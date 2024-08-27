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
    public partial class GudiDataGridview : DataGridView
    {
        public GudiDataGridview()
        {
            InitializeComponent();

            this.RowHeadersWidth = 30;
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 30;

            //this.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            //this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Green;
            //this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
            //this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Yellow;

            //this.DefaultCellStyle.BackColor = Color.White;
            //this.DefaultCellStyle.ForeColor = Color.Black;
            //this.DefaultCellStyle.SelectionBackColor = Color.Violet;
            //this.DefaultCellStyle.SelectionForeColor = Color.Orange;


            //this.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Brown;
            //this.AlternatingRowsDefaultCellStyle.BackColor = Color.Lime;

            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Info;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.FromArgb(52, 52, 52);
            this.DefaultCellStyle.SelectionBackColor = Color.Gold;
            //this.DefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
            //this.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;


            this.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
