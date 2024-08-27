
namespace PersonalProject
{
    partial class frmProduct
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvMenu = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.cboSubCategory = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMidCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMainCategory = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.pnlSort = new System.Windows.Forms.Panel();
            this.lblSales = new System.Windows.Forms.LinkLabel();
            this.llbSale = new System.Windows.Forms.LinkLabel();
            this.llbProductName = new System.Windows.Forms.LinkLabel();
            this.llbRegist = new System.Windows.Forms.LinkLabel();
            this.llbPrice = new System.Windows.Forms.LinkLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1042, 562);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.SplitterWidth = 11;
            this.splitContainer1.TabIndex = 0;
            // 
            // trvMenu
            // 
            this.trvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenu.Location = new System.Drawing.Point(0, 0);
            this.trvMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trvMenu.Name = "trvMenu";
            this.trvMenu.Size = new System.Drawing.Size(201, 562);
            this.trvMenu.TabIndex = 0;
            this.trvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMenu_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer2.Panel1.Controls.Add(this.cboBrand);
            this.splitContainer2.Panel1.Controls.Add(this.cboSubCategory);
            this.splitContainer2.Panel1.Controls.Add(this.txtKeyword);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.cboMidCategory);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.cboMainCategory);
            this.splitContainer2.Panel1.Controls.Add(this.btnSelect);
            this.splitContainer2.Panel1.Controls.Add(this.pnlSort);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer2.Size = new System.Drawing.Size(830, 562);
            this.splitContainer2.SplitterDistance = 115;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(750, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 23);
            this.btnSearch.TabIndex = 47;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboBrand
            // 
            this.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(565, 15);
            this.cboBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(138, 23);
            this.cboBrand.TabIndex = 34;
            // 
            // cboSubCategory
            // 
            this.cboSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubCategory.FormattingEnabled = true;
            this.cboSubCategory.Location = new System.Drawing.Point(381, 15);
            this.cboSubCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSubCategory.Name = "cboSubCategory";
            this.cboSubCategory.Size = new System.Drawing.Size(138, 23);
            this.cboSubCategory.TabIndex = 33;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Location = new System.Drawing.Point(554, 74);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(194, 22);
            this.txtKeyword.TabIndex = 32;
            this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "검색";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "정렬 기준";
            // 
            // cboMidCategory
            // 
            this.cboMidCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMidCategory.FormattingEnabled = true;
            this.cboMidCategory.Location = new System.Drawing.Point(237, 15);
            this.cboMidCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMidCategory.Name = "cboMidCategory";
            this.cboMidCategory.Size = new System.Drawing.Size(138, 23);
            this.cboMidCategory.TabIndex = 4;
            this.cboMidCategory.SelectedIndexChanged += new System.EventHandler(this.cboMidCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "조회 기준";
            // 
            // cboMainCategory
            // 
            this.cboMainCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainCategory.FormattingEnabled = true;
            this.cboMainCategory.Location = new System.Drawing.Point(89, 15);
            this.cboMainCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMainCategory.Name = "cboMainCategory";
            this.cboMainCategory.Size = new System.Drawing.Size(138, 23);
            this.cboMainCategory.TabIndex = 1;
            this.cboMainCategory.SelectedIndexChanged += new System.EventHandler(this.cboMainCategory_SelectedIndexChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(720, 15);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(86, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "조회";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // pnlSort
            // 
            this.pnlSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSort.Controls.Add(this.lblSales);
            this.pnlSort.Controls.Add(this.llbSale);
            this.pnlSort.Controls.Add(this.llbProductName);
            this.pnlSort.Controls.Add(this.llbRegist);
            this.pnlSort.Controls.Add(this.llbPrice);
            this.pnlSort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlSort.Location = new System.Drawing.Point(89, 69);
            this.pnlSort.Name = "pnlSort";
            this.pnlSort.Size = new System.Drawing.Size(374, 28);
            this.pnlSort.TabIndex = 39;
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.LinkColor = System.Drawing.Color.Black;
            this.lblSales.Location = new System.Drawing.Point(288, 6);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(55, 15);
            this.lblSales.TabIndex = 39;
            this.lblSales.TabStop = true;
            this.lblSales.Text = "판매량순";
            this.lblSales.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSales_LinkClicked);
            // 
            // llbSale
            // 
            this.llbSale.AutoSize = true;
            this.llbSale.LinkColor = System.Drawing.Color.Black;
            this.llbSale.Location = new System.Drawing.Point(210, 6);
            this.llbSale.Name = "llbSale";
            this.llbSale.Size = new System.Drawing.Size(55, 15);
            this.llbSale.TabIndex = 38;
            this.llbSale.TabStop = true;
            this.llbSale.Text = "할인율순";
            this.llbSale.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSale_LinkClicked);
            // 
            // llbProductName
            // 
            this.llbProductName.AutoSize = true;
            this.llbProductName.LinkColor = System.Drawing.Color.Black;
            this.llbProductName.Location = new System.Drawing.Point(3, 6);
            this.llbProductName.Name = "llbProductName";
            this.llbProductName.Size = new System.Drawing.Size(55, 15);
            this.llbProductName.TabIndex = 37;
            this.llbProductName.TabStop = true;
            this.llbProductName.Text = "상품명순";
            this.llbProductName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbProductName_LinkClicked);
            // 
            // llbRegist
            // 
            this.llbRegist.AutoSize = true;
            this.llbRegist.LinkColor = System.Drawing.Color.Black;
            this.llbRegist.Location = new System.Drawing.Point(145, 6);
            this.llbRegist.Name = "llbRegist";
            this.llbRegist.Size = new System.Drawing.Size(43, 15);
            this.llbRegist.TabIndex = 36;
            this.llbRegist.TabStop = true;
            this.llbRegist.Text = "등록순";
            this.llbRegist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbRegist_LinkClicked);
            // 
            // llbPrice
            // 
            this.llbPrice.AutoSize = true;
            this.llbPrice.LinkColor = System.Drawing.Color.Black;
            this.llbPrice.Location = new System.Drawing.Point(80, 6);
            this.llbPrice.Name = "llbPrice";
            this.llbPrice.Size = new System.Drawing.Size(43, 15);
            this.llbPrice.TabIndex = 35;
            this.llbPrice.TabStop = true;
            this.llbPrice.Text = "가격순";
            this.llbPrice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbPrice_LinkClicked);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 562);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProduct";
            this.Text = "상품";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.ResizeEnd += new System.EventHandler(this.frmProduct_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlSort.ResumeLayout(false);
            this.pnlSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvMenu;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cboMidCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMainCategory;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.ComboBox cboSubCategory;
        private System.Windows.Forms.LinkLabel llbSale;
        private System.Windows.Forms.LinkLabel llbProductName;
        private System.Windows.Forms.LinkLabel llbRegist;
        private System.Windows.Forms.LinkLabel llbPrice;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pnlSort;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.LinkLabel lblSales;
    }
}