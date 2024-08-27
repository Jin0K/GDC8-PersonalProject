
namespace PersonalProject
{
    partial class BaseSelectForm
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
            this.labelMT = new System.Windows.Forms.Label();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.cboMt = new System.Windows.Forms.ComboBox();
            this.cboCom = new System.Windows.Forms.ComboBox();
            this.labelCompany = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.Panel();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnSubMenu = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.btnSubMenu2 = new System.Windows.Forms.Button();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.btnSubMenu3 = new System.Windows.Forms.Button();
            this.ucPeriod = new UserControls.PeriodUserControl();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLocalNavigationBar
            // 
            this.pnlLocalNavigationBar.Controls.Add(this.btnSubMenu3);
            this.pnlLocalNavigationBar.Controls.Add(this.btnSubMenu2);
            this.pnlLocalNavigationBar.Controls.Add(this.btnExcelExport);
            this.pnlLocalNavigationBar.Controls.Add(this.btnClose);
            this.pnlLocalNavigationBar.Controls.Add(this.btnDelete);
            this.pnlLocalNavigationBar.Controls.Add(this.btnSubMenu);
            this.pnlLocalNavigationBar.Controls.Add(this.btnInsert);
            this.pnlLocalNavigationBar.Size = new System.Drawing.Size(882, 64);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnInsert, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnSubMenu, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnExcelExport, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnSubMenu2, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnSubMenu3, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnCloses, 0);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ucPeriod);
            this.pnlContent.Controls.Add(this.pnlDetail);
            this.pnlContent.Controls.Add(this.cboState);
            this.pnlContent.Controls.Add(this.labelStatus);
            this.pnlContent.Controls.Add(this.dgvList);
            this.pnlContent.Controls.Add(this.btnSelect);
            this.pnlContent.Controls.Add(this.cboCom);
            this.pnlContent.Controls.Add(this.labelCompany);
            this.pnlContent.Controls.Add(this.cboMt);
            this.pnlContent.Controls.Add(this.labelPeriod);
            this.pnlContent.Controls.Add(this.labelMT);
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Size = new System.Drawing.Size(882, 492);
            // 
            // labelMT
            // 
            this.labelMT.AutoSize = true;
            this.labelMT.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMT.Location = new System.Drawing.Point(12, 24);
            this.labelMT.Name = "labelMT";
            this.labelMT.Size = new System.Drawing.Size(29, 12);
            this.labelMT.TabIndex = 9;
            this.labelMT.Text = "항목";
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPeriod.Location = new System.Drawing.Point(471, 24);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(29, 12);
            this.labelPeriod.TabIndex = 10;
            this.labelPeriod.Text = "기간";
            // 
            // cboMt
            // 
            this.cboMt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMt.FormattingEnabled = true;
            this.cboMt.Location = new System.Drawing.Point(12, 46);
            this.cboMt.Name = "cboMt";
            this.cboMt.Size = new System.Drawing.Size(149, 20);
            this.cboMt.TabIndex = 11;
            // 
            // cboCom
            // 
            this.cboCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCom.FormattingEnabled = true;
            this.cboCom.Location = new System.Drawing.Point(183, 46);
            this.cboCom.Name = "cboCom";
            this.cboCom.Size = new System.Drawing.Size(149, 20);
            this.cboCom.TabIndex = 13;
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelCompany.Location = new System.Drawing.Point(183, 24);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(41, 12);
            this.labelCompany.TabIndex = 12;
            this.labelCompany.Text = "거래처";
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelect.Location = new System.Drawing.Point(795, 47);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(72, 20);
            this.btnSelect.TabIndex = 14;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // dgvList
            // 
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.Location = new System.Drawing.Point(12, 99);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(419, 381);
            this.dgvList.TabIndex = 15;
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(354, 46);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(95, 20);
            this.cboState.TabIndex = 17;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelStatus.Location = new System.Drawing.Point(354, 24);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(29, 12);
            this.labelStatus.TabIndex = 16;
            this.labelStatus.Text = "상태";
            // 
            // btnSubMenu
            // 
            this.btnSubMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenu.Location = new System.Drawing.Point(288, 14);
            this.btnSubMenu.Name = "btnSubMenu";
            this.btnSubMenu.Size = new System.Drawing.Size(87, 36);
            this.btnSubMenu.TabIndex = 18;
            this.btnSubMenu.Text = "서브메뉴";
            this.btnSubMenu.UseVisualStyleBackColor = true;
            this.btnSubMenu.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(812, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 36);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "창닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Location = new System.Drawing.Point(14, 14);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(87, 33);
            this.btnInsert.TabIndex = 18;
            this.btnInsert.Text = "등록";
            this.btnInsert.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(343, 352);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 26);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(107, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 33);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExcelExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelExport.Location = new System.Drawing.Point(719, 12);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(87, 36);
            this.btnExcelExport.TabIndex = 21;
            this.btnExcelExport.Text = "Excel 출력";
            this.btnExcelExport.UseVisualStyleBackColor = false;
            // 
            // btnSubMenu2
            // 
            this.btnSubMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenu2.Location = new System.Drawing.Point(382, 14);
            this.btnSubMenu2.Name = "btnSubMenu2";
            this.btnSubMenu2.Size = new System.Drawing.Size(87, 36);
            this.btnSubMenu2.TabIndex = 22;
            this.btnSubMenu2.Text = "서브메뉴";
            this.btnSubMenu2.UseVisualStyleBackColor = true;
            this.btnSubMenu2.Visible = false;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetail.Controls.Add(this.txtNumber);
            this.pnlDetail.Controls.Add(this.labelNumber);
            this.pnlDetail.Controls.Add(this.btnUpdate);
            this.pnlDetail.Location = new System.Drawing.Point(437, 99);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(433, 381);
            this.pnlDetail.TabIndex = 22;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(59, 19);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(123, 21);
            this.txtNumber.TabIndex = 24;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelNumber.Location = new System.Drawing.Point(24, 22);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(29, 12);
            this.labelNumber.TabIndex = 23;
            this.labelNumber.Text = "번호";
            // 
            // btnSubMenu3
            // 
            this.btnSubMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenu3.Location = new System.Drawing.Point(475, 14);
            this.btnSubMenu3.Name = "btnSubMenu3";
            this.btnSubMenu3.Size = new System.Drawing.Size(87, 36);
            this.btnSubMenu3.TabIndex = 23;
            this.btnSubMenu3.Text = "서브메뉴";
            this.btnSubMenu3.UseVisualStyleBackColor = true;
            this.btnSubMenu3.Visible = false;
            // 
            // ucPeriod
            // 
            this.ucPeriod.Location = new System.Drawing.Point(471, 46);
            this.ucPeriod.Name = "ucPeriod";
            this.ucPeriod.Size = new System.Drawing.Size(284, 21);
            this.ucPeriod.TabIndex = 23;
            // 
            // BaseSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Name = "BaseSelectForm";
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label labelPeriod;
        protected System.Windows.Forms.Label labelMT;
        protected System.Windows.Forms.Button btnSelect;
        protected System.Windows.Forms.ComboBox cboCom;
        protected System.Windows.Forms.Label labelCompany;
        protected System.Windows.Forms.ComboBox cboMt;
        protected System.Windows.Forms.ComboBox cboState;
        protected System.Windows.Forms.Label labelStatus;
        protected System.Windows.Forms.Panel dgvList;
        protected System.Windows.Forms.Button btnSubMenu;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnSubMenu2;
        protected System.Windows.Forms.Button btnExcelExport;
        protected System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.Button btnInsert;
        protected System.Windows.Forms.Panel pnlDetail;
        protected System.Windows.Forms.Label labelNumber;
        protected System.Windows.Forms.TextBox txtNumber;
        protected System.Windows.Forms.Button btnSubMenu3;
        protected UserControls.PeriodUserControl ucPeriod;
    }
}
