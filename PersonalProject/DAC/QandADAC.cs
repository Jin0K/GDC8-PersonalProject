using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalProject
{
    public class QandA
    {
        //CONTACT_NUMBER, CUSTOMER_ID, PRODUCT_CODE, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, REGIST_DATETIME, ANSWER, ANSWER_DATETIME
        public int ContactNumber { get; set; }
        public string CustomerID { get; set; }
        public string BrandID { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string QuestionType { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public bool Secret { get; set; }
        public int Hits { get; set; }
        public DateTime RegistDateTime { get; set; }
        public string Answer { get; set; }
        public DateTime AnswerDateTime { get; set; }
    }
    public class QandADAC : IDisposable
    {
        MySqlConnection conn;

        public QandADAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }


        public bool InsertQuestion(QandA qa, string[] imgPaths)
        {
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"insert into q_and_a(CUSTOMER_ID, PRODUCT_CODE, QUESTION_TYPE, TITLE, CONTENTS, SECRET) values(@CUSTOMER_ID, @PRODUCT_CODE, @QUESTION_TYPE, @TITLE, @CONTENTS, @SECRET);select last_insert_id()";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CUSTOMER_ID", qa.CustomerID);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", qa.ProductCode);
                cmd.Parameters.AddWithValue("@QUESTION_TYPE", qa.QuestionType);
                cmd.Parameters.AddWithValue("@TITLE", qa.Title);
                cmd.Parameters.AddWithValue("@CONTENTS", qa.Contents);
                cmd.Parameters.AddWithValue("@SECRET", qa.Secret);

                cmd.Transaction = trans;
                qa.ContactNumber = Convert.ToInt32(cmd.ExecuteScalar());

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into product_img(PRODUCT_CODE, SERVER_PATH, IMG_DIV, CONTACT_NUMBER) values(@PRODUCT_CODE, @SERVER_PATH, 'I004', @CONTACT_NUMBER)";
                cmd2.Transaction = trans;
                cmd2.Parameters.Add("@PRODUCT_CODE", MySqlDbType.Int32);
                cmd2.Parameters.Add("@SERVER_PATH", MySqlDbType.VarString);
                cmd2.Parameters.Add("@CONTACT_NUMBER", MySqlDbType.Int32);

                for (int i = 0; i < imgPaths.Length; i++)
                {
                    cmd2.Parameters["@PRODUCT_CODE"].Value = qa.ProductCode;
                    cmd2.Parameters["@SERVER_PATH"].Value = imgPaths[i];
                    cmd2.Parameters["@CONTACT_NUMBER"].Value = qa.ContactNumber;
                    cmd2.ExecuteNonQuery();

                }

                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
            finally
            {
                Dispose();
            }

        }


        public DataTable GetAllQA()
        {
            string sql = @"select qa.CONTACT_NUMBER, CUSTOMER_ID, p.PRODUCT_CODE, PRODUCT_NAME, BRAND_ID, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, qa.REGIST_DATETIME, ANSWER, ANSWER_DATETIME, 
PRODUCT_IMG_CODE, SERVER_PATH
from q_and_a qa inner join product p on qa.PRODUCT_CODE = p.PRODUCT_CODE
 			    left outer join (select PRODUCT_IMG_CODE, PRODUCT_CODE, SERVER_PATH, CONTACT_NUMBER
				 		    from product_img
						    where IMG_DIV = 'I004') pimg on qa.CONTACT_NUMBER = pimg.CONTACT_NUMBER";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }

        public DataTable GetProductQA(string productName)
        {
            string sql = @"select qa.CONTACT_NUMBER, CUSTOMER_ID, p.PRODUCT_CODE, PRODUCT_NAME, BRAND_ID, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, qa.REGIST_DATETIME, ANSWER, ANSWER_DATETIME, 
PRODUCT_IMG_CODE, SERVER_PATH 
from q_and_a qa inner join product p on qa.PRODUCT_CODE = p.PRODUCT_CODE
			   left outer join (select PRODUCT_IMG_CODE, PRODUCT_CODE, SERVER_PATH, CONTACT_NUMBER
						   from product_img
						   where IMG_DIV = 'I004') pimg on qa.CONTACT_NUMBER = pimg.CONTACT_NUMBER
where PRODUCT_NAME=@PRODUCT_NAME";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@PRODUCT_NAME", productName);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }

        public bool Update(QandA qa, string[] imgPaths)
        {
            MySqlTransaction trans = conn.BeginTransaction();


            try
            {
                string sql = @"update q_and_a
set CUSTOMER_ID=@CUSTOMER_ID, PRODUCT_CODE=@PRODUCT_CODE, QUESTION_TYPE=@QUESTION_TYPE, TITLE=@TITLE, CONTENTS=@CONTENTS, SECRET=@SECRET, HITS=@HITS, ANSWER=@ANSWER, ANSWER_DATETIME=@ANSWER_DATETIME 
where CONTACT_NUMBER=@CONTACT_NUMBER";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", qa.CustomerID);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", qa.ProductCode);
                cmd.Parameters.AddWithValue("@QUESTION_TYPE", qa.QuestionType);
                cmd.Parameters.AddWithValue("@TITLE", qa.Title);
                cmd.Parameters.AddWithValue("@CONTENTS", qa.Contents);
                cmd.Parameters.AddWithValue("@SECRET", qa.Secret);
                cmd.Parameters.AddWithValue("@HITS", qa.Hits+1);
                cmd.Parameters.AddWithValue("@ANSWER", qa.Answer);
                cmd.Parameters.AddWithValue("@ANSWER_DATETIME", qa.AnswerDateTime);
                cmd.Parameters.AddWithValue("@CONTACT_NUMBER", qa.ContactNumber);

                cmd.Transaction = trans;
                cmd.ExecuteScalar();

                if (imgPaths.Length > 0)
                {
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into product_img(PRODUCT_CODE, SERVER_PATH, IMG_DIV, CONTACT_NUMBER) values(@PRODUCT_CODE, @SERVER_PATH, 'I004', @CONTACT_NUMBER)";
                    cmd2.Transaction = trans;
                    cmd2.Parameters.Add("@PRODUCT_CODE", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@SERVER_PATH", MySqlDbType.VarString);
                    cmd2.Parameters.Add("@CONTACT_NUMBER", MySqlDbType.Int32);

                    for (int i = 0; i < imgPaths.Length; i++)
                    {
                        cmd2.Parameters["@PRODUCT_CODE"].Value = qa.ProductCode;
                        cmd2.Parameters["@SERVER_PATH"].Value = imgPaths[i];
                        cmd2.Parameters["@CONTACT_NUMBER"].Value = qa.ContactNumber;
                        cmd2.ExecuteNonQuery();

                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
            finally
            {
                Dispose();
            }
        }

        public int Delete(int contactNum)
        {
            string sql = @"update q_and_a set Deleted = 1 where CONTACT_NUMBER=@CONTACT_NUMBER";
            //string sql = @"delete from q_and_a where CONTACT_NUMBER=@CONTACT_NUMBER";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CONTACT_NUMBER", contactNum);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw err;
                //MessageBox.Show(err.Message);
                //return -1;
            }
            finally
            {
                Dispose();
            }
        }

        public int UpdateHits(int contactNum)
        {
            string sql = @"update q_and_a set HITS = HITS + 1 where CONTACT_NUMBER=@CONTACT_NUMBER";
            //string sql = @"delete from q_and_a where CONTACT_NUMBER=@CONTACT_NUMBER";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CONTACT_NUMBER", contactNum);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                Dispose();
            }
        }

    }
}
