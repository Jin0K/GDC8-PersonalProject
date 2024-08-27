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
    public partial class WaitAsyncForm : Form
    {
        public Action Worker { get; set; }

        public WaitAsyncForm(Action worker)
        {
            InitializeComponent();

            this.Worker = worker;
        }

        private void WaitAsyncForm_Load(object sender, EventArgs e)
        {
            var task1 = Task.Factory.StartNew(Worker); 
            task1.ContinueWith((t) => this.Close(), TaskScheduler.FromCurrentSynchronizationContext()); 
        }
    }
}
