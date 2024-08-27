using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PersonalProject
{
    public partial class AddStore : BaseSelectForm
    {
        StoreService strServ = null;
        string savefilepath; //엑셀 저장 경로
        //List<OrderInfoDetailVO> list;
        int mt_epr_date;

        public AddStore()
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

        private void AddStore_Load(object sender, EventArgs e)
        {
            CommonService comServ = new CommonService();

            #region 코드 데이터들을 조회해서 콤보박스 바인딩

            string[] gubuns = { "Material", "Company", "COM_MTR_ID" , "입고상태" };

            List<CommonVO> list = comServ.GetCodeList(gubuns);

            CommonUtil.ComboBinding(cboMt, list, "Material", blankText: "전체");
            CommonUtil.ComboBinding(cboCom, list, "Company", blankText: "전체");

            var cmtList = list.FindAll((cmt)=> cmt.Category== "COM_MTR_ID" && cmt.P_Code == "2");
            CommonUtil.ComboBinding(cboState, cmtList, "COM_MTR_ID", blankText: "전체");

            List<CommonVO> storeStatusList = list.FindAll((cbo) => cbo.Category == "입고상태" && cbo.Name.Contains("입고"));
            CommonUtil.ComboBinding(cboSTORE_Status, storeStatusList, "입고상태", blankText: "선택");
            #endregion

            //발주상세코드, 거래처, 항목명, 수량, 단위, 입고예정일, 발주날짜 + 항목 단위, 유통기한
            #region 입고 미완료 목록 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvNotStore);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "발주번호", "ORDER_No", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "발주상세번호", "ORDER_Detail", DataGridViewContentAlignment.MiddleCenter, colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "거래처 번호", "COM_No", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "거래처명", "COM_Name");
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "거래처별 물품번호", "COM_MTR_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "물품 번호", "MT_Code", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "물품명", "COM_MTR_Name");
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "주문량", "ORDER_Qty", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "주문량 단위", "ORDER_Unit", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "단위이름", "Unit_Name");
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "규격", "MT_Min_Order", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "발주날짜", "ORDER_Date");
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "납기날짜", "Period_Date");
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "발주상태", "Status_Name", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "발주상태", "ORDER_Status", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "유효 유통 기간", "MT_Epr_Date", visibility: false);
            //DataGridViewUtil.AddGridTextColumn(dgvNotStore, "물품단위", "MT_Unit", visibility: false);
            //DataGridViewUtil.AddGridTextColumn(dgvNotStore, "물품단위이름", "MT_Unit_Name", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNotStore, "발주 상세 번호의 총 입고 수량", "STORE_Qty", visibility: false);
            #endregion

            dtpSTORE_Date.MaxDate = DateTime.Today.AddDays(1).AddTicks(-1);
            cboCom.Enabled = cboState.Enabled = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string mtCode = cboMt.SelectedValue.ToString();
            string comNo = cboCom.SelectedValue.ToString();
            string cmtId = cboState.SelectedValue.ToString();
            string dtFrom = ucPeriod.From;
            string dtTo = ucPeriod.To;

            if (strServ == null)
            {
                strServ = new StoreService();
            }

            List<OrderInfoDetailVO> list = strServ.GetOrderSearchList(comNo, mtCode, cmtId, dtFrom, dtTo);
            dgvNotStore.DataSource = null;
            dgvNotStore.DataSource = list;
            dgvNotStore.ClearSelection();

            CommonUtil.ClearControls(pnlClear);
            mt_epr_date = 0;
            if (! btnExcelExport.Enabled)
                btnExcelExport.Enabled = true;

        }

        private void dgvNotStore_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //유효성체크
            if (e.RowIndex < 0) return;

            //if (strServ == null)
            //    strServ = new StoreService();

            //상세주문정보를 조회
            //strServ = strServ.GetOrderDetailList(ordID);

            ////Find():EF에서 데이터테이블에만 존재하는 행들도 조회
            ////FirstOrDefault(): EF에서 DB에 반영된 행들만 조회


            ////주문내역정보를 조회해서 컨트롤에 바인딩
            if (dgvNotStore["ORDER_Detail", e.RowIndex].Value != null)
            {
                //int ordID = Convert.ToInt32(dgvNotStore["ORDER_Detail", e.RowIndex].Value);
                //OrderVO order = orderToVendor.OrderM;
                //OrderDetailVO details = orderToVendor.OrderD;
                //dgvOrderDetail.DataSource = details; //상세주문정보를 데이터그리드뷰에 바인딩
                //dgvOrderDetail.ClearSelection();
                lblComName.Tag = dgvNotStore["COM_No", e.RowIndex].Value;
                lblComName.Text = dgvNotStore["COM_Name", e.RowIndex].Value.ToString();
                lblMTName.Tag = dgvNotStore["MT_Code", e.RowIndex].Value;
                lblMTName.Text = dgvNotStore["COM_MTR_Name", e.RowIndex].Value.ToString();
                lblCMT_Unit.Text = dgvNotStore["Unit_Name", e.RowIndex].Value.ToString();
                lblCMT_Unit.Tag = dgvNotStore["ORDER_Unit", e.RowIndex].Value.ToString();
                lblOrderDetail.Text = dgvNotStore["ORDER_Detail", e.RowIndex].Value.ToString();
                lblOrderDetail.Tag = dgvNotStore["ORDER_No", e.RowIndex].Value;

                mt_epr_date = Convert.ToInt32(dgvNotStore["MT_Epr_Date", e.RowIndex].Value);
                lblMT_Epr_Date.Text = $"({dgvNotStore["MT_Epr_Date", e.RowIndex].Value} 일)";
                lblSTORE_Date.Text = DateTime.Now.AddDays((double)mt_epr_date).ToShortDateString();

                cboSTORE_Status.SelectedIndex = 0;
                
                nuSTORE_Qty.Increment = Convert.ToInt32(dgvNotStore["MT_Min_Order", e.RowIndex].Value);
                nuSTORE_Qty.Value = 0;
                int notInQty = Convert.ToInt32(dgvNotStore["ORDER_Qty", e.RowIndex].Value) - Convert.ToInt32(dgvNotStore["STORE_Qty", e.RowIndex].Value);
                //if (lblCMT_Unit.Tag.Equals(dgvNotStore["ORDER_Unit", e.RowIndex].Value))
                //{
                    nuSTORE_Qty.Maximum = notInQty;
                //}
                //else
                //{
                //    double conv = CommonUtil.UnitCodeConversion(dgvNotStore["ORDER_Unit", e.RowIndex].Value.ToString(), lblCMT_Unit.Tag.ToString());
                //    nuSTORE_Qty.Maximum = (decimal)(notInQty * conv);
                //}
                //lblOrderNo.Text = order.ORDER_No.ToString();
                //lblComName.Text = order.COM_Name;
                //lblOrderDate.Text = order.ORDER_Date.ToShortDateString();
                //lblOrderStatus.Tag = order.ORDER_Status;

                //List<CommonVO> orderStatusList = new List<CommonVO>();
                //CommonVO cbo = new CommonVO
                //{
                //    Name = lblOrderStatus.Text = order.Status_Name,
                //    Code = order.ORDER_Status
                //};
                //orderStatusList.Add(cbo);
                //if (order.Status_Name == "발주") // || order.Status_Name == "발주취소"
                //{
                //    cboOrderStatus.Enabled = true;
                //    cbo = new CommonVO
                //    {
                //        Name = "발주취소", // (order.Status_Name == "발주")?"발주취소":"발주",
                //        Code = "ODR4" //(order.Status_Name == "발주")?"ODR4": "ODR3"
                //    };
                //    orderStatusList.Add(cbo);
                //}
                //else
                //{
                //    cboOrderStatus.Enabled = false;
                //}

                //cboOrderStatus.DisplayMember = "Name";
                //cboOrderStatus.ValueMember = "Code";
                //cboOrderStatus.DataSource = orderStatusList;
                //cboOrderStatus.SelectedIndex = cboOrderStatus.FindStringExact(order.Status_Name);

                //if (lblOrderStatus.Text == "발주취소")
                //    btnUpdate.Enabled = false;
                //else
                //    btnUpdate.Enabled = true;

                //lblRequiredDate.Text = order.Period_Date.ToShortDateString();
                //dtpPeriod_Date.Value = order.Period_Date;
                //dtpPeriod_Date.MinDate = order.ORDER_Date;
                //lblTotalPrice.Text = order.ORDER_Price.ToString("#,##0") + " 원";

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

                //if (!btnExcelExport.Enabled)
                //    btnExcelExport.Enabled = true;


            }
        }

        private void nuSTORE_Qty_ValueChanged(object sender, EventArgs e)
        {
            if(nuSTORE_Qty.Value == nuSTORE_Qty.Maximum)
            {
                cboSTORE_Status.SelectedIndex = cboSTORE_Status.FindStringExact("입고");
            }
            else
            {
                cboSTORE_Status.SelectedIndex = cboSTORE_Status.FindStringExact("부분입고");
            }
        }

        private void cboCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboCom.SelectedIndex) > 0)
            {
                cboState.Enabled = false;
                if(Convert.ToInt32(cboState.SelectedIndex) > 0)
                    cboState.SelectedIndex = 0;
                
            }
            else
            {
                if (!cboState.Enabled) cboState.Enabled = true;
            }
        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboState.SelectedIndex) > 0)
            {
                cboCom.Enabled = false;
                if (Convert.ToInt32(cboCom.SelectedIndex) > 0)
                    cboCom.SelectedIndex = 0;
            }
            else
            {
                if (!cboCom.Enabled) cboCom.Enabled = true;
            }
        }


        private void cboSTORE_Status_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSTORE_Status.SelectedIndex < 0) return;
            if(cboSTORE_Status.SelectedValue.ToString() == "STR1")
            {
                nuSTORE_Qty.Value = nuSTORE_Qty.Maximum;
            }
            else
            {
                if(nuSTORE_Qty.Value != 0)
                    nuSTORE_Qty.Value = 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //유효성체크

            if(lblOrderDetail.Text.Length < 1)
            {
                MessageBox.Show("입고할 물품을 선택하여 주십시오.");
                return;
            }

            if (cboSTORE_Status.SelectedIndex < 1)
            {
                MessageBox.Show("입고 상태를 선택하여 주십시오.");
                return;
            }

            if (nuSTORE_Qty.Value < 1)
            {
                MessageBox.Show("입고 수량을 입력하여 주십시오.");
                return;
            }

            if (dtpSTORE_Date.Value > DateTime.Now)
            {
                MessageBox.Show("입고일은 실제로 받은 날짜만 입력할 수 있습니다.");
                return;
            }



            //처리로직
            StoreVO store = new StoreVO
            {
                //COM_No, STORE_Date, STORE_Status
                COM_No = Convert.ToInt32(lblComName.Tag),
                STORE_Date = dtpSTORE_Date.Value,
                STORE_Status = cboSTORE_Status.SelectedValue.ToString()
            };

            StoreDetailVO detail = new StoreDetailVO
            {
                //MT_Code, STORE_Qty, STORE_Unit, Epr_Date, Stored_Qty, ORDER_No, ORDER_Detail
                MT_Code = Convert.ToInt32(lblMTName.Tag),
                STORE_Qty = Convert.ToInt32(nuSTORE_Qty.Value),
                STORE_Unit = lblCMT_Unit.Tag.ToString(),
                Epr_Date = dtpSTORE_Date.Value.AddDays(lblMT_Epr_Date.Text.OriginalInt()),
                Stored_Qty = Convert.ToInt32(nuSTORE_Qty.Value),
                ORDER_No = Convert.ToInt32(lblOrderDetail.Tag),
                ORDER_Detail = Convert.ToInt32(lblOrderDetail.Text),
            };

            bool result = strServ.RegisterStore(store, detail);
            if (result)
            {
                CommonUtil.ClearControls(pnlClear);
                dgvNotStore.DataSource = null;
                btnSelect.PerformClick();

                MessageBox.Show("입고처리되었습니다.");
            }
            else
            {
                MessageBox.Show("입고 등록 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void dtpSTORE_Date_ValueChanged(object sender, EventArgs e)
        {
            lblSTORE_Date.Text = DateTime.Now.AddDays((double)mt_epr_date).ToShortDateString();
        }

        //private void btnExcelExport_Click(object sender, EventArgs e)
        //{
        //    // 유효성검사
        //    if (dgvNotStore.DataSource == null)
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

        //    success = ExcelUtil.ExportExcelToList<OrderInfoDetailVO>((List<OrderInfoDetailVO>)dgvNotStore.DataSource, savefilepath, DataGridViewUtil.GetDataGridViewPropName(dgvNotStore));

        //    if (success)
        //        MessageBox.Show("엑셀 다운로드 완료");

        //}
    }
}
