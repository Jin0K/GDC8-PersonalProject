
namespace PersonalProject
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.llbJoin = new System.Windows.Forms.LinkLabel();
            this.llbFindID = new System.Windows.Forms.LinkLabel();
            this.llbFindPassword = new System.Windows.Forms.LinkLabel();
            this.UserDiv = new PersonalProject.UserDivControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "비밀번호";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(91, 63);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(145, 21);
            this.txtID.TabIndex = 1;
<<<<<<< HEAD
            this.txtID.Text = "q";
=======
            this.txtID.Text = "b";
>>>>>>> a1f384a (COMMIT 1)
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(91, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(145, 21);
            this.txtPassword.TabIndex = 2;
<<<<<<< HEAD
            this.txtPassword.Text = "qQ!12345";
=======
            this.txtPassword.Text = "12345678";
>>>>>>> a1f384a (COMMIT 1)
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(258, 61);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 64);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // llbJoin
            // 
            this.llbJoin.AutoSize = true;
            this.llbJoin.Location = new System.Drawing.Point(71, 147);
            this.llbJoin.Name = "llbJoin";
            this.llbJoin.Size = new System.Drawing.Size(53, 12);
            this.llbJoin.TabIndex = 4;
            this.llbJoin.TabStop = true;
            this.llbJoin.Text = "회원가입";
            this.llbJoin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbJoin_LinkClicked);
            // 
            // llbFindID
            // 
            this.llbFindID.AutoSize = true;
            this.llbFindID.Location = new System.Drawing.Point(130, 147);
            this.llbFindID.Name = "llbFindID";
            this.llbFindID.Size = new System.Drawing.Size(69, 12);
            this.llbFindID.TabIndex = 5;
            this.llbFindID.TabStop = true;
            this.llbFindID.Text = "아이디 찾기";
            this.llbFindID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbFindID_LinkClicked);
            // 
            // llbFindPassword
            // 
            this.llbFindPassword.AutoSize = true;
            this.llbFindPassword.Location = new System.Drawing.Point(205, 147);
            this.llbFindPassword.Name = "llbFindPassword";
            this.llbFindPassword.Size = new System.Drawing.Size(81, 12);
            this.llbFindPassword.TabIndex = 6;
            this.llbFindPassword.TabStop = true;
            this.llbFindPassword.Text = "비밀번호 찾기";
            this.llbFindPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbFindPassword_LinkClicked);
            // 
            // UserDiv
            // 
            this.UserDiv.Location = new System.Drawing.Point(33, 21);
            this.UserDiv.Name = "UserDiv";
            this.UserDiv.Size = new System.Drawing.Size(115, 21);
            this.UserDiv.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 192);
            this.Controls.Add(this.llbFindPassword);
            this.Controls.Add(this.UserDiv);
            this.Controls.Add(this.llbFindID);
            this.Controls.Add(this.llbJoin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLogin_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel llbJoin;
        private System.Windows.Forms.LinkLabel llbFindID;
        private UserDivControl UserDiv;
        private System.Windows.Forms.LinkLabel llbFindPassword;
    }
}