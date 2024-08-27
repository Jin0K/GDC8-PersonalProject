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
    public partial class frmOrder : Form
    {
        DataTable dtAllOrder, dtSelectOrder;
        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            OrderDAC dac = new OrderDAC();
            dtAllOrder = dac.GetOrders();
            dtSelectOrder = dtAllOrder.Copy();
            ShowOrderList(dtAllOrder);
        }

        public void ShowOrderList(DataTable dt)
        {
            splitContainer1.Panel2.Controls.Clear();

            //int totalPrice = 0, totalPay = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                OrderUserControl ctrl = new OrderUserControl();
                ctrl.Name = $"OrderItem{i}";
                ctrl.Location = new Point(10, 10 + (75 * i));
                ctrl.Size = new Size(900, 70);
                //DataRow[] drColor = dsProduct.Tables["common_code"].Select($"CCODE='{dt.Rows[i]["COLOR"]}'");
                //DataRow[] drSize = dsProduct.Tables["common_code"].Select($"CCODE='{dt.Rows[i]["SIZE"]}'");
                ctrl.OrderMaster = new Order()
                {
                    //ORDER_NUMBER, CUSTOMER_ID, ADDRESS_NUMBER, ORDER_AMOUNT, ORDER_DATETIME, ORDER_STATUS, PAYMENT_CHECK
                    OrderNumber = Convert.ToInt32(dt.Rows[i]["ORDER_NUMBER"]),
                    CustomerID = dt.Rows[i]["CUSTOMER_ID"].ToString(),
                    AddressNumber = Convert.ToInt32(dt.Rows[i]["ADDRESS_NUMBER"]),
                    OrderAmount = Convert.ToInt32(dt.Rows[i]["ORDER_AMOUNT"]),
                    OrderDateTime = Convert.ToDateTime(dt.Rows[i]["ORDER_DATETIME"]),
                    OrderStatus = dt.Rows[i]["ORDER_STATUS"].ToString(),
                    OrderStatusName = dt.Rows[i]["CNAME"].ToString(),
                    PaymentCheck = Convert.ToBoolean(dt.Rows[i]["PAYMENT_CHECK"])
                };
                //ADDRESS_NAME, ZIP_CODE, ADDRESS1, ADDRESS2
                ctrl.AddressName = dt.Rows[i]["ADDRESS_NAME"].ToString();
                ctrl.ZipCode = dt.Rows[i]["ZIP_CODE"].ToString();
                ctrl.Address1 = dt.Rows[i]["ADDRESS1"].ToString();
                ctrl.Address2 = dt.Rows[i]["ADDRESS2"].ToString();

                ctrl.ShowOrderDetail += Ctrl_ShowOrderDetail;
                splitContainer1.Panel2.Controls.Add(ctrl);

            }
            //lblTotalPrice.Text = $"{totalPrice.ToString("#,##0")} 원";
            //lblDiscountPrice.Text = $"{(totalPrice - totalPay).ToString("#,##0")} 원";
            //lblPay.Text = totalPay.ToString("#,##0");
            //lblAccumulatedPoint.Text = $"{((totalPay * 1.0) * 0.01).ToString()} 점";
        }

        private void Ctrl_ShowOrderDetail(object sender, OrderItemEventArgs e)
        {
            
            //OrderUserControl ucOrder = (OrderUserControl)sender;
            DataView dv = new DataView(dtAllOrder);
            dv.RowFilter = $"ORDER_NUMBER={e.OrderNumber}";
            frmOrderDetail frm = new frmOrderDetail(dv.ToTable());
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            DataView dv = new DataView(dtAllOrder);
            dv.RowFilter = " (ORDER_DATETIME >= #" + ucPeriod.From.ToString("MM/dd/yyyy") + "# And ORDER_DATETIME <= #" + ucPeriod.To.AddDays(1).ToString("MM/dd/yyyy") + "# ) ";
            //dv.RowFilter = $"ORDER_DATETIME BETWEEN #{ucPeriod.From}# AND DATEADD(DAY, 1, #{ucPeriod.To.AddDays(1)}#)";
            dtSelectOrder = dv.ToTable();
            ShowOrderList(dtSelectOrder);

        }

        private void llbSort_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            DataView dv = new DataView(dtSelectOrder);
            

            if (llbSort.Text == "오름차순▲")
            {
                llbSort.Text = "내림차순▼";
                dv.Sort = $"ORDER_DATETIME desc";
            }
            else if (llbSort.Text == "내림차순▼")
            {
                llbSort.Text = "오름차순▲";
                dv.Sort = $"ORDER_DATETIME asc";
            }
            //else
            //{
            //    PnlSortLinkLabelReset();
            //    linkLabel.Text = linkLabel.Text + "▲";
            //    dv.Sort = $"{sortColumn} asc";
            //}


            //linkLabel.LinkColor = Color.Blue;
            //dtCurFilter = dv.ToTable();
            ShowOrderList(dv.ToTable());
        }
    }
}
