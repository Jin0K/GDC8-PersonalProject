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


>>>>>>> a1f384a (COMMIT 1)
namespace PersonalProject
{
    public partial class UserDivControl : UserControl
    {
        
        public RadioButton RdoCustomer
        {
            get { return rdoCustomer; }
            set { rdoCustomer = value; }
        }
        public RadioButton RdoBrand
        {
            get { return rdoBrand; }
            set { rdoBrand = value; }
        }
        public UserDivControl()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        public DivTable CheckedValue()
        {
            if (rdoBrand.Checked)
                return DivTable.Brand;
            else if (rdoCustomer.Checked)
                return DivTable.Customer;
=======
        public CommonVO.DivTable CheckedValue()
        {
            if (rdoBrand.Checked)
                return CommonVO.DivTable.Brand;
            else if (rdoCustomer.Checked)
                return CommonVO.DivTable.Customer;
>>>>>>> a1f384a (COMMIT 1)
            else
                return 0;
        }

        private void UserDivControl_Load(object sender, EventArgs e)
        {
            rdoCustomer.Checked = true;
        }
    }
}
