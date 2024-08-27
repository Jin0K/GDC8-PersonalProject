using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

public class OrderInfoVO
    {
        public OrderVO OrderM { get; set; }
        public OrderDetailVO OrderD { get; set; }
        public Product Prod { get; set; }
        
    }

    public class OrderInfoDetailVO
    {
        public int STORE_Qty { get; set; } //발주 상세 번호의 총 입고 수량
        public int ORDER_No { get; set; } //발주/수주 번호
        public DateTime ORDER_Date { get; set; } //발주/수주 날짜
        public int Total_Price { get; set; } //총액(Order table)
        public int COM_No { get; set; } //거래처 번호
        public string COM_Name { get; set; } //거래처명
        public DateTime Period_Date { get; set; } //희망납기날짜
        public string ORDER_Status { get; set; } //발주/수주 상태
        public string ORDER_Type { get; set; } //주문구분(발주/수주)
        public string Status_Name { get; set; } //상태 이름
        public int ORDER_Detail { get; set; } //발주/수주 상세 번호
        //public int ORDER_No { get; set; } //발주/수주 번호
        public int? COM_MTR_ID { get; set; } //거래처별 거래 물품 번호
        public string COM_MTR_Name { get; set; } //거래처별 거래 물품 이름
        public int MT_Code { get; set; } //물품 번호(거래처에 같은 항목이 거래 단위에 따라 거래 단가가 달라지는 경우 문제가 생김)
        public string MT_Name { get; set; } //물품명
        public int ORDER_Qty { get; set; } //주문량
        public string ORDER_Unit { get; set; } //주문량 단위
        public string Unit_Name { get; set; } //주문량 단위 이름
        public int ORDER_Price { get; set; } //비용(Order Detail table)
        public int MT_Min_Order { get; set; } //최소 주문 수량(구격)
        public int MT_Qty { get; set; } //물품 재고량
        #region 필수 정보
        public int Mt_Code { get; set; }//1. 항목 코드
        public string Mt_Name { get; set; }//2. 항목 이름
        public int Mt_Price { get; set; }//3. 단가
        public int Mt_Level { get; set; }//4. 항목 수준
        public string Mt_Str_Level { get; set; }

        public DateTime Mt_Stored_Date { get; set; }//5. 입고 날짜
        public int Mt_Epr_Date { get; set; }//6. 유효 안전 유통기한
        public int Mt_Qty { get; set; }//7. 재고량(default : 0)
        public string Mt_Unit { get; set; }//8. 단위
        public string MT_Unit_Name { get; set; } //8-1. 단위 이름(공통 코드)
        #endregion

        #region 부가 정보
        public int Mt_Safety { get; set; }//9. 안전 재고량 (재료일 때 필수)
        public int Mt_Min_Order { get; set; }//10. 발주 최소 수량
        public Nullable<int> Com_No { get; set; }//11. 재료 주 거래처
        public string Com_Name { get; set; }//11-2 주 거래처 이름
        public byte[] Mt_Image { get; set; }//12. 항목 사진(완제품만 있어도 됨)
        #endregion

    }

