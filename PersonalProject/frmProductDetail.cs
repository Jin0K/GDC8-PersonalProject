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
    public partial class frmProductDetail : Form
    {
        public DataTable dtCommonInProduct { get; set; }
        DataTable dtProduct, dtQAs, dtReviews;
        DataView dvSub;
        public frmProductDetail(string brandID, string productName)
        {
            InitializeComponent();

            ProductDAC dac = new ProductDAC();
            dtProduct = dac.GetProduct(brandID, productName);
        }


        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            string[] category = { "MAIN_TYPE", "MIDDLE_TYPE", "SUB_TYPE", "IMG_TYPE", "문의유형" };

            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCodes(category);

            //DataView dvCommonCode = new DataView(dt);
            //dvCommonCode.RowFilter = $" (CATEGORY = '색상' and CCODE in (select COLOR from product where PRODUCT_NAME = '{dtProduct.Rows[0]["PRODUCT_NAME"]}')) or (CATEGORY = '사이즈' and CCODE in (select SIZE from product where PRODUCT_NAME='{dtProduct.Rows[0]["PRODUCT_NAME"]}'))";

            CommonDAC dac1 = new CommonDAC();
            dtCommonInProduct = dac1.GetProductCommonCodes(new string[] { "색상", "사이즈" }, new string[] { "COLOR", "SIZE" }, dtProduct.Rows[0]["PRODUCT_NAME"].ToString());

            DataView dvColors = new DataView(dtCommonInProduct);
            dvColors.RowFilter = "CATEGORY='색상'";
            DataTable dtColors = dvColors.ToTable();

            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = dtColors.Columns["CCODE"];
            dtColors.PrimaryKey = primarykey;
            //DataRow[] drColors = dtCommonInProduct.Select($"CATEGORY='색상'");
            for (int i = 1; i < int.Parse(dtColors.Rows.Count.ToString()); i++)
            {
                //cboColor.SelectedIndex = i;
                int total = 0;
                DataRow[] rows = dtProduct.Select($"COLOR='{dtColors.Rows[i]["CCODE"].ToString()}'");
                //DataRow[] rows = dtProduct.Select($"COLOR='{cboColor.SelectedValue}'");
                for (int j = 0; j < rows.Length; j++)
                {
                    total += Convert.ToInt32(rows[j]["INVENTORY"]);
                }


                DataRow noColor = dtColors.Rows.Find(dtColors.Rows[i]["CCODE"]);
                if (total < 1)
                {
                    Debug.WriteLine(dtColors.Rows[i]["CCODE"]);
                    Debug.WriteLine(noColor["CNAME"]);
                    noColor["CNAME"] = noColor["CNAME"] + "(품절)";
                    Debug.WriteLine(noColor["CNAME"]);
                }
                else
                {
                    noColor["CNAME"] = noColor["CNAME"].ToString().Replace("(품절)", "");
                }
            }
            dtColors.AcceptChanges();

            CommonUtil.ComboBinding(cboColor, dtColors, "색상");
            //CommonUtil.ComboBinding(cboSize, dtCommonInProduct, "사이즈");

            //List<int> deleteIndex = new List<int>();
            //    if (dtProduct.Select($"COLOR='{drColors[i]["CCODE"]}'").Length > 0)
            //        continue;

            //    deleteIndex.Add(i);
            //cboColor.SelectedIndex = 0;
            //foreach (int index in deleteIndex)
            //{
            //    drColors[index]
            //}



            DataTable dtSelectTable = new DataTable();
            dtSelectTable.Columns.Add("Name");
            dtSelectTable.Columns.Add("Code");

            DataRow dr0 = dtSelectTable.NewRow();
            dr0["Code"] = "";
            dr0["Name"] = "전체";
            dtSelectTable.Rows.Add(dr0);

            DataRow dr1 = dtSelectTable.NewRow();
            dr1["Code"] = "q_and_a";
            dr1["Name"] = "문의";
            dtSelectTable.Rows.Add(dr1);

            DataRow dr2 = dtSelectTable.NewRow();
            dr2["Code"] = "review";
            dr2["Name"] = "후기";
            dtSelectTable.Rows.Add(dr2);
            dtSelectTable.AcceptChanges();

            DataView dv = new DataView(dtSelectTable);
            cboTable.DisplayMember = "Name";
            cboTable.ValueMember = "Code";
            cboTable.DataSource = dv;

            DataRow dr = dt.NewRow();
            dr["CCode"] = "";
            dr["CName"] = "전체";
            dr["Category"] = "문의유형";
            dt.Rows.InsertAt(dr, 0);
            dt.AcceptChanges();

            dvSub = new DataView(dt);
            dvSub.RowFilter = "CATEGORY='문의유형'";

            //p.PRODUCT_CODE, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, COLOR, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME, PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH
            lblMainCategory.Text = dtProduct.Rows[0]["MAIN_CATEGORY"].ToString();
            lblMidCategory.Text = dtProduct.Rows[0]["MIDDLE_CATEGORY"].ToString();
            lblSubCategory.Text = dtProduct.Rows[0]["SUB_CATEGORY"].ToString();
            lblProductName.Text = dtProduct.Rows[0]["PRODUCT_NAME"].ToString();
            lblBrand.Text = dtProduct.Rows[0]["BRAND_NAME"].ToString();
            lblPrice.Text = Convert.ToInt32(dtProduct.Rows[0]["PRICE"]).ToString("#,##0") + " 원";
            lblDiscountRate.Text = (Convert.ToDouble(dtProduct.Rows[0]["DISCOUNT_RATE"])*100).ToString("#0.##") + "%";
            lblDiscountPrice.Text = (1.0 * Convert.ToInt32(dtProduct.Rows[0]["PRICE"]) * (1 - Convert.ToDouble(dtProduct.Rows[0]["DISCOUNT_RATE"]))).ToString("#,##0") + " 원";
            lblProductDescription.Text = dtProduct.Rows[0]["PRODUCT_DESCRIPTION"].ToString();

            lblScore.Text = dtProduct.Rows[0]["AVG_SCORE"].ToString();
            lblCount.Text = dtProduct.Rows[0]["COUNT_REVIEW"].ToString()+" 명";

            DataTable dtImages = dtProduct.Copy();
            if (dtProduct.Columns["PRODUCT_IMG_CODE"].Unique) //컬럼 중복여부 확인
            {
                DataView dvImages = new DataView(dtImages);
                dtImages = dvImages.ToTable("PRODUCT_IMG_CODE");
            }

            for (int i = 0; i < dtImages.Rows.Count; i++)
            {
                PictureBox item = new PictureBox();
                item.Name = $"picture{i}";
                item.Size = new Size(97, 90);
                item.Location = new Point((i * 100), 0); //97, 90
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                item.ImageLocation = dtImages.Rows[i]["SERVER_PATH"].ToString();
                item.SizeMode = PictureBoxSizeMode.Zoom;
                item.BackColor = Color.White;
                item.DoubleClick += SubPictureBox_DoubleClick;
                pnlSubImages.Controls.Add(item);
            }

            pnlSubImages.Refresh();
            pnlSubImages.Update();

            //txtImgPath.Text = dlg.FileName; //전체경로
            //                                //item.Image = Image.FromFile(dlg.FileName);
            
            DataRow[] mainImg = dtProduct.Select("IMG_DIV='I001'");
            pctMainImg.ImageLocation = mainImg[0]["SERVER_PATH"].ToString();

            if (((frmMain)(this.Parent).Parent).CurrentBrand != null)
            {
                btnAddToCart.Enabled = false;
                btnBuy.Enabled = false;
                btnContact.Enabled = false;
            }
            else
            {
                btnAddToCart.Enabled = true;
                btnBuy.Enabled = true;
            }

            //CONTACT_NUMBER, CUSTOMER_ID, p.PRODUCT_CODE, PRODUCT_NAME, BRAND_ID, QUESTION_TYPE, TITLE, CONTENTS, SECRET, HITS, qa.REGIST_DATETIME, ANSWER, ANSWER_DATETIME 
            DataGridViewUtil.SetInitGridView(gudiDataGridview1);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "글번호", "CONTACT_NUMBER", DataGridViewContentAlignment.MiddleCenter, colWidth:80); //0
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "문의 유형", "QUESTION_TYPE", DataGridViewContentAlignment.MiddleCenter); //1
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제목", "TITLE", colWidth:300); //2
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
            //img.Image = Image.FromFile()
            gudiDataGridview1.Columns.Add(img); //5
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "작성일시", "REGIST_DATETIME", DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제품코드", "PRODUCT_CODE", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "제품명", "PRODUCT_NAME", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "내용", "CONTENTS", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "답변", "ANSWER", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "답변일시", "ANSWER_DATETIME", visibility: false);
            DataGridViewUtil.AddGridTextColumn(gudiDataGridview1, "브랜드", "BRAND_ID", visibility: false);

            LoadData();
        }

        private void SubPictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            pctMainImg.ImageLocation = picture.ImageLocation;
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTable.SelectedValue.ToString() == "q_and_a")
            {
                cboSub.DisplayMember = "CNAME";
                cboSub.ValueMember = "CCODE";
                cboSub.DataSource = dvSub;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (! IsVaildProduct()) return;

            //p.PRODUCT_CODE, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRICE, SIZE, COLOR, INVENTORY, MAIN_CATEGORY, MIDDLE_CATEGORY, SUB_CATEGORY, DISCOUNT_RATE, REGIST_DATETIME,PRODUCT_IMG_CODE, SERVER_PATH, IMG_DIV, b.BRAND_ID, BRAND_NAME, LOGO_IMG_PATH

            DataRow[] dr = dtProduct.Select($"PRODUCT_NAME='{lblProductName.Text}' and COLOR='{cboColor.SelectedValue}' and SIZE='{cboSize.SelectedValue}'");

            int productCode = (int)dr[0]["PRODUCT_CODE"];

            ShoppingCartDAC dac = new ShoppingCartDAC();
            if (dac.Insert(((frmMain)(this.Parent).Parent).CurrentCustomer.ID, productCode, (int)nudQty.Value))
            {
                MessageBox.Show("장바구니에 추가되었습니다.");
            }
            else
            {
                MessageBox.Show("오류가 발생했습니다.");
            }

        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (!IsVaildProduct()) return;

            DataView selectProduct = new DataView(dtProduct);
            selectProduct.RowFilter = $"PRODUCT_NAME='{lblProductName.Text}' and COLOR='{cboColor.SelectedValue}' and SIZE='{cboSize.SelectedValue}'";
            selectProduct.ToTable(false, new string[] { "PRODUCT_CODE", "PRODUCT_NAME", "INVENTORY", "BRAND_ID" });
            DataRow[] selectProduct1 = dtProduct.Select($"PRODUCT_NAME='{lblProductName.Text}' and COLOR='{cboColor.SelectedValue}' and SIZE='{cboSize.SelectedValue}'");

            //int productCode = (int)dr[0]["PRODUCT_CODE"];
            if (Convert.ToInt32(selectProduct[0]["INVENTORY"]) == 0)
            {
                MessageBox.Show("품절된 상품입니다.");
                return;
            }
            else if (Convert.ToInt32(selectProduct[0]["INVENTORY"]) < nudQty.Value)
            {
                MessageBox.Show($"재고 수량이 부족합니다.\n\r현재 재고 수량 : {Convert.ToInt32(selectProduct[0]["INVENTORY"])}");
                return;
            }

            frmPay pay = new frmPay(((frmMain)(this.Parent).Parent).CurrentCustomer, Convert.ToInt32(selectProduct[0]["PRODUCT_CODE"]), selectProduct[0]["PRODUCT_NAME"].ToString(), (int)nudQty.Value);
            pay.ShowDialog(this);

        }
        private bool IsVaildProduct()
        {
            StringBuilder sb = new StringBuilder();
            if (cboColor.SelectedIndex < 1)
            {
                sb.AppendLine("색상을 선택해주세요.");
            }
            if (cboSize.SelectedIndex < 1)
            {
                sb.AppendLine("사이즈를 선택해주세요.");
            }
            if (nudQty.Value < 1)
            {
                sb.AppendLine("수량을 입력해주세요.");
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return false;
            }

            

            if (((frmMain)(this.Parent).Parent).CurrentCustomer == null)
            {
                MessageBox.Show("로그인이 필요한 서비스입니다. 로그인을 해주세요.");
                ((frmMain)(this.Parent).Parent).LoginMenu.PerformClick();
                return false;
            }

            return true;

        }


        private void ComboBindingBasedCombo(ComboBox combo, ComboBox basedCombo, string comboCol, string basedCol, string comboCategory)
        {
            //combo = cboSize / basedcombo = cboColor / string combocol size / string basedcol color / 사이즈
            if (basedCombo.SelectedIndex < 1) return;
            
            //string tempSelected = combo.Text.ToString();
            //if (tempSelected == "선택") return;

            //if (basedCombo.Text.Contains("품절"))
            //{
            //    MessageBox.Show("품절된 상품입니다.");
            //    basedCombo.SelectedIndex = 0;
            //    return;
            //}

            DataView dvColorSizes = new DataView(dtProduct);
            dvColorSizes.RowFilter = $"{basedCol}='{basedCombo.SelectedValue}'";
            DataTable dtColorSizes = dvColorSizes.ToTable(false, new string[] { basedCol, comboCol, "INVENTORY" });
            if (dtColorSizes.Columns[comboCol].Unique)
            {
                dtColorSizes = dtColorSizes.DefaultView.ToTable(comboCol);
            }

            DataView dvSizes = new DataView(dtCommonInProduct);
            dvSizes.RowFilter = $"CATEGORY='{comboCategory}'";
            DataTable dtSizes = dvSizes.ToTable();

            DataColumn[] primarykey = new DataColumn[1];
            primarykey[0] = dtSizes.Columns["CCODE"];
            dtSizes.PrimaryKey = primarykey;

            DataTable dtComboSize = new DataTable();
            dtComboSize.Columns.Add("CNAME");
            dtComboSize.Columns.Add("CCODE");

            DataColumn[] pk = new DataColumn[1];
            pk[0] = dtComboSize.Columns["CCODE"];
            dtComboSize.PrimaryKey = pk;

            if (dtComboSize.Rows.Count < 1 || dtComboSize.Rows[0]["CCODE"].ToString().Length > 0)
            {
                DataRow dr0 = dtComboSize.NewRow();
                dr0["CCODE"] = "";
                dr0["CNAME"] = "선택";
                dtComboSize.Rows.Add(dr0);
            }

            for (int i = 0; i < int.Parse(dtSizes.Rows.Count.ToString()); i++) //dtColorSizes?
            {
                if (dtSizes.Rows.Find(dtColorSizes.Rows[i][comboCol]).ItemArray.Length > 0 && dtComboSize.Rows.Find(dtColorSizes.Rows[i][comboCol]) == null)
                {
                    DataRow dr = dtComboSize.NewRow();
                    dr["CCODE"] = dtColorSizes.Rows[i][comboCol].ToString();
                    dr["CNAME"] = dtSizes.Rows.Find(dtColorSizes.Rows[i][comboCol])["CNAME"].ToString();
                    dtComboSize.Rows.Add(dr);

                }
                else continue;

                DataRow noSize = dtSizes.Rows.Find(dtSizes.Rows[i]["CCODE"]);

                if (Convert.ToInt32(dtColorSizes.Rows[i]["INVENTORY"]) < 1)
                {
                    noSize["CNAME"] = noSize["CNAME"] + "(품절)";
                }
                else
                {
                    noSize["CNAME"] = noSize["CNAME"].ToString().Replace("(품절)", "").Trim();
                }
            }
            dtComboSize.AcceptChanges();

            DataView dv = new DataView(dtComboSize);
            combo.DisplayMember = "CNAME";
            combo.ValueMember = "CCODE";
            combo.DataSource = dv;


            //basedCombo.SelectedIndex = combo.FindStringExact(tempSelected);

        }


        private void cboColor_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBindingBasedCombo(cboSize, cboColor, "SIZE", "COLOR", "사이즈");
        }

        private void cboSize_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboColor.SelectedText == "선택")
            {
                MessageBox.Show("색상 먼저 선택 해주세요.");
                return;
            }
            //ComboBindingBasedCombo(cboColor, cboSize, "COLOR", "SIZE", "색상");

        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            
            if (((frmMain)(this.Parent).Parent).CurrentCustomer == null)
            {
                MessageBox.Show("로그인이 필요한 서비스입니다. 로그인을 해주세요.");
                ((frmMain)(this.Parent).Parent).LoginMenu.PerformClick();
                return;
            }

            if(cboColor.SelectedValue.ToString().Length<1 || cboSize.SelectedValue.ToString().Length < 1)
            {
                MessageBox.Show("문의할 상품의 옵션을 선택해주세요.");
                return;
            }

            DataRow[] selectProduct = dtProduct.Select($"PRODUCT_NAME='{lblProductName.Text}' and COLOR='{cboColor.SelectedValue}' and SIZE='{cboSize.SelectedValue}'");

            
            frmQandADetail frm = new frmQandADetail(OpenMode.Insert, dtProduct, dtCommonInProduct, Convert.ToInt32(selectProduct[0]["PRODUCT_CODE"]));
            frm.CloseForm += Frm_CloseForm;
            //frm.MdiParent = this.MdiParent;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                QandADAC dac = new QandADAC();
                bool bResult = dac.InsertQuestion(frm.QandADetail, frm.UploadImgPaths);
                //dac.Dispose();

                if (bResult)
                {
                    LoadData();
                    MessageBox.Show("문의가 등록되었습니다.");
                }
            }
        }

        private void Frm_CloseForm(object sender, FormCloseEventArgs e)
        {
            frmQandADetail frm = (frmQandADetail)e.ThisForm; //(frmQandADetail)sender;
            frm.Dispose();
            frm.Close();
        }

        private void LoadData()
        {
            QandADAC dac = new QandADAC();
            dtQAs = dac.GetProductQA(dtProduct.Rows[0]["PRODUCT_NAME"].ToString());
            //ReviewDAC review = new ReviewDAC();
            //dtReviews = review.GetReviews()
            DataView dv = new DataView(dtQAs);
            DataTable dt = dv.ToTable(true, new string[] { "CONTACT_NUMBER", "CUSTOMER_ID", "PRODUCT_CODE", "PRODUCT_NAME", "BRAND_ID", "QUESTION_TYPE", "TITLE", "CONTENTS", "SECRET", "HITS", "REGIST_DATETIME", "ANSWER", "ANSWER_DATETIME" });
            //기본설정 : 바인딩되는 DataSource의 컬럼그대로 컬럼이 생성되면서 바인딩


            //DataTable dt = dtQA.AsEnumerable().GroupBy(row => new
            //{
            //    CONTACT_NUMBER = row.Field<int>("CONTACT_NUMBER")
            //    CUSTOMER_ID = row.Field<string>("CUSTOMER_ID"),
            //    PRODUCT_CODE = row.Field<int>("PRODUCT_CODE"),
            //    PRODUCT_NAME = row.Field<string>("PRODUCT_NAME"),
            //    BRAND_ID = row.Field<string>("BRAND_ID"),
            //    QUESTION_TYPE = row.Field<string>("QUESTION_TYPE"),
            //    TITLE = row.Field<string>("TITLE"),
            //    CONTENTS = row.Field<string>("CONTENTS"),
            //    SECRET = row.Field<Boolean>("SECRET"),
            //    HITS = row.Field<int>("HITS"),
            //    REGIST_DATETIME = row.Field<DateTime?>("REGIST_DATETIME"),
            //    ANSWER = row.Field<string>("ANSWER"),
            //    ANSWER_DATETIME = row.Field<DateTime?>("ANSWER_DATETIME")

            //})
            //    .Select(g =>
            //{
            //    var row = dtQA.NewRow();
            //    row["CONTACT_NUMBER"] = g.Key.CONTACT_NUMBER;
            //    row["CUSTOMER_ID"] = g.Key.CUSTOMER_ID;
            //    row["PRODUCT_CODE"] = g.Key.PRODUCT_CODE;
            //    row["PRODUCT_NAME"] = g.Key.PRODUCT_NAME;
            //    row["BRAND_ID"] = g.Key.BRAND_ID;
            //    row["QUESTION_TYPE"] = g.Key.QUESTION_TYPE;
            //    row["TITLE"] = g.Key.TITLE;
            //    row["CONTENTS"] = g.Key.CONTENTS;
            //    row["SECRET"] = g.Key.SECRET;
            //    row["HITS"] = g.Key.HITS;
            //    row["REGIST_DATETIME"] = g.Key.REGIST_DATETIME;
            //    row["ANSWER"] = g.Key.ANSWER;
            //    row["ANSWER_DATETIME"] = g.Key.ANSWER_DATETIME;

            //    return row;
            //}).CopyToDataTable();


            gudiDataGridview1.DataSource = dt;
            gudiDataGridview1.ClearSelection();
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
            }
        }

        private void gudiDataGridview1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            QandA qa = DataGridViewUtil.QandAOfCellIndex(gudiDataGridview1, e.RowIndex);
            DataView dv = new DataView(dtQAs);
            dv.RowFilter = $"CONTACT_NUMBER={qa.ContactNumber}";

            frmQandADetail frm = new frmQandADetail(OpenMode.Update, qa, dv.ToTable());
            frm.CloseForm += Frm_CloseForm;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                List<string> imgPath = new List<string>();
                DataRow[] rows = dtQAs.Select($"CONTACT_NUMBER={qa.ContactNumber}");
                for (int i = rows.Length; i < frm.UploadImgPaths.Length; i++)
                {
                    imgPath.Add(frm.UploadImgPaths[i]);
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
            else
            {
                QandADAC dac = new QandADAC();
                if(dac.UpdateHits(qa.ContactNumber) > 0)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("조회수 업데이트 중 오류가 발생하였습니다.");
                }
            }
        }
    }
}
