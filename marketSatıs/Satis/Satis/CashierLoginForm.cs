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
    public partial class CashierLoginForm : Form
    {
        Button b;
        Button urun;
        Users us;
        List<Category> temp = HelperCategory.GetList();
        Customer customer;
        List<ProductModel> productModels;
        List<Product> p=new List<Product>();
        int j = 0;
        List<List<string>> receipt = new List<List<string>>();
        OrderDetail ord;
       
        public CashierLoginForm()
        {
            InitializeComponent();
        }
        public CashierLoginForm(Users _us)
        {
            InitializeComponent();
            this.us = _us;
            label3.Text = us.userName;
        }
        private void CashierLoginForm_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            label1.Visible = false;
            button2.Enabled = false;
            button4.Enabled = false;
            int sayi = 0;
            List<string> temp2 = new List<string>();
            foreach (var item in temp)
            {
                if (item.IsActive==true)
                {
                    temp2.Add(item.categoryName);
                }
            }
            sayi = temp2.Count;
            
            for (int i = 0; i < sayi; i++)
            {
                b = new Button();
                b.Size = new Size(110, 60);
                b.Text = temp2[i];
                b.BackColor = Color.Red;
                b.MouseEnter += B_Click;
                b.MouseLeave += B_Click2;
                flowLayoutPanel1.Controls.Add(b);
                b.Click += B_UrunGetir;
            }
        }

        private void B_UrunGetir(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            List<ProductModel> products = HelperProduct.GetListByCategoryName((sender as Button).Text);
            int urunsayi = 0;
            List<string> temp3 = new List<string>();
            foreach (var item in products)
            {
                int stock = HelperStock.GetStockByProductID(item.productID);
                if (item.IsActive==true)
                {
                    if (item.discontinued==false)
                    {
                        if (item.stock > 0)
                        {
                            temp3.Add(item.productName);
                        }
                    }
                }
            }
            urunsayi = temp3.Count;
            for (int i = 0; i < urunsayi; i++)
            {
                urun = new Button();
                urun.Size = new Size(100, 50);
                urun.Text = temp3[i];
                urun.BackColor = Color.Cyan;
                urun.MouseEnter += Urun_Click;
                urun.MouseLeave += Urun_Click2;
                flowLayoutPanel2.Controls.Add(urun);
                urun.Click += Urun_SipariseEkle;
            }
        }

        private void Urun_SipariseEkle(object sender, EventArgs e)
        {
             productModels= HelperProduct.GetListByProductname((sender as Button).Text);
        }

        private void Urun_Click2(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Cyan;
        }

        private void Urun_Click(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Red;
        }

        private void B_Click2(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Red;
        }

        private void B_Click(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Cyan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Müşteri seç butonu form açılma kısmı
            CustomerSearchForm csf = new CustomerSearchForm();
            csf.Show();
            button2.Enabled = true;
        }
        public void GetCustomer(Customer cm)
        {
            this.customer = cm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Satışı tamamla butonu
            //toplam tutar hesapla
            int totalPrice = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalPrice += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            label1.Text = totalPrice.ToString();

            Cashier cashier = HelperCashier.GetByName(label3.Text);
            customer = HelperCustomer.GetByID(customer.CustomerID);
            Order or = new Order()
            {
                customerID = customer.CustomerID,
                orderDate = DateTime.Now,
                cashierID = cashier.cashierID,
                totalPrice = Convert.ToInt32(label1.Text),
            };
            var ekle = HelperOrder.CUD(or, System.Data.Entity.EntityState.Added);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                p.Add(HelperProduct.GetByID(Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value)));
            }
            int k = 0;
            foreach (var item in p)
            {
                for (; k < dataGridView1.Rows.Count;)
                {
                    item.stock -= Convert.ToInt32(dataGridView1.Rows[k].Cells[4].Value);
                    var a = HelperProduct.CUD(item, System.Data.Entity.EntityState.Modified);
                    break;
                }
                k++;
            }
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //fiş için yapılanlar
                List<string> temp = new List<string>();
                string ad = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string id = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string birimFiyat = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string indirim = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string adet = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string tutar = dataGridView1.Rows[i].Cells[5].Value.ToString();
                temp.Add(ad);
                temp.Add(id);
                temp.Add(birimFiyat);
                temp.Add(indirim);
                temp.Add(adet);
                temp.Add(tutar);
                receipt.Add(temp);
            }
                foreach (var item in p)
                {
                    ord = new OrderDetail();

                    ord.orderID = or.orderID;
                    ord.productID = item.productID;
                    ord.unitPrice = item.unitPrice;
                for (; j < dataGridView1.Rows.Count; j++)
                {
                    ord.count = Convert.ToInt32(dataGridView1.Rows[j].Cells[4].Value);
                    break;
                }
                j++;

                var ekle2 = HelperOrderDetail.CUD(ord, System.Data.Entity.EntityState.Added);
                }
            
            ReceiptForm rpf = new ReceiptForm(receipt, customer, label1.Text);
            rpf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ürünü siparişlere ekleme butonu
            int adet = Convert.ToInt32(textBox1.Text);
            foreach (var item in productModels)
            {
                double tutar = (item.unitPrice - (item.unitPrice * (item.discount / 100.0)))*adet;
                if (item.stock<adet)
                {
                    MessageBox.Show($"Yeterli stok bulunamadı.Stokta {item.stock} tane ürün var.");
                }
                else
                {
                    dataGridView1.Rows.Add(item.productName, item.productID, item.unitPrice, item.discount, adet, tutar);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Seçilen ürünü çıkar butonu
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
    }
}
