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
    public partial class frmAddress : Form
    {
        string customerID;
        bool isChanged = false;
        public Address AddressInfo
        {
            get
            {
                //AddressDAC dac = new AddressDAC();
                //dac.GetAddress(txtID.Text);
                //DataRow[] rows = dtAllAddressList.Select($"ADDRESS_NUMBER={((frmMain)this.Owner).CurrentCostumer.BaseAddress}");

                Address addr = new Address();
                //addr.ID = txtID.Text;
                addr.Number = ucZipCode.AddressNumber;
                addr.Name = ucZipCode.AddressName;
                addr.ZipCode = ucZipCode.ZipCode;
                addr.Address1 = ucZipCode.Address1;
                addr.Address2 = ucZipCode.Address2;
                addr.CustomerID = customerID;
                //AddressDAC dac = new AddressDAC();
                //Address addr = dac.GetAddress(((frmMain)this.Owner).CurrentCostumer.BaseAddress);

                return addr;
            }
            set
            {
                //cboSelectAddr.SelectedValue = value.ID;
                ucZipCode.AddressName = value.Name;
                ucZipCode.ZipCode = value.ZipCode;
                ucZipCode.Address1 = value.Address1;
                ucZipCode.Address2 = value.Address2;

            }
        }

        public frmAddress(string customerID)
        {
            InitializeComponent();

            this.customerID = customerID;
        }

        private void frmAddress_Load(object sender, EventArgs e)
        {
            //컨트롤의 초기화  ADDRESS_NUMBER, ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2
            

            DataGridViewUtil.SetInitGridView(dgvAddress);
            DataGridViewUtil.AddGridTextColumn(dgvAddress, "등록번호", "ADDRESS_NUMBER", visibility: false) ;
            DataGridViewUtil.AddGridTextColumn(dgvAddress, "주소명", "ADDRESS_NAME", DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextColumn(dgvAddress, "우편 번호", "ZIP_CODE", DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddGridTextColumn(dgvAddress, "주소1", "ADDRESS1", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvAddress, "주소2", "ADDRESS2", colWidth: 200);
            


            //데이터바인딩
            LoadData();
        }

        private void LoadData()
        {
            AddressDAC dac = new AddressDAC();
            //DataTable dt = dac.GetAddress(customerID);
            dgvAddress.DataSource = dac.GetAddress(customerID);
            
            dac.Dispose();

            //기본설정 : 바인딩되는 DataSource의 컬럼그대로 컬럼이 생성되면서 바인딩
            //dgvAddress.DataSource = dt;
            dgvAddress.ClearSelection();
        }

        private void dgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2, ADDRESS_NUMBER

            ucZipCode.AddressNumber = Convert.ToInt32(dgvAddress[0, dgvAddress.CurrentRow.Index].Value);
            ucZipCode.AddressName = dgvAddress[1, dgvAddress.CurrentRow.Index].Value.ToString();
            ucZipCode.ZipCode = dgvAddress[2, dgvAddress.CurrentRow.Index].Value.ToString();
            ucZipCode.Address1 = dgvAddress[3, dgvAddress.CurrentRow.Index].Value.ToString();
            ucZipCode.Address2 = dgvAddress[4, dgvAddress.CurrentRow.Index].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!CommonCheck()) return;

            AddressDAC dac = new AddressDAC();
            bool bResult = dac.Insert(AddressInfo);
            //string sResult = "추가";

            if (bResult)
            {
                MessageBox.Show($"주소 추가를 완료하였습니다.");
                isChanged = true;
                LoadData();
                //this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show($"주소 추가 중 오류가 발생하였습니다.");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(ucZipCode.AddressNumber < 1)
            {
                MessageBox.Show($"수정할 주소를 선택해주세요.");
                return;
            }

            if (!CommonCheck()) return;

            AddressDAC dac = new AddressDAC();
            bool bResult = dac.Update(AddressInfo);
            //string sResult = "수정";

            if (bResult)
            {
                MessageBox.Show($"주소 수정을 완료하였습니다.");
                isChanged = true;
                LoadData();
                //this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show($"주소 수정 중 오류가 발생하였습니다.");
            }
        }

        private bool CommonCheck()
        {
            
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(ucZipCode.Name))
            {
                sb.AppendLine("주소명을 입력하세요.");
            }
            else if (string.IsNullOrWhiteSpace(ucZipCode.Name))
            {
                sb.AppendLine("주소명을 입력하세요.");
            }
            else if (string.IsNullOrWhiteSpace(ucZipCode.ZipCode) || string.IsNullOrWhiteSpace(ucZipCode.Address1))
            {
                sb.AppendLine("주소를 입력하세요.");
            }
            else if (string.IsNullOrWhiteSpace(ucZipCode.Address2))
            {
                sb.AppendLine("상세 주소를 입력하세요.");
            }

            AddressDAC dac = new AddressDAC();
            if(dac.IsVaildName(AddressInfo))
            {
                sb.AppendLine("이미 사용 중인 주소명입니다.");
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return false;
            }
            else return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ucZipCode.AddressNumber < 1)
            {
                MessageBox.Show($"삭제할 주소를 선택해주세요.");
                return;
            }

            if (MessageBox.Show($"주소명 : {ucZipCode.AddressName}\n\r우편번호 : {ucZipCode.ZipCode}\n\r주소1 : {ucZipCode.Address1}\n\r주소2 : {ucZipCode.Address2}\n\r주소를 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            AddressDAC dac = new AddressDAC();
            bool bResult = dac.Delete(AddressInfo);
            //string sResult = "수정";

            if (bResult)
            {
                MessageBox.Show($"주소 삭제를 완료하였습니다.");
                isChanged = true;
                LoadData();
                //this.DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show($"주소 삭제 중 오류가 발생하였습니다.");
            }
        }

        private void frmAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
                this.DialogResult = DialogResult.OK;
        }
    }
}