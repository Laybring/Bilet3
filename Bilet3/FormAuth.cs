using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet3
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 20000;
        }

        int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            

            string login = textBox1.Text;
            string password = textBox2.Text;

            using (ConnectDB db = new ConnectDB())
            {
                DataTable users = db.ExecuteSql($"select * from [USERS] where login = '{login}' and password = '{password}'");

                if (users.Rows.Count > 0)
                {
                    FormMain Main = new FormMain();
                    Main.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль! Проверьте корректность введенных данных.");
                    count++;
                }
                if (count >= 3)
                {
                    this.Enabled = false;
                    timer1.Start();
                    FormCaptcha captcha = new FormCaptcha();
                    captcha.Show();
                }


            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Enabled = true;
            count = 0;
            timer1.Stop();
        }
        
    }
}
