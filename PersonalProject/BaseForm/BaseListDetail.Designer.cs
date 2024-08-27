

    partial class BaseListDetail
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
        public void InitializeComponent()
        {
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.Panel();
            this.btnSubMenu2 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubMenu = new System.Windows.Forms.Button();
            this.btnSubMenu3 = new System.Windows.Forms.Button();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLocalNavigationBar
            // 
            this.pnlLocalNavigationBar.Controls.Add(this.btnExcelExport);
            this.pnlLocalNavigationBar.Controls.Add(this.btnSubMenu3);
            this.pnlLocalNavigationBar.Controls.Add(this.btnSubMenu2);
            this.pnlLocalNavigationBar.Controls.Add(this.btnClose);
            this.pnlLocalNavigationBar.Controls.Add(this.btnSubMenu);
            this.pnlLocalNavigationBar.Size = new System.Drawing.Size(882, 61);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnSubMenu, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnSubMenu2, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnSubMenu3, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnExcelExport, 0);
            this.pnlLocalNavigationBar.Controls.SetChildIndex(this.btnCloses, 0);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlDetail);
            this.pnlContent.Controls.Add(this.dgvList);
            this.pnlContent.Location = new System.Drawing.Point(0, 61);
            this.pnlContent.Size = new System.Drawing.Size(882, 495);
            // 
            // btnCloses
            // 
            this.btnCloses.Location = new System.Drawing.Point(812, 12);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Location = new System.Drawing.Point(497, 99);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(373, 360);
            this.pnlDetail.TabIndex = 24;
            // 
            // dgvList
            // 
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.Location = new System.Drawing.Point(15, 99);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(476, 355);
            this.dgvList.TabIndex = 23;
            // 
            // btnSubMenu2
            // 
            this.btnSubMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenu2.Location = new System.Drawing.Point(413, 14);
            this.btnSubMenu2.Name = "btnSubMenu2";
            this.btnSubMenu2.Size = new System.Drawing.Size(87, 33);
            this.btnSubMenu2.TabIndex = 25;
            this.btnSubMenu2.Text = "서브메뉴";
            this.btnSubMenu2.UseVisualStyleBackColor = true;
            this.btnSubMenu2.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(812, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 36);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "창닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubMenu
            // 
            this.btnSubMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenu.Location = new System.Drawing.Point(310, 14);
            this.btnSubMenu.Name = "btnSubMenu";
            this.btnSubMenu.Size = new System.Drawing.Size(87, 33);
            this.btnSubMenu.TabIndex = 23;
            this.btnSubMenu.Text = "서브메뉴";
            this.btnSubMenu.UseVisualStyleBackColor = true;
            this.btnSubMenu.Visible = false;
            // 
            // btnSubMenu3
            // 
            this.btnSubMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenu3.Location = new System.Drawing.Point(516, 14);
            this.btnSubMenu3.Name = "btnSubMenu3";
            this.btnSubMenu3.Size = new System.Drawing.Size(87, 33);
            this.btnSubMenu3.TabIndex = 26;
            this.btnSubMenu3.Text = "서브메뉴";
            this.btnSubMenu3.UseVisualStyleBackColor = true;
            this.btnSubMenu3.Visible = false;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExcelExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelExport.Location = new System.Drawing.Point(719, 12);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(87, 36);
            this.btnExcelExport.TabIndex = 28;
            this.btnExcelExport.Text = "Excel 출력";
            this.btnExcelExport.UseVisualStyleBackColor = false;
            // 
            // BaseListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Name = "BaseListDetail";
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlDetail;
        protected System.Windows.Forms.Panel dgvList;
        protected System.Windows.Forms.Button btnSubMenu2;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnSubMenu;
        protected System.Windows.Forms.Button btnSubMenu3;
        protected System.Windows.Forms.Button btnExcelExport;
    }

