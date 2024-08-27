using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class CommonVO
    {
        public string Code { get; set; } //코드
        public string P_Code { get; set; } //부모코드
        public string Category { get; set; } //카테고리
        public string Name { get; set; } //이름

        public enum DivTable { Customer, Brand }

    }

