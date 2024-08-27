using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalProject
{
    public delegate void ProductItemHandler(object sender, ProductItemEventArgs e);
    public partial class ProductItemUserControl : UserControl
    {
        Product curProduct;

        public event ProductItemHandler ShowProduct;
        public float? AvgScore
        {
            get { return Convert.ToSingle(lblScore.Text.Replace("★","")); }
            set 
            {
                if (value == null)
                    lblScore.Visible = false;
                else
                {
                    lblScore.Visible = true;
                    lblScore.Text = "★" + value.ToString();
                }
            }
        }

        public int Count
        {
            get { return Convert.ToInt32(lblCnt.Text.Replace("명", "")); }
            set
            {
                lblCnt.Text = value.ToString()+"명";
            }
        }

        public Product ProductItem
        {
            //get
            //{

            //    Product prod = new Product();
            //    prod.ProductName = txtProductName.Text.Trim();
            //    prod.ProductPrice = int.Parse(txtPrice.Text.Replace(",", ""));
            //    prod.MainCategory = cboMainCategory.SelectedValue.ToString();
            //    prod.MiddleCategory = cboMidCategory.SelectedValue.ToString();
            //    prod.SubCategory = cboSubCategory.SelectedValue.ToString();
            //    if (!string.IsNullOrWhiteSpace(txtDiscountRate.Text))
            //        prod.DiscountRate = double.Parse(txtDiscountRate.Text);
            //    prod.BrandID = lblBrand.Text;
            //    //prod.MainImgPath = pctMainImg.ImageLocation;
            //    prod.Description = txtProductDescription.Text;

            //    return prod;
            //}
            set
            {
                curProduct = value;
                Debug.WriteLine(curProduct.ProductName);
                Debug.WriteLine(value.ProductName);
                pictureBox1.ImageLocation = value.MainImgPath;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                llbTitle.Text = value.ProductName;
                lblPrice.Text = value.ProductPrice.ToString("#,##0") + " 원";
                lblDiscountRate.Text = (value.DiscountRate*100).ToString("#0.##")+"%";
                lblDiscountPrice.Text = (1.0*value.ProductPrice * (1-value.DiscountRate) ).ToString("#,##0") + " 원";
                if (value.TotalInventory < 1)
                    lblState.Text = "품절";
                else if (value.TotalInventory < 5)
                    lblState.Text = "품절임박";
                else
                    lblState.Text = "";

            }
        }

        public ProductItemUserControl()
        {
            InitializeComponent();
        }

        private void ProductItemUserControl_DoubleClick(object sender, EventArgs e)
        {
            if (ShowProduct != null)
            {
                ProductItemEventArgs args = new ProductItemEventArgs();
                args.BrandID = curProduct.BrandID;
                args.ProductName = curProduct.ProductName;
                ShowProduct(null, args);
            }

            //frmProductDetail fd = new frmProductDetail(curProduct.BrandID, curProduct.ProductName);
            //fd.MdiParent = this.Parent as Form;
            //fd.Show();
        }

        private void llbTitle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ShowProduct != null)
            {
                ProductItemEventArgs args = new ProductItemEventArgs();
                args.BrandID = curProduct.BrandID;
                args.ProductName = curProduct.ProductName;
                ShowProduct(null, args);
            }
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (ShowProduct != null)
            {
                ProductItemEventArgs args = new ProductItemEventArgs();
                args.BrandID = curProduct.BrandID;
                args.ProductName = curProduct.ProductName;
                ShowProduct(null, args);
            }
            //frmProductDetail fd = new frmProductDetail(curProduct.BrandID, curProduct.ProductName);
            //fd.MdiParent = this.Parent as Form;
            //fd.Show();
        }

    }

    public class ProductItemEventArgs : EventArgs
    {
        public string BrandID { get; set; }
        public string ProductName { get; set; }
    }
}
