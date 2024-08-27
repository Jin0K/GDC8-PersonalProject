using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




    class ProductService
    {
        //C
        public bool InsertProductInfo(Product prod)
        {
            ProductDAC dac = new ProductDAC();

            bool result = dac.AddProductInfo(prod);

            dac.Dispose();

            return result;
        }

        public bool InsertBomInfo(int prodID, List<Product> prod)
        {
            ProductDAC dac = new ProductDAC();
            bool result = dac.AddProductBOM(prodID, prod);

            dac.Dispose();
            return result;
        }

        public bool InsertShippingInfo(OrderVO ord, List<Product> products)
        {
            ProductDAC dac = new ProductDAC();
            bool result = dac.InsertShippingInfo(ord, products);

            dac.Dispose();
            return result;
        }

        public bool InsertOrderFromCustomer(OrderVO ord, List<OrderDetailVO> orderDetails)
        {
            ProductDAC dac = new ProductDAC();
            bool result = dac.InsertOrderFromCustomer(ord, orderDetails);

            dac.Dispose();
            return result;
        }

        //R

        public async Task<Message<Product>> GetProductAsync(int prodID)
        {
            ProductDAC dac = new ProductDAC();

            Message<Product> resMsg = dac.GetProductInfo(prodID);

            dac.Dispose();

            return resMsg;
        }

        public List<Product> GetProductAllList()
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetProductAllList();

            dac.Dispose();

            return result;
        }

        public List<Product> GetProductList()
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetProductList();

            dac.Dispose();

            return result;
        }

        public List<Product> GetProductForBOM()
        {
            ProductDAC dac = new ProductDAC();
            List<Product> result = dac.GetProductListForBOM();
            dac.Dispose();

            return result;
        }

        public async Task<Message<Product>> GetWillShipProductsAsync(int ordno, int mtCode)
        {
            ProductDAC dac = new ProductDAC();

            Message<Product> result = dac.GetWillShipProductsInfo(ordno, mtCode);

            dac.Dispose();

            return result;
        }

        public List<Product> GetProductsFilteredList(int Mt_Code, ItemLevel Mt_Level, string Mt_Name)
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetProductFilteredList(Mt_Code, Mt_Level, Mt_Name);

            dac.Dispose();

            return result;
        }

        public object GetBOMListOfProduct(int mt_Code)
        {
            ProductDAC dac = new ProductDAC();
            List<Product> result = dac.GetBOMListOfProduct(mt_Code);
            dac.Dispose();

            return result;
        }

        public object GetBOMListOfMT(int mt_Code)
        {
            ProductDAC dac = new ProductDAC();
            List<Product> result = dac.GetBOMListOfMT(mt_Code);
            dac.Dispose();

            return result;
        }

        public List<OrderDetailVO> GetOrderDetails(int OrderNo)
        {
            ProductDAC dac = new ProductDAC();

            List<OrderDetailVO> result = dac.GetOrderDetails(OrderNo);

            dac.Dispose();

            return result;
        }

        public async Task<List<StoreInfoDetailVO>> GetStoreSearchListAsync()
        {
            StoreDAC dac = new StoreDAC();

            List<StoreInfoDetailVO> result = dac.GetStoreSearchList();

            dac.Dispose();

            return result;
        }

        public async Task<Messages<ShippedProductInfoVO>> GetShippedProductInfoListAsync()
        {
            ProductDAC dac = new ProductDAC();

            Messages<ShippedProductInfoVO> resMsg = dac.GetAllShippedProductInfoINVW();

            dac.Dispose();

            return resMsg;
        }

        //수주목록 데이터 추출
        public List<OrderVO> GetOrdersFromCustomer()
        {
            ProductDAC dac = new ProductDAC();

            List<OrderVO> result = dac.GetProductListFromOrder(OrderType.OrderFromCustomer);

            dac.Dispose();

            return result;
        }

        public async Task<Message<OrderVO>> GetShipInfo(int no = -1, int com = -1, string status = "", DateTime from = default(DateTime), DateTime to = default(DateTime))
        {
            ProductDAC dac = new ProductDAC();

            Message<OrderVO> result = dac.GetShipInfo(no, com, status, from, to);
            
            dac.Dispose();

            return result;
        }

        public List<OrderVO> GetOrdersFromCustomerFiltered(int com = -1, string status = "SHP1", DateTime from = default(DateTime), DateTime to = default(DateTime))
        {
            ProductDAC dac = new ProductDAC();

            List<OrderVO> result = dac.GetProductListFromOrder(OrderType.OrderFromCustomer, com, status, Convert.ToString(from), Convert.ToString(to));

            dac.Dispose();

            return result;
        }

        public List<Product> GetProductBOM()
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetProductFilteredList(0, ItemLevel.Product, "");

            dac.Dispose();

            return result;
        }



        public List<Product> GetSearchMaterial()
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetProductFilteredList(0, ItemLevel.Material, "");

            dac.Dispose();

            return result;
        }

        public List<Product> GetIngredient(int P_Mt_Code)
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetIngredient(P_Mt_Code);

            dac.Dispose();

            return result;

        }

        public List<Product> GetBOMList(int Mt_Code)
        {

            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetBOMList(Mt_Code);

            dac.Dispose();

            return result;
        }

        //public bool CopyBOM(int P_Mt_Code, List<Product> prod)
        //{
        //    ProductDAC dac = new ProductDAC();

        //    bool result = dac.CopyBOM(P_Mt_Code,prod);

        //    dac.Dispose();

        //    return result;
        //}




        /// <summary>
        /// 완제품 생산에 필요한 재료들의 상세 정보를 가져온다.
        /// </summary>
        /// <param name="P_Mt_Code">완제품의 제품 코드</param>
        /// <returns>
        /// MT_code     : 재료 품목 코드
        /// Mt_Name     : 재료명
        /// Mt_Unit     : 단위 코드
        /// Unit_Name   : 단위명
        /// Mt_Rate     : 제품 생산에 필요한 소모량(단위 미포함)
        /// rate_bom    : 제품 생산에 필요한 소모량(단위포함)
        /// safety_bom  : 재료 안전재고량(단위포함)
        /// qty_bom     : 재료 실 재고량(단위포함)
        /// </returns>
        public List<Product> GetIngredientDetail(int P_Mt_Code)
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetIngredientDetail(P_Mt_Code);

            dac.Dispose();

            return result;
        }

        public List<Product> GetProducts(int Mt_Code)
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.GetProducts(Mt_Code);

            dac.Dispose();

            return result;
        }

        //U
        /// <summary>
        /// 물품 약식 정보 갱신
        /// </summary>
        /// <param name="prod">물품 정보</param>
        /// <returns>수행 결과</returns>
        public List<Product> UpdateAndGetProductSimpleInfo(Product prod)
        {
            ProductDAC dac = new ProductDAC();

            List<Product> result = dac.UpdateAndGetProductSimpleInfo(prod);

            dac.Dispose();

            return result;
        }

        /// <summary>
        /// 물품 전체 정보 갱신
        /// </summary>
        /// <param name="prod">물품 정보</param>
        /// <returns>수행 결과</returns>
        public bool UpdateProductDetailInfo(Product prod)
        {
            ProductDAC dac = new ProductDAC();

            bool result = dac.UpdateProductDetailInfo(prod);

            dac.Dispose();

            return result;
        }

        public bool UpdateBOM(Product prod)
        {
            ProductDAC dac = new ProductDAC();

            bool result = dac.UpdateBOM(prod);

            dac.Dispose();
            return result;
        }

        /// <summary>
        /// 생산시 소모된 재료 재고량 수정
        /// </summary>
        /// <param name="products">생산시 소모된 재료리스트</param>
        /// <returns></returns>
        public async Task<Message> InsertConsumeInfo(List<Product> products)
        {
            ProductDAC dac = new ProductDAC();

            Message msg = new Message
            {
                isSuccess = dac.InsertConsumeInfo(products),
            };

            dac.Dispose();

            return msg;
        }


        //D
        /// <summary>
        /// 물품 정보 삭제
        /// </summary>
        /// <param name="mtrCode">물품 고유 번호</param>
        /// <returns>수행 결과</returns>
        public bool DeleteProductInfo(int mtrCode)
        {
            ProductDAC dac = new ProductDAC();

            bool result = dac.DeleteProductInfo(mtrCode);

            dac.Dispose();

            return result;
        }
        public bool DeleteBOM(int mtrCode)
        {
            BomDAC dac = new BomDAC();

            bool result = dac.DeleteBOM(mtrCode);

            dac.Dispose();

            return result;
        }

        public bool DeleteOrderFromCustomer(int ordID)
        {
            ProductDAC dac = new ProductDAC();

            bool result = dac.DeleteOrderFromCustomer(ordID);

            dac.Dispose();

            return result;
        }
    }

