
namespace PersonalProject.UserControls
{
    partial class ucImageSelector
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
            this.ucImage = new System.Windows.Forms.PictureBox();
            this.ucLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ucImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ucImage
            // 
            this.ucImage.Location = new System.Drawing.Point(0, 0);
            this.ucImage.Name = "ucImage";
            this.ucImage.Size = new System.Drawing.Size(98, 131);
            this.ucImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ucImage.TabIndex = 20;
            this.ucImage.TabStop = false;
            // 
            // ucLabel
            // 
            this.ucLabel.Location = new System.Drawing.Point(19, 54);
            this.ucLabel.Name = "ucLabel";
            this.ucLabel.Size = new System.Drawing.Size(60, 23);
            this.ucLabel.TabIndex = 21;
            this.ucLabel.Text = "No Image";
            this.ucLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucImageSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucLabel);
            this.Controls.Add(this.ucImage);
            this.Name = "ucImageSelector";
            this.Size = new System.Drawing.Size(98, 131);
            ((System.ComponentModel.ISupportInitialize)(this.ucImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ucImage;
        private System.Windows.Forms.Label ucLabel;
    }
}
