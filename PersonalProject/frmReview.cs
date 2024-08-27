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
    public partial class frmReview : Form
    {
        DataTable dtAllReviews;
        
        public frmReview()
        {
            InitializeComponent();
<<<<<<< HEAD
=======

>>>>>>> a1f384a (COMMIT 1)
        }

        private void frmReview_Load(object sender, EventArgs e)
        {
            
            //rv.REVIEW_NUMBER, od.ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, rv.REGIST_DATETIME, DELETED, c.CUSTOMER_ID, CUSTOMER_NAME, p.PRODUCT_CODE, PRODUCT_NAME, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, b.BRAND_ID, BRAND_NAME, PRODUCT_IMG_CODE, SERVER_PATH

            //CONTACT_NUMBER, CUSTOMER_ID, p.PRODUCT_CODE, PRODUCT_NAME, BRAND_ID, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, qa.REGIST_DATETIME, ANSWER, ANSWER_DATETIME 
            DataGridViewUtil.SetInitGridView(gudiDataGridview1);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "글번호", "REVIEW_NUMBER", DataGridViewContentAlignment.MiddleCenter, colWidth: 80); //0
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "유형", "QUESTION_TYPE", DataGridViewContentAlignment.MiddleCenter, visibility: false); //1
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제목", "TITLE", colWidth: 400); //2
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "작성자", "CUSTOMER_ID"); //3
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "조회수", "HITS", DataGridViewContentAlignment.MiddleRight, visibility: false); //4
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            //특정 동일한 이미지를 보여줄때
            //img.Image = Image.FromFile(@"C:\Users\stonegram\Downloads\image\image\20191024114946.jpg");
            //DataSource의 특정컬럼으로 데이터바인딩을 할때
            //1. BLOB이미지를 데이터바인딩 (DataPropertyName 속성만 정의해주면 된다)
            //img.DataPropertyName = "productImage"; 
            //2. 이미지경로를 데이터바인딩 (CellFormatting 이벤트에 코딩해야 한다)
            img.Name = "SECRET";
            img.HeaderText = "비밀글";
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;
            img.Image = null;
            img.DefaultCellStyle.NullValue = null;
            img.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.Width = 80;
            img.ReadOnly = true;
            img.DataPropertyName = "SECRET";
            img.Visible = false;
            //gudiDataGridview1["SECRET", e.RowIndex]
            //img.Image = Image.FromFile()
            gudiDataGridview1.Columns.Add(img); //5
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "작성일시", "REGIST_DATETIME", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제품코드", "PRODUCT_CODE", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제품명", "PRODUCT_NAME", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "내용", "CONTENTS", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "답변", "ANSWER", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "답변일시", "ANSWER_DATETIME", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "브랜드", "BRAND_ID", visibility: false);

            LoadData();

            ReviewDAC dac = new ReviewDAC();
            DataTable dt = dac.IsNotUpload(((frmMain)this.MdiParent).CurrentCustomer.ID);

            ShowOrderReviewList(dt);
        }

        private void LoadData()
        {
            //rv.REVIEW_NUMBER, od.ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, rv.REGIST_DATETIME, DELETED, c.CUSTOMER_ID, CUSTOMER_NAME, p.PRODUCT_CODE, PRODUCT_NAME, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, b.BRAND_ID, BRAND_NAME, PRODUCT_IMG_CODE, SERVER_PATH
            ReviewDAC dac = new ReviewDAC();
            dtAllReviews = dac.GetReviews();

            DataView dv = new DataView(dtAllReviews);
            DataTable dt = dv.ToTable(true, new string[] { "REVIEW_NUMBER", "ORDER_DETAIL_CODE", "TITLE", "CONTENTS", "SCORE", "REGIST_DATETIME", "DELETED", "CUSTOMER_ID", "CUSTOMER_NAME", "PRODUCT_CODE", "PRODUCT_NAME", "SIZE", "SIZE_NAME", "COLOR", "COLOR_NAME", "BRAND_ID", "BRAND_NAME" });

            //기본설정 : 바인딩되는 DataSource의 컬럼그대로 컬럼이 생성되면서 바인딩
            gudiDataGridview1.DataSource = dt;
            gudiDataGridview1.ClearSelection();
        }
        public void ShowOrderReviewList(DataTable dt)
        {
            splitContainer2.Panel2.Controls.Clear();

            int totalPrice = 0, totalPay = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OrderDetailUserControl ctrl = new OrderDetailUserControl();
                ctrl.Name = $"OrderReviewItem{i}";
                ctrl.Location = new Point(15, 10 + (140 * i));
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
                splitContainer2.Panel2.Controls.Add(ctrl);

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
            //frm.MdiParent = this.MdiParent;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show("후기가 등록되었습니다.");
                LoadData();

                ReviewDAC dac = new ReviewDAC();
                DataTable dt = dac.IsNotUpload(((frmMain)this.MdiParent).CurrentCustomer.ID);

                ShowOrderReviewList(dt);
            }
        }

        private void gudiDataGridview1_DoubleClick(object sender, EventArgs e)
        {
            //rv.REVIEW_NUMBER, od.ORDER_DETAIL_CODE, TITLE, CONTENTS, SCORE, rv.REGIST_DATETIME, DELETED, c.CUSTOMER_ID, CUSTOMER_NAME, p.PRODUCT_CODE, PRODUCT_NAME, SIZE, sz.CNAME SIZE_NAME, COLOR, cl.CNAME COLOR_NAME, b.BRAND_ID, BRAND_NAME, PRODUCT_IMG_CODE, SERVER_PATH

            DataView dv = new DataView(dtAllReviews);
            dv.RowFilter = $"REVIEW_NUMBER={Convert.ToInt32(gudiDataGridview1["REVIEW_NUMBER", gudiDataGridview1.CurrentRow.Index].Value)}";

            

            frmReviewIns frm = new frmReviewIns(OpenMode.Update, dv.ToTable());
            //frm.MdiParent = this.MdiParent;
            //frm.Show();

            //QandA qa = DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, e.RowIndex);
  
            //frmQandADetail frm = new frmQandADetail(OpenMode.Update, qa, dv.ToTable());
            //frm.CloseForm += Frm_CloseForm;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {    
                LoadData();
                MessageBox.Show("후기가 수정되었습니다.");   
            }
            //else
            //{
            //    MessageBox.Show("후기 수정 중 오류가 발생하였습니다.");
            //}


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtAllReviews);
            dv.RowFilter = $"REVIEW_NUMBER={Convert.ToInt32(gudiDataGridview1["REVIEW_NUMBER", gudiDataGridview1.CurrentRow.Index].Value)}";

            frmReviewIns frm = new frmReviewIns(OpenMode.Update, dv.ToTable());
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
                MessageBox.Show("후기가 수정되었습니다.");
            }
            //else
            //{
            //    MessageBox.Show("후기 수정 중 오류가 발생하였습니다.");
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
            if (gudiDataGridview1["CUSTOMER_ID", gudiDataGridview1.CurrentRow.Index].Value.ToString() != ((frmMain)this.MdiParent).CurrentCustomer.ID)
            {
                MessageBox.Show("다른 사용자의 후기는 삭제할 수 없습니다.");
                return;

            }

>>>>>>> a1f384a (COMMIT 1)
            int reviewNum = Convert.ToInt32(gudiDataGridview1["REVIEW_NUMBER", gudiDataGridview1.CurrentRow.Index].Value);
            DialogResult result = MessageBox.Show($"글번호 : {reviewNum.ToString()} 후기를 삭제하시겠습니까?", "후기 삭제", MessageBoxButtons.YesNoCancel);

            if(result == DialogResult.Yes)
            {
                ReviewDAC dac = new ReviewDAC();
                int iResult = dac.Delete(reviewNum);
                //dac.Dispose();

                if (iResult > 0)
                {
                    LoadData();
                    MessageBox.Show("후기가 삭제되었습니다.");
                }
            }
        }
    }
}
