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
    public partial class frmQandA : Form
    {
        DataTable dtQAs;
        public frmQandA()
        {
            InitializeComponent();
        }

        private void gudiDataGridview1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //CONTACT_NUMBER, CUSTOMER_ID, PRODUCT_CODE, PRODUCT_CODE, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, REGIST_DATETIME, ANSWER, ANSWER_DATETIME
            DataView dv = new DataView(dtQAs);
            dv.RowFilter = $"CONTACT_NUMBER={DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, e.RowIndex).ContactNumber}";

            frmQandADetail frm = new frmQandADetail(OpenMode.Update, DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, e.RowIndex), dv.ToTable());
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                List<string> imgPath = new List<string>();
                DataRow[] rows = dtQAs.Select($"CONTACT_NUMBER={DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, gudiDataGridview1.CurrentRow.Index).ContactNumber}");
                if (rows.Length != frm.UploadImgPaths.Length)
                {
                    for (int i = rows.Length; i < frm.UploadImgPaths.Length; i++)
                    {
                        imgPath.Add(frm.UploadImgPaths[i]);
                    }
                }
                QandADAC dac = new QandADAC();
                bool bResult = dac.Update(frm.QandADetail, imgPath.ToArray());
                //dac.Dispose();

                if (bResult)
                {
                    LoadData();
                    MessageBox.Show("문의가 수정되었습니다.");
                }
            }
        }



        private void frmQandA_Load(object sender, EventArgs e)
        {

            //CONTACT_NUMBER, CUSTOMER_ID, p.PRODUCT_CODE, PRODUCT_NAME, BRAND_ID, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, qa.REGIST_DATETIME, ANSWER, ANSWER_DATETIME 
            DataGridViewUtil.SetInitGridView(gudiDataGridview1);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "글번호", "CONTACT_NUMBER", DataGridViewContentAlignment.MiddleCenter, colWidth: 80); //0
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "문의 유형", "QUESTION_TYPE", DataGridViewContentAlignment.MiddleCenter); //1
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제목", "TITLE", colWidth: 300); //2
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "작성자", "CUSTOMER_ID"); //3
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "조회수", "HITS", DataGridViewContentAlignment.MiddleRight); //4
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
            //gudiDataGridview1["SECRET", e.RowIndex]
            //img.Image = Image.FromFile()
            gudiDataGridview1.Columns.Add(img); //5
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "작성일시", "REGIST_DATETIME", DataGridViewContentAlignment.MiddleRight, colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제품코드", "PRODUCT_CODE", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제품명", "PRODUCT_NAME", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "내용", "CONTENTS", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "답변", "ANSWER", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "답변일시", "ANSWER_DATETIME", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "브랜드", "BRAND_ID", visibility: false);

            LoadData();
        }

        private void LoadData()
        {
            QandADAC dac = new QandADAC();
            dtQAs = dac.GetAllQA();
            DataView dv = new DataView(dtQAs);
            DataTable dt = dv.ToTable(true, new string[] { "CONTACT_NUMBER", "CUSTOMER_ID", "PRODUCT_CODE", "PRODUCT_NAME", "BRAND_ID", "QUESTION_TYPE", "TITLE", "CONTENTS", "SECRET", "HITS", "REGIST_DATETIME", "ANSWER", "ANSWER_DATETIME" });

            //기본설정 : 바인딩되는 DataSource의 컬럼그대로 컬럼이 생성되면서 바인딩
            gudiDataGridview1.DataSource = dt;
            gudiDataGridview1.ClearSelection();
        }

        //private void btnContact_Click(object sender, EventArgs e)
        //{
        //    frmQandADetail frm = new frmQandADetail(OpenMode.Insert);
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        //입력받은 학생정보를 DB에 저장
        //        QandADAC dac = new QandADAC();
        //        int iResult = dac.InsertQuestion(frm.QandADetail);
        //        dac.Dispose();

        //        if (iResult > 0)
        //        {
        //            LoadData();
        //            MessageBox.Show("학생이 추가되었습니다.");
        //        }
        //    }
        //}

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtQAs);
            dv.RowFilter = $"CONTACT_NUMBER={DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, gudiDataGridview1.CurrentRow.Index).ContactNumber}";

            frmQandADetail frm = new frmQandADetail(OpenMode.Update, DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, gudiDataGridview1.CurrentRow.Index), dv.ToTable());
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                List<string> imgPath = new List<string>();
                DataRow[] rows = dtQAs.Select($"CONTACT_NUMBER={DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, gudiDataGridview1.CurrentRow.Index).ContactNumber}");
                if (rows.Length != frm.UploadImgPaths.Length)
                {
                    for (int i = rows.Length; i < frm.UploadImgPaths.Length; i++)
                    {
                        imgPath.Add(frm.UploadImgPaths[i]);
                    }
                }
                QandADAC dac = new QandADAC();
                bool bResult = dac.Update(frm.QandADetail, imgPath.ToArray());
                //dac.Dispose();

                if (bResult)
                {
                    LoadData();
                    MessageBox.Show("문의가 수정되었습니다.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //삭제여부 확인
            int rowIndex = gudiDataGridview1.CurrentRow.Index;
            int contactNum = Convert.ToInt32(gudiDataGridview1["CONTACT_NUMBER", rowIndex].Value);
            string name = gudiDataGridview1["TITLE", rowIndex].Value.ToString();

            if (MessageBox.Show($"{contactNum} : {name} 글을 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                QandADAC dac = new QandADAC();
                int iResult = dac.Delete(contactNum);
                //dac.Dispose();

                if (iResult > 0)
                {
                    LoadData();
                    MessageBox.Show("문의가 삭제되었습니다.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //그리드뷰의 선택된 행(셀)의 값을 읽어서 Student 객체를 만든다.
            int rowIndex = gudiDataGridview1.CurrentRow.Index;
            QandA qa = DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, rowIndex);
            DataView dv = new DataView(dtQAs);
            dv.RowFilter = $"CONTACT_NUMBER={qa.ContactNumber}";

            frmQandADetail frm = new frmQandADetail(OpenMode.Update, qa, dv.ToTable());
            //frm.QandADetail = qa;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                List<string> imgPath = new List<string>();
                DataRow[] rows = dtQAs.Select($"CONTACT_NUMBER={qa.ContactNumber}");
                if (rows.Length != frm.UploadImgPaths.Length)
                {
                    for (int i = rows.Length; i < frm.UploadImgPaths.Length; i++)
                    {
                        imgPath.Add(frm.UploadImgPaths[i]);
                    }
                }
                QandADAC dac = new QandADAC();
                bool bResult = dac.Update(frm.QandADetail, imgPath.ToArray());
                //dac.Dispose();

                if (bResult)
                {
                    LoadData();
                    MessageBox.Show("문의가 수정되었습니다.");
                }
            }
        }

        private void gudiDataGridview1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == gudiDataGridview1.NewRowIndex)
                return;

            if (e.ColumnIndex == 5)
            {
                if (Convert.ToBoolean(gudiDataGridview1["SECRET", e.RowIndex].Value))
                {
                    Image img = Properties.Resources.icons8_lock_24; //Image.FromFile(gudiDataGridview1["ProductImage", e.RowIndex].Value.ToString());
                    e.Value = img;
                }
                else
                {
                    e.Value = null;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtQAs);
            dv.RowFilter = " (REGIST_DATETIME >= #" + ucPeriod.From.ToString("MM/dd/yyyy") + "# And REGIST_DATETIME <= #" + ucPeriod.To.AddDays(1).ToString("MM/dd/yyyy") + "# ) ";
            DataTable dt = dv.ToTable(true, new string[] { "CONTACT_NUMBER", "CUSTOMER_ID", "PRODUCT_CODE", "PRODUCT_NAME", "BRAND_ID", "QUESTION_TYPE", "TITLE", "CONTENTS", "SECRET", "HITS", "REGIST_DATETIME", "ANSWER", "ANSWER_DATETIME" });

            //기본설정 : 바인딩되는 DataSource의 컬럼그대로 컬럼이 생성되면서 바인딩
            gudiDataGridview1.DataSource = dt;
            gudiDataGridview1.ClearSelection();
        }
    }
}
