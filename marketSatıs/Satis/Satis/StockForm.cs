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
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Stok ekle Butonu
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                Product p = HelperProduct.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                p.stock += Convert.ToInt32(textBox2.Text);
                var degistir = HelperProduct.CUD(p, System.Data.Entity.EntityState.Modified);
                Stock s = new Stock()
                {
                    productID = p.productID,
                    dateOfAdded = DateTime.Now,
                    count = Convert.ToInt32(textBox2.Text)
                };
                var ekle = HelperStock.CUD(s, System.Data.Entity.EntityState.Added);
                if (ekle.Item2)
                {
                    MessageBox.Show("Stok ekleme başarılı.");
                }
                else
                {
                    MessageBox.Show("Stok eklenemedi");
                }
                Yenile();
                DataGrid2Yenile();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen adet giriniz.");
            }
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            DataGrid2Yenile();
            button2.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Items.Add("Ürün Ad");
            comboBox1.Items.Add("Satıcı şirket Ad");
            comboBox1.Items.Add("Kategori Ad");
            comboBox2.Items.Add("Ürün Ad");
            Yenile();
        }
        public void Yenile()
        {
            dataGridView1.Rows.Clear();
            List<ProductModel> productmodel = HelperProduct.GetProductModelList();
            foreach (var item in productmodel)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.productID, item.productName, item.Supplier.companyName, item.category.categoryName, item.unitPrice, item.dateOfAdded,item.stock, item.stringDiscounted);
                }
            }
        }

        public void DataGrid2Yenile()
        {
            dataGridView2.Rows.Clear();
            List<Product> prlst = HelperProduct.GetList();
            foreach (var item in prlst)
            {
                if (item.stock>0)
                {
                    dataGridView2.Rows.Add(item.productName, item.stock);
                }
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ürün seç butonu
            button2.Enabled = true;
            textBox2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Stok Arama butonu
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Add("column11", "kayıt tarih");
            List<StockModel> pm = new List<StockModel>();
            if (comboBox2.SelectedIndex == 0)
            {
                pm = HelperStock.GetListByProductName(textBox3.Text);
            }
            foreach (var item in pm)
            {
                    dataGridView2.Rows.Add(item.product.productName,item.count,item.dateOfAdded);
            }
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stok eklemek için ürün arama butonu
            dataGridView1.Rows.Clear();
            List<ProductModel> pm = new List<ProductModel>();
            if (comboBox1.SelectedIndex == 0)
            {
                pm = HelperProduct.GetListByProductname(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                pm = HelperProduct.GetListByCompanyName(textBox1.Text);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                pm = HelperProduct.GetListByCategoryName(textBox1.Text);
            }

            foreach (var item in pm)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.productID, item.productName, item.Supplier.companyName, item.category.categoryName, item.unitPrice, item.dateOfAdded, item.stringDiscounted);
                }
            }
            textBox1.Clear();
        }
    }
}
