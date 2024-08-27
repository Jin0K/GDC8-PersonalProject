using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




    class StoreService
    {
        public List<OrderInfoDetailVO> GetOrderSearchList(
                 string comNo, string mtCode, string cmtId, string dtFrom, string dtTo)
        {
            StoreDAC db = new StoreDAC();
            List<OrderInfoDetailVO> list = db.GetOrderSearchList(comNo, mtCode, cmtId, dtFrom, dtTo);
            db.Dispose();

            return list;
        }

        public bool RegisterStore(StoreVO store, StoreDetailVO detail)
        {
            StoreDAC db = new StoreDAC();
            bool result = db.RegisterStore(store, detail);
            db.Dispose();

            return result;
        }

        public async Task<Message> InsertProductManufactured(List<StoreDetailVO> detail, List<Product> products)
        {
            StoreDAC db = new StoreDAC();
            Message result = new Message{ isSuccess = db.InsertProductManufactured(detail, products) };
            db.Dispose();

            return result;
        }

        public List<StoreInfoDetailVO> GetStoreSearchList(
                 string comNo, string mtCode, string status, string dtFrom, string dtTo)
        {
            StoreDAC db = new StoreDAC();
            List<StoreInfoDetailVO> list = db.GetStoreSearchList(comNo, mtCode, status, dtFrom, dtTo);
            db.Dispose();

            return list;
        }

        public bool DeleteStore(int storeNum)
        {
            StoreDAC db = new StoreDAC();
            bool result = db.DeleteStore(storeNum);
            db.Dispose();

            return result;
        }

        internal StoreExcelExportVO GetStoreDetail(int storeNum)
        {
            StoreDAC db = new StoreDAC();
            StoreExcelExportVO list = db.GetStoreDetail(storeNum);
            db.Dispose();

            return list;
        }
    }

