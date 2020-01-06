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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kategori Ekleme Butonu
            if (!String.IsNullOrEmpty(textBox2.Text)&& !String.IsNullOrEmpty(textBox3.Text))
            {
                if (!HelperCategory.SearchCategoryName(textBox2.Text))
                {
                    MessageBox.Show("Aynı kategori adı mevcut. Lütfen kategori adını değiştiriniz.");
                }
                else
                {
                    Category cg = new Category()
                    {
                        categoryName = textBox2.Text,
                        Description = textBox3.Text,
                        IsActive = true
                    };
                    var ekle = HelperCategory.CUD(cg, System.Data.Entity.EntityState.Added);
                    if (ekle.Item2)
                    {
                        MessageBox.Show("Kategori ekleme başarılı.");
                    }
                    else
                    {
                        MessageBox.Show("Kategori eklenemedi");
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
        }
        public void Yenile()
        {
            dataGridView1.Rows.Clear();
            List<Category> categories = HelperCategory.GetList();
            foreach (var item in categories)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.categoryID, item.categoryName, item.Description);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Kategori Düzenleme Butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                Category cg = HelperCategory.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                cg.categoryName = textBox2.Text;
                cg.Description = textBox3.Text;
                var degistir = HelperCategory.CUD(cg, System.Data.Entity.EntityState.Modified);
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kategori Silme Butonu
            if (!String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {
                    Category cg = HelperCategory.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                    cg.IsActive = false;
                    var b = HelperCategory.CUD(cg, System.Data.Entity.EntityState.Modified);
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
                MessageBox.Show("Lütfen silinecek kategoriyi seçiniz.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Girdileri temizle butonu
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kategori Arama Butonu
            dataGridView1.Rows.Clear();
            List<Category> cg = new List<Category>();
            if (comboBox1.SelectedIndex == 0)
            {
                cg = HelperCategory.GetListByCategoryName(textBox1.Text);
            }
            foreach (var item in cg)
            {
                if (item.IsActive == true)
                {
                    dataGridView1.Rows.Add(item.categoryID, item.categoryName, item.Description);
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            Yenile();
            comboBox1.Items.Add("Kategori Adı");
            textBox2.Clear();
            textBox3.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            Category cg = HelperCategory.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            textBox2.Text = cg.categoryName;
            textBox3.Text = cg.Description;
        }
    }
}
