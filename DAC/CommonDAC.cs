using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using static CommonVO;
using System.Windows.Forms;

namespace PersonalProject
{
    public class CommonDAC : IDisposable
    {
        MySqlConnection conn;

        public CommonDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        /// <summary>
        /// DB로부터 공통코드 리스트 추출
        /// </summary>
        /// <param name="categories">카테고리들 </param>
        /// <returns></returns>
        public List<CommonVO> GetCodeList(string[] categories)
        {
            string category = string.Join("','", categories);

            string sql = $@"select Code, Name, Category, P_Code
from VW_ComboBindingList 
where Category in ('{category}')";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            List<CommonVO> list;

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    list = Helper.DataReaderMapToList<CommonVO>(reader);
                    //Helper.DataReaderMapToList()메서드를 실행하고
                    //에러가 나지 않았는데, list = null로 경우

                    //while (reader.Read())
                    //{
                    //    ComboItemVO item = new ComboItemVO();
                    //    item.Code = reader["Code"].ToString();
                    //    item.CodeName = reader["CodeName"].ToString();
                    //    item.Category = reader["Category"].ToString();

                    //    list.Add(item);
                    //}
                }

                return list;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                throw;
            }
        }


        public DataTable GetOneCommonCodes(string category, string pCode)
        {
            string sql;

            if (string.IsNullOrWhiteSpace(pCode))
            {
                sql = "select CCODE, CNAME, CATEGORY from common_code where CATEGORY=@category and PCode is @pCode";
            }
            else
            {
                sql = "select CCODE, CNAME, CATEGORY from common_code where CATEGORY=@category and PCode = @pCode";
            }

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@category", category);
            da.SelectCommand.Parameters.AddWithValue("@pCode", pCode);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }

        /// <summary>
        /// DB로부터 각 단위의 상위 단위 추출
        /// </summary>
        /// <returns></returns>
        public List<CommonVO> GetParentUnit()
        {
            string sql = $@"select c.Code, p.Code as P_Code, p.Name
from Common_Code c
inner join Common_Code p
on c.P_Code = p.Code
where c.Category = '단위' and p.Name <> '단위'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            List<CommonVO> list;

            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    list = Helper.DataReaderMapToList<CommonVO>(reader);
                }

                return list;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                throw;
            }
        }


        public DataTable GetCommonCodes(string[] category)
        {
            string temp = "'" + string.Join("','", category) + "'"; //"색상','SCHOOL','JOB"

            string sql = "select CCODE, CATEGORY, CNAME, PCODE from common_code where CATEGORY in (" + temp + ");";  //'색상','SCHOOL','JOB'

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }

        public DataTable GetProductCommonCodes(string[] category, string[] productCol, string productName)
        {
            //string temp = "'" + string.Join("','", category) + "'"; //"색상','SCHOOL','JOB"
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < category.Length; i++)
            {
                if (sb.Length < 1)
                    sb.Append($"(CATEGORY='{category[i]}' and CCODE in (select {productCol[i]} from product where PRODUCT_NAME=@PRODUCT_NAME))");
                else
                    sb.Append($" or (CATEGORY = '{category[i]}' and CCODE in (select {productCol[i]} from product where PRODUCT_NAME = @PRODUCT_NAME))");
            }
            sb.Insert(0, @"select CCODE, CATEGORY, CNAME, PCODE
from common_code
where ");
            string sql = sb.ToString();
            //string sql = "select CCODE, CATEGORY, CNAME, PCODE from common_code where CATEGORY in (" + temp + ");";  //'색상','SCHOOL','JOB'

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@PRODUCT_NAME", productName);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }

        //존재시 0보다 큰 값 반환
        public bool IsVaildValue(DivTable div, string column, string value)
        {
            string table;
            if (div == DivTable.Customer)
            {
                table = "customer";
            }
            else if (div == DivTable.Brand)
            {
                table = "brand";
            }
            else
            {
                return false;
            }

            string sql = $"select count(*) from {table} where {column} = @value";

            //string sql = "select count(*) from customer where customer_id = @customerId";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@value", value);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            //Dispose();

            return (cnt > 0);

        }

        public bool ConfirmUser(DivTable div, string id, string name, string email1, string email2)
        {
            string table, idCol, nameCol, email1Col, email2Col;
            if (div == DivTable.Customer)
            {
                table = "customer";
                idCol = "CUSTOMER_ID";
                nameCol = "CUSTOMER_NAME";
                email1Col = "EMAIL1"; 
                email2Col = "EMAIL2";
                //sql = "select count(*) from customer where  = @CUSTOMER_ID and CUSTOMER_NAME = @CUSTOMER_NAME and EMAIL1 = @EMAIL1 and EMAIL2 = @EMAIL2";
            }
            else if (div == DivTable.Brand)
            {
                table = "brand";
                idCol = "BRAND_ID";
                nameCol = "BRAND_NAME";
                email1Col = "BRAND_EMAIL1";
                email2Col = "BRAND_EMAIL2";
                //sql = "select count(*) from brand where BRAND_ID = @BRAND_ID and BRAND_NAME = @BRAND_NAME and BRAND_EMAIL1 = @BRAND_EMAIL1 and BRAND_EMAIL2 = @BRAND_EMAIL2";
            }
            else
                return false;

            string sql = $"select count(*) from {table} where {idCol} = @ID and {nameCol} = @NAME and {email1Col} = @EMAIL1 and {email2Col} = @EMAIL2";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@EMAIL1", email1);
            cmd.Parameters.AddWithValue("@EMAIL2", email2);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return (cnt > 0);
        }

        public string ConfirmUser(DivTable div, string name, string email1, string email2)
        {
            string table, idCol, nameCol, email1Col, email2Col;
            if (div == DivTable.Customer)
            {
                table = "customer";
                idCol = "CUSTOMER_ID";
                nameCol = "CUSTOMER_NAME";
                email1Col = "EMAIL1";
                email2Col = "EMAIL2";
                //sql = "select count(*) from customer where  = @CUSTOMER_ID and CUSTOMER_NAME = @CUSTOMER_NAME and EMAIL1 = @EMAIL1 and EMAIL2 = @EMAIL2";
            }
            else if (div == DivTable.Brand)
            {
                table = "brand";
                idCol = "BRAND_ID";
                nameCol = "BRAND_NAME";
                email1Col = "BRAND_EMAIL1";
                email2Col = "BRAND_EMAIL2";
                //sql = "select count(*) from brand where BRAND_ID = @BRAND_ID and BRAND_NAME = @BRAND_NAME and BRAND_EMAIL1 = @BRAND_EMAIL1 and BRAND_EMAIL2 = @BRAND_EMAIL2";
            }
            else
                return null;

            string sql = $"select {idCol} from {table} where {nameCol} = @NAME and {email1Col} = @EMAIL1 and {email2Col} = @EMAIL2";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@NAME", name);
            cmd.Parameters.AddWithValue("@EMAIL1", email1);
            cmd.Parameters.AddWithValue("@EMAIL2", email2);

            string id = cmd.ExecuteScalar() as string;

            return id;

        }

        public bool UpdatePWD(DivTable div, string uid, string newPwd)
        {
            string table, PwdCol, IdCol;
            if (div == DivTable.Customer)
            {
                table = "customer";
                PwdCol = "CUSTOMER_PASSWORD";
                IdCol = "CUSTOMER_ID";
            }
            else if (div == DivTable.Brand)
            {
                table = "brand";
                PwdCol = "BRAND_PASSWORD";
                IdCol = "BRAND_ID";
            }
            else
            {
                return false;
            }
            string sql = $"update {table} set {PwdCol} = @PWD where {IdCol}=@ID";
         
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PWD", newPwd);
            cmd.Parameters.AddWithValue("@ID", uid);
            int iRowsAffect = cmd.ExecuteNonQuery();
            return (iRowsAffect > 0);
        }
    }
}
