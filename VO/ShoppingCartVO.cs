using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    //SHOPPING_CART_ID, CUSTOMER_ID, PRODUCT_CODE, QUANTITY, INCLUDED_DATE, ORDER_CHECK
    public class ShoppingCart
    {
        public int CartID { get; set; }
        public string CustomerID { get; set; }
        public int ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime IncludedDate { get; set; }
        public bool OrderCheck { get; set; }
    }

        
    

