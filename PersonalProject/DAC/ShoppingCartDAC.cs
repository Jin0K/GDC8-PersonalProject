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
    //SHOPPING_CART_ID, CUSTOMER_ID, PRODUCT_CODE, QUANTITY, INCLUDED_DATE, ORDER_CHECK
    public class ShoppingCart
    {
        public int CartID { get; set; }
        public string CustomerID { get; set; }
        public int ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime IncludedDate { get; set; }
        public bool OrderCheck { get; set; }
    }

    public class ShoppingCartDAC : IDisposable
    {
        MySqlConnection conn;

        public ShoppingCartDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public bool Insert(string customerID, int productCode, int Quantity)
        {
            try
            {   //SHOPPING_CART_ID
                string sql = @"insert into shopping_cart(CUSTOMER_ID, PRODUCT_CODE, QUANTITY) 
values(@CUSTOMER_ID, @PRODUCT_CODE, @QUANTITY);select last_insert_id();";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CUSTOMER_ID", customerID);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", productCode);
                cmd.Parameters.AddWithValue("@QUANTITY", Quantity);

                return (Convert.ToInt32(cmd.ExecuteScalar()) > 0);

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


        public DataTable GetCart(string customerID)
        {
            string sql = @"select SHOPPING_CART_ID, p.PRODUCT_CODE, QUANTITY, INCLUDED_DATE, 
PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME,
b.BRAND_ID, BRAND_NAME, (select SERVER_PATH from product_img where IMG_DIV='I001' and PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME=p.PRODUCT_NAME)) PRODUCT_IMG
from shopping_cart s inner join product p on s.PRODUCT_CODE = p.PRODUCT_CODE 
inner join brand b on p.BRAND_ID = b.BRAND_ID 
inner join (select CCODE, CNAME from common_code where CATEGORY='사이즈') sz on sz.CCODE = p.SIZE
inner join (select CCODE, CNAME from common_code where CATEGORY='색상') cl on cl.CCODE = p.COLOR
where ORDER_CHECK=0 and CUSTOMER_ID=@CUSTOMER_ID";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@CUSTOMER_ID", customerID);

            da.Fill(dt);
            Dispose();
            return dt;
        }

        public int UpdateQty(int cartID, int qty)
        {
            string sql = @"update shopping_cart set QUANTITY=@QUANTITY where SHOPPING_CART_ID=@SHOPPING_CART_ID";
            //string sql = @"delete from q_and_a where CONTACT_NUMBER=@CONTACT_NUMBER";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@QUANTITY", qty);
                cmd.Parameters.AddWithValue("@SHOPPING_CART_ID", cartID);

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


        public int Delete(int cartID)
        {
            //string sql = @"update q_and_a set Deleted = 1 where CONTACT_NUMBER=@CONTACT_NUMBER";
            string sql = @"delete from shopping_cart where SHOPPING_CART_ID=@SHOPPING_CART_ID";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SHOPPING_CART_ID", cartID);

                return cmd.ExecuteNonQuery();
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

        
    }
}
