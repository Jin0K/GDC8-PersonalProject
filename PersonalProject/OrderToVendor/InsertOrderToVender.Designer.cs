
namespace PersonalProject
{
    partial class InsertOrderToVender
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.grbOrderProductList = new System.Windows.Forms.GroupBox();
            this.txtMTMinOrder = new System.Windows.Forms.TextBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnCartDel = new System.Windows.Forms.Button();
            this.btnCartAdd = new System.Windows.Forms.Button();
            this.txtMTPrice = new System.Windows.Forms.TextBox();
            this.nuOrderQty = new System.Windows.Forms.NumericUpDown();
            this.labelOrderQty = new System.Windows.Forms.Label();
            this.txtMTUnit = new System.Windows.Forms.TextBox();
            this.cboComMtr = new System.Windows.Forms.ComboBox();
            this.labelComMtr = new System.Windows.Forms.Label();
            this.dtpRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.labelRequiredDate = new System.Windows.Forms.Label();
            this.cboCOM = new System.Windows.Forms.ComboBox();
            this.labelcboCOM = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.grbCompanyList = new System.Windows.Forms.GroupBox();
            this.dgvCompanyList = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cboMT = new System.Windows.Forms.ComboBox();
            this.labelcboMT = new System.Windows.Forms.Label();
            this.grbOrderCalc = new System.Windows.Forms.GroupBox();
            this.lblMTQty = new System.Windows.Forms.Label();
            this.lblWon2 = new System.Windows.Forms.Label();
            this.lblEA = new System.Windows.Forms.Label();
            this.lblWon = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.labelOrderQtyCalc = new System.Windows.Forms.Label();
            this.lblMTUnit = new System.Windows.Forms.Label();
            this.nuQty = new System.Windows.Forms.NumericUpDown();
            this.labelnuQty = new System.Windows.Forms.Label();
            this.lblMTPrice = new System.Windows.Forms.Label();
            this.labelComMTRUnitPrice = new System.Windows.Forms.Label();
            this.lblCOM = new System.Windows.Forms.Label();
            this.labelCOM = new System.Windows.Forms.Label();
            this.lblComMTRUnit = new System.Windows.Forms.Label();
            this.lblMTMinOrder = new System.Windows.Forms.Label();
            this.lblMT = new System.Windows.Forms.Label();
            this.labelMT = new System.Windows.Forms.Label();
            this.labelMTMinOrder = new System.Windows.Forms.Label();
            this.lblComMTRUnitPrice = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.pnlDetail.SuspendLayout();
            this.dgvList.SuspendLayout();
            this.pnlLocalNavigationBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            this.grbOrderProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuOrderQty)).BeginInit();
            this.grbCompanyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyList)).BeginInit();
            this.grbOrderCalc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuQty)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDetail
            // 
            this.pnlDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetail.Controls.Add(this.lblSum);
            this.pnlDetail.Controls.Add(this.pnlOrder);
            this.pnlDetail.Controls.Add(this.btnInsert);
            this.pnlDetail.Location = new System.Drawing.Point(516, 6);
            this.pnlDetail.Size = new System.Drawing.Size(539, 477);
            // 
            // dgvList
            // 
            this.dgvList.Controls.Add(this.grbOrderCalc);
            this.dgvList.Controls.Add(this.grbCompanyList);
            this.dgvList.Controls.Add(this.btnSelect);
            this.dgvList.Controls.Add(this.cboMT);
            this.dgvList.Controls.Add(this.labelcboMT);
            this.dgvList.Location = new System.Drawing.Point(14, 6);
            this.dgvList.Size = new System.Drawing.Size(496, 477);
            // 
            // btnSubMenu2
            // 
            this.btnSubMenu2.Tag = "ListStore";
            this.btnSubMenu2.Text = "입고관리";
            this.btnSubMenu2.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(2471, 11);
            // 
            // btnSubMenu
            // 
            this.btnSubMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubMenu.Tag = "ListOrderToVendor";
            this.btnSubMenu.Text = "발주관리";
            this.btnSubMenu.UseVisualStyleBackColor = false;
            this.btnSubMenu.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnSubMenu3
            // 
            this.btnSubMenu3.Tag = "RequiredOrderList";
            this.btnSubMenu3.Text = "빠른발주";
            this.btnSubMenu3.Click += new System.EventHandler(this.SubMenu_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(883, 12);
            this.btnExcelExport.Size = new System.Drawing.Size(108, 36);
            this.btnExcelExport.Text = "발주서 Excel로 미리 출력해보기";
            //this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // pnlLocalNavigationBar
            // 
            this.pnlLocalNavigationBar.Size = new System.Drawing.Size(1067, 61);
            // 
            // pnlContent
            // 
            this.pnlContent.Size = new System.Drawing.Size(1067, 495);
            // 
            // btnCloses
            // 
            this.btnCloses.Location = new System.Drawing.Point(997, 12);
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.Controls.Add(this.grbOrderProductList);
            this.pnlOrder.Controls.Add(this.dtpRequiredDate);
            this.pnlOrder.Controls.Add(this.labelRequiredDate);
            this.pnlOrder.Controls.Add(this.cboCOM);
            this.pnlOrder.Controls.Add(this.labelcboCOM);
            this.pnlOrder.Location = new System.Drawing.Point(3, 3);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(533, 439);
            this.pnlOrder.TabIndex = 24;
            // 
            // grbOrderProductList
            // 
            this.grbOrderProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOrderProductList.Controls.Add(this.txtMTMinOrder);
            this.grbOrderProductList.Controls.Add(this.dgvCart);
            this.grbOrderProductList.Controls.Add(this.btnCartDel);
            this.grbOrderProductList.Controls.Add(this.btnCartAdd);
            this.grbOrderProductList.Controls.Add(this.txtMTPrice);
            this.grbOrderProductList.Controls.Add(this.nuOrderQty);
            this.grbOrderProductList.Controls.Add(this.labelOrderQty);
            this.grbOrderProductList.Controls.Add(this.txtMTUnit);
            this.grbOrderProductList.Controls.Add(this.cboComMtr);
            this.grbOrderProductList.Controls.Add(this.labelComMtr);
            this.grbOrderProductList.Location = new System.Drawing.Point(3, 97);
            this.grbOrderProductList.Name = "grbOrderProductList";
            this.grbOrderProductList.Size = new System.Drawing.Size(527, 339);
            this.grbOrderProductList.TabIndex = 28;
            this.grbOrderProductList.TabStop = false;
            this.grbOrderProductList.Text = "발주 물품";
            // 
            // txtMTMinOrder
            // 
            this.txtMTMinOrder.Location = new System.Drawing.Point(234, 32);
            this.txtMTMinOrder.Name = "txtMTMinOrder";
            this.txtMTMinOrder.ReadOnly = true;
            this.txtMTMinOrder.Size = new System.Drawing.Size(66, 21);
            this.txtMTMinOrder.TabIndex = 40;
            this.txtMTMinOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvCart
            // 
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(7, 93);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowTemplate.Height = 23;
            this.dgvCart.Size = new System.Drawing.Size(514, 240);
            this.dgvCart.TabIndex = 39;
            // 
            // btnCartDel
            // 
            this.btnCartDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCartDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartDel.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCartDel.Location = new System.Drawing.Point(484, 64);
            this.btnCartDel.Name = "btnCartDel";
            this.btnCartDel.Size = new System.Drawing.Size(30, 25);
            this.btnCartDel.TabIndex = 38;
            this.btnCartDel.Text = "-";
            this.btnCartDel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCartDel.UseVisualStyleBackColor = true;
            this.btnCartDel.Click += new System.EventHandler(this.btnCartDel_Click);
            // 
            // btnCartAdd
            // 
            this.btnCartAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCartAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartAdd.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCartAdd.Location = new System.Drawing.Point(448, 64);
            this.btnCartAdd.Name = "btnCartAdd";
            this.btnCartAdd.Size = new System.Drawing.Size(30, 25);
            this.btnCartAdd.TabIndex = 35;
            this.btnCartAdd.Text = "+";
            this.btnCartAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCartAdd.UseVisualStyleBackColor = true;
            this.btnCartAdd.Click += new System.EventHandler(this.btnCartAdd_Click);
            // 
            // txtMTPrice
            // 
            this.txtMTPrice.Enabled = false;
            this.txtMTPrice.Location = new System.Drawing.Point(134, 66);
            this.txtMTPrice.Name = "txtMTPrice";
            this.txtMTPrice.ReadOnly = true;
            this.txtMTPrice.Size = new System.Drawing.Size(129, 21);
            this.txtMTPrice.TabIndex = 34;
            // 
            // nuOrderQty
            // 
            this.nuOrderQty.Location = new System.Drawing.Point(54, 66);
            this.nuOrderQty.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nuOrderQty.Name = "nuOrderQty";
            this.nuOrderQty.Size = new System.Drawing.Size(74, 21);
            this.nuOrderQty.TabIndex = 33;
            this.nuOrderQty.ThousandsSeparator = true;
            this.nuOrderQty.Leave += new System.EventHandler(this.nuOrderQty_Leave);
            // 
            // labelOrderQty
            // 
            this.labelOrderQty.AutoSize = true;
            this.labelOrderQty.Location = new System.Drawing.Point(15, 69);
            this.labelOrderQty.Name = "labelOrderQty";
            this.labelOrderQty.Size = new System.Drawing.Size(29, 12);
            this.labelOrderQty.TabIndex = 32;
            this.labelOrderQty.Text = "수량";
            // 
            // txtMTUnit
            // 
            this.txtMTUnit.Location = new System.Drawing.Point(303, 32);
            this.txtMTUnit.Name = "txtMTUnit";
            this.txtMTUnit.ReadOnly = true;
            this.txtMTUnit.Size = new System.Drawing.Size(58, 21);
            this.txtMTUnit.TabIndex = 31;
            // 
            // cboComMtr
            // 
            this.cboComMtr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComMtr.FormattingEnabled = true;
            this.cboComMtr.Location = new System.Drawing.Point(54, 32);
            this.cboComMtr.Name = "cboComMtr";
            this.cboComMtr.Size = new System.Drawing.Size(170, 20);
            this.cboComMtr.TabIndex = 30;
            this.cboComMtr.SelectedIndexChanged += new System.EventHandler(this.cboComMtr_SelectedIndexChanged);
            // 
            // labelComMtr
            // 
            this.labelComMtr.AutoSize = true;
            this.labelComMtr.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelComMtr.Location = new System.Drawing.Point(15, 35);
            this.labelComMtr.Name = "labelComMtr";
            this.labelComMtr.Size = new System.Drawing.Size(29, 12);
            this.labelComMtr.TabIndex = 29;
            this.labelComMtr.Text = "물품";
            // 
            // dtpRequiredDate
            // 
            this.dtpRequiredDate.Location = new System.Drawing.Point(165, 43);
            this.dtpRequiredDate.Name = "dtpRequiredDate";
            this.dtpRequiredDate.Size = new System.Drawing.Size(170, 21);
            this.dtpRequiredDate.TabIndex = 26;
            // 
            // labelRequiredDate
            // 
            this.labelRequiredDate.AutoSize = true;
            this.labelRequiredDate.Location = new System.Drawing.Point(87, 48);
            this.labelRequiredDate.Name = "labelRequiredDate";
            this.labelRequiredDate.Size = new System.Drawing.Size(69, 12);
            this.labelRequiredDate.TabIndex = 27;
            this.labelRequiredDate.Text = "납기 요청일";
            // 
            // cboCOM
            // 
            this.cboCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOM.FormattingEnabled = true;
            this.cboCOM.Location = new System.Drawing.Point(165, 12);
            this.cboCOM.Name = "cboCOM";
            this.cboCOM.Size = new System.Drawing.Size(170, 20);
            this.cboCOM.TabIndex = 25;
            this.cboCOM.SelectedIndexChanged += new System.EventHandler(this.cboCOM_SelectedIndexChanged);
            // 
            // labelcboCOM
            // 
            this.labelcboCOM.AutoSize = true;
            this.labelcboCOM.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelcboCOM.Location = new System.Drawing.Point(115, 15);
            this.labelcboCOM.Name = "labelcboCOM";
            this.labelcboCOM.Size = new System.Drawing.Size(41, 12);
            this.labelcboCOM.TabIndex = 23;
            this.labelcboCOM.Text = "거래처";
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Location = new System.Drawing.Point(446, 445);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(87, 26);
            this.btnInsert.TabIndex = 19;
            this.btnInsert.Text = "발주하기";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // grbCompanyList
            // 
            this.grbCompanyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCompanyList.Controls.Add(this.dgvCompanyList);
            this.grbCompanyList.Location = new System.Drawing.Point(3, 55);
            this.grbCompanyList.Name = "grbCompanyList";
            this.grbCompanyList.Size = new System.Drawing.Size(490, 193);
            this.grbCompanyList.TabIndex = 21;
            this.grbCompanyList.TabStop = false;
            this.grbCompanyList.Text = "거래처 목록";
            // 
            // dgvCompanyList
            // 
            this.dgvCompanyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompanyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanyList.Location = new System.Drawing.Point(3, 17);
            this.dgvCompanyList.Name = "dgvCompanyList";
            this.dgvCompanyList.RowTemplate.Height = 23;
            this.dgvCompanyList.Size = new System.Drawing.Size(484, 173);
            this.dgvCompanyList.TabIndex = 0;
            this.dgvCompanyList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyList_CellDoubleClick);
            // 
            // btnSelect
            // 
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Location = new System.Drawing.Point(297, 17);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(73, 23);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "조회하기";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cboMT
            // 
            this.cboMT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMT.FormattingEnabled = true;
            this.cboMT.Location = new System.Drawing.Point(120, 18);
            this.cboMT.Name = "cboMT";
            this.cboMT.Size = new System.Drawing.Size(171, 20);
            this.cboMT.TabIndex = 13;
            // 
            // labelcboMT
            // 
            this.labelcboMT.AutoSize = true;
            this.labelcboMT.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelcboMT.Location = new System.Drawing.Point(85, 21);
            this.labelcboMT.Name = "labelcboMT";
            this.labelcboMT.Size = new System.Drawing.Size(29, 12);
            this.labelcboMT.TabIndex = 12;
            this.labelcboMT.Text = "물품";
            // 
            // grbOrderCalc
            // 
            this.grbOrderCalc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOrderCalc.Controls.Add(this.lblMTQty);
            this.grbOrderCalc.Controls.Add(this.lblWon2);
            this.grbOrderCalc.Controls.Add(this.lblEA);
            this.grbOrderCalc.Controls.Add(this.lblWon);
            this.grbOrderCalc.Controls.Add(this.lblTotalPrice);
            this.grbOrderCalc.Controls.Add(this.labelTotalPrice);
            this.grbOrderCalc.Controls.Add(this.lblOrderQty);
            this.grbOrderCalc.Controls.Add(this.labelOrderQtyCalc);
            this.grbOrderCalc.Controls.Add(this.lblMTUnit);
            this.grbOrderCalc.Controls.Add(this.nuQty);
            this.grbOrderCalc.Controls.Add(this.labelnuQty);
            this.grbOrderCalc.Controls.Add(this.lblMTPrice);
            this.grbOrderCalc.Controls.Add(this.labelComMTRUnitPrice);
            this.grbOrderCalc.Controls.Add(this.lblCOM);
            this.grbOrderCalc.Controls.Add(this.labelCOM);
            this.grbOrderCalc.Controls.Add(this.lblComMTRUnit);
            this.grbOrderCalc.Controls.Add(this.lblMTMinOrder);
            this.grbOrderCalc.Controls.Add(this.lblMT);
            this.grbOrderCalc.Controls.Add(this.labelMT);
            this.grbOrderCalc.Controls.Add(this.labelMTMinOrder);
            this.grbOrderCalc.Controls.Add(this.lblComMTRUnitPrice);
            this.grbOrderCalc.Location = new System.Drawing.Point(3, 254);
            this.grbOrderCalc.Name = "grbOrderCalc";
            this.grbOrderCalc.Size = new System.Drawing.Size(487, 220);
            this.grbOrderCalc.TabIndex = 22;
            this.grbOrderCalc.TabStop = false;
            this.grbOrderCalc.Text = "발주 수량 계산";
            // 
            // lblMTQty
            // 
            this.lblMTQty.AutoSize = true;
            this.lblMTQty.Location = new System.Drawing.Point(373, 98);
            this.lblMTQty.Name = "lblMTQty";
            this.lblMTQty.Size = new System.Drawing.Size(29, 12);
            this.lblMTQty.TabIndex = 20;
            this.lblMTQty.Text = "단위";
            // 
            // lblWon2
            // 
            this.lblWon2.AutoSize = true;
            this.lblWon2.Location = new System.Drawing.Point(348, 61);
            this.lblWon2.Name = "lblWon2";
            this.lblWon2.Size = new System.Drawing.Size(17, 12);
            this.lblWon2.TabIndex = 19;
            this.lblWon2.Text = "원";
            // 
            // lblEA
            // 
            this.lblEA.AutoSize = true;
            this.lblEA.Location = new System.Drawing.Point(182, 173);
            this.lblEA.Name = "lblEA";
            this.lblEA.Size = new System.Drawing.Size(17, 12);
            this.lblEA.TabIndex = 18;
            this.lblEA.Text = "개";
            // 
            // lblWon
            // 
            this.lblWon.AutoSize = true;
            this.lblWon.Location = new System.Drawing.Point(439, 173);
            this.lblWon.Name = "lblWon";
            this.lblWon.Size = new System.Drawing.Size(17, 12);
            this.lblWon.TabIndex = 17;
            this.lblWon.Text = "원";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalPrice.Location = new System.Drawing.Point(292, 166);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(141, 25);
            this.lblTotalPrice.TabIndex = 16;
            this.lblTotalPrice.Text = "1,000,000";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Location = new System.Drawing.Point(231, 173);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(57, 12);
            this.labelTotalPrice.TabIndex = 15;
            this.labelTotalPrice.Text = "발주 금액";
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderQty.Location = new System.Drawing.Point(92, 166);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(78, 19);
            this.lblOrderQty.TabIndex = 14;
            this.lblOrderQty.Text = "수량";
            this.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelOrderQtyCalc
            // 
            this.labelOrderQtyCalc.AutoSize = true;
            this.labelOrderQtyCalc.Location = new System.Drawing.Point(24, 173);
            this.labelOrderQtyCalc.Name = "labelOrderQtyCalc";
            this.labelOrderQtyCalc.Size = new System.Drawing.Size(57, 12);
            this.labelOrderQtyCalc.TabIndex = 13;
            this.labelOrderQtyCalc.Text = "발주 수량";
            // 
            // lblMTUnit
            // 
            this.lblMTUnit.AutoSize = true;
            this.lblMTUnit.Location = new System.Drawing.Point(271, 98);
            this.lblMTUnit.Name = "lblMTUnit";
            this.lblMTUnit.Size = new System.Drawing.Size(29, 12);
            this.lblMTUnit.TabIndex = 12;
            this.lblMTUnit.Text = "단위";
            // 
            // nuQty
            // 
            this.nuQty.DecimalPlaces = 3;
            this.nuQty.Location = new System.Drawing.Point(134, 93);
            this.nuQty.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nuQty.Name = "nuQty";
            this.nuQty.Size = new System.Drawing.Size(120, 21);
            this.nuQty.TabIndex = 11;
            this.nuQty.ThousandsSeparator = true;
            this.nuQty.ValueChanged += new System.EventHandler(this.nuQty_ValueChanged);
            // 
            // labelnuQty
            // 
            this.labelnuQty.AutoSize = true;
            this.labelnuQty.Location = new System.Drawing.Point(16, 95);
            this.labelnuQty.Name = "labelnuQty";
            this.labelnuQty.Size = new System.Drawing.Size(85, 12);
            this.labelnuQty.TabIndex = 10;
            this.labelnuQty.Text = "필요 항목 수량";
            // 
            // lblMTPrice
            // 
            this.lblMTPrice.AutoSize = true;
            this.lblMTPrice.Location = new System.Drawing.Point(292, 61);
            this.lblMTPrice.Name = "lblMTPrice";
            this.lblMTPrice.Size = new System.Drawing.Size(45, 12);
            this.lblMTPrice.TabIndex = 9;
            this.lblMTPrice.Text = "100,000";
            // 
            // labelComMTRUnitPrice
            // 
            this.labelComMTRUnitPrice.AutoSize = true;
            this.labelComMTRUnitPrice.Location = new System.Drawing.Point(200, 61);
            this.labelComMTRUnitPrice.Name = "labelComMTRUnitPrice";
            this.labelComMTRUnitPrice.Size = new System.Drawing.Size(57, 12);
            this.labelComMTRUnitPrice.TabIndex = 8;
            this.labelComMTRUnitPrice.Text = "재료 단가";
            // 
            // lblCOM
            // 
            this.lblCOM.AutoSize = true;
            this.lblCOM.Location = new System.Drawing.Point(70, 61);
            this.lblCOM.Name = "lblCOM";
            this.lblCOM.Size = new System.Drawing.Size(53, 12);
            this.lblCOM.TabIndex = 7;
            this.lblCOM.Text = "거래처명";
            // 
            // labelCOM
            // 
            this.labelCOM.AutoSize = true;
            this.labelCOM.Location = new System.Drawing.Point(16, 61);
            this.labelCOM.Name = "labelCOM";
            this.labelCOM.Size = new System.Drawing.Size(41, 12);
            this.labelCOM.TabIndex = 6;
            this.labelCOM.Text = "거래처";
            // 
            // lblComMTRUnit
            // 
            this.lblComMTRUnit.AutoSize = true;
            this.lblComMTRUnit.Location = new System.Drawing.Point(427, 29);
            this.lblComMTRUnit.Name = "lblComMTRUnit";
            this.lblComMTRUnit.Size = new System.Drawing.Size(29, 12);
            this.lblComMTRUnit.TabIndex = 5;
            this.lblComMTRUnit.Text = "단위";
            // 
            // lblMTMinOrder
            // 
            this.lblMTMinOrder.Location = new System.Drawing.Point(331, 29);
            this.lblMTMinOrder.Name = "lblMTMinOrder";
            this.lblMTMinOrder.Size = new System.Drawing.Size(85, 12);
            this.lblMTMinOrder.TabIndex = 4;
            this.lblMTMinOrder.Text = "수량";
            this.lblMTMinOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMT
            // 
            this.lblMT.AutoSize = true;
            this.lblMT.Location = new System.Drawing.Point(51, 29);
            this.lblMT.Name = "lblMT";
            this.lblMT.Size = new System.Drawing.Size(41, 12);
            this.lblMT.TabIndex = 3;
            this.lblMT.Text = "항목명";
            // 
            // labelMT
            // 
            this.labelMT.AutoSize = true;
            this.labelMT.Location = new System.Drawing.Point(16, 29);
            this.labelMT.Name = "labelMT";
            this.labelMT.Size = new System.Drawing.Size(29, 12);
            this.labelMT.TabIndex = 2;
            this.labelMT.Text = "항목";
            // 
            // labelMTMinOrder
            // 
            this.labelMTMinOrder.AutoSize = true;
            this.labelMTMinOrder.Location = new System.Drawing.Point(200, 29);
            this.labelMTMinOrder.Name = "labelMTMinOrder";
            this.labelMTMinOrder.Size = new System.Drawing.Size(85, 12);
            this.labelMTMinOrder.TabIndex = 1;
            this.labelMTMinOrder.Text = "발주 최소 수량";
            // 
            // lblComMTRUnitPrice
            // 
            this.lblComMTRUnitPrice.AutoSize = true;
            this.lblComMTRUnitPrice.Location = new System.Drawing.Point(371, 61);
            this.lblComMTRUnitPrice.Name = "lblComMTRUnitPrice";
            this.lblComMTRUnitPrice.Size = new System.Drawing.Size(85, 12);
            this.lblComMTRUnitPrice.TabIndex = 0;
            this.lblComMTRUnitPrice.Text = "물품 거래 단위";
            // 
            // lblSum
            // 
            this.lblSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(11, 452);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(45, 12);
            this.lblSum.TabIndex = 25;
            this.lblSum.Text = "금액 합";
            // 
            // InsertOrderToVender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1067, 556);
            this.Name = "InsertOrderToVender";
            this.Tag = "";
            this.Text = "발주등록";
            this.Load += new System.EventHandler(this.InsertOrderToVender_Load);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.dgvList.ResumeLayout(false);
            this.dgvList.PerformLayout();
            this.pnlLocalNavigationBar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.grbOrderProductList.ResumeLayout(false);
            this.grbOrderProductList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuOrderQty)).EndInit();
            this.grbCompanyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyList)).EndInit();
            this.grbOrderCalc.ResumeLayout(false);
            this.grbOrderCalc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlOrder;
        protected System.Windows.Forms.Label labelcboCOM;
        protected System.Windows.Forms.Button btnInsert;
        //protected System.Windows.Forms.Panel dgvList;
        private System.Windows.Forms.ComboBox cboCOM;
        private System.Windows.Forms.GroupBox grbOrderProductList;
        protected System.Windows.Forms.Button btnCartDel;
        protected System.Windows.Forms.Button btnCartAdd;
        private System.Windows.Forms.TextBox txtMTPrice;
        private System.Windows.Forms.NumericUpDown nuOrderQty;
        private System.Windows.Forms.Label labelOrderQty;
        private System.Windows.Forms.TextBox txtMTUnit;
        private System.Windows.Forms.ComboBox cboComMtr;
        protected System.Windows.Forms.Label labelComMtr;
        private System.Windows.Forms.DateTimePicker dtpRequiredDate;
        private System.Windows.Forms.Label labelRequiredDate;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.GroupBox grbCompanyList;
        private System.Windows.Forms.DataGridView dgvCompanyList;
        protected System.Windows.Forms.Button btnSelect;
        protected System.Windows.Forms.ComboBox cboMT;
        protected System.Windows.Forms.Label labelcboMT;
        private System.Windows.Forms.GroupBox grbOrderCalc;
        private System.Windows.Forms.Label lblEA;
        private System.Windows.Forms.Label lblWon;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.Label lblOrderQty;
        private System.Windows.Forms.Label labelOrderQtyCalc;
        private System.Windows.Forms.Label lblMTUnit;
        private System.Windows.Forms.NumericUpDown nuQty;
        private System.Windows.Forms.Label labelnuQty;
        private System.Windows.Forms.Label lblMTPrice;
        private System.Windows.Forms.Label labelComMTRUnitPrice;
        private System.Windows.Forms.Label lblCOM;
        private System.Windows.Forms.Label labelCOM;
        private System.Windows.Forms.Label lblComMTRUnit;
        private System.Windows.Forms.Label lblMTMinOrder;
        private System.Windows.Forms.Label lblMT;
        private System.Windows.Forms.Label labelMT;
        private System.Windows.Forms.Label labelMTMinOrder;
        private System.Windows.Forms.Label lblComMTRUnitPrice;
        private System.Windows.Forms.Label lblWon2;
        private System.Windows.Forms.Label lblMTQty;
        private System.Windows.Forms.TextBox txtMTMinOrder;
        private System.Windows.Forms.Label lblSum;
    }
}
