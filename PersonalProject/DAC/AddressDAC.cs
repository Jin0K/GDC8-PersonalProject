using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject
{
    public class Address
    {
        public int Number { get; set; }
        //public string ID { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CustomerID { get; set; }
        public char BaseAddress { get; set; }
    }

    public class AddressDAC : IDisposable
    {
        MySqlConnection conn;

        public AddressDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();           
        }

        public void Dispose()
        {
            conn.Close();
        }

        public Address GetAddress(int addressNumber)
        {
            string sql = "select ADDRESS_NUMBER, CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, BASE_ADDRESS from address where ADDRESS_NUMBER = @ADDRESS_NUMBER";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ADDRESS_NUMBER", addressNumber);

            MySqlDataReader reader = cmd.ExecuteReader();
            Address addr = new Address();
            if (reader.Read()) //select 결과가 한개의 행으로 나올때 
            {
                addr.Number = Convert.ToInt32(reader["ADDRESS_NUMBER"].ToString());
                addr.Name = reader["ADDRESS_NAME"].ToString();
    
                addr.ZipCode = reader["ZIP_CODE"].ToString();
                addr.Address1 = reader["ADDRESS1"].ToString();
                addr.Address2 = reader["ADDRESS2"].ToString();

            }
 
            return addr;
        }

        public DataTable GetAddress(string customerId)
        {
            string sql = "select ADDRESS_NUMBER, CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, BASE_ADDRESS from address where CUSTOMER_ID = @CUSTOMER_ID";
            
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@CUSTOMER_ID", customerId);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }

        public bool Insert(Address addr)
        {
            try
            {
                string sql = @"insert into address(CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2) values(@CUSTOMER_ID, @ADDRESS_NAME, @ZIP_CODE, @ADDRESS1, @ADDRESS2);select last_insert_id();";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CUSTOMER_ID", addr.CustomerID);
                cmd.Parameters.AddWithValue("@ADDRESS_NAME", addr.Name);
                cmd.Parameters.AddWithValue("@ZIP_CODE", addr.ZipCode);
                cmd.Parameters.AddWithValue("@ADDRESS1", addr.Address1);
                cmd.Parameters.AddWithValue("@ADDRESS2", addr.Address2);

                addr.Number = Convert.ToInt32(cmd.ExecuteScalar());

                return (addr.Number > 0);
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

        public bool Update(Address addr)
        {
            try
            {
                string sql = @"update address set ADDRESS_NAME=@ADDRESS_NAME, ZIP_CODE=@ZIP_CODE, ADDRESS1=@ADDRESS1, ADDRESS2=@ADDRESS2 where ADDRESS_NUMBER=@ADDRESS_NUMBER";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ADDRESS_NAME", addr.Name);
                cmd.Parameters.AddWithValue("@ZIP_CODE", addr.ZipCode);
                cmd.Parameters.AddWithValue("@ADDRESS1", addr.Address1);
                cmd.Parameters.AddWithValue("@ADDRESS2", addr.Address2);
                cmd.Parameters.AddWithValue("@ADDRESS_NUMBER", addr.Number);

                int iRowsAffect = cmd.ExecuteNonQuery();
                return (iRowsAffect > 0);

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

        public bool Delete(Address addr)
        {
            try
            {
                string sql = @"delete from address where ADDRESS_NUMBER=@ADDRESS_NUMBER";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ADDRESS_NUMBER", addr.Number);

                int iRowsAffect = cmd.ExecuteNonQuery();
                return (iRowsAffect > 0);

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

        public bool UpdateBaseAddress(Address addr)
        {
            try
            {

                string sql = @"update address set BASE_ADDRESS = 'N' where CUSTOMER_ID=@CUSTOMER_ID;
update address set BASE_ADDRESS = 'Y' 
where ADDRESS_NUMBER=@ADDRESS_NUMBER";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", addr.CustomerID);
                cmd.Parameters.AddWithValue("@ADDRESS_NUMBER", addr.Number);
                int iRowsAffect = cmd.ExecuteNonQuery();
                return (iRowsAffect > 0);

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
        public bool IsVaildName(Address addr)
        {
            string sql = "select count(*) from address where ADDRESS_NAME = @ADDRESS_NAME and ADDRESS_NUMBER=@ADDRESS_NUMBER";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ADDRESS_NAME", addr.Name);
            cmd.Parameters.AddWithValue("@ADDRESS_NUMBER", addr.Number);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            Dispose();

            return (cnt > 0);

        }

        //public DataTable GetAddress()
        //{
        //    string sql = "select ADDRESS_NUMBER, CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2 from address where CUSTOMER_ID = @CUSTOMER_ID";

        //    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
        //    da.SelectCommand.Parameters.AddWithValue("@CUSTOMER_ID", );

        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    Dispose();

        //    return dt;
        //}
    }
}
