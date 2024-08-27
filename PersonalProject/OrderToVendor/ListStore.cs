using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

//using Excel = Microsoft.Office.Interop.Excel;

namespace PersonalProject
{
    public partial class ListStore : BaseSelectForm
    {
        StoreService strServ = null;
        string savefilepath; //엑셀 저장 경로
        int storeNum; //엑셀 출력할 디테일num

        public ListStore()
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

        private void ListStore_Load(object sender, EventArgs e)
        {
            CommonService comServ = new CommonService();

            #region 코드 데이터들을 조회해서 콤보박스 바인딩

            string[] gubuns = { "Material", "Company", "입고상태" };

            List<CommonVO> list = comServ.GetCodeList(gubuns);

            CommonUtil.ComboBinding(cboMt, list, "Material", blankText: "전체");
            CommonUtil.ComboBinding(cboCom, list, "Company", blankText: "전체");

            List<CommonVO> storeStatusList = list.FindAll((cbo) => cbo.Category == "입고상태" && cbo.Name.Contains("입고"));
            CommonUtil.ComboBinding(cboState, storeStatusList, "입고상태", blankText: "전체");
            #endregion

            #region 입고 목록 데이터그리드뷰 컬럼 셋팅
            //입고상세번호, 거래처, 입고일, 입고상태, 항목, 수량, 단위, 유통기한
            //SD.STORE_No, S.COM_No, COM_Name, STORE_Date, STORE_Status, CS.Name as Status_Name, STORE_Detail, SD.MT_Code, MT_Name, STORE_Qty, STORE_Unit, CU.Name as Unit_Name, Epr_Date, SD.ORDER_Detail
            DataGridViewUtil.SetInitGridView(dgvStoreList);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "입고상세번호", "STORE_Detail", DataGridViewContentAlignment.MiddleCenter, colWidth: 120);
            //DataGridViewUtil.AddGridTextColumn(dgvStoreList, "거래처 번호", "COM_No");
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "거래처명", "COM_Name");
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "물품명", "COM_MTR_Name");
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "입고 물량", "STORE_Qty", DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "입고단위", "Unit_Name", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "입고 단위", "STORE_Unit", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "입고 날짜", "STORE_Date", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "유통 기간", "Epr_Date", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "입고상태", "Status_Name", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "입고 상태", "STORE_Status", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "발주번호", "ORDER_No", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvStoreList, "발주상세번호", "ORDER_Detail", DataGridViewContentAlignment.MiddleCenter, colWidth: 120);
            #endregion

            CommonUtil.ClearControls(pnlClear);
            btnExcelExport.Enabled = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string mtCode = cboMt.SelectedValue.ToString();
            string comNo = cboCom.SelectedValue.ToString();
            string status = cboState.SelectedValue.ToString();
            string dtFrom = ucPeriod.From;
            string dtTo = ucPeriod.To;

            if (strServ == null)
            {
                strServ = new StoreService();
            }

            List<StoreInfoDetailVO> list = strServ.GetStoreSearchList(comNo, mtCode, status, dtFrom, dtTo);
            dgvStoreList.DataSource = null;
            dgvStoreList.DataSource = list;
            dgvStoreList.ClearSelection();

            CommonUtil.ClearControls(pnlClear);

            if (!btnExcelExport.Enabled)
                btnExcelExport.Enabled = true;
        }

        private void dgvStoreList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //유효성체크
            if (e.RowIndex < 0) return;

            //조회해서 컨트롤에 바인딩
            if (dgvStoreList["STORE_Detail", e.RowIndex].Value != null)
            {
                //lblComName.Tag = dgvStoreList["COM_No", e.RowIndex].Value;
                lblComName.Text = dgvStoreList["COM_Name", e.RowIndex].Value.ToString();
                //lblMTName.Tag = dgvStoreList["MT_Code", e.RowIndex].Value;
                lblMTName.Text = dgvStoreList["COM_MTR_Name", e.RowIndex].Value.ToString();
                lblUnit.Text = dgvStoreList["Unit_Name", e.RowIndex].Value.ToString();
                //lblUnit.Tag = dgvStoreList["MT_Unit", e.RowIndex].Value.ToString();
                lblSTORE_Detail.Text = dgvStoreList["STORE_Detail", e.RowIndex].Value.ToString();
                lblEpr_Date.Text = Convert.ToDateTime(dgvStoreList["Epr_Date", e.RowIndex].Value).ToShortDateString();
                lblStoreDate.Text = Convert.ToDateTime(dgvStoreList["STORE_Date", e.RowIndex].Value).ToString("yyyy-MM-dd HH:mm");
                lblSTORE_Qty.Text = dgvStoreList["STORE_Qty", e.RowIndex].Value.ToString();
                lblSTORE_Status.Text = dgvStoreList["Status_Name", e.RowIndex].Value.ToString();

                //lblOrderDetail.Text = dgvStoreList["ORDER_Detail", e.RowIndex].Value.ToString();
                //lblOrderDetail.Tag = dgvStoreList["ORDER_No", e.RowIndex].Value;

                if (!btnExcelExport.Enabled)
                    btnExcelExport.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //유효성검사
            if (dgvStoreList.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 내역을 선택하여 주십시오.");
                return;
            }

            //처리
            int storeNum = Convert.ToInt32(dgvStoreList.SelectedRows[0].Cells["STORE_Detail"].Value);
            if (MessageBox.Show($"입고번호 : {storeNum}을 삭제하시겠습니까?", "입고 삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            bool result = strServ.DeleteStore(storeNum);
            if (result)
            {
                MessageBox.Show("삭제가 완료되었습니다.");
                btnSelect.PerformClick();
            }
            else
            {
                MessageBox.Show("삭제 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }

        //private void btnExcelExport_Click(object sender, EventArgs e)
        //{
        //    // 유효성검사
        //    if (dgvStoreList.DataSource == null)
        //    {
        //        MessageBox.Show("출력할 내용이 없습니다.");
        //        return;
        //    }

        //    //저장할 디렉토리, 파일명을 물어보고, 그 파일경로로 엑셀파일 저장
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.Filter = "Excel Files(*.xlsx)|*.xlsx";
        //    dlg.Title = "엑셀파일로 내보내기";

        //    //// 유효성검사
        //    //if (dgvStoreList.SelectedRows.Count < 1)
        //    //{
        //    //    MessageBox.Show("출력할 내역을 선택하여 주십시오.");
        //    //    return;
        //    //}


        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        this.savefilepath = dlg.FileName;
        //        if(!string.IsNullOrWhiteSpace(lblSTORE_Detail.Text))
        //            storeNum = Convert.ToInt32(dgvStoreList.SelectedRows[0].Cells["STORE_Detail"].Value);
        //        try
        //        {
        //            WaitAsyncForm wait = new WaitAsyncForm(ExportExcel);
        //            wait.ShowDialog();
        //        }
        //        catch (Exception err)
        //        {
        //            MessageBox.Show(err.Message);
        //        }
        //    }
        //}

        //private void ExportExcel()
        //{
        //    bool success = false;

        //    if (string.IsNullOrWhiteSpace(lblSTORE_Detail.Text))
        //    {
        //        success = ExcelUtil.ExportExcelToList<StoreInfoDetailVO>((List<StoreInfoDetailVO>)dgvStoreList.DataSource, savefilepath, DataGridViewUtil.GetDataGridViewPropName(dgvStoreList));
        //    }
        //    else
        //    {
        //        success = ExcelExportDetail();
        //    }

        //    if (success)
        //        MessageBox.Show("엑셀 다운로드 완료");
        //}

        //private bool ExcelExportDetail() 
        //{
        //    string filePath = Application.StartupPath + @"\Templates\TradingStatementTemplate.xlsx";

        //    if (!File.Exists(filePath))
        //    {
        //        MessageBox.Show("템플릿 파일이 존재하지 않습니다.");
        //        return false;
        //    }

        //    Excel.Application xlApp = new Excel.Application(); //엑셀 실행
        //    Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
        //    //Excel.Worksheet xlWorkSheet= (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //    Excel.Worksheet xlWorkSheet = ExcelUtil.PrintTradingStatementTemplateOnWorksheet((Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1), storeNum); //가장 앞에 있는 sheet 하나를 가져와서 참조, dynamic 타입이라 미리 형변환 하는 게 좋음

        //    //xls 확장자로 저장하는 경우
        //    //xlWorkBook.SaveAs(dlg.FileName, Excel.XlFileFormat.xlWorkbookNormal);

        //    //xlsx 확장자로 저장하는 경우
        //    xlWorkBook.SaveCopyAs(savefilepath);
        //    xlWorkBook.Saved = true;

        //    xlWorkBook.Close(true);  //엑셀 문서 닫기
        //    xlApp.Quit(); //엑셀 프로그램 종료(해도 프로세스는 남아있음)


        //    //엑셀 프로세스 제거, 릴리즈는 생성순서와 반대로 실행
        //    ExcelUtil.ReleaseObject(xlWorkSheet);
        //    ExcelUtil.ReleaseObject(xlWorkBook);
        //    ExcelUtil.ReleaseObject(xlApp);

        //    return true;
        //}
    }
}
