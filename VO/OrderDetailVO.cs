using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class OrderDetailVO
    {
        public int ORDER_Detail { get; set; } //발주/수주 상세 번호
        public int ORDER_No { get; set; } //발주/수주 번호
        public int? COM_MTR_ID { get; set; } //거래처별 거래 물품 번호
        public string COM_MTR_Name { get; set; } //거래처별 거래 물품 이름(규격 포함)
        public int MT_Code { get; set; } //물품 번호(거래처에 같은 항목이 거래 단위에 따라 거래 단가가 달라지는 경우 문제가 생김)
        public string MT_Name { get; set; } //물품명
        public int ORDER_Qty { get; set; } //주문량
        public string ORDER_Unit { get; set; } //주문량 단위
        public string Unit_Name { get; set; } //주문량 단위 이름
        public int ORDER_Price { get; set; } //비용
        public int MT_Min_Order { get; set; } //최소 주문 수량(구격)
        public decimal MT_Qty { get; set; } //물품 재고량
        public int STORE_Detail { get; set; } //입고 상세 번호
        public int STORE_Qty { get; set; } //입고 수량
        public string SD_Status { get; set; } //입고 상태
    }

