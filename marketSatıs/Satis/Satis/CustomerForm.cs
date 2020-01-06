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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void MusteriForm_Load(object sender, EventArgs e)
        {
            Yenile();
            comboBox1.Items.Add("Ad");
            comboBox1.Items.Add("Soyad");
            comboBox1.Items.Add("Tc");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //Müşteri ekleme butonu
            if (!String.IsNullOrEmpty(textBox2.Text)&& !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                Customer cm = new Customer()
                {
                    name = textBox2.Text,
                    surname = textBox3.Text,
                    tcNo = textBox4.Text,
                    gsm = maskedTextBox1.Text,
                    address = textBox5.Text,
                    IsActive = true
                };
                var ekle = HelperCustomer.CUD(cm, System.Data.Entity.EntityState.Added);
                if (ekle.Item2)
                {
                    MessageBox.Show("Müşteri ekleme başarılı.");
                }
                else
                {
                    MessageBox.Show("Müşteri eklenemedi");
                }
                Yenile();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Müşteri Düzenleme butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                Customer cm = HelperCustomer.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                cm.name = textBox2.Text;
                cm.surname = textBox3.Text;
                cm.tcNo = textBox4.Text;
                cm.gsm = maskedTextBox1.Text;
                cm.address = textBox5.Text;
                var degistir = HelperCustomer.CUD(cm, System.Data.Entity.EntityState.Modified);
                if (degistir.Item2)
                {
                    MessageBox.Show("Güncelleme başarılı.");
                }
                else
                {
                    MessageBox.Show("Güncelleme yapılamadı.");
                }
                Yenile();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Müşteri Silme Butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    Customer cm = HelperCustomer.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                    cm.IsActive = false;
                    var b = HelperCustomer.CUD(cm, System.Data.Entity.EntityState.Modified);
                    if (b.Item2)
                    {
                        MessageBox.Show("Silme işlemi başarılı");
                    }
                    else
                    {
                        MessageBox.Show("Silme yapılamadı");
                    }
                }
                Yenile();
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Girdileri temizle butonu
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Müşteri arama butonu
            dataGridView1.Rows.Clear();
            List<Customer> cm = new List<Customer>();
            if (comboBox1.SelectedIndex == 0)
            {
                cm = HelperCustomer.GetListByName(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                cm = HelperCustomer.GetListBySurname(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                cm = HelperCustomer.GetListByTc(textBox1.Text);
            }
            foreach (var item in cm)
            {
                if (item.IsActive==true)
                {
                    dataGridView1.Rows.Add(item.CustomerID, item.name, item.surname, item.tcNo, item.gsm, item.address);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            Customer cm = HelperCustomer.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            textBox2.Text = cm.name;
            textBox3.Text = cm.surname;
            textBox4.Text = cm.tcNo;
            maskedTextBox1.Text = cm.gsm;
            textBox5.Text = cm.address;
        }
    }
}
