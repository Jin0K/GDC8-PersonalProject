
namespace PersonalProject
{
    partial class BuyItemUserControl
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
            this.lblOption = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.pctMainImage = new System.Windows.Forms.PictureBox();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.lblDiscountPrice = new System.Windows.Forms.Label();
            this.lblDiscountRate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctMainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(120, 89);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(31, 15);
            this.lblOption.TabIndex = 9;
            this.lblOption.Text = "옵션";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(362, 59);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPrice.Size = new System.Drawing.Size(102, 15);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "가격";
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(557, 38);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(31, 15);
            this.lblQty.TabIndex = 6;
            this.lblQty.Text = "수량";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(199, 38);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(43, 15);
            this.lblProductName.TabIndex = 5;
            this.lblProductName.Text = "상품명";
            // 
            // pctMainImage
            // 
            this.pctMainImage.Image = global::PersonalProject.Properties.Resources.poll_859_9;
            this.pctMainImage.Location = new System.Drawing.Point(0, 0);
            this.pctMainImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pctMainImage.Name = "pctMainImage";
            this.pctMainImage.Size = new System.Drawing.Size(114, 114);
            this.pctMainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctMainImage.TabIndex = 8;
            this.pctMainImage.TabStop = false;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(630, 38);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(47, 15);
            this.lblTotalPrice.TabIndex = 10;
            this.lblTotalPrice.Text = "총 가격";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Location = new System.Drawing.Point(199, 12);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(55, 15);
            this.lblProductCode.TabIndex = 11;
            this.lblProductCode.Text = "상품코드";
            // 
            // lblDiscountPrice
            // 
            this.lblDiscountPrice.AutoSize = true;
            this.lblDiscountPrice.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDiscountPrice.Location = new System.Drawing.Point(433, 35);
            this.lblDiscountPrice.Name = "lblDiscountPrice";
            this.lblDiscountPrice.Size = new System.Drawing.Size(54, 19);
            this.lblDiscountPrice.TabIndex = 12;
            this.lblDiscountPrice.Text = "할인가";
            // 
            // lblDiscountRate
            // 
            this.lblDiscountRate.AutoSize = true;
            this.lblDiscountRate.Location = new System.Drawing.Point(468, 59);
            this.lblDiscountRate.Name = "lblDiscountRate";
            this.lblDiscountRate.Size = new System.Drawing.Size(43, 15);
            this.lblDiscountRate.TabIndex = 13;
            this.lblDiscountRate.Text = "할인율";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "상품코드";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "상품명";
            // 
            // BuyItemUserControl
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
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BuyItemUserControl";
            this.Size = new System.Drawing.Size(734, 115);
            ((System.ComponentModel.ISupportInitialize)(this.pctMainImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.PictureBox pctMainImage;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label lblDiscountPrice;
        private System.Windows.Forms.Label lblDiscountRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
