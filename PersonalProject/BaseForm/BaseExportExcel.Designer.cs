
namespace PersonalProject
{
    partial class BaseExportExcel
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
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.btnSubMenu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLocalNavigationBar
            // 
            this.pnlLocalNavigationBar.Controls.Add(this.button2);
            this.pnlLocalNavigationBar.Controls.Add(this.btnSubMenu);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvPreview);
            // 
            // dgvPreview
            // 
            this.dgvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(12, 22);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.RowTemplate.Height = 23;
            this.dgvPreview.Size = new System.Drawing.Size(858, 437);
            this.dgvPreview.TabIndex = 0;
            // 
            // btnSubMenu
            // 
            this.btnSubMenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubMenu.Location = new System.Drawing.Point(12, 25);
            this.btnSubMenu.Name = "btnSubMenu";
            this.btnSubMenu.Size = new System.Drawing.Size(146, 33);
            this.btnSubMenu.TabIndex = 24;
            this.btnSubMenu.Text = "Template Download ";
            this.btnSubMenu.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(762, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 33);
            this.button2.TabIndex = 25;
            this.button2.Text = "Export to Excel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // BaseExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Name = "BaseExportExcel";
            this.Text = "엑셀 다운로드";
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreview;
        protected System.Windows.Forms.Button btnSubMenu;
        protected System.Windows.Forms.Button button2;
    }
}
