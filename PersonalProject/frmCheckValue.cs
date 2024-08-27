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
    public partial class frmCheckValue : Form
    {
<<<<<<< HEAD
        DivTable div;
=======
        CommonVO.DivTable div;
>>>>>>> a1f384a (COMMIT 1)
        string column;
        string infoMessage;
        bool bCheck;
        public string CheckValue
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }

        //public frmIDCheck()
        //{
        //       InitializeComponent();
        //}
        
<<<<<<< HEAD
        public frmCheckValue(DivTable div, Button btn)
=======
        public frmCheckValue(CommonVO.DivTable div, Button btn)
>>>>>>> a1f384a (COMMIT 1)
        {
            InitializeComponent();
            this.div = div;
            this.column = btn.Tag.ToString();
            if(column.Contains("ID"))
            {
                infoMessage = "아이디";
            }
            else if(column.Contains("NAME"))
            {
                infoMessage = "이름";
            }else if(column.Contains("NUMBER"))
            {
                infoMessage = "번호";
            }
            this.Text = $"{infoMessage} 중복 체크";
        }

        private void btnIDCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CheckValue))
            {
                MessageBox.Show($"사용하실 {infoMessage}를 입력하세요.");
                return;
            }

            CommonDAC dac = new CommonDAC();

            if (dac.IsVaildValue(div, column, CheckValue))
            {
                label1.Text = $"이미 사용중인 {infoMessage}입니다.";
                bCheck = false;
            }
            else
            {
                label1.Text = $"사용 가능한 {infoMessage}입니다.";
                bCheck = true; 
            }
            dac.Dispose();
        }

        private void btnIDApply_Click(object sender, EventArgs e)
        {
            if (bCheck)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"사용자 {infoMessage} 중복체크를 다시 하시기 바랍니다.");
            }
        }

        private void frmIDCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
