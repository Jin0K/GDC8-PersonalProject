using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //BRAND_ID, BRAND_NAME, COMPANY_REGIST_NUMBER, BRAND_PASSWORD, LOGO_IMG_PATH, BRAND_EMAIL1, BRAND_EMAIL2, BRAND_CONTACT, BRAND_ADDRESS, COUNTRY
    public class Brand
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string CompanyNumber { get; set; }
        public string Password { get; set; }
        public string LogoImagePath { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }


    

