using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    public class Product
    {
        #region 필수 정보
        public int Mt_Code { get; set; }//1. 항목 코드
        public string Mt_Name { get; set; }//2. 항목 이름
        public int Mt_Price { get; set; }//3. 단가
        public int Mt_Level { get; set; }//4. 항목 수준
        public string Mt_Str_Level { get; set; } //4. 항목 수준
        public DateTime Mt_Stored_Date { get; set; }//5. 제품 등록 날짜
        public int Mt_Epr_Date { get; set; }//6. 유효 안전 유통기한
        public decimal Mt_Qty { get; set; }//7. 재고량(default : 0)
        public string Mt_Unit { get; set; }//8. 단위
        public string Unit_Name { get; set; } //8-1. 단위 이름(공통 코드)
        #endregion

        #region 부가 정보
        public int Mt_Safety { get; set; }//9. 안전 재고량 (재료일 때 필수)
        public int Mt_Min_Order { get; set; }//10. 발주 최소 수량
        public Nullable<int> Com_No { get; set; }//11. 재료 주 거래처
        public string Com_Name { get; set; }//11-2 주 거래처 이름
        public byte[] Mt_Image { get; set; }//12. 항목 사진(완제품만 있어도 됨)
        public int Mt_Rate { get; set; } //13. 소모량

        public int P_Mt_Code { get; set; }//BOM 상위 개체
        public string rate_bom { get; set; } // 소모량 + 단위
        public string qty_bom { get; set; }// 재고량 + 단위
        public string safety_bom { get; set; }// 안전재고량 + 단위
        public double totConsume { get; set; }//총 소비량(생산 시 재료 소비량, 출고 시 출고량)
        public decimal Ship_Qty { get; set; } //출고 량
        public decimal Rest_Qty //남은 주문 량
        { 
            get
            {
                return ORDER_Qty - Ship_Qty;
            }
        }
        public string Mt_Status { get; set; }//입출고 상태(부분입고, 전량입고, 부분출고, 전량출고);
        #endregion

        #region 집계 정보
        public decimal ORDER_Qty { get; set; } //13. 총 발주 수량
        public decimal STORE_Qty { get; set; } //14. 총 입고 수량
        public decimal Before_STORE_Qty { get; set; } //15. 미입고 수량
        public decimal Logical_Qty { get; set; } //16. 논리 재고량
        public decimal MT_Require { get; set; } //17. 수주에 필요한 자재 소요량
        public decimal Need_Qty { get; set; } //18. 필요한 재고량
        #endregion

        #region BOM 정전개/역전개
        public string Info { get; set; }
        public int Levels { get; set; }
        public string Gubun { get; set; }
    #endregion





    #region Test

    public string MainImgPath { get; set; }
    public int Ord_Qty { get; set; }
    public int ProductCode { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public float DiscountRate { get; set; }
    public string ColorText { get; set; }
    public string Color { get; set; }
    public string SizeText { get; set; }
    public object Size { get; set; }
    public int TotalInventory { get; set; }
    public string BrandID { get; set; }
    public int Inventory { get; set; }
    public string MainCategory { get; set; }
    public string MiddleCategory { get; set; }
    public string SubCategory { get; set; }
    public string Description { get; set; }
    #endregion

    #region 
    /// <summary>
    /// DataGridView에서 선택된 행의 값을 Product 인스턴스로 반환
    /// </summary>
    public Func<DataGridViewRow, Product> GetProductFromRow = (row) =>
        {
            try
            {
                Product prod = Activator.CreateInstance<Product>();
                foreach (System.Reflection.PropertyInfo prop in prod.GetType().GetProperties())
                {
                    //프로퍼티는 존재하는데, reader안에 조회된 컬럼이 없는 경우
                    //reader에 조회된 컬럼은 있는데, 프로퍼티는 정의되지 않은 경우
                    try
                    {
                        //System.Diagnostics.Debug.WriteLine($"{prop.Name} : {row.Cells[prop.Name].Value}");
                        System.Reflection.PropertyInfo propertyInfo = prod.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(prod, Convert.ChangeType(row.Cells[prop.Name].Value, propertyInfo.PropertyType), null);
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine($"예외발생-1 : {err.Message}");
                        System.Diagnostics.Debug.WriteLine($"예외발생-2 : {prop.Name}");
                        continue;
                    }
                }
                return prod;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);
                throw;
            }
        };
        #endregion
    }

