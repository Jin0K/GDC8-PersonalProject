using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




    class OrderToVendorService
    {
        public List<ComMtrVO> GetCompanyList(int mtCode)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            List<ComMtrVO> list = db.FindCompaniesByMT(mtCode);
            db.Dispose();

            return list;
        }

        public List<ComMtrVO> GetAllCompaniesByMT()
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            List<ComMtrVO> list = db.GetAllCompaniesByMT();
            db.Dispose();

            return list;
        }

        public OrderCalcVO GetOrderCalcDetail(int comMtrId)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            OrderCalcVO list = db.GetComMtrDetail(comMtrId);
            db.Dispose();

            return list;
        }

        public bool RegisterOrder(OrderVO order, List<OrderDetailVO> carts)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            bool result = db.RegisterOrder(order, carts);
            db.Dispose();

            return result;
        }

        public List<OrderVO> GetOrderSearchList(
                  string comNo, string mtCode, string status, string dtFrom, string dtTo)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            List<OrderVO> list = db.GetOrderSearchList(comNo, mtCode, status, dtFrom, dtTo);
            db.Dispose();

            return list;
        }

        public OrderToVendorVO GetOrderDetailList(int ordID)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            OrderToVendorVO list = db.GetOrderDetailList(ordID);
            db.Dispose();

            return list;
        }

        public bool UpdateOrder(OrderVO order)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            bool result = db.UpdateOrder(order);
            db.Dispose();

            return result;
        }

        public bool DeleteOrder(int orderNo)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            bool result = db.DeleteOrder(orderNo);
            db.Dispose();

            return result;
        }

        public bool DeleteOrder(List<int> orderNos)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            bool result = db.DeleteOrder(string.Join(",", orderNos), ",");
            db.Dispose();

            return result;
        }

        public Company GetCompanyDetail(int comNo)
        {
            CompanyDAC db = new CompanyDAC();
            Company company = db.GetCompanyInfo(comNo);
            db.Dispose();

            return company;
        }

        public List<Product> GetNeedMTList()
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            List<Product> list = db.GetNeedMTList();
            db.Dispose();

            return list;
        }

        public List<OrderToVendorVO> FastRegisterOrder(List<int> selCodes, List<int> orderQty, DateTime date)
        {
            OrderToVendorDAC db = new OrderToVendorDAC();
            List<OrderToVendorVO> results = db.FastRegisterOrder(string.Join(",", selCodes), string.Join(",", orderQty), ",", date);
            db.Dispose();

            return results;
        }
    }

