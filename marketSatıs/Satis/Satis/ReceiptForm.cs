using Satis.DAL;
using Satis.Entity;
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
    public partial class ReceiptForm : Form
    {
        Customer cm;
        List<List<string>> receipt;
        string tutar;
        public ReceiptForm()
        {
            InitializeComponent();
        }
        public ReceiptForm(List<List<string>> receipt,Customer cm,string tutar)
        {
            InitializeComponent();
            this.receipt = receipt;
            this.cm = cm;
            this.tutar = tutar;
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            foreach (var item in receipt)
            {
                listView1.Items.Add(new ListViewItem(item.ToArray()));
            }
            label3.Text = cm.name+" "+cm.surname;
            label2.Text = tutar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
