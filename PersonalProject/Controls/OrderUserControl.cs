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
    public delegate void OrderItemEventHandler(object sender, OrderItemEventArgs e);

    public partial class OrderUserControl : UserControl
    {
        Order order;
        public event OrderItemEventHandler ShowOrderDetail;
        public Order OrderMaster
        {

            get { return order; }
            set
            {
                if (value == null) return;
                order = value;
                lblDateTime.Text = value.OrderDateTime.ToString("yyyy-MM-ddHH:mm:ss");
                lblOrderAmount.Text = value.OrderAmount.ToString("#,##0") + " 원";
                lblOrderState.Text = value.OrderStatusName.ToString();
                llbOrderNumber.Text = value.OrderNumber.ToString();
            }
        }
        public string ZipCode
        {
            get { return lblZipCode.Text; }
            set { lblZipCode.Text = value; }
        }
        public string Address1
        {
            get { return lblAddress1.Text; }
            set { lblAddress1.Text = value; }
        }
        public string Address2
        {
            get { return lblAddress2.Text; }
            set { lblAddress2.Text = value; }
        }

        public string AddressName
        {
            get { return lblAddressName.Text; }
            set { lblAddressName.Text = value; }
        }

        public int AddressNumber { get; set; }

        public OrderUserControl()
        {
            InitializeComponent();
        }

        private void llbOrderNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ShowOrderDetail != null)
            {
                OrderItemEventArgs args = new OrderItemEventArgs();
                args.OrderNumber = OrderMaster.OrderNumber;
                ShowOrderDetail(null, args);
            }
        }

        private void OrderUserControl_DoubleClick(object sender, EventArgs e)
        {
            if (ShowOrderDetail != null)
            {
                OrderItemEventArgs args = new OrderItemEventArgs();
                args.OrderNumber = OrderMaster.OrderNumber;
                ShowOrderDetail(null, args);
            }
        }
    }
    public class OrderItemEventArgs : EventArgs
    {
        public int OrderNumber { get; set; }
    }
}
