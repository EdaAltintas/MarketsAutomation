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
    public partial class CashierForm : Form
    {
        public CashierForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kasiyer ekleme butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text) && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(textBox7.Text) && !String.IsNullOrEmpty(textBox8.Text))
            {
                if (!HelperCashier.SearchUserName(textBox7.Text))
                {
                    MessageBox.Show("Aynı kullanıcı adı mevcut. Lütfen kullanıcı adını değiştiriniz.");
                }
                else
                {
                    Cashier c = new Cashier()
                    {
                        name = textBox2.Text,
                        surname = textBox3.Text,
                        tcNo = textBox4.Text,
                        gsm = maskedTextBox1.Text,
                        address = textBox5.Text,
                        salary = Convert.ToInt32(textBox6.Text),
                        userName = textBox7.Text,
                        password = textBox8.Text,
                        IsActive = true,
                    };
                    Users us = new Users()
                    {
                        userName = textBox7.Text,
                        password = textBox8.Text,
                        userType = 2
                    };
                    var ekle = HelperCashier.CUD(c, System.Data.Entity.EntityState.Added);
                    var ekle2 = HelperUsers.CUD(us, System.Data.Entity.EntityState.Added);
                    if (ekle.Item2)
                    {
                        MessageBox.Show("Kasiyer ekleme başarılı.");
                    }
                    else
                    {
                        MessageBox.Show("Kasiyer eklenemedi");
                    }
                    Yenile();
                }
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
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
        public void Yenile()
        {
            dataGridView1.Rows.Clear();
            List<Cashier> cashier = HelperCashier.GetList();
            foreach (var item in cashier)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.cashierID, item.name, item.surname, item.tcNo, item.gsm,item.address,item.salary,item.userName,item.password);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Kasiyer Düzenleme butonu
            if (!String.IsNullOrEmpty(textBox2.Text)&& !String.IsNullOrEmpty(textBox3.Text)&& !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text) && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(textBox7.Text) && !String.IsNullOrEmpty(textBox8.Text))
            {
                Cashier c = HelperCashier.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                c.name = textBox2.Text;
                c.surname = textBox3.Text;
                c.tcNo = textBox4.Text;
                c.gsm = maskedTextBox1.Text;
                c.address = textBox5.Text;
                c.salary = Convert.ToInt32(textBox6.Text);
                c.userName = textBox7.Text;
                c.password = textBox8.Text;
                var degistir = HelperCashier.CUD(c, System.Data.Entity.EntityState.Modified);
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
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void KasiyerForm_Load(object sender, EventArgs e)
        {
            Yenile();
            comboBox1.Items.Add("Ad");
            comboBox1.Items.Add("Soyad");
            comboBox1.Items.Add("Tc");
            comboBox1.Items.Add("Kullanıcı Adı");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            Cashier c = HelperCashier.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            textBox2.Text = c.name;
            textBox3.Text = c.surname;
            textBox4.Text = c.tcNo;
            maskedTextBox1.Text = c.gsm;
            textBox5.Text = c.address;
            textBox6.Text = c.salary.ToString();
            textBox7.Text = c.userName;
            textBox8.Text = c.password;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Girdileri temizle butonu
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kasiyer Silme Butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text) && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(textBox7.Text) && !String.IsNullOrEmpty(textBox8.Text))
            {
                if (String.IsNullOrEmpty(dataGridView1.CurrentRow.Index.ToString()))
                {
                    MessageBox.Show("Kasiyer seçmediniz!!!");
                }
                else
                {
                    var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (a == DialogResult.Yes)
                    {
                        Cashier m = HelperCashier.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                        m.IsActive = false;
                        var b = HelperCashier.CUD(m, System.Data.Entity.EntityState.Modified);
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
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kasiyer arama butonu
            dataGridView1.Rows.Clear();
            List<Cashier> c = new List<Cashier>();
            if (comboBox1.SelectedIndex==0)
            {
                c = HelperCashier.GetListByName(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex==1)
            {
                c = HelperCashier.GetListBySurname(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex==2)
            {
                c = HelperCashier.GetListByTc(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex==3)
            {
                c = HelperCashier.GetListByUserName(textBox1.Text);
            }
            foreach (var item in c)
            {
                if (item.IsActive==true)
                {
                    dataGridView1.Rows.Add(item.cashierID, item.name, item.surname, item.tcNo, item.gsm, item.address, item.salary, item.userName, item.password);
                }
                
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}
