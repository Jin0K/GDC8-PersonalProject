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
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerID { get; set; }
        public int AddressNumber { get; set; }
        public int OrderAmount { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string OrderStatus { get; set; }
        public string OrderStatusName { get; set; }
        public bool PaymentCheck { get; set; }
    }

    public class OrderDAC : IDisposable
    {
        MySqlConnection conn;

        //ORDER_NUMBER, CUSTOMER_ID, ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, PAYMENT_CHECK
        
        public OrderDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetOrders()
        {
            string sql = @"select ORDER_NUMBER, om.CUSTOMER_ID, a.ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, CNAME, PAYMENT_CHECK, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2
        from order_master om inner join address a on om.ADDRESS_NUMBER = a.ADDRESS_NUMBER
        inner join common_code cc on cc.CCODE = om.ORDER_STATUS";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            //da.SelectCommand.Parameters.AddWithValue("@CUSTOMER_ID", customerId);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Dispose();

            return dt;
        }

        public bool Insert(Customer customer, int addressNumber, int totalPay, int usePoint, DataTable dt)
        {
            //책을 3권
            //Lending 테이블 insert 1건
            //LendingItem 테이블에 insert 3건
            //Book 테이블에 update 3건, update 3건
            //트랜잭션 : 여러개의 커맨드를 하나의 단위로 묶어서 처리
            //주문 테이블에 주문 1건, 주문Detail 테이블에 목록 추가, 장바구니에 주문 목록 update 1컬럼
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into order_master(CUSTOMER_ID, ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_STATUS, PAYMENT_CHECK) values(@CUSTOMER_ID, @ADDRESS_NUMBER, @ORDER_AMOUNT, 'ST03', 1); select last_insert_id();";
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", customer.ID);
                cmd.Parameters.AddWithValue("@ADDRESS_NUMBER", addressNumber);
                cmd.Parameters.AddWithValue("@ORDER_AMOUNT", totalPay);
                cmd.Transaction = trans;
                int orderNumber = Convert.ToInt32(cmd.ExecuteScalar());

                #region 커맨드 정의
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into order_detail(ORDER_NUMBER, PRODUCT_CODE, ORDER_QUANTITY) values(@ORDER_NUMBER, @PRODUCT_CODE, @ORDER_QUANTITY)";
                cmd2.Transaction = trans;
                cmd2.Parameters.Add("@ORDER_NUMBER", MySqlDbType.Int32);
                cmd2.Parameters.Add("@PRODUCT_CODE", MySqlDbType.Int32);
                cmd2.Parameters.Add("@ORDER_QUANTITY", MySqlDbType.Int32);

                MySqlCommand cmd3 = new MySqlCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "update shopping_cart set ORDER_CHECK = 1 where SHOPPING_CART_ID = @SHOPPING_CART_ID";
                cmd3.Transaction = trans;
                cmd3.Parameters.Add("@SHOPPING_CART_ID", MySqlDbType.Int32);

                MySqlCommand cmd4 = new MySqlCommand();
                cmd4.Connection = conn;
                cmd4.CommandText = "update customer set ACCUMULATE_POINT=ACCUMULATE_POINT-@USE_POINT where CUSTOMER_ID=@CUSTOMER_ID";
                cmd4.Parameters.AddWithValue("@USE_POINT", usePoint);
                
                cmd4.Transaction = trans;
                cmd4.ExecuteNonQuery();
                #endregion

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmd2.Parameters["@ORDER_NUMBER"].Value = orderNumber;
                    cmd2.Parameters["@PRODUCT_CODE"].Value = Convert.ToInt32(dt.Rows[i]["PRODUCT_CODE"]);
                    cmd2.Parameters["@ORDER_QUANTITY"].Value = Convert.ToInt32(dt.Rows[i]["QUANTITY"]);
                    cmd2.ExecuteNonQuery();

                    cmd3.Parameters["@SHOPPING_CART_ID"].Value = Convert.ToInt32(dt.Rows[i]["SHOPPING_CART_ID"]);
                    cmd3.ExecuteNonQuery();

                    //cmd4.Parameters["@BookID"].Value = bookIDs[i];
                    //cmd4.Parameters["@StudentID"].Value = stuID;
                    //cmd4.ExecuteNonQuery();
                }

                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
        }

        public bool Insert(Customer customer, int addressNumber, int totalPay, int qty, int usePoint, DataTable dt)
        {

            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into order_master(CUSTOMER_ID, ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_STATUS, PAYMENT_CHECK) values(@CUSTOMER_ID, @ADDRESS_NUMBER, @ORDER_AMOUNT, 'ST03', 1); select last_insert_id();";
                cmd.Parameters.AddWithValue("@CUSTOMER_ID", customer.ID);
                cmd.Parameters.AddWithValue("@ADDRESS_NUMBER", addressNumber);
                cmd.Parameters.AddWithValue("@ORDER_AMOUNT", totalPay);
                cmd.Transaction = trans;
                int orderNumber = Convert.ToInt32(cmd.ExecuteScalar());

                #region 커맨드 정의
                MySqlCommand cmd2 = new MySqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "insert into order_detail(ORDER_NUMBER, PRODUCT_CODE, ORDER_QUANTITY) values(@ORDER_NUMBER, @PRODUCT_CODE, @ORDER_QUANTITY)";
                cmd.Parameters.AddWithValue("@ORDER_NUMBER", orderNumber);
                cmd.Parameters.AddWithValue("@PRODUCT_CODE", Convert.ToInt32(dt.Rows[0]["PRODUCT_CODE"]));
                cmd.Parameters.AddWithValue("@ORDER_QUANTITY", qty);

                cmd2.Transaction = trans;             
                cmd2.ExecuteNonQuery();


                MySqlCommand cmd4 = new MySqlCommand();
                cmd4.Connection = conn;
                cmd4.CommandText = "update customer set ACCUMULATE_POINT=ACCUMULATE_POINT-@USE_POINT where CUSTOMER_ID=@CUSTOMER_ID";
                cmd4.Parameters.AddWithValue("@USE_POINT", usePoint);
                cmd4.Transaction = trans;
                cmd4.ExecuteNonQuery();
                #endregion

                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
        }



    }
}
