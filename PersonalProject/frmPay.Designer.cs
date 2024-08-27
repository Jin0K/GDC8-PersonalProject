
namespace PersonalProject
{
    partial class frmPay
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUsePoint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ntbPoint = new PersonalProject.NumTextBox();
            this.ucZipCode = new PersonalProject.ZipCodeUserControl();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.lblAccumulatedPoint = new System.Windows.Forms.Label();
            this.lblPoint = new System.Windows.Forms.Label();
            this.lblPay = new System.Windows.Forms.Label();
            this.lblDiscountPrice = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
<<<<<<< HEAD
            this.label5 = new System.Windows.Forms.Label();
=======
>>>>>>> a1f384a (COMMIT 1)
            this.btnBuy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.finalUserControl2 = new PersonalProject.BuyItemUserControl();
            this.finalUserControl1 = new PersonalProject.BuyItemUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnUsePoint);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.ntbPoint);
            this.splitContainer1.Panel1.Controls.Add(this.ucZipCode);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddAddress);
            this.splitContainer1.Panel1.Controls.Add(this.lblAccumulatedPoint);
            this.splitContainer1.Panel1.Controls.Add(this.lblPoint);
            this.splitContainer1.Panel1.Controls.Add(this.lblPay);
            this.splitContainer1.Panel1.Controls.Add(this.lblDiscountPrice);
            this.splitContainer1.Panel1.Controls.Add(this.lblTotalPrice);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
<<<<<<< HEAD
            this.splitContainer1.Panel1.Controls.Add(this.label5);
=======
>>>>>>> a1f384a (COMMIT 1)
            this.splitContainer1.Panel1.Controls.Add(this.btnBuy);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cboAddress);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Size = new System.Drawing.Size(882, 450);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnUsePoint
            // 
            this.btnUsePoint.Location = new System.Drawing.Point(528, 47);
            this.btnUsePoint.Name = "btnUsePoint";
            this.btnUsePoint.Size = new System.Drawing.Size(49, 23);
            this.btnUsePoint.TabIndex = 34;
            this.btnUsePoint.Text = "사용";
            this.btnUsePoint.UseVisualStyleBackColor = true;
            this.btnUsePoint.Click += new System.EventHandler(this.btnUsePoint_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(503, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = "점";
            // 
            // ntbPoint
            // 
            this.ntbPoint.Location = new System.Drawing.Point(426, 48);
            this.ntbPoint.Name = "ntbPoint";
            this.ntbPoint.Size = new System.Drawing.Size(71, 22);
            this.ntbPoint.TabIndex = 32;
            this.ntbPoint.Text = "0";
            this.ntbPoint.TextChanged += new System.EventHandler(this.ntbPoint_TextChanged);
            // 
            // ucZipCode
            // 
            this.ucZipCode.Address1 = "";
            this.ucZipCode.Address2 = "";
            this.ucZipCode.AddressName = "기본 주소명";
            this.ucZipCode.AddressNumber = 0;
            this.ucZipCode.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ucZipCode.Location = new System.Drawing.Point(94, 45);
            this.ucZipCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucZipCode.Name = "ucZipCode";
            this.ucZipCode.Size = new System.Drawing.Size(284, 125);
            this.ucZipCode.TabIndex = 31;
            this.ucZipCode.ZipCode = "";
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddAddress.Location = new System.Drawing.Point(221, 12);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(122, 23);
            this.btnAddAddress.TabIndex = 30;
            this.btnAddAddress.Text = "배송지 추가/수정";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // lblAccumulatedPoint
            // 
            this.lblAccumulatedPoint.AutoSize = true;
            this.lblAccumulatedPoint.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAccumulatedPoint.Location = new System.Drawing.Point(706, 109);
            this.lblAccumulatedPoint.Name = "lblAccumulatedPoint";
            this.lblAccumulatedPoint.Size = new System.Drawing.Size(71, 15);
            this.lblAccumulatedPoint.TabIndex = 28;
            this.lblAccumulatedPoint.Text = "구매 적립금";
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPoint.Location = new System.Drawing.Point(451, 16);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(71, 15);
            this.lblPoint.TabIndex = 27;
            this.lblPoint.Text = "보유 적립금";
            // 
            // lblPay
            // 
            this.lblPay.AutoSize = true;
            this.lblPay.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPay.Location = new System.Drawing.Point(706, 78);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(59, 15);
            this.lblPay.TabIndex = 26;
            this.lblPay.Text = "결제 금액";
            // 
            // lblDiscountPrice
            // 
            this.lblDiscountPrice.AutoSize = true;
            this.lblDiscountPrice.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDiscountPrice.Location = new System.Drawing.Point(706, 47);
            this.lblDiscountPrice.Name = "lblDiscountPrice";
            this.lblDiscountPrice.Size = new System.Drawing.Size(43, 15);
            this.lblDiscountPrice.TabIndex = 25;
            this.lblDiscountPrice.Text = "할인액";
            this.lblDiscountPrice.Click += new System.EventHandler(this.lblDiscountPrice_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalPrice.Location = new System.Drawing.Point(706, 16);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(47, 15);
            this.lblTotalPrice.TabIndex = 24;
            this.lblTotalPrice.Text = "총 금액";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(374, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "포인트";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(374, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "보유 포인트";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(601, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "적립 예정 포인트";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
<<<<<<< HEAD
            this.label6.Location = new System.Drawing.Point(10, 82);
=======
            this.label6.Location = new System.Drawing.Point(10, 51);
>>>>>>> a1f384a (COMMIT 1)
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "주소";
            // 
<<<<<<< HEAD
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(10, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "우편번호";
            // 
=======
>>>>>>> a1f384a (COMMIT 1)
            // btnBuy
            // 
            this.btnBuy.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBuy.Location = new System.Drawing.Point(777, 141);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(93, 29);
            this.btnBuy.TabIndex = 15;
            this.btnBuy.Text = "결제하기";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(641, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "결제 금액";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(641, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "할인 금액";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(625, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "총 상품 금액";
            // 
            // cboAddress
            // 
            this.cboAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAddress.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboAddress.FormattingEnabled = true;
            this.cboAddress.Location = new System.Drawing.Point(94, 13);
            this.cboAddress.Name = "cboAddress";
            this.cboAddress.Size = new System.Drawing.Size(121, 23);
            this.cboAddress.TabIndex = 11;
            this.cboAddress.SelectedIndexChanged += new System.EventHandler(this.cboAddress_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "배송지 선택";
            // 
            // finalUserControl2
            // 
            this.finalUserControl2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.finalUserControl2.ItemQty = 0;
            this.finalUserControl2.Location = new System.Drawing.Point(27, 135);
            this.finalUserControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.finalUserControl2.Name = "finalUserControl2";
            this.finalUserControl2.ProductItem = null;
            this.finalUserControl2.Size = new System.Drawing.Size(717, 126);
            this.finalUserControl2.TabIndex = 1;
            // 
            // finalUserControl1
            // 
            this.finalUserControl1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.finalUserControl1.ItemQty = 0;
            this.finalUserControl1.Location = new System.Drawing.Point(27, 3);
            this.finalUserControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.finalUserControl1.Name = "finalUserControl1";
            this.finalUserControl1.ProductItem = null;
            this.finalUserControl1.Size = new System.Drawing.Size(717, 126);
            this.finalUserControl1.TabIndex = 0;
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPay";
            this.Text = "결제";
            this.Load += new System.EventHandler(this.frmPay_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
<<<<<<< HEAD
        private System.Windows.Forms.Label label5;
=======
>>>>>>> a1f384a (COMMIT 1)
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboAddress;
        private System.Windows.Forms.Label label1;
        private BuyItemUserControl finalUserControl2;
        private BuyItemUserControl finalUserControl1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label lblPay;
        private System.Windows.Forms.Label lblDiscountPrice;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblAccumulatedPoint;
        private System.Windows.Forms.Button btnAddAddress;
        private ZipCodeUserControl ucZipCode;
        private NumTextBox ntbPoint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUsePoint;
    }
}