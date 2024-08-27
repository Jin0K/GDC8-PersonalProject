using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalProject
{
    public partial class EmailUserControl : UserControl
    {
        public string Email1 
        {
            get { return txtEmail1.Text; }
            set { txtEmail1.Text = value; }
        }

        //public string Email2
        //{
        //    get { return txtEmail2.Text; }
        //    set { txtEmail2.Text = value; }
        //}
        public string Email2
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(txtEmail2.Text))
                    return txtEmail2.Text;
                else if (!string.IsNullOrWhiteSpace(cboEmail.SelectedValue as string))
                    return cboEmail.SelectedValue.ToString();
                else
                    return null;

            }
            set
            {
                if (value == null) return;

                if (value.Contains("."))
                    txtEmail2.Text = value;
                else
                    cboEmail.SelectedValue = value as object;
            }
        }
        public TextBox TxtEmail1
        {
            get { return txtEmail1; }
            set { txtEmail1 = value; }
        }
        public TextBox TxtEmail2
        {
            get { return txtEmail2; }
            set { txtEmail2 = value; }
        }
        public ComboBox CboEmail
        {
            get { return cboEmail; }
            set { cboEmail = value; }
        }

        public EmailUserControl()
        {
            InitializeComponent();
        }

        //public string GetEmail2()
        //{
        //    if (!string.IsNullOrWhiteSpace(txtEmail2.Text))
        //        return txtEmail2.Text;
        //    else if (!string.IsNullOrWhiteSpace(cboEmail.SelectedValue.ToString()))
        //        return cboEmail.SelectedValue.ToString();
        //    else
        //        return "";
        //}

        private void cboEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debug.WriteLine(CboEmail.Text);
            //Debug.WriteLine(CboEmail.SelectedText);
            //Debug.WriteLine(CboEmail.SelectedValue);
            if (CboEmail.Text == "직접 입력")
            {
                TxtEmail2.Visible = true;
                CboEmail.Location = new Point(296, 0);
                TxtEmail2.Focus();
            }
            else
            {
                TxtEmail2.Visible = false;
                CboEmail.Location = TxtEmail2.Location;

            }
        }

        private void EmailUserControl_Load(object sender, EventArgs e)
        {
            //string[] category = { "이메일 주소" };

            //CommonDAC dac = new CommonDAC();
            //DataTable dt = dac.GetCommonCodes(category);

            //CommonUtil.ComboBinding(CboEmail, "이메일 주소", dt, inputItem: true);

            //email.CboEmail.SelectedIndex = 0;
            //TxtEmail2.Visible = false;
            //CboEmail.Location = TxtEmail2.Location;


        }
    }
}
