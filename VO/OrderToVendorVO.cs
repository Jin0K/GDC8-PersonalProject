using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

public class OrderToVendorVO
    {
        public OrderVO OrderM { get; set; }
        public List<OrderDetailVO> OrderD { get; set; }
    }


