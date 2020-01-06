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
    public partial class Form2 : Form
    {
        Users u= new Users();
        public Form2(Users u)
        {
            InitializeComponent();
            this.u = u;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.MouseEnter += B_CLick;
            button2.MouseEnter += B_CLick;
            button3.MouseEnter += B_CLick;
            button4.MouseEnter += B_CLick;
            button5.MouseEnter += B_CLick;
            button6.MouseEnter += B_CLick;
            button7.MouseEnter += B_CLick;
            button8.MouseEnter += B_CLick;

            button1.MouseLeave += B_CLick2;
            button2.MouseLeave += B_CLick2;
            button3.MouseLeave += B_CLick2;
            button4.MouseLeave += B_CLick2;
            button5.MouseLeave += B_CLick2;
            button6.MouseLeave += B_CLick2;
            button7.MouseLeave += B_CLick2;
            button8.MouseLeave += B_CLick2;

        }

        private void B_CLick2(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.White;
        }


        private void B_CLick(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.DarkRed;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashierForm kf = new CashierForm();
            kf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerForm cmf = new CustomerForm();
            cmf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SupplierForm spf = new SupplierForm();
            spf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm pf = new ProductForm();
            pf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CategoryForm cf = new CategoryForm();
            cf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockForm sf = new StockForm();
            sf.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReportForm rpf = new ReportForm();
            rpf.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
