using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
=======
using static CommonVO;
>>>>>>> a1f384a (COMMIT 1)

namespace PersonalProject
{
    public partial class frmLogin : Form
    {
        Customer loginCustomer;
        Brand loginBrand;
        public Customer CurrentCostumer { get; set; }
        public Brand CurrentBrand { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void llbJoin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (UserDiv.CheckedValue() == DivTable.Customer)
            {
                frmCustomer frm = new frmCustomer(OpenMode.Insert);
                frm.ShowDialog();
            }
            else if(UserDiv.CheckedValue() == DivTable.Brand)
            {
                frmBrand frm = new frmBrand(OpenMode.Insert);
                frm.ShowDialog();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //유효성체크
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("아이디와 비밀번호를 입력하세요.");
                return;
            }
            //입력된 아이디와 비밀번호를 DB에 전달해서, 유효한 로그인인지 체크
            if (UserDiv.CheckedValue() == DivTable.Customer)
            {
                CustomerDAC dac = new CustomerDAC();
                loginCustomer = dac.Login(txtID.Text);
            }
            else if (UserDiv.CheckedValue() == DivTable.Brand)
            {
                BrandDAC dac = new BrandDAC();
                loginBrand = dac.Login(txtID.Text);
            }

            //UserDAC dac = new UserDAC();
            //User loginUser = dac.Login(textBox1.Text);
            //dac.Dispose();
            if (loginCustomer == null && loginBrand == null)
            {
                MessageBox.Show("등록된 아이디가 아닙니다. 회원가입을 해주십시오.");
            }
            else if ((loginBrand == null && loginCustomer.Password != txtPassword.Text) || (loginCustomer == null && loginBrand.Password != txtPassword.Text))
            {
                MessageBox.Show("비밀번호를 다시 입력하여 주십시오.");
            }
            else
            {
                if(loginCustomer != null)
                {
                    CurrentCostumer = loginCustomer;
                    MessageBox.Show($"{CurrentCostumer.Name}님 환영합니다.");
                }
                else if (loginBrand != null)
                {
                    CurrentBrand = loginBrand;
                    MessageBox.Show($"{CurrentBrand.Name}님 환영합니다.");
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            UserDiv.RdoCustomer.Checked = true;
            ActiveControl = txtID;
        }

        private void llbFindPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFindPassword frm = new frmFindPassword();
            frm.ShowDialog();
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPassword.Text.Length > 0 && e.KeyChar == 13)
                btnLogin.PerformClick();
        }

        private void llbFindID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFindID frm = new frmFindID();
            frm.ShowDialog();
        }
    }
}
