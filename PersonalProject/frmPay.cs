using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalProject
{
    public partial class frmPay : Form
    {
        Customer currentCustomer;
        //DataSet dsProduct;
        DataTable dtAllAddressList, dtProduct, dtCommon;
        int quantity=0;
        bool bPoint=true;
        public frmPay(Customer currentCustomer, int productCode, string productName, int quantity) //제품 하나 구매
        {
            InitializeComponent();

            this.currentCustomer = currentCustomer;
            //this.productCode = productCode;
            this.quantity = quantity;
            ProductDAC dac = new ProductDAC();
            DataSet dsProduct = dac.GetProductControl(productCode, productName);
            dtProduct = dsProduct.Tables["product"];
            dtCommon = dsProduct.Tables["common_code"];
        }

        public frmPay(Customer currentCustomer, DataTable dt) //장바구니 구매
        {
            InitializeComponent();

            this.currentCustomer = currentCustomer;
            dtProduct = dt;
            DataTable dtColor = dt.DefaultView.ToTable(false, new string[] { "COLOR", "COLOR_NAME" });
            dtColor.Columns["COLOR"].ColumnName = "CCODE";
            dtColor.Columns["COLOR_NAME"].ColumnName = "CNAME";
            dtColor.TableName = "dtCommon";
            //DataColumn[] primarykey = new DataColumn[1];
            //primarykey[0] = dtColor.Columns["CCODE"];
            //dtColor.PrimaryKey = primarykey;

            DataTable dtSize = dt.DefaultView.ToTable(false, new string[] { "SIZE", "SIZE_NAME" });
            dtSize.Columns["SIZE"].ColumnName = "CCODE";
            dtSize.Columns["SIZE_NAME"].ColumnName = "CNAME";
            dtSize.TableName = "dtCommon";
            //DataColumn[] pk = new DataColumn[1];
            //pk[0] = dtSize.Columns["CCODE"];
            //dtSize.PrimaryKey = pk;

            DataSet ds = new DataSet();
            ds.Merge(dtColor);
            ds.Merge(dtSize);

            dtCommon = ds.Tables[0];
            //ds.Tables[0].TableName = 
            //dtCommon = dtColor.Merge(dtSize);
            //this.productCode = productCode;
            //this.quantity = quantity;
            //ProductDAC dac = new ProductDAC();
            //dsProduct = dac.GetProductControl(productCode, productName);
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            lblPoint.Text = currentCustomer.Point.ToString() + " 점";

            AddressDAC ad = new AddressDAC();
            dtAllAddressList = ad.GetAddress(currentCustomer.ID);

            CommonUtil.ComboBinding(cboAddress, dtAllAddressList, "ADDRESS_NAME", "ADDRESS_NUMBER");
            ShowAddress();
            int totalPrice = 0, totalPay=0;
            for(int i=0; i < dtProduct.Rows.Count; i++)
            {
                BuyItemUserControl ctrl = new BuyItemUserControl();
                ctrl.Name = $"BuyItem{i}";
                ctrl.Location = new Point(75, 20  + (120 * i)); 
                ctrl.Size = new Size(735, 115);
                DataRow[] drColor = dtCommon.Select($"CCODE='{dtProduct.Rows[i]["COLOR"]}'");
                DataRow[] drSize = dtCommon.Select($"CCODE='{dtProduct.Rows[i]["SIZE"]}'");
                ctrl.ProductItem = new Product()
                {
                    //p.PRODUCT_CODE, PRODUCT_NAME, PRICE, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV
                    ProductCode = Convert.ToInt32(dtProduct.Rows[i]["PRODUCT_CODE"]),
                    ProductName = dtProduct.Rows[i]["PRODUCT_NAME"].ToString(),
                    ProductPrice = Convert.ToInt32(dtProduct.Rows[i]["PRICE"]),
                    MainImgPath = dtProduct.Rows[i]["PRODUCT_IMG"].ToString(),
                    //PRODUCT_IMG
                    //MainImgPath = mainImgs[idx]["SERVER_PATH"].ToString()
                    //MainImgPath = dtProduct.Rows[i]["SERVER_PATH"].ToString(),
                    DiscountRate = Convert.ToSingle(dtProduct.Rows[i]["DISCOUNT_RATE"]),
                    Inventory = Convert.ToInt32(dtProduct.Rows[i]["INVENTORY"]),
                    BrandID = dtProduct.Rows[i]["BRAND_ID"].ToString(),
                    MainCategory = dtProduct.Rows[i]["MAIN_CATEGORY"].ToString(),
                    MiddleCategory = dtProduct.Rows[i]["MIDDLE_CATEGORY"].ToString(),
                    SubCategory = dtProduct.Rows[i]["SUB_CATEGORY"].ToString(),
                    Color = dtProduct.Rows[i]["COLOR"].ToString(),
                    Size = dtProduct.Rows[i]["SIZE"].ToString(),
                    ColorText = drColor[0]["CNAME"].ToString(),
                    SizeText = drSize[0]["CNAME"].ToString()
                };
                if(dtProduct.Columns.Contains("QUANTITY"))
                    ctrl.ItemQty = Convert.ToInt32(dtProduct.Rows[i]["QUANTITY"]);
                else
                    ctrl.ItemQty = quantity;
                totalPrice += Convert.ToInt32(dtProduct.Rows[i]["PRICE"]) * ctrl.ItemQty;
                totalPay += Convert.ToInt32(Convert.ToSingle(dtProduct.Rows[i]["PRICE"]) * (1-Convert.ToSingle(dtProduct.Rows[i]["DISCOUNT_RATE"]))) * ctrl.ItemQty; //(1.0 * value.ProductPrice * (1 - value.DiscountRate))
                ctrl.ToTalPrice();

                //ctrl.ShowProduct += ShowProductDetail;
                splitContainer1.Panel2.Controls.Add(ctrl);

            }
            lblTotalPrice.Text = $"{totalPrice.ToString("#,##0")} 원";
            lblDiscountPrice.Text = $"{(totalPrice - totalPay).ToString("#,##0")} 원";
            lblPay.Text = $"{totalPay.ToString("#,##0")} 원";
            lblAccumulatedPoint.Text = $"{((totalPay * 1.0) * 0.01).ToString()} 점";
        }

        private void ShowAddress()
        {
            
            //ADDRESS_NUMBER, CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, BASE_ADDRESS
            DataRow[] rows = dtAllAddressList.Select("BASE_ADDRESS='Y'");
            if (rows.Length < 1) return;
            ucZipCode.AddressNumber = Convert.ToInt32(rows[0]["ADDRESS_NUMBER"]);
            ucZipCode.AddressName = rows[0]["ADDRESS_NAME"].ToString();
            ucZipCode.ZipCode = rows[0]["ZIP_CODE"].ToString();
            ucZipCode.Address1 = rows[0]["ADDRESS1"].ToString();
            ucZipCode.Address2 = rows[0]["ADDRESS2"].ToString();

            cboAddress.SelectedIndex = cboAddress.FindString(ucZipCode.AddressName);
        }

        private void lblDiscountPrice_Click(object sender, EventArgs e)
        {

        }

        private void cboAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] rows = dtAllAddressList.Select($"ADDRESS_NUMBER={cboAddress.SelectedValue}");

            ucZipCode.AddressNumber = Convert.ToInt32(rows[0]["ADDRESS_NUMBER"]);
            ucZipCode.AddressName = rows[0]["ADDRESS_NAME"].ToString();
            ucZipCode.ZipCode = rows[0]["ZIP_CODE"].ToString();
            ucZipCode.Address1 = rows[0]["ADDRESS1"].ToString();
            ucZipCode.Address2 = rows[0]["ADDRESS2"].ToString();

        }

        private void btnUsePoint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ntbPoint.Text)) return;
            if (int.Parse(ntbPoint.Text) > currentCustomer.Point)
            {
                MessageBox.Show("보유 포인트보다 더 많은 포인트를 입력할 수 없습니다.");
                ntbPoint.Focus();
                return;
            }
            int discountPrice = int.Parse(lblDiscountPrice.Text.Replace(",", "").Replace("원", "")) + int.Parse(ntbPoint.Text);
            lblPay.Text = (int.Parse(lblPay.Text.Replace(",", "").Replace("원", "")) - discountPrice).ToString("#,##0") + " 원";
            lblDiscountPrice.Text = discountPrice.ToString("#,##0") + " 원";
            bPoint = true;
        }

        private void ntbPoint_TextChanged(object sender, EventArgs e)
        {
            if (bPoint == true && Convert.ToInt32(ntbPoint.Text) > 0)
                bPoint = false;
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            frmAddress frm = new frmAddress(currentCustomer.ID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AddressDAC ad = new AddressDAC();
                dtAllAddressList = ad.GetAddress(currentCustomer.ID);

                CommonUtil.ComboBinding(cboAddress, dtAllAddressList, "ADDRESS_NAME", "ADDRESS_NUMBER");
                ShowAddress();
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if(! bPoint)
            {
                sb.AppendLine("포인트 사용 버튼을 눌러주세요.");
            }

            if(string.IsNullOrWhiteSpace(cboAddress.SelectedValue.ToString()))
            {
                sb.AppendLine("주소를 선택해주세요.");
            }
            else if (string.IsNullOrWhiteSpace(ucZipCode.ZipCode) || string.IsNullOrWhiteSpace(ucZipCode.Address1))
            {
                sb.AppendLine("주소를 입력하세요.");
            }
            else if (string.IsNullOrWhiteSpace(ucZipCode.Address2))
            {
                sb.AppendLine("상세 주소를 입력하세요.");
            }

            if(sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            bool isInsert = false;
            OrderDAC dac = new OrderDAC();
            if (dtProduct.Columns.Contains("SHOPPING_CART_ID"))
                isInsert = dac.Insert(currentCustomer, Convert.ToInt32(cboAddress.SelectedValue), Convert.ToInt32(lblPay.Text.Replace("원","").Replace(",", "").Trim()), Convert.ToInt32(ntbPoint.Text), dtProduct);
            else
                isInsert = dac.Insert(currentCustomer, Convert.ToInt32(cboAddress.SelectedValue), Convert.ToInt32(lblPay.Text.Replace("원", "").Replace(",", "").Trim()), quantity, Convert.ToInt32(ntbPoint.Text), dtProduct);

            if(isInsert)
            {
                MessageBox.Show("주문이 완료되었습니다.");
<<<<<<< HEAD
                this.Dispose();
                this.Close();
=======

                foreach (System.Windows.Forms.Form TheForm in this.MdiChildren)
                {
                    TheForm.Dispose();
                }

                this.Dispose();
                this.Close();
                
>>>>>>> a1f384a (COMMIT 1)
            }
            else
            {
                MessageBox.Show("주문 중 오류가 발생되었습니다.");
            }

        }
    }
}
