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
    public partial class frmOrderDetail : Form
    {
        public frmOrderDetail(DataTable dtOrder)
        {
            InitializeComponent();

            OrderDetailDAC dac = new OrderDetailDAC();
            //DataTable dt = dac.GetOrderDetails(order.OrderNumber);

            //lblOrderNumber.Text = order.OrderNumber.ToString();
            //lblOrderDateTime.Text = order.OrderDateTime.ToString();
            //lblOrderAmount.Text = order.OrderAmount.ToString("#,##0");

            DataTable dt = dac.GetOrderDetails(Convert.ToInt32(dtOrder.Rows[0]["ORDER_NUMBER"]));

            //ORDER_NUMBER, CUSTOMER_ID, ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, PAYMENT_CHECK

            lblOrderNumber.Text = dtOrder.Rows[0]["ORDER_NUMBER"].ToString();
            lblOrderDateTime.Text = dtOrder.Rows[0]["ORDER_DATETIME"].ToString();
            lblOrderAmount.Text = Convert.ToInt32(dtOrder.Rows[0]["ORDER_AMOUNT"]).ToString("#,##0");
            lblAddressName.Text = dtOrder.Rows[0]["ADDRESS_NAME"].ToString();
            lblZipCode.Text = dtOrder.Rows[0]["ZIP_CODE"].ToString();
            lblAddress1.Text = dtOrder.Rows[0]["ADDRESS1"].ToString();
            lblAddress2.Text = dtOrder.Rows[0]["ADDRESS2"].ToString();
            lblOrderState.Text = dtOrder.Rows[0]["CNAME"].ToString();


            ShowOrderList(dt);
        }

        public void ShowOrderList(DataTable dt)
        {
            splitContainer1.Panel2.Controls.Clear();

            int totalPrice = 0, totalPay = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OrderDetailUserControl ctrl = new OrderDetailUserControl();
                ctrl.Name = $"OrderDetailItem{i}";
                ctrl.Location = new Point(20, 15 + (140 * i));
                ctrl.Size = new Size(915, 135);
                //DataRow[] drColor = dsProduct.Tables["common_code"].Select($"CCODE='{dt.Rows[i]["COLOR"]}'");
                //DataRow[] drSize = dsProduct.Tables["common_code"].Select($"CCODE='{dt.Rows[i]["SIZE"]}'");
                ctrl.ProductItem = new Product()
                {
                    //ORDER_NUMBER, CUSTOMER_ID, ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, PAYMENT_CHECK
                    ProductCode = Convert.ToInt32(dt.Rows[i]["PRODUCT_CODE"]),
                    ProductName = dt.Rows[i]["PRODUCT_NAME"].ToString(),
                    ProductPrice = Convert.ToInt32(dt.Rows[i]["PRICE"]),
                    //MainImgPath = mainImgs[i]["SERVER_PATH"].ToString()
                    MainImgPath = dt.Rows[i]["PRODUCT_IMG"].ToString(),
                    DiscountRate = Convert.ToSingle(dt.Rows[i]["DISCOUNT_RATE"]),
                    //TotalInventory = Convert.ToInt32(dt.Rows[i]["sum(INVENTORY)"]),
                    BrandID = dt.Rows[i]["BRAND_ID"].ToString(),
                    MainCategory = dt.Rows[i]["MAIN_CATEGORY"].ToString(),
                    MiddleCategory = dt.Rows[i]["MIDDLE_CATEGORY"].ToString(),
                    SubCategory = dt.Rows[i]["SUB_CATEGORY"].ToString(),
                    Color = dt.Rows[i]["COLOR"].ToString(),
                    Size = dt.Rows[i]["SIZE"].ToString(),
                    ColorText = dt.Rows[i]["COLOR_NAME"].ToString(),
                    SizeText = dt.Rows[i]["SIZE_NAME"].ToString()
                };
                ctrl.OrderDetailCode = Convert.ToInt32(dt.Rows[i]["ORDER_DETAIL_CODE"]);
                ctrl.ItemQty = Convert.ToInt32(dt.Rows[i]["ORDER_QUANTITY"]);
                totalPrice += Convert.ToInt32(dt.Rows[i]["PRICE"]) * ctrl.ItemQty;
                totalPay += Convert.ToInt32(Convert.ToSingle(dt.Rows[i]["PRICE"]) * (1 - Convert.ToSingle(dt.Rows[i]["DISCOUNT_RATE"]))) * ctrl.ItemQty; //(1.0 * value.ProductPrice * (1 - value.DiscountRate))
                ctrl.ToTalPrice();
                ctrl.ShowReviewList += Ctrl_ShowReviewList;
                splitContainer1.Panel2.Controls.Add(ctrl);

            }
            //lblTotalPrice.Text = $"{totalPrice.ToString("#,##0")} 원";
            //lblDiscountPrice.Text = $"{(totalPrice - totalPay).ToString("#,##0")} 원";
            //lblPay.Text = totalPay.ToString("#,##0");
            //lblAccumulatedPoint.Text = $"{((totalPay * 1.0) * 0.01).ToString()} 점";
        }

        private void Ctrl_ShowReviewList(object sender, EventArgs e)
        {
            OrderDetailUserControl ucOrderDetail = (OrderDetailUserControl)sender;
            //DataView dv = new DataView(dtAllOrder);
            //dv.RowFilter = $"ORDER_NUMBER={ucOrder.OrderMaster.OrderNumber}";
            frmReviewIns frm = new frmReviewIns(OpenMode.Insert, ((frmMain)this.MdiParent).CurrentCustomer.ID, ucOrderDetail.OrderDetailCode, ucOrderDetail.ProductItem);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

    }
}
