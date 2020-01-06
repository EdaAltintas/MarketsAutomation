using Satis.DAL;
using Satis.Entity;
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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ürün ekleme butonu
            if (!String.IsNullOrEmpty(textBox2.Text)&& !String.IsNullOrEmpty(textBox3.Text)&& !String.IsNullOrEmpty(textBox4.Text))
            {
                if (!HelperProduct.SearchProductName(textBox2.Text))
                {
                    MessageBox.Show("Aynı ürün adı mevcut. Lütfen ürün adını değiştiriniz.");
                }
                else
                {
                    Product p = new Product()
                    {
                        productName = textBox2.Text,
                        categoryID = Convert.ToInt32(comboBox3.SelectedValue),
                        supplierID = Convert.ToInt32(comboBox2.SelectedValue),
                        unitPrice = Convert.ToDouble(textBox3.Text),
                        discount = Convert.ToInt32(textBox4.Text),
                        discontinued = false,
                        dateOfAdded = DateTime.Now,
                        stock = 0,
                        IsActive = true
                    };
                    var ekle = HelperProduct.CUD(p, System.Data.Entity.EntityState.Added);
                    if (ekle.Item2)
                    {
                        MessageBox.Show("Ürün ekleme başarılı.");
                    }
                    else
                    {
                        MessageBox.Show("Ürün eklenemedi");
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
        }
        public void Yenile()
        {
            dataGridView1.Rows.Clear();
            List<ProductModel> productmodel = HelperProduct.GetProductModelList();
            foreach (var item in productmodel)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.productID, item.productName,item.Supplier.companyName, item.category.categoryName, item.unitPrice,item.discount, item.dateOfAdded,item.stock, item.stringDiscounted);
                }
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Ürün Ad");
            comboBox1.Items.Add("Satıcı şirket Ad");
            comboBox1.Items.Add("Kategori Ad");
            Yenile();
            var ff = HelperCategory.GetList();
            List<Category> temp = new List<Category>();
            foreach (var item in ff)
            {
                if (item.IsActive==true)
                {
                    temp.Add(item);
                }
            }
            comboBox3.DataSource = temp;
            comboBox3.ValueMember = "categoryID";
            comboBox3.DisplayMember = "categoryName";

            var gg = HelperSupplier.GetList();
            List<Supplier> temp2 = new List<Supplier>();
            foreach (var item in gg)
            {
                if (item.IsActive == true)
                {
                    temp2.Add(item);
                }
            }
            comboBox2.DataSource = temp2;
            comboBox2.ValueMember = "supplierID";
            comboBox2.DisplayMember = "companyName";
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            button6.Enabled = false;
            button7.Enabled = false;
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            //girdileri temizle butonu
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //satışı durdur butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                Product p = HelperProduct.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                p.discontinued = true;

                var degistir = HelperProduct.CUD(p, System.Data.Entity.EntityState.Modified);
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
                MessageBox.Show("Lütfen seçim yapınız.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ürün silme butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    Product p = HelperProduct.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                    p.IsActive = false;
                    var b = HelperProduct.CUD(p, System.Data.Entity.EntityState.Modified);
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
                MessageBox.Show("Lütfen silinecek ürünü seçiniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Ürün düzenle butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                Product p = HelperProduct.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                p.productName = textBox2.Text;
                p.unitPrice = Convert.ToDouble(textBox3.Text);
                p.supplierID = Convert.ToInt32(comboBox2.SelectedValue);
                p.categoryID = Convert.ToInt32(comboBox3.SelectedValue);
                p.discount = Convert.ToInt32(textBox4.Text);
                var degistir = HelperProduct.CUD(p, System.Data.Entity.EntityState.Modified);
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
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            Product p = HelperProduct.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            Category c = HelperCategory.GetByID(p.categoryID);
            Supplier s = HelperSupplier.GetByID(p.supplierID);
            textBox2.Text = p.productName;
            textBox3.Text = p.unitPrice.ToString();
            textBox4.Text = p.discount.ToString();
            comboBox2.Text = s.companyName;
            comboBox3.Text =c.categoryName;
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Satışı devam ettir
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                Product p = HelperProduct.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                p.discontinued = false;

                var degistir = HelperProduct.CUD(p, System.Data.Entity.EntityState.Modified);
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
                MessageBox.Show("Lütfen seçim yapınız.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Arama Butonu
            dataGridView1.Rows.Clear();
            List<ProductModel> pm = new List<ProductModel>();
            if (comboBox1.SelectedIndex == 0)
            {
                pm= HelperProduct.GetListByProductname(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                pm = HelperProduct.GetListByCompanyName(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                pm= HelperProduct.GetListByCategoryName(textBox1.Text);
            }

            foreach (var item in pm)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.productID, item.productName, item.Supplier.companyName, item.category.categoryName,item.unitPrice,item.discount, item.dateOfAdded, item.stock ,item.stringDiscounted);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
