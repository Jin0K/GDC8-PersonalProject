using PersonalProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

//using Excel = Microsoft.Office.Interop.Excel;


namespace PersonalProject
{
    public partial class InsertOrderToVender : BaseListDetail
    {
        OrderToVendorService otvServ = null;
        List<ComMtrVO> comMtrList = null; //항목에 따른 거래처 목록(COM_MTR)
        List<OrderDetailVO> cartList = null; //장바구니목록
        List<CommonVO> cmtList; //거래처별 거래물품 목록(id, 이름)

        //엑셀 출력 시 필요한 파라미터
        OrderToVendorVO orderToVendor; //발주내용
        string saveFilePath; //저장할 파일 경로
        string openFilePath; //발주서 엑셀 템플릿을 열 파일 경로

        public InsertOrderToVender()
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

        private void InsertOrderToVender_Load(object sender, EventArgs e)
        {
            CommonService comServ = new CommonService();

            #region 코드 데이터들을 조회해서 콤보박스 바인딩

            string[] gubuns = { "Material", "Company", "COM_MTR_ID" };

            List<CommonVO> list = comServ.GetCodeList(gubuns);

            cmtList = list.FindAll((item) => item.Category.Equals("COM_MTR_ID"));

            CommonUtil.ComboBinding(cboMT, list, "Material", blankText: "전체");
            CommonUtil.ComboBinding(cboCOM, list, "Company", blankText: "선택");
            #endregion

            #region 거래처 목록 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvCompanyList);
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "업체번호", "COM_No", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "거래처명", "COM_Name");
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "거래처별 물품번호", "COM_MTR_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "물품명", "COM_MTR_Name");
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "물품단가", "MT_Price", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "규격", "MT_Min_Order", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "단가단위", "Unit_Name");
            DataGridViewUtil.AddGridTextColumn(dgvCompanyList, "거래단위", "MT_Unit", visibility: false);

            #endregion

            #region 장바구니 데이터그리드뷰 컬럼 셋팅
            DataGridViewUtil.SetInitGridView(dgvCart);
            DataGridViewUtil.AddGridTextColumn(dgvCart, "물품번호", "COM_MTR_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvCart, "물품명", "MT_Name");
            DataGridViewUtil.AddGridTextColumn(dgvCart, "주문량", "ORDER_Qty", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dgvCart, "주문단위", "ORDER_Unit", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvCart, "주문단위", "Unit_Name", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvCart, "비용", "ORDER_Price", DataGridViewContentAlignment.MiddleRight, colWidth: 80);
            #endregion

            dgvCompanyList.SelectionMode = dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 특정 cell 하나를 클릭해도, 줄 전체가 선택
            ClearControls(grbOrderCalc); //발주 수량 계산 초기화
            dtpRequiredDate.MinDate = DateTime.Now.AddDays(1); //납기요청일은 최소 내일

            lblSum.Text = "";
        }

        private void ClearControls(GroupBox grb)
        {
            foreach (Control ctrl in grb.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Name.StartsWith("lbl"))
                        lbl.Text = "";
                }
                else if (ctrl is NumericUpDown nud)
                    nud.Value = 0;
                else if (ctrl is TextBox txt)
                    txt.Text = "";
                else if (ctrl is ComboBox cbo)
                    cbo.SelectedIndex = 0;
                else if (ctrl is DateTimePicker dtp)
                    dtp.Value = DateTime.Now;
            }
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboMT.SelectedIndex < 0) return;

            if (comMtrList == null)
            {
                otvServ = new OrderToVendorService();
                comMtrList = otvServ.GetAllCompaniesByMT();
            }

            dgvCompanyList.DataSource = null;
            if (cboMT.SelectedIndex == 0)
                dgvCompanyList.DataSource = comMtrList;
            else
                dgvCompanyList.DataSource = comMtrList.Where((item) => item.MT_Code.Equals(Convert.ToInt32(cboMT.SelectedValue))).ToList();
            dgvCompanyList.ClearSelection();
        }

        private void dgvCompanyList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //유효성체크
            if (e.RowIndex < 0) return;

            ClearControls(grbOrderCalc);
            //2. 주문내역정보를 조회해서 컨트롤에 바인딩
            OrderCalcVO orc = otvServ.GetOrderCalcDetail(Convert.ToInt32(dgvCompanyList["COM_MTR_ID", e.RowIndex].Value));
            //Find():EF에서 데이터테이블에만 존재하는 행들도 조회
            //FirstOrDefault(): EF에서 DB에 반영된 행들만 조회
            //OrderCalcVO order = orgList.Find((item) => item.OrderID == ordID);
            if (orc != null)
            {
                lblCOM.Text = dgvCompanyList["COM_Name", e.RowIndex].Value.ToString();
                lblComMTRUnit.Text = orc.ComMtr.Unit_Name;
                lblComMTRUnitPrice.Text = $"원/{orc.ComMtr.Unit_Name}";
                lblMT.Text = orc.ComMtr.COM_MTR_Name; //dgvCompanyList["MT_Name", e.RowIndex].Value.ToString();
                lblMTMinOrder.Text = orc.ComMtr.MT_Min_Order.ToString("#,##0");
                lblMTPrice.Text = orc.ComMtr.MT_Price.ToString("#,##0");
                lblMTUnit.Text = orc.Prod.Unit_Name;
                lblMTQty.Text = $"실재고량 : {orc.Prod.Mt_Qty.ToString("#,##0")}{orc.Prod.Unit_Name}"; //실재고량 → 빠른발주 폼 끝나면 논리 재고량으로 수정

                //lblOrderQty
                //lblTotalPrice

                ////선택된 주문의 상태가 배송전, 배송후
                //if (order.ShipVia == null || order.Freight == null)
                //{
                //    //배송전
                //    cboShipper.SelectedValue = "";
                //    dtpShippedDate.Format = DateTimePickerFormat.Short;
                //    dtpShippedDate.Value = DateTime.Now;
                //    txtFreight.Text = "";

                //    btnShip.Enabled = true;
                //    btnDelete.Enabled = true;
                //}
                //else
                //{
                //    //배송후
                //    cboShipper.SelectedValue = order.ShipVia.ToString();
                //    txtFreight.Text = order.Freight.ToString();
                //    //배송일이 널인 데이터는 배송일을 빈값으로 보여준다.
                //    if (order.ShippedDate == null)
                //    {
                //        dtpShippedDate.Format = DateTimePickerFormat.Custom;
                //        dtpShippedDate.CustomFormat = " ";
                //    }
                //    else
                //    {
                //        dtpShippedDate.Format = DateTimePickerFormat.Short;
                //        dtpShippedDate.Value = Convert.ToDateTime(order.ShippedDate);
                //    }

                //    btnShip.Enabled = false;
                //    btnDelete.Enabled = false;
            }
        }

        private void nuQty_ValueChanged(object sender, EventArgs e)
        {
            //유효성체크
            if (lblMT.Text.Length < 1)
            {
                if (nuQty.Value != 0)
                    nuQty.Value = 0;
                return;
            }
            if (nuQty.Value <= 0)
            {
                lblOrderQty.Text = "0";
                lblTotalPrice.Text = "0";
                return;
            }

            double conversion = CommonUtil.UnitNameConversion(lblMTUnit.Text, lblComMTRUnitPrice.Text.Replace("원", "").Replace("/", "")); //단위 계산

            double wantQty = (double)nuQty.Value * conversion; //필요 항목 수량
            //double wantQty = Math.Ceiling((double)nuQty.Value * conversion); //필요 항목 수량
            int min = lblMTMinOrder.Text.OriginalInt(); //주문 단위
            int orderQty, i = 2; //주문단위, 개수
            if (min > 1) //주문 단위가 있는 경우
            {
                if (wantQty <= min) //주문 단위보다 필요 수량이 작거나 같은 경우
                {
                    orderQty = min;
                }
                else
                {
                    //계산

                    while ((min * i) < wantQty) //주문단위*개수가 필요수량보다 같거나 커질 때까지
                    {
                        i++;
                    }
                    orderQty = min * i;
                }
            }
            else
            {
                orderQty = Convert.ToInt32(Math.Ceiling(wantQty));
            }

            lblEA.Text = lblComMTRUnit.Text;
            lblWon.Text = "원";
            lblOrderQty.Text = orderQty.ToString("#,##0");
            lblTotalPrice.Text = (lblOrderQty.Text.OriginalInt() * lblMTPrice.Text.OriginalInt()).ToString("#,##0");
        }

        private void cboCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //데이터바인딩을 할때도 SelectedIndexChanged 이벤트는 발생하므로
            if (cboCOM.SelectedIndex < 1) return;

            if (cartList != null)
            {
                //if (MessageBox.Show("발주 물품을 초기화하시겠습니까?", "발주 예정 목록 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                cartList.Clear();
                dgvCart.DataSource = null;
                //cboComMtr.SelectedIndex = 0;
                //}
                //else
                //    return;
            }

            //전체 목록을 조회
            if (comMtrList == null)
            {
                otvServ = new OrderToVendorService();
                comMtrList = otvServ.GetAllCompaniesByMT();
            }

            int selComNo = Convert.ToInt32(cboCOM.SelectedValue);

            //var list = (from com in comMtrList
            //            where com.COM_No == selComNo
            //            select
            //            new CommonVO
            //            {
            //                Code = com.COM_MTR_ID.ToString(),
            //                Name = com.MT_Name,
            //                Category = "TBL_COM_MTR"
            //            }).ToList();

            var idList = (from com in comMtrList
                          where com.COM_No == selComNo
                          select com.COM_MTR_ID.ToString()).ToList();

            List<CommonVO> cmtCombo = (from item in cmtList
                                       where idList.Contains(item.Code)
                                       select item).ToList();


            CommonUtil.ComboBinding(cboComMtr, cmtCombo, "COM_MTR_ID", blankText: "선택");

        }

        private void cboComMtr_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 선택된 제품이 있는 경우, 
            if (cboComMtr.SelectedIndex > 0)
            {
                int comMtrCode = Convert.ToInt32(cboComMtr.SelectedValue);

                var selProd = comMtrList.FirstOrDefault(prod => prod.COM_MTR_ID == comMtrCode);
                if (selProd != null)
                {
                    txtMTUnit.Tag = selProd.MT_Unit;
                    txtMTUnit.Text = selProd.Unit_Name;
                    txtMTPrice.Text = selProd.MT_Price.ToString("c");
                    nuOrderQty.Value = 0;
                    nuOrderQty.Increment = (selProd.MT_Min_Order > 0) ? selProd.MT_Min_Order : 1;
                    txtMTMinOrder.Text = (selProd.MT_Min_Order > 0) ? selProd.MT_Min_Order.ToString("#,##0") : "1";
                }

                //var list = (from prod in prodAllList
                //            where prod.ProductID == prodId
                //            select prod).ToList();
                //if (list.Count > 0)
                //{
                //    txtQuantityPerUnit.Text = list[0].QuantityPerUnit;
                //    txtUnitPrice.Text = list[0].UnitPrice.ToString();
                //}
            }
            else
            {
                txtMTUnit.Text = txtMTMinOrder.Text = txtMTPrice.Text = "";
                nuOrderQty.Value = 0;
            }
        }

        private void btnCartAdd_Click(object sender, EventArgs e)
        {
            //유효성체크(제품선택은 했는지, 주문수량이 0 이상인지)
            if (cboComMtr.SelectedIndex < 1 || nuOrderQty.Value < 1)
            {
                MessageBox.Show("발주 목록에 추가할 제품이나 수량을 선택하여 주십시오.");
                return;
            }

            //처리로직
            if (cartList == null)
            {
                cartList = new List<OrderDetailVO>();
            }

            int comMtrCode = Convert.ToInt32(cboComMtr.SelectedValue);
            int idx = cartList.FindIndex((prod) => prod.COM_MTR_ID == comMtrCode);
            if (idx >= 0)
            {
                //이미 선택된 제품이 장바구니에 추가하는 경우
                cartList[idx].ORDER_Qty += (int)nuOrderQty.Value;
                cartList[idx].ORDER_Price = Convert.ToInt32(txtMTPrice.Text.OriginalInt() * cartList[idx].ORDER_Qty);
            }
            else
            {
                cboMT.SelectedIndex = cboMT.FindStringExact(cboComMtr.Text.Substring(0, cboComMtr.Text.LastIndexOf('(')));

                //신규로 제품을 장바구니 추가하는 경우
                OrderDetailVO newItem = new OrderDetailVO
                {
                    COM_MTR_ID = comMtrCode,
                    MT_Code = Convert.ToInt32(cboMT.SelectedValue),
                    MT_Name = cboComMtr.Text,
                    ORDER_Unit = txtMTUnit.Tag.ToString(),
                    ORDER_Qty = (int)nuOrderQty.Value,
                    ORDER_Price = Convert.ToInt32(txtMTPrice.Text.OriginalInt() * nuOrderQty.Value),
                    Unit_Name = txtMTUnit.Text,
                    MT_Min_Order = (int)nuOrderQty.Increment
                };
                cartList.Add(newItem);
            }

            //cartList를 dgvCart에 바인딩
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartList;
            dgvCart.ClearSelection();

            cboComMtr.SelectedIndex = 0;
            lblSum.Text = $"총 금액 : {cartList.Select(x => x.ORDER_Price).Sum().ToString("#,##0")} 원";
        }

        private void btnCartDel_Click(object sender, EventArgs e)
        {
            //유효성검사(삭제할 제품을 선택했는지)
            if (dgvCart.SelectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 제품을 선택하여 주십시오.");
                return;
            }

            int prodId = Convert.ToInt32(dgvCart.SelectedRows[0].Cells["COM_MTR_ID"].Value);
            if (MessageBox.Show($"{prodId}를 삭제 하시겠습니까?", "발주 물품 삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            //처리
            int idx = cartList.FindIndex((prod) => prod.COM_MTR_ID == prodId);
            if (idx >= 0)
            {
                cartList.RemoveAt(idx);

                dgvCart.DataSource = null;
                dgvCart.DataSource = cartList;
            }
            lblSum.Text = $"총 금액 : {cartList.Select(x => x.ORDER_Price).Sum().ToString("#,##0")} 원";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OrderToVendorVO order = BeforeExport();
            if (order.OrderM == null) return;

            bool result = otvServ.RegisterOrder(order.OrderM, cartList);
            if (result)
            {
                cartList.Clear();
                dgvCart.DataSource = null;
                cboComMtr.SelectedIndex = 0;
                lblSum.Text = "";

                MessageBox.Show("주문이 완료되었습니다.");
            }
            else
            {
                MessageBox.Show("주문처리 중 오류가 발생했습니다. 다시 시도하여 주십시오.");
            }
        }

        private OrderToVendorVO BeforeExport()
        {
            //유효성체크(고객, 사원 선택여부 / cartList의 건수가 있는지)
            if (cboCOM.SelectedIndex < 1)
            {
                MessageBox.Show("거래처를 선택하여 주십시오.");
                return null;
            }

            if (cartList == null || cartList.Count < 1)
            {
                MessageBox.Show("주문할 제품을 선택하여 주십시오.");
                return null;
            }

            //처리로직(OrderVO, List<OrderDetailVO>)
            OrderVO order = new OrderVO
            {
                COM_No = Convert.ToInt32(cboCOM.SelectedValue),
                COM_Name = cboCOM.Text,
                ORDER_Price = cartList.Sum((elem) => elem.ORDER_Price),
                Period_Date = dtpRequiredDate.Value
            };

            OrderToVendorVO orderToVendor = new OrderToVendorVO
            {
                OrderM = order,
                OrderD = cartList
            };

            return orderToVendor;
        }

        //private void btnExcelExport_Click(object sender, EventArgs e)
        //{
        //    OrderToVendorVO orderToVendor = BeforeExport();
        //    if (orderToVendor.OrderM == null) return;


        //    //저장할 디렉토리, 파일명을 물어보고, 그 파일경로로 엑셀파일 저장
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.Filter = "Excel Files(*.xls)|*.xls";
        //    dlg.Title = "엑셀파일로 내보내기";

        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        string filePath = Application.StartupPath + @"\Templates\OrderFormTemplate.xls";
        //        //string openPath = @"/Templates/OrderFormTemplate.xls";
        //        if (!File.Exists(filePath))
        //        {
        //            MessageBox.Show("템플릿 파일이 존재하지 않습니다.");
        //            return;
        //        }

        //        this.orderToVendor = orderToVendor;
        //        saveFilePath = dlg.FileName;
        //        openFilePath = filePath;
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
        //    Excel.Application xlApp = new Excel.Application(); //엑셀 실행
        //    Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(openFilePath);
        //    //Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();  //새문서 만들기(문서 만들면 기본 sheet 생성, 버전따라 생성한 sheet 수가 다름)

        //    //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add(); //sheet 추가
        //    //DataTable dt = (DataTable)dataGridView1.DataSource;

        //    //Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //가장 앞에 있는 sheet 하나를 가져와서 참조, dynamic 타입이라 미리 형변환 하는 게 좋음

        //    Excel.Worksheet xlWorkSheet = ExcelUtil.PrintOrderFormTemplateOnWorksheet((Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1), orderToVendor); //가장 앞에 있는 sheet 하나를 가져와서 참조, dynamic 타입이라 미리 형변환 하는 게 좋음



        //    xlWorkBook.SaveAs(saveFilePath, Excel.XlFileFormat.xlWorkbookNormal); //엑셀 문서를 파일 저장, 상대경로/절대 경로, xls/xlsx 둘 다 가능
        //    xlWorkBook.Close(true);  //엑셀 문서 닫기
        //    xlApp.Quit(); //엑셀 프로그램 종료(해도 프로세스는 남아있음)


        //    //엑셀 프로세스 제거, 릴리즈는 생성순서와 반대로 실행
        //    ExcelUtil.ReleaseObject(xlWorkSheet);
        //    ExcelUtil.ReleaseObject(xlWorkBook);
        //    ExcelUtil.ReleaseObject(xlApp);

        //    MessageBox.Show("엑셀 다운로드 완료");
        //}

        private void nuOrderQty_Leave(object sender, EventArgs e)
        {
            int multiple = txtMTMinOrder.Text.OriginalInt();

            if (nuOrderQty.Value % multiple != 0)
            {
                nuOrderQty.Value = Math.Ceiling(nuOrderQty.Value / multiple) * multiple;
            }

        }
    }
}
