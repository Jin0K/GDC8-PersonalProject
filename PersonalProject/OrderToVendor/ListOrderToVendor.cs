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
    public partial class ListOrderToVendor : BaseSelectForm
    {
        OrderToVendorService otvServ = null;
        string savefilepath; //엑셀 저장 경로
        OrderToVendorVO orderToVendor = null; //발주 내역(기본+상세)

        public ListOrderToVendor()
        {
            InitializeComponent();
        }

        //MdiChild Form 생성
        private void SubMenu_Click(object sender, EventArgs e)
        {
            //Button menu = (Button)sender;
            //FormUtil.OpenCreateForm(menu.Tag.ToString(), (frmMain)this.MdiParent);
            FormUtil fu = new FormUtil();
            fu.SubMenu_Click(sender, e, (frmMain)this.MdiParent);
        }

        private void ListOrderToVendor_Load(object sender, EventArgs e)
        {
            CommonService comServ = new CommonService();

            #region 코드 데이터들을 조회해서 콤보박스 바인딩

            string[] gubuns = { "Material", "Company", "발주/수주 상태" };

            List<CommonVO> list = comServ.GetCodeList(gubuns);

            CommonUtil.ComboBinding(cboMt, list, "Material", blankText: "전체");
            CommonUtil.ComboBinding(cboCom, list, "Company", blankText: "전체");
            CommonUtil.ComboBinding(cboState, list, "발주/수주 상태", blankText: "전체");
            #endregion

            #region 발주 목록 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvOrder);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "발주번호", "ORDER_No");
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "업체번호", "COM_No");
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "거래처 명", "COM_Name");
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "발주날짜", "ORDER_Date");
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "총액", "ORDER_Price", DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "납기날짜", "Period_Date");
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "발주상태", "Status_Name");
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "발주상태", "ORDER_Status", visibility: false);
            #endregion

            #region 발주 물품 데이터그리드뷰 컬럼 셋팅
            //항목코드, 항목명, 단위 , 수량, 가격
            //ORDER_Detail, OD.ORDER_No, OD.MT_Code, MT_Name, ORDER_Qty, ORDER_Unit, (select Name from Common_Code where Code=ORDER_Unit) Unit_Name, OD.ORDER_Price MT_Price, COM_MTR_ID, 
            DataGridViewUtil.SetInitGridView(dgvOrderDetail);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "발주상세번호", "ORDER_Detail");
            //DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "거래처별 거래 물품 번호", "COM_MTR_ID");
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "물품명", "COM_MTR_Name");
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "주문량", "ORDER_Qty", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "단위", "Unit_Name", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "비용", "ORDER_Price", DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "단위", "ORDER_Unit", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "입고상태", "SD_Status", DataGridViewContentAlignment.MiddleCenter, colWidth:80);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "입고번호", "STORE_Detail", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "입고수량", "STORE_Qty", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvOrderDetail, "단위", "Unit_Name", colWidth: 80);
            #endregion

            dgvOrder.SelectionMode = dgvOrderDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 특정 cell 하나를 클릭해도, 줄 전체가 선택
            CommonUtil.ClearControls(pnlClear);
            btnExcelExport.Enabled = false;
            //dtpPeriod_Date.MinDate = DateTime.Now.AddDays(1); //납기요청일은 최소 내일
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string mtCode = cboMt.SelectedValue.ToString();
            string comNo = cboCom.SelectedValue.ToString();
            string status = cboState.SelectedValue.ToString();
            string dtFrom = ucPeriod.From;
            string dtTo = ucPeriod.To;

            if (otvServ == null)
                otvServ = new OrderToVendorService();

            List<OrderVO> list = otvServ.GetOrderSearchList(comNo, mtCode, status, dtFrom, dtTo);
            dgvOrder.DataSource = list;
            dgvOrder.ClearSelection();

            dgvOrderDetail.DataSource = null;
            CommonUtil.ClearControls(pnlClear);
            if (! btnExcelExport.Enabled)
                btnExcelExport.Enabled = true;

            if (orderToVendor != null)
                orderToVendor = null;
        }

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //유효성체크
            if (e.RowIndex < 0) return;

            int ordID = Convert.ToInt32(dgvOrder["ORDER_No", e.RowIndex].Value);

            if (otvServ == null)
                otvServ = new OrderToVendorService();

            //상세주문정보를 조회
            orderToVendor = otvServ.GetOrderDetailList(ordID);

            //Find():EF에서 데이터테이블에만 존재하는 행들도 조회
            //FirstOrDefault(): EF에서 DB에 반영된 행들만 조회


            //주문내역정보를 조회해서 컨트롤에 바인딩
            if (orderToVendor != null)
            {
                OrderVO order = orderToVendor.OrderM;
                List<OrderDetailVO> details = orderToVendor.OrderD;
                dgvOrderDetail.DataSource = details; //상세주문정보를 데이터그리드뷰에 바인딩
                dgvOrderDetail.ClearSelection();

                lblOrderNo.Text = order.ORDER_No.ToString();
                lblComName.Text = order.COM_Name;
                lblOrderDate.Text = order.ORDER_Date.ToShortDateString();
                lblOrderStatus.Tag = order.ORDER_Status;

                List<CommonVO> orderStatusList = new List<CommonVO>();
                CommonVO cbo = new CommonVO
                {
                    Name = lblOrderStatus.Text = order.Status_Name,
                    Code = order.ORDER_Status
                };
                orderStatusList.Add(cbo);
                if (order.Status_Name == "발주") // || order.Status_Name == "발주취소"
                {
                    cboOrderStatus.Enabled = true;
                    cbo = new CommonVO
                    {
                        Name = "발주취소", // (order.Status_Name == "발주")?"발주취소":"발주",
                        Code = "ODR4" //(order.Status_Name == "발주")?"ODR4": "ODR3"
                    };
                    orderStatusList.Add(cbo);
                }
                else
                {
                    cboOrderStatus.Enabled = false;
                }

                cboOrderStatus.DisplayMember = "Name";
                cboOrderStatus.ValueMember = "Code";
                cboOrderStatus.DataSource = orderStatusList;
                cboOrderStatus.SelectedIndex = cboOrderStatus.FindStringExact(order.Status_Name);

                if (lblOrderStatus.Text == "발주취소")
                    btnUpdate.Enabled = false;
                else
                    btnUpdate.Enabled = true;

                lblRequiredDate.Text = order.Period_Date.ToShortDateString();
                dtpPeriod_Date.Value = order.Period_Date;
                //dtpPeriod_Date.MinDate = order.ORDER_Date;
                lblTotalPrice.Text = order.ORDER_Price.ToString("#,##0") + " 원";

                ////선택된 주문의 상태가 입고전, 입고후
                //if (order.ORDER_Status == "ODR3" || order.ORDER_Status == "ODR4") //입고전
                //{
                //    btnDelete.Enabled = true;
                //}
                //else //입고후
                //{
                //    ////배송일이 널인 데이터는 배송일을 빈값으로 보여준다.
                //    //if (order.ShippedDate == null)
                //    //{
                //    //    dtpShippedDate.Format = DateTimePickerFormat.Custom;
                //    //    dtpShippedDate.CustomFormat = " ";
                //    //}
                //    //else
                //    //{
                //    //    dtpShippedDate.Format = DateTimePickerFormat.Short;
                //    //    dtpShippedDate.Value = Convert.ToDateTime(order.ShippedDate);
                //    //}

                //    btnDelete.Enabled = false;
                //}

                if (!btnExcelExport.Enabled)
                    btnExcelExport.Enabled = true;


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //유효성검사
            if (dgvOrder.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 내역을 선택하여 주십시오.");
                return;
            }

            List<int> orderNos = new List<int>();
            for (int i = 0; i < dgvOrder.SelectedRows.Count; i++)
            {
                if (!dgvOrder.SelectedRows[i].Cells["Status_Name"].Value.ToString().Contains("발주"))
                {
                    MessageBox.Show("입고 내역이 존재하는 발주 내역은 삭제하실 수 없습니다.");
                    return;
                }
                else
                {
                    orderNos.Add(Convert.ToInt32(dgvOrder.SelectedRows[i].Cells["ORDER_No"].Value));
                }
            }

            orderNos.Sort();

            if (dgvOrder.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"발주번호 : {orderNos[0]}을 삭제하시겠습니까?", "발주 삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }
            else
            {
                if (MessageBox.Show($"발주번호 : {orderNos[0]}부터 {orderNos.Last()}까지를 삭제하시겠습니까?", "발주 삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            //처리

            bool result = false;

            if (dgvOrder.SelectedRows.Count == 1)
            {
                result = otvServ.DeleteOrder(orderNos[0]);
            }
            else
            {
                result = otvServ.DeleteOrder(orderNos); 
            }

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //유효성체크
            if (dtpPeriod_Date.Value < Convert.ToDateTime(lblOrderDate.Text))
            {
                MessageBox.Show("납기일을 발주일보다 빠르게 입력할 수 없습니다.");
                return;
            }

            OrderVO order = new OrderVO
            {
                ORDER_No = Convert.ToInt32(lblOrderNo.Text),
                //ORDER_Price = Convert.ToInt32(lblTotalPrice.Text.OriginalInt()),
                //ORDER_Date = Convert.ToDateTime(lblOrderDate.Text),
                Period_Date = dtpPeriod_Date.Value,
                ORDER_Status = cboOrderStatus.SelectedValue.ToString()
            };

            //처리
            bool result = otvServ.UpdateOrder(order);
            if (result)
            {
                MessageBox.Show("수정이 완료되었습니다.");
                btnSelect.PerformClick();
            }
            else
            {
                MessageBox.Show("수정 중 오류가 발생하였습니다.\n다시 시도하여 주십시오.");
            }
        }

        //private void btnExcelExport_Click(object sender, EventArgs e)
        //{
        //    if(dgvOrder.DataSource == null)
        //    {
        //        MessageBox.Show("출력할 내용이 없습니다.");
        //        return;
        //    }

        //    //저장할 디렉토리, 파일명을 물어보고, 그 파일경로로 엑셀파일 저장
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.Filter = "Excel Files(*.xls)|*.xls";
        //    dlg.Title = "엑셀파일로 내보내기";

        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        savefilepath = dlg.FileName;
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

        //    if (orderToVendor == null)
        //    {

        //        success = ExcelUtil.ExportExcelToList<OrderVO>((List<OrderVO>)dgvOrder.DataSource, savefilepath, DataGridViewUtil.GetDataGridViewPropName(dgvOrder));
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
            
        //    string filePath = Application.StartupPath + @"\Templates\OrderFormTemplate.xls";
        //    //string openPath = @"/Templates/OrderFormTemplate.xls";
        //    if (!File.Exists(filePath))
        //    {
        //        MessageBox.Show("템플릿 파일이 존재하지 않습니다.");
        //        return false;
        //    }
    
        //    Excel.Application xlApp = new Excel.Application(); //엑셀 실행
        //    Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
        //    //Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();  //새문서 만들기(문서 만들면 기본 sheet 생성, 버전따라 생성한 sheet 수가 다름)

        //    //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add(); //sheet 추가
        //    //DataTable dt = (DataTable)dataGridView1.DataSource;

        //    //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //가장 앞에 있는 sheet 하나를 가져와서 참조, dynamic 타입이라 미리 형변환 하는 게 좋음

        //    Excel.Worksheet xlWorkSheet = ExcelUtil.PrintOrderFormTemplateOnWorksheet((Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1), orderToVendor); //가장 앞에 있는 sheet 하나를 가져와서 참조, dynamic 타입이라 미리 형변환 하는 게 좋음

                
        //    xlWorkBook.SaveAs(savefilepath, Excel.XlFileFormat.xlWorkbookNormal); //엑셀 문서를 파일 저장, 상대경로/절대 경로, xls/xlsx 둘 다 가능
        //    xlWorkBook.Close(true);  //엑셀 문서 닫기
        //    xlApp.Quit(); //엑셀 프로그램 종료(해도 프로세스는 남아있음)


        //    //엑셀 프로세스 제거, 릴리즈는 생성순서와 반대로 실행
        //    ExcelUtil.ReleaseObject(xlWorkSheet);
        //    ExcelUtil.ReleaseObject(xlWorkBook);
        //    ExcelUtil.ReleaseObject(xlApp);

        //    return true;
           

        //}



        //private void btnInsert_Click(object sender, EventArgs e)
        //{
        //    InsertOrderToVender frm = new InsertOrderToVender();
        //    frm.MdiParent = this.MdiParent;
        //    frm.Show();
        //}

    }
}
