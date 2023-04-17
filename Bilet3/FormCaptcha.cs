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
    public partial class FormCaptcha : Form
    {
        public FormCaptcha()
        {
            InitializeComponent();
        }

        private Bitmap CreateImage(int Width, int Heighr)
        {
            Random rnd = new Random();
            Bitmap result = new Bitmap(Width, Heighr);

            int Xpos = 10;
            int Ypos = 10;

            Brush[] colors = {
            Brushes.Black,
            Brushes.Red,
            Brushes.RoyalBlue,
            Brushes.Green,
            Brushes.Yellow,
            Brushes.White,
            Brushes.Tomato,
            Brushes.Sienna,
            Brushes.Pink };

            Pen[] colopens = {
            Pens.Black,
            Pens.Red,
            Pens.RoyalBlue,
            Pens.Green,
            Pens.Yellow,
            Pens.White,
            Pens.Tomato,
            Pens.Sienna,
            Pens.Pink };

            FontStyle[] fontstyle = {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Regular,
            FontStyle.Strikeout,
            FontStyle.Underline };

            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            Graphics g = Graphics.FromImage((Image)result);
            g.Clear(Color.Gray);

            g.RotateTransform(rnd.Next(rotate.Length));
            Text = String.Empty;
            String ALF = "7890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; i++)
                Text += ALF[rnd.Next(ALF.Length)];

            g.DrawString(Text, new Font("Arial", 25, fontstyle[rnd.Next(fontstyle.Length)]),
            colors[rnd.Next(colors.Length)], new PointF(Xpos, Ypos));

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.Text)
            {
                MessageBox.Show("Капча введена верно!", "Отлично!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неудачная попытка!");
                Application.Exit();
            }
        }

        private void FormCaptcha_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
