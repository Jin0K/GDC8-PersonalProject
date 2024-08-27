
namespace PersonalProject
{
    partial class frmCustomer
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
<<<<<<< HEAD
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
=======
            this.labelID = new System.Windows.Forms.Label();
            this.labelPw = new System.Windows.Forms.Label();
            this.labelChk = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelGen = new System.Windows.Forms.Label();
            this.labelBirth = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelAddr = new System.Windows.Forms.Label();
>>>>>>> a1f384a (COMMIT 1)
            this.label10 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rdoM = new System.Windows.Forms.RadioButton();
            this.pnlGenderSelect = new System.Windows.Forms.Panel();
            this.rdoF = new System.Windows.Forms.RadioButton();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnIDCheck = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPasswordSame = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboSelectAddr = new System.Windows.Forms.ComboBox();
            this.pnlSetAddr = new System.Windows.Forms.Panel();
            this.btnAddAddr = new System.Windows.Forms.Button();
            this.btnSetAddr = new System.Windows.Forms.Button();
<<<<<<< HEAD
=======
            this.baseZip = new PersonalProject.ZipCodeUserControl();
>>>>>>> a1f384a (COMMIT 1)
            this.email = new PersonalProject.EmailUserControl();
            this.ntbPhone3 = new PersonalProject.NumTextBox();
            this.ntbPhone2 = new PersonalProject.NumTextBox();
            this.ntbPhone1 = new PersonalProject.NumTextBox();
<<<<<<< HEAD
            this.baseZip = new PersonalProject.ZipCodeUserControl();
=======
>>>>>>> a1f384a (COMMIT 1)
            this.pnlGenderSelect.SuspendLayout();
            this.pnlSetAddr.SuspendLayout();
            this.SuspendLayout();
            // 
<<<<<<< HEAD
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(103, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "회원ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(87, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "비밀번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(50, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "비밀번호 확인";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(119, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "이름";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(119, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "성별";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(87, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "생년월일";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(103, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "이메일";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(119, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "주소";
=======
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelID.Location = new System.Drawing.Point(103, 84);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(43, 15);
            this.labelID.TabIndex = 1;
            this.labelID.Text = "회원ID";
            // 
            // labelPw
            // 
            this.labelPw.AutoSize = true;
            this.labelPw.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelPw.Location = new System.Drawing.Point(87, 138);
            this.labelPw.Name = "labelPw";
            this.labelPw.Size = new System.Drawing.Size(55, 15);
            this.labelPw.TabIndex = 2;
            this.labelPw.Text = "비밀번호";
            // 
            // labelChk
            // 
            this.labelChk.AutoSize = true;
            this.labelChk.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelChk.Location = new System.Drawing.Point(50, 192);
            this.labelChk.Name = "labelChk";
            this.labelChk.Size = new System.Drawing.Size(83, 15);
            this.labelChk.TabIndex = 3;
            this.labelChk.Text = "비밀번호 확인";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelName.Location = new System.Drawing.Point(119, 246);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(31, 15);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "이름";
            // 
            // labelGen
            // 
            this.labelGen.AutoSize = true;
            this.labelGen.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelGen.Location = new System.Drawing.Point(119, 299);
            this.labelGen.Name = "labelGen";
            this.labelGen.Size = new System.Drawing.Size(31, 15);
            this.labelGen.TabIndex = 5;
            this.labelGen.Text = "성별";
            // 
            // labelBirth
            // 
            this.labelBirth.AutoSize = true;
            this.labelBirth.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelBirth.Location = new System.Drawing.Point(87, 353);
            this.labelBirth.Name = "labelBirth";
            this.labelBirth.Size = new System.Drawing.Size(55, 15);
            this.labelBirth.TabIndex = 6;
            this.labelBirth.Text = "생년월일";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelEmail.Location = new System.Drawing.Point(103, 407);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(43, 15);
            this.labelEmail.TabIndex = 7;
            this.labelEmail.Text = "이메일";
            // 
            // labelAddr
            // 
            this.labelAddr.AutoSize = true;
            this.labelAddr.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAddr.Location = new System.Drawing.Point(119, 460);
            this.labelAddr.Name = "labelAddr";
            this.labelAddr.Size = new System.Drawing.Size(31, 15);
            this.labelAddr.TabIndex = 8;
            this.labelAddr.Text = "주소";
>>>>>>> a1f384a (COMMIT 1)
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(87, 622);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "전화번호";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtID.Location = new System.Drawing.Point(179, 84);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.MaxLength = 10;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(114, 22);
            this.txtID.TabIndex = 0;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPassword.Location = new System.Drawing.Point(179, 137);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(114, 22);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPasswordConfirm.Location = new System.Drawing.Point(179, 192);
            this.txtPasswordConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPasswordConfirm.MaxLength = 20;
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(114, 22);
            this.txtPasswordConfirm.TabIndex = 3;
            this.txtPasswordConfirm.UseSystemPasswordChar = true;
            this.txtPasswordConfirm.Leave += new System.EventHandler(this.txtPasswordConfirm_Leave);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(179, 245);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 22);
            this.txtName.TabIndex = 4;
            // 
            // rdoM
            // 
            this.rdoM.AutoSize = true;
            this.rdoM.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoM.Location = new System.Drawing.Point(8, 5);
            this.rdoM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoM.Name = "rdoM";
            this.rdoM.Size = new System.Drawing.Size(37, 19);
            this.rdoM.TabIndex = 0;
            this.rdoM.TabStop = true;
            this.rdoM.Text = "남";
            this.rdoM.UseVisualStyleBackColor = true;
            // 
            // pnlGenderSelect
            // 
            this.pnlGenderSelect.Controls.Add(this.rdoF);
            this.pnlGenderSelect.Controls.Add(this.rdoM);
            this.pnlGenderSelect.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlGenderSelect.Location = new System.Drawing.Point(179, 297);
            this.pnlGenderSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlGenderSelect.Name = "pnlGenderSelect";
            this.pnlGenderSelect.Size = new System.Drawing.Size(114, 32);
            this.pnlGenderSelect.TabIndex = 5;
            // 
            // rdoF
            // 
            this.rdoF.AutoSize = true;
            this.rdoF.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoF.Location = new System.Drawing.Point(55, 4);
            this.rdoF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoF.Name = "rdoF";
            this.rdoF.Size = new System.Drawing.Size(37, 19);
            this.rdoF.TabIndex = 1;
            this.rdoF.TabStop = true;
            this.rdoF.Text = "여";
            this.rdoF.UseVisualStyleBackColor = true;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirth.Location = new System.Drawing.Point(179, 351);
            this.dtpBirth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(113, 22);
            this.dtpBirth.TabIndex = 6;
            // 
            // btnJoin
            // 
            this.btnJoin.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJoin.Location = new System.Drawing.Point(202, 734);
            this.btnJoin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(127, 44);
            this.btnJoin.TabIndex = 14;
            this.btnJoin.Text = "회원가입";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(397, 734);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 44);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnIDCheck
            // 
            this.btnIDCheck.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnIDCheck.Location = new System.Drawing.Point(305, 81);
            this.btnIDCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIDCheck.Name = "btnIDCheck";
            this.btnIDCheck.Size = new System.Drawing.Size(136, 29);
            this.btnIDCheck.TabIndex = 1;
            this.btnIDCheck.Tag = "CUSTOMER_ID";
            this.btnIDCheck.Text = "ID중복체크";
            this.btnIDCheck.UseVisualStyleBackColor = true;
            this.btnIDCheck.Click += new System.EventHandler(this.btnIDCheck_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(326, 625);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(235, 625);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "-";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPassword.ForeColor = System.Drawing.Color.Red;
            this.lblPassword.Location = new System.Drawing.Point(179, 163);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(393, 13);
            this.lblPassword.TabIndex = 30;
            this.lblPassword.Text = "비밀번호는 반드시 영어 대 / 소문자, 숫자, 특수문자를 각각 1개 이상 포함해야 합니다.";
            this.lblPassword.Visible = false;
            // 
            // lblPasswordSame
            // 
            this.lblPasswordSame.AutoSize = true;
            this.lblPasswordSame.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPasswordSame.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordSame.Location = new System.Drawing.Point(179, 218);
            this.lblPasswordSame.Name = "lblPasswordSame";
            this.lblPasswordSame.Size = new System.Drawing.Size(146, 13);
            this.lblPasswordSame.TabIndex = 31;
            this.lblPasswordSame.Text = "입력하신 비밀번호가 다릅니다.";
            this.lblPasswordSame.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(80, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(68, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 17);
            this.label14.TabIndex = 33;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(29, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 17);
            this.label15.TabIndex = 34;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(94, 246);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 17);
            this.label16.TabIndex = 35;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(80, 407);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 17);
            this.label17.TabIndex = 35;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
<<<<<<< HEAD
            this.label18.ForeColor = System.Drawing.Color.Red;
=======
            this.label18.ForeColor = System.Drawing.Color.Black;
>>>>>>> a1f384a (COMMIT 1)
            this.label18.Location = new System.Drawing.Point(92, 460);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 17);
            this.label18.TabIndex = 35;
            this.label18.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
<<<<<<< HEAD
            this.label19.ForeColor = System.Drawing.Color.Red;
=======
            this.label19.ForeColor = System.Drawing.Color.Black;
>>>>>>> a1f384a (COMMIT 1)
            this.label19.Location = new System.Drawing.Point(67, 620);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 17);
            this.label19.TabIndex = 35;
            this.label19.Text = "*";
            // 
            // cboSelectAddr
            // 
            this.cboSelectAddr.FormattingEnabled = true;
            this.cboSelectAddr.Location = new System.Drawing.Point(0, 0);
            this.cboSelectAddr.Name = "cboSelectAddr";
            this.cboSelectAddr.Size = new System.Drawing.Size(210, 23);
            this.cboSelectAddr.TabIndex = 39;
            this.cboSelectAddr.SelectedIndexChanged += new System.EventHandler(this.cboSelectAddr_SelectedIndexChanged);
            // 
            // pnlSetAddr
            // 
            this.pnlSetAddr.Controls.Add(this.btnAddAddr);
            this.pnlSetAddr.Controls.Add(this.btnSetAddr);
            this.pnlSetAddr.Controls.Add(this.cboSelectAddr);
            this.pnlSetAddr.Location = new System.Drawing.Point(479, 463);
            this.pnlSetAddr.Name = "pnlSetAddr";
            this.pnlSetAddr.Size = new System.Drawing.Size(210, 131);
            this.pnlSetAddr.TabIndex = 40;
            // 
            // btnAddAddr
            // 
            this.btnAddAddr.Location = new System.Drawing.Point(83, 98);
            this.btnAddAddr.Name = "btnAddAddr";
            this.btnAddAddr.Size = new System.Drawing.Size(127, 31);
            this.btnAddAddr.TabIndex = 41;
            this.btnAddAddr.Text = "주소지 추가";
            this.btnAddAddr.UseVisualStyleBackColor = true;
            this.btnAddAddr.Click += new System.EventHandler(this.btnAddAddr_Click);
            // 
            // btnSetAddr
            // 
            this.btnSetAddr.Location = new System.Drawing.Point(55, 42);
            this.btnSetAddr.Name = "btnSetAddr";
            this.btnSetAddr.Size = new System.Drawing.Size(155, 31);
            this.btnSetAddr.TabIndex = 40;
            this.btnSetAddr.Text = "기본 주소로 설정";
            this.btnSetAddr.UseVisualStyleBackColor = true;
            this.btnSetAddr.Click += new System.EventHandler(this.btnSetAddr_Click);
            // 
<<<<<<< HEAD
=======
            // baseZip
            // 
            this.baseZip.Address1 = "";
            this.baseZip.Address2 = "";
            this.baseZip.AddressName = "기본 주소명";
            this.baseZip.AddressNumber = 0;
            this.baseZip.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.baseZip.Location = new System.Drawing.Point(179, 463);
            this.baseZip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.baseZip.Name = "baseZip";
            this.baseZip.Size = new System.Drawing.Size(284, 131);
            this.baseZip.TabIndex = 41;
            this.baseZip.ZipCode = "";
            // 
>>>>>>> a1f384a (COMMIT 1)
            // email
            // 
            this.email.Email1 = "";
            this.email.Email2 = null;
            this.email.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.email.Location = new System.Drawing.Point(179, 407);
            this.email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(427, 32);
            this.email.TabIndex = 38;
            // 
            // ntbPhone3
            // 
            this.ntbPhone3.Location = new System.Drawing.Point(346, 622);
            this.ntbPhone3.MaxLength = 4;
            this.ntbPhone3.Name = "ntbPhone3";
            this.ntbPhone3.Size = new System.Drawing.Size(66, 22);
            this.ntbPhone3.TabIndex = 13;
            // 
            // ntbPhone2
            // 
            this.ntbPhone2.Location = new System.Drawing.Point(255, 622);
            this.ntbPhone2.MaxLength = 4;
            this.ntbPhone2.Name = "ntbPhone2";
            this.ntbPhone2.Size = new System.Drawing.Size(66, 22);
            this.ntbPhone2.TabIndex = 12;
            // 
            // ntbPhone1
            // 
            this.ntbPhone1.Location = new System.Drawing.Point(179, 622);
            this.ntbPhone1.MaxLength = 3;
            this.ntbPhone1.Name = "ntbPhone1";
            this.ntbPhone1.Size = new System.Drawing.Size(51, 22);
            this.ntbPhone1.TabIndex = 11;
            // 
<<<<<<< HEAD
            // baseZip
            // 
            this.baseZip.Address1 = "";
            this.baseZip.Address2 = "";
            this.baseZip.AddressName = "기본 주소명";
            this.baseZip.AddressNumber = 0;
            this.baseZip.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.baseZip.Location = new System.Drawing.Point(179, 463);
            this.baseZip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.baseZip.Name = "baseZip";
            this.baseZip.Size = new System.Drawing.Size(284, 131);
            this.baseZip.TabIndex = 41;
            this.baseZip.ZipCode = "";
            // 
=======
>>>>>>> a1f384a (COMMIT 1)
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 845);
            this.Controls.Add(this.baseZip);
            this.Controls.Add(this.pnlSetAddr);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblPasswordSame);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.ntbPhone3);
            this.Controls.Add(this.ntbPhone2);
            this.Controls.Add(this.ntbPhone1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnIDCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.pnlGenderSelect);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPasswordConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label10);
<<<<<<< HEAD
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
=======
            this.Controls.Add(this.labelAddr);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelBirth);
            this.Controls.Add(this.labelGen);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelChk);
            this.Controls.Add(this.labelPw);
            this.Controls.Add(this.labelID);
>>>>>>> a1f384a (COMMIT 1)
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCustomer_KeyPress);
            this.pnlGenderSelect.ResumeLayout(false);
            this.pnlGenderSelect.PerformLayout();
            this.pnlSetAddr.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
<<<<<<< HEAD
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
=======
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelPw;
        private System.Windows.Forms.Label labelChk;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelGen;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelAddr;
>>>>>>> a1f384a (COMMIT 1)
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton rdoM;
        private System.Windows.Forms.Panel pnlGenderSelect;
        private System.Windows.Forms.RadioButton rdoF;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnIDCheck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private NumTextBox ntbPhone1;
        private NumTextBox ntbPhone2;
        private NumTextBox ntbPhone3;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPasswordSame;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private EmailUserControl email;
        private System.Windows.Forms.ComboBox cboSelectAddr;
        private System.Windows.Forms.Panel pnlSetAddr;
        private System.Windows.Forms.Button btnSetAddr;
        private System.Windows.Forms.Button btnAddAddr;
        private ZipCodeUserControl baseZip;
    }
}