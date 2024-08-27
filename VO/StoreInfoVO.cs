using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

public class StoreInfoVO
    {
        public StoreVO StoreM { get; set; }
        public StoreDetailVO StoreD { get; set; }
    }

    public class StoreExcelExportVO
    {
        public Company Company { get; set; }
        public StoreInfoDetailVO Store { get; set; }
    }


    public class StoreInfoDetailVO
    {
        public int STORE_No { get; set; } //입고 번호
        public int COM_No { get; set; } //거래처 번호
        public string COM_Name { get; set; } //거래처명
        public DateTime STORE_Date { get; set; } //입고 날짜
        public int Total_Case { get; set; } //총 입고 건수
        public string STORE_Status { get; set; } //입고 상태
        public string Status_Name { get; set; } //상태 이름
        public int STORE_Detail { get; set; } //입고 상세 번호
        public int STORE_Case { get; set; } //입고 건수
        public int MT_Code { get; set; } //입고 물품 번호
        public string MT_Name { get; set; } //입고 물품 이름
        public int MT_Price { get; set; } //단가
        public int STORE_Qty { get; set; } //입고 물량
        public string STORE_Unit { get; set; } //입고 단위
        public string Unit_Name { get; set; } //단위 이름
        public DateTime Epr_Date { get; set; } //유통 기간
        public int Stored_Qty { get; set; } //재고량
        public int ORDER_No { get; set; } //발주 번호
        public int ORDER_Detail { get; set; } //발주 상세 번호
        public string COM_MTR_Name { get; set; } //거래처 물품명(규격포함)
    }

