using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace PersonalProject
{

    //REVIEW_NUMBER, ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, REGIST_DATETIME, DELETED
    public class Review
    {
        public int ReviewNumber { get; set; }
        public int OrderDetailCode { get; set; }
        public int ProductCode { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Score { get; set; }
        public DateTime RegistDateTime { get; set; }
        public bool Deleted { get; set; }
        public string CustomerID { get; set; }
    }
    public class ReviewDAC : IDisposable
    {
        MySqlConnection conn;

        public ReviewDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetReviews()
        {
            try
            {
                string sql = @"select rv.REVIEW_NUMBER, od.ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, rv.REGIST_DATETIME, DELETED, c.CUSTOMER_ID, CUSTOMER_NAME, p.PRODUCT_CODE, PRODUCT_NAME, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, b.BRAND_ID, BRAND_NAME, PRODUCT_IMG_CODE, SERVER_PATH
from review rv inner join order_detail od on rv.ORDER_DETAIL_CODE = od.ORDER_DETAIL_CODE
inner join order_master om on om.ORDER_NUMBER = od.ORDER_NUMBER
inner join customer c on c.CUSTOMER_ID = om.CUSTOMER_ID
inner join product p on od.PRODUCT_CODE = p.PRODUCT_CODE 
inner join brand b on p.BRAND_ID = b.BRAND_ID 
inner join (select CCODE, CNAME from common_code where CATEGORY='사이즈') sz on sz.CCODE = p.SIZE
inner join (select CCODE, CNAME from common_code where CATEGORY='색상') cl on cl.CCODE = p.COLOR
left outer join (select PRODUCT_IMG_CODE, PRODUCT_CODE, SERVER_PATH, REVIEW_NUMBER
				 		    from product_img
						    where IMG_DIV = 'I005') pimg on rv.REVIEW_NUMBER = pimg.REVIEW_NUMBER
where DELETED=0";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                //da.SelectCommand.Parameters.AddWithValue("@ORDER_NUMBER", orderNumber);
                da.Fill(dt);

                //return true;
                return dt;

            }
            catch (Exception err)
            {
                throw err;
                //return false;
            }
            finally
            {
                Dispose();
            }
        }


        public bool Insert(Review rv, string[] imgPaths)
        {
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {

                //MySqlCommand cmd0 = new MySqlCommand();
                //cmd0.Connection = conn;
                //cmd0.CommandText = "select count(ORDER_DETAIL_CODE) from review where ORDER_DETAIL_CODE = @ORDER_DETAIL_CODE";
                //cmd0.Parameters.AddWithValue("@ORDER_DETAIL_CODE", rv.OrderDetailCode);
                //cmd0.Transaction = trans;
                if (! IsUploaded(rv.OrderDetailCode))
                {
                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandText = "update customer set ACCUMULATE_POINT = ACCUMULATE_POINT + 100 where CUSTOMER_ID = '@CUSTOMER_ID'";
                    cmd3.Parameters.AddWithValue("@CUSTOMER_ID", rv.CustomerID);
                    cmd3.Transaction = trans;
                    cmd3.ExecuteScalar();
                }

                string sql = @"insert into review(ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE) values(@ORDER_DETAIL_CODE, @TITLE, @CONTENTS, @SCORE);select last_insert_id()";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ORDER_DETAIL_CODE", rv.OrderDetailCode);
                cmd.Parameters.AddWithValue("@TITLE", rv.Title);
                cmd.Parameters.AddWithValue("@CONTENTS", rv.Contents);
                cmd.Parameters.AddWithValue("@SCORE", rv.Score);

                cmd.Transaction = trans;
                rv.ReviewNumber = Convert.ToInt32(cmd.ExecuteScalar());

                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into product_img(PRODUCT_CODE, SERVER_PATH, IMG_DIV, REVIEW_NUMBER) values(@PRODUCT_CODE, @SERVER_PATH, 'I005', @REVIEW_NUMBER)";
                cmd2.Transaction = trans;
                cmd2.Parameters.Add("@PRODUCT_CODE", MySqlDbType.Int32);
                cmd2.Parameters.Add("@SERVER_PATH", MySqlDbType.VarString);
                cmd2.Parameters.Add("@REVIEW_NUMBER", MySqlDbType.Int32);

                for (int i = 0; i < imgPaths.Length; i++)
                {
                    cmd2.Parameters["@PRODUCT_CODE"].Value = rv.ProductCode;
                    cmd2.Parameters["@SERVER_PATH"].Value = imgPaths[i];
                    cmd2.Parameters["@REVIEW_NUMBER"].Value = rv.ReviewNumber;
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

        public bool IsUploaded(int orderDetailCode)
        {
            try
            {
                MySqlCommand cmd0 = new MySqlCommand();
                cmd0.Connection = conn;
                cmd0.CommandText = "select count(ORDER_DETAIL_CODE) from review where ORDER_DETAIL_CODE = @ORDER_DETAIL_CODE";
                cmd0.Parameters.AddWithValue("@ORDER_DETAIL_CODE", orderDetailCode);
                
                return (Convert.ToInt32(cmd0.ExecuteScalar()) > 0);
                   
            }
            catch (Exception err)
            {
                throw err;
            }
            //finally
            //{
            //    Dispose();
            //}

        }

        public DataTable IsNotUpload(string customerID)
        {
            try
            {
                string sql = @"select ORDER_DETAIL_CODE, om.ORDER_NUMBER, p.PRODUCT_CODE, ORDER_QUANTITY,
PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME,
b.BRAND_ID, BRAND_NAME, (select SERVER_PATH from product_img where IMG_DIV='I001' and PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME=p.PRODUCT_NAME)) PRODUCT_IMG
from order_detail od inner join product p on od.PRODUCT_CODE = p.PRODUCT_CODE 
inner join order_master om on od.ORDER_NUMBER = om.ORDER_NUMBER 
inner join brand b on p.BRAND_ID = b.BRAND_ID 
inner join (select CCODE, CNAME from common_code where CATEGORY='사이즈') sz on sz.CCODE = p.SIZE
inner join (select CCODE, CNAME from common_code where CATEGORY='색상') cl on cl.CCODE = p.COLOR
where om.CUSTOMER_ID=@CUSTOMER_ID and ORDER_DETAIL_CODE not in (select ORDER_DETAIL_CODE from review)";


                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@CUSTOMER_ID", customerID);

                DataTable dt = new DataTable();
                da.Fill(dt);
                Dispose();

                return dt;

            }
            catch (Exception err)
            {
                throw err;
            }


        }

        public bool Update(Review rv, string[] imgPaths)
        {
            MySqlTransaction trans = conn.BeginTransaction();


            try
            {
                string sql = @"update review set TITLE=@TITLE, CONTENTS=@CONTENTS, SCORE=@SCORE, REGIST_DATETIME=now() 
where REVIEW_NUMBER=@REVIEW_NUMBER";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TITLE", rv.Title);
                cmd.Parameters.AddWithValue("@CONTENTS", rv.Contents);
                cmd.Parameters.AddWithValue("@SCORE", rv.Score);
                cmd.Parameters.AddWithValue("@REVIEW_NUMBER", rv.ReviewNumber);


                cmd.Transaction = trans;
                int bup = cmd.ExecuteNonQuery();

                if (imgPaths.Length > 0)
                {
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = "insert into product_img(PRODUCT_CODE, SERVER_PATH, IMG_DIV, REVIEW_NUMBER) values(@PRODUCT_CODE, @SERVER_PATH, 'I005', @REVIEW_NUMBER)";
                    cmd2.Transaction = trans;
                    cmd2.Parameters.Add("@PRODUCT_CODE", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@SERVER_PATH", MySqlDbType.VarString);
                    cmd2.Parameters.Add("@REVIEW_NUMBER", MySqlDbType.Int32);

                    for (int i = 0; i < imgPaths.Length; i++)
                    {
                        cmd2.Parameters["@PRODUCT_CODE"].Value = rv.ProductCode;
                        cmd2.Parameters["@SERVER_PATH"].Value = imgPaths[i];
                        cmd2.Parameters["@REVIEW_NUMBER"].Value = rv.ReviewNumber;
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

        public int Delete(int reviewNum)
        {
            string sql = @"update review set Deleted = 1 where REVIEW_NUMBER=@REVIEW_NUMBER";
            //string sql = @"delete from q_and_a where CONTACT_NUMBER=@CONTACT_NUMBER";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@REVIEW_NUMBER", reviewNum);

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

    }
}
