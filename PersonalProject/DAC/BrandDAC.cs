using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject
{
    //BRAND_ID, BRAND_NAME, COMPANY_REGIST_NUMBER, BRAND_PASSWORD, LOGO_IMG_PATH, BRAND_EMAIL1, BRAND_EMAIL2, BRAND_CONTACT, BRAND_ADDRESS, COUNTRY
    public class Brand
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string CompanyNumber { get; set; }
        public string Password { get; set; }
        public string LogoImagePath { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
    public class BrandDAC : IDisposable
    {
        MySqlConnection conn;
        public BrandDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public bool IsVaildID(string id)
        {
            string sql = "select count(*) from brand where brand_id = @brandId";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@brandId", id);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            //Dispose();

            return (cnt > 0);

        }

        internal int Insert(Brand brand)
        {
            

            //BRAND_ID, BRAND_NAME, COMPANY_REGIST_NUMBER, BRAND_PASSWORD, LOGO_IMG_PATH, BRAND_EMAIL1, BRAND_EMAIL2, BRAND_CONTACT, BRAND_ADDRESS, COUNTRY

            string sql = @"insert into brand(BRAND_ID, BRAND_NAME, COMPANY_REGIST_NUMBER, BRAND_PASSWORD, LOGO_IMG_PATH, BRAND_EMAIL1, BRAND_EMAIL2, BRAND_CONTACT, BRAND_ADDRESS, COUNTRY) 
values(@BRAND_ID, @BRAND_NAME, @COMPANY_REGIST_NUMBER, @BRAND_PASSWORD, @LOGO_IMG_PATH, @BRAND_EMAIL1, @BRAND_EMAIL2, @BRAND_CONTACT, @BRAND_ADDRESS, @COUNTRY)";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@BRAND_ID", brand.ID);
                cmd.Parameters.AddWithValue("@BRAND_NAME", brand.Name);
                cmd.Parameters.AddWithValue("@COMPANY_REGIST_NUMBER", brand.CompanyNumber);
                cmd.Parameters.AddWithValue("@BRAND_PASSWORD", brand.Password);
                cmd.Parameters.AddWithValue("@LOGO_IMG_PATH", brand.LogoImagePath);
                cmd.Parameters.AddWithValue("@BRAND_EMAIL1", brand.Email1);
                cmd.Parameters.AddWithValue("@BRAND_EMAIL2", brand.Email2);
                cmd.Parameters.AddWithValue("@BRAND_CONTACT", brand.Contact);
                cmd.Parameters.AddWithValue("@BRAND_ADDRESS", brand.Address);
                cmd.Parameters.AddWithValue("@COUNTRY", brand.Country);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return -1;
            }
            finally
            {
                Dispose();
            }
        }
        public Brand Login(string bID)
        {
            string sql = "select BRAND_ID, BRAND_NAME, COMPANY_REGIST_NUMBER, BRAND_PASSWORD, LOGO_IMG_PATH, BRAND_EMAIL1, BRAND_EMAIL2, BRAND_CONTACT, BRAND_ADDRESS, COUNTRY from brand where BRAND_ID=@BRAND_ID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@BRAND_ID", bID);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Brand login = new Brand();
                login.ID = reader["BRAND_ID"].ToString();
                login.Name = reader["BRAND_NAME"].ToString();
                login.CompanyNumber = reader["COMPANY_REGIST_NUMBER"].ToString();
                login.Password = reader["BRAND_PASSWORD"].ToString();
                login.LogoImagePath = reader["LOGO_IMG_PATH"].ToString();
                login.Email1 = reader["BRAND_EMAIL1"].ToString();
                login.Email2 = reader["BRAND_EMAIL2"].ToString();
                login.Contact = reader["BRAND_CONTACT"].ToString();
                login.Address = reader["BRAND_ADDRESS"].ToString();
                login.Country = reader["COUNTRY"].ToString();

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
            string sql = "select count(*) from brand where BRAND_ID = @BRAND_ID and BRAND_NAME = @BRAND_NAME and BRAND_EMAIL1 = @BRAND_EMAIL1 and BRAND_EMAIL2 = @BRAND_EMAIL2";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@BRAND_ID", id);
            cmd.Parameters.AddWithValue("@BRAND_NAME", name);
            cmd.Parameters.AddWithValue("@BRAND_EMAIL1", email1);
            cmd.Parameters.AddWithValue("@BRAND_EMAIL2", email2);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return (cnt > 0);
        }

        public int UpdateImageFile(string brandID, string imgFile)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = $"UPDATE brand SET LOGO_IMG_PATH=@LOGO_IMG_PATH WHERE BRAND_ID=@BRAND_ID";

            cmd.Parameters.AddWithValue("@LOGO_IMG_PATH", imgFile);
            cmd.Parameters.AddWithValue("@BRAND_ID", brandID);

            return cmd.ExecuteNonQuery();
        }

        public DataTable GetBrand()
        {
            string sql = "select BRAND_ID, BRAND_NAME, LOGO_IMG_PATH from brand"; 

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }


    }
}
