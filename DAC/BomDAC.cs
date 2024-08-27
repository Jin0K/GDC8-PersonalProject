using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class BomDAC : IDisposable
    {
        MySqlConnection conn;

        public BomDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

     

        public void Dispose()
        {
            conn.Close();
        }
       
        public bool DeleteBOM(int BomID)
        {
            string sql = @"delete from BOM where MT_Code = @Mt_Code;";

            try
            {
                //prod.Mt_Epr_Date = Convert.ToInt32(nudExpirationDateInList.Value);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Mt_Code", BomID);

                if (cmd.ExecuteNonQuery() < 1)
                    throw new Exception("물품 정보를 삭제 중에 에러가 발생했습니다.");

                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }



    }

