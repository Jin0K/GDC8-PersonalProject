using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Excel = Microsoft.Office.Interop.Excel;

namespace PersonalProject
{
    public partial class RequiredOrderList : BaseListDetail
    {
        CheckBox headerCheckBox; //dgvNeed 컬럼헤더 체크박스
        OrderToVendorService otvServ;
        List<Product> needlist; //항목 리스트
        //string checkedRdo = string.Empty; //pnlFilter에서 선택된 라디오 버튼 이름

        List<OrderToVendorVO> orderToVendors; //엑셀 발주서에 출력
        string savefilepath; //엑셀 저장 경로
        string openfilepath; //엑셀 템플릿 경로

        public RequiredOrderList()
        {
            InitializeComponent();
        }

        //MdiChild Form 생성
        private void SubMenu_Click(object sender, EventArgs e)
        {
            //Button menu = (Button)sender;
            //FormUtil.OpenCreateForm(menu.Tag.ToString(), (frmMain)this.MdiParent);
            FormUtil formUtil = new FormUtil();
            formUtil.SubMenu_Click(sender, e, (frmMain)this.MdiParent);
        }

        private void RequiredOrderList_Load(object sender, EventArgs e)
        {

            DataGridViewUtil.SetInitGridView(dgvNeed); //Code, Name, Category

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn(); //0
            chk.HeaderText = "";
            chk.Width = 28;
            chk.Name = "chk";
            //chk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNeed.Columns.Add(chk); //0

            Point temp = dgvNeed.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckBox = new CheckBox();
            headerCheckBox.Location = new Point(temp.X +7, temp.Y +3);
            headerCheckBox.Size = new Size(16, 16);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Click += HeaderCheckBox_Click;
            dgvNeed.Controls.Add(headerCheckBox);

            //항목코드, 항목명, 실재고량, 논리재고량, 안전재고량, 필요량
            // M.MT_Code, MT_Name, MT_Qty, ORDER_Qty, STORE_Qty, Before_STORE_Qty, Logical_Qty, MT_Safety, M.COM_No, M.MT_Unit, CCM.Name as Unit_Name, CMT_MT_Unit, CMT_Unit_Name
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "항목코드", "MT_Code", DataGridViewContentAlignment.MiddleCenter, colWidth:80); //1
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "물품명", "MT_Name"); //2
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "실재고량", "MT_Qty", DataGridViewContentAlignment.MiddleRight); //3
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "미입고량", "Before_STORE_Qty", DataGridViewContentAlignment.MiddleRight);//4
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "수주소요량", "MT_Require", DataGridViewContentAlignment.MiddleRight);//5
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "안전재고량", "MT_Safety", DataGridViewContentAlignment.MiddleRight); //6
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "필요재고량", "Need_Qty", DataGridViewContentAlignment.MiddleRight); //7
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "논리재고량", "Logical_Qty", DataGridViewContentAlignment.MiddleRight); //8
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "단위", "Unit_Name", colWidth: 40); //9
            DataGridViewUtil.AddGridTextColumn(dgvNeed, "단위", "MT_Unit", visibility: false);
            //DataGridViewUtil.AddGridTextColumn(dgvNeed, "비용", "ORDER_Price", DataGridViewContentAlignment.MiddleRight);

            dgvNeed.SelectionMode = dgvNeed.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 특정 cell 하나를 클릭해도, 줄 전체가 선택
            //ClearControls(grbOrderCalc); //발주 수량 계산 초기화

        
            otvServ = new OrderToVendorService();
            //needlist = otvServ.GetNeedMTList(); 빌드 오류
            dgvNeed.DataSource = null;
            dgvNeed.DataSource = needlist;

            //dgvNeed.DataSource = needlist.Where((item) => item.Mt_Safety + item.MT_Require > item.Logical_Qty).ToList();

            //headerCheckBox.Checked = true;
            //HeaderCheckBox_Click(headerCheckBox, null);
            rdoAll.Checked = true;
            headerCheckBox.Checked = false;
            dgvNeed.ClearSelection();
            dtpRequiredDate.MinDate = DateTime.Now.AddDays(1); //납기요청일은 최소 내일
        }

        private void HeaderCheckBox_Click(object sender, EventArgs e)
        {
            dgvNeed.EndEdit();

            foreach (DataGridViewRow row in dgvNeed.Rows)
            {
                (row.Cells["chk"]).Value = headerCheckBox.Checked;
            }
        }

        private void dgvNeed_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvNeed.NewRowIndex)
                return;

            if (e.ColumnIndex == 6) //논리 재고량
            {
                decimal logicalQty = Convert.ToDecimal(dgvNeed["Logical_Qty", e.RowIndex].Value);
                decimal needQty = Convert.ToDecimal(dgvNeed["Need_Qty", e.RowIndex].Value);
                decimal mtRequire = Convert.ToDecimal(dgvNeed["MT_Require", e.RowIndex].Value);
                int mtSafety = Convert.ToInt32(dgvNeed["MT_Safety", e.RowIndex].Value);
                //dgvNeed["MT_Name", e.RowIndex].Style.ForeColor = 

                if (!rdoSafe.Checked)
                {
                    if (logicalQty < mtRequire)
                    {
                        dgvNeed["MT_Require", e.RowIndex].Style.BackColor = Color.SkyBlue;
                    }
                    else if (logicalQty == mtRequire)
                    {
                        dgvNeed["MT_Require", e.RowIndex].Style.BackColor = Color.PaleTurquoise;
                    }
                }

                if (! rdoOrder.Checked)
                {
                    if (logicalQty < mtSafety)
                    {
                        dgvNeed["MT_Safety", e.RowIndex].Style.BackColor = Color.Coral;
                    }
                    else if (logicalQty == mtSafety)
                    {
                        dgvNeed["MT_Safety", e.RowIndex].Style.BackColor = Color.Pink;
                    }
                }

                if (rdoNeedAll.Checked || rdoAll.Checked)
                {
                    if (logicalQty < needQty)
                    {
                        dgvNeed["Need_Qty", e.RowIndex].Style.BackColor = Color.Yellow;
                    }
                    else if (logicalQty == needQty)
                    {
                        dgvNeed["Need_Qty", e.RowIndex].Style.BackColor = Color.GreenYellow;
                    }
                }

                if (dgvNeed["Need_Qty", e.RowIndex].Style.BackColor.IsKnownColor)
                {
                    dgvNeed["MT_Code", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = dgvNeed["Need_Qty", e.RowIndex].Style.BackColor;
                }
                else if (dgvNeed["MT_Require", e.RowIndex].Style.BackColor.IsKnownColor)
                {
                    dgvNeed["MT_Code", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = dgvNeed["MT_Require", e.RowIndex].Style.BackColor;
                }
                else if (dgvNeed["MT_Safety", e.RowIndex].Style.BackColor.IsKnownColor)
                {
                    dgvNeed["MT_Code", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = dgvNeed["MT_Safety", e.RowIndex].Style.BackColor;
                }

                //if (! dgvNeed["MT_Require", e.RowIndex].Style.BackColor.IsEmpty && ! dgvNeed["MT_Safety", e.RowIndex].Style.BackColor.IsEmpty)
                //{
                //    if (dgvNeed["MT_Require", e.RowIndex].Style.BackColor != Color.GreenYellow && dgvNeed["MT_Safety", e.RowIndex].Style.BackColor != Color.GreenYellow)
                //        dgvNeed["MT_Name", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = Color.Orange;
                //    else if (dgvNeed["MT_Require", e.RowIndex].Style.BackColor == Color.GreenYellow)
                //        dgvNeed["MT_Name", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = dgvNeed["MT_Safety", e.RowIndex].Style.BackColor;
                //    else if (dgvNeed["MT_Safety", e.RowIndex].Style.BackColor == Color.GreenYellow)
                //        dgvNeed["MT_Name", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = dgvNeed["MT_Require", e.RowIndex].Style.BackColor;
                //    else
                //        dgvNeed["MT_Name", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = Color.GreenYellow;
                //}
                //else if (! dgvNeed["MT_Require", e.RowIndex].Style.BackColor.IsEmpty)
                //{
                //    dgvNeed["MT_Name", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = dgvNeed["MT_Require", e.RowIndex].Style.BackColor;
                //}
                //else if (! dgvNeed["MT_Safety", e.RowIndex].Style.BackColor.IsEmpty)
                //{
                //    dgvNeed["MT_Name", e.RowIndex].Style.BackColor = dgvNeed["Logical_Qty", e.RowIndex].Style.BackColor = dgvNeed["MT_Safety", e.RowIndex].Style.BackColor;
                //}

            }

            //if (e.ColumnIndex == 4)
            //{
            //    e.Value = dgvNeed["Category", e.RowIndex].Value.ToString() + "수정";
            //    //안전재고량
            //    if (dgvNeed["Category", e.RowIndex].Value.ToString() == "색상")
            //    {
            //        dgvNeed["Code", e.RowIndex].Style.ForeColor = Color.Red;
            //        dgvNeed["Code", e.RowIndex].Style.BackColor = Color.Yellow;
            //    }
            //}
            //else if (e.ColumnIndex == 6)
            //{
            //    Image img = Image.FromFile(dgvNeed["ProductImage", e.RowIndex].Value.ToString());
            //    e.Value = img;
            //}
           
        }

        private void btnSelectiveOrder_Click(object sender, EventArgs e)
        {
            dgvNeed.EndEdit();

            List<int> selCodes = new List<int>();
            List<int> orderQtys = new List<int>();
            foreach (DataGridViewRow row in dgvNeed.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                if (Convert.ToBoolean(chk.Value))
                {
                    int code = Convert.ToInt32(row.Cells["MT_Code"].Value);
                    selCodes.Add(code);

                    int lack = Convert.ToInt32(row.Cells["Need_Qty"].Value) - Convert.ToInt32(row.Cells["Logical_Qty"].Value);
                    int orderQty = (lack > 0) ? lack : 0 + (int)nuExtra.Value;

                    if (orderQty > 0)
                    {
                        orderQtys.Add(orderQty);
                    }
                    else
                    {
                        MessageBox.Show("발주 수량이 0인 물품이 포함되어있습니다.\r\n추가 여유 수량을 입력하거나 발주 목록에서 제외해주세요.");
                        return;
                    }
                }
            }

            if(selCodes.Count < 1)
            {
                MessageBox.Show("발주할 물품을 선택해주세요.");
                return;
            }

            if(selCodes.Count != orderQtys.Count)
            {
                return;
            }

            List<OrderToVendorVO> results = otvServ.FastRegisterOrder(selCodes, orderQtys, dtpRequiredDate.Value);
            //RegisterOrderResult(results);

            

        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            //빌드 오류
            //dgvNeed.DataSource = null;

            //if (rdoNeedAll.Checked)
            //{
            //    //checkedRdo = rdoAll.Name;
            //    dgvNeed.DataSource = needlist.Where((item) => item.Need_Qty > item.Logical_Qty).ToList();

            //}
            //else if (rdoSafe.Checked)
            //{
            //    //checkedRdo = rdoSafe.Name;
            //    dgvNeed.DataSource = needlist.Where((item) => item.Mt_Safety > item.Logical_Qty).ToList();

            //}
            //else if (rdoOrder.Checked)
            //{
            //    //checkedRdo = rdoOrder.Name;
            //    dgvNeed.DataSource = needlist.Where((item) => item.MT_Require > item.Logical_Qty).ToList();
            //}
            //else if (rdoAll.Checked)
            //{
            //    //checkedRdo = rdoAll.Name;
            //    dgvNeed.DataSource = needlist;
            //}
            ////else
            ////{

            ////}

            //headerCheckBox.Checked = true;
            //HeaderCheckBox_Click(headerCheckBox, null);
            //dgvNeed.ClearSelection();
        }

        private void btnAllOrder_Click(object sender, EventArgs e)
        {
            dgvNeed.EndEdit();

            List<int> selCodes = new List<int>();
            List<int> orderQtys = new List<int>();
            foreach (DataGridViewRow row in dgvNeed.Rows)
            {
                //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["chk"];
                //if (Convert.ToBoolean(chk.Value))
                //{
                int code = Convert.ToInt32(row.Cells["MT_Code"].Value);
                selCodes.Add(code);

                int lack = Convert.ToInt32(row.Cells["Need_Qty"].Value) - Convert.ToInt32(row.Cells["Logical_Qty"].Value);
                int orderQty = (lack > 0) ? lack : 0 + (int)nuExtra.Value;

                if (orderQty > 0)
                {
                    orderQtys.Add(orderQty);
                }
                else
                {
                    MessageBox.Show("발주 수량이 0인 물품이 포함되어있습니다.\r\n추가 여유 수량을 입력하거나 발주 목록에서 제외해주세요.");
                    return;
                }
                //}
            }

            if (selCodes.Count < 1)
            {
                MessageBox.Show("발주할 물품을 선택해주세요.");
                return;
            }

            if (selCodes.Count != orderQtys.Count)
            {
                return;
            }

            List<OrderToVendorVO> results = otvServ.FastRegisterOrder(selCodes, orderQtys, dtpRequiredDate.Value);
            //RegisterOrderResult(results);
        }

        private void dgvNeed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvNeed.EndEdit();

            if (e.RowIndex < 0 || e.RowIndex == dgvNeed.NewRowIndex)
                return;

            if (dgvNeed.Rows[e.RowIndex].Cells["chk"] is DataGridViewCheckBoxCell chk && Convert.ToBoolean(chk.Value) == false)
            {
                if (headerCheckBox.Checked)
                    headerCheckBox.Checked = false;
            }
        }

        //private void RegisterOrderResult(List<OrderToVendorVO> results)
        //{
        //    if (results != null)
        //    {
        //        rdoNeedAll.Checked = true;
        //        rdo_CheckedChanged(null, null);

        //        MessageBox.Show("발주가 완료되었습니다.");

        //        this.orderToVendors = results;

        //        string filePath = Application.StartupPath + @"\Templates\OrderFormTemplate.xls";
        //        //string openPath = @"/Templates/OrderFormTemplate.xls";
        //        if (!File.Exists(filePath))
        //        {
        //            MessageBox.Show("템플릿 파일이 존재하지 않습니다.");
        //            return;
        //        }
        //        openfilepath = filePath;
        //        //저장할 디렉토리, 파일명을 물어보고, 그 파일경로로 엑셀파일 저장
        //        SaveFileDialog dlg = new SaveFileDialog();
        //        dlg.Filter = "Excel Files(*.xls)|*.xls";
        //        dlg.Title = "엑셀파일로 내보내기";

        //        if (dlg.ShowDialog() == DialogResult.OK)
        //        {
        //            savefilepath = dlg.FileName;
        //            try
        //            {
        //                WaitAsyncForm wait = new WaitAsyncForm(ExportExcel);
        //                wait.ShowDialog();
        //            }
        //            catch (Exception err)
        //            {
        //                MessageBox.Show(err.Message);
        //            }
        //        }

        //        needlist = otvServ.GetNeedMTList();
        //        dgvNeed.DataSource = null;
        //        dgvNeed.DataSource = needlist;
        //        dgvNeed.ClearSelection();
        //        headerCheckBox.Checked = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("발주처리 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
        //    }

        //}

        //private void ExportExcel()
        //{
        //    Excel.Application xlApp = new Excel.Application(); //엑셀 실행
        //    Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(openfilepath);
        //    //Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();  //새문서 만들기(문서 만들면 기본 sheet 생성, 버전따라 생성한 sheet 수가 다름)

        //    //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add(); //sheet 추가
        //    //DataTable dt = (DataTable)dataGridView1.DataSource;

        //    Excel.Worksheet xlWorkSheet = null; //가장 앞에 있는 sheet 하나를 가져와서 참조, dynamic 타입이라 미리 형변환 하는 게 좋음

        //    int i = 1;
        //    foreach (OrderToVendorVO orders in orderToVendors)
        //    {
        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(i);
        //        xlWorkSheet.Copy(xlWorkSheet); //sheet 복사
        //        ExcelUtil.PrintOrderFormTemplateOnWorksheet(xlWorkSheet, orders);
        //        i++;
        //    }

        //    xlApp.DisplayAlerts = false;

        //    //((Excel.Worksheet)xlWorkBook.Worksheets.get_Item(i)).Delete();
        //    ((Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1)).Delete();

        //    //xlWorkSheet = xlWorkBook.Worksheets.Item[xlWorkBook.Worksheets.Count - 1];
        //    //xlWorkSheet.Delete();

        //    xlApp.DisplayAlerts = true;

        //    xlWorkBook.SaveAs(savefilepath, Excel.XlFileFormat.xlWorkbookNormal); //엑셀 문서를 파일 저장, 상대경로/절대 경로, xls/xlsx 둘 다 가능
        //    xlWorkBook.Close(true);  //엑셀 문서 닫기
        //    xlApp.Quit(); //엑셀 프로그램 종료(해도 프로세스는 남아있음)


        //    //엑셀 프로세스 제거, 릴리즈는 생성순서와 반대로 실행
        //    ExcelUtil.ReleaseObject(xlWorkSheet);
        //    ExcelUtil.ReleaseObject(xlWorkBook);
        //    ExcelUtil.ReleaseObject(xlApp);

        //    MessageBox.Show("엑셀 다운로드 완료");
            
        //}

        //private void btnExcelExport_Click(object sender, EventArgs e)
        //{
        //    // 유효성검사
        //    if (dgvNeed.DataSource == null)
        //    {
        //        MessageBox.Show("출력할 내용이 없습니다.");
        //        return;
        //    }
        //    //저장할 디렉토리, 파일명을 물어보고, 그 파일경로로 엑셀파일 저장
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.Filter = "Excel Files(*.xls)|*.xls|Excel Files(*.xlsx)|*.xlsx";
        //    dlg.Title = "엑셀파일로 내보내기";

        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        savefilepath = dlg.FileName;
        //        try
        //        {
        //            WaitAsyncForm wait = new WaitAsyncForm(ExportExcelList);
        //            wait.ShowDialog();
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show(err.Message);
        //        }
        //    }
        //}

        //private void ExportExcelList()
        //{
        //    bool success = false;

        //    //success = ExcelUtil.ExportExcelToList<Product>((List<Product>)dgvNeed.DataSource, dlg.FileName, new List<string> { "" }, DataGridViewUtil.GetDataGridViewPropName(dgvNeed));

        //    success = ExcelUtil.ExportExcelToList<Product>((List<Product>)dgvNeed.DataSource, savefilepath, DataGridViewUtil.GetDataGridViewPropName(dgvNeed));

        //    if (success)
        //        MessageBox.Show("엑셀 다운로드 완료");

        //}
    }
}
