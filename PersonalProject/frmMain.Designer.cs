
namespace PersonalProject
{
    partial class frmMain
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.JoinMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.개인회원가입ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.브랜드등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.아이디찾기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.비밀번호찾기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.전체상품조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.주문내역ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.장바구니ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.문의ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.후기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.회원정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BrandMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.상품등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.입출고내역ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.문의ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.브랜드정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
<<<<<<< HEAD
=======
            this.statusStrip1.SuspendLayout();
>>>>>>> a1f384a (COMMIT 1)
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(914, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem,
            this.전체상품조회ToolStripMenuItem,
            this.CustomerMenu,
            this.BrandMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoginMenu,
            this.LogOutMenu,
            this.toolStripSeparator3,
            this.JoinMenu,
            this.FindMenu,
            this.toolStripSeparator4,
            this.종료ToolStripMenuItem});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // LoginMenu
            // 
            this.LoginMenu.Name = "LoginMenu";
            this.LoginMenu.Size = new System.Drawing.Size(191, 22);
            this.LoginMenu.Text = "로그인";
            this.LoginMenu.Click += new System.EventHandler(this.로그인ToolStripMenuItem_Click);
            // 
            // LogOutMenu
            // 
            this.LogOutMenu.Enabled = false;
            this.LogOutMenu.Name = "LogOutMenu";
            this.LogOutMenu.Size = new System.Drawing.Size(191, 22);
            this.LogOutMenu.Text = "로그아웃";
            this.LogOutMenu.Click += new System.EventHandler(this.LogOutMenu_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // JoinMenu
            // 
            this.JoinMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.개인회원가입ToolStripMenuItem,
            this.브랜드등록ToolStripMenuItem});
            this.JoinMenu.Name = "JoinMenu";
            this.JoinMenu.Size = new System.Drawing.Size(191, 22);
            this.JoinMenu.Text = "가입/등록";
            // 
            // 개인회원가입ToolStripMenuItem
            // 
            this.개인회원가입ToolStripMenuItem.Name = "개인회원가입ToolStripMenuItem";
            this.개인회원가입ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.개인회원가입ToolStripMenuItem.Text = "개인 회원 가입";
            this.개인회원가입ToolStripMenuItem.Click += new System.EventHandler(this.개인회원가입ToolStripMenuItem_Click);
            // 
            // 브랜드등록ToolStripMenuItem
            // 
            this.브랜드등록ToolStripMenuItem.Name = "브랜드등록ToolStripMenuItem";
            this.브랜드등록ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.브랜드등록ToolStripMenuItem.Text = "브랜드 등록";
            this.브랜드등록ToolStripMenuItem.Click += new System.EventHandler(this.브랜드등록ToolStripMenuItem_Click);
            // 
            // FindMenu
            // 
            this.FindMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.아이디찾기ToolStripMenuItem,
            this.비밀번호찾기ToolStripMenuItem});
            this.FindMenu.Name = "FindMenu";
            this.FindMenu.Size = new System.Drawing.Size(191, 22);
            this.FindMenu.Text = "아이디/비밀번호 찾기";
            // 
            // 아이디찾기ToolStripMenuItem
            // 
            this.아이디찾기ToolStripMenuItem.Name = "아이디찾기ToolStripMenuItem";
            this.아이디찾기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.아이디찾기ToolStripMenuItem.Text = "아이디 찾기";
            this.아이디찾기ToolStripMenuItem.Click += new System.EventHandler(this.아이디찾기ToolStripMenuItem_Click);
            // 
            // 비밀번호찾기ToolStripMenuItem
            // 
            this.비밀번호찾기ToolStripMenuItem.Name = "비밀번호찾기ToolStripMenuItem";
            this.비밀번호찾기ToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.비밀번호찾기ToolStripMenuItem.Text = "비밀번호 찾기";
            this.비밀번호찾기ToolStripMenuItem.Click += new System.EventHandler(this.비밀번호찾기ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.종료ToolStripMenuItem.Text = "종료";
<<<<<<< HEAD
=======
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
>>>>>>> a1f384a (COMMIT 1)
            // 
            // 전체상품조회ToolStripMenuItem
            // 
            this.전체상품조회ToolStripMenuItem.Name = "전체상품조회ToolStripMenuItem";
            this.전체상품조회ToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.전체상품조회ToolStripMenuItem.Text = "상품 조회/검색";
            this.전체상품조회ToolStripMenuItem.Click += new System.EventHandler(this.전체상품조회ToolStripMenuItem_Click);
            // 
            // CustomerMenu
            // 
            this.CustomerMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.주문내역ToolStripMenuItem,
            this.장바구니ToolStripMenuItem,
            this.문의ToolStripMenuItem,
            this.후기ToolStripMenuItem,
            this.toolStripSeparator1,
            this.회원정보ToolStripMenuItem});
            this.CustomerMenu.Name = "CustomerMenu";
            this.CustomerMenu.Size = new System.Drawing.Size(43, 20);
            this.CustomerMenu.Text = "고객";
            this.CustomerMenu.Visible = false;
            // 
            // 주문내역ToolStripMenuItem
            // 
            this.주문내역ToolStripMenuItem.Name = "주문내역ToolStripMenuItem";
            this.주문내역ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.주문내역ToolStripMenuItem.Text = "주문내역";
            this.주문내역ToolStripMenuItem.Click += new System.EventHandler(this.주문내역ToolStripMenuItem_Click);
            // 
            // 장바구니ToolStripMenuItem
            // 
            this.장바구니ToolStripMenuItem.Name = "장바구니ToolStripMenuItem";
            this.장바구니ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.장바구니ToolStripMenuItem.Text = "장바구니";
            this.장바구니ToolStripMenuItem.Click += new System.EventHandler(this.장바구니ToolStripMenuItem_Click);
            // 
            // 문의ToolStripMenuItem
            // 
            this.문의ToolStripMenuItem.Name = "문의ToolStripMenuItem";
            this.문의ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.문의ToolStripMenuItem.Text = "문의";
            this.문의ToolStripMenuItem.Click += new System.EventHandler(this.문의ToolStripMenuItem_Click);
            // 
            // 후기ToolStripMenuItem
            // 
            this.후기ToolStripMenuItem.Name = "후기ToolStripMenuItem";
            this.후기ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.후기ToolStripMenuItem.Text = "후기";
            this.후기ToolStripMenuItem.Click += new System.EventHandler(this.후기ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(123, 6);
            // 
            // 회원정보ToolStripMenuItem
            // 
            this.회원정보ToolStripMenuItem.Name = "회원정보ToolStripMenuItem";
            this.회원정보ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.회원정보ToolStripMenuItem.Text = "회원 정보";
            this.회원정보ToolStripMenuItem.Click += new System.EventHandler(this.회원정보ToolStripMenuItem_Click);
            // 
            // BrandMenu
            // 
            this.BrandMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상품등록ToolStripMenuItem,
            this.입출고내역ToolStripMenuItem,
            this.문의ToolStripMenuItem1,
            this.toolStripSeparator2,
            this.브랜드정보ToolStripMenuItem});
            this.BrandMenu.Name = "BrandMenu";
            this.BrandMenu.Size = new System.Drawing.Size(55, 20);
            this.BrandMenu.Text = "브랜드";
            this.BrandMenu.Visible = false;
            // 
            // 상품등록ToolStripMenuItem
            // 
            this.상품등록ToolStripMenuItem.Name = "상품등록ToolStripMenuItem";
            this.상품등록ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.상품등록ToolStripMenuItem.Text = "상품 등록";
            this.상품등록ToolStripMenuItem.Click += new System.EventHandler(this.상품등록ToolStripMenuItem_Click);
            // 
            // 입출고내역ToolStripMenuItem
            // 
            this.입출고내역ToolStripMenuItem.Name = "입출고내역ToolStripMenuItem";
            this.입출고내역ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.입출고내역ToolStripMenuItem.Text = "입고/출고 내역";
            this.입출고내역ToolStripMenuItem.Click += new System.EventHandler(this.입출고내역ToolStripMenuItem_Click);
            // 
            // 문의ToolStripMenuItem1
            // 
            this.문의ToolStripMenuItem1.Name = "문의ToolStripMenuItem1";
            this.문의ToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.문의ToolStripMenuItem1.Text = "문의";
            this.문의ToolStripMenuItem1.Click += new System.EventHandler(this.문의ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // 브랜드정보ToolStripMenuItem
            // 
            this.브랜드정보ToolStripMenuItem.Name = "브랜드정보ToolStripMenuItem";
            this.브랜드정보ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.브랜드정보ToolStripMenuItem.Text = "브랜드 정보";
            this.브랜드정보ToolStripMenuItem.Click += new System.EventHandler(this.브랜드정보ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 562);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "무신사";
            this.Load += new System.EventHandler(this.frmMain_Load);
<<<<<<< HEAD
=======
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
>>>>>>> a1f384a (COMMIT 1)
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem LoginMenu;
        private System.Windows.Forms.ToolStripMenuItem LogOutMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem JoinMenu;
        private System.Windows.Forms.ToolStripMenuItem FindMenu;
        private System.Windows.Forms.ToolStripMenuItem 전체상품조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomerMenu;
        private System.Windows.Forms.ToolStripMenuItem 주문내역ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 장바구니ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 문의ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 후기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 회원정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BrandMenu;
        private System.Windows.Forms.ToolStripMenuItem 입출고내역ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 문의ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 브랜드정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 아이디찾기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 비밀번호찾기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 개인회원가입ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 브랜드등록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 상품등록ToolStripMenuItem;
<<<<<<< HEAD
=======


>>>>>>> a1f384a (COMMIT 1)
    }
}

