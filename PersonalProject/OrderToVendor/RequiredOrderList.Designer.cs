
namespace PersonalProject
{
    partial class RequiredOrderList
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.rdoNeedAll = new System.Windows.Forms.RadioButton();
            this.rdoOrder = new System.Windows.Forms.RadioButton();
            this.rdoSafe = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.labelLookup = new System.Windows.Forms.Label();
            this.grbNeedList = new System.Windows.Forms.GroupBox();
            this.dgvNeed = new System.Windows.Forms.DataGridView();
            this.btnAllOrder = new System.Windows.Forms.Button();
            this.btnSelectiveOrder = new System.Windows.Forms.Button();
            this.nuExtra = new System.Windows.Forms.NumericUpDown();
            this.lblExtra = new System.Windows.Forms.Label();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.labelRequiredDate = new System.Windows.Forms.Label();
            this.pnlDetail.SuspendLayout();
            this.dgvList.SuspendLayout();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grbNeedList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuExtra)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetail.Controls.Add(this.dtpRequiredDate);
            this.pnlDetail.Controls.Add(this.labelRequiredDate);
            this.pnlDetail.Controls.Add(this.lblExtra);
            this.pnlDetail.Controls.Add(this.nuExtra);
            this.pnlDetail.Controls.Add(this.btnSelectiveOrder);
            this.pnlDetail.Controls.Add(this.btnAllOrder);
            this.pnlDetail.Location = new System.Drawing.Point(202, 436);
            this.pnlDetail.Size = new System.Drawing.Size(663, 56);
            // 
            // dgvList
            // 
            this.dgvList.Controls.Add(this.grbNeedList);
            this.dgvList.Location = new System.Drawing.Point(15, 51);
            this.dgvList.Size = new System.Drawing.Size(853, 385);
            // 
            // btnSubMenu2
            // 
            this.btnSubMenu2.Tag = "ListStore";
            this.btnSubMenu2.Text = "입고관리";
            this.btnSubMenu2.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnSubMenu
            // 
            this.btnSubMenu.Tag = "ListOrderToVendor";
            this.btnSubMenu.Text = "발주관리";
            this.btnSubMenu.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnSubMenu3
            // 
            this.btnSubMenu3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubMenu3.Tag = "RequiredOrderList";
            this.btnSubMenu3.Text = "빠른발주";
            this.btnSubMenu3.UseVisualStyleBackColor = false;
            this.btnSubMenu3.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Text = "필요 목록 Excel 출력";
            //this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.labelLookup);
            this.pnlContent.Controls.Add(this.pnlFilter);
            this.pnlContent.Controls.SetChildIndex(this.pnlFilter, 0);
            this.pnlContent.Controls.SetChildIndex(this.labelLookup, 0);
            this.pnlContent.Controls.SetChildIndex(this.dgvList, 0);
            this.pnlContent.Controls.SetChildIndex(this.pnlDetail, 0);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.rdoNeedAll);
            this.pnlFilter.Controls.Add(this.rdoOrder);
            this.pnlFilter.Controls.Add(this.rdoSafe);
            this.pnlFilter.Controls.Add(this.rdoAll);
            this.pnlFilter.Location = new System.Drawing.Point(74, 11);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(448, 23);
            this.pnlFilter.TabIndex = 25;
            // 
            // rdoNeedAll
            // 
            this.rdoNeedAll.AutoSize = true;
            this.rdoNeedAll.Location = new System.Drawing.Point(3, 3);
            this.rdoNeedAll.Name = "rdoNeedAll";
            this.rdoNeedAll.Size = new System.Drawing.Size(103, 16);
            this.rdoNeedAll.TabIndex = 3;
            this.rdoNeedAll.Text = "발주 필요 항목";
            this.rdoNeedAll.UseVisualStyleBackColor = true;
            this.rdoNeedAll.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoOrder
            // 
            this.rdoOrder.AutoSize = true;
            this.rdoOrder.Location = new System.Drawing.Point(229, 3);
            this.rdoOrder.Name = "rdoOrder";
            this.rdoOrder.Size = new System.Drawing.Size(87, 16);
            this.rdoOrder.TabIndex = 2;
            this.rdoOrder.Text = "수주량 미만";
            this.rdoOrder.UseVisualStyleBackColor = true;
            this.rdoOrder.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoSafe
            // 
            this.rdoSafe.AutoSize = true;
            this.rdoSafe.Location = new System.Drawing.Point(112, 3);
            this.rdoSafe.Name = "rdoSafe";
            this.rdoSafe.Size = new System.Drawing.Size(111, 16);
            this.rdoSafe.TabIndex = 1;
            this.rdoSafe.Text = "안전재고량 미만";
            this.rdoSafe.UseVisualStyleBackColor = true;
            this.rdoSafe.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(322, 3);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(75, 16);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.Text = "전체 항목";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // labelLookup
            // 
            this.labelLookup.AutoSize = true;
            this.labelLookup.Location = new System.Drawing.Point(15, 16);
            this.labelLookup.Name = "labelLookup";
            this.labelLookup.Size = new System.Drawing.Size(53, 12);
            this.labelLookup.TabIndex = 26;
            this.labelLookup.Text = "조회기준";
            // 
            // grbNeedList
            // 
            this.grbNeedList.Controls.Add(this.dgvNeed);
            this.grbNeedList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNeedList.Location = new System.Drawing.Point(0, 0);
            this.grbNeedList.Name = "grbNeedList";
            this.grbNeedList.Size = new System.Drawing.Size(853, 385);
            this.grbNeedList.TabIndex = 0;
            this.grbNeedList.TabStop = false;
            this.grbNeedList.Text = "필요 발주 목록";
            // 
            // dgvNeed
            // 
            this.dgvNeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNeed.Location = new System.Drawing.Point(3, 17);
            this.dgvNeed.Name = "dgvNeed";
            this.dgvNeed.RowTemplate.Height = 23;
            this.dgvNeed.Size = new System.Drawing.Size(847, 365);
            this.dgvNeed.TabIndex = 0;
            this.dgvNeed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNeed_CellContentClick);
            this.dgvNeed.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvNeed_CellFormatting);
            // 
            // btnAllOrder
            // 
            this.btnAllOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllOrder.Location = new System.Drawing.Point(573, 27);
            this.btnAllOrder.Name = "btnAllOrder";
            this.btnAllOrder.Size = new System.Drawing.Size(87, 26);
            this.btnAllOrder.TabIndex = 20;
            this.btnAllOrder.Text = "전체 발주";
            this.btnAllOrder.UseVisualStyleBackColor = true;
            this.btnAllOrder.Click += new System.EventHandler(this.btnAllOrder_Click);
            // 
            // btnSelectiveOrder
            // 
            this.btnSelectiveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectiveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectiveOrder.Location = new System.Drawing.Point(480, 27);
            this.btnSelectiveOrder.Name = "btnSelectiveOrder";
            this.btnSelectiveOrder.Size = new System.Drawing.Size(87, 26);
            this.btnSelectiveOrder.TabIndex = 21;
            this.btnSelectiveOrder.Text = "선택 발주";
            this.btnSelectiveOrder.UseVisualStyleBackColor = true;
            this.btnSelectiveOrder.Click += new System.EventHandler(this.btnSelectiveOrder_Click);
            // 
            // nuExtra
            // 
            this.nuExtra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nuExtra.Location = new System.Drawing.Point(340, 30);
            this.nuExtra.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nuExtra.Name = "nuExtra";
            this.nuExtra.Size = new System.Drawing.Size(120, 21);
            this.nuExtra.TabIndex = 22;
            this.nuExtra.ThousandsSeparator = true;
            // 
            // lblExtra
            // 
            this.lblExtra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtra.AutoSize = true;
            this.lblExtra.Location = new System.Drawing.Point(338, 11);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(85, 12);
            this.lblExtra.TabIndex = 23;
            this.lblExtra.Text = "추가 여유 수량";
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Location = new System.Drawing.Point(150, 30);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(170, 21);
            this.dtpRequiredDate.TabIndex = 28;
            // 
            // labelRequiredDate
            // 
            this.labelRequiredDate.AutoSize = true;
            this.labelRequiredDate.Location = new System.Drawing.Point(148, 11);
            this.labelRequiredDate.Name = "labelRequiredDate";
            this.labelRequiredDate.Size = new System.Drawing.Size(69, 12);
            this.labelRequiredDate.TabIndex = 29;
            this.labelRequiredDate.Text = "납기 요청일";
            // 
            // RequiredOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Name = "RequiredOrderList";
            this.Tag = "";
            this.Text = "빠른발주";
            this.Load += new System.EventHandler(this.RequiredOrderList_Load);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.dgvList.ResumeLayout(false);
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.grbNeedList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuExtra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.RadioButton rdoSafe;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoOrder;
        private System.Windows.Forms.Label labelLookup;
        private System.Windows.Forms.GroupBox grbNeedList;
        private System.Windows.Forms.DataGridView dgvNeed;
        protected System.Windows.Forms.Button btnSelectiveOrder;
        protected System.Windows.Forms.Button btnAllOrder;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.NumericUpDown nuExtra;
        private System.Windows.Forms.RadioButton rdoNeedAll;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.Label labelRequiredDate;
    }
}
