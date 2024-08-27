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
    //public delegate void EventHandler(object sender, EventArgs e);
    public partial class OrderDetailUserControl : UserControl
    {
        public event EventHandler ShowReviewList;
        Product orderProduct;
        public Product ProductItem
        {
            get { return orderProduct; }
            set
            {
                if (value == null) return;
                orderProduct = value;
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
            get
            {
                if (lblQty.Text == "수량") return 0;
                return int.Parse(lblQty.Text.Replace("개", "").Trim());
            }
            set
            {
                lblQty.Text = value.ToString() + " 개";
            }
        }

        public int OrderDetailCode { get; set; }

        public OrderDetailUserControl()
        {
            InitializeComponent();
        }

        public void ToTalPrice()
        {
            if (lblPrice.Text != "가격" && lblQty.Text != "수량")
                lblTotalPrice.Text = (int.Parse(lblDiscountPrice.Text.Replace(",", "").Replace("원", "").Trim()) * int.Parse(lblQty.Text.Replace("개", "").Trim())).ToString("#,##0") + " 원";
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            if(ShowReviewList != null)
            {
                ShowReviewList(this, e);
            }
        }
    }
}
