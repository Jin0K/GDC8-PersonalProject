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
    public delegate void CartItemHandler(object sender, CartItemEventArgs e);
    public delegate void CartItemQtyHandler(object sender, CartItemQtyEventArgs e);

    public partial class CartUserControl : UserControl
    {
        Product curProduct;
        public event CartItemHandler DelCartItem; //삭제버튼을 클릭할때 발생하는 이벤트
        public event CartItemQtyHandler UpdateQty; //수량이 변경될때 발생하는 이벤트
<<<<<<< HEAD
        public ShoppingCart CartItem 
        { 
            get; 
            set; 
        }
=======
       

>>>>>>> a1f384a (COMMIT 1)
        public Product ProductItem
        {
            get { return curProduct; }
            set
            {
                if (value == null) return;
                curProduct = value;
                pctMainImage.ImageLocation = value.MainImgPath;
                pctMainImage.SizeMode = PictureBoxSizeMode.Zoom;
                lblProductCode.Text = value.ProductCode.ToString();
                lblProductName.Text = value.ProductName;
                lblPrice.Text = $"{value.ProductPrice.ToString("#,##0")}";
                lblDiscountRate.Text = $"({(value.DiscountRate * 100).ToString("#0.##")}%↓)";
                lblDiscountPrice.Text = (1.0 * value.ProductPrice * (1 - value.DiscountRate)).ToString("#,##0") + " 원";
                lblOption.Text = $"옵션 : 색상 - {value.ColorText}({value.Color}), 사이즈 - {value.SizeText}({value.Size})";

            }
        }
        public int ItemQty
        {
            get { return (int)numQty.Value; }
            set { numQty.Value = value; }
        }

        public bool IsChecked
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

<<<<<<< HEAD
=======
        public ShoppingCart CartItem { get; internal set; }

>>>>>>> a1f384a (COMMIT 1)
        public CartUserControl()
        {
            InitializeComponent();
        }
        public void ToTalPrice()
        {
            //get 
            //{
            //    if (lblQty.Text == "총 가격") return 0;
            //    return int.Parse(lblTotalPrice.Text.Replace("원","").Trim()); 
            //}
            //set 
            //{
            if (lblPrice.Text != "가격" && ItemQty > 0)
                lblTotalPrice.Text = (int.Parse(lblDiscountPrice.Text.Replace(",", "").Replace("원", "").Trim()) * ItemQty).ToString("#,##0") + " 원";
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DelCartItem != null)
            {
                CartItemEventArgs args = new CartItemEventArgs();
                args.ProductCode = curProduct.ProductCode;
                DelCartItem(this, args);
            }
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateQty != null)
            {
                CartItemQtyEventArgs args = new CartItemQtyEventArgs();
                args.ProductCode = curProduct.ProductCode;
                args.Qty = (int)numQty.Value;

                UpdateQty(this, args);
            }
        }
    }
    public class CartItemEventArgs : EventArgs
    {
        public int ProductCode { get; set; }
    }

    public class CartItemQtyEventArgs : EventArgs
    {
        public int ProductCode { get; set; }
        public int Qty { get; set; }
    }
}
