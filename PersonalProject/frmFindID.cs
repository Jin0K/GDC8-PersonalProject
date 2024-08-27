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
    public partial class frmFindID : Form
    {
        public frmFindID()
        {
            InitializeComponent();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            //값을 모두 입력했는지 유효성체크
            if (string.IsNullOrWhiteSpace(txtName.Text) || !CommonUtil.IsValidEmail(CommonUtil.CombineEmail(email)))
            {
                MessageBox.Show("이름, 이메일을 모두 입력하세요.");
                return;
            }
            else if (!userDiv.RdoBrand.Checked && !userDiv.RdoCustomer.Checked)
            {
                MessageBox.Show("구분(고객/브랜드)을 선택해주세요.");
                return;
            }


            CommonDAC dac = new CommonDAC();
            string id = dac.ConfirmUser(userDiv.CheckedValue(), txtName.Text, email.TxtEmail1.Text, email.Email2);
            string msg;

            if (string.IsNullOrWhiteSpace(id))
                msg = "해당되는 정보의 ID를 찾을 수 없습니다.";
            else
                msg = $"해당되는 정보의 ID는 '{id}'입니다.";
            
            frmShowID showID = new frmShowID(msg);
            if(showID.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void frmFindID_Load(object sender, EventArgs e)
        {
            string[] category = { "이메일 주소" };

            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCodes(category);

            CommonUtil.ComboBinding(email.CboEmail, dt, "이메일 주소", inputItem: true);
        }
    }
}
