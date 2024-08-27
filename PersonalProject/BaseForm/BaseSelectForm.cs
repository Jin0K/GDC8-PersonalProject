using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PersonalProject
{
    public partial class BaseSelectForm : BaseForm
    {
        public BaseSelectForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FormUtil.CloseForm(this);
        }


        //private void btnToday_Click(object sender, EventArgs e)
        //{
        //    dtpFrom.Value = dtpTo.Value = DateTime.Now;
        //}

        //private void btnWeek_Click(object sender, EventArgs e)
        //{
        //    dtpTo.Value = DateTime.Now;
        //    dtpFrom.Value = DateTime.Now.AddDays(-7);
        //}

        //private void btnMonth_Click(object sender, EventArgs e)
        //{
        //    dtpTo.Value = DateTime.Now;
        //    dtpFrom.Value = DateTime.Now.AddMonths(-1);
        //}

        //private void btn3Month_Click(object sender, EventArgs e)
        //{
        //    dtpTo.Value = DateTime.Now;
        //    dtpFrom.Value = DateTime.Now.AddMonths(-3);
        //}

        //private void btn6Month_Click(object sender, EventArgs e)
        //{
        //    dtpTo.Value = DateTime.Now;
        //    dtpFrom.Value = DateTime.Now.AddMonths(-6);
        //}

        //private void btnExcelExport_Click(object sender, EventArgs e)
        //{
        //    BaseExportExcel frm = new BaseExportExcel();
        //    frm.ShowDialog();
        //}
    }
}
