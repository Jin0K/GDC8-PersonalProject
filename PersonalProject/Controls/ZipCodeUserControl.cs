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
    public partial class ZipCodeUserControl : UserControl
    {
        public string ZipCode
        {
            get { return txtZipCode.Text; }
            set { txtZipCode.Text = value; }
        }
        public string Address1
        {
            get { return txtAddress1.Text; }
            set { txtAddress1.Text = value; }
        }
        public string Address2
        {
            get { return txtAddress2.Text; }
            set { txtAddress2.Text = value; }
        }

        public string AddressName
        {
            get { return txtAddressName.Text; }
            set { txtAddressName.Text = value; }
        }

        public int AddressNumber { get; set; }

        public ZipCodeUserControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmZipSearch frm = new frmZipSearch();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtZipCode.Text = frm.Zipcode;
                txtAddress1.Text = frm.Address1;
                txtAddress2.Text = frm.Address2;
                txtAddress2.Focus();
            }
        }
    }
}
