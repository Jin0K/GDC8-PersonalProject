
namespace PersonalProject
{
    partial class OrderUserControl
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
            this.llbOrderNumber = new System.Windows.Forms.LinkLabel();
            this.lblAddressName = new System.Windows.Forms.Label();
            this.lblOrderAmount = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblOrderState = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // llbOrderNumber
            // 
            this.llbOrderNumber.AutoSize = true;
            this.llbOrderNumber.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.llbOrderNumber.Location = new System.Drawing.Point(529, 31);
            this.llbOrderNumber.Name = "llbOrderNumber";
            this.llbOrderNumber.Size = new System.Drawing.Size(55, 15);
            this.llbOrderNumber.TabIndex = 0;
            this.llbOrderNumber.TabStop = true;
            this.llbOrderNumber.Text = "주문번호";
            this.llbOrderNumber.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbOrderNumber_LinkClicked);
            // 
            // lblAddressName
            // 
            this.lblAddressName.AutoSize = true;
            this.lblAddressName.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddressName.Location = new System.Drawing.Point(130, 8);
            this.lblAddressName.Name = "lblAddressName";
            this.lblAddressName.Size = new System.Drawing.Size(43, 15);
            this.lblAddressName.TabIndex = 1;
            this.lblAddressName.Text = "주소명";
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.AutoSize = true;
            this.lblOrderAmount.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmount.Location = new System.Drawing.Point(682, 31);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.Size = new System.Drawing.Size(55, 15);
            this.lblOrderAmount.TabIndex = 2;
            this.lblOrderAmount.Text = "주문금액";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDateTime.Location = new System.Drawing.Point(21, 20);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(81, 36);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "주문일시";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblOrderState
            // 
            this.lblOrderState.AutoSize = true;
            this.lblOrderState.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderState.Location = new System.Drawing.Point(819, 31);
            this.lblOrderState.Name = "lblOrderState";
            this.lblOrderState.Size = new System.Drawing.Size(55, 15);
            this.lblOrderState.TabIndex = 4;
            this.lblOrderState.Text = "주문상태";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddress1.Location = new System.Drawing.Point(201, 30);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(39, 15);
            this.lblAddress1.TabIndex = 5;
            this.lblAddress1.Text = "주소1";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAddress2.Location = new System.Drawing.Point(130, 52);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(39, 15);
            this.lblAddress2.TabIndex = 6;
            this.lblAddress2.Text = "주소2";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZipCode.Location = new System.Drawing.Point(130, 30);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(55, 15);
            this.lblZipCode.TabIndex = 7;
            this.lblZipCode.Text = "우편번호";
            // 
            // OrderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblZipCode);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.lblAddress1);
            this.Controls.Add(this.lblOrderState);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblOrderAmount);
            this.Controls.Add(this.lblAddressName);
            this.Controls.Add(this.llbOrderNumber);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OrderUserControl";
            this.Size = new System.Drawing.Size(900, 70);
            this.DoubleClick += new System.EventHandler(this.OrderUserControl_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llbOrderNumber;
        private System.Windows.Forms.Label lblAddressName;
        private System.Windows.Forms.Label lblOrderAmount;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblOrderState;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblZipCode;
    }
}
