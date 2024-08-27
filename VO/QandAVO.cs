using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VO;



public class QandA
    {
        //CONTACT_NUMBER, CUSTOMER_ID, PRODUCT_CODE, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, REGIST_DATETIME, ANSWER, ANSWER_DATETIME
        public int ContactNumber { get; set; }
        public string CustomerID { get; set; }
        public string BrandID { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string QuestionType { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public bool Secret { get; set; }
        public int Hits { get; set; }
        public DateTime RegistDateTime { get; set; }
        public string Answer { get; set; }
        public DateTime AnswerDateTime { get; set; }
    }

