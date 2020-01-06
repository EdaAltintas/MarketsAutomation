using Satis.DAL;
using Satis.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Satis
{
    public partial class ReportForm : Form
    {
        List<OrderModel> oml = HelperOrder.GetOrderModelList();
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            foreach (var item in oml)
            {
                dataGridView1.Rows.Add(item.orderDetail.orderID, item.product.productID, item.product.productName, item.orderDetail.count, item.product.discount, item.orderDetail.unitPrice, item.totalPrice,item.order.orderDate);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tarihe göre arama
            dataGridView1.Rows.Clear();
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            foreach (var item in oml)
            {
                DateTime date = dateTimePicker1.Value;
                string format = "MMM ddd d";
                DateTime date2 = item.order.orderDate.Date;
                if (date.ToString(format)==date2.ToString(format))
                {
                    dataGridView1.Rows.Add(item.orderDetail.orderID, item.product.productID, item.product.productName, item.orderDetail.count, item.product.discount, item.product.unitPrice, item.totalPrice, item.order.orderDate);
                }
            }
        }
    }
}
