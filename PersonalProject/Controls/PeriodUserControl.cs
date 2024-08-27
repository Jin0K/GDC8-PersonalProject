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
    public partial class PeriodUserControl : UserControl
    {
        public DateTime From 
        {
            get { return dtpFrom.Value; }
            set { dtpFrom.Value = value; } 
        }
        public DateTime To
        {
            get { return dtpTo.Value; }
            set { dtpTo.Value = value; }
        }
        public PeriodUserControl()
        {
            InitializeComponent();
        }

        private void btn1Day_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = dtpTo.Value = DateTime.Now;
        }

        private void btn1Week_Click(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now.AddDays(-7);
        }

        private void btn1Month_Click(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
        }

        private void btn3Month_Click(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now.AddMonths(-3);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = dtpFrom.Value.AddMonths(1).AddDays(-1);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(1900, 1, 1);
            dtpTo.Value = DateTime.Now;
        }
    }
}
