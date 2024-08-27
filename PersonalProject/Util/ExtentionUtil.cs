using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    static class ExtentionUtil
    {
        //확장메서드 
        //1. 파라미터에 어떤 클래스에 대해서 확장하는 것인지 this 클래스명.
        //2. 클래스명에 static을 붙인다.

        public static int WordLength(this string str)
        {
            return str.Trim().Replace(" ", "").Length;
        }

        public static int OriginalInt(this string str)
        {
            return Convert.ToInt32(str.Replace(",", "").Replace("원","").Replace("₩", "").Replace("$", "").Replace("(", "").Replace(")", "").Replace("일", "").Trim());
        }
    }

