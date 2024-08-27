
namespace PersonalProject
{
    partial class frmShowID
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.btnFindPassword = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(68, 49);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(223, 15);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "해당되는 정보의 ID를 찾을 수 없습니다.";
            // 
            // btnFindPassword
            // 
            this.btnFindPassword.Location = new System.Drawing.Point(8, 99);
            this.btnFindPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindPassword.Name = "btnFindPassword";
            this.btnFindPassword.Size = new System.Drawing.Size(102, 29);
            this.btnFindPassword.TabIndex = 1;
            this.btnFindPassword.Text = "비밀번호 찾기";
            this.btnFindPassword.UseVisualStyleBackColor = true;
            this.btnFindPassword.Click += new System.EventHandler(this.btnFindPassword_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(280, 99);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 29);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(114, 99);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(102, 29);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "로그인 하기";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmShowID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 136);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnFindPassword);
            this.Controls.Add(this.lblResult);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ID 찾기 결과";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnFindPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnLogin;
    }
}