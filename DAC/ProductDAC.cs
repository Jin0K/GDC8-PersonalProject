using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Data;
using MySql.Data.MySqlClient;

public enum OrderType { OrderToVender, OrderFromCustomer };
    public enum ItemLevel { NoSelect = 0, Product = 1, Material = 2 }

    public class ProductDAC : IDisposable
    {
        MySqlConnection conn;

        public ProductDAC()
        {
            conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString);
            conn.Open();
        }

    public DataTable GetProduct(string brandID, string productName)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
        {
            conn.Close();
        }




        #region READ
        #region 물품
        /// <summary>
        /// 제품/재료에 관한 전체 리스트
        /// </summary>
        /// <returns>물품 리스트</returns>
        public List<Product> GetProductAllList()
        {
            //string sql =
            //    @"SELECT 
            //        m.MT_Code
            //        , m.MT_Name
            //        , m.MT_Image
            //        , m.MT_Qty
            //        , m.MT_Level
            //        ,case MT_Level
            //         when 1 then '완제품'
            //         when 2 then '재료'
            //         end as 'MT_Str_Level'
            //        , m.MT_Safety
            //        , m.MT_Epr_Date
            //        , c.COM_Name
            //        , cc.Name 
            //    FROM Material m
            //    inner join Company c on m.COM_No = c.COM_No
            //    inner join Common_Code cc on m.MT_Unit = cc.Code
            //    order by MT_Level desc";
            string sql = @"
SELECT [MT_Code]
      ,[MT_Name]
      ,[MT_Image]
      ,[MT_Qty]
      ,[MT_Level]
      ,[MT_Str_Level]
      ,[MT_Safety]
      ,[MT_Epr_Date]
      ,[COM_Name]
      ,[MT_Unit]
      ,[MT_Str_Unit] as Unit_Name
  FROM [team1].[dbo].[VW_ITEM_LIST]
  order by MT_Level desc";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

    public DataTable GetProductAllTable()
    {
        string sql = @"
SELECT [MT_Code]
      ,[MT_Name]
      ,[MT_Image]
      ,[MT_Qty]
      ,[MT_Level]
      ,[MT_Str_Level]
      ,[MT_Safety]
      ,[MT_Epr_Date]
      ,[COM_Name]
      ,[MT_Unit]
      ,[MT_Str_Unit] as Unit_Name
  FROM [team1].[dbo].[VW_ITEM_LIST]
  order by MT_Level desc";

        try
        {
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                Dispose();

                return dt;
        }
        catch (Exception err)
        {
            Debug.WriteLine(err.Message);
            return null;
        }
    }



    public DataSet GetProductControl(int productCode, string productName)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetBOMListOfProduct(int mt_Code)
        {
            string sql = @"with MyBOM as
(
    select MT_Code, P_MT_Code, MT_Rate, MT_Unit, 0 Levels
	from BOM
	where MT_Code = @MT_Code
    union all
	select B.MT_Code, B.P_MT_Code, B.MT_Rate, MyB.MT_Unit, (MyB.Levels + 1) Levels
	from BOM B join MyBOM MyB on B.P_MT_Code = MyB.MT_Code
)
select Info, MT_Code, MT_Name, MT_Rate, Levels, Gubun, MT_Unit, (select Name from Common_Code where Code=MT_Unit) as Unit_Name
from (
select distinct case when MyB.Levels = 0 then '▶' 
       else SUBSTRING('      ', 1, MyB.Levels * 3) + 'L ' end + M.MT_Name Info,
       MyB.MT_Code, M.MT_Name
	   , 
	   case when MyB.Levels = 0 then 1
       else MT_Rate end MT_Rate
	   , Levels, 
	   case when MyB.Levels = 0 then '완제품'
       else '재료' end Gubun,
	   case when MyB.Levels = 0 then M.MT_Unit
       else MyB.MT_Unit end MT_Unit, (select Name from Common_Code where Code=M.MT_Unit) as Unit_Name
from MyBOM MyB join Material M on MyB.MT_Code = M.MT_Code) F
order by Levels";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MT_Code", mt_Code);
                return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
            }
        }

        public List<Product> GetBOMListOfMT(int mt_Code)
        {
            string sql = @"with MyBOM as
(
    select MT_Code, C_MT_Code, MT_Rate, MT_Unit, 0 Levels
	from BOM
	where MT_Code = @MT_Code
    union all
	select B.MT_Code, B.C_MT_Code, B.MT_Rate, B.MT_Unit, (MyB.Levels + 1) Levels
	from BOM B join MyBOM MyB on B.C_MT_Code = MyB.MT_Code
)

select distinct case when MyB.Levels = 1 then 'L' 
       else SUBSTRING('      ', 1, MyB.Levels * 3) + '▶' end + M.MT_Name Info,
       MyB.MT_Code, M.MT_Name
	   , Levels, 
	   case when MyB.Levels = 1 then '완제품'
       else '재료' end Gubun,
	   case when MyB.Levels = 1 then  (select Name from Common_Code where Code=M.MT_Unit)
       else '' end Unit_Name
from MyBOM MyB join Material M on MyB.MT_Code = M.MT_Code
order by Levels";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MT_Code", mt_Code);
                return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
            }
        }


        public List<Product> GetProductListForBOM()
        {
            string sql = @"select MT_Code, MT_Name, MT_Level, case when MT_Level = 1 then '완제품'
       else '재료' end Gubun
from Material";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
            }
        }

        /// <summary>
        /// 필터링된 제품/재료 리스트
        /// </summary>
        /// <param name="Mt_Code">물품 고유 번호</param>
        /// <param name="Mt_Level">물품 수준 1 : 완제품, 2 : 재료</param>
        /// <param name="Mt_Name">물품명</param>
        /// <returns>물품 리스트</returns>
        public List<Product> GetProductFilteredList(int Mt_Code, ItemLevel Mt_Level, string Mt_Name)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT 
                            m.MT_Code
                            , m.MT_Name
                            , m.MT_Image
                            , m.MT_Qty
                            , m.MT_Level
                            ,case MT_Level
	                            when 1 then '완제품'
	                            when 2 then '재료'
	                            end as 'MT_Str_Level'
                            , m.MT_Safety
                            , m.MT_Epr_Date
                            , c.COM_Name
                            , cc.Name
                            , cc.Code MT_Unit
                            , cc.Name Unit_Name
                        FROM Material m 
                        inner join Company c on m.COM_No = c.COM_No
                        inner join Common_Code cc on m.MT_Unit = cc.Code
                        ");

            if (Mt_Code != 0 || Mt_Level != ItemLevel.NoSelect || !string.IsNullOrWhiteSpace(Mt_Name))
            {
                sb.Append(" WHERE");

                if (Mt_Code != 0) sb.Append($" m.MT_Code = {Mt_Code}"); //물품 번호가 입력되었을 때
                if (Mt_Level != 0) sb.Append($" m.MT_Level = {(int)Mt_Level}");//물품 수준이 입력되었을 때
                if (!(string.IsNullOrWhiteSpace(Mt_Name)))//물품 이름이 입력되었을 때
                    sb.Append($" m.MT_Name = '{Mt_Name}'");
            }

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), conn))
                {
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public Message<Product> GetProductInfo(int prodID)
        {
            string sql = @"select * from Material where MT_Code = @MT_Code";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                Message<Product> resMsg = new Message<Product>();
                try
                {
                    cmd.Parameters.AddWithValue("@MT_Code", prodID);

                    Product prod = Helper.DataReaderMapToT<Product>(cmd.ExecuteReader());

                    if (prod == null) throw new Exception();

                    resMsg.isSuccess = true;
                    resMsg.message = "성공";
                    resMsg.Instance = prod;

                    return resMsg;
                }
                catch (Exception)
                {
                    resMsg.isSuccess = false;
                    resMsg.message = "물품 정보를 DB로부터 가져오는데 실패했습니다.";
                    resMsg.Instance = null;

                    return resMsg;
                }
            }
        }

        public Message<Product> GetWillShipProductsInfo(int no, int mtCode)
        {
            //string sql = $@"SELECT [ORDER_No]
            //                      ,[ORDER_Date]
            //                      ,[Period_Date]
            //                      ,[COM_No]
            //                      ,[ORDER_Status]
            //                      ,[Status_Name]
            //                      ,[ORDER_Detail]
            //                      ,[MT_Code]
            //                      ,[MT_Name]
            //                      ,[MT_Qty]
            //                      ,[ORDER_Qty]
            //                      ,[ORDER_Unit]
            //                      ,[Unit_Name]
            //                    FROM [team1].[dbo].[VW_GetOrderWithItems]
            //                   WHERE ORDER_No = {no} AND MT_Code = {mtCode}";
            string spName = "sp_GetProductBeforeShip";

           try
           {
                using (MySqlCommand cmd = new MySqlCommand(spName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var param = new[] {
                        new SqlParameter {
                            ParameterName="@Order_No",
                            Direction = System.Data.ParameterDirection.Input,
                            Value = no
                        },
                        new SqlParameter {
                            ParameterName="@MT_Code",
                            Direction = System.Data.ParameterDirection.Input,
                            Value = mtCode
                        }
                    };

                    cmd.Parameters.AddRange(param);

                    List<Product> temp = Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                    Message<Product> result = new Message<Product> { isSuccess = true, Instance = temp[0], message = "성공"};

                    if (result != null)
                        return result;
                    else throw new Exception();
                }
           }
           catch(Exception)
           {
                return new Message<Product> { isSuccess = false, message = $"DB로부터 제품 정보(제품 코드 : {mtCode})를 가져오는데 실패했습니다."};
           }
        }

    public bool IsVaildName(string text1, string text2)
    {
        throw new NotImplementedException();
    }

    public Messages<ShippedProductInfoVO> GetShippedProductInfoList()
        {
            string sql = @"SELECT SMT_Detail
      ,SMT_No
      ,ORDER_No
      ,COM_No
      ,COM_Name
      ,SMT_Date
      ,SMT_Status
      ,Status_Name
      ,MT_Code
      ,MT_Name
      ,SMT_Qty
      ,SMT_Unit
      ,Unit_Name
      ,ORDER_Price
  FROM VW_ShippedProductDetailInfo";

            using(MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                Messages<ShippedProductInfoVO> resMsg = new Messages<ShippedProductInfoVO>();

                try
                {
                    List<ShippedProductInfoVO> products = Helper.DataReaderMapToList<ShippedProductInfoVO>(cmd.ExecuteReader());

                    if (products == null) throw new Exception();

                    resMsg.isSuccess = true;
                    resMsg.Instances = products;
                    resMsg.message = "성공";
                }
                catch (Exception)
                {
                    resMsg.isSuccess = false;
                    resMsg.Instances = null;
                    resMsg.message = "DB에서 추출하지 못했습니다.";
                }

                return resMsg;
            }
        }
        #endregion

        #region 수주/발주
        /// <summary>
        /// 수주목록
        /// </summary>
        /// <returns></returns>
        public List<OrderVO> GetProductListFromOrder(OrderType type)
        {
            string orderType = string.Empty;

            switch (type)
            {
                case OrderType.OrderToVender:
                    orderType = "ODT1";
                    break;
                case OrderType.OrderFromCustomer:
                    orderType = "ODT2";
                    break;
                default:
                    break;
            }

            string sql = @"SELECT * From VW_GetOrderListWithCompany WHERE ORDER_TYPE = @OrderType";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderType", orderType);
                    return Helper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

    public bool Insert(Product prod, QuantityPerOption[] qpos, ImagePerOption[] ipos)
    {
        throw new NotImplementedException();
    }

    public List<OrderVO> GetProductListFromOrder(OrderType type, int com, string status, string from, string to)
        {
            StringBuilder sbQuery = new StringBuilder(@"SELECT * FROM VW_GetOrderListWithCompany");

            switch (type)
            {
                case OrderType.OrderToVender:
                    sbQuery.Append($" WHERE ORDER_TYPE = 'ODT1'");
                    break;
                case OrderType.OrderFromCustomer:
                    sbQuery.Append($" WHERE ORDER_TYPE = 'ODT2'");
                    break;
                default:
                    break;
            }



            if (com > 0)
                sbQuery.Append($" and c.COM_NO = {com}");
            if (!string.IsNullOrWhiteSpace(status))
                sbQuery.Append($" and ORDER_Status = {status}");
            if (!string.IsNullOrWhiteSpace(from)&& !string.IsNullOrWhiteSpace(to))
                sbQuery.Append($" and ORDER_Date Between '{from}' AND '{to}'");
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sbQuery.ToString(), conn))
                {
                    return Helper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

        }
        public Message<OrderVO> GetShipInfo(int no, int com, string status, DateTime from, DateTime to)
        {
            StringBuilder sbQuery = new StringBuilder(@"SELECT * FROM VW_GetOrderDetailListWithCompany");
            StringBuilder sbWhere = new StringBuilder(" WHERE ");

            StringBuilder sbErr = new StringBuilder();
            Message<OrderVO> resMsg;

            int lenWhere = sbWhere.Length;

            if(no > 0)
            {
                sbWhere.Append($"ORDER_No = {no}");
            }

            if (com > 0)
            {
                if (sbWhere.Length > lenWhere) sbWhere.Append(" AND ");
                sbWhere.Append($"COM_No = {com}");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                if (sbWhere.Length > lenWhere) sbWhere.Append(" AND ");
                sbWhere.Append($"ORDER_Status = {status}");
            }

            //검색 기간이 기본 값이 아닐 때
            if((from.Year != 1 && to.Year != 1) )
            {
                //시작 기간의 연도가 종료 기간의 연도 보다 클 때
                if (from.Year > to.Year) sbErr.Append("검색 기간(연도) ");

                //시작 기간의 월이 종료 기간의 월 보다 클 때
                if (from.Month > to.Month) sbErr.Append("검색 기간(월) ");

                //시작 기간의 월과 종료 기간의 월 수가 같으면서
                //시작 기간의 일이 종료 기간의 일 보다 클 때
                if ((from.Month == to.Month) && (from.Day > to.Day))
                {
                    sbErr.Append("검색 기간(일)");
                    throw new Exception();
                }

                if (sbWhere.Length > lenWhere) sbWhere.Append(" AND ");
                sbWhere.Append($"ORDER_Date Between '{from.ToString()}' AND '{to.ToString()}'");
            }

            if (sbWhere.Length > lenWhere) sbQuery.Append(sbWhere);

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sbQuery.ToString(), conn))
                {
                    List<OrderVO> orders = Helper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                    resMsg = new Message<OrderVO> { isSuccess = true, message = "성공", Instance = orders[0] };
                    return resMsg;
                }
            }
            catch (Exception)
            {
                sbErr.Append("을 수정해주시기 바랍니다.");

                resMsg = new Message<OrderVO> { isSuccess = false, message = sbErr.ToString(), Instance = null };
                
                return resMsg;
            }
        }

        public Messages<ShippedProductInfoVO> GetAllShippedProductInfoINVW()
        {
            string sql = "SELECT * FROM VW_AllShippedProductInfo";

            StringBuilder sbErr = new StringBuilder();
            Messages<ShippedProductInfoVO> resMsg;

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    List<ShippedProductInfoVO> orders = Helper.DataReaderMapToList<ShippedProductInfoVO>(cmd.ExecuteReader());
                    resMsg = new Messages<ShippedProductInfoVO> { isSuccess = true, message = "성공", Instances = orders };
                    return resMsg;
                }
            }
            catch (Exception)
            {
                sbErr.Append("을 수정해주시기 바랍니다.");

                resMsg = new Messages<ShippedProductInfoVO> { isSuccess = false, message = "실패", Instances = null };

                return resMsg;
            }

        }
       
        public List<OrderDetailVO> GetOrderDetails(int OrderNo)
        {
            string sql = @"SELECT od.[ORDER_Detail] 
      ,od.[MT_Code]
	  ,m.MT_Name
      ,[ORDER_Qty]
	  ,[ORDER_Unit]
      ,case [ORDER_Unit]
		when 'U003' then 'EA'
		else '미정'
		end as Unit_Name
      ,[ORDER_Price]
	  ,m.MT_Qty
      ,m.MT_Epr_Date
  FROM [team1].[dbo].[Order_Detail] od
  inner join [team1].[dbo].[Material] m
  on od.MT_Code = m.MT_Code
  inner join [team1].[dbo].[TBL_COM_MTR]cm
  on od.COM_MTR_ID = cm.COM_MTR_ID
  where ORDER_No = @OrderNo";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
                    return Helper.DataReaderMapToList<OrderDetailVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
        #endregion

        public List<Product> GetProductList() // 레벨 1 / 2 에 나뉘어 완제품/재료 나누는 쿼리
        {

            string sql = @"select  MT_Code, MT_Name, case MT_Level  when 1 then '완제품'  when 2 then '재료'  end as 'MT_Str_Level' from Material";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }

        }

        public List<Product> GetIngredient(int P_MT_Code) // BOM과 Material 및 Common_Code 테이블 조인 후 재료 명 가져오는 쿼리문
        {
            string sql = @"SELECT BOM.MT_CODE, MATERIAL.MT_NAME, BOM.MT_RATE, BOM.MT_UNIT, Common_Code.NAME as Unit_Name FROM BOM JOIN MATERIAL ON BOM.MT_Code = MATERIAL.MT_Code JOIN Common_Code ON BOM.MT_Unit = Common_Code.Code WHERE P_MT_CODE = @P_MT_Code ORDER BY MT_CODE ASC";
            
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@P_MT_Code", P_MT_Code);
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<Product> GetIngredientDetail(int P_MT_Code)
        {
            string sql = @"SELECT 
                            b.MT_CODE
                            , b.MT_Rate
                            , b.Mt_Unit
                            , c.Name as Unit_Name
                            , concat(b.MT_RATE,'(', c.NAME,')') as rate_bom
                            , m.MT_NAME 
                            , concat(m.MT_Qty,'(', m.Unit_Name,')') as qty_bom
                            , concat(m.MT_Safety,'(', m.Unit_Name,')') as safety_bom
                        FROM BOM b
                            JOIN
							(
								select 
									m.MT_Code
									, m.MT_Name 
									, c.Name as Unit_Name
									, m.MT_Qty
									, m.MT_Safety
								from Material m
									inner join Common_Code c on m.MT_Unit = c.Code
							) m on b.MT_Code = m.MT_Code
                            JOIN Common_Code c ON b.MT_Unit = c.Code
                        WHERE P_MT_CODE = @P_MT_Code";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@P_MT_Code", P_MT_Code);
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<Product> GetIngredientDetails(int P_MT_Code)
        {
            string sql = @"SELECT 
                            b.MT_CODE
                            , b.MT_Rate
                            , b.Mt_Unit
                            , c.Name as Unit_Name
                            , concat(b.MT_RATE,'(', c.NAME,')') as rate_bom
                            , m.MT_NAME 
                            , concat(m.MT_Qty,'(', m.Unit_Name,')') as qty_bom
                            , concat(m.MT_Safety,'(', m.Unit_Name,')') as safety_bom
                        FROM BOM b
                            JOIN
							(
								select 
									m.MT_Code
									, m.MT_Name 
									, c.Name as Unit_Name
									, m.MT_Qty
									, m.MT_Safety
								from Material m
									inner join Common_Code c on m.MT_Unit = c.Code
							) m on b.MT_Code = m.MT_Code
                            JOIN Common_Code c ON b.MT_Unit = c.Code
                        WHERE P_MT_CODE = @P_MT_Code";

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@P_MT_Code", P_MT_Code);
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<Product> GetProducts(int Mt_Code)
        {
            string sql = @"SELECT MT_CODE, MT_NAME, MT_QTY FROM MATERIAL WHERE MT_CODE = @MT_CODE";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Mt_Code", Mt_Code);
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<Product> GetBOMList(int Mt_Code)
        {
            string sql = @"
	with MyMaterial as
(
select MT_Code, MT_Rate, MT_Unit, 0 levels
from BOM
where MT_Code = @MT_Code

union all

select B.MT_Code, B.MT_Rate, B.MT_Unit, (A.levels + 1) levels
from MyMaterial A join BOM B on A.MT_Code = B.P_MT_Code
)

select case when levels = 0  then '▶'

    else SUBSTRING('      ',1,levels * 3) + 'L ' end + m.MT_Name info,

    MT_Rate, mm.MT_Unit

    from MyMaterial mm
inner join Material m on mm.MT_Code = m.MT_Code";
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Mt_Code", Mt_Code);
                    return Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

       
 
        #endregion

        #region Create OR Insert
        /// <summary>
        /// 물품 정보 DB 삽입
        /// </summary>
        /// <param name="prod">물품 Instance</param>
        /// <returns>쿼리 실행 결과(Type Bool)</returns>
        public bool AddProductInfo(Product prod)
        {
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"insert into Material(MT_Name, MT_LEVEL, MT_Safety, MT_Epr_Date, MT_Unit, STR_Date, MT_Image, MT_Qty, COM_No) values (@MtName, @MtLevel, @MtSafety, @MtEprDate, @MtUnit, @STR_Date, @MtImage, @MtQty, @ComNo)";

                    cmd.Parameters.AddWithValue("@MtName", prod.Mt_Name);
                    cmd.Parameters.AddWithValue("@MtLevel", prod.Mt_Level);
                    cmd.Parameters.AddWithValue("@MtSafety", prod.Mt_Safety);
                    cmd.Parameters.AddWithValue("@MtUnit", prod.Mt_Unit);
                    cmd.Parameters.AddWithValue("@MtEprDate", prod.Mt_Epr_Date);
                    cmd.Parameters.AddWithValue("@STR_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MtQty", prod.Mt_Qty);
                    cmd.Parameters.AddWithValue("@ComNo", prod.Com_No);

                    cmd.Parameters.Add("@MtImage", MySql.Data.MySqlClient.MySqlDbType.Blob); //img

                    if (prod.Mt_Image != null)
                    {
                        cmd.Parameters["@MtImage"].Value = prod.Mt_Image;
                    }
                    else
                    {
                        cmd.Parameters["@MtImage"].Value = DBNull.Value;
                    }

                    if (cmd.ExecuteNonQuery() < 1)
                        //throw new Exception("물품 정보를 저장 중에 에러가 발생했습니다.");
                        throw new Exception();

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

        public bool AddProductBOM(int prodID, List<Product> prod)
        {
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = "delete from BOM where P_MT_Code = @PMTCode";
                    cmd.Parameters.AddWithValue("@PMTCode", prodID);
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = @"INSERT INTO BOM(MT_Code, P_MT_Code, MT_Rate, MT_Unit) VALUES (@MT_Code, @PMTCode, @MT_Rate, @MT_Unit)";
                    cmd.Parameters.Add(new SqlParameter("@MT_Code", MySqlDbType.Int32));
                    cmd.Parameters.Add(new SqlParameter("@MT_Rate", MySqlDbType.Int32));
                    cmd.Parameters.Add(new SqlParameter("@MT_Unit", MySqlDbType.VarChar));
                    

                    foreach (Product item in prod)
                    {
                        cmd.Parameters["@MT_Code"].Value = item.Mt_Code;
                        cmd.Parameters["@MT_Rate"].Value = item.Mt_Rate;
                        cmd.Parameters["@MT_Unit"].Value = item.Mt_Unit;
                      
                        if (cmd.ExecuteNonQuery() < 1)
                            throw new Exception();
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

        /// <summary>
        /// 제품 생산으로 인한 재료 소모
        /// </summary>
        /// <param name="products">소모된 재료 리스트</param>
        /// <returns>boolean - 실행 결과</returns>
        public bool InsertConsumeInfo(List<Product> products)
        {
           MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"INSERT INTO Shipment(COM_No, ORDER_No, SMT_Date, SMT_Status)
VALUES(@COM_No, @ORDER_No, @SMT_Date, @SMT_Status); Select @@IDENTITY; ";
                    cmd.Parameters.AddWithValue("@Order_No", DBNull.Value);
                    cmd.Parameters.AddWithValue("@COM_No", DBNull.Value);
                    cmd.Parameters.AddWithValue("@SMT_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SMT_status", "SHP05");

                    int smtNo = Convert.ToInt32(cmd.ExecuteScalar());

                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = $@"INSERT INTO Shipment_Detail(SMT_No, SMT_Case, MT_Code, SMT_Qty, SMT_Unit) VALUES ({smtNo}, 'SHP05', @MT_Code, @SMT_Qty, @SMT_Unit)";
                    cmd2.Transaction = trans;

                    cmd2.Parameters.Add("@MT_Code", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@SMT_Qty", MySqlDbType.Decimal);
                    cmd2.Parameters.Add("@SMT_Unit", MySqlDbType.VarChar); //nvarchar

                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Connection = conn;
                    cmd3.CommandText = @"UPDATE [dbo].[Material] SET MT_Qty = @MT_Qty WHERE MT_Code = @MT_Code";

                    cmd3.Parameters.Add("@MT_Qty", MySqlDbType.Decimal);
                    cmd3.Parameters.Add("@MT_Code", MySqlDbType.Int32);

                    foreach (Product item in products)
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
        public bool InsertShippingInfo(OrderVO order, List<Product> products)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"UPDATE ORDER SET ORDER_Status = @ordStatus WHERE ORDER_No = @ordNo";

                    cmd.Parameters.AddWithValue("@ordStatus", order.ORDER_Status);
                    cmd.Parameters.AddWithValue("@ordNo", order.ORDER_No);

                    cmd.Parameters.Clear();

                    cmd.CommandText = @"INSERT INTO Shipment(COM_No, ORDER_No, SMT_Date, SMT_Status)
VALUES(@COM_No, @ORDER_No, @SMT_Date, @SMT_Status); Select @@IDENTITY; ";
                    cmd.Parameters.AddWithValue("@Order_No", order.ORDER_No);
                    cmd.Parameters.AddWithValue("@COM_No", order.COM_No);
                    cmd.Parameters.AddWithValue("@SMT_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SMT_status", order.ORDER_Status);

                    int smtNo = Convert.ToInt32(cmd.ExecuteScalar());

                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandText = @"INSERT INTO Shipment_Detail(SMT_No, SMT_Case, MT_Code, SMT_Qty, SMT_Unit) VALUES (@SMT_No, @SMT_Case, @MT_Code, @SMT_Qty, @SMT_Unit)";
                    cmd2.Transaction = trans;

                    cmd2.Parameters.Add("@SMT_No", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@SMT_Case", MySqlDbType.VarChar);
                    cmd2.Parameters.Add("@MT_Code", MySqlDbType.Int32);
                    cmd2.Parameters.Add("@SMT_Qty", MySqlDbType.Decimal);
                    cmd2.Parameters.Add("@SMT_Unit", MySqlDbType.VarChar);

                    MySqlCommand cmd3 = new MySqlCommand();
                    cmd3.Transaction = trans;
                    cmd3.Connection = conn;
                    cmd3.CommandText = @"UPDATE [dbo].[Material] SET MT_Qty = @MT_Qty WHERE MT_Code = @MT_Code";

                    cmd3.Parameters.Add("@MT_Qty", MySqlDbType.Decimal);
                    cmd3.Parameters.Add("@MT_Code", MySqlDbType.Int32);

                    foreach (Product item in products)
                    {
                        cmd2.Parameters["@SMT_No"].Value = smtNo;
                        cmd2.Parameters["@MT_Code"].Value = item.Mt_Code;
                        cmd2.Parameters["@SMT_Qty"].Value = item.Ship_Qty;
                        cmd2.Parameters["@SMT_Unit"].Value = item.Mt_Unit;
                        cmd2.Parameters["@SMT_Case"].Value = item.Mt_Status;

                        if (cmd2.ExecuteNonQuery() < 1)
                            throw new Exception();

                        cmd3.Parameters["@MT_Qty"].Value = item.Mt_Qty - item.Ship_Qty;
                        cmd3.Parameters["@MT_Code"].Value = item.Mt_Code;

                        if (cmd3.ExecuteNonQuery() < 1)
                            throw new Exception();
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

        public bool CopyBOM(int P_Mt_Code, List<Product> prod)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"
                    INSERT INTO BOM( MT_Code, P_MT_Code , MT_Rate, MT_Unit)
                    SELECT MT_Code, @P_MT_Code, MT_Rate, MT_Unit 
                    FROM BOM 
                    WHERE MT_Code = @MT_Code";

                    cmd.Parameters.Add(new SqlParameter("@MT_Code", MySqlDbType.Int32));
                    cmd.Parameters.AddWithValue("@P_MT_Code", P_Mt_Code);
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

        public bool InsertOrderFromCustomer(OrderVO ord, List<OrderDetailVO> orderDetails)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Transaction = trans;
                    cmd.Connection = conn;

                    cmd.CommandText = $@"INSERT INTO [dbo].[Orders]
           ([ORDER_Date]
           ,[ORDER_Price]
           ,[COM_No]
           ,[Period_Date]
           ,[ORDER_Status]
           ,[ORDER_Type])
     VALUES
           (@Order_Date
           ,@ORDER_Price
           ,@COM_No
           ,@Period_Date
           ,@ORDER_Status
           ,@ORDER_Type); SELECT @@IDENTITY;";

                    cmd.Parameters.AddWithValue("@Order_Date", ord.ORDER_Date);
                    cmd.Parameters.AddWithValue("@ORDER_Price", ord.ORDER_Price);
                    cmd.Parameters.AddWithValue("@COM_No", ord.COM_No);
                    cmd.Parameters.AddWithValue("@Period_Date", ord.Period_Date);
                    cmd.Parameters.AddWithValue("@ORDER_Status", ord.ORDER_Status);
                    cmd.Parameters.AddWithValue("@ORDER_Type", ord.ORDER_Type);

                    int OrderNo = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd.Parameters.Clear();

                    cmd.CommandText = @"INSERT INTO [dbo].[Order_Detail]
           ([ORDER_No]
           ,[MT_Code]
           ,[ORDER_Qty]
           ,[ORDER_Unit]
           ,[ORDER_Price]
           ,[COM_MTR_ID])
     VALUES
           (@ORDER_No
           ,@MT_Code
           ,@ORDER_Qty
           ,@ORDER_Unit
           ,@ORDER_Price
           ,@COM_MTR_ID)";

                    cmd.Parameters.AddWithValue("@ORDER_No", OrderNo);
                    cmd.Parameters.Add("@MT_Code", MySqlDbType.Int32);
                    cmd.Parameters.Add("@ORDER_Qty", MySqlDbType.Decimal);
                    cmd.Parameters.Add("@ORDER_Unit", MySqlDbType.VarChar);
                    cmd.Parameters.Add("@ORDER_Price", MySqlDbType.Int32);
                    cmd.Parameters.Add("@COM_MTR_ID", MySqlDbType.Int32);

                    foreach (OrderDetailVO item in orderDetails)
                    {
                        cmd.Parameters["@MT_Code"].Value = item.MT_Code;
                        cmd.Parameters["@ORDER_Qty"].Value = item.ORDER_Qty;
                        cmd.Parameters["@ORDER_Unit"].Value = item.ORDER_Unit;
                        cmd.Parameters["@ORDER_Price"].Value = item.ORDER_Price;
                        cmd.Parameters["@COM_MTR_ID"].Value = item.COM_MTR_ID;

                        if (cmd.ExecuteNonQuery() < 1) throw new Exception();
                    }

                    trans.Commit();
                    return true;
                }
            }
            catch (Exception)
            {
                trans.Rollback();
                return false;
            }
        }


        #endregion

        #region Update
        /// <summary>
        /// 제품/재료 일부 정보 갱신
        /// </summary>
        /// <param name="prod">제품/재료</param>
        /// <returns></returns>
        public List<Product> UpdateAndGetProductSimpleInfo(Product prod)
        {
            //string sql = @"update Material SET MT_Name = @MtName, MT_Safety = @MtSafety, MT_Qty = @MtQty, MT_Epr_Date = @MtEprDate, MT_Unit = @MtUnit, MT_Ord_Qty = @OrdQty, COM_No = @ComNo where MT_Code = @MtCode;";
            //string sql = @"update Material SET MT_Name = @MtName, MT_Safety = @MtSafety, MT_Qty = @MtQty, MT_Epr_Date = @MtEprDate, COM_No = @ComNo where MT_Code = @MtCode;";

            StringBuilder sb = new StringBuilder("UPDATE Material SET ");

            if (!string.IsNullOrWhiteSpace(prod.Mt_Name))
                sb.Append($"MT_Name = '{prod.Mt_Name}'");
            if (prod.Mt_Safety > 0)
                sb.Append($", MT_Safety = {prod.Mt_Safety}");
            if (prod.Mt_Qty > -1)
                sb.Append($", MT_Qty = {prod.Mt_Qty}");
            if (!string.IsNullOrWhiteSpace(prod.Mt_Epr_Date.ToString()))
                sb.Append($", MT_Epr_Date = '{prod.Mt_Epr_Date}'");
            if (prod.Com_No > 0)
                sb.Append($", COM_No = {prod.Com_No}");
            sb.Append($" WHERE MT_Code = {prod.Mt_Code}");

            try
            {
                MySqlCommand cmd = new MySqlCommand(sb.ToString(), conn);

                if (cmd.ExecuteNonQuery() < 0) throw new Exception();

                List<Product> result = GetProductAllList();

                return result;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool UpdateBOM(Product prod) //BOM재료 수정하는 쿼리문
        {
            string sql = @"UPDATE Material SET MT_Name = @MTName, MT_Qty = @MTQty where MT_Code = @MTCode";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MtCode", prod.Mt_Code);               
                cmd.Parameters.AddWithValue("@MtName", prod.Mt_Name);
                cmd.Parameters.AddWithValue("@MtQty", prod.Mt_Qty);


                if (cmd.ExecuteNonQuery() < 1)
                    throw new Exception("물품 정보를 수정 중에 오류가 발생했습니다.");

                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }


        /// <summary>
        /// 제품/재료 상세 정보 갱신
        /// </summary>
        /// <param name="prod">제품/재료</param>
        /// <returns>갱신 결과</returns>
        public bool UpdateProductDetailInfo(Product prod)
        {
           MySqlTransaction trans = conn.BeginTransaction();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                cmd.Transaction = trans;
                cmd.CommandText = @"update Material SET MT_Name = @MtName, MT_Safety = @MtSafety, MT_Qty = @MtQty, MT_Epr_Date = @MtEprDate, MT_Unit = @MtUnit, COM_No = @ComNo where MT_Code = @MtCode;";

                try
                {
                    //prod.Mt_Epr_Date = Convert.ToInt32(nudExpirationDateInList.Value);
                    cmd.Parameters.AddWithValue("@MtCode", prod.Mt_Code);
                    cmd.Parameters.AddWithValue("@MtName", prod.Mt_Name);
                    cmd.Parameters.AddWithValue("@MtSafety", prod.Mt_Safety);
                    cmd.Parameters.AddWithValue("@MtUnit", prod.Mt_Unit);
                    cmd.Parameters.AddWithValue("@MtQty", prod.Mt_Qty);
                    cmd.Parameters.AddWithValue("@ComNo", prod.Com_No);
                    //cmd.Parameters.AddWithValue("@OrdQty", prod.Ord_Qty);
                    cmd.Parameters.AddWithValue("@MtEprDate", prod.Mt_Epr_Date);

                    if (cmd.ExecuteNonQuery() < 1)
                        throw new Exception("물품 정보를 수정 중에 에러가 발생했습니다.");

                    return true;
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err.Message);
                    return false;
                }
            }
        }

        public Message UpdateMaterialQty(List<Product> products)
        {
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandText = @"update Material SET MT_Qty = @MtQty where MT_Code = @MtCode;";
                    cmd.Parameters.Add("@MtQty", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                    cmd.Parameters.Add("@MtCode", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    foreach (Product prod in products)
                    {
                        cmd.Parameters["@MtQty"].Value = prod.Mt_Qty;
                        cmd.Parameters["@MtCode"].Value = prod.Mt_Code;

                        if (cmd.ExecuteNonQuery() < 1)
                            throw new Exception("물품 정보를 갱신 중에 에러가 발생했습니다.");
                    }

                    trans.Commit();
                    return new Message { isSuccess = true, message = "물품 정보 갱신 성공"};
                }
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return new Message { isSuccess = false, message = err.Message };
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 제품/재료 삭제
        /// </summary>
        /// <param name="prodID">물품 고유 번호</param>
        /// <returns>삭제 결과</returns>
        public bool DeleteProductInfo(int prodID)
        {
            string sql = @"delete from Material where MT_Code = @MtCode;";

            try
            {
                //prod.Mt_Epr_Date = Convert.ToInt32(nudExpirationDateInList.Value);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MtCode", prodID);

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

       public bool DeleteOrderFromCustomer(int ordID)
        {
           MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    cmd.CommandText = @"DELETE FROM ORDER_DETAIL WHERE ORDER_No = @ordID";
                    cmd.Parameters.AddWithValue("@ordID", ordID);

                    if (cmd.ExecuteNonQuery() < 1) throw new Exception();

                    cmd.Parameters.Clear();

                    cmd.CommandText = @"DELETE FROM ODRER WHERE ORDER_No = @ordID";
                    cmd.Parameters.AddWithValue("@ordID", ordID);

                    if (cmd.ExecuteNonQuery() < 1) throw new Exception();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;

                return false;
            }
        }

        #endregion
    }


