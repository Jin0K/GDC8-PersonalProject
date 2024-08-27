using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
using System.Xml;
<<<<<<< HEAD
=======
using System.IO;
>>>>>>> a1f384a (COMMIT 1)

namespace PersonalProject
{
    public partial class frmZipSearch : Form
    {
        public string Zipcode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public frmZipSearch()
        {
            InitializeComponent();
        }

        private void ZipSearchPopup_Load(object sender, EventArgs e)
        {
            DataGridViewUtil.SetInitGridView(dgvZip);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "우편번호", "zipNo", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "도로명주소", "roadAddr", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "지번주소", "jibunAddr", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "도주1", "roadAddrPart1", visibility:false);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "도주2", "roadAddrPart2", visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvZip, "건물이름", "bdNm", visibility: false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string apiKey = ConfigurationManager.AppSettings["zipAPIKey"];
            string apiUrl = $"https://www.juso.go.kr/addrlink/addrLinkApi.do?confmKey={apiKey}&currentPage=1&countPerPage=200&keyword={txtSearch.Text}";
=======
            #region 도로명 주소 api
            //string apiKey = ConfigurationManager.AppSettings["zipAPIKey"];
            //string apiUrl = $"https://www.juso.go.kr/addrlink/addrLinkApi.do?confmKey={apiKey}&currentPage=1&countPerPage=200&keyword={txtSearch.Text}";


            //try
            //{
            //    DataSet ds = new DataSet();

            //    WebClient wc = new WebClient();
            //    XmlReader read = new XmlTextReader(wc.OpenRead(apiUrl));

            //    ds.ReadXml(read);

            //    if (ds.Tables[0].Rows[0]["totalCount"].ToString() != "0")
            //    {
            //        dgvZip.DataSource = ds.Tables[1];
            //    }
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message);
            //}

            #endregion

            #region 우체국 주소 api

            string apiKey = "991911a2e4bf97fd31723792790427";
            string apiUrl = $"http://biz.epost.go.kr/KpostPortal/openapi?regkey={apiKey}&target=postNew&query={txtSearch.Text}&countPerPage=10";

>>>>>>> a1f384a (COMMIT 1)

            try
            {
                DataSet ds = new DataSet();

                WebClient wc = new WebClient();
                XmlReader read = new XmlTextReader(wc.OpenRead(apiUrl));

                ds.ReadXml(read);

<<<<<<< HEAD
                if (ds.Tables[0].Rows[0]["totalCount"].ToString() != "0")
                {
                    dgvZip.DataSource = ds.Tables[1];
                }
=======
                if (ds.Tables[0].Rows[0]["error_code"].ToString() == "" && ds.Tables[0].Rows[0]["totalCount"].ToString() != "0")
                {
                    dgvZip.DataSource = ds.Tables[1];
                }
                else
                {
                    MessageBox.Show("검색 결과가 존재하지 않습니다.");
                }
>>>>>>> a1f384a (COMMIT 1)
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
<<<<<<< HEAD
=======

            #endregion

>>>>>>> a1f384a (COMMIT 1)
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSearch.Text.Length > 0 && e.KeyChar == 13)
                btnSearch.PerformClick();
        }

        private void dgvZip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtJibunZipcode.Text = txtRoadZipcode.Text = dgvZip["zipNo", e.RowIndex].Value.ToString();

<<<<<<< HEAD
            txtRoadAddr1.Text = dgvZip["roadAddrPart1", e.RowIndex].Value.ToString();

=======
            try
            {
                txtRoadAddr1.Text = dgvZip["roadAddrPart1", e.RowIndex].Value.ToString();
            }
            catch
            {
                txtRoadAddr1.Text = "";
            }
            
>>>>>>> a1f384a (COMMIT 1)
            string bdNm = dgvZip["bdNm", e.RowIndex].Value.ToString();
            string addr2 = dgvZip["roadAddrPart2", e.RowIndex].Value.ToString();
            string jibun = dgvZip["jibunAddr", e.RowIndex].Value.ToString();

            txtJibunAddr1.Text = jibun;

            if (addr2.Contains(bdNm))
                txtRoadAddr2.Text = addr2;
            else
                txtRoadAddr2.Text = addr2 + bdNm;
            
            if (jibun.Contains(bdNm))
                txtJibunAddr2.Text = "";
            else
                txtJibunAddr2.Text = bdNm;
        }

        private void btnRoad_Click(object sender, EventArgs e)
        {
            Zipcode = txtRoadZipcode.Text;
            Address1 = txtRoadAddr1.Text;
            Address2 = txtRoadAddr2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnJibun_Click(object sender, EventArgs e)
        {
            Zipcode = txtJibunZipcode.Text;
            Address1 = txtJibunAddr1.Text;
            Address2 = txtJibunAddr2.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
