using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace PersonalProject
{
    //public class Customer
    //{
    //    public string ID { get; set; }
    //    public string Password { get; set; }
    //    public string Name { get; set; }
    //    public char Gender { get; set; }
    //    public DateTime Birth { get; set; }
    //    public string Email1 { get; set; }
    //    public string Email2 { get; set; }
    //    public string Phone1 { get; set; }
    //    public string Phone2 { get; set; }
    //    public string Phone3 { get; set; }
    //    public int Point { get; set; }
    //    public DateTime RegistDate { get; set; }
    //    public char Admin { get; set; }
    //    public int BaseAddress { get; set; }
    //}

    

    public class CustomerDAC : IDisposable
    {        
        MySqlConnection conn;
        public CustomerDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        //ID 존재시 0보다 큰 값 반환
        public bool IsVaildID(string id)
        {
            string sql = "select count(*) from customer where customer_id = @customerId";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@customerId", id);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            //Dispose();

            return (cnt > 0);

        }


//        public DataTable GetUserAllCodes()
//        {
//            string sql = @"select cast(StudentID as char) Code, StudentName Name, 'student' Category from student
//union
//select cast(BookID as char) Code, BookName Name, 'book' Category from book";

//            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
//            DataTable dt = new DataTable();
//            da.Fill(dt);

//            return dt;
//        }

//        public DataSet GetUserCodes()
//        {
//            DataSet ds = new DataSet();
//            ds.Tables.Add(GetStudents());
//            ds.Tables.Add(GetBooks());

//            return ds;
//        }

//        private DataTable GetStudents()
//        {
//            string sql = "select StudentID, StudentName from student";
//            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
//            DataTable dt = new DataTable();
//            da.Fill(dt);

//            return dt;
//        }

//        private DataTable GetBooks()
//        {
//            string sql = "select BookID, BookName from book";
//            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
//            DataTable dt = new DataTable();
//            da.Fill(dt);

//            return dt;
//        }

        public bool Insert(Customer ct, Address addr)
        {
            //ID,Password,Name,Gender,Birth,Email1,Email2,Phone1,Phone2,Phone3

            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                
                string sql = "insert into customer(CUSTOMER_ID, CUSTOMER_PASSWORD, CUSTOMER_NAME, GENDER, BIRTH, EMAIL1, EMAIL2, PHONE1, PHONE2, PHONE3, ADMIN_DIV) values(@CUSTOMER_ID, @CUSTOMER_PASSWORD, @CUSTOMER_NAME, @GENDER, @BIRTH, @EMAIL1, @EMAIL2, @PHONE1, @PHONE2, @PHONE3, 'C')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", ct.ID);
                cmd.Parameters.AddWithValue("@CUSTOMER_PASSWORD", ct.Password);
                cmd.Parameters.AddWithValue("@CUSTOMER_NAME", ct.Name);
                cmd.Parameters.AddWithValue("@GENDER", ct.Gender);
                cmd.Parameters.AddWithValue("@BIRTH", ct.Birth);
                cmd.Parameters.AddWithValue("@EMAIL1", ct.Email1);
                cmd.Parameters.AddWithValue("@EMAIL2", ct.Email2);
                cmd.Parameters.AddWithValue("@PHONE1", ct.Phone1);
                cmd.Parameters.AddWithValue("@PHONE2", ct.Phone2);
                cmd.Parameters.AddWithValue("@PHONE3", ct.Phone3);

                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();

                cmd.Parameters.AddWithValue("@ADDRESS_NAME", addr.Name);
                cmd.Parameters.AddWithValue("@ZIP_CODE", addr.ZipCode);
                cmd.Parameters.AddWithValue("@ADDRESS1", addr.Address1);
                cmd.Parameters.AddWithValue("@ADDRESS2", addr.Address2);

                //Command  Connection, CommandText, CommandType, Parameter, Transaction
                cmd.CommandText = @"insert into address(CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, BASE_ADDRESS) values(@CUSTOMER_ID, @ADDRESS_NAME, @ZIP_CODE, @ADDRESS1, @ADDRESS2, 'Y');select last_insert_id();";
                addr.Number = Convert.ToInt32(cmd.ExecuteScalar());
                ct.BaseAddress = addr.Number;

                //return cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
            //}
            //catch (Exception err)
            //{
            //    Debug.WriteLine(err.Message);
            //    return -1;
            //}
            finally
            {
                Dispose();
            }



        }

        public Customer Login(string cID)
        {
            string sql = "select CUSTOMER_ID, CUSTOMER_PASSWORD, CUSTOMER_NAME, GENDER, BIRTH, EMAIL1, EMAIL2, PHONE1, PHONE2, PHONE3, ACCUMULATE_POINT, REGIST_DATE, ADMIN_DIV from customer where CUSTOMER_ID=@CUSTOMER_ID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CUSTOMER_ID", cID);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Customer login = new Customer();
                login.ID = reader["CUSTOMER_ID"].ToString();
                login.Password = reader["CUSTOMER_PASSWORD"].ToString();
                login.Name = reader["CUSTOMER_NAME"].ToString();
                login.Gender = char.Parse(reader["GENDER"].ToString());
                login.Birth = (DateTime)reader["BIRTH"];
                login.Email1 = reader["EMAIL1"].ToString();
                login.Email2 = reader["EMAIL2"].ToString();
                login.Phone1 = reader["PHONE1"].ToString();
                login.Phone2 = reader["PHONE2"].ToString();
                login.Phone3 = reader["PHONE3"].ToString();
                login.Point = Convert.ToInt32(reader["ACCUMULATE_POINT"]);
                login.RegistDate = (DateTime)reader["REGIST_DATE"];
                login.Admin = char.Parse(reader["ADMIN_DIV"].ToString());

                Dispose();
                return login;
            }
            else
            {
                Dispose();
                return null;
            }
        }
        public bool ConfirmUser(string id, string name, string email1, string email2)
        {
            string sql = "select count(*) from customer where CUSTOMER_ID = @CUSTOMER_ID and CUSTOMER_NAME = @CUSTOMER_NAME and EMAIL1 = @EMAIL1 and EMAIL2 = @EMAIL2";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CUSTOMER_ID", id);
            cmd.Parameters.AddWithValue("@CUSTOMER_NAME", name);
            cmd.Parameters.AddWithValue("@EMAIL1", email1);
            cmd.Parameters.AddWithValue("@EMAIL2", email2);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return (cnt > 0);
        }

        public bool Update(Customer ct, Address addr)
        {
            //ID,Password,Name,Gender,Birth,Email1,Email2,Phone1,Phone2,Phone3

            MySqlTransaction trans = conn.BeginTransaction();

            try
            {

                string sql = "update customer set CUSTOMER_PASSWORD=@CUSTOMER_PASSWORD, CUSTOMER_NAME=@CUSTOMER_NAME, GENDER=@GENDER, BIRTH=@BIRTH, EMAIL1=@EMAIL1, EMAIL2=@EMAIL2, PHONE1=@PHONE1, PHONE2=@PHONE2, PHONE3=@PHONE3 where CUSTOMER_ID=@CUSTOMER_ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", ct.ID);
                cmd.Parameters.AddWithValue("@CUSTOMER_PASSWORD", ct.Password);
                cmd.Parameters.AddWithValue("@CUSTOMER_NAME", ct.Name);
                cmd.Parameters.AddWithValue("@GENDER", ct.Gender);
                cmd.Parameters.AddWithValue("@BIRTH", ct.Birth);
                cmd.Parameters.AddWithValue("@EMAIL1", ct.Email1);
                cmd.Parameters.AddWithValue("@EMAIL2", ct.Email2);
                cmd.Parameters.AddWithValue("@PHONE1", ct.Phone1);
                cmd.Parameters.AddWithValue("@PHONE2", ct.Phone2);
                cmd.Parameters.AddWithValue("@PHONE3", ct.Phone3);

                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();

                cmd.Parameters.AddWithValue("@ADDRESS_NAME", addr.Name);
                cmd.Parameters.AddWithValue("@ZIP_CODE", addr.ZipCode);
                cmd.Parameters.AddWithValue("@ADDRESS1", addr.Address1);
                cmd.Parameters.AddWithValue("@ADDRESS2", addr.Address2);

                //Command  Connection, CommandText, CommandType, Parameter, Transaction
                cmd.CommandText = @"update address set ADDRESS_NAME=@ADDRESS_NAME, ZIP_CODE=@ZIP_CODE, ADDRESS1=@ADDRESS1, ADDRESS2=@ADDRESS2 where CUSTOMER_ID=@CUSTOMER_ID and ADDRESS_NUMBER=@ADDRESS_NUMBER";
                cmd.ExecuteScalar();

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

    }
}
