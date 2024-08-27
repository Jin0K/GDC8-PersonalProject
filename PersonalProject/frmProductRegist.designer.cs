
namespace PersonalProject
{
    partial class frmProductRegist
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
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnImgUpload = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMainCategory = new System.Windows.Forms.ComboBox();
            this.cboMidCategory = new System.Windows.Forms.ComboBox();
            this.cboSubCategory = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.pctMainImg = new System.Windows.Forms.PictureBox();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.txtImgPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboImgDiv = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cboSize = new System.Windows.Forms.ComboBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.lblBrand = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlSubImages = new System.Windows.Forms.Panel();
            this.txtDiscountRate = new System.Windows.Forms.TextBox();
            this.lstOption = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstOptionValue = new System.Windows.Forms.ListBox();
            this.cboExistColor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiscountPrice = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnDeleteOption = new System.Windows.Forms.Button();
            this.lstPicture = new System.Windows.Forms.ListBox();
            this.btnDeletePicture = new System.Windows.Forms.Button();
            this.lstPictureText = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctMainImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegist
            // 
            this.btnRegist.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegist.Location = new System.Drawing.Point(294, 614);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(75, 23);
            this.btnRegist.TabIndex = 69;
            this.btnRegist.Text = "상품 등록";
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnImgUpload
            // 
            this.btnImgUpload.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnImgUpload.Location = new System.Drawing.Point(667, 478);
            this.btnImgUpload.Name = "btnImgUpload";
            this.btnImgUpload.Size = new System.Drawing.Size(61, 23);
            this.btnImgUpload.TabIndex = 68;
            this.btnImgUpload.Text = "업로드";
            this.btnImgUpload.UseVisualStyleBackColor = true;
            this.btnImgUpload.Click += new System.EventHandler(this.btnImgUpload_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(562, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 15);
            this.label15.TabIndex = 65;
            this.label15.Text = "할인가";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(364, 327);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 54;
            this.label12.Text = "설명";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(364, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 53;
            this.label11.Text = "가격";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(352, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 52;
            this.label10.Text = "사이즈";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(562, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 51;
            this.label9.Text = "색상";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(340, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 50;
            this.label7.Text = "카테고리";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(352, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 47;
            this.label4.Text = "브랜드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(562, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 46;
            this.label3.Text = "할인율";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(352, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "제품명";
            // 
            // cboMainCategory
            // 
            this.cboMainCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainCategory.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboMainCategory.FormattingEnabled = true;
            this.cboMainCategory.Location = new System.Drawing.Point(403, 12);
            this.cboMainCategory.Name = "cboMainCategory";
            this.cboMainCategory.Size = new System.Drawing.Size(121, 23);
            this.cboMainCategory.TabIndex = 70;
            this.cboMainCategory.SelectedIndexChanged += new System.EventHandler(this.cboMainCategory_SelectedIndexChanged);
            // 
            // cboMidCategory
            // 
            this.cboMidCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMidCategory.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboMidCategory.FormattingEnabled = true;
            this.cboMidCategory.Location = new System.Drawing.Point(535, 12);
            this.cboMidCategory.Name = "cboMidCategory";
            this.cboMidCategory.Size = new System.Drawing.Size(121, 23);
            this.cboMidCategory.TabIndex = 71;
            this.cboMidCategory.SelectedIndexChanged += new System.EventHandler(this.cboMidCategory_SelectedIndexChanged);
            // 
            // cboSubCategory
            // 
            this.cboSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubCategory.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSubCategory.FormattingEnabled = true;
            this.cboSubCategory.Location = new System.Drawing.Point(667, 12);
            this.cboSubCategory.Name = "cboSubCategory";
            this.cboSubCategory.Size = new System.Drawing.Size(121, 23);
            this.cboSubCategory.TabIndex = 72;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductName.Location = new System.Drawing.Point(403, 48);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(385, 22);
            this.txtProductName.TabIndex = 73;
            // 
            // pctMainImg
            // 
            this.pctMainImg.Location = new System.Drawing.Point(12, 12);
            this.pctMainImg.Name = "pctMainImg";
            this.pctMainImg.Size = new System.Drawing.Size(312, 389);
            this.pctMainImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctMainImg.TabIndex = 55;
            this.pctMainImg.TabStop = false;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductDescription.Location = new System.Drawing.Point(404, 327);
            this.txtProductDescription.Multiline = true;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(385, 143);
            this.txtProductDescription.TabIndex = 80;
            // 
            // txtImgPath
            // 
            this.txtImgPath.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtImgPath.Location = new System.Drawing.Point(404, 510);
            this.txtImgPath.Name = "txtImgPath";
            this.txtImgPath.ReadOnly = true;
            this.txtImgPath.Size = new System.Drawing.Size(385, 22);
            this.txtImgPath.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(329, 482);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 81;
            this.label2.Text = "이미지 분류";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(329, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 83;
            this.label5.Text = "이미지 경로";
            // 
            // cboImgDiv
            // 
            this.cboImgDiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImgDiv.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboImgDiv.FormattingEnabled = true;
            this.cboImgDiv.Location = new System.Drawing.Point(404, 479);
            this.cboImgDiv.Name = "cboImgDiv";
            this.cboImgDiv.Size = new System.Drawing.Size(121, 23);
            this.cboImgDiv.TabIndex = 84;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(403, 614);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 85;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cboSize
            // 
            this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSize.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSize.FormattingEnabled = true;
            this.cboSize.Location = new System.Drawing.Point(403, 189);
            this.cboSize.Name = "cboSize";
            this.cboSize.Size = new System.Drawing.Size(121, 23);
            this.cboSize.TabIndex = 86;
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(625, 189);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(121, 23);
            this.cboColor.TabIndex = 87;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(364, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 88;
            this.label6.Text = "수량";
            // 
            // nudQty
            // 
            this.nudQty.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudQty.Location = new System.Drawing.Point(403, 228);
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(120, 22);
            this.nudQty.TabIndex = 89;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBrand.Location = new System.Drawing.Point(401, 87);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(55, 15);
            this.lblBrand.TabIndex = 90;
            this.lblBrand.Text = "브랜드명";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(731, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 15);
            this.label8.TabIndex = 92;
            this.label8.Text = "%";
            // 
            // pnlSubImages
            // 
            this.pnlSubImages.AutoScroll = true;
            this.pnlSubImages.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlSubImages.Location = new System.Drawing.Point(12, 408);
            this.pnlSubImages.Name = "pnlSubImages";
            this.pnlSubImages.Size = new System.Drawing.Size(312, 92);
            this.pnlSubImages.TabIndex = 94;
            // 
            // txtDiscountRate
            // 
            this.txtDiscountRate.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDiscountRate.Location = new System.Drawing.Point(625, 155);
            this.txtDiscountRate.Name = "txtDiscountRate";
            this.txtDiscountRate.Size = new System.Drawing.Size(100, 22);
            this.txtDiscountRate.TabIndex = 96;
            this.txtDiscountRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountRate_KeyPress);
            this.txtDiscountRate.Leave += new System.EventHandler(this.txtDiscountRate_Leave);
            // 
            // lstOption
            // 
            this.lstOption.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstOption.FormattingEnabled = true;
            this.lstOption.ItemHeight = 15;
            this.lstOption.Location = new System.Drawing.Point(403, 268);
            this.lstOption.Name = "lstOption";
            this.lstOption.Size = new System.Drawing.Size(342, 49);
            this.lstOption.TabIndex = 97;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(565, 230);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 23);
            this.btnAdd.TabIndex = 98;
            this.btnAdd.Text = "옵션별 수량 추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstOptionValue
            // 
            this.lstOptionValue.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstOptionValue.FormattingEnabled = true;
            this.lstOptionValue.ItemHeight = 15;
            this.lstOptionValue.Location = new System.Drawing.Point(403, 268);
            this.lstOptionValue.Name = "lstOptionValue";
            this.lstOptionValue.Size = new System.Drawing.Size(342, 34);
            this.lstOptionValue.TabIndex = 99;
            // 
            // cboExistColor
            // 
            this.cboExistColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExistColor.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboExistColor.FormattingEnabled = true;
            this.cboExistColor.Location = new System.Drawing.Point(531, 479);
            this.cboExistColor.Name = "cboExistColor";
            this.cboExistColor.Size = new System.Drawing.Size(121, 23);
            this.cboExistColor.TabIndex = 101;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(12, 503);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(231, 15);
            this.label13.TabIndex = 102;
            this.label13.Text = "* 대표 이미지는 하나만 등록 가능합니다.";
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.Location = new System.Drawing.Point(625, 116);
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.Size = new System.Drawing.Size(100, 21);
            this.txtDiscountPrice.TabIndex = 103;
            this.txtDiscountPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountPrice_KeyPress);
            this.txtDiscountPrice.Leave += new System.EventHandler(this.txtDiscountPrice_Leave);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(404, 116);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 21);
            this.txtPrice.TabIndex = 104;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountPrice_KeyPress);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // btnDeleteOption
            // 
            this.btnDeleteOption.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteOption.Location = new System.Drawing.Point(691, 230);
            this.btnDeleteOption.Name = "btnDeleteOption";
            this.btnDeleteOption.Size = new System.Drawing.Size(55, 23);
            this.btnDeleteOption.TabIndex = 105;
            this.btnDeleteOption.Text = "삭제";
            this.btnDeleteOption.UseVisualStyleBackColor = true;
            this.btnDeleteOption.Click += new System.EventHandler(this.btnDeleteOption_Click);
            // 
            // lstPicture
            // 
            this.lstPicture.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstPicture.FormattingEnabled = true;
            this.lstPicture.ItemHeight = 15;
            this.lstPicture.Location = new System.Drawing.Point(403, 538);
            this.lstPicture.Name = "lstPicture";
            this.lstPicture.Size = new System.Drawing.Size(385, 64);
            this.lstPicture.TabIndex = 106;
            this.lstPicture.Click += new System.EventHandler(this.lstPicture_Click);
            this.lstPicture.DoubleClick += new System.EventHandler(this.lstPicture_DoubleClick);
            // 
            // btnDeletePicture
            // 
            this.btnDeletePicture.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeletePicture.Location = new System.Drawing.Point(734, 478);
            this.btnDeletePicture.Name = "btnDeletePicture";
            this.btnDeletePicture.Size = new System.Drawing.Size(55, 23);
            this.btnDeletePicture.TabIndex = 107;
            this.btnDeletePicture.Text = "삭제";
            this.btnDeletePicture.UseVisualStyleBackColor = true;
            this.btnDeletePicture.Click += new System.EventHandler(this.btnDeletePicture_Click);
            // 
            // lstPictureText
            // 
            this.lstPictureText.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstPictureText.FormattingEnabled = true;
            this.lstPictureText.ItemHeight = 15;
            this.lstPictureText.Location = new System.Drawing.Point(403, 538);
            this.lstPictureText.Name = "lstPictureText";
            this.lstPictureText.Size = new System.Drawing.Size(385, 64);
            this.lstPictureText.TabIndex = 108;
            this.lstPictureText.Click += new System.EventHandler(this.lstPictureText_Click);
            // 
            // frmProductRegist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 658);
            this.Controls.Add(this.lstPictureText);
            this.Controls.Add(this.btnDeletePicture);
            this.Controls.Add(this.lstPicture);
            this.Controls.Add(this.btnDeleteOption);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDiscountPrice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboExistColor);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstOption);
            this.Controls.Add(this.txtDiscountRate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.cboSize);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboImgDiv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtImgPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductDescription);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.cboSubCategory);
            this.Controls.Add(this.cboMidCategory);
            this.Controls.Add(this.cboMainCategory);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.btnImgUpload);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pctMainImg);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlSubImages);
            this.Controls.Add(this.lstOptionValue);
            this.Name = "frmProductRegist";
            this.Text = "상품등록";
            this.Load += new System.EventHandler(this.frmProductRegist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctMainImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnImgUpload;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pctMainImg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMainCategory;
        private System.Windows.Forms.ComboBox cboMidCategory;
        private System.Windows.Forms.ComboBox cboSubCategory;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.TextBox txtImgPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboImgDiv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboSize;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlSubImages;
        private System.Windows.Forms.TextBox txtDiscountRate;
        private System.Windows.Forms.ListBox lstOption;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstOptionValue;
        private System.Windows.Forms.ComboBox cboExistColor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDiscountPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnDeleteOption;
        private System.Windows.Forms.ListBox lstPicture;
        private System.Windows.Forms.Button btnDeletePicture;
        private System.Windows.Forms.ListBox lstPictureText;
    }
}