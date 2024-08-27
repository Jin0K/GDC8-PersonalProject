using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class StoreVO
    {
        public int STORE_No { get; set; } //입고 번호
        public int COM_No { get; set; } //거래처 번호
        public DateTime STORE_Date { get; set; } //입고 날짜
        public int Total_Case { get; set; } //총 입고 건수
        public string STORE_Status { get; set; } //입고 상태

    }

