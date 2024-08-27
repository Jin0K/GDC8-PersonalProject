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
    public partial class frmShowID : Form
    {
        public frmShowID(string msg)
        {
            InitializeComponent();

            lblResult.Text = msg;
        }

        private void btnFindPassword_Click(object sender, EventArgs e)
        {
            frmFindPassword frm = new frmFindPassword();
            frm.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
