using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Company
    {
        #region 필수 정보
        public int Com_No { get; set; }//1. 거래처 고유 번호
        public string Com_License { get; set; }//2. 사업자 등록번호
        public string Com_Name { get; set; }//3. 거래처 명
        public string Com_Tel { get; set; }//4. 거래처 연락처
        public string Com_Email { get; set; }//5. 거래처 이메일
        public string Com_Addr_Zip { get; set; }//6. 거래처 우편번호
        public string Com_Addr_Street1 { get; set; }//7. 거래처 주소(도로명)
        public string Com_Addr_Street2 { get; set; }//8. 거래처 주소(상세주소)
        public string Com_Type { get; set; }//9. 거래처 구분
        public string Com_Main_Item { get; set; }//10. 주 거래 품목
        #endregion
    }

