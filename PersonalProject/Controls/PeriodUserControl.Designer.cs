
namespace PersonalProject
{
    partial class PeriodUserControl
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
            this.btnAll = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.btn3Month = new System.Windows.Forms.Button();
            this.btn1Month = new System.Windows.Forms.Button();
            this.btn1Week = new System.Windows.Forms.Button();
            this.btn1Day = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAll.Location = new System.Drawing.Point(554, 0);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(56, 29);
            this.btnAll.TabIndex = 39;
            this.btnAll.Text = "전체";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnThisMonth.Location = new System.Drawing.Point(497, 0);
            this.btnThisMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(56, 29);
            this.btnThisMonth.TabIndex = 38;
            this.btnThisMonth.Text = "이번달";
            this.btnThisMonth.UseVisualStyleBackColor = true;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btn3Month
            // 
            this.btn3Month.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn3Month.Location = new System.Drawing.Point(440, 0);
            this.btn3Month.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn3Month.Name = "btn3Month";
            this.btn3Month.Size = new System.Drawing.Size(56, 29);
            this.btn3Month.TabIndex = 37;
            this.btn3Month.Text = "3개월";
            this.btn3Month.UseVisualStyleBackColor = true;
            this.btn3Month.Click += new System.EventHandler(this.btn3Month_Click);
            // 
            // btn1Month
            // 
            this.btn1Month.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn1Month.Location = new System.Drawing.Point(383, 0);
            this.btn1Month.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn1Month.Name = "btn1Month";
            this.btn1Month.Size = new System.Drawing.Size(56, 29);
            this.btn1Month.TabIndex = 36;
            this.btn1Month.Text = "1개월";
            this.btn1Month.UseVisualStyleBackColor = true;
            this.btn1Month.Click += new System.EventHandler(this.btn1Month_Click);
            // 
            // btn1Week
            // 
            this.btn1Week.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn1Week.Location = new System.Drawing.Point(326, 0);
            this.btn1Week.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn1Week.Name = "btn1Week";
            this.btn1Week.Size = new System.Drawing.Size(56, 29);
            this.btn1Week.TabIndex = 35;
            this.btn1Week.Text = "1주일";
            this.btn1Week.UseVisualStyleBackColor = true;
            this.btn1Week.Click += new System.EventHandler(this.btn1Week_Click);
            // 
            // btn1Day
            // 
            this.btn1Day.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn1Day.Location = new System.Drawing.Point(279, 0);
            this.btn1Day.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn1Day.Name = "btn1Day";
            this.btn1Day.Size = new System.Drawing.Size(46, 29);
            this.btn1Day.TabIndex = 34;
            this.btn1Day.Text = "1일";
            this.btn1Day.UseVisualStyleBackColor = true;
            this.btn1Day.Click += new System.EventHandler(this.btn1Day_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(130, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "~";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(153, 4);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(123, 22);
            this.dtpTo.TabIndex = 32;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(0, 4);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(123, 22);
            this.dtpFrom.TabIndex = 31;
            // 
            // PeriodUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnThisMonth);
            this.Controls.Add(this.btn3Month);
            this.Controls.Add(this.btn1Month);
            this.Controls.Add(this.btn1Week);
            this.Controls.Add(this.btn1Day);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PeriodUserControl";
            this.Size = new System.Drawing.Size(612, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Button btn3Month;
        private System.Windows.Forms.Button btn1Month;
        private System.Windows.Forms.Button btn1Week;
        private System.Windows.Forms.Button btn1Day;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}
