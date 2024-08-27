using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

public class OrderToVendorDAC : IDisposable
    {
       MySqlConnection conn;

        public OrderToVendorDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        /// <summary>
        /// 항목이 존재하는 회사 찾기
        /// </summary>
        /// <param name="mtCode"></param>
        /// <returns></returns>
        public List<ComMtrVO> FindCompaniesByMT(int mtCode)
        {
            string sql = @"select COM_MTR_ID, CM.MT_Code, MT_Name, CM.COM_No, c.COM_Name, c.COM_Type, MT_Price, CM.MT_Unit, CC.Name Unit_Name, MT_Min_Order, CMT.Name as COM_MTR_Name
from TBL_COM_MTR CM inner join Company C on CM.COM_No = C.COM_No
inner join Material M on M.MT_Code = CM.MT_Code
inner join Common_Code CC on CC.Code = CM.MT_Unit
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code = COM_MTR_ID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MT_Code", mtCode);

                return Helper.DataReaderMapToList<ComMtrVO>(cmd.ExecuteReader());
            }

        }

        /// <summary>
        /// 모든 항목에 대한 회사 전부 가져오기
        /// </summary>
        /// <returns></returns>
        public List<ComMtrVO> GetAllCompaniesByMT()
        {
            string sql = @"select COM_MTR_ID, CM.MT_Code, MT_Name, CM.COM_No, c.COM_Name, c.COM_Type, MT_Price, CM.MT_Unit, CC.Name Unit_Name, MT_Min_Order, CMT.Name as COM_MTR_Name
from TBL_COM_MTR CM inner join Company C on CM.COM_No = C.COM_No
inner join Material M on M.MT_Code = CM.MT_Code
inner join Common_Code CC on CC.Code = CM.MT_Unit
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code = COM_MTR_ID";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                return Helper.DataReaderMapToList<ComMtrVO>(cmd.ExecuteReader());
            }
        }

        public OrderCalcVO GetComMtrDetail(int comMtrId)
        {
            string sql = @"select CM.MT_Code, MT_Name, isnull(MT_Qty,0) MT_Qty, MT_Safety, M.MT_Unit as MT_Unit, CCM.Name as Unit_Name, MT_Price, CM.MT_Unit as CMT_Unit, CCCM.Name as CMT_Unit_Name, isnull(nullif(MT_Min_Order,0),1) MT_Min_Order, CMT.Name as COM_MTR_Name
from (select MT_Code, COM_No, MT_Price, MT_Unit, MT_Min_Order, COM_MTR_ID
	  from TBL_COM_MTR
	  where COM_MTR_ID=@COM_MTR_ID) CM inner join Material M on CM.MT_Code = M.MT_Code
inner join Common_Code CCM on CCM.Code = M.MT_Unit
inner join Common_Code CCCM on CCCM.Code = CM.MT_Unit
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code = COM_MTR_ID";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@COM_MTR_ID", comMtrId);

                   MySqlDataReader dr = cmd.ExecuteReader();
                    Product prod = new Product();
                    ComMtrVO cm = new ComMtrVO();
                    cm.COM_MTR_ID = comMtrId;
                    if (dr.Read())
                    {
                        prod = Helper.DataReaderMapToT<Product>(dr);
                        cm = Helper.DataReaderMapToT<ComMtrVO>(dr);

                        //prod.Mt_Code = cm.MT_Code = Convert.ToInt32(dr["Mt_Code"]);
                        //prod.Mt_Name = cm.MT_Name = dr["Mt_Name"].ToString();
                        //prod.Mt_Qty = Convert.ToInt32(dr["MT_Qty"]);
                        //prod.Mt_Safety = Convert.ToInt32(dr["MT_Safety"]);
                        //prod.Mt_Unit = dr["MT_Unit"].ToString();
                        //prod.Unit_Name = dr["Unit_Name"].ToString();


                        //cm.MT_Price = Convert.ToInt32(dr["MT_Price"]);
                        cm.MT_Unit = dr["CMT_Unit"].ToString();
                        cm.Unit_Name = dr["CMT_Unit_Name"].ToString();
                        //cm.MT_Min_Order = Convert.ToInt32(dr["MT_Min_Order"]);
                    }
                    dr.Close();
                    //List<Product> prod = Helper.DataReaderMapToList<Product>(dr);
                    //List<ComMtrVO> cm = Helper.DataReaderMapToList<ComMtrVO>(dr);
                    //foreach (System.Reflection.PropertyInfo prop in cm.GetType().GetProperties()) //프로퍼티 이름이 중복인 컬럼 처리
                    //{
                    //    if (dr.GetOrdinal("MT_Unit") >= 0) //프로퍼티명이 MT_Unit인 경우
                    //    {
                    //        prop.SetValue(cm, "CMT_Unit", null);
                    //    }

                    //    if (dr.GetOrdinal("Unit_Name") >= 0) //프로퍼티명이 Unit_Name인 경우
                    //    {
                    //        prop.SetValue(cm, "CMT_Unit_Name", null);
                    //    }
                    //}

                    //List<OrderCalcVO> ocs = new List<OrderCalcVO>();
                    //if (prod.Count == cm.Count)
                    //{
                    //for (int i = 0; i < prod.Count; i++)
                    //{
                    OrderCalcVO oc = new OrderCalcVO
                    {
                        Prod = prod,
                        ComMtr = cm
                    };

                    //ocs.Add(oc);
                    //}
                    //}
                    //else
                    //{
                    //    throw new Exception("List로 만들던 중 문제가 발생하였습니다.");
                    //}

                    return oc;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return null;
            }
        }

        public bool DeleteOrder(string orderNos, string sepChar)
        {
            //Order Detail 을 먼저 삭제하고, Order를 삭제한다. (FK)
           

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    if (sepChar.Length != 1)
                        throw new Exception("구분자는 1글자만 가능합니다.");

                    cmd.Connection = conn;
                    //cmd.Transaction = trans;

                    cmd.CommandText = "SP_DeleteOrders";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_OrderIDs", orderNos);
                    cmd.Parameters.AddWithValue("@P_SepChar", sepChar);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    if (iRowAffect < 1)
                        throw new Exception("주문번호에 해당하는 정보가 없습니다.");
                }

                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public List<OrderToVendorVO> FastRegisterOrder(string selCodes, string orderQty, string sepChar, DateTime date)
        {
            //SqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    if (sepChar.Length != 1)
                        throw new Exception("구분자는 1글자만 가능합니다.");

                    cmd.Connection = conn;
                    //cmd.Transaction = trans;

                    cmd.CommandText = "SP_InsertOrdersToVender";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_MT_Codes", selCodes);
                    cmd.Parameters.AddWithValue("@P_ORDER_Qtys", orderQty);
                    cmd.Parameters.AddWithValue("@P_SepChar", sepChar);
                    cmd.Parameters.AddWithValue("@P_Period_Date", date);

                   MySqlDataReader dr = cmd.ExecuteReader();
                    //List<OrderToVendorVO> orders = Helper.DataReaderMapToList<OrderToVendorVO>(dr);

                    //trans.Commit();

                    //List<OrderDetailVO> details = new List<OrderDetailVO>();
                    List<OrderInfoVO> infos = new List<OrderInfoVO>();
                    while (dr.Read())
                    {
                        OrderDetailVO ord = Helper.DataReaderMapToT<OrderDetailVO>(dr);
                        ord.ORDER_Price = Convert.ToInt32(dr["MT_Price"]);

                        //details.Add(ord);


                        //ORDER_Date, O.ORDER_Price Total_Price, O.COM_No, COM_Name, Period_Date, ORDER_Status, (select Name from Common_Code where Code=ORDER_Status) Status_Name
                        OrderVO or = Helper.DataReaderMapToT<OrderVO>(dr);
                        or.ORDER_Price = Convert.ToInt32(dr["Total_Price"]);
                        
                        OrderInfoVO info = new OrderInfoVO
                        {
                            OrderD = ord,
                            OrderM = or
                        };

                        infos.Add(info);
                    }
                    dr.Close();

                    List<OrderToVendorVO> list = infos.GroupBy((key) => key.OrderM.ORDER_No).Select(g => new OrderToVendorVO { OrderM = g.Where(m => m.OrderM.ORDER_No==g.Key).Select(m=>m.OrderM).FirstOrDefault(), OrderD = g.Where(d => d.OrderD.ORDER_No==g.Key).Select(d=>d.OrderD).ToList()}).ToList();

                    //List<OrderVO> m = infos.Select((x) => x.OrderM).Distinct().ToList();
                    //var d = infos.Select((x) => x.OrderD).GroupBy((x) => x.ORDER_No).Select

                    //List<OrderToVendorVO> orders = new List<OrderToVendorVO>();
                    //foreach (var item in m)
                    //{
                    //    OrderToVendorVO order = new OrderToVendorVO { OrderM=item, OrderD=d.Where((detail) => detail.Key==item.ORDER_No).ToList<OrderDetailVO>() };
                    //}
                    
                    //List<OrderToVendorVO> list = (from info in infos
                    //                              group info by info.OrderM.ORDER_No into grp
                    //                              select new OrderToVendorVO() { OrderM = grp.Where<OrderVO>((x)=>x.OrderM.ORDER_No==grp.Key).ToList().FirstOrDefault() , OrderD = new List<OrderDetailVO>(grp.Where<OrderDetailVO>(x => x.ORDER_No == grp.Key.ORDER_No)) }).Distinct().ToList();
                    ////.Where<OrderDetailVO>(x => x.ORDER_No == grp.Key.ORDER_No).ToList()
                    //infos.GroupBy(info => info.OrderM).Select(grp => grp.First()).ToList();


                    return list;

                }


            }
            catch (Exception err)
            {

                //trans.Rollback();
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool RegisterOrder(OrderVO order, List<OrderDetailVO> carts)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    //OrderVO 1건 insert
                    cmd.CommandText = @"insert into Orders(ORDER_Date, ORDER_Price, COM_No, Period_Date, ORDER_Status, ORDER_Type) 
values(@ORDER_Date, @ORDER_Price, @COM_No, @Period_Date, 'ODR3', 'ODT1'); select @@IDENTITY";


                    cmd.Parameters.AddWithValue("@ORDER_Date", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@ORDER_Price", order.ORDER_Price);
                    cmd.Parameters.AddWithValue("@COM_No", order.COM_No);
                    cmd.Parameters.AddWithValue("@Period_Date", order.Period_Date);

                    int newOrderID = Convert.ToInt32(cmd.ExecuteScalar());

                    //OrderDetailVO 여러건 insert
                    cmd.Parameters.Clear();

                    cmd.CommandText = @"insert into Order_Detail(ORDER_No, MT_Code, ORDER_Qty, ORDER_Unit, ORDER_Price, COM_MTR_ID) 
values(@ORDER_No, @MT_Code, @ORDER_Qty, @ORDER_Unit, @ORDER_Price, @COM_MTR_ID)";
                    cmd.Parameters.AddWithValue("@ORDER_No", newOrderID);

                    cmd.Parameters.Add("@COM_MTR_ID", MySqlDbType.Int32);
                    cmd.Parameters.Add("@MT_Code", MySqlDbType.Int32);
                    cmd.Parameters.Add("@ORDER_Qty", MySqlDbType.Int32);
                    cmd.Parameters.Add("@ORDER_Unit", MySqlDbType.VarChar);
                    cmd.Parameters.Add("@ORDER_Price", MySqlDbType.Int32);

                    foreach (OrderDetailVO item in carts)
                    {
                        cmd.Parameters["@COM_MTR_ID"].Value = item.COM_MTR_ID;
                        cmd.Parameters["@MT_Code"].Value = item.MT_Code;
                        cmd.Parameters["@ORDER_Price"].Value = item.ORDER_Price;
                        cmd.Parameters["@ORDER_Qty"].Value = item.ORDER_Qty;
                        cmd.Parameters["@ORDER_Unit"].Value = item.ORDER_Unit;

                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                    return true;
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public List<OrderVO> GetOrderSearchList(
                  string comNo, string mtCode, string status, string dtFrom, string dtTo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select distinct O.ORDER_No, ORDER_Date, O.ORDER_Price, O.COM_No, COM_Name, Period_Date, ORDER_Status, (select Name from Common_Code where Code=ORDER_Status) Status_Name
from Orders O inner join Company C on O.COM_No = C.COM_No
      inner join Order_Detail OD on O.ORDER_No = OD.ORDER_No
	  inner join Material M on M.MT_Code = OD.MT_Code
where ORDER_Type='ODT1'
and ORDER_Date between @dtFrom and @dtTo ");

            if (!string.IsNullOrWhiteSpace(comNo))
            {
                sb.Append(" and O.COM_No = @COM_No ");
            }

            if (!string.IsNullOrWhiteSpace(mtCode))
            {
                sb.Append(" and OD.MT_Code=@MT_Code ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                sb.Append(" and ORDER_Status = @ORDER_Status ");
            }


            using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@dtFrom", dtFrom);
                cmd.Parameters.AddWithValue("@dtTo", dtTo);
                cmd.Parameters.AddWithValue("@COM_No", comNo);
                cmd.Parameters.AddWithValue("@MT_Code", mtCode);
                cmd.Parameters.AddWithValue("@ORDER_Status", status);

                List<OrderVO> order = Helper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                return order;
            }
        }

        public OrderToVendorVO GetOrderDetailList(int ordID)
        {
            string sql = @"select OD.ORDER_Detail, OD.ORDER_No, OD.MT_Code, MT_Name, ORDER_Qty, ORDER_Unit, (select Name from Common_Code where Code=ORDER_Unit) Unit_Name, OD.ORDER_Price MT_Price, OD.COM_MTR_ID, isnull(nullif(MT_Min_Order,0),1) MT_Min_Order, 
ORDER_Date, O.ORDER_Price Total_Price, O.COM_No, COM_Name, COM_Tel, Period_Date, ORDER_Status, (select Name from Common_Code where Code=ORDER_Status) Status_Name
, STORE_Detail, isnull(STORE_Qty, 0) STORE_Qty, SD_Status, CMT.Name as COM_MTR_Name
from Order_Detail OD inner join Material M on OD.MT_Code = M.MT_Code
inner join Orders O on O.ORDER_No = OD.ORDER_No
inner join (select COM_No, COM_Name, COM_Tel from Company) C on O.COM_No = C.COM_No
left outer join (select COM_MTR_ID, MT_Min_Order from TBL_COM_MTR) CM on OD.COM_MTR_ID = CM.COM_MTR_ID
left outer join (select OD.ORDER_Detail, STORE_Detail, STORE_Qty, 
						case when (STORE_Qty_Sum = OD.ORDER_Qty) then '입고'
							 when (0 < STORE_Qty_Sum) then '부분입고'
							 else '미입고'
						end SD_Status
				from (select STORE_Detail, SD.ORDER_Detail, STORE_Qty, ORDER_Qty, STORE_Qty_Sum
						from (select SD.ORDER_Detail, sum(STORE_Qty) STORE_Qty_Sum, ORDER_Qty
								from Store_Detail SD inner join Order_Detail OD on SD.ORDER_Detail=OD.ORDER_Detail
								group by SD.ORDER_Detail, ORDER_Qty) SD_Sum inner join (select STORE_Detail, ORDER_Detail, STORE_Qty from Store_Detail) SD on SD_Sum.ORDER_Detail= SD.ORDER_Detail
						) SD right outer join ORDER_Detail OD on OD.ORDER_Detail=SD.ORDER_Detail
) SD on SD.ORDER_Detail=OD.ORDER_Detail
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code = OD.COM_MTR_ID
where ORDER_Type = 'ODT1' and OD.ORDER_No = @ORDER_No";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ORDER_No", ordID);

                   MySqlDataReader dr = cmd.ExecuteReader();

                    List<OrderDetailVO> details = new List<OrderDetailVO>();
                    OrderVO or = null;
                    while (dr.Read())
                    {
                        OrderDetailVO ord = Helper.DataReaderMapToT<OrderDetailVO>(dr);
                        ord.ORDER_Detail = Convert.ToInt32(dr["ORDER_Detail"]);
                        ord.ORDER_No = Convert.ToInt32(dr["ORDER_No"]);
                        ord.MT_Code = Convert.ToInt32(dr["MT_Code"]);
                        ord.MT_Name = dr["MT_Name"].ToString();
                        ord.ORDER_Qty = Convert.ToInt32(dr["ORDER_Qty"]);
                        ord.ORDER_Unit = dr["ORDER_Unit"].ToString();
                        ord.Unit_Name = dr["Unit_Name"].ToString();
                        ord.ORDER_Price = Convert.ToInt32(dr["MT_Price"]);
                        if (!DBNull.Value.Equals(dr["COM_MTR_ID"]))
                            ord.COM_MTR_ID = Convert.ToInt32(dr["COM_MTR_ID"]);
                        //ord.COM_MTR_ID = (!DBNull.Value.Equals(dr["COM_MTR_ID"]))? Convert.ToInt32(dr["COM_MTR_ID"]) : null;
                        if (!DBNull.Value.Equals(dr["MT_Min_Order"]))
                            ord.MT_Min_Order = Convert.ToInt32(dr["MT_Min_Order"]);

                        details.Add(ord);

                        if (or == null)
                        {
                            //ORDER_Date, O.ORDER_Price Total_Price, O.COM_No, COM_Name, Period_Date, ORDER_Status, (select Name from Common_Code where Code=ORDER_Status) Status_Name
                            or = new OrderVO
                            {
                                ORDER_No = Convert.ToInt32(dr["ORDER_No"]),
                                ORDER_Date = Convert.ToDateTime(dr["ORDER_Date"]),
                                ORDER_Price = Convert.ToInt32(dr["Total_Price"]),
                                COM_No = Convert.ToInt32(dr["COM_No"]),
                                COM_Name = dr["COM_Name"].ToString(),
                                Period_Date = Convert.ToDateTime(dr["Period_Date"]),
                                ORDER_Status = dr["ORDER_Status"].ToString(),
                                Status_Name = dr["Status_Name"].ToString()
                            };
                        }

                        
                    }
                    dr.Close();
                    OrderToVendorVO otv = new OrderToVendorVO
                    {
                        OrderD = details,
                        OrderM = or
                    };

                    return otv;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return null;
            }
        }

        public bool UpdateOrder(OrderVO order)
        {
            try
            {
                string sql = @"update Orders 
set Period_Date = @Period_Date, ORDER_Status = @ORDER_Status
where ORDER_No = @ORDER_No";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Period_Date", order.Period_Date);
                    cmd.Parameters.AddWithValue("@ORDER_No", order.ORDER_No);
                    cmd.Parameters.AddWithValue("@ORDER_Status", order.ORDER_Status);

                    int iRowAffect = cmd.ExecuteNonQuery();
                    if (iRowAffect < 1)
                        throw new Exception($"주문번호 - {order.ORDER_No}에 해당하는 정보가 없습니다.");

                    return true;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool DeleteOrder(int orderNo)
        {
            //Order Detail 을 먼저 삭제하고, Order를 삭제한다. (FK)
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from Order_Detail where ORDER_No = @ORDER_No";
                    cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@ORDER_No", orderNo);
                    int iRowAffect = cmd.ExecuteNonQuery();
                    if (iRowAffect < 1)
                        throw new Exception("주문번호에 해당하는 정보가 없습니다.");

                    cmd.CommandText = "delete from Orders where ORDER_No = @ORDER_No";
                    iRowAffect = cmd.ExecuteNonQuery();

                    if (iRowAffect < 1)
                        throw new Exception("주문번호에 해당하는 정보가 없습니다.");
                }
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                trans.Rollback();
                return false;
            }
        }


        public List<Product> GetNeedMTList()
        {
            //string sql = @"select distinct M.MT_Code, MT_Name, isnull(MT_Qty,0) as MT_Qty, isnull(ORDER_Qty,0) ORDER_Qty, isnull(STORE_Qty,0) STORE_Qty, isnull((ORDER_Qty - STORE_Qty),0) as Before_STORE_Qty,
            //isnull((MT_Qty + (ORDER_Qty - STORE_Qty)),MT_Qty) as Logical_Qty, isnull(MT_Safety,0) as MT_Safety, M.COM_No, M.MT_Unit, CCM.Name as Unit_Name, CM.MT_Unit as CMT_MT_Unit, CCCM.Name as CMT_Unit_Name
            //, isnull(convert(int,MT_Require), 0) MT_Require
            //from  Material M join (select COM_MTR_ID, MT_Code, COM_No, MT_Price, MT_Unit, MT_Min_Order from TBL_COM_MTR) CM on M.MT_Code = CM.MT_Code
            //left outer join (select MT_Code, sum(ORDER_Qty) as ORDER_Qty
            //				from Order_Detail OD inner join Orders  O on OD.ORDER_No = O.ORDER_No
            //				where ORDER_Type = 'ODT1'
            //				group by MT_Code) O on M.MT_Code=O.MT_Code
            //left outer join (select MT_Code, sum(STORE_Qty) STORE_Qty
            //				from Store_Detail
            //				group by MT_Code) S on S.MT_Code=M.MT_Code
            //inner join Common_Code CCM on CCM.Code=M.MT_Unit
            //inner join Common_Code CCCM on CCCM.Code=CM.MT_Unit
            //left outer join (select MT_Code, 
            //					case
            //						when (BOM_Unit = MT_Unit) then MT_Require
            //						when BOM_Unit = 'U002' and MT_Unit = 'U001' then CEILING(0.001*MT_Require)
            //						when BOM_Unit = 'U001' and MT_Unit = 'U002' then 1000*MT_Require
            //					end MT_Require
            //				 from (select sum(ORDER_Qty*MT_Rate) MT_Require, C_MT_Code
            //						from Order_Detail OD inner join Orders O on OD.ORDER_No=O.ORDER_No
            //						inner join BOM B on B.MT_Code=OD.MT_Code
            //						where ORDER_Type='ODT2' and ORDER_Status = 'ODR3'
            //						group by C_MT_Code) BOM 
            //				left outer join (select distinct B.MT_Unit as BOM_Unit, M.MT_Unit, M.MT_Code
            //								from BOM B inner join Material M on B.C_MT_Code=M.MT_Code) Unit on BOM.C_MT_Code=Unit.MT_Code) B on B.MT_Code=M.MT_Code
            //where M.COM_No = CM.COM_No and MT_Level=2";

            //using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            //{
            //    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
            //}

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SP_GetAggregateStatus";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
            }
        }

    }

