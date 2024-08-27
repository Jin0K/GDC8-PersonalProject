using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalProject.UserControls
{
    public enum PriodType { OneDay, ThreeDay, OneWeek, OneMonth, ThreeMonth, SixMonth }

    public partial class PeriodUserControl : UserControl
    {
        public PriodType Period
        {
            set
            {
                cboPeriod.SelectedIndex = (int)value;
            }
        }

        public string From
        {
            get { return dtpFrom.Value.ToShortDateString(); }
        }

        public string To
        {
            get { return dtpTo.Value.AddDays(1).ToShortDateString(); }
        }

        public PeriodUserControl()
        {
            InitializeComponent();
        }

        private void PeriodUserControl_Load(object sender, EventArgs e)
        {
            dtpTo.Value = DateTime.Now;
        }

   

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboPeriod.Text)
            {
                case "1일":
                    dtpFrom.Value = dtpTo.Value.AddDays(-1); break;
                case "3일":
                    dtpFrom.Value = dtpTo.Value.AddDays(-3); break;
                case "1주일":
                    dtpFrom.Value = dtpTo.Value.AddDays(-7); break;
                case "1개월":
                    dtpFrom.Value = dtpTo.Value.AddMonths(-1); break;
                case "3개월":
                    dtpFrom.Value = dtpTo.Value.AddMonths(-3); break;
                case "6개월":
                    dtpFrom.Value = dtpTo.Value.AddMonths(-6); break;
            }
        }
    }
}
