using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using MySql.Data.MySqlClient;

public class StoreDAC : IDisposable
    {
       MySqlConnection conn;

        public StoreDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }


        public void Dispose()
        {
            conn.Close();
        }

        /// <summary>
        /// 미완료 입고 목록 조회
        /// </summary>
        /// <param name="comNo">거래처 번호</param>
        /// <param name="mtCode">항목 코드</param>
        /// <param name="cmtId">거래처별 물품 ID</param>
        /// <param name="dtFrom">조회기간 시작</param>
        /// <param name="dtTo">조회기간 끝</param>
        /// <returns></returns>
        public List<OrderInfoDetailVO> GetOrderSearchList(string comNo, string mtCode, string cmtId, string dtFrom, string dtTo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select OD.ORDER_Detail, OD.ORDER_No, O.COM_No, COM_Name, OD.COM_MTR_ID, OD.MT_Code, MT_Name, ORDER_Qty, ORDER_Unit, CU.Name as Unit_Name, ORDER_Date, Period_Date, ORDER_Status, CS.Name as Status_Name
, MT_Epr_Date, MT_Unit, (select Name from Common_Code where Code=M.MT_Unit) MT_Unit_Name, isnull(MT_Min_Order,0) MT_Min_Order, isnull(STORE_Qty,0) STORE_Qty
, CMT.Name as COM_MTR_Name
from Order_Detail OD inner join Orders O on OD.ORDER_No=O.ORDER_No
inner join (select COM_No, COM_Name from Company) C on C.COM_No = O.COM_No
inner join (select MT_Code, MT_Name, MT_Epr_Date, MT_Unit from Material) M on M.MT_Code = OD.MT_Code
inner join (select COM_MTR_ID, MT_Min_Order from TBL_COM_MTR) CM on OD.COM_MTR_ID=CM.COM_MTR_ID
inner join (select Code, Name from Common_Code) CU on CU.Code = OD.ORDER_Unit
inner join (select Code, Name from Common_Code) CS on CS.Code = O.ORDER_Status
left outer join (select ORDER_Detail, isnull(sum(STORE_Qty),0) STORE_Qty from Store_Detail group by ORDER_Detail) SD on SD.ORDER_Detail=OD.ORDER_Detail
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code = OD.COM_MTR_ID
where ORDER_Type='ODT1' and ORDER_Status in ('ODR2','ODR3')
and OD.ORDER_Detail not in (select OD.ORDER_Detail
							from Order_Detail OD left outer join (select ORDER_Detail, sum(STORE_Qty) STORE_Qty
															from Store_Detail
															group by ORDER_Detail) SD on OD.ORDER_Detail=SD.ORDER_Detail
								inner join Orders O on O.ORDER_No=OD.ORDER_No
							where ORDER_Type='ODT1' and ORDER_Qty=STORE_Qty)
and ORDER_Date between @dtFrom and @dtTo ");

            if (!string.IsNullOrWhiteSpace(comNo))
            {
                sb.Append(" and O.COM_No = @COM_No ");
            }

            if (!string.IsNullOrWhiteSpace(mtCode))
            {
                sb.Append(" and OD.MT_Code=@MT_Code ");
            }

            if (!string.IsNullOrWhiteSpace(cmtId))
            {
                sb.Append(" and OD.COM_MTR_ID=@COM_MTR_ID ");
            }

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@dtFrom", dtFrom);
                    cmd.Parameters.AddWithValue("@dtTo", dtTo);
                    cmd.Parameters.AddWithValue("@COM_No", comNo);
                    cmd.Parameters.AddWithValue("@MT_Code", mtCode);
                    cmd.Parameters.AddWithValue("@COM_MTR_ID", cmtId);

                    //List<OrderInfoVO> order = Helper.DataReaderMapToList<OrderInfoVO>(cmd.ExecuteReader());

                   MySqlDataReader dr = cmd.ExecuteReader();

                    List<OrderInfoDetailVO> infos = new List<OrderInfoDetailVO>();

                    //ORDER_Detail, O.COM_No, COM_Name, COM_MTR_ID, OD.MT_Code, MT_Name, ORDER_Qty, ORDER_Unit, CU.Name as Unit_Name, ORDER_Date, Period_Date, ORDER_Status, CS.Name as Status_Name, MT_Epr_Date, MT_Unit, isnull(MT_Min_Order,0) MT_Min_Order
                    while (dr.Read())
                    {
                        OrderInfoDetailVO info = Helper.DataReaderMapToT<OrderInfoDetailVO>(dr);

                        //Product prod = new Product
                        //{
                        //    Mt_Code = Convert.ToInt32(dr["MT_Code"]),
                        //    Mt_Name = dr["MT_Name"].ToString(),
                        //    Mt_Epr_Date = Convert.ToInt32(dr["MT_Epr_Date"]),
                        //    Mt_Unit = dr["MT_Unit"].ToString()
                        //};

                        //OrderDetailVO ord = new OrderDetailVO();
                        //ord.ORDER_No = Convert.ToInt32(dr["ORDER_No"]);
                        //ord.ORDER_Detail = Convert.ToInt32(dr["ORDER_Detail"]);
                        //ord.ORDER_No = Convert.ToInt32(dr["ORDER_No"]);
                        //ord.MT_Code = Convert.ToInt32(dr["MT_Code"]);
                        //ord.MT_Name = dr["MT_Name"].ToString();
                        //ord.ORDER_Qty = Convert.ToInt32(dr["ORDER_Qty"]);
                        //ord.ORDER_Unit = dr["ORDER_Unit"].ToString();
                        //ord.Unit_Name = dr["Unit_Name"].ToString();
                        ////ord.ORDER_Price = Convert.ToInt32(dr["MT_Price"]);
                        //if (!DBNull.Value.Equals(dr["COM_MTR_ID"]))
                        //    ord.COM_MTR_ID = Convert.ToInt32(dr["COM_MTR_ID"]);
                        //ord.COM_MTR_ID = (!DBNull.Value.Equals(dr["COM_MTR_ID"]))? Convert.ToInt32(dr["COM_MTR_ID"]) : null;
                        //if (!DBNull.Value.Equals(dr["MT_Min_Order"]))
                        //    ord.MT_Min_Order = Convert.ToInt32(dr["MT_Min_Order"]);



                        ////ORDER_Date, O.ORDER_Price Total_Price, O.COM_No, COM_Name, Period_Date, ORDER_Status, (select Name from Common_Code where Code=ORDER_Status) Status_Name
                        //OrderVO or = new OrderVO
                        //{
                        //    ORDER_No = Convert.ToInt32(dr["ORDER_No"]),
                        //    ORDER_Date = Convert.ToDateTime(dr["ORDER_Date"]),
                        //    ORDER_Price = Convert.ToInt32(dr["Total_Price"]);
                        //    COM_No = Convert.ToInt32(dr["COM_No"]),
                        //    COM_Name = dr["COM_Name"].ToString(),
                        //    Period_Date = Convert.ToDateTime(dr["Period_Date"]),
                        //    ORDER_Status = dr["ORDER_Status"].ToString(),
                        //    Status_Name = dr["Status_Name"].ToString()
                        //};

                        //OrderInfoVO info = new OrderInfoVO
                        //{
                        //    Prod = prod,
                        //    OrderD = ord,
                        //    OrderM = or
                        //};


                        infos.Add(info);
                    }

                    dr.Close();

                    return infos;
                }

            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return null;
            }


        }

        public StoreExcelExportVO GetStoreDetail(int storeNum)
        {

            string sql = @"select S.COM_No, COM_Name, COM_License, COM_Tel, COM_Email, COM_Addr_Zip, COM_Addr_Street1, COM_Addr_Street2, STORE_Date, STORE_Status, CS.Name as Status_Name,
STORE_Detail, SD.MT_Code, MT_Name, STORE_Qty, STORE_Unit, CU.Name as Unit_Name, Epr_Date, SD.ORDER_Detail, SD.ORDER_No, CMT.Name as COM_MTR_Name, (ORDER_Price/ORDER_Qty) MT_Price
from Store S inner join Store_Detail SD on S.STORE_No=SD.STORE_No
inner join (select MT_Code, MT_Name from Material) M on M.MT_Code = SD.MT_Code
inner join Company C on C.COM_No=S.COM_No
inner join (select Code, Name from Common_Code) CS on CS.Code=S.STORE_Status
inner join (select Code, Name from Common_Code) CU on CU.Code=SD.STORE_Unit
inner join (select ORDER_Detail, COM_MTR_ID, ORDER_Qty,ORDER_Price from Order_Detail) OD on OD.ORDER_Detail=SD.ORDER_Detail
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code=COM_MTR_ID
where STORE_Detail=@STORE_Detail ";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@STORE_Detail", storeNum);

                   MySqlDataReader dr = cmd.ExecuteReader();
                    StoreExcelExportVO exportVO = null;
                    if (dr.Read())
                    {
                        StoreInfoDetailVO info = Helper.DataReaderMapToT<StoreInfoDetailVO>(dr);
                        Company company = Helper.DataReaderMapToT<Company>(dr);
                        exportVO = new StoreExcelExportVO { Company = company, Store = info };
                    }

                    dr.Close();

                    return exportVO;
                }

            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return null;
            }
        }
        /// <summary>
        /// 입고 목록 조회
        /// </summary>
        /// <returns></returns>
        public List<StoreInfoDetailVO> GetStoreSearchList()
        {
            string sql = @"select SD.STORE_No, S.COM_No, COM_Name, STORE_Date, STORE_Status, CS.Name as Status_Name,
STORE_Detail, SD.MT_Code, MT_Name, CMT.Name as COM_MTR_Name, STORE_Qty, STORE_Unit, CU.Name as Unit_Name, Epr_Date, SD.ORDER_Detail, SD.ORDER_No, (ORDER_Price/ORDER_Qty) MT_Price
from Store S inner join Store_Detail SD on S.STORE_No=SD.STORE_No
inner join (select MT_Code, MT_Name from Material) M on M.MT_Code = SD.MT_Code
inner join (select COM_No, COM_Name from Company) C on C.COM_No=S.COM_No
inner join (select Code, Name from Common_Code) CS on CS.Code=S.STORE_Status
inner join (select Code, Name from Common_Code) CU on CU.Code=SD.STORE_Unit
inner join (select ORDER_Detail, COM_MTR_ID, ORDER_Qty,ORDER_Price from Order_Detail) OD on OD.ORDER_Detail=SD.ORDER_Detail
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code=COM_MTR_ID;";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {

                   MySqlDataReader dr = cmd.ExecuteReader();

                    List<StoreInfoDetailVO> infos = new List<StoreInfoDetailVO>();

                    while (dr.Read())
                    {
                        StoreInfoDetailVO info = Helper.DataReaderMapToT<StoreInfoDetailVO>(dr);

                        infos.Add(info);
                    }

                    dr.Close();

                    return infos;
                }

            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return null;
            }
        }

        /// <summary>
        /// 입고 목록 조회
        /// </summary>
        /// <param name="comNo">거래처 번호</param>
        /// <param name="mtCode">항목 코드</param>
        /// <param name="status">입고상태</param>
        /// <param name="dtFrom">조회기간 시작</param>
        /// <param name="dtTo">조회기간 끝</param>
        /// <returns></returns>
        public List<StoreInfoDetailVO> GetStoreSearchList(string comNo, string mtCode, string status, string dtFrom, string dtTo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select SD.STORE_No, S.COM_No, COM_Name, STORE_Date, STORE_Status, CS.Name as Status_Name,
STORE_Detail, SD.MT_Code, MT_Name, CMT.Name as COM_MTR_Name, STORE_Qty, STORE_Unit, CU.Name as Unit_Name, Epr_Date, SD.ORDER_Detail, SD.ORDER_No, (ORDER_Price/ORDER_Qty) MT_Price
from Store S inner join Store_Detail SD on S.STORE_No=SD.STORE_No
inner join (select MT_Code, MT_Name from Material) M on M.MT_Code = SD.MT_Code
inner join (select COM_No, COM_Name from Company) C on C.COM_No=S.COM_No
inner join (select Code, Name from Common_Code) CS on CS.Code=S.STORE_Status
inner join (select Code, Name from Common_Code) CU on CU.Code=SD.STORE_Unit
inner join (select ORDER_Detail, COM_MTR_ID, ORDER_Qty,ORDER_Price from Order_Detail) OD on OD.ORDER_Detail=SD.ORDER_Detail
inner join (select Code, Name from VW_ComboBindingList where Category='COM_MTR_ID') CMT on CMT.Code=COM_MTR_ID
where STORE_Date between @dtFrom and @dtTo ");

            if (!string.IsNullOrWhiteSpace(comNo))
            {
                sb.Append(" and S.COM_No = @COM_No ");
            }

            if (!string.IsNullOrWhiteSpace(mtCode))
            {
                sb.Append(" and SD.MT_Code=@MT_Code ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                sb.Append(" and STORE_Status=@STORE_Status ");
            }

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@dtFrom", dtFrom);
                    cmd.Parameters.AddWithValue("@dtTo", dtTo);
                    cmd.Parameters.AddWithValue("@COM_No", comNo);
                    cmd.Parameters.AddWithValue("@MT_Code", mtCode);
                    cmd.Parameters.AddWithValue("@STORE_Status", status);

                   MySqlDataReader dr = cmd.ExecuteReader();

                    List<StoreInfoDetailVO> infos = new List<StoreInfoDetailVO>();

                    while (dr.Read())
                    {
                        StoreInfoDetailVO info = Helper.DataReaderMapToT<StoreInfoDetailVO>(dr);

                        infos.Add(info);
                    }

                    dr.Close();

                    return infos;
                }

            }
            catch (Exception err)
            {
                Debug.WriteLine(err);
                return null;
            }
        }

        /// <summary>
        /// 입고 등록
        /// </summary>
        /// <param name="store">입고 테이블에 들어갈 VO</param>
        /// <param name="detail">입고 상세 테이블에 들어갈 VO</param>
        /// <returns></returns>
        public bool RegisterStore(StoreVO store, StoreDetailVO detail)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    //StoreVO 1건 insert
                    cmd.CommandText = @"insert into Store(COM_No, STORE_Date, STORE_Status) 
values(@COM_No, @STORE_Date, @STORE_Status); select @@IDENTITY";


                    cmd.Parameters.AddWithValue("@COM_No", store.COM_No);
                    cmd.Parameters.AddWithValue("@STORE_Date", store.STORE_Date);
                    cmd.Parameters.AddWithValue("@STORE_Status", store.STORE_Status);

                    int newStoreNo = Convert.ToInt32(cmd.ExecuteScalar());

                    //StoreDetailVO 여러건? insert
                    cmd.Parameters.Clear();

                    cmd.CommandText = @"insert into Store_Detail(STORE_No, MT_Code, STORE_Qty, STORE_Unit, Epr_Date, Stored_Qty, ORDER_No, ORDER_Detail)
values(@STORE_No, @MT_Code, @STORE_Qty, @STORE_Unit, @Epr_Date, @Stored_Qty, @ORDER_No, @ORDER_Detail)";
                    cmd.Parameters.AddWithValue("@STORE_No", newStoreNo);

                    cmd.Parameters.AddWithValue("@MT_Code", detail.MT_Code);
                    cmd.Parameters.AddWithValue("@STORE_Qty", detail.STORE_Qty);
                    cmd.Parameters.AddWithValue("@Stored_Qty", detail.STORE_Qty); // 최초입고시 잔여량은 입고량과 같음
                    cmd.Parameters.AddWithValue("@STORE_Unit", detail.STORE_Unit);
                    cmd.Parameters.AddWithValue("@Epr_Date", detail.Epr_Date);
                    cmd.Parameters.AddWithValue("@ORDER_No", detail.ORDER_No);
                    cmd.Parameters.AddWithValue("@ORDER_Detail", detail.ORDER_Detail);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    cmd.CommandText = @"update Store set Total_Case=@iRowAffect where STORE_No=@STORE_No";
                    cmd.Parameters.AddWithValue("@iRowAffect", iRowAffect);
                    cmd.Parameters.AddWithValue("@STORE_No", newStoreNo);

                    int iResult = cmd.ExecuteNonQuery();

                    //입고한 재고 총 재고량에 추가
                    //cmd.CommandText = @"update Material set MT_Qty=MT_Qty+@STORE_Qty where MT_Code=@MT_Code";
                    cmd.CommandText = @"update Material 
set MT_Qty=MT_Qty+(
select 
	case
		when (@STORE_Unit = MT_Unit) then @STORE_Qty
		when EXISTS (select Code, Name from Common_Code where Category='단위' and P_Code<>'U000' and Code=@STORE_Unit) and EXISTS (select Code from Common_Code where Category='단위' and P_Code='U000' and Name<>'EA' and Code=MT_Unit) then 0.001*@STORE_Qty
		when EXISTS (select Code from Common_Code where Category='단위' and P_Code='U000' and Name<>'EA' and Code=@STORE_Unit) and EXISTS (select Code, Name from Common_Code where Category='단위' and P_Code<>'U000' and Code=MT_Unit) then 1000*@STORE_Qty
	end 
from Material M 
where M.MT_Code=@MT_Code)
where MT_Code=@MT_Code";

                    cmd.Parameters.AddWithValue("@MT_Code", detail.MT_Code);
                    cmd.Parameters.AddWithValue("@STORE_Qty", detail.STORE_Qty);
                    cmd.Parameters.AddWithValue("@STORE_Unit", detail.STORE_Unit);

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    cmd.CommandText = "SaveOrderStatus";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORDER_No", detail.ORDER_No);

                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    return (iResult > 0);
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        /// <summary>
        /// 생산제품 입고 등록
        /// </summary>
        /// <param name="detail">생산제품 상세정보</param>
        /// <returns></returns>
        public bool InsertProductManufactured(List<StoreDetailVO> detail, List<Product> products)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    #region 완제품
                    //StoreVO 1건 insert
                    cmd.CommandText = @"insert into Store(COM_No, STORE_Date, STORE_Status) 
values(@COM_No, @STORE_Date, 'STR3'); select @@IDENTITY";

                    cmd.Parameters.AddWithValue("@COM_No", DBNull.Value);
                    cmd.Parameters.AddWithValue("@STORE_Date", DateTime.Now);

                    int newStoreNo = Convert.ToInt32(cmd.ExecuteScalar());

                    //StoreDetailVO 여러건? insert
                    int iRowAffect = 0;

                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Transaction = trans;
                    cmd2.Connection = conn;
                    cmd2.CommandText = $@"insert into Store_Detail(STORE_No, MT_Code, STORE_Qty, Stored_Qty, STORE_Unit, Epr_Date)
values({newStoreNo}, @MT_Code, @STORE_Qty, @Stored_Qty, @STORE_Unit, @Epr_Date)";

                    cmd2.Parameters.Add("@MT_Code", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@STORE_Qty", MySqlDbType.Decimal);
                    cmd2.Parameters.Add("@Stored_Qty", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@STORE_Unit", MySqlDbType.VarChar);
                    cmd2.Parameters.Add("@Epr_Date", MySqlDbType.DateTime);

                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Transaction = trans;
                    cmd3.Connection = conn;
                    cmd3.CommandText = @"update Material 
set MT_Qty=ISNULL(MT_Qty, 0)+@STORE_Qty
where MT_Code=@MT_Code";

                    cmd3.Parameters.Add("@MT_Code", MySqlDbType.Int32);
                    cmd3.Parameters.Add("@STORE_Qty", MySqlDbType.Decimal);
                    cmd3.Parameters.Add("@STORE_Unit", MySqlDbType.VarChar);

                    foreach (StoreDetailVO item in detail)
                    {

                        cmd2.Parameters["@MT_Code"].Value = item.MT_Code;
                        cmd2.Parameters["@STORE_Qty"].Value = item.mSTORE_Qty;
                        cmd2.Parameters["@Stored_Qty"].Value = Convert.ToInt32(item.mStored_Qty); // 최초입고시 잔여량은 입고량과 같음
                        cmd2.Parameters["@STORE_Unit"].Value = item.STORE_Unit;
                        cmd2.Parameters["@Epr_Date"].Value = item.Epr_Date;

                        if (cmd2.ExecuteNonQuery() < 1)
                            throw new Exception();

                        cmd3.Parameters["@MT_Code"].Value = item.MT_Code;
                        cmd3.Parameters["@STORE_Qty"].Value = item.mSTORE_Qty;
                        cmd3.Parameters["@STORE_Unit"].Value = item.STORE_Unit;

                        if (cmd3.ExecuteNonQuery() < 1)
                            throw new Exception();

                        ++iRowAffect;
                    }

                    cmd.Parameters.Clear();

                    cmd.CommandText = @"update Store set Total_Case=@iRowAffect where STORE_No=@STORE_No";
                    cmd.Parameters.AddWithValue("@iRowAffect", iRowAffect);
                    cmd.Parameters.AddWithValue("@STORE_No", newStoreNo);

                    cmd.ExecuteNonQuery();
                    #endregion

                    #region 재료
                    cmd.Parameters.Clear();

                    cmd.CommandText = @"INSERT INTO Shipment(SMT_Date, SMT_Status) VALUES(@SMT_Date, 'SHP5'); Select @@IDENTITY;";
                    cmd.Parameters.AddWithValue("@SMT_Date", DateTime.Now);

                    object temp = cmd.ExecuteScalar();
                    int smtNo = Convert.ToInt32(temp);

                    cmd2.CommandText = $@"INSERT INTO Shipment_Detail(SMT_No, SMT_Case, MT_Code, SMT_Qty, SMT_Unit) VALUES ({smtNo}, 'SHP5', @MT_Code, @SMT_Qty, @SMT_Unit)";

                    cmd2.Parameters.Clear();
                    cmd2.Parameters.Add("@MT_Code", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@SMT_Qty", MySqlDbType.Decimal);
                    cmd2.Parameters.Add("@SMT_Unit", MySqlDbType.VarChar);

                    cmd3.Parameters.Clear();
                    cmd3.CommandText = @"UPDATE [dbo].[Material] SET MT_Qty = @MT_Qty WHERE MT_Code = @MT_Code";

                    cmd3.Parameters.Add("@MT_Qty", MySqlDbType.Decimal);
                    cmd3.Parameters.Add("@MT_Code", MySqlDbType.Int32);

                    foreach (Product item  in products)
                    {
                        cmd2.Parameters["@MT_Code"].Value = item.Mt_Code;
                        cmd2.Parameters["@SMT_Qty"].Value = item.Ship_Qty;
                        cmd2.Parameters["@SMT_Unit"].Value = item.Mt_Unit;

                        if (cmd2.ExecuteNonQuery() < 1)
                            throw new Exception();

                        cmd3.Parameters["@MT_Qty"].Value = item.Mt_Qty - item.Ship_Qty;
                        cmd3.Parameters["@MT_Code"].Value = item.Mt_Code;

                        if (cmd3.ExecuteNonQuery() < 1)
                            throw new Exception();
                    }
                    #endregion
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

        /// <summary>
        /// 입고 상세 목록 삭제
        /// </summary>
        /// <param name="storeNum">입고 상세 번호</param>
        /// <returns></returns>
        public bool DeleteStore(int storeNum)
        {
            //STORE_Detail을 먼저 삭제하고, STORE를 삭제한다. (FK)
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    //삭제 전 store PK랑 프로시저에 쓸 OrderNo 가져오기
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    cmd.CommandText = "select STORE_No, ORDER_No, STORE_Qty, MT_Code, STORE_Unit from Store_Detail where STORE_Detail = @STORE_Detail";
                    cmd.Parameters.AddWithValue("@STORE_Detail", storeNum);

                   MySqlDataReader dr = cmd.ExecuteReader();
                    int masterNo = 0, orderNo = 0, qty = 0, mtCode = 0;
                    string units = string.Empty;
                    if (dr.Read())
                    {
                        masterNo = Convert.ToInt32(dr["STORE_No"]);
                        orderNo = Convert.ToInt32(dr["ORDER_No"]);
                        mtCode = Convert.ToInt32(dr["MT_Code"]);
                        qty = Convert.ToInt32(dr["STORE_Qty"]);
                        units = dr["STORE_Unit"].ToString();
                    }
                    dr.Close();

                    //Detail 삭제
                    cmd.CommandText = "delete from Store_Detail where STORE_Detail = @STORE_Detail and STORE_Qty=Stored_Qty";

                    int iRowAffect = cmd.ExecuteNonQuery();
                    if (iRowAffect < 1)
                        throw new Exception("입고번호에 해당하는 정보가 없거나 이미 사용한 재고입니다.");

                    //입고한 재고 총 재고량에서 제거
                    //cmd.CommandText = @"update Material set MT_Qty=MT_Qty-@STORE_Qty where MT_Code=@MT_Code";
                    //                    cmd.CommandText = @"update Material set MT_Qty=MT_Qty-(
                    //select 
                    //	case
                    //		when (@STORE_Unit = MT_Unit) then @STORE_Qty
                    //		when @STORE_Unit = 'U002' and MT_Unit = 'U001' then 0.001*@STORE_Qty
                    //		when @STORE_Unit = 'U001' and MT_Unit = 'U002' then 1000*@STORE_Qty
                    //	end 
                    //from Material M 
                    //where M.MT_Code=@MT_Code)
                    //where MT_Code=@MT_Code";
                    cmd.CommandText = @"update Material 
set MT_Qty=MT_Qty-(
select 
	case
		when (@STORE_Unit = MT_Unit) then @STORE_Qty
		when EXISTS (select Code, Name from Common_Code where Category='단위' and P_Code<>'U000' and Code=@STORE_Unit) and EXISTS (select Code from Common_Code where Category='단위' and P_Code='U000' and Name<>'EA' and Code=MT_Unit) then 0.001*@STORE_Qty
		when EXISTS (select Code from Common_Code where Category='단위' and P_Code='U000' and Name<>'EA' and Code=@STORE_Unit) and EXISTS (select Code, Name from Common_Code where Category='단위' and P_Code<>'U000' and Code=MT_Unit) then 1000*@STORE_Qty
	end 
from Material M 
where M.MT_Code=@MT_Code)
where MT_Code=@MT_Code";
                    
                    cmd.Parameters.AddWithValue("@MT_Code", mtCode);
                    cmd.Parameters.AddWithValue("@STORE_Qty", qty);
                    cmd.Parameters.AddWithValue("@STORE_Unit", units);


                    cmd.ExecuteNonQuery();

                    //Detail 삭제 후 Master에 그 외 Detail이 남아 있는지 확인
                    cmd.CommandText = "select count(STORE_Detail) from Store_Detail where STORE_No = @STORE_No";
                    cmd.Parameters.AddWithValue("@STORE_No", masterNo);

                    //Detail이 없으면 Master도 삭제
                    if (Convert.ToInt32(cmd.ExecuteScalar()) < 1)
                    {
                        cmd.CommandText = "delete from Store where STORE_No = @STORE_No";
                        iRowAffect = cmd.ExecuteNonQuery();

                        if (iRowAffect < 1)
                            throw new Exception("입고번호에 해당하는 정보가 없습니다.");
                    }

                    //Orders 테이블 ORDER_Status 컬럼 입고/부분입고 처리
                    cmd.CommandText = "SaveOrderStatus";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ORDER_No", orderNo);

                    cmd.ExecuteNonQuery();

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

        
    }

