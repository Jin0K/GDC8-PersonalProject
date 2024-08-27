using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using MySql.Data.MySqlClient;


public class CompanyDAC : IDisposable
    {
       MySqlConnection conn;

        public CompanyDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }

        //조회
        public List<Company> GetCompanyAllList()
        {
            string sql = "select COM_No, COM_License, COM_Name, COM_Tel, COM_Email, COM_Addr_Zip, COM_Addr_Street1, COM_Addr_Street2, COM_Type, COM_Main_Item from Company";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<Company>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        //검색
        public List<Company> GetCompanySearchList(string cName)
        {
            string sql = @"select COM_No, COM_License, COM_Name, COM_Tel, COM_Email, COM_Addr_Zip, COM_Addr_Street1, COM_Addr_Street2, COM_Type, COM_Main_Item from Company where COM_Name LIKE @COM_Name";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@COM_Name", "%" + cName + "%");
                    return Helper.DataReaderMapToList<Company>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        //거래내역 조회
        public List<Product> GetDealDetails(int comNo)
        {
            //string sql = @"SELECT MT_Name, MT_Qty, STR_Date AS Mt_Stored_Date FROM Material WHERE COM_No = @COM_No ORDER BY Mt_Stored_Date DESC";
            string sql = @"SELECT m.MT_Name, m.MT_Qty, cc.Name AS Unit_Name, m.STR_Date AS Mt_Stored_Date FROM Material m JOIN Common_Code cc ON m.MT_Unit = cc.Code WHERE COM_No = @COM_No ORDER BY Mt_Stored_Date DESC";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@COM_No", comNo);

                return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
            }
        }

        //취급 품목
        public List<Product> GetMainItems(int comNo)
        {
            string sql = @"SELECT DISTINCT MT_Name FROM Material WHERE MT_Level = '2' AND COM_No = @COM_No";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@COM_No", comNo);

                return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
            }
        }

        //삭제
        public bool DeleteCompanyInfo(int comNo)
        {
            string sql = @"delete from Company where COM_No = @COM_No;";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@COM_No", comNo);

                if (cmd.ExecuteNonQuery() < 1)
                    throw new Exception("거래처 정보를 삭제 중에 에러가 발생했습니다.");

                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        //등록
        public bool AddCompanyInfo(Company com)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"insert into Company(COM_License, COM_Name, COM_Tel, COM_Email, COM_Addr_Zip, COM_Addr_Street1, COM_Addr_Street2, COM_Type) values (@COM_License, @COM_Name, @COM_Tel, @COM_Email, @COM_Addr_Zip, @COM_Addr_Street1, @COM_Addr_Street2, @COM_Type)";

                    cmd.Parameters.AddWithValue("@COM_License", com.Com_License);
                    cmd.Parameters.AddWithValue("@COM_Name", com.Com_Name);
                    cmd.Parameters.AddWithValue("@COM_Tel", com.Com_Tel);
                    cmd.Parameters.AddWithValue("@COM_Email", com.Com_Email);
                    cmd.Parameters.AddWithValue("@COM_Addr_Zip", com.Com_Addr_Zip);
                    cmd.Parameters.AddWithValue("@COM_Addr_Street1", com.Com_Addr_Street1);
                    cmd.Parameters.AddWithValue("@COM_Addr_Street2", com.Com_Addr_Street2);
                    cmd.Parameters.AddWithValue("@COM_Type", com.Com_Type);

                    if (cmd.ExecuteNonQuery() < 1)
                        throw new Exception();

                    trans.Commit();
                    return true;
                }
            }
            catch(Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        //불러오기
        public Company GetCompanyInfo(int comNo)
        {
            string sql = @"select COM_No, COM_License, COM_Name, COM_Tel, COM_Email, COM_Addr_Zip, COM_Addr_Street1, COM_Addr_Street2, COM_Type, COM_Main_Item
                            from Company
                            where COM_No=@COM_No";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@COM_No", comNo);

                return Helper.DataReaderMapToList<Company>(cmd.ExecuteReader()).FirstOrDefault();
            }
        }

        //수정
        public bool UpdateCompany(Company com)
        {
            string sql = @"Update Company set 
                        COM_License=@COM_License, 
                        COM_Name=@COM_Name, 
                        COM_Tel=@COM_Tel, 
                        COM_Email=@COM_Email, 
                        COM_Addr_Zip=@COM_Addr_Zip, 
                        COM_Addr_Street1=@COM_Addr_Street1, 
                        COM_Addr_Street2=@COM_Addr_Street2, 
                        COM_Type=@COM_Type,
                        COM_Main_Item=@COM_Main_Item where COM_No=@COM_No";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@COM_License", com.Com_License);
                cmd.Parameters.AddWithValue("@COM_Name", com.Com_Name);
                cmd.Parameters.AddWithValue("@COM_Tel", com.Com_Tel);
                cmd.Parameters.AddWithValue("@COM_Email", com.Com_Email);
                cmd.Parameters.AddWithValue("@COM_Addr_Zip", com.Com_Addr_Zip);
                cmd.Parameters.AddWithValue("@COM_Addr_Street1", com.Com_Addr_Street1);
                cmd.Parameters.AddWithValue("@COM_Addr_Street2", com.Com_Addr_Street2);
                cmd.Parameters.AddWithValue("@COM_Type", com.Com_Type);
                cmd.Parameters.AddWithValue("@COM_Main_Item", com.Com_Main_Item);
                cmd.Parameters.AddWithValue("@COM_No", com.Com_No);

                int iRowAffect = cmd.ExecuteNonQuery();
                return (iRowAffect > 0);
            }
        }
    }

