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

    public delegate void FormCloseEventHandler(object sender, FormCloseEventArgs e);
    public partial class frmQandADetail : Form
    {
        public event FormCloseEventHandler CloseForm;

        //string brandID;
        //QandA QandADetail;
        int productCode;
        OpenMode open;
        DataTable dtProduct, dtQA;
        public QandA QandADetail
        {
         
            //CONTACT_NUMBER, CUSTOMER_ID, PRODUCT_CODE, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, REGIST_DATETIME, ANSWER, ANSWER_DATETIME 
            get
            {

                //return QandADetail;
                QandA qa = new QandA();
                if (string.IsNullOrWhiteSpace(txtTitle.Text)) return qa;
                qa.ContactNumber = Convert.ToInt32(lblContactNumber.Text);
                qa.CustomerID = lblCustomerID.Text;
                qa.Title = txtTitle.Text;
                qa.Contents = txtContents.Text;
                qa.RegistDateTime = Convert.ToDateTime(lblRegistDateTime.Text);
                qa.AnswerDateTime = Convert.ToDateTime(lblAnswerDateTime.Text);
                qa.Answer = txtAnswer.Text;
                qa.BrandID = lblBrandID.Text;
                qa.ProductCode = Convert.ToInt32(cboProduct.SelectedValue);
                qa.Hits = Convert.ToInt32(lblHits.Text);
                if(cboInquiryType.SelectedValue != null)
                    qa.QuestionType = cboInquiryType.SelectedValue.ToString();
                qa.Secret = chkSecret.Checked;

                return qa;
            }
            set
            {
                lblContactNumber.Text = value.ContactNumber.ToString();
                lblCustomerID.Text = value.CustomerID;
                txtTitle.Text = value.Title;
                txtContents.Text = value.Contents;
                lblRegistDateTime.Text = value.RegistDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                lblAnswerDateTime.Text = value.AnswerDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                txtAnswer.Text = value.Answer;
                lblBrandID.Text = value.BrandID;
                if (value.ProductCode > 0)
                    cboProduct.SelectedIndex = cboProduct.FindString(value.ProductCode.ToString());
                else if (productCode > 0)
                    cboProduct.SelectedIndex = cboProduct.FindString(productCode.ToString());
                else
                    cboProduct.SelectedIndex = cboProduct.FindString("선택");

                lblHits.Text = value.Hits.ToString();
                if(! string.IsNullOrWhiteSpace(value.QuestionType))
                    cboInquiryType.SelectedIndex = cboInquiryType.FindString(value.QuestionType.ToString());
                chkSecret.Checked = value.Secret;

            }
        }
        public string[] UploadImgPaths
        {
            get
            {
                string[] ImgPaths = new string[lstPicture.Items.Count];
                for (int i = 0; i < lstPicture.Items.Count; i++)
                {
                    ImgPaths[i] = CommonUtil.GetImagePath(lstPicture.Items[i].ToString(), DateTime.Now.ToString("yyyyMMddHHmmssfff"), "QandA", QandADetail.BrandID);
                }
                return ImgPaths;
            }
            //set
            //{
            //    string[] ImgPaths = new string[lstPicture.Items.Count];
            //    for (int i = 0; i < lstPicture.Items.Count; i++)
            //    {
            //        ImgPaths[i] = CommonUtil.GetImagePath(lstPicture.Items[i].ToString(), DateTime.Now.ToString("yyyyMMddHHmmssfff"), "QandA", QandADetail.BrandID);
            //    }
                //return ImgPaths;
            //}
        }

        public frmQandADetail(OpenMode open, QandA qa, DataTable dtQA)
        {
            InitializeComponent();

            //dac에서 product랑 common 코드 가져오기
            ProductDAC dac = new ProductDAC();
            DataSet ds = dac.GetProductControl(qa.ProductCode, qa.ProductName);
            ComboBoxBinding(ds.Tables["product"], ds.Tables["common_code"]);
            cboProduct.SelectedIndex = cboProduct.FindString(qa.ProductCode.ToString());

            //brandID = ds.Tables["product"].Rows[0]["BRAND_ID"].ToString();
            //DefaultSet(ds.Tables["product"]);
            this.QandADetail = qa;
            this.open = open;
            this.dtQA = dtQA;
        }

        public frmQandADetail(OpenMode open, DataTable dtProduct, DataTable dtCommon, int productCode) //문의하기 새로만들때만
        {
            InitializeComponent();

            ComboBoxBinding(dtProduct, dtCommon);
            cboProduct.SelectedIndex = cboProduct.FindString(productCode.ToString());
            //brandID = dtProduct.Rows[0]["BRAND_ID"].ToString();
            this.dtProduct = dtProduct;
            this.productCode = productCode;
            this.open = open;
            //this.dtQA = dtQA;
        }

        private void DefaultSet(DataTable dtProduct)
        {

            //CustomerID, BrandID, ProductCode, ProductName, QuestionType 
            //CONTACT_NUMBER, CUSTOMER_ID, PRODUCT_CODE, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, REGIST_DATETIME, ANSWER, ANSWER_DATETIME
            QandADetail = new QandA() { 
                CustomerID = ((frmMain)this.Owner).CurrentCustomer.ID,
                BrandID = dtProduct.Rows[0]["BRAND_ID"].ToString(),
                ProductCode = productCode,
                ProductName = dtProduct.Rows[0]["PRODUCT_NAME"].ToString()
            };

            lblCustomerID.Text = ((frmMain)this.Owner).CurrentCustomer.ID;
            lblBrandID.Text = dtProduct.Rows[0]["BRAND_ID"].ToString();
            QandADetail.ProductCode = productCode; //Convert.ToInt32(dtProduct.Rows[0]["PRODUCT_CODE"]);
            QandADetail.ProductName = dtProduct.Rows[0]["PRODUCT_NAME"].ToString();
            
        }

        private void ComboBoxBinding(DataTable dtProduct, DataTable dtCommon)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CCODE");
            dt.Columns.Add("CNAME");

            //var dict = new List<string>();
            foreach (DataRow row in dtProduct.Rows)
            {
                string color = dtCommon.Select($"CCODE='{row["COLOR"]}'")[0]["CNAME"].ToString();
                string size = dtCommon.Select($"CCODE='{row["SIZE"]}'")[0]["CNAME"].ToString();
                string name = $"{row["PRODUCT_CODE"]} / {row["PRODUCT_NAME"]}({row["BRAND_ID"]}) / {color}({row["COLOR"]}) / {size}({row["SIZE"]})";
                //dict.Add();
                DataRow dr = dt.NewRow();
                dr["CCODE"] = row["PRODUCT_CODE"];
                dr["CNAME"] = name;
                dt.Rows.Add(dr);

            }
            DataRow dr0 = dt.NewRow();
            dr0["CCODE"] = 0;
            dr0["CNAME"] = "선택";
            dt.Rows.InsertAt(dr0,0);
            dt.AcceptChanges();

            DataView dv = new DataView(dt);
            cboProduct.DisplayMember = "CNAME";
            cboProduct.ValueMember = "CCODE";
            cboProduct.DataSource = dv;
            //CommonUtil.ComboBinding(cboProduct, dtProduct, $"{dtProduct.Columns["PRODUCT_CODE"].}", "PRODUCT_CODE");
        }

        private void frmQandADetail_Load(object sender, EventArgs e)
        {
            if(QandADetail.ProductCode < 1)
                DefaultSet(dtProduct);

            //cboProduct.SelectedIndex = cboProduct.FindString(QandADetail.ProductCode.ToString());

            if (((frmMain)this.Owner).CurrentBrand != null)
            {
                //splitContainer1.Panel1.Enabled = false;
                //splitContainer1.Panel2.Enabled = true;
                //txtStudentID.Enabled = true;
                //this.Text = "학생정보등록";
                cboProduct.Enabled = false;
                cboInquiryType.Enabled = false;
                txtAnswer.ReadOnly = false;
                txtContents.ReadOnly = true;
                //txtImgPath.Enabled = false;
                txtTitle.ReadOnly = true;
            }
            else if (((frmMain)this.Owner).CurrentCustomer != null)
            {
                //splitContainer1.Panel1.Enabled = true;
                //splitContainer1.Panel2.Enabled = false;
                //txtStudentID.Enabled = false;
                //this.Text = "학생정보수정";
                cboProduct.Enabled = true;
                cboInquiryType.Enabled = true;
                txtAnswer.ReadOnly = true;
                txtContents.ReadOnly = false;
                //txtImgPath.Enabled = true;
                //txtImgPath.ReadOnly = true;
                txtTitle.ReadOnly = false;
            }
            else
            {
                cboProduct.Enabled = false;
                cboInquiryType.Enabled = false;
                txtAnswer.ReadOnly = true;
                txtContents.ReadOnly = true;
                //txtImgPath.Enabled = false;
                //txtImgPath.ReadOnly = true;
                txtTitle.ReadOnly = true;
                //MessageBox.Show("로그인한 사용자에게만 제공하는 기능입니다.");
                //this.Close();
            }

            if (open == OpenMode.Insert)
            {
                pnlContactNumber.Visible = false;
                pnlAnswerTime.Visible = false;
                pnlRegistTime.Visible = false;
            }
            else
            {
                pnlContactNumber.Visible = true;
                pnlAnswerTime.Visible = true;
                pnlRegistTime.Visible = true;
            }

            if (open == OpenMode.Insert || ((frmMain)this.Owner).CurrentBrand != null)
            {
                btnOK.Text = "등록";
                btnImgUpload.Enabled = true;
            }
            else if (((frmMain)this.Owner).CurrentCustomer != null && lblCustomerID.Text != ((frmMain)this.Owner).CurrentCustomer.ID && string.IsNullOrWhiteSpace(txtAnswer.Text))
            {
                btnOK.Text = "수정";
                btnImgUpload.Enabled = true;
            }
            else
            {
                btnOK.Text = "확인";
                btnImgUpload.Enabled = false;
            }
            //p.PRODUCT_CODE, PRODUCT_NAME, PRICE, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV

            //상품코드, 사이즈, 색상, 제품명, 문의유형
            string[] category = { "문의유형" };

            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCodes(category);
            CommonUtil.ComboBinding(cboInquiryType, dt, "문의유형");
            
            if (! string.IsNullOrWhiteSpace(QandADetail.QuestionType))
            {
                DataRow[] dr = dt.Select($"CCODE='{QandADetail.QuestionType.ToString()}'");
                cboInquiryType.SelectedIndex = cboInquiryType.FindString(dr[0]["CNAME"].ToString());
            }
            else
            {
                cboInquiryType.SelectedIndex = cboInquiryType.FindString("선택");
            }

            if (open == OpenMode.Update)
            {
                for (int i=0; i< dtQA.Rows.Count; i++)
                {
                    lstPicture.Items.Add(dtQA.Rows[i]["SERVER_PATH"].ToString());
                }
            }
        }

        private void btnImgUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images File(*.gif;*.jpg;*.jpeg;*.png;*.bmp)|*.gif;*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                txtImgPath.Text = dlg.FileName; //전체경로

                lstPicture.Items.Add(dlg.FileName);
                
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (((frmMain)this.Owner).CurrentCustomer == null && ((frmMain)this.Owner).CurrentBrand == null)
            {
                this.Dispose();
                //this.DialogResult = DialogResult.Cancel;
                //if (CloseForm != null)
                //{
                //    FormCloseEventArgs args = new FormCloseEventArgs();
                //    args.ThisForm = this;
                //    CloseForm(null, args);
                //}
                return;
                //frmQandADetail_FormClosing(null, null);
                //Application.Exit();
                //this.Dispose();
                //this.Close();
            }

            if (((frmMain)this.Owner).CurrentCustomer != null && lblCustomerID.Text != ((frmMain)this.Owner).CurrentCustomer.ID)
            {
                this.Dispose();

                return;
            }
            if (((frmMain)this.Owner).CurrentBrand != null && lblBrandID.Text != ((frmMain)this.Owner).CurrentBrand.ID)
            {
                this.Dispose();

                return;
            }

            //if (open == OpenMode.Update)
            //{
            //    if (((frmMain)this.Owner).CurrentCustomer != null && lblCustomerID.Text != ((frmMain)this.Owner).CurrentCustomer.ID)
            //    {
            //        MessageBox.Show("글 작성자만 수정 가능합니다.");
            //        return;
            //    }
            //    if (((frmMain)this.Owner).CurrentBrand != null && lblBrandID.Text != ((frmMain)this.Owner).CurrentBrand.ID)
            //    {
            //        MessageBox.Show("문의 제품의 브랜드만 답변 가능합니다.");
            //        return;
            //    }
            //}

            StringBuilder sb = new StringBuilder();
            if (((frmMain)this.Owner).CurrentCustomer != null)
            {
                if(cboInquiryType.SelectedIndex < 1)
                {
                    sb.AppendLine("문의 유형을 선택해주세요.");
                }
                if(cboProduct.SelectedIndex < 1)
                {
                    sb.AppendLine("문의 상품을 선택해주세요.");
                }
                if(txtTitle.Text.Trim().Length < 1)
                {
                    sb.AppendLine("제목을 입력해주세요.");
                }
                if (txtContents.Text.Trim().Length < 1)
                {
                    sb.AppendLine("문의 내용을 입력해주세요.");
                }

                if(sb.Length > 0)
                {
                    MessageBox.Show(sb.ToString());
                    return;
                }
            }
            else if (((frmMain)this.Owner).CurrentBrand != null)
            {
                if (txtAnswer.Text.Trim().Length < 1)
                {
                    sb.AppendLine("답변 내용을 입력해주세요.");
                }

                if (sb.Length > 0)
                {
                    MessageBox.Show(sb.ToString());
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void lstPicture_DoubleClick(object sender, EventArgs e)
        {
            frmPicture frm = new frmPicture(lstPicture.SelectedItem.ToString());
            frm.Show();
        }
    }
    public class FormCloseEventArgs : EventArgs
    {
        public Form ThisForm { get; set; }
    }
}
