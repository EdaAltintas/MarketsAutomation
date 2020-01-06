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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Satıcı ekleme butonu
            if (!String.IsNullOrEmpty(textBox2.Text)&& !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                Supplier sp = new Supplier()
                {
                    companyName = textBox2.Text,
                    supplierNameSurname = textBox3.Text,
                    address = textBox4.Text,
                    gsm = maskedTextBox1.Text,
                    IsActive = true
                };
                var ekle = HelperSupplier.CUD(sp, System.Data.Entity.EntityState.Added);
                if (ekle.Item2)
                {
                    MessageBox.Show("Satıcı ekleme başarılı.");
                }
                else
                {
                    MessageBox.Show("Satıcı eklenemedi");
                }
                Yenile();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
        }
        public void Yenile()
        {
            dataGridView1.Rows.Clear();
            List<Supplier> supplier = HelperSupplier.GetList();
            foreach (var item in supplier)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.supplierID, item.companyName, item.supplierNameSurname, item.address, item.gsm);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Satıcı Düzenleme Butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                Supplier sp = HelperSupplier.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                sp.companyName = textBox2.Text;
                sp.supplierNameSurname = textBox3.Text;
                sp.address = textBox4.Text;
                sp.gsm = maskedTextBox1.Text;
                var degistir = HelperSupplier.CUD(sp, System.Data.Entity.EntityState.Modified);
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Satıcı Silme Butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(maskedTextBox1.Text))
            {
                var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    Supplier sp = HelperSupplier.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                    sp.IsActive = false;
                    var b = HelperSupplier.CUD(sp, System.Data.Entity.EntityState.Modified);
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
                MessageBox.Show("Lütfen silinecek satıcıyı seçiniz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Satıcı Arama Butonu
            dataGridView1.Rows.Clear();
            List<Supplier> c = new List<Supplier>();
            if (comboBox1.SelectedIndex == 0)
            {
                c = HelperSupplier.GetListBySuppliernamesurname(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                c = HelperSupplier.GetListByCompanyName(textBox1.Text);
            }
            foreach (var item in c)
            {
                if (item.IsActive==true)
                {
                    dataGridView1.Rows.Add(item.supplierID, item.companyName, item.supplierNameSurname, item.address, item.gsm);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            Yenile();
            comboBox1.Items.Add("Satıcı ad soyad");
            comboBox1.Items.Add("Şirket Adı");
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            Supplier sp = HelperSupplier.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            textBox2.Text = sp.companyName;
            textBox3.Text = sp.supplierNameSurname;
            textBox4.Text = sp.address;
            maskedTextBox1.Text = sp.gsm;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Girdileri temizle butonu
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
        }
    }
}
