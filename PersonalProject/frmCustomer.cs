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
<<<<<<< HEAD
=======
using static CommonVO;
>>>>>>> a1f384a (COMMIT 1)

namespace PersonalProject
{
    public partial class frmCustomer : Form
    {
        OpenMode openMode = 0;
        DataTable dtAllAddressList;

        //ID,Password,Name,Gender,Birth,Email1,Email2,Phone1,Phone2,Phone3
        public Customer CustomerInfo
        {
            get
            {
                Customer ct = new Customer();
                ct.ID = txtID.Text;
                ct.Password = txtPassword.Text;
                ct.Name = txtName.Text;
                ct.Birth = dtpBirth.Value;
                ct.Email1 = email.TxtEmail1.Text;
                //ct.Email2 = ((frmMain)this.Owner).CurrentCostumer.Email2;
                ct.Phone1 = ntbPhone1.Text;
                ct.Phone2 = ntbPhone2.Text;
                ct.Phone3 = ntbPhone3.Text;
                ct.BaseAddress = Convert.ToInt32(cboSelectAddr.SelectedValue);

                if (rdoF.Checked)
                    ct.Gender = 'F';
                else if (rdoM.Checked)
                    ct.Gender = 'M';

                if (email.CboEmail.Text == "직접 입력")
                    ct.Email2 = email.TxtEmail2.Text;
                else
                    ct.Email2 = email.CboEmail.SelectedValue.ToString();

                return ct;
            }
            set
            {
                txtID.Text = value.ID;
                txtName.Text = value.Name;
                txtPassword.Text = txtPasswordConfirm.Text = value.Password;
                dtpBirth.Value = value.Birth;
                email.TxtEmail1.Text = value.Email1;
                //                email.TxtEmail2.Text = value.Email2;
                ntbPhone1.Text = value.Phone1;
                ntbPhone2.Text = value.Phone2;
                ntbPhone3.Text = value.Phone3;
                //cboSelectAddr.SelectedItem = value.BaseAddress;

                if (value.Gender == 'F')
                    rdoF.Checked = true;
                else if (value.Gender == 'M')
                    rdoM.Checked = true;

                if (value.Email2.Contains("."))
                {
                    email.TxtEmail2.Text = value.Email2; //code
                    email.CboEmail.SelectedIndex = email.CboEmail.FindString("직접 입력");
                }
                //}else
                //{
                //    if(email.CboEmail.SelectedValue.ToString() == value.Email2)
                //    {
                //        email.CboEmail.SelectedIndex = email.CboEmail.FindString(email.CboEmail.SelectedText); 
                //    }
                //}
                    //email.Email2 = value.Email2;
                //email.CboEmail.SelectedIndex = email.CboEmail.FindString(((frmMain)this.Owner).CurrentCostumer.Email2);
                //email.CboEmail.SelectedIndex = email.CboEmail.FindString(email.CboEmail.);

            }
        }

        public Address AddressInfo
        {
            get
            {

                //ADDRESS_NUMBER, CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, BASE_ADDRESS
                //DataRow[] rows = dtAllAddressList.Select("BASE_ADDRESS='Y'");

                //baseZip.AddressName = rows[0]["ADDRESS_NAME"].ToString();
                //baseZip.ZipCode = rows[0]["ZIP_CODE"].ToString();
                //baseZip.Address1 = rows[0]["ADDRESS1"].ToString();
                //baseZip.Address2 = rows[0]["ADDRESS2"].ToString();

                //AddressDAC dac = new AddressDAC();
                //dac.GetAddress(txtID.Text);
                //DataRow[] rows = dtAllAddressList.Select($"ADDRESS_NUMBER={((frmMain)this.Owner).CurrentCostumer.BaseAddress}");

                Address addr = new Address();
                //addr.ID = txtID.Text;
                addr.Number = Convert.ToInt32(cboSelectAddr.SelectedValue);
                addr.Name = baseZip.AddressName;
                addr.ZipCode = baseZip.ZipCode;
                addr.Address1 = baseZip.Address1;
                addr.Address2 = baseZip.Address2;
                addr.CustomerID = txtID.Text;
                //((frmMain)this.Owner).CurrentCostumer.ID;
                //AddressDAC dac = new AddressDAC();
                //Address addr = dac.GetAddress(((frmMain)this.Owner).CurrentCostumer.BaseAddress);

                return addr;
            }
            set
            {
                //cboSelectAddr.SelectedValue = value.ID;
                baseZip.AddressName = value.Name;
                baseZip.ZipCode = value.ZipCode;
                baseZip.Address1 = value.Address1;
                baseZip.Address2 = value.Address2;

            }
        }

        public frmCustomer(OpenMode gubun)
        {
            InitializeComponent();
            
            if (gubun == OpenMode.Insert)
            {
                txtID.Enabled = true;
                pnlSetAddr.Visible = false;
                this.Text = "회원가입";
                btnJoin.Text = "가입";

                dtpBirth.MaxDate = DateTime.Now;

            }
            else
            {
                txtID.Enabled = false;
                btnIDCheck.Enabled = false;
                pnlSetAddr.Visible = true;
                
                this.Text = "회원정보";
                btnJoin.Text = "수정";
                
                //CommonUtil.ComboBinding(cboSelectAddr,)
            }
            openMode = gubun;
        }

        private void btnIDCheck_Click(object sender, EventArgs e)
        {
            frmCheckValue frm = new frmCheckValue(DivTable.Customer, btnIDCheck);
            frm.CheckValue = txtID.Text;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtID.Text = frm.CheckValue;
                txtID.Enabled = false;
                txtPassword.Focus();
            }
        }

        private void btnAddrAdd_Click(object sender, EventArgs e)
        {
            frmAddress addr = new frmAddress(CustomerInfo.ID);
            addr.Show();
        }

        //private void cboEmail_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Debug.WriteLine(email.CboEmail.Text);
        //    Debug.WriteLine(email.CboEmail.SelectedText);
        //    Debug.WriteLine(email.CboEmail.SelectedValue);
        //    if (email.CboEmail.Text == "직접 입력")
        //    {
        //        email.TxtEmail2.Visible = true;
        //        email.CboEmail.Location = new Point(376, 354);
        //        email.TxtEmail2.Focus();
        //    }
        //    else
        //    {
        //        email.TxtEmail2.Visible = false;
        //        email.CboEmail.Location = email.TxtEmail2.Location;
        //    }
        //}

        private void btnJoin_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            CustomerDAC dac = new CustomerDAC();
            if (openMode == OpenMode.Insert)
            {
                //유효성 체크
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    sb.AppendLine("ID를 입력하세요.");
                }
                else if (txtID.Enabled == true)
                {
                    sb.AppendLine("중복 체크를 완료해주세요");
                }
                
                if (dac.IsVaildID(txtID.Text))
                {
                    sb.AppendLine("이미 사용중인 아이디입니다.");
                }
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                sb.AppendLine("이름을 입력하세요.");
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


<<<<<<< HEAD
            if (string.IsNullOrWhiteSpace(baseZip.ZipCode) || string.IsNullOrWhiteSpace(baseZip.Address1))
            {
                sb.AppendLine("주소를 입력하세요.");
            }
            else if (string.IsNullOrWhiteSpace(baseZip.Address2))
            {
                sb.AppendLine("상세 주소를 입력하세요.");
            }

            if (ntbPhone1.TextLength < 2 || ntbPhone2.TextLength < 3 || ntbPhone3.TextLength != 4)
            {
                sb.AppendLine("핸드폰 번호를 입력하세요.");
            }
=======
            //if (string.IsNullOrWhiteSpace(baseZip.ZipCode) || string.IsNullOrWhiteSpace(baseZip.Address1))
            //{
            //    sb.AppendLine("주소를 입력하세요.");
            //}
            //else if (string.IsNullOrWhiteSpace(baseZip.Address2))
            //{
            //    sb.AppendLine("상세 주소를 입력하세요.");
            //}

            //if (ntbPhone1.TextLength < 2 || ntbPhone2.TextLength < 3 || ntbPhone3.TextLength != 4)
            //{
            //    sb.AppendLine("핸드폰 번호를 입력하세요.");
            //}
>>>>>>> a1f384a (COMMIT 1)

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }

            string sResult = string.Empty;
            bool bResult;
            //처리
            if (openMode == OpenMode.Insert)
            {
                bResult = dac.Insert(CustomerInfo, AddressInfo);
                sResult = "가입";
            }
            else if (openMode == OpenMode.Update)
            {
                bResult = dac.Update(CustomerInfo, AddressInfo);
                sResult = "정보 수정";
            }
            else
                bResult = false;

            if (bResult)
            {
                MessageBox.Show($"회원{sResult}을 완료하였습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"회원{sResult} 중 오류가 발생하였습니다.");
            }
            
           
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            if(openMode == OpenMode.Update)
                CommonUtil.ComboBindingEmail(email, ((frmMain)this.Owner).CurrentCustomer);
            else
                CommonUtil.ComboBindingEmail(email);

            #region email 실패 주석
            //////email.CboEmail.SelectedIndex = 0;
            ////email.TxtEmail2.Visible = false;
            ////email.CboEmail.Location = email.TxtEmail2.Location;

            //string[] category = { "이메일 주소" };

            //CommonDAC dac = new CommonDAC();
            //DataTable dt = dac.GetCommonCodes(category);

            //CommonUtil.ComboBinding(email.CboEmail, dt, "이메일 주소", inputItem: true);
            //Debug.WriteLine(email.Email2);
            ////Debug.WriteLine(email.CboEmail.);
            ////DataRow[] rows = dt.Select("BASE_ADDRESS='Y'");

            ////baseZip.AddressNumber = Convert.ToInt32(rows[0]["ADDRESS_NUMBER"]);
            ////baseZip.AddressName = rows[0]["ADDRESS_NAME"].ToString();
            ////baseZip.ZipCode = rows[0]["ZIP_CODE"].ToString();
            ////baseZip.Address1 = rows[0]["ADDRESS1"].ToString();
            ////baseZip.Address2 = rows[0]["ADDRESS2"].ToString();

            ////cboSelectAddr.SelectedIndex = cboSelectAddr.FindString(baseZip.AddressName);


            //if (CustomerInfo.Email2.Contains(".")) //email.CboEmail.Text == "직접 입력" || email.TxtEmail2.Text.Contains(".")
            //{
            //    email.TxtEmail2.Visible = true;
            //    email.CboEmail.Location = new Point(296, 0);

            //    email.CboEmail.SelectedIndex = email.CboEmail.FindString("직접 입력");
            //    email.TxtEmail2.Text = email.Email2;

            //    email.TxtEmail2.Focus();
            //}
            //else
            //{
            //    email.TxtEmail2.Visible = false;
            //    email.CboEmail.Location = email.TxtEmail2.Location;
            //    DataRow[] rows = dt.Select($"CCODE='{CustomerInfo.Email2}'");
            //    email.CboEmail.SelectedIndex = email.CboEmail.FindString(rows[0]["CNAME"].ToString());
            //}

            ////if (email.Email2.Contains("."))
            ////{
            ////    email.TxtEmail2.Text = value.Email2;
            ////    email.CboEmail.SelectedIndex = email.CboEmail.FindString("직접 입력");

            ////}
            ////email.CboEmail.SelectedIndex = email.CboEmail.FindString(CustomerInfo.Email2); 

            #endregion

            if (! txtID.Enabled)
            {
                //Debug.WriteLine(txtID.Text);
                //Debug.WriteLine(CustomerInfo.ID);
                //Debug.WriteLine(this.CustomerInfo.ID);
                //Debug.WriteLine(AddressInfo.CustomerID);

                AddressDAC ad = new AddressDAC();
                dtAllAddressList = ad.GetAddress(CustomerInfo.ID);

                CommonUtil.ComboBinding(cboSelectAddr, dtAllAddressList, "ADDRESS_NAME", "ADDRESS_NUMBER");
                ShowAddress();


            }

            //DataRow dr1 = dt.NewRow();
            //dr1["CCode"] = "";
            //dr1["CName"] = "이메일 주소 선택";
            //dt.Rows.InsertAt(dr1, 0);
            //DataRow dr2 = dt.NewRow();
            //dr2["CCode"] = "직접 입력";
            //dr2["CName"] = "직접 입력";
            //dt.Rows.Add(dr2);
            //dt.AcceptChanges(); //datatable의 변경내역을 반영 commit

            //email.CboEmail.DisplayMember = "CName";
            //email.CboEmail.ValueMember = "CCode";
            //email.CboEmail.DataSource = dt;
        }

        private void ShowAddress()
        {

            //ADDRESS_NUMBER, CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, BASE_ADDRESS
            DataRow[] rows = dtAllAddressList.Select("BASE_ADDRESS='Y'");

<<<<<<< HEAD
=======
            if (rows.Length == 0)
            {
                return;
            }

>>>>>>> a1f384a (COMMIT 1)
            baseZip.AddressNumber = Convert.ToInt32(rows[0]["ADDRESS_NUMBER"]);
            baseZip.AddressName = rows[0]["ADDRESS_NAME"].ToString();
            baseZip.ZipCode = rows[0]["ZIP_CODE"].ToString();
            baseZip.Address1 = rows[0]["ADDRESS1"].ToString();
            baseZip.Address2 = rows[0]["ADDRESS2"].ToString();

            cboSelectAddr.SelectedIndex = cboSelectAddr.FindString(baseZip.AddressName);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.TextLength < 8)
            {
                lblPassword.Visible = true;
                lblPassword.Text = "비밀번호는 8자리 이상 입력하세요.";
            }
            else if (!CommonUtil.IsValidPassword(txtPassword.Text))
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

        private void frmCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnSetAddr_Click(object sender, EventArgs e)
        {
            AddressDAC dac = new AddressDAC();
            if(dac.UpdateBaseAddress(AddressInfo))
                CustomerInfo.BaseAddress = AddressInfo.Number;
        }

        private void btnAddAddr_Click(object sender, EventArgs e)
        {
            frmAddress frm = new frmAddress(CustomerInfo.ID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                AddressDAC ad = new AddressDAC();
                dtAllAddressList = ad.GetAddress(CustomerInfo.ID);

                CommonUtil.ComboBinding(cboSelectAddr, dtAllAddressList, "ADDRESS_NAME", "ADDRESS_NUMBER");
                ShowAddress();
            }
        }

        private void cboSelectAddr_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ADDRESS_NUMBER, CUSTOMER_ID, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, BASE_ADDRESS
            DataRow[] rows = dtAllAddressList.Select($"ADDRESS_NUMBER={cboSelectAddr.SelectedValue}");

            baseZip.AddressNumber = Convert.ToInt32(rows[0]["ADDRESS_NUMBER"]);
            baseZip.AddressName = rows[0]["ADDRESS_NAME"].ToString();
            baseZip.ZipCode = rows[0]["ZIP_CODE"].ToString();
            baseZip.Address1 = rows[0]["ADDRESS1"].ToString();
            baseZip.Address2 = rows[0]["ADDRESS2"].ToString();


        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtID.Text.Length > 0 && e.KeyChar == 13)
                btnIDCheck.PerformClick();
        }
    }
}
