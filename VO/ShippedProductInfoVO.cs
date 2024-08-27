using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;


    public class ShippedProductInfoVO
    {
        public int SMT_Detail { get; set; }//출고 상세 번호
        public int SMT_No { get; set; }//출고 번호
        public int ORDER_No { get; set; }//주문 번호(수주)
        public int COM_No { get; set; }//거래처 고유 번호
        public string COM_Name { get; set; }//거래처 이름
        public DateTime SMT_Date { get; set; }//출고 날짜
        public string SMT_Status { get; set; }//출고 상태 - 코드
        public string Status_Name { get; set; }//출고 상태 - 내용
        public int MT_Code { get; set; }//제품 고유 번호
        public string MT_Name { get; set; }//제품명
        public decimal SMT_Qty { get; set; }//출고량
        public string SMT_Unit { get; set; }//출고량 단위 - 코드
        public string Unit_Name { get; set; }//출고량 단위 - 내용
        public int ORDER_Price { get; set; }//매출
    }

