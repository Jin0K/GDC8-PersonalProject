using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PersonalProject.UserControls
{
    public partial class ucImageSelector : UserControl
    {
        public byte[] ImageByte {
            get
            {
                if (ucImage.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ucImage.Image.Save(ms, ucImage.Image.RawFormat);
                        return ms.ToArray();
                    }
                }

                return null;
            }
            set
            {
                if(value != null)
                {
                    ucLabel.Visible = false;
                    using (var ms = new MemoryStream(value))
                    {
                        ucImage.Image = Image.FromStream(ms);
                    }
                }                
            }
        }
        public string ImagePath
        { 
            get
            {
                if(ucImage.ImageLocation != null)
                {
                    using (FileStream fs = new FileStream(ucImage.ImageLocation, FileMode.Open, FileAccess.Read))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        return br.ReadBytes((int)fs.Length).ToString();
                    }
                }
                return null;
            }

            set
            {
                ucImage.ImageLocation = value;
                ucLabel.Visible = false;
            }
        }
        public ucImageSelector()
        {
            InitializeComponent();
        }

        public void Init()
        {
            ucLabel.Visible = true;
            ucImage.Image = null;
        }
    }
}
