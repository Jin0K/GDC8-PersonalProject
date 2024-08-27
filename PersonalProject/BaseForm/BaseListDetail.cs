using PersonalProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


    public partial class BaseListDetail : BaseForm
    {
        public BaseListDetail()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FormUtil.CloseForm(this);
        }
    }

