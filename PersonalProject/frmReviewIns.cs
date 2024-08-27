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
    public partial class frmReviewIns : Form
    {
        OpenMode open;
        int uploadedImgs=0, reviewNum;
        public string[] UploadImgPaths
        {
            get
            {
                string[] ImgPaths = new string[lstPicture.Items.Count];
                for (int i = uploadedImgs; i < lstPicture.Items.Count; i++)
                {
                    ImgPaths[i] = CommonUtil.GetImagePath(lstPicture.Items[i].ToString(), DateTime.Now.ToString("yyyyMMddHHmmssfff"), "Review", lblCustomerID.Text);
                }
                return ImgPaths;
            }
        }


        //REVIEW_NUMBER, ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, REGIST_DATETIME, DELETED
        public frmReviewIns(OpenMode open,string cusomerID ,int orderDetailCode, Product product)
        {
            InitializeComponent();

            this.open = open;
            lblProductCode.Text = product.ProductCode.ToString();
            lblProductName.Text = product.ProductName;
            lblOption.Text = $"색상 - {product.ColorText}({product.Color}), 사이즈 - {product.SizeText}({product.Size})";
            lblCustomerID.Text = cusomerID;
            lblOrderDetailCode.Text = orderDetailCode.ToString();

            trackBar1.Value = 5;
        }
<<<<<<< HEAD
=======

>>>>>>> a1f384a (COMMIT 1)
        public frmReviewIns(OpenMode open, DataTable dt)
        {
            InitializeComponent();
            //rv.REVIEW_NUMBER, od.ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, rv.REGIST_DATETIME, DELETED, c.CUSTOMER_ID, CUSTOMER_NAME, p.PRODUCT_CODE, PRODUCT_NAME, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, b.BRAND_ID, BRAND_NAME, PRODUCT_IMG_CODE, SERVER_PATH

            this.open = open;
            lblProductCode.Text = dt.Rows[0]["PRODUCT_CODE"].ToString();
            lblProductName.Text = dt.Rows[0]["PRODUCT_NAME"].ToString();
            lblOption.Text = $"색상 - {dt.Rows[0]["COLOR_NAME"].ToString()}({dt.Rows[0]["COLOR"].ToString()}), 사이즈 - {dt.Rows[0]["SIZE_NAME"].ToString()}({dt.Rows[0]["SIZE"].ToString()})";
            lblCustomerID.Text = dt.Rows[0]["CUSTOMER_ID"].ToString();
            lblOrderDetailCode.Text = dt.Rows[0]["ORDER_DETAIL_CODE"].ToString();
            lblRegistDateTime.Text = dt.Rows[0]["REGIST_DATETIME"].ToString();
            txtTitle.Text = dt.Rows[0]["TITLE"].ToString();
            txtContents.Text = dt.Rows[0]["CONTENTS"].ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstPicture.Items.Add(dt.Rows[i]["SERVER_PATH"].ToString());
            }

            uploadedImgs = dt.Rows.Count;
            reviewNum = Convert.ToInt32(dt.Rows[0]["REVIEW_NUMBER"]);

            trackBar1.Value = Convert.ToInt32(dt.Rows[0]["SCORE"]);
        }

        private void frmReviewIns_Load(object sender, EventArgs e)
        {
            if(open == OpenMode.Insert)
                pnlRegistTime.Visible = false;
            else
                pnlRegistTime.Visible = true;

            lblScore.Text = trackBar1.Value.ToString() + " 점";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblScore.Text = trackBar1.Value.ToString() + " 점";
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

        private void lstPicture_DoubleClick(object sender, EventArgs e)
        {
            frmPicture frm = new frmPicture(lstPicture.SelectedItem.ToString());
            frm.Show();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======

            if (lblCustomerID.Text != this.Owner.Tag.ToString())
            {
                this.Dispose();
                this.Close();
                return;

            }

>>>>>>> a1f384a (COMMIT 1)
            StringBuilder sb = new StringBuilder();
           
            if (txtTitle.Text.Trim().Length < 1)
            {
                sb.AppendLine("제목을 입력해주세요.");
            }
            if (txtContents.Text.Trim().Length < 1)
            {
                sb.AppendLine("후기 내용을 입력해주세요.");
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            
            Review review = new Review()
            {
                //REVIEW_NUMBER, ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, REGIST_DATETIME, DELETED
                ReviewNumber = reviewNum,
                OrderDetailCode = Convert.ToInt32(lblOrderDetailCode.Text),
                Title = txtTitle.Text,
                Contents = txtContents.Text,
                Score = trackBar1.Value,
                RegistDateTime = DateTime.Now,
                CustomerID = lblCustomerID.Text
            };


            ReviewDAC dac = new ReviewDAC();
            List<string> list = new List<string>();

            if (open == OpenMode.Insert)
            {
                //foreach (var item in lstPicture.Items)
                //{
                //    list.Add(item.ToString());
                //}

                if (dac.Insert(review, UploadImgPaths))
                {
                    MessageBox.Show("후기가 등록되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("후기가 등록 중 오류가 발생되었습니다.");
                }
            }
            else if (open == OpenMode.Update)
            {
                //for (int i = uploadedImgs; i < lstPicture.Items.Count; i++)
                //{
                //    list.Add(lstPicture.Items[i].ToString());
                //}
                try
                {
                    if (dac.Update(review, UploadImgPaths))
                    {
<<<<<<< HEAD
                        //MessageBox.Show("후기가 수정되었습니다.");
=======
                        MessageBox.Show("후기가 수정되었습니다.");
>>>>>>> a1f384a (COMMIT 1)
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
<<<<<<< HEAD
                }
                //else
                //{
                //    MessageBox.Show("후기가 수정 중 오류가 발생되었습니다.");
                //}
=======
                    MessageBox.Show("후기가 수정 중 오류가 발생되었습니다.");

                }


>>>>>>> a1f384a (COMMIT 1)
            }

            
        }
    }
}
