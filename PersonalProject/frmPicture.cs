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
    public partial class frmPicture : Form
    {
        string imgPath;
        public frmPicture(string imgPath)
        {
            InitializeComponent();
            this.imgPath = imgPath;
        }

        private void frmPicture_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = imgPath;
            this.Width = pictureBox1.Width + 10; 
            this.Height = pictureBox1.Height + 10;
            this.Padding = new System.Windows.Forms.Padding(5);
        }
    }
}
