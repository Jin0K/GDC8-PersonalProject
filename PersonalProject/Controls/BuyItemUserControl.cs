using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace PersonalProject
{
    public partial class BuyItemUserControl : UserControl
    {
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
                lblQty.Text = value.ToString() +" 개"; 
            }
        }

        public BuyItemUserControl()
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
                if (lblPrice.Text != "가격" && lblQty.Text != "수량") 
                    lblTotalPrice.Text = (int.Parse(lblDiscountPrice.Text.Replace(",","").Replace("원","").Trim()) * int.Parse(lblQty.Text.Replace("개", "").Trim())).ToString("#,##0")+" 원"; 
            //}
        }

        //public void Strike()
        //{

        //    Font font = lblPrice.Font;
        //    font.Strikeout = true;
        //}
    }

}
