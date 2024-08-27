using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalProject
{
    public partial class frmFindPassword : Form
    {
        public frmFindPassword()
        {
            InitializeComponent();
        }

      
        private void btnFind_Click(object sender, EventArgs e)
        {
            //3개의 값을 모두 입력했는지 유효성체크
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtName.Text) || !CommonUtil.IsValidEmail(CommonUtil.CombineEmail(email)))
            {
                MessageBox.Show("아이디, 이름, 이메일을 모두 입력하세요.");
                return;
            }
            else if(!userDiv.RdoBrand.Checked && !userDiv.RdoCustomer.Checked)
            {
                Debug.WriteLine(userDiv.RdoBrand.Checked);

                Debug.WriteLine(userDiv.RdoCustomer.Checked);
                Debug.WriteLine(userDiv.CheckedValue());
                MessageBox.Show("구분(고객/브랜드)을 선택해주세요.");
                return;
            }
            
            //frmChangePassword changePwd = new frmChangePassword();
            //changePwd.Show();

            //입력한 값으로 회원여부를 확인
            
            CommonDAC dac = new CommonDAC();
            bool bFlag = dac.ConfirmUser(userDiv.CheckedValue(), txtID.Text, txtName.Text, email.TxtEmail1.Text, email.Email2);
            //if(userDiv.CheckedValue() == DivTable.Brand)
            //{
            //    BrandDAC dac = new BrandDAC();
            //    bFlag = dac.ConfirmUser(txtID.Text, txtName.Text, email.TxtEmail1.Text, email.TxtEmail2.Text);

            //}
            //else if (userDiv.CheckedValue() == DivTable.Customer)
            //{
            //    CustomerDAC dac = new CustomerDAC();
            //    bFlag = dac.ConfirmUser(txtID.Text, txtName.Text, email.TxtEmail1.Text, email.TxtEmail2.Text);

            //}

            if (!bFlag)
            {
                MessageBox.Show("회원정보가 없습니다. 다시 확인하여 주십시오.");
                return;
            }

            //회원인 경우 비밀번호를 재생성
            string newPwd = CreatePassword();

            //재생성된 비밀번호를 DB에 update
            bool bResult = dac.UpdatePWD(userDiv.CheckedValue(), txtID.Text, newPwd);
            dac.Dispose();
            if (bResult)
            {
                //재생성된 비밀번호를 메일로 발송
                string subject = $"{txtName.Text}님의 비밀번호 초기화 안내 메일입니다.";
                string body = $"{txtName.Text}님의 비밀번호는 {newPwd}으로 초기화 되었습니다. 로그인해주십시오.";
                string to = CommonUtil.CombineEmail(email);

                CommonUtil.SendMail(subject, body, to);
                MessageBox.Show("비밀번호를 재생성해서 메일로 발송하였습니다. 확인하여 주십시오.");
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호 찾기 중 오류가 발생했습니다. 다시 시도하여 주십시오..");
            }
        }

        //대문자와 숫자의 조합으로 6글자
        private string CreatePassword()
        {
            StringBuilder sb = new StringBuilder();

            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int temp = rnd.Next(0, 36);  //0 ~35 숫자(0~9) 영어 대문자(10~35) A:65, 영어 소문자(36~61) a:97,
                if (temp < 10)
                    sb.Append(temp);
                else //if(temp < 36)
                    sb.Append((char)(temp + 55));
                //else if (temp < 36)
                //    sb.Append((char)(temp + 61));
            }
            return sb.ToString();
        }

        private void frmFindPassword_Load(object sender, EventArgs e)
        {

            string[] category = { "이메일 주소" };

            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCodes(category);

            CommonUtil.ComboBinding(email.CboEmail, dt, "이메일 주소", inputItem: true);

        }
    }
}
