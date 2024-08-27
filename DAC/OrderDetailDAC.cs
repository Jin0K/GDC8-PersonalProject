using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace PersonalProject
{
    //ORDER_DETAIL_CODE, ORDER_NUMBER, PRODUCT_CODE, ORDER_QUANTITY
    public class OrderDetail
    {
        public int OrderDetailCode { get; set; }
        public int OrderNumber { get; set; }
        public int ProductCode { get; set; }
        public int OrderQuantity { get; set; }
        public int ReviewCount { get; set; }
    }
    public class OrderDetailDAC : IDisposable
    {
        MySqlConnection conn;

        //ORDER_NUMBER, CUSTOMER_ID, ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, PAYMENT_CHECK

        public OrderDetailDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetOrderDetails(int orderNumber)
        {
            try
            {
                string sql = @"select  ORDER_DETAIL_CODE, ORDER_NUMBER, p.PRODUCT_CODE, ORDER_QUANTITY,
PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME,
b.BRAND_ID, BRAND_NAME, (select SERVER_PATH from product_img where IMG_DIV='I001' and PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME=p.PRODUCT_NAME)) PRODUCT_IMG
from order_detail od inner join product p on od.PRODUCT_CODE = p.PRODUCT_CODE 
inner join brand b on p.BRAND_ID = b.BRAND_ID 
inner join (select CCODE, CNAME from common_code where CATEGORY='사이즈') sz on sz.CCODE = p.SIZE
inner join (select CCODE, CNAME from common_code where CATEGORY='색상') cl on cl.CCODE = p.COLOR
where ORDER_NUMBER=@ORDER_NUMBER;";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@ORDER_NUMBER", orderNumber);
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

        public DataTable GetOrderSales()
        {
            try
            {
                string sql = @"select ORDER_QUANTITY, ORDER_DATETIME, PRODUCT_NAME
from order_detail od inner join order_master om on od.ORDER_NUMBER = om.ORDER_NUMBER
inner join product p on p.PRODUCT_CODE = od.PRODUCT_CODE";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
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



        //        public DataSet GetOrderDetails(int orderNumber)
        //        {
        //            //    string sql = @"select ORDER_NUMBER, om.CUSTOMER_ID, a.ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, CNAME, PAYMENT_CHECK, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2
        //            //from order_master om inner join address a on om.ADDRESS_NUMBER = a.ADDRESS_NUMBER
        //            //inner join common_code cc on cc.CCODE = om.ORDER_STATUS";

        //            MySqlTransaction trans = conn.BeginTransaction();
        //            try
        //            {
        //                string sql = @"select ORDER_NUMBER, om.CUSTOMER_ID, a.ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, CNAME STATUS_NAME, PAYMENT_CHECK, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2
        //        from order_master om inner join address a on om.ADDRESS_NUMBER = a.ADDRESS_NUMBER
        //        inner join common_code cc on cc.CCODE = om.ORDER_STATUS
        //        where ORDER_NUMBER=@ORDER_NUMBER";

        //                DataSet ds = new DataSet();
        //                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
        //                da.SelectCommand.Parameters.AddWithValue("@ORDER_NUMBER", orderNumber);
        //                da.SelectCommand.Transaction = trans;
        //                da.Fill(ds, "order_master");

        //                da.SelectCommand.CommandText = @"select  ORDER_DETAIL_CODE, ORDER_NUMBER, p.PRODUCT_CODE, ORDER_QUANTITY,
        //PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME,
        //b.BRAND_ID, BRAND_NAME, (select SERVER_PATH from product_img where IMG_DIV='I001' and PRODUCT_CODE in (select PRODUCT_CODE from product where PRODUCT_NAME=p.PRODUCT_NAME)) PRODUCT_IMG
        //from order_detail od inner join product p on od.PRODUCT_CODE = p.PRODUCT_CODE 
        //inner join brand b on p.BRAND_ID = b.BRAND_ID 
        //inner join (select CCODE, CNAME from common_code where CATEGORY='사이즈') sz on sz.CCODE = p.SIZE
        //inner join (select CCODE, CNAME from common_code where CATEGORY='색상') cl on cl.CCODE = p.COLOR
        //where ORDER_NUMBER=@ORDER_NUMBER;";

        //                da.SelectCommand.Transaction = trans;
        //                da.Fill(ds, "order_detail");

        //                trans.Commit();
        //                //return true;
        //                return ds;

        //            }
        //            catch (Exception err)
        //            {
        //                trans.Rollback();
        //                throw err;
        //                //return false;
        //            }
        //            finally
        //            {
        //                Dispose();
        //            }
        //        }


    }
}