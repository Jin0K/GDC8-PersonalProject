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
    public partial class frmProduct : Form
    {
        DataTable dtAllCategory;
        DataTable dtAllProduct;
        DataTable dtCurFilter;
        //public Product ProductInfo 
        //{ 
        //    get
        //    {
        //        ProductInfo = new Product()
        //        {
        //            //p.PRODUCT_CODE, PRODUCT_NAME, PRICE, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV
        //            ProductCode = Convert.ToInt32(dt.Rows[idx]["PRODUCT_CODE"]),
        //            ProductName = dt.Rows[idx]["PRODUCT_NAME"].ToString(),
        //            ProductPrice = Convert.ToInt32(dt.Rows[idx]["PRICE"]),
        //            //MainImgPath = mainImgs[idx]["SERVER_PATH"].ToString()
        //            MainImgPath = dt.Rows[idx]["SERVER_PATH"].ToString(),
        //            DiscountRate = Convert.ToDouble(dt.Rows[idx]["DISCOUNT_RATE"]),
        //            TotalInventory = Convert.ToInt32(dt.Rows[idx]["sum(INVENTORY)"])
        //        }
        //        return ProductInfo;
        //    }
        //    set; 
        //}
        public frmProduct()
        {
            InitializeComponent();
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {
            //select BRAND_ID, BRAND_NAME, LOGO_IMG_PATH from brand
            BrandDAC bd = new BrandDAC();
            DataTable dtBrand = bd.GetBrand();
            CommonUtil.ComboBinding(cboBrand, dtBrand, "BRAND_NAME", "BRAND_ID", blankText:"전체",isStringValue:true);

            string[] category = { "MAIN_TYPE", "MIDDLE_TYPE", "SUB_TYPE" };
            
            CommonDAC dac = new CommonDAC();
            dtAllCategory = dac.GetCommonCodes(category);

            ////DataTable에 Row를 추가하는 방법
            //DataRow dr = dtAllCategory.NewRow();
            //dr["CCODE"] = "";
            //dr["CNAME"] = "전체";
            //dtAllCategory.Rows.InsertAt(dr, 0);
            //dtAllCategory.AcceptChanges(); //datatable의 변경내역을 반영 commit

            bindingSource1.DataSource = dtAllCategory;
            CommonUtil.MenuBinding(dtAllCategory, cboMainCategory, "MAIN_TYPE", null);
            //cboMainCategory.DisplayMember = "CNAME";
            //cboMainCategory.ValueMember = "CCODE";
            //bindingSource1.Filter = "PCODE IS NULL";
            //cboMainCategory.DataBindings.Add("SelectedText", bindingSource1, "CNAME");

            //cboMidCategory.DisplayMember = "CNAME";
            //cboMidCategory.ValueMember = "CCODE";
            //bindingSource1.Filter = $"PCODE='{cboMainCategory.SelectedValue}'";
            //cboMidCategory.DataBindings.Add("SelectedText", bindingSource1, "CNAME");

            //cboSubCategory.DisplayMember = "CNAME";
            //cboSubCategory.ValueMember = "CCODE";
            //bindingSource1.Filter = $"PCODE='{cboMainCategory.SelectedValue}'";
            //cboSubCategory.DataBindings.Add("SelectedText", bindingSource1, "CNAME");

            ProductDAC pd = new ProductDAC();
<<<<<<< HEAD
            dtAllProduct = pd.GetProductList();
=======
            dtAllProduct = pd.GetProductAllTable(); //GetProductList
>>>>>>> a1f384a (COMMIT 1)
            ShowProductList(dtAllProduct);
            dtCurFilter = dtAllProduct.Copy();

            CommonUtil.SetTreeView(trvMenu, dtAllCategory);
            //trvMenu.EndUpdate();
            trvMenu.ExpandAll();
            trvMenu.SelectedNode = trvMenu.Nodes[0];

            //for (int i = 0; i < 13; i++)
            //{ 
            //    if(i == 0)
            //    {
            //        cboMonth.Items.Add("선택");
            //        continue;
            //    }
            //    cboMonth.Items.Add(i); 
            //}
            //cboMonth.SelectedIndex = 0;
        }


        private void ShowProductList(DataTable dt)
        {
            splitContainer2.Panel2.Controls.Clear();
            //DataTable Row수를 2로 나눈 몫의 올림
            int iCol = (splitContainer2.Panel2.Width - 60) / 205;
            int iRows = (int)Math.Ceiling(dt.Rows.Count / (iCol*1.0));
            int idx = 0;
            for (int r = 0; r < iRows; r++)
            {
                for (int i = 0; i < iCol; i++)
                {
                    if (idx >= dt.Rows.Count) break;

                    //DataRow[] mainImgs = dt.Select("IMG_DIV = 'I001'");

                    ProductItemUserControl ctrl = new ProductItemUserControl();
                    ctrl.Location = new Point(20 + (205 * i), 16 + (340 * r)); //197, 338
                    ctrl.Size = new Size(197, 338);
                    ctrl.ProductItem = new Product()
                    {
                        //p.PRODUCT_CODE, PRODUCT_NAME, PRICE, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV
                        //ProductCode = Convert.ToInt32(dt.Rows[idx]["PRODUCT_CODE"]),
                        ProductName = dt.Rows[idx]["PRODUCT_NAME"].ToString(),
                        ProductPrice = Convert.ToInt32(dt.Rows[idx]["PRICE"]),
                        //MainImgPath = mainImgs[idx]["SERVER_PATH"].ToString()
                        MainImgPath = dt.Rows[idx]["SERVER_PATH"].ToString(),
                        DiscountRate = Convert.ToSingle(dt.Rows[idx]["DISCOUNT_RATE"]),
                        TotalInventory = Convert.ToInt32(dt.Rows[idx]["SUM_INVENTORY"]),
                        BrandID = dt.Rows[idx]["BRAND_ID"].ToString(),
                        MainCategory = dt.Rows[idx]["MAIN_CATEGORY"].ToString(),
                        MiddleCategory = dt.Rows[idx]["MIDDLE_CATEGORY"].ToString(),
                        SubCategory = dt.Rows[idx]["SUB_CATEGORY"].ToString()
                    };
                    if (dt.Rows[idx]["AVG_SCORE"] == DBNull.Value)
                        ctrl.AvgScore = 0;
                    else
                        ctrl.AvgScore = Convert.ToSingle(dt.Rows[idx]["AVG_SCORE"]);
                    if (dt.Rows[idx]["COUNT_REVIEW"] == DBNull.Value)
                        ctrl.Count = 0;
                    else
                        ctrl.Count = Convert.ToInt32(dt.Rows[idx]["COUNT_REVIEW"]);
                    ctrl.ShowProduct += ShowProductDetail;
                    splitContainer2.Panel2.Controls.Add(ctrl);
                    idx++;
                }
            }
        }

        private void ShowProductDetail(object sender, ProductItemEventArgs e)
        {
            frmProductDetail fd = new frmProductDetail(e.BrandID, e.ProductName);
            fd.MdiParent = this.MdiParent;
            fd.Show();
        }

        private void cboMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = string.Empty;
            Debug.WriteLine("SelectedText"+cboMainCategory.SelectedText);
            if (cboMainCategory.SelectedIndex > 0)
                temp = cboMainCategory.SelectedValue.ToString();
            //Debug.WriteLine(cboMainCategory.SelectedValue.ToString());
            //Debug.WriteLine(cboMainCategory.SelectedText.ToString());
            if (cboMainCategory.SelectedIndex < 1 ||string.IsNullOrWhiteSpace(cboMainCategory.SelectedValue.ToString()))
                cboMidCategory.DataSource = null;
            else
                CommonUtil.MenuBinding(dtAllCategory, cboMidCategory, "MIDDLE_TYPE", cboMainCategory.SelectedValue.ToString());

            if (temp.Length > 0)
            {
                DataRow[] rows = dtAllCategory.Select($"CCODE='{temp}'");
                cboMainCategory.SelectedIndex = cboMainCategory.FindStringExact(rows[0]["CNAME"].ToString());
            }

        }

        private void cboMidCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = string.Empty;
            if (cboMidCategory.SelectedIndex > 0)
                temp = cboMidCategory.SelectedValue.ToString();

            if (cboMidCategory.SelectedIndex < 1 || string.IsNullOrWhiteSpace(cboMidCategory.SelectedValue.ToString()))
                cboSubCategory.DataSource = null;
            else
                CommonUtil.MenuBinding(dtAllCategory, cboSubCategory, "SUB_TYPE", cboMidCategory.SelectedValue.ToString());

            if (temp.Length > 0)
            {
                DataRow[] rows = dtAllCategory.Select($"CCODE='{temp}'");
                cboMidCategory.SelectedIndex = cboMidCategory.FindStringExact(rows[0]["CNAME"].ToString());
            }


            //if (cboMidCategory.SelectedValue.ToString().Length > 0)
            //{
            //CommonUtil.MSubtypeDataBinding(dtAllCategory, cboSubCategory, "SUB_TYPE", cboMidCategory.SelectedValue.ToString());
            //}
            //else
            //{
            //    //cboSType.Items.Clear(); DataSource 존재시 불가/오류남
            //    cboMidCategory.DataSource = null;
            //}
        }

        private void frmProduct_ResizeEnd(object sender, EventArgs e)
        {
            ShowProductList(dtCurFilter);
        }

        private void llbProductName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabelSort(llbProductName, dtCurFilter, "PRODUCT_NAME");
        }

        private void LinkLabelSort(LinkLabel linkLabel,DataTable dt, string sortColumn)
        {
            splitContainer2.Panel2.Controls.Clear();

            DataView dv = new DataView(dt);


            if (linkLabel.Text.Contains("▲"))
            {
                linkLabel.Text = linkLabel.Text.Replace("▲", "") + "▼";
                dv.Sort = $"{sortColumn} desc";
            }
            else if (linkLabel.Text.Contains("▼"))
            {
                linkLabel.Text = linkLabel.Text.Replace("▼", "") + "▲";
                dv.Sort = $"{sortColumn} asc";
            }
            else
            {
                PnlSortLinkLabelReset();
                linkLabel.Text = linkLabel.Text + "▲";
                dv.Sort = $"{sortColumn} asc";
            }


            linkLabel.LinkColor = Color.Blue;
            dtCurFilter = dv.ToTable();
            ShowProductList(dtCurFilter);
        }

        private void llbPrice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabelSort(llbPrice, dtCurFilter, "PRICE");
        }

        private void llbRegist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabelSort(llbRegist, dtCurFilter, "REGIST_DATETIME");
        }

        private void llbSale_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabelSort(llbSale, dtCurFilter, "DISCOUNT_RATE");
        }


        private void lblSales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabelSort(lblSales, dtCurFilter, "SALES");
        }

        private void trvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(e.Node.Name))
            {
                cboMainCategory.SelectedIndex = 0;
                cboMidCategory.SelectedIndex = cboSubCategory.SelectedIndex = -1;

                dtCurFilter = dtAllProduct.Copy();
                ShowProductList(dtCurFilter);
                return;
            }
            //if (cboSubCategory.SelectedIndex < 0) return;
            Debug.WriteLine(cboMainCategory.SelectedIndex);
            Debug.WriteLine(cboMidCategory.SelectedIndex);
            Debug.WriteLine(cboSubCategory.SelectedIndex);

            cboMainCategory.SelectedIndex = 0;
            cboMidCategory.SelectedIndex = cboSubCategory.SelectedIndex = -1;
            //MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY
            DataView dv = new DataView(dtAllProduct);
            if (int.Parse(e.Node.Name.Replace("T", "")) % 100 == 0)
            {

                cboMainCategory.SelectedIndex = cboMainCategory.FindStringExact(e.Node.Text);

                cboMidCategory.SelectedIndex = 0;
                cboSubCategory.SelectedIndex = -1;
                dv.RowFilter = $"MAIN_CATEGORY='{e.Node.Name}'";

            }
            else if (int.Parse(e.Node.Name.Replace("T", "")) % 10 == 0)
            {
                
                DataRow[] dr = dtAllCategory.Select($"CCODE='{e.Node.Tag}'");
                cboMainCategory.SelectedIndex = cboMainCategory.FindStringExact(dr[0]["CNAME"].ToString());

                cboMidCategory.SelectedIndex = cboMidCategory.FindStringExact(e.Node.Text);

                cboSubCategory.SelectedIndex = 0;
                //DataRow dr = dtAllCategory.Rows.Find(e.Node.Tag);
                //cboMainCategory.SelectedIndex = cboMainCategory.FindStringExact(dr["CCNAME"].ToString());
                dv.RowFilter = $"MIDDLE_CATEGORY='{e.Node.Name}'";

            }
            else
            {

                DataRow[] dr = dtAllCategory.Select($"CCODE='{e.Node.Tag}'");
                DataRow[] dr1 = dtAllCategory.Select($"CCODE='{dr[0]["PCODE"].ToString()}'");
                cboMainCategory.SelectedIndex = cboMainCategory.FindStringExact(dr1[0]["CNAME"].ToString());

                cboMidCategory.SelectedIndex = cboMidCategory.FindStringExact(dr[0]["CNAME"].ToString());

                cboSubCategory.SelectedIndex = cboSubCategory.FindStringExact(e.Node.Text);

                //DataRow dr1 = dtAllCategory.Rows.Find(dr["PCODE"].ToString());
                //cboMainCategory.SelectedIndex = cboMainCategory.FindStringExact(dr["CCNAME"].ToString());
                dv.RowFilter = $"SUB_CATEGORY='{e.Node.Name}'";

            }
            dtCurFilter = dv.ToTable();
            ShowProductList(dtCurFilter);


        }

        private void PnlSortLinkLabelReset()
        {
            foreach(LinkLabel linkLabel in pnlSort.Controls)
            {
                linkLabel.Text = linkLabel.Text.Replace("▲", "").Replace("▼", "");
                linkLabel.LinkColor = Color.Black;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();

            DataView dv = new DataView(dtCurFilter);
            //string keyword = txtKeyword.Text;

            //StringBuilder filter = new StringBuilder();
            
            //if (txtKeyword.Text.Contains(" "))
            //{
            //    string[] keywords = txtKeyword.Text.Split(' ');

            //    for(int i=0;i<keywords.Length;i++)
            //    {
            //        if (filter.Length > 0) filter.Append("%");

            //        if (!(string.IsNullOrEmpty(keywords[i])))
            //            filter.Append(keywords[i]);
            //    }

            //    //keyword = string.Join("%", keywords);
            //}
            //else
            //{
            //    filter.Append(txtKeyword.Text);
            //}
            //filter.Insert(0, "PRODUCT_NAME like '%");
            //filter.Append("%'");
            dv.RowFilter = $"PRODUCT_NAME like '%{txtKeyword.Text}%'";
            dtCurFilter = dv.ToTable();
            ShowProductList(dtCurFilter);
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtKeyword.Text.Length > 0 && e.KeyChar == 13)
                btnSearch.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtAllProduct);
            //dv.RowFilter = " (REGIST_DATETIME >= #" + ucPeriod.From.ToString("MM/dd/yyyy") + "# And REGIST_DATETIME <= #" + ucPeriod.To.AddDays(1).ToString("MM/dd/yyyy") + "# ) ";
            //MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME
            StringBuilder sb = new StringBuilder();
            string and = " and ";
            if(! string.IsNullOrWhiteSpace(cboBrand.SelectedValue.ToString()))
                sb.Append($" BRAND_ID='{cboBrand.SelectedValue}'");
            if (! string.IsNullOrWhiteSpace(cboMainCategory.SelectedValue.ToString()))
            {
                if (sb.ToString().Length > 0) sb.Append(and);
                sb.Append($" MAIN_CATEGORY='{cboMainCategory.SelectedValue}'");
            }
            if (cboMidCategory.SelectedIndex > 0)
            {
                if (sb.ToString().Length > 0) sb.Append(and);
                sb.Append($" MIDDLE_CATEGORY='{cboMidCategory.SelectedValue}'");
            }
            if (! string.IsNullOrWhiteSpace(cboSubCategory.SelectedValue.ToString()))
            {
                if (sb.ToString().Length > 0) sb.Append(and);
                sb.Append($" SUB_CATEGORY='{cboSubCategory.SelectedValue}'");
            }
            dv.RowFilter = sb.ToString();
            dtCurFilter = dv.ToTable();
            ShowProductList(dtCurFilter);
        }

    }
}
