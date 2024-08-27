using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalProject
{
    
    public partial class frmProductRegist : Form
    {
        DataTable dtAllCategory;
        int idx = 0, pctName = 0;
        //public Product ProductInfo 
        //{
        //    get
        //    {

        //    }
        //    set; 
        //}
        //public Brand BrandInfo { get; set; }

        //public QuantityPerOption QtyPerOption
        //{
        //    get
        //    {

        //        string[] options = new string[lstOption.Items.Count];
        //        for (int i = 0; i < lstOption.Items.Count; i++)
        //        {
        //            //{cboColor.SelectedValue} / {cboSize.SelectedValue} / {nudQty.Value}
        //            string[] arr = lstOptionValue.Items[i].ToString().Split('/');
        //            options[i] = arr[0].Trim();
        //        }
        //        return options;
        //    }


        //}

        public frmProductRegist()
        {
            InitializeComponent();
        }

        private void frmProductRegist_Load(object sender, EventArgs e)
        {
            string[] category = { "MAIN_TYPE", "MIDDLE_TYPE", "SUB_TYPE", "색상", "사이즈", "IMG_TYPE" };

            CommonDAC dac = new CommonDAC();
            dtAllCategory = dac.GetCommonCodes(category);

            CommonUtil.ComboBinding(cboImgDiv, dtAllCategory, "IMG_TYPE");
            CommonUtil.ComboBinding(cboColor, dtAllCategory, "색상");
            CommonUtil.ComboBinding(cboSize, dtAllCategory, "사이즈");
            CommonUtil.MenuBinding(dtAllCategory, cboMainCategory, "MAIN_TYPE", null, display:"선택");

            Debug.WriteLine(this.MdiParent);
            Debug.WriteLine(this.Owner);

            lblBrand.Text = ((frmMain)this.MdiParent).CurrentBrand.Name;

        }

        private void cboMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = string.Empty;
            
            if (cboMainCategory.SelectedIndex > 0)
                temp = cboMainCategory.SelectedValue.ToString();
            
            if (cboMainCategory.SelectedIndex < 1 || string.IsNullOrWhiteSpace(cboMainCategory.SelectedValue.ToString()))
                cboMidCategory.DataSource = null;
            else
                CommonUtil.MenuBinding(dtAllCategory, cboMidCategory, "MIDDLE_TYPE", cboMainCategory.SelectedValue.ToString(), display: "선택");

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
                CommonUtil.MenuBinding(dtAllCategory, cboSubCategory, "SUB_TYPE", cboMidCategory.SelectedValue.ToString(), display: "선택");

            if (temp.Length > 0)
            {
                DataRow[] rows = dtAllCategory.Select($"CCODE='{temp}'");
                cboMidCategory.SelectedIndex = cboMidCategory.FindStringExact(rows[0]["CNAME"].ToString());
            }


        }

        private void btnImgUpload_Click(object sender, EventArgs e)
        {
            if (e.ToString().StartsWith("-")) return;

            if (string.IsNullOrWhiteSpace(cboExistColor.SelectedValue.ToString()))
            {
                MessageBox.Show("옵션별 수량과 업로드 이미지의 제품 색상을 선택하고 이미지를 추가해주세요.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cboImgDiv.SelectedValue.ToString()))
            {
                MessageBox.Show("이미지 분류를 선택해주세요.");
                return;
            }

            if (cboImgDiv.SelectedValue.ToString() == "I001" && pctMainImg.ImageLocation != null)
            {
                MessageBox.Show("메인 이미지는 하나만 등록하실 수 있습니다.");
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images File(*.gif;*.jpg;*.jpeg;*.png;*.bmp)|*.gif;*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                
                if (cboImgDiv.SelectedValue.ToString() == "I001")
                {                  

                    txtImgPath.Text = dlg.FileName; //전체경로
                    //pctMainImg.Image = Image.FromFile(dlg.FileName);
                    pctMainImg.ImageLocation = dlg.FileName;
                    pctMainImg.SizeMode = PictureBoxSizeMode.Zoom;
                    pctMainImg.BackColor = Color.White;

                    //lstPicture.Items.Add($"{cboImgDiv.SelectedValue}/{cboExistColor.SelectedValue}/{pctMainImg.Name}");
                }
                
                //panel2.Controls.Clear();

                    
                PictureBox item = new PictureBox();
                item.Name = $"picture{pctName}";                
                item.Size = new Size(97, 90);
                item.Location = new Point((idx * 100), 0); //97, 90
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                //item.Image = Image.FromFile(dlg.FileName);
                item.ImageLocation = dlg.FileName;
                item.SizeMode = PictureBoxSizeMode.Zoom;
                item.BackColor = Color.White;

                pnlSubImages.Controls.Add(item);
                pnlSubImages.Refresh();
                pnlSubImages.Update();

                txtImgPath.Text = dlg.FileName; //전체경로

                lstPicture.Items.Add($"{cboImgDiv.SelectedValue}/{cboExistColor.SelectedValue}/{pnlSubImages.Controls[idx].Name}");
                lstPictureText.Items.Add($"{cboImgDiv.Text}/{cboExistColor.Text}/{pnlSubImages.Controls[idx].Name}");

                idx++;
                pctName++;
            }
        }


        private void txtDiscountPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice == null || txtDiscountPrice.Text.Length < 1) return;

            txtDiscountRate.Text = ((1.0 - double.Parse(txtDiscountPrice.Text.Replace(",", "")) /double.Parse(txtPrice.Text.Replace(",", "")))*100).ToString("##0.##");
            txtDiscountPrice.Text = string.Format(txtDiscountPrice.Text, "#,##0");
        }


        private void txtDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txtDiscountRate_Leave(object sender, EventArgs e)
        {
            if (txtPrice != null && txtDiscountRate.Text.Length > 0) 
                txtDiscountPrice.Text = ((int)(double.Parse(txtPrice.Text.Replace(",", "")) * (1.0 - double.Parse(txtDiscountRate.Text) * 0.01))).ToString("#,##0");

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboColor.SelectedValue == null)
            {
                MessageBox.Show("색상을 선택해주세요.");
                return;
            }

            if (cboSize.SelectedValue == null)
            {
                MessageBox.Show("사이즈를 선택해주세요.");
                return;
            }
            if (nudQty.Value == 0)
            {
                MessageBox.Show("수량은 0이상으로 설정해주세요.");
                return;
            }
            Debug.WriteLine(cboColor.Text);
            Debug.WriteLine(cboColor.SelectedText);
            Debug.WriteLine(cboColor.SelectedValue);
            Debug.WriteLine(cboSize.SelectedText);
            Debug.WriteLine(cboSize.SelectedValue);

            for (int i = 0; i < lstOptionValue.Items.Count; i++)
            {
                if (lstOptionValue.Items[i].ToString().Contains($"{cboColor.SelectedValue}/{cboSize.SelectedValue}"))
                {
                    MessageBox.Show("중복된 항목이 존재합니다.");
                    return;
                }
            }

            //if (lstOptionValue.Items.Contains($"{cboColor.SelectedValue}/{cboSize.SelectedValue}"))
            //    MessageBox.Show("중복된 항목이 존재합니다.");

            lstOption.Items.Add($"{cboColor.Text} / {cboSize.Text} / {nudQty.Value}");
            lstOptionValue.Items.Add($"{cboColor.SelectedValue}/{cboSize.SelectedValue}/{nudQty.Value}");
            ExistsColor();
            //lstOption.Items.Add($"{cboColor.Text} : {cboColor.SelectedValue} / {cboSize.Text} : {cboSize.SelectedValue} / {nudQty.Value}");
        }

        private void ExistsColor()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CCODE");
            dt.Columns.Add("CNAME");

            DataRow dr1 = dt.NewRow();
            dr1["CCODE"] = "";
            dr1["CNAME"] = "선택";
            dt.Rows.InsertAt(dr1, 0);

            for (int i = 0; i < lstOptionValue.Items.Count; i++)
            {
                bool bCheck = false;
                string[] arrText = lstOption.Items[i].ToString().Split('/');
                string colorsText = arrText[0].Trim();

                string[] arrValue = lstOptionValue.Items[i].ToString().Split('/');
                string colorsCode = arrValue[0].Trim();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["CCODE"].ToString() == colorsCode)
                    {
                        bCheck = true;
                        break;
                    }
                }
                if (bCheck) continue;

                DataRow dr = dt.NewRow();
                dr["CCODE"] = colorsCode;
                dr["CNAME"] = colorsText;
                dt.Rows.Add(dr);
            }

            dt.AcceptChanges();

            DataView dv = new DataView(dt);
            cboExistColor.DisplayMember = "CNAME";
            cboExistColor.ValueMember = "CCODE";
            cboExistColor.DataSource = dv;
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (cboSubCategory.SelectedIndex < 1 || cboMidCategory.SelectedIndex < 1 || cboMainCategory.SelectedIndex < 1)
                sb.AppendLine("카테고리를 전부 선택해주세요.");

            if (txtPrice.Text.Length < 1)
                sb.AppendLine("가격을 입력해주세요.");

            if (lstOptionValue.Items.Count < 0)
                sb.AppendLine("옵션별 수량을 추가해주세요.");

            if (txtProductDescription.Text.Trim().Length < 0)
                sb.AppendLine("제품 설명을 입력해주세요.");

            if (pctMainImg.ImageLocation == null)
                sb.AppendLine("메인 이미지를 등록해주세요.");

            ProductDAC dac = new ProductDAC();
            if (! dac.IsVaildName(txtProductName.Text,lblBrand.Text))
                sb.AppendLine("브랜드 내 동일한 제품명이 존재합니다.");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            //ProductCode, ProductName, ProductPrice, Inventory, MainCategory, MiddleCategory, SubCategory, DiscountRate, RegistDateTime, BrandID, MainImgPath 

            Product prod = new Product();
            prod.ProductName = txtProductName.Text.Trim();
            prod.ProductPrice = int.Parse(txtPrice.Text.Replace(",",""));
            prod.MainCategory = cboMainCategory.SelectedValue.ToString();
            prod.MiddleCategory = cboMidCategory.SelectedValue.ToString();
            prod.SubCategory = cboSubCategory.SelectedValue.ToString();
            if(! string.IsNullOrWhiteSpace(txtDiscountRate.Text))
                prod.DiscountRate = float.Parse(txtDiscountRate.Text)/100;
            
            prod.BrandID = lblBrand.Text;
            //prod.MainImgPath = pctMainImg.ImageLocation;
            prod.Description = txtProductDescription.Text;
            //prod.DiscountRate = doutxtDiscountRate.Text

            QuantityPerOption[] qpos = new QuantityPerOption[lstOption.Items.Count];
            for(int i = 0; i < lstOption.Items.Count; i++)
            {
                QuantityPerOption qpo = new QuantityPerOption();
                string[] arr = lstOptionValue.Items[i].ToString().Split('/');
                qpo.Color = arr[0].Trim();
                qpo.Size = arr[1].Trim();
                qpo.Quantity = int.Parse(arr[2].Trim());

                qpos[i] = qpo;
            }

            ImagePerOption[] ipos = new ImagePerOption[lstPicture.Items.Count];
            for (int i = 0; i < lstPicture.Items.Count; i++)
            {
                ImagePerOption ipo = new ImagePerOption();
                string[] arr = lstPicture.Items[i].ToString().Split('/');
                ipo.ImgDiv = arr[0].Trim();
                ipo.Color = arr[1].Trim();

                Control[] ctrls = pnlSubImages.Controls.Find(arr[2], false);
                PictureBox pb = (PictureBox)ctrls[0];

                ipo.Path = pb.ImageLocation; 
                //CommonUtil.GetImagePath(pb.ImageLocation,

                ipos[i] = ipo;
            }

            if(dac.Insert(prod, qpos, ipos))
            {
                MessageBox.Show("상품 등록이 완료되었습니다.");
                pnlSubImages.Controls.Clear();
                pnlSubImages.Refresh();
                pctMainImg.ImageLocation = null;
                txtDiscountPrice.Clear();
                txtDiscountRate.Clear();
                txtImgPath.Clear();
                txtPrice.Clear();
                txtProductDescription.Clear();
                txtProductName.Clear();
                lstOption.Items.Clear();
                lstOptionValue.Items.Clear();
                lstPicture.Items.Clear();
                lstPictureText.Items.Clear();
                nudQty.Value = 0;
                cboColor.SelectedIndex = cboExistColor.SelectedIndex = cboImgDiv.SelectedIndex = cboMainCategory.SelectedIndex = cboMidCategory.SelectedIndex = cboSize.SelectedIndex = cboSubCategory.SelectedIndex = 0;

            }    
            else
            {
                MessageBox.Show("상품 등록 중 오류가 발생하였습니다.");
            }
        }

        private void txtDiscountPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ',')
                e.Handled = true;
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice.Text.Length > 0)
            {
                int temp = int.Parse(txtPrice.Text.Replace(",",""));
                txtPrice.Text = temp.ToString("#,##0"); 
                

                //string temp = string.Format("{0:#,##0}", txtPrice.Text);
                //txtPrice.Text = temp;
                //temp = string.Format("{0:C0}", txtPrice.Text);
                //txtPrice.Text = temp;
                //int temp = int.Parse(txtPrice.Text);
                //txtPrice.Text = temp.ToString("#,##0");
            }

        }

        private void btnDeleteOption_Click(object sender, EventArgs e)
        {
            if (lstOption.SelectedIndex < 0)
            {
                MessageBox.Show("삭제할 목록을 선택해주세요.");
                return;
            }

            int sindex = lstOption.SelectedIndex;
            lstOption.Items.RemoveAt(sindex);
            lstOptionValue.Items.RemoveAt(sindex);
            ExistsColor();

        }

        private void lstPicture_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            if (lstPictureText.SelectedIndex < 0)
            {
                MessageBox.Show("삭제할 목록을 선택해주세요.");
                return;
            }

            string[] arr = lstPicture.Items[lstPictureText.SelectedIndex].ToString().Split('/');
            string imgDiv = arr[0].Trim();
            string pctName = arr[2].Trim();

            if(imgDiv == "I001")
            {
                pctMainImg.ImageLocation = null; //Nothing
                pctMainImg.BackColor = Color.White;
            }
            
                Control[] ctrls = pnlSubImages.Controls.Find(pctName, false);
                PictureBox pb = (PictureBox)ctrls[0];

                if (pnlSubImages.Controls.Contains(pb))
                {
                    //this.pb.Click -= new System.EventHandler(this.NewPanelButton_Click);
                    pnlSubImages.Controls.Remove(pb);
                    pb.Dispose();
                }

                idx--;

                foreach(PictureBox picture in pnlSubImages.Controls)
                {
                    picture.Location = new Point((idx * 100), 0);
                }
            

            //int sindex = lstOption.SelectedIndex;
            lstPicture.Items.RemoveAt(lstPictureText.SelectedIndex);
            lstPictureText.Items.RemoveAt(lstPictureText.SelectedIndex);
            //lstOptionValue.Items.RemoveAt(sindex);
            //ExistsColor();
        }

        private void lstPictureText_Click(object sender, EventArgs e)
        {
            pctMainImg.BackColor = Color.White;
            foreach (PictureBox picture in pnlSubImages.Controls)
            {
                picture.BackColor = Color.White;
            }

            if (lstPictureText.SelectedItems.Count > 0)
            {
                string[] arr = lstPicture.Items[lstPictureText.SelectedIndex].ToString().Split('/');
                string imgDiv = arr[0].Trim();
                //string colorText = arrText[1].Trim();
                string pctName = arr[2].Trim();

                if (imgDiv == "I001")
                {
                    pctMainImg.BackColor = Color.Yellow;
                    pctMainImg.Focus();
                }
                
                    Control[] ctrls = pnlSubImages.Controls.Find(pctName, false);
                    PictureBox pb = (PictureBox)ctrls[0];

                    pb.BackColor = Color.Yellow;
                    pb.Focus();
                
            }

        }

        private void lstPicture_Click(object sender, EventArgs e)
        {
            pctMainImg.BackColor = Color.White;
            foreach (PictureBox picture in pnlSubImages.Controls)
            {
                picture.BackColor = Color.White;
            }

            if (lstPicture.SelectedItems.Count > 0)
            {
                string[] arr = lstPicture.Items[lstPicture.SelectedIndex].ToString().Split('/');
                string imgDiv = arr[0].Trim();
                //string colorText = arrText[1].Trim();
                string pctName = arr[2].Trim();

                if (imgDiv == "I001")
                {
                    pctMainImg.BackColor = Color.Yellow;
                    pctMainImg.Focus();
                }
                else
                {
                    Control[] ctrls = pnlSubImages.Controls.Find(pctName, false);
                    PictureBox pb = (PictureBox)ctrls[0];

                    pb.BackColor = Color.Yellow;
                    pb.Focus();
                }
            }
        }
    }
<<<<<<< HEAD
    public class QuantityPerOption
    {
        public int Code { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
    public class ImagePerOption
    {
        public string ImgDiv { get; set; }
        public string Color { get; set; }
        public string Path { get; set; }
    }
=======
    
>>>>>>> a1f384a (COMMIT 1)

}
