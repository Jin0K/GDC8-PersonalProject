using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class StoreDetailVO
    {
        public int STORE_No { get; set; } //입고 번호
        public int STORE_Detail { get; set; } //입고 상세 번호
        public int STORE_Case { get; set; } //입고 건수
        public int MT_Code { get; set; } //입고 물품 번호
        public int STORE_Qty { get; set; } //입고 물량
        public decimal mSTORE_Qty { get; set; } //입고 물량
        public string STORE_Unit { get; set; } //입고 단위
        public DateTime Epr_Date { get; set; } //유통 기간
        public int Stored_Qty { get; set; } //재고량
        public decimal mStored_Qty { get; set; }// 재고량 Type : Decimal
        public int ORDER_No { get; set; } //발주 번호
        public int ORDER_Detail { get; set; } //발주 상세 번호

    }

