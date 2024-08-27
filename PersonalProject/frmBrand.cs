using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

<<<<<<< HEAD
=======

>>>>>>> a1f384a (COMMIT 1)
namespace PersonalProject
{
    public partial class frmBrand : Form
    {
        OpenMode openMode;
        //BRAND_ID, BRAND_NAME, COMPANY_REGIST_NUMBER, BRAND_PASSWORD, LOGO_IMG_PATH, BRAND_EMAIL1, BRAND_EMAIL2, BRAND_CONTACT, BRAND_ADDRESS, COUNTRY
        public Brand BrandInfo
        {
            get
            {
                Brand brand = new Brand();
                brand.ID = txtID.Text;
                brand.Name = txtName.Text;
                brand.CompanyNumber = txtCompanyNumber.Text;
                brand.Password = txtPassword.Text;
                brand.Email1 = email.TxtEmail1.Text;
                //brand.Email2 = ((frmMain)this.Owner).CurrentBrand.Email2;
                brand.Contact = txtContact.Text;
                brand.Address = txtAddress.Text;
                brand.Country = txtCountry.Text;

                if(! string.IsNullOrWhiteSpace(txtLogoImage.Text))
                    brand.LogoImagePath = CommonUtil.GetImagePath(txtLogoImage.Text, $"{DateTime.Now.ToString("yyyyMMddHHmmss")}", "Logo", brand.ID);

                if (email.CboEmail.Text == "직접 입력")
                    brand.Email2 = email.TxtEmail2.Text;
                else
                    brand.Email2 = email.CboEmail.SelectedValue.ToString();

                return brand;
            }
            set
            {
                txtID.Text = value.ID;
                txtName.Text = value.Name;
                txtCompanyNumber.Text = value.CompanyNumber;
                txtPassword.Text = txtPasswordConfirm.Text = value.Password;
                //txtLogoImage.Text = value.LogoImagePath;
                email.TxtEmail1.Text = value.Email1;
                txtContact.Text = value.Contact;
                txtAddress.Text = value.Address;
                txtCountry.Text = value.Country;

                if (value.Email2.Contains("."))
                {
                    email.TxtEmail2.Text = value.Email2;
                    email.CboEmail.SelectedIndex = email.CboEmail.FindString("직접 입력");

                }
                //else
                //    email.Email2 = value.Email2;
                //email.CboEmail.SelectedIndex = email.CboEmail.FindString(email.CboEmail.Text);

                pctLogo.ImageLocation = value.LogoImagePath;
            }
        }

        public frmBrand(OpenMode gubun)
        {
            InitializeComponent();

            if (gubun == OpenMode.Insert)
            {
                txtID.Enabled = true;
                this.Text = "브랜드 등록";
            }
            else
            {
                txtID.Enabled = false;
                btnCheckID.Enabled = false;
                this.Text = "브랜드 정보";
            }

            openMode = gubun;
        }

        private void btnCheckID_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            frmCheckValue frm = new frmCheckValue(DivTable.Brand, btnCheckID);
=======
            frmCheckValue frm = new frmCheckValue(CommonVO.DivTable.Brand, btnCheckID);
>>>>>>> a1f384a (COMMIT 1)
            frm.CheckValue = txtID.Text;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtID.Text = frm.CheckValue;
                txtID.Enabled = false;
                txtName.Focus();
            }
        }

        private void btnCheckName_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            frmCheckValue frm = new frmCheckValue(DivTable.Brand, btnCheckName);
=======
            frmCheckValue frm = new frmCheckValue(CommonVO.DivTable.Brand, btnCheckName);
>>>>>>> a1f384a (COMMIT 1)
            frm.CheckValue = txtName.Text;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtName.Text = frm.CheckValue;
                txtName.Enabled = false;
                txtCompanyNumber.Focus();
            }
        }

        private void btnCheckCompanyNumber_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            frmCheckValue frm = new frmCheckValue(DivTable.Brand, btnCheckCompanyNumber);
=======
            frmCheckValue frm = new frmCheckValue(CommonVO.DivTable.Brand, btnCheckCompanyNumber);
>>>>>>> a1f384a (COMMIT 1)
            frm.CheckValue = txtCompanyNumber.Text;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCompanyNumber.Text = frm.CheckValue;
                txtCompanyNumber.Enabled = false;
                txtPassword.Focus();
            }
        }
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.TextLength < 8)
            {
                lblPassword.Visible = true;
                lblPassword.Text = "비밀번호는 8자리 이상 입력하세요.";
            }
            else if (! CommonUtil.IsValidPassword(txtPassword.Text))
            {
                lblPassword.Visible = true;
                lblPassword.Text = "비밀번호는 반드시 영어 대 / 소문자, 숫자, 특수문자를 각각 1개 이상 포함해야 합니다.";
            }
            else
            {
                lblPassword.Visible = false;
            }
        }

        private void txtPasswordConfirm_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                lblPasswordSame.Visible = true;
            }
            else
            {
                lblPasswordSame.Visible = false;
            }

        }

        private void frmBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //유효성 체크
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                sb.AppendLine("ID를 입력하세요.");
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                sb.AppendLine("이름을 입력하세요.");
            }
            if (string.IsNullOrWhiteSpace(txtCompanyNumber.Text))
            {
                sb.AppendLine("사업자 등록 번호를 입력하세요.");
            }
            if(txtID.Enabled == true || txtName.Enabled == true || txtCompanyNumber.Enabled == true)
            {
                sb.AppendLine("중복 체크를 완료해주세요");
            }
            
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                sb.AppendLine("비밀번호를 입력하세요.");
            }
            else if (!CommonUtil.IsValidPassword(txtPassword.Text))
            {
                sb.AppendLine("비밀번호는 8~20자이며 반드시 영어 대/소문자, 숫자, 특수문자를 각각 1개 이상 포함해야합니다.");
            }
            if (string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                sb.AppendLine("비밀번호 확인을 해주세요.");
            }
            

            if (string.IsNullOrWhiteSpace(email.TxtEmail1.Text))
            {
                sb.AppendLine("Email을 입력하세요.");

            }
            else if (email.CboEmail.Text == "직접 입력" && string.IsNullOrWhiteSpace(email.TxtEmail2.Text))
            {
                sb.AppendLine("Email 주소를 입력하세요.");
            }
            else if (string.IsNullOrWhiteSpace(email.CboEmail.Text))
            {
                sb.AppendLine("Email 주소를 선택하세요.");
            }
            else if (!CommonUtil.IsValidEmail(CommonUtil.CombineEmail(email)))
            {
                sb.AppendLine("Email 양식에 맞춰 입력하세요.");
            }

            BrandDAC dac = new BrandDAC();
            if (dac.IsVaildID(txtID.Text))
            {
                sb.AppendLine("이미 사용중인 아이디입니다.");
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            
            //처리
            int iResult = dac.Insert(BrandInfo);

            
            if (iResult > 0)
            {
                
                MessageBox.Show("브랜드 등록을 완료하였습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            if (openMode == OpenMode.Update)
                CommonUtil.ComboBindingEmail(email, ((frmMain)this.Owner).CurrentBrand);
            else
                CommonUtil.ComboBindingEmail(email);
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images File(*.gif;*.jpg;*.jpeg;*.png;*.bmp)|*.gif;*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLogoImage.Text = dlg.FileName; //전체경로
                pctLogo.Image = Image.FromFile(dlg.FileName);
                pctLogo.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtID.Text.Length > 0 && e.KeyChar == 13)
                btnCheckID.PerformClick();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtName.Text.Length > 0 && e.KeyChar == 13)
                btnCheckName.PerformClick();
        }

        private void txtCompanyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCompanyNumber.Text.Length > 0 && e.KeyChar == 13)
                btnCheckCompanyNumber.PerformClick();
        }
    }
}
