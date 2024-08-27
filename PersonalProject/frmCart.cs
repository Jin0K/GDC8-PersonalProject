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
    public partial class frmCart : Form
    {
        DataTable dtAllCart;
        public frmCart(string customerID)
        {
            InitializeComponent();

            ShoppingCartDAC dac = new ShoppingCartDAC();
            dtAllCart = dac.GetCart(customerID);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //frmPay pay = new frmPay();
            //pay.Show();
        }

        private void frmCart_Load(object sender, EventArgs e)
        {
            ShowCartList();
        }

        public void ShowCartList()
        {
            splitContainer1.Panel1.Controls.Clear();

            int totalPrice = 0, totalPay = 0;
            for (int i = 0; i < dtAllCart.Rows.Count; i++)
            {
                CartUserControl ctrl = new CartUserControl();
                ctrl.Name = $"CartItem{i}";
                ctrl.Location = new Point(30, 20 + (90 * i));
                ctrl.Size = new Size(915, 85);
                //DataRow[] drColor = dsProduct.Tables["common_code"].Select($"CCODE='{dtAllCart.Rows[i]["COLOR"]}'");
                //DataRow[] drSize = dsProduct.Tables["common_code"].Select($"CCODE='{dtAllCart.Rows[i]["SIZE"]}'");
                ctrl.CartItem = new ShoppingCart()
                {
                    //SHOPPING_CART_ID, CUSTOMER_ID, PRODUCT_CODE, QUANTITY, INCLUDED_DATE, ORDER_CHECK
                    CartID = Convert.ToInt32(dtAllCart.Rows[i]["SHOPPING_CART_ID"]),
                    ProductCode = Convert.ToInt32(dtAllCart.Rows[i]["PRODUCT_CODE"]),
                    Quantity = Convert.ToInt32(dtAllCart.Rows[i]["QUANTITY"]),
                    CustomerID = ((frmMain)this.MdiParent).CurrentCustomer.ID,
                    IncludedDate = Convert.ToDateTime(dtAllCart.Rows[i]["INCLUDED_DATE"])
                    //OrderCheck = Convert.ToBoolean(dtAllCart.Rows[i]["ORDER_CHECK"])
                };
                ctrl.ProductItem = new Product()
                {
                    //p.PRODUCT_CODE, PRODUCT_NAME, PRICE, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV
                    ProductCode = Convert.ToInt32(dtAllCart.Rows[i]["PRODUCT_CODE"]),
                    ProductName = dtAllCart.Rows[i]["PRODUCT_NAME"].ToString(),
                    ProductPrice = Convert.ToInt32(dtAllCart.Rows[i]["PRICE"]),
                    MainImgPath = dtAllCart.Rows[i]["PRODUCT_IMG"].ToString(),
                    //MainImgPath = mainImgs[idx]["SERVER_PATH"].ToString()
                    //MainImgPath = dtProduct.Rows[i]["SERVER_PATH"].ToString(),
                    DiscountRate = Convert.ToSingle(dtAllCart.Rows[i]["DISCOUNT_RATE"]),
                    Inventory = Convert.ToInt32(dtAllCart.Rows[i]["INVENTORY"]),
                    BrandID = dtAllCart.Rows[i]["BRAND_ID"].ToString(),
                    MainCategory = dtAllCart.Rows[i]["MAIN_CATEGORY"].ToString(),
                    MiddleCategory = dtAllCart.Rows[i]["MIDDLE_CATEGORY"].ToString(),
                    SubCategory = dtAllCart.Rows[i]["SUB_CATEGORY"].ToString(),
                    Color = dtAllCart.Rows[i]["COLOR"].ToString(),
                    Size = dtAllCart.Rows[i]["SIZE"].ToString(),
                    ColorText = dtAllCart.Rows[i]["COLOR_NAME"].ToString(),
                    SizeText = dtAllCart.Rows[i]["SIZE_NAME"].ToString()
                };
                ctrl.ItemQty = Convert.ToInt32(dtAllCart.Rows[i]["QUANTITY"]);
                totalPrice += Convert.ToInt32(dtAllCart.Rows[i]["PRICE"]) * ctrl.ItemQty;
                totalPay += Convert.ToInt32(Convert.ToSingle(dtAllCart.Rows[i]["PRICE"]) * (1 - Convert.ToSingle(dtAllCart.Rows[i]["DISCOUNT_RATE"]))) * ctrl.ItemQty; //(1.0 * value.ProductPrice * (1 - value.DiscountRate))
                ctrl.ToTalPrice();

                ctrl.DelCartItem += Ctrl_DelCartItem;
                ctrl.UpdateQty += Ctrl_UpdateQty;
                splitContainer1.Panel1.Controls.Add(ctrl);

            }
            //lblTotalPrice.Text = $"{totalPrice.ToString("#,##0")} 원";
            //lblDiscountPrice.Text = $"{(totalPrice - totalPay).ToString("#,##0")} 원";
            lblPay.Text = totalPay.ToString("#,##0");
            //lblAccumulatedPoint.Text = $"{((totalPay * 1.0) * 0.01).ToString()} 점";
        }

        private void Ctrl_UpdateQty(object sender, CartItemQtyEventArgs e)
        {
            int productCode = e.ProductCode;
            DataRow[] rows = dtAllCart.Select("PRODUCT_CODE=" + productCode);
            if (rows.Length > 0)
            {
                ShoppingCartDAC dac = new ShoppingCartDAC();
                if (dac.UpdateQty(Convert.ToInt32(rows[0]["SHOPPING_CART_ID"]), e.Qty) > 0)
                {
                    int price = Convert.ToInt32(rows[0]["PRICE"]); // Convert.ToInt32(rows[0]["Pqty"]); //단가
                    rows[0]["QUANTITY"] = e.Qty;
                    //rows[0]["Pprice"] = e.Qty * price;
                    lblPay.Text = (Convert.ToInt32(Convert.ToSingle(rows[0]["PRICE"]) * (1 - Convert.ToSingle(rows[0]["DISCOUNT_RATE"]))) * e.Qty).ToString("#,##0"); //(1.0 * value.ProductPrice * (1 - value.DiscountRate))

                    dtAllCart.AcceptChanges();

                }
                else
                {
                    MessageBox.Show("수량 변경 중 오류가 발생하였습니다.");
                }
                ShowCartList();
            }
        }

        private void Ctrl_DelCartItem(object sender, CartItemEventArgs e)
        {
            int delPID = e.ProductCode;
            DataRow[] rows = dtAllCart.Select("PRODUCT_CODE=" + delPID);
            if (rows.Length > 0)
            {
                ShoppingCartDAC dac = new ShoppingCartDAC();
                if (dac.Delete(Convert.ToInt32(rows[0]["SHOPPING_CART_ID"])) > 0)
                {
                    dtAllCart.Rows.Remove(rows[0]);
                    dtAllCart.AcceptChanges();
                }
                dac.Dispose();
                ShowCartList();
            }
        }


        private void btnChecked_Click(object sender, EventArgs e)
        {
            foreach (CartUserControl item in splitContainer1.Panel1.Controls)
            {
                if(btnChecked.Text == "전체 선택")
                    item.IsChecked = true;
                else if(btnChecked.Text == "전체 선택 해제")
                    item.IsChecked = false;
            }

            if (btnChecked.Text == "전체 선택")
                btnChecked.Text = "전체 선택 해제";
            else if (btnChecked.Text == "전체 선택 해제")
                btnChecked.Text = "전체 선택";
        }

        private void btnCheckedDelete_Click(object sender, EventArgs e)
        {
            ShoppingCartDAC dac = new ShoppingCartDAC();

            foreach (CartUserControl item in splitContainer1.Panel1.Controls)
            {
                if (item.IsChecked)
                {
                    DataRow[] rows = dtAllCart.Select("SHOPPING_CART_ID=" + item.CartItem.CartID);
                    if (rows.Length > 0)
                    {
                        if (dac.Delete(Convert.ToInt32(rows[0]["SHOPPING_CART_ID"])) > 0)
                            dtAllCart.Rows.Remove(rows[0]);
                    }
                }
            }
            dac.Dispose();
            dtAllCart.AcceptChanges();
            ShowCartList();
        }

        private void btnCheckedBuy_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dtAllCart.Clone();
            int i = 0;
            foreach (CartUserControl item in splitContainer1.Panel1.Controls)
            {
                if (item.IsChecked)
                {
                    if (item.CartItem.CartID == Convert.ToInt32(dtAllCart.Rows[i]["SHOPPING_CART_ID"]))
                    {
                        if(Convert.ToInt32(dtAllCart.Rows[i]["INVENTORY"]) >= Convert.ToInt32(dtAllCart.Rows[i]["QUANTITY"]))
                            dt.ImportRow(dtAllCart.Rows[i]);
                        else if(Convert.ToInt32(dtAllCart.Rows[i]["INVENTORY"]) > 0)
                        {
                            MessageBox.Show($"재고 수량보다 주문 수량이 더 많습니다. \r\n{dtAllCart.Rows[i]["PRODUCT_NAME"]}(브랜드 : {dtAllCart.Rows[i]["BRAND_NAME"]}) 상품의 선택 옵션 재고 : {Convert.ToInt32(dtAllCart.Rows[i]["INVENTORY"])}");
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"{dtAllCart.Rows[i]["PRODUCT_NAME"]}(브랜드 : {dtAllCart.Rows[i]["BRAND_NAME"]}) 상품의 해당 옵션은 품절 상태입니다.");
                            return;
                        }
                    }
                    else
<<<<<<< HEAD
                        MessageBox.Show("장바구니 물품 구매 중 오류가 발생하였습니다.");
                    //DataRow[] rows = dtAllCart.Select("SHOPPING_CART_ID=" + item.CartItem.CartID);
                    //if (rows.Length > 0)
                    //{
                        
=======
                    {
                        MessageBox.Show("장바구니 물품 구매 중 오류가 발생하였습니다.");
                        //this.Dispose();
                        //this.Close();
                    }
                    //DataRow[] rows = dtAllCart.Select("SHOPPING_CART_ID=" + item.CartItem.CartID);
                    //if (rows.Length > 0)
                    //{

>>>>>>> a1f384a (COMMIT 1)
                    //}
                }
                i++;
            }

            frmPay frm = new frmPay(((frmMain)this.MdiParent).CurrentCustomer, dt);
            frm.Show();
<<<<<<< HEAD
=======
            frm.Dispose();
            frm.Close();

>>>>>>> a1f384a (COMMIT 1)
        }
    }
}
