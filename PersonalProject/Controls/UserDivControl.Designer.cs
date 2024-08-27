
namespace PersonalProject
{
    partial class UserDivControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdoBrand = new System.Windows.Forms.RadioButton();
            this.rdoCustomer = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdoBrand
            // 
            this.rdoBrand.AutoSize = true;
            this.rdoBrand.Location = new System.Drawing.Point(56, 0);
            this.rdoBrand.Name = "rdoBrand";
            this.rdoBrand.Size = new System.Drawing.Size(59, 16);
            this.rdoBrand.TabIndex = 1;
            this.rdoBrand.TabStop = true;
            this.rdoBrand.Text = "브랜드";
            this.rdoBrand.UseVisualStyleBackColor = true;
            // 
            // rdoCustomer
            // 
            this.rdoCustomer.AutoSize = true;
            this.rdoCustomer.Location = new System.Drawing.Point(0, 0);
            this.rdoCustomer.Name = "rdoCustomer";
            this.rdoCustomer.Size = new System.Drawing.Size(47, 16);
            this.rdoCustomer.TabIndex = 0;
            this.rdoCustomer.TabStop = true;
            this.rdoCustomer.Text = "고객";
            this.rdoCustomer.UseVisualStyleBackColor = true;
            // 
            // UserDivControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdoBrand);
            this.Controls.Add(this.rdoCustomer);
            this.Name = "UserDivControl";
            this.Size = new System.Drawing.Size(115, 16);
            this.Load += new System.EventHandler(this.UserDivControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rdoBrand;
        private System.Windows.Forms.RadioButton rdoCustomer;
    }
}
