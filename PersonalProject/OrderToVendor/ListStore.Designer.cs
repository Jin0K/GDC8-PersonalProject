
namespace PersonalProject
{
    partial class ListStore
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
            this.lblSTORE_Detail = new System.Windows.Forms.Label();
            this.lblStoreDate = new System.Windows.Forms.Label();
            this.labelStoreDate = new System.Windows.Forms.Label();
            this.lblComName = new System.Windows.Forms.Label();
            this.labelComName = new System.Windows.Forms.Label();
            this.labelSTORE_Status = new System.Windows.Forms.Label();
            this.lblMTName = new System.Windows.Forms.Label();
            this.labelMTName = new System.Windows.Forms.Label();
            this.lblSTORE_Qty = new System.Windows.Forms.Label();
            this.labelSTORE_Qty = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.labelEpr_Date = new System.Windows.Forms.Label();
            this.lblEpr_Date = new System.Windows.Forms.Label();
            this.dgvStoreList = new System.Windows.Forms.DataGridView();
            this.lblSTORE_Status = new System.Windows.Forms.Label();
            this.pnlClear = new System.Windows.Forms.Panel();
            this.dgvList.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreList)).BeginInit();
            this.pnlClear.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPeriod
            // 
            this.labelPeriod.Size = new System.Drawing.Size(53, 12);
            this.labelPeriod.Text = "입고기간";
            // 
            // btnSelect
            // 
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvList
            // 
            this.dgvList.Controls.Add(this.dgvStoreList);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(337, 343);
            this.btnUpdate.Visible = false;
            // 
            // btnInsert
            // 
            this.btnInsert.Tag = "AddStore";
            this.btnInsert.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.labelEpr_Date);
            this.pnlDetail.Controls.Add(this.labelSTORE_Qty);
            this.pnlDetail.Controls.Add(this.labelMTName);
            this.pnlDetail.Controls.Add(this.labelSTORE_Status);
            this.pnlDetail.Controls.Add(this.labelStoreDate);
            this.pnlDetail.Controls.Add(this.labelComName);
            this.pnlDetail.Controls.Add(this.pnlClear);
            this.pnlDetail.Controls.SetChildIndex(this.txtNumber, 0);
            this.pnlDetail.Controls.SetChildIndex(this.pnlClear, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelComName, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelStoreDate, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelSTORE_Status, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelMTName, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelSTORE_Qty, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelEpr_Date, 0);
            this.pnlDetail.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlDetail.Controls.SetChildIndex(this.labelNumber, 0);
            // 
            // txtNumber
            // 
            this.txtNumber.Visible = false;
            // 
            // btnSubMenu3
            // 
            this.btnSubMenu3.Tag = "RequiredOrderList";
            this.btnSubMenu3.Text = "빠른발주";
            this.btnSubMenu3.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // lblSTORE_Detail
            // 
            this.lblSTORE_Detail.AutoSize = true;
            this.lblSTORE_Detail.Location = new System.Drawing.Point(8, 19);
            this.lblSTORE_Detail.Name = "lblSTORE_Detail";
            this.lblSTORE_Detail.Size = new System.Drawing.Size(85, 12);
            this.lblSTORE_Detail.TabIndex = 25;
            this.lblSTORE_Detail.Text = "입고 상세 번호";
            // 
            // lblStoreDate
            // 
            this.lblStoreDate.AutoSize = true;
            this.lblStoreDate.Location = new System.Drawing.Point(8, 107);
            this.lblStoreDate.Name = "lblStoreDate";
            this.lblStoreDate.Size = new System.Drawing.Size(65, 12);
            this.lblStoreDate.TabIndex = 43;
            this.lblStoreDate.Text = "2021-11-07";
            // 
            // labelStoreDate
            // 
            this.labelStoreDate.AutoSize = true;
            this.labelStoreDate.Location = new System.Drawing.Point(24, 110);
            this.labelStoreDate.Name = "labelStoreDate";
            this.labelStoreDate.Size = new System.Drawing.Size(41, 12);
            this.labelStoreDate.TabIndex = 42;
            this.labelStoreDate.Text = "입고일";
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Location = new System.Drawing.Point(8, 63);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(41, 12);
            this.lblComName.TabIndex = 41;
            this.lblComName.Text = "거래처";
            // 
            // labelComName
            // 
            this.labelComName.AutoSize = true;
            this.labelComName.Location = new System.Drawing.Point(24, 66);
            this.labelComName.Name = "labelComName";
            this.labelComName.Size = new System.Drawing.Size(41, 12);
            this.labelComName.TabIndex = 40;
            this.labelComName.Text = "거래처";
            // 
            // labelSTORE_Status
            // 
            this.labelSTORE_Status.AutoSize = true;
            this.labelSTORE_Status.Location = new System.Drawing.Point(24, 154);
            this.labelSTORE_Status.Name = "labelSTORE_Status";
            this.labelSTORE_Status.Size = new System.Drawing.Size(53, 12);
            this.labelSTORE_Status.TabIndex = 45;
            this.labelSTORE_Status.Text = "입고상태";
            // 
            // lblMTName
            // 
            this.lblMTName.AutoSize = true;
            this.lblMTName.Location = new System.Drawing.Point(8, 195);
            this.lblMTName.Name = "lblMTName";
            this.lblMTName.Size = new System.Drawing.Size(41, 12);
            this.lblMTName.TabIndex = 47;
            this.lblMTName.Text = "항목명";
            // 
            // labelMTName
            // 
            this.labelMTName.AutoSize = true;
            this.labelMTName.Location = new System.Drawing.Point(24, 198);
            this.labelMTName.Name = "labelMTName";
            this.labelMTName.Size = new System.Drawing.Size(29, 12);
            this.labelMTName.TabIndex = 46;
            this.labelMTName.Text = "항목";
            // 
            // lblSTORE_Qty
            // 
            this.lblSTORE_Qty.Location = new System.Drawing.Point(8, 239);
            this.lblSTORE_Qty.Name = "lblSTORE_Qty";
            this.lblSTORE_Qty.Size = new System.Drawing.Size(65, 12);
            this.lblSTORE_Qty.TabIndex = 49;
            this.lblSTORE_Qty.Text = "수량";
            this.lblSTORE_Qty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelSTORE_Qty
            // 
            this.labelSTORE_Qty.AutoSize = true;
            this.labelSTORE_Qty.Location = new System.Drawing.Point(24, 242);
            this.labelSTORE_Qty.Name = "labelSTORE_Qty";
            this.labelSTORE_Qty.Size = new System.Drawing.Size(53, 12);
            this.labelSTORE_Qty.TabIndex = 48;
            this.labelSTORE_Qty.Text = "입고수량";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(79, 239);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 12);
            this.lblUnit.TabIndex = 50;
            this.lblUnit.Text = "단위";
            // 
            // labelEpr_Date
            // 
            this.labelEpr_Date.AutoSize = true;
            this.labelEpr_Date.Location = new System.Drawing.Point(24, 286);
            this.labelEpr_Date.Name = "labelEpr_Date";
            this.labelEpr_Date.Size = new System.Drawing.Size(53, 12);
            this.labelEpr_Date.TabIndex = 51;
            this.labelEpr_Date.Text = "유통기한";
            // 
            // lblEpr_Date
            // 
            this.lblEpr_Date.AutoSize = true;
            this.lblEpr_Date.Location = new System.Drawing.Point(8, 283);
            this.lblEpr_Date.Name = "lblEpr_Date";
            this.lblEpr_Date.Size = new System.Drawing.Size(101, 12);
            this.lblEpr_Date.TabIndex = 53;
            this.lblEpr_Date.Text = "2021-11-14 (7 일)";
            // 
            // dgvStoreList
            // 
            this.dgvStoreList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStoreList.Location = new System.Drawing.Point(0, 0);
            this.dgvStoreList.Name = "dgvStoreList";
            this.dgvStoreList.RowTemplate.Height = 23;
            this.dgvStoreList.Size = new System.Drawing.Size(419, 381);
            this.dgvStoreList.TabIndex = 0;
            this.dgvStoreList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStoreList_CellDoubleClick);
            // 
            // lblSTORE_Status
            // 
            this.lblSTORE_Status.AutoSize = true;
            this.lblSTORE_Status.Location = new System.Drawing.Point(8, 151);
            this.lblSTORE_Status.Name = "lblSTORE_Status";
            this.lblSTORE_Status.Size = new System.Drawing.Size(57, 12);
            this.lblSTORE_Status.TabIndex = 54;
            this.lblSTORE_Status.Text = "부분 입고";
            // 
            // pnlClear
            // 
            this.pnlClear.Controls.Add(this.lblSTORE_Detail);
            this.pnlClear.Controls.Add(this.lblComName);
            this.pnlClear.Controls.Add(this.lblEpr_Date);
            this.pnlClear.Controls.Add(this.lblSTORE_Status);
            this.pnlClear.Controls.Add(this.lblStoreDate);
            this.pnlClear.Controls.Add(this.lblUnit);
            this.pnlClear.Controls.Add(this.lblMTName);
            this.pnlClear.Controls.Add(this.lblSTORE_Qty);
            this.pnlClear.Location = new System.Drawing.Point(83, 3);
            this.pnlClear.Name = "pnlClear";
            this.pnlClear.Size = new System.Drawing.Size(248, 334);
            this.pnlClear.TabIndex = 56;
            // 
            // ListStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListStore";
            this.Text = "입고관리";
            this.Load += new System.EventHandler(this.ListStore_Load);
            this.dgvList.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreList)).EndInit();
            this.pnlClear.ResumeLayout(false);
            this.pnlClear.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblSTORE_Detail;
        private System.Windows.Forms.Label lblStoreDate;
        private System.Windows.Forms.Label labelStoreDate;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.Label labelComName;
        private System.Windows.Forms.Label labelSTORE_Status;
        private System.Windows.Forms.Label lblEpr_Date;
        private System.Windows.Forms.Label labelEpr_Date;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblSTORE_Qty;
        private System.Windows.Forms.Label labelSTORE_Qty;
        private System.Windows.Forms.Label lblMTName;
        private System.Windows.Forms.Label labelMTName;
        private System.Windows.Forms.DataGridView dgvStoreList;
        private System.Windows.Forms.Label lblSTORE_Status;
        private System.Windows.Forms.Panel pnlClear;
    }
}
