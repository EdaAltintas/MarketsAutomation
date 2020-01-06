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
    public partial class CustomerSearchForm : Form
    {
        Customer cm;
        public CustomerSearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Müşteri arama butonu
            dataGridView1.Rows.Clear();
            List<Customer> cml = new List<Customer>();
            if (comboBox1.SelectedIndex == 0)
            {
                cml = HelperCustomer.GetListByName(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                cml = HelperCustomer.GetListBySurname(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                cml = HelperCustomer.GetListByTc(textBox1.Text);
            }
            foreach (var item in cml)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.CustomerID, item.name, item.surname, item.tcNo, item.gsm, item.address);
                }
            }
        }

        private void CustomerSearchForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Ad");
            comboBox1.Items.Add("Soyad");
            comboBox1.Items.Add("Tc");
            Yenile();
        }

        public void Yenile()
        {
            dataGridView1.Rows.Clear();
            List<Customer> customer = HelperCustomer.GetList();
            foreach (var item in customer)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.CustomerID, item.name, item.surname, item.tcNo, item.gsm, item.address);
                }
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MÜŞTERİ SEÇ BUTONU
           cm= HelperCustomer.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            MessageBox.Show("Müşteri seçildi");
            this.Close();
        }

        private void CustomerSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CashierLoginForm clf = (CashierLoginForm)Application.OpenForms["CashierLoginForm"];
            clf.GetCustomer(cm);
        }
    }
}
