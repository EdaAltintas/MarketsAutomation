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
    
    public partial class Form1 : Form
    {
        string userName, pass = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = textBox1.Text.Trim();
            pass = textBox2.Text.Trim();
            var u = HelperUsers.GetByName(userName);
            if (u == null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış");
            }
            else
            {
                if (u.userName == userName && u.password == pass)
                {
                    if (u.userType==1)
                    {
                        Form2 frm2 = new Form2(u);
                        frm2.Show();
                    }
                    else
                    {
                        CashierLoginForm clf = new CashierLoginForm(u);
                        clf.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                }
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
