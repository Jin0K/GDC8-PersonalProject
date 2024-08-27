
namespace PersonalProject
{
    partial class BaseForm
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
            this.pnlLocalNavigationBar = new System.Windows.Forms.Panel();
            this.btnCloses = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLocalNavigationBar
            // 
            this.pnlLocalNavigationBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlLocalNavigationBar.Controls.Add(this.btnCloses);
            this.pnlLocalNavigationBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLocalNavigationBar.Location = new System.Drawing.Point(0, 0);
            this.pnlLocalNavigationBar.Name = "pnlLocalNavigationBar";
            this.pnlLocalNavigationBar.Size = new System.Drawing.Size(882, 85);
            this.pnlLocalNavigationBar.TabIndex = 0;
            // 
            // btnCloses
            // 
            this.btnCloses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloses.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCloses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloses.Location = new System.Drawing.Point(812, 12);
            this.btnCloses.Name = "btnCloses";
            this.btnCloses.Size = new System.Drawing.Size(58, 36);
            this.btnCloses.TabIndex = 25;
            this.btnCloses.Text = "창닫기";
            this.btnCloses.UseVisualStyleBackColor = false;
            this.btnCloses.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 85);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(882, 471);
            this.pnlContent.TabIndex = 1;
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 556);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlLocalNavigationBar);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlLocalNavigationBar;
        protected System.Windows.Forms.Panel pnlContent;
        protected System.Windows.Forms.Button btnCloses;
    }
}