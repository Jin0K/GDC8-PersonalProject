
namespace PersonalProject
{
    partial class AddStore
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.grb = new System.Windows.Forms.GroupBox();
            this.dgvNotStore = new System.Windows.Forms.DataGridView();
            this.lblCMT_Unit = new System.Windows.Forms.Label();
            this.lblSTORE_Date = new System.Windows.Forms.Label();
            this.lblMT_Epr_Date = new System.Windows.Forms.Label();
            this.labelMT_Epr_Date = new System.Windows.Forms.Label();
            this.labelSTORE_Qty = new System.Windows.Forms.Label();
            this.lblMTName = new System.Windows.Forms.Label();
            this.labelMTName = new System.Windows.Forms.Label();
            this.labelSTORE_Status = new System.Windows.Forms.Label();
            this.labelSTORE_Date = new System.Windows.Forms.Label();
            this.lblComName = new System.Windows.Forms.Label();
            this.labelComName = new System.Windows.Forms.Label();
            this.lblOrderDetail = new System.Windows.Forms.Label();
            this.dtpSTORE_Date = new System.Windows.Forms.DateTimePicker();
            this.cboSTORE_Status = new System.Windows.Forms.ComboBox();
            this.nuSTORE_Qty = new System.Windows.Forms.NumericUpDown();
            this.pnlClear = new System.Windows.Forms.Panel();
            this.dgvList.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.grb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSTORE_Qty)).BeginInit();
            this.pnlClear.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cboCom
            // 
            this.cboCom.Location = new System.Drawing.Point(156, 46);
            this.cboCom.Size = new System.Drawing.Size(127, 20);
            this.cboCom.SelectedIndexChanged += new System.EventHandler(this.cboCom_SelectedIndexChanged);
            // 
            // labelCompany
            // 
            this.labelCompany.Location = new System.Drawing.Point(156, 24);
            // 
            // cboMt
            // 
            this.cboMt.Size = new System.Drawing.Size(127, 20);
            // 
            // cboState
            // 
            this.cboState.Location = new System.Drawing.Point(300, 46);
            this.cboState.Size = new System.Drawing.Size(149, 20);
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.cboState_SelectedIndexChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(298, 24);
            this.labelStatus.Size = new System.Drawing.Size(77, 12);
            this.labelStatus.Text = "거래처별물품";
            // 
            // dgvList
            // 
            this.dgvList.Controls.Add(this.grb);
            // 
            // btnSubMenu
            // 
            this.btnSubMenu.Tag = "ListOrderToVendor";
            this.btnSubMenu.Text = "발주관리";
            this.btnSubMenu.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnSubMenu2
            // 
            this.btnSubMenu2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubMenu2.Tag = "ListStore";
            this.btnSubMenu2.Text = "입고관리";
            this.btnSubMenu2.UseVisualStyleBackColor = false;
            this.btnSubMenu2.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnExcelExport
            // 
            //this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(15, 460);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(318, 324);
            this.btnUpdate.Size = new System.Drawing.Size(98, 37);
            this.btnUpdate.Text = "입고 등록";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(77, 460);
            this.btnInsert.Tag = "AddStore";
            this.btnInsert.Visible = false;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.labelMT_Epr_Date);
            this.pnlDetail.Controls.Add(this.labelSTORE_Qty);
            this.pnlDetail.Controls.Add(this.labelMTName);
            this.pnlDetail.Controls.Add(this.labelSTORE_Status);
            this.pnlDetail.Controls.Add(this.labelSTORE_Date);
            this.pnlDetail.Controls.Add(this.labelComName);
            this.pnlDetail.Controls.Add(this.pnlClear);
            this.pnlDetail.Controls.SetChildIndex(this.txtNumber, 0);
            this.pnlDetail.Controls.SetChildIndex(this.pnlClear, 0);
            this.pnlDetail.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelNumber, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelComName, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelSTORE_Date, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelSTORE_Status, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelMTName, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelSTORE_Qty, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelMT_Epr_Date, 0);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(59, 18);
            this.txtNumber.Visible = false;
            // 
            // btnSubMenu3
            // 
            this.btnSubMenu3.Tag = "RequiredOrderList";
            this.btnSubMenu3.Text = "빠른발주";
            this.btnSubMenu3.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // grb
            // 
            this.grb.Controls.Add(this.dgvNotStore);
            this.grb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grb.Location = new System.Drawing.Point(0, 0);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(419, 381);
            this.grb.TabIndex = 0;
            this.grb.TabStop = false;
            this.grb.Text = "미완료 입고 목록";
            // 
            // dgvNotStore
            // 
            this.dgvNotStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotStore.Location = new System.Drawing.Point(3, 17);
            this.dgvNotStore.Name = "dgvNotStore";
            this.dgvNotStore.RowTemplate.Height = 23;
            this.dgvNotStore.Size = new System.Drawing.Size(413, 361);
            this.dgvNotStore.TabIndex = 0;
            this.dgvNotStore.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotStore_CellDoubleClick);
            // 
            // lblCMT_Unit
            // 
            this.lblCMT_Unit.AutoSize = true;
            this.lblCMT_Unit.Location = new System.Drawing.Point(148, 227);
            this.lblCMT_Unit.Name = "lblCMT_Unit";
            this.lblCMT_Unit.Size = new System.Drawing.Size(57, 12);
            this.lblCMT_Unit.TabIndex = 70;
            this.lblCMT_Unit.Text = "단위 수량";
            // 
            // lblSTORE_Date
            // 
            this.lblSTORE_Date.AutoSize = true;
            this.lblSTORE_Date.Location = new System.Drawing.Point(11, 263);
            this.lblSTORE_Date.Name = "lblSTORE_Date";
            this.lblSTORE_Date.Size = new System.Drawing.Size(65, 12);
            this.lblSTORE_Date.TabIndex = 68;
            this.lblSTORE_Date.Text = "2021-11-14";
            // 
            // lblMT_Epr_Date
            // 
            this.lblMT_Epr_Date.AutoSize = true;
            this.lblMT_Epr_Date.Location = new System.Drawing.Point(97, 263);
            this.lblMT_Epr_Date.Name = "lblMT_Epr_Date";
            this.lblMT_Epr_Date.Size = new System.Drawing.Size(37, 12);
            this.lblMT_Epr_Date.TabIndex = 67;
            this.lblMT_Epr_Date.Text = "(7 일)";
            // 
            // labelMT_Epr_Date
            // 
            this.labelMT_Epr_Date.AutoSize = true;
            this.labelMT_Epr_Date.Location = new System.Drawing.Point(24, 280);
            this.labelMT_Epr_Date.Name = "labelMT_Epr_Date";
            this.labelMT_Epr_Date.Size = new System.Drawing.Size(53, 12);
            this.labelMT_Epr_Date.TabIndex = 66;
            this.labelMT_Epr_Date.Text = "유통기한";
            // 
            // labelSTORE_Qty
            // 
            this.labelSTORE_Qty.AutoSize = true;
            this.labelSTORE_Qty.Location = new System.Drawing.Point(24, 237);
            this.labelSTORE_Qty.Name = "labelSTORE_Qty";
            this.labelSTORE_Qty.Size = new System.Drawing.Size(53, 12);
            this.labelSTORE_Qty.TabIndex = 63;
            this.labelSTORE_Qty.Text = "입고수량";
            // 
            // lblMTName
            // 
            this.lblMTName.AutoSize = true;
            this.lblMTName.Location = new System.Drawing.Point(11, 177);
            this.lblMTName.Name = "lblMTName";
            this.lblMTName.Size = new System.Drawing.Size(41, 12);
            this.lblMTName.TabIndex = 62;
            this.lblMTName.Text = "항목명";
            // 
            // labelMTName
            // 
            this.labelMTName.AutoSize = true;
            this.labelMTName.Location = new System.Drawing.Point(24, 194);
            this.labelMTName.Name = "labelMTName";
            this.labelMTName.Size = new System.Drawing.Size(29, 12);
            this.labelMTName.TabIndex = 61;
            this.labelMTName.Text = "항목";
            // 
            // labelSTORE_Status
            // 
            this.labelSTORE_Status.AutoSize = true;
            this.labelSTORE_Status.Location = new System.Drawing.Point(24, 151);
            this.labelSTORE_Status.Name = "labelSTORE_Status";
            this.labelSTORE_Status.Size = new System.Drawing.Size(53, 12);
            this.labelSTORE_Status.TabIndex = 60;
            this.labelSTORE_Status.Text = "입고상태";
            // 
            // labelSTORE_Date
            // 
            this.labelSTORE_Date.AutoSize = true;
            this.labelSTORE_Date.Location = new System.Drawing.Point(24, 108);
            this.labelSTORE_Date.Name = "labelSTORE_Date";
            this.labelSTORE_Date.Size = new System.Drawing.Size(41, 12);
            this.labelSTORE_Date.TabIndex = 58;
            this.labelSTORE_Date.Text = "입고일";
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Location = new System.Drawing.Point(11, 48);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(41, 12);
            this.lblComName.TabIndex = 57;
            this.lblComName.Text = "거래처";
            // 
            // labelComName
            // 
            this.labelComName.AutoSize = true;
            this.labelComName.Location = new System.Drawing.Point(24, 65);
            this.labelComName.Name = "labelComName";
            this.labelComName.Size = new System.Drawing.Size(41, 12);
            this.labelComName.TabIndex = 56;
            this.labelComName.Text = "거래처";
            // 
            // lblOrderDetail
            // 
            this.lblOrderDetail.AutoSize = true;
            this.lblOrderDetail.Location = new System.Drawing.Point(11, 5);
            this.lblOrderDetail.Name = "lblOrderDetail";
            this.lblOrderDetail.Size = new System.Drawing.Size(85, 12);
            this.lblOrderDetail.TabIndex = 71;
            this.lblOrderDetail.Text = "발주 상세 번호";
            // 
            // dtpSTORE_Date
            // 
            this.dtpSTORE_Date.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpSTORE_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSTORE_Date.Location = new System.Drawing.Point(11, 85);
            this.dtpSTORE_Date.Name = "dtpSTORE_Date";
            this.dtpSTORE_Date.Size = new System.Drawing.Size(136, 21);
            this.dtpSTORE_Date.TabIndex = 72;
            this.dtpSTORE_Date.ValueChanged += new System.EventHandler(this.dtpSTORE_Date_ValueChanged);
            // 
            // cboSTORE_Status
            // 
            this.cboSTORE_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSTORE_Status.FormattingEnabled = true;
            this.cboSTORE_Status.Location = new System.Drawing.Point(13, 131);
            this.cboSTORE_Status.Name = "cboSTORE_Status";
            this.cboSTORE_Status.Size = new System.Drawing.Size(121, 20);
            this.cboSTORE_Status.TabIndex = 73;
            this.cboSTORE_Status.SelectedValueChanged += new System.EventHandler(this.cboSTORE_Status_SelectedValueChanged);
            // 
            // nuSTORE_Qty
            // 
            this.nuSTORE_Qty.Location = new System.Drawing.Point(11, 218);
            this.nuSTORE_Qty.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nuSTORE_Qty.Name = "nuSTORE_Qty";
            this.nuSTORE_Qty.Size = new System.Drawing.Size(120, 21);
            this.nuSTORE_Qty.TabIndex = 74;
            this.nuSTORE_Qty.ThousandsSeparator = true;
            this.nuSTORE_Qty.ValueChanged += new System.EventHandler(this.nuSTORE_Qty_ValueChanged);
            // 
            // pnlClear
            // 
            this.pnlClear.Controls.Add(this.lblMT_Epr_Date);
            this.pnlClear.Controls.Add(this.lblSTORE_Date);
            this.pnlClear.Controls.Add(this.nuSTORE_Qty);
            this.pnlClear.Controls.Add(this.lblOrderDetail);
            this.pnlClear.Controls.Add(this.lblCMT_Unit);
            this.pnlClear.Controls.Add(this.cboSTORE_Status);
            this.pnlClear.Controls.Add(this.lblComName);
            this.pnlClear.Controls.Add(this.dtpSTORE_Date);
            this.pnlClear.Controls.Add(this.lblMTName);
            this.pnlClear.Location = new System.Drawing.Point(83, 17);
            this.pnlClear.Name = "pnlClear";
            this.pnlClear.Size = new System.Drawing.Size(271, 289);
            this.pnlClear.TabIndex = 75;
            // 
            // AddStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Name = "AddStore";
            this.Tag = "";
            this.Text = "입고등록";
            this.Load += new System.EventHandler(this.AddStore_Load);
            this.dgvList.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.grb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuSTORE_Qty)).EndInit();
            this.pnlClear.ResumeLayout(false);
            this.pnlClear.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb;
        private System.Windows.Forms.DataGridView dgvNotStore;
        private System.Windows.Forms.Label lblCMT_Unit;
        private System.Windows.Forms.Label lblSTORE_Date;
        private System.Windows.Forms.Label lblMT_Epr_Date;
        private System.Windows.Forms.Label labelMT_Epr_Date;
        private System.Windows.Forms.Label labelSTORE_Qty;
        private System.Windows.Forms.Label lblMTName;
        private System.Windows.Forms.Label labelMTName;
        private System.Windows.Forms.Label labelSTORE_Status;
        private System.Windows.Forms.Label labelSTORE_Date;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.Label labelComName;
        private System.Windows.Forms.NumericUpDown nuSTORE_Qty;
        private System.Windows.Forms.ComboBox cboSTORE_Status;
        private System.Windows.Forms.DateTimePicker dtpSTORE_Date;
        private System.Windows.Forms.Label lblOrderDetail;
        private System.Windows.Forms.Panel pnlClear;
    }
}
