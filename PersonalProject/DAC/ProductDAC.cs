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
    //p.PRODUCT_CODE, PRODUCT_NAME, PRICE, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV
    public class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ProductPrice { get; set; }
        public int Inventory { get; set; }
        public string MainCategory { get; set; }
        public string MiddleCategory { get; set; }
        public string SubCategory { get; set; }
        public float DiscountRate { get; set; }
        public DateTime RegistDateTime { get; set; }
        public string BrandID { get; set; }
        public string MainImgPath { get; set; }
        public int TotalInventory { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ColorText { get; set; }
        public string SizeText { get; set; }
    }

    public class ProductDAC : IDisposable
    {
        MySqlConnection conn;

        public ProductDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }


        public DataSet GetProductControl(int productCode, string productName)
        {
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sql = @"select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, COLOR, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME,
b.BRAND_ID, BRAND_NAME, (select SERVER_PATH from product_img where IMG_DIV='I001' and PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME='@PRODUCT_NAME')) PRODUCT_IMG
from product p left outer join brand b on p.BRAND_ID = b.BRAND_ID where PRODUCT_CODE=@PRODUCT_CODE";

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
                //da.SelectCommand.Parameters.AddWithValue("@BRAND_ID", dv[0]["BRAND_ID"]);
                da.SelectCommand.Parameters.AddWithValue("@PRODUCT_NAME", productName);
                da.SelectCommand.Transaction = trans;
                da.Fill(ds, "product");

                da.SelectCommand.CommandText = @"select CCODE, CNAME 
from common_code 
where CCODE=(select SIZE from product where PRODUCT_CODE=@PRODUCT_CODE)
union
select CCODE, CNAME 
from common_code 
where CCODE=(select COLOR from product where PRODUCT_CODE=@PRODUCT_CODE)";

                da.SelectCommand.Transaction = trans;
                da.Fill(ds, "common_code");

                trans.Commit();
                //return true;
                return ds;

            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
                //return false;
            }
            finally
            {
                Dispose();
            }
        }


        public DataTable GetProduct(string brandID, string productName)
        {
            string sql = @"select p.PRODUCT_CODE, p.PRODUCT_NAME, AVG_SCORE, COUNT_REVIEW, PRODUCT_DESCRIPTION, PRICE, SIZE, COLOR, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME,
PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH
from (select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, COLOR, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, BRAND_ID, DISCOUNT_RATE, REGIST_DATETIME
from product
where PRODUCT_NAME=@PRODUCT_NAME) p left outer join (select BRAND_ID, BRAND_NAME, LOGO_IMG_PATH
						   from brand
						   where BRAND_ID = @BRAND_ID) b on p.BRAND_ID = b.BRAND_ID
			   left outer join (select PRODUCT_IMG_CODE, PRODUCT_CODE, SERVER_PATH, IMG_DIV
						   from product_img) pimg on p.PRODUCT_CODE = pimg.PRODUCT_CODE
                           left outer join (select ifnull(avg(SCORE),0) AVG_SCORE, count(REVIEW_NUMBER) COUNT_REVIEW, PRODUCT_NAME
from review rv inner join order_detail od on rv.ORDER_DETAIL_CODE=od.ORDER_DETAIL_CODE
inner join product p on p.PRODUCT_CODE = od.PRODUCT_CODE
where DELETED=0 and od.PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME = p.PRODUCT_NAME)
group by p.PRODUCT_NAME) rv on rv.PRODUCT_NAME = p.PRODUCT_NAME
where p.PRODUCT_NAME=@PRODUCT_NAME";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@BRAND_ID", brandID);
            da.SelectCommand.Parameters.AddWithValue("@PRODUCT_NAME", productName);

            da.Fill(dt);
            Dispose();
            return dt;
        }


        public DataTable GetProductList()
        {
            string sql = @"select p.PRODUCT_NAME, PRICE, (select sum(INVENTORY) from product where PRODUCT_NAME = p.PRODUCT_NAME) SUM_INVENTORY, 
(select ifnull(sum(ORDER_QUANTITY),0) 
from order_detail 
where PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME = p.PRODUCT_NAME)) SALES, AVG_SCORE, COUNT_REVIEW,
MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, SERVER_PATH
from product p inner join brand b on p.BRAND_ID = b.BRAND_ID
               inner join(select PRODUCT_IMG_CODE, PRODUCT_CODE, SERVER_PATH
                           from product_img
                           where IMG_DIV = 'I001') pimg on p.PRODUCT_CODE = pimg.PRODUCT_CODE
left outer join (select ifnull(avg(SCORE),0) AVG_SCORE, count(REVIEW_NUMBER) COUNT_REVIEW, pd.PRODUCT_NAME
from review rv inner join order_detail od on rv.ORDER_DETAIL_CODE=od.ORDER_DETAIL_CODE
inner join product pd on pd.PRODUCT_CODE = od.PRODUCT_CODE
where DELETED=0 and od.PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME = pd.PRODUCT_NAME)
group by pd.PRODUCT_NAME) rv on rv.PRODUCT_NAME =p.PRODUCT_NAME
group by p.PRODUCT_NAME";

//            string sql = @"select PRODUCT_NAME, PRICE, sum(INVENTORY), MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, SERVER_PATH
//from product p inner join brand b on p.BRAND_ID = b.BRAND_ID
//			   inner join (select PRODUCT_IMG_CODE, PRODUCT_CODE, SERVER_PATH
//						   from product_img
//						   where IMG_DIV = 'I001') pimg on p.PRODUCT_CODE = pimg.PRODUCT_CODE
//group by PRODUCT_NAME";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

            da.Fill(dt);
            Dispose();
            return dt;

        }

        public bool Insert(Product prod, QuantityPerOption[] qpos, ImagePerOption[] ipos) // 2021100, {1, 3, 5}
        {
            //책을 3권
            //Lending 테이블 insert 1건
            //LendingItem 테이블에 insert 3건
            //Book 테이블에 update 3건, update 3건
            //트랜잭션 : 여러개의 커맨드를 하나의 단위로 묶어서 처리
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                int[] productCode = new int[qpos.Length];
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                for (int i = 0; i < qpos.Length; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"insert into product(PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, COLOR, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, BRAND_ID, DISCOUNT_RATE)
values(@PRODUCT_NAME, @PRODUCT_DESCRIPTION, @PRICE, @SIZE, @COLOR, @INVENTORY, @MAIN_CATEGORY, @MIDDLE_CATEGORY, @SUB_CATEGORY, @BRAND_ID, @DISCOUNT_RATE);select last_insert_id();";
                    cmd.Parameters.AddWithValue("@PRODUCT_NAME", prod.ProductName);
                    cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", prod.Description);
                    cmd.Parameters.AddWithValue("@PRICE", prod.ProductPrice);
                    cmd.Parameters.AddWithValue("@MAIN_CATEGORY", prod.MainCategory);
                    cmd.Parameters.AddWithValue("@MIDDLE_CATEGORY", prod.MiddleCategory);
                    cmd.Parameters.AddWithValue("@SUB_CATEGORY", prod.SubCategory);
                    cmd.Parameters.AddWithValue("@BRAND_ID", prod.BrandID);
                    cmd.Parameters.AddWithValue("@DISCOUNT_RATE", prod.DiscountRate);

                    cmd.Parameters.AddWithValue("@SIZE", qpos[i].Size);
                    cmd.Parameters.AddWithValue("@COLOR", qpos[i].Color);
                    cmd.Parameters.AddWithValue("@INVENTORY", qpos[i].Quantity);

                    cmd.Transaction = trans;
                    productCode[i] = Convert.ToInt32(cmd.ExecuteScalar());
                }
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into product_img(PRODUCT_CODE, SERVER_PATH, IMG_DIV) values(@PRODUCT_CODE, @SERVER_PATH, @IMG_DIV)";
                    cmd2.Transaction = trans;

                    cmd2.Parameters.Add("@PRODUCT_CODE", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@SERVER_PATH", MySqlDbType.VarString);
                    cmd2.Parameters.Add("@IMG_DIV", MySqlDbType.VarChar);
                    
                    //cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
                    //cmd.Parameters.AddWithValue("@SERVER_PATH", ipos[j].Path);
                    //cmd.Parameters.AddWithValue("@IMG_DIV", ipos[j].ImgDiv);

                
                for (int i = 0; i < ipos.Length; i++)
                {
                    int index = -1;
                    for (int j = 0; j < qpos.Length; j++)
                    {
                        if (qpos[j].Color == ipos[i].Color)
                        {
                            index = j;
                            break;
                        }
                    }

                    if (index > -1)
                    {
                        cmd2.Parameters["@PRODUCT_CODE"].Value = productCode[index];
                        cmd2.Parameters["@SERVER_PATH"].Value = CommonUtil.GetImagePath(ipos[i].Path, productCode[index] + $"_{DateTime.Now.ToString("yyyyMMddHHmmss")}", "Product", prod.BrandID);
                        cmd2.Parameters["@IMG_DIV"].Value = ipos[i].ImgDiv;
                        cmd2.ExecuteNonQuery();
                    }
                    //else i--;
                }
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
                //return false;
            }
            finally
            {
                Dispose();
            }
        }

        //동일 이름 없으면 0
        public bool IsVaildName(string name, string id)
        {
            string sql = "select count(*) from product where BRAND_ID = @BRAND_ID and PRODUCT_NAME = @PRODUCT_NAME";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@BRAND_ID", id);
            cmd.Parameters.AddWithValue("@PRODUCT_NAME", name);

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());

            //Dispose();

            return (cnt == 0);

        }
    }
}
