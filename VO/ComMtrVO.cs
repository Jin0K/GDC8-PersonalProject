using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class ComMtrVO
    {
        public int COM_MTR_ID { get; set; } //거래처별 거래 물품 번호
        public string COM_MTR_Name { get; set; } //거래처별 거래 물품명(규격포함)
        public int MT_Code { get; set; } //물품 번호
        public string MT_Name { get; set; } //물품명
        public int COM_No { get; set; } //업체 번호
        public string COM_Name { get; set; } //업체명
        public string COM_Type { get; set; } //업체형태
        public int MT_Price { get; set; } //물품 단가
        public string MT_Unit { get; set; } //물품 거래 단위 코드
        public string Unit_Name { get; set; } //물품 거래 단위 이름
        public int MT_Min_Order { get; set; } //최소 주문 수량(구격)
    }





