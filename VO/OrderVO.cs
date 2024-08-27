using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class OrderVO
    {
        public int ORDER_No { get; set; } //발주/수주 번호
        public DateTime ORDER_Date { get; set; } //발주/수주 날짜
        public int ORDER_Price { get; set; } //총액
        public int COM_No { get; set; } //거래처 번호
        public string COM_Licence { get; set; }//사업자 등록번호
        public string COM_Name { get; set; } //거래처명
        public string COM_Tel { get; set; } //거래처 번호
        public string COM_Addr_Zip { get; set; }// 거래처 우편번호
        public string COM_Addr_Street1 { get; set; } // 거래처 주소1
        public string COM_Addr_Street2 { get; set; } // 거래처 주소2
        public DateTime Period_Date { get; set; } //희망납기날짜
        public string ORDER_Type { get; set; } //주문구분(발주/수주)
        public string ORDER_Status { get; set; } //발주/수주 상태
        public string Status_Name { get; set; } //상태 이름

        
    }

public class Order
{
    public int OrderNumber { get; set; }
    public string CustomerID { get; set; }
    public int AddressNumber { get; set; }
    public int OrderAmount { get; set; }
    public DateTime OrderDateTime { get; set; }
    public string OrderStatus { get; set; }
    public string OrderStatusName { get; set; }
    public bool PaymentCheck { get; set; }
}


