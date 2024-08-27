
namespace PersonalProject
{
    partial class OrderDetailUserControl
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
            this.btnReview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDiscountRate = new System.Windows.Forms.Label();
            this.lblDiscountPrice = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblOption = new System.Windows.Forms.Label();
            this.pctMainImage = new System.Windows.Forms.PictureBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReview
            // 
            this.btnReview.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReview.Location = new System.Drawing.Point(829, 55);
            this.btnReview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(86, 29);
            this.btnReview.TabIndex = 5;
            this.btnReview.Text = "후기 작성";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "상품명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "상품코드";
            // 
            // lblDiscountRate
            // 
            this.lblDiscountRate.AutoSize = true;
            this.lblDiscountRate.Location = new System.Drawing.Point(557, 86);
            this.lblDiscountRate.Name = "lblDiscountRate";
            this.lblDiscountRate.Size = new System.Drawing.Size(43, 15);
            this.lblDiscountRate.TabIndex = 24;
            this.lblDiscountRate.Text = "할인율";
            // 
            // lblDiscountPrice
            // 
            this.lblDiscountPrice.AutoSize = true;
            this.lblDiscountPrice.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDiscountPrice.Location = new System.Drawing.Point(517, 56);
            this.lblDiscountPrice.Name = "lblDiscountPrice";
            this.lblDiscountPrice.Size = new System.Drawing.Size(54, 19);
            this.lblDiscountPrice.TabIndex = 23;
            this.lblDiscountPrice.Text = "할인가";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(229, 15);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(55, 15);
            this.lblProductCode.TabIndex = 22;
            this.lblProductCode.Text = "상품코드";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(721, 62);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(47, 15);
            this.lblTotalPrice.TabIndex = 21;
            this.lblTotalPrice.Text = "총 가격";
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(138, 111);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(31, 15);
            this.lblOption.TabIndex = 20;
            this.lblOption.Text = "옵션";
            // 
            // pctMainImage
            // 
            this.pctMainImage.Image = global::PersonalProject.Properties.Resources.poll_859_9;
            this.pctMainImage.Location = new System.Drawing.Point(1, 0);
            this.pctMainImage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pctMainImage.Name = "pctMainImage";
            this.pctMainImage.Size = new System.Drawing.Size(130, 136);
            this.pctMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctMainImage.TabIndex = 19;
            this.pctMainImage.TabStop = false;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(435, 86);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrice.Size = new System.Drawing.Size(117, 19);
            this.lblPrice.TabIndex = 18;
            this.lblPrice.Text = "가격";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(638, 62);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(31, 15);
            this.lblQty.TabIndex = 17;
            this.lblQty.Text = "수량";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(229, 48);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(43, 15);
            this.lblProductName.TabIndex = 16;
            this.lblProductName.Text = "상품명";
            // 
            // OrderDetailUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDiscountRate);
            this.Controls.Add(this.lblDiscountPrice);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblOption);
            this.Controls.Add(this.pctMainImage);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.btnReview);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OrderDetailUserControl";
            this.Size = new System.Drawing.Size(915, 135);
            ((System.ComponentModel.ISupportInitialize)(this.pctMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDiscountRate;
        private System.Windows.Forms.Label lblDiscountPrice;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.PictureBox pctMainImage;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblProductName;
    }
}
