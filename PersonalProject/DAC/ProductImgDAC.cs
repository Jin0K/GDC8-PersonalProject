using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject
{
    //p.PRODUCT_CODE, PRODUCT_NAME, PRICE, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV
    public class ProductImg
    {
        public int ProductImgCode { get; set; }
        public int ProductCode { get; set; }
        public string ServerPath { get; set; }
        public string ImgDiv { get; set; }
        public int ContactNumber { get; set; }
        public int ReviewNumber { get; set; }
    }

    public class ProductImgDAC : IDisposable
    {
        MySqlConnection conn;

        public ProductImgDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }



    }
}