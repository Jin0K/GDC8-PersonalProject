using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalProject
{
    public enum OpenMode { Insert, Update }
<<<<<<< HEAD
    public enum DivTable { Customer, Brand }
=======
>>>>>>> a1f384a (COMMIT 1)
    public partial class frmMain : Form
    {
        public Customer CurrentCustomer { get; set; }
        public Brand CurrentBrand { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                LoginMenu.Enabled = false;
                LogOutMenu.Enabled = true;
                JoinMenu.Enabled = false;
                FindMenu.Enabled = false;

                this.CurrentCustomer = login.CurrentCostumer;
                this.CurrentBrand = login.CurrentBrand;
<<<<<<< HEAD
                if (CurrentCustomer != null)
                {
                    CustomerMenu.Visible = true;
=======

                if (CurrentCustomer != null)
                {
                    CustomerMenu.Visible = true;
                    this.Tag = this.CurrentCustomer.ID;

>>>>>>> a1f384a (COMMIT 1)
                }
                else if (CurrentBrand != null)
                {
                    BrandMenu.Visible = true;
<<<<<<< HEAD
=======
                    this.Tag = this.CurrentBrand.ID;

>>>>>>> a1f384a (COMMIT 1)
                }

            }
        }


<<<<<<< HEAD
        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                LoginMenu.Enabled = false;
                LogOutMenu.Enabled = true;
                JoinMenu.Enabled = false;
                FindMenu.Enabled = false;

                this.CurrentCustomer = login.CurrentCostumer;
                this.CurrentBrand = login.CurrentBrand;
                if (CurrentCustomer != null)
                {
                    CustomerMenu.Visible = true;
                }
                else if (CurrentBrand != null)
                {
                    BrandMenu.Visible = true;
                }

            }
        }

=======
>>>>>>> a1f384a (COMMIT 1)
        private void 개인회원가입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer joinC = new frmCustomer(OpenMode.Insert);
            joinC.ShowDialog(this);
        }

        private void 브랜드등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrand joinB = new frmBrand(OpenMode.Insert);
            joinB.Show();
        }

        private void 아이디찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindID findID = new frmFindID();
            findID.Show();
        }

        private void 비밀번호찾기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindPassword findPwd = new frmFindPassword();
            findPwd.Show();
        }

        private void 전체상품조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct prod = new frmProduct();
            prod.MdiParent = this;
            prod.Show();
            prod.Dock = DockStyle.Fill;
        }

        private void 주문내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrder ord = new frmOrder();
            ord.MdiParent = this;
            ord.Show();
        }

        private void 장바구니ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCart cart = new frmCart(CurrentCustomer.ID);
            cart.MdiParent = this;
            cart.Show();
        }

        private void 문의ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQandA qa = new frmQandA();
            qa.MdiParent = this;
            qa.Show();
        }

        private void 후기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReview rv = new frmReview();
            rv.MdiParent = this;
            rv.Show();
        }

        private void 회원정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer(OpenMode.Update);
            customer.CustomerInfo = CurrentCustomer;
            customer.ShowDialog(this);
            //customer.Show();
        }

        private void 입출고내역ToolStripMenuItem_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            frmProductHistory history = new frmProductHistory();
            history.MdiParent = this;
            history.Show();
            history.Dock = DockStyle.Fill;
=======
            //frmProductHistory history = new frmProductHistory();
            //history.MdiParent = this;
            //history.Show();
            //history.Dock = DockStyle.Fill;

            ListStore store = new ListStore();
            store.MdiParent = this;
            store.Show();
            store.Dock = DockStyle.Fill;
>>>>>>> a1f384a (COMMIT 1)
        }

        private void 문의ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmQandA qa = new frmQandA();
            qa.MdiParent = this;
            qa.Show();
        }

        private void 브랜드정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrand brand = new frmBrand(OpenMode.Update);
            brand.BrandInfo = CurrentBrand;
            brand.ShowDialog(this); ;
        }

        private void 상품등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductRegist pr = new frmProductRegist();
            pr.MdiParent = this;
            //pr.BrandInfo = CurrentBrand;
            pr.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void LogOutMenu_Click(object sender, EventArgs e)
        {
            CurrentBrand = null; 
            CurrentCustomer = null;
            LoginMenu.Enabled = true;
            LogOutMenu.Enabled = false;
            JoinMenu.Enabled = true;
            FindMenu.Enabled = true;
            CustomerMenu.Visible = false;
            BrandMenu.Visible = false;

            foreach (System.Windows.Forms.Form TheForm in this.MdiChildren)
            {
                TheForm.Dispose();
            }
        }
<<<<<<< HEAD
=======

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
>>>>>>> a1f384a (COMMIT 1)
    }
}
