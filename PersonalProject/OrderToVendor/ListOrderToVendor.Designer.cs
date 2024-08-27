
namespace PersonalProject
{
    partial class ListOrderToVendor
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
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.labelOrderStatus = new System.Windows.Forms.Label();
            this.labelComName = new System.Windows.Forms.Label();
            this.lblComName = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.labelOrderDate = new System.Windows.Forms.Label();
            this.lblRequiredDate = new System.Windows.Forms.Label();
            this.labelPeriod_Date = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.grbOrderProductList = new System.Windows.Forms.GroupBox();
            this.dgvOrderDetail = new System.Windows.Forms.DataGridView();
            this.pnlClear = new System.Windows.Forms.Panel();
            this.cboOrderStatus = new System.Windows.Forms.ComboBox();
            this.dtpPeriod_Date = new System.Windows.Forms.DateTimePicker();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.dgvList.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.grbOrderProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.pnlClear.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPeriod
            // 
            this.labelPeriod.Size = new System.Drawing.Size(53, 12);
            this.labelPeriod.Text = "발주기간";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(761, 47);
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvList
            // 
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvList.Controls.Add(this.dgvOrder);
            this.dgvList.Size = new System.Drawing.Size(812, 410);
            // 
            // btnSubMenu
            // 
            this.btnSubMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubMenu.Location = new System.Drawing.Point(373, 3);
            this.btnSubMenu.Tag = "ListOrderToVendor";
            this.btnSubMenu.Text = "발주관리";
            this.btnSubMenu.UseVisualStyleBackColor = false;
            this.btnSubMenu.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3980, 12);
            // 
            // btnSubMenu2
            // 
            this.btnSubMenu2.Location = new System.Drawing.Point(467, 3);
            this.btnSubMenu2.Tag = "ListStore";
            this.btnSubMenu2.Text = "입고관리";
            this.btnSubMenu2.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(1071, 14);
            //this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(299, 378);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Tag = "InsertOrderToVender";
            this.btnInsert.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetail.Controls.Add(this.grbOrderProductList);
            this.pnlDetail.Controls.Add(this.labelTotalPrice);
            this.pnlDetail.Controls.Add(this.labelPeriod_Date);
            this.pnlDetail.Controls.Add(this.labelOrderDate);
            this.pnlDetail.Controls.Add(this.labelComName);
            this.pnlDetail.Controls.Add(this.labelOrderStatus);
            this.pnlDetail.Controls.Add(this.pnlClear);
            this.pnlDetail.Location = new System.Drawing.Point(830, 99);
            this.pnlDetail.Size = new System.Drawing.Size(392, 410);
            this.pnlDetail.Controls.SetChildIndex(this.txtNumber, 0);
            this.pnlDetail.Controls.SetChildIndex(this.pnlClear, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelOrderStatus, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelComName, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelOrderDate, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelPeriod_Date, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelTotalPrice, 0);
            this.pnlDetail.Controls.SetChildIndex(this.grbOrderProductList, 0);
            this.pnlDetail.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelNumber, 0);
            // 
            // labelNumber
            // 
            this.labelNumber.Location = new System.Drawing.Point(15, 22);
            // 
            // txtNumber
            // 
            this.txtNumber.Visible = false;
            // 
            // btnSubMenu3
            // 
            this.btnSubMenu3.Location = new System.Drawing.Point(560, 3);
            this.btnSubMenu3.Tag = "RequiredOrderList";
            this.btnSubMenu3.Text = "빠른발주";
            this.btnSubMenu3.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // pnlLocalNavigationBar
            // 
            this.pnlLocalNavigationBar.Size = new System.Drawing.Size(1234, 64);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlContent.Size = new System.Drawing.Size(1234, 521);
            // 
            // btnCloses
            // 
            this.btnCloses.Location = new System.Drawing.Point(1164, 14);
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowTemplate.Height = 23;
            this.dgvOrder.Size = new System.Drawing.Size(812, 410);
            this.dgvOrder.TabIndex = 0;
            this.dgvOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellDoubleClick);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(8, 11);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(53, 12);
            this.lblOrderNo.TabIndex = 25;
            this.lblOrderNo.Text = "발주코드";
            // 
            // labelOrderStatus
            // 
            this.labelOrderStatus.AutoSize = true;
            this.labelOrderStatus.Location = new System.Drawing.Point(15, 139);
            this.labelOrderStatus.Name = "labelOrderStatus";
            this.labelOrderStatus.Size = new System.Drawing.Size(53, 12);
            this.labelOrderStatus.TabIndex = 27;
            this.labelOrderStatus.Text = "발주상태";
            // 
            // labelComName
            // 
            this.labelComName.AutoSize = true;
            this.labelComName.Location = new System.Drawing.Point(15, 45);
            this.labelComName.Name = "labelComName";
            this.labelComName.Size = new System.Drawing.Size(41, 12);
            this.labelComName.TabIndex = 28;
            this.labelComName.Text = "거래처";
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Location = new System.Drawing.Point(8, 34);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(41, 12);
            this.lblComName.TabIndex = 30;
            this.lblComName.Text = "거래처";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(8, 80);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(65, 12);
            this.lblOrderDate.TabIndex = 33;
            this.lblOrderDate.Text = "2021-11-07";
            // 
            // labelOrderDate
            // 
            this.labelOrderDate.AutoSize = true;
            this.labelOrderDate.Location = new System.Drawing.Point(15, 91);
            this.labelOrderDate.Name = "labelOrderDate";
            this.labelOrderDate.Size = new System.Drawing.Size(53, 12);
            this.labelOrderDate.TabIndex = 31;
            this.labelOrderDate.Text = "발주날짜";
            // 
            // lblRequiredDate
            // 
            this.lblRequiredDate.AutoSize = true;
            this.lblRequiredDate.Location = new System.Drawing.Point(132, 103);
            this.lblRequiredDate.Name = "lblRequiredDate";
            this.lblRequiredDate.Size = new System.Drawing.Size(65, 12);
            this.lblRequiredDate.TabIndex = 36;
            this.lblRequiredDate.Text = "2021-11-17";
            this.lblRequiredDate.Visible = false;
            // 
            // labelPeriod_Date
            // 
            this.labelPeriod_Date.AutoSize = true;
            this.labelPeriod_Date.Location = new System.Drawing.Point(15, 114);
            this.labelPeriod_Date.Name = "labelPeriod_Date";
            this.labelPeriod_Date.Size = new System.Drawing.Size(41, 12);
            this.labelPeriod_Date.TabIndex = 34;
            this.labelPeriod_Date.Text = "납기일";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(8, 57);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(61, 12);
            this.lblTotalPrice.TabIndex = 39;
            this.lblTotalPrice.Text = "250,000 원";
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Location = new System.Drawing.Point(15, 68);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(29, 12);
            this.labelTotalPrice.TabIndex = 37;
            this.labelTotalPrice.Text = "총액";
            // 
            // grbOrderProductList
            // 
            this.grbOrderProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOrderProductList.Controls.Add(this.dgvOrderDetail);
            this.grbOrderProductList.Location = new System.Drawing.Point(3, 162);
            this.grbOrderProductList.Name = "grbOrderProductList";
            this.grbOrderProductList.Size = new System.Drawing.Size(386, 213);
            this.grbOrderProductList.TabIndex = 40;
            this.grbOrderProductList.TabStop = false;
            this.grbOrderProductList.Text = "발주 물품";
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            this.dgvOrderDetail.RowTemplate.Height = 23;
            this.dgvOrderDetail.Size = new System.Drawing.Size(380, 193);
            this.dgvOrderDetail.TabIndex = 39;
            // 
            // pnlClear
            // 
            this.pnlClear.Controls.Add(this.cboOrderStatus);
            this.pnlClear.Controls.Add(this.dtpPeriod_Date);
            this.pnlClear.Controls.Add(this.lblOrderStatus);
            this.pnlClear.Controls.Add(this.lblTotalPrice);
            this.pnlClear.Controls.Add(this.lblRequiredDate);
            this.pnlClear.Controls.Add(this.lblOrderDate);
            this.pnlClear.Controls.Add(this.lblOrderNo);
            this.pnlClear.Controls.Add(this.lblComName);
            this.pnlClear.Location = new System.Drawing.Point(74, 11);
            this.pnlClear.Name = "pnlClear";
            this.pnlClear.Size = new System.Drawing.Size(200, 162);
            this.pnlClear.TabIndex = 41;
            // 
            // cboOrderStatus
            // 
            this.cboOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderStatus.FormattingEnabled = true;
            this.cboOrderStatus.Location = new System.Drawing.Point(8, 125);
            this.cboOrderStatus.Name = "cboOrderStatus";
            this.cboOrderStatus.Size = new System.Drawing.Size(121, 20);
            this.cboOrderStatus.TabIndex = 39;
            // 
            // dtpPeriod_Date
            // 
            this.dtpPeriod_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriod_Date.Location = new System.Drawing.Point(8, 99);
            this.dtpPeriod_Date.Name = "dtpPeriod_Date";
            this.dtpPeriod_Date.Size = new System.Drawing.Size(100, 21);
            this.dtpPeriod_Date.TabIndex = 38;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(168, 125);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(29, 12);
            this.lblOrderStatus.TabIndex = 37;
            this.lblOrderStatus.Text = "발주";
            this.lblOrderStatus.Visible = false;
            // 
            // ListOrderToVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1234, 585);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListOrderToVendor";
            this.Tag = "";
            this.Text = "발주관리";
            this.Load += new System.EventHandler(this.ListOrderToVendor_Load);
            this.dgvList.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.grbOrderProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.pnlClear.ResumeLayout(false);
            this.pnlClear.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label labelComName;
        private System.Windows.Forms.Label labelOrderStatus;
        private System.Windows.Forms.Label lblRequiredDate;
        private System.Windows.Forms.Label labelPeriod_Date;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label labelOrderDate;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.GroupBox grbOrderProductList;
        private System.Windows.Forms.DataGridView dgvOrderDetail;
        private System.Windows.Forms.Panel pnlClear;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.DateTimePicker dtpPeriod_Date;
        private System.Windows.Forms.ComboBox cboOrderStatus;
    }
}
