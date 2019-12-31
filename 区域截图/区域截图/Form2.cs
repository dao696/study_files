using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 区域截图
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        int i = 0;
        Bitmap bit;
        Bitmap bit2;
        Bitmap copy;
        int x;
        int y;
        int xx;
        int yy;
        Pen pen = new Pen(Color.Red, 2);
        Rectangle rect = new Rectangle();
        Graphics g2;

        private void Form2_Load(object sender, EventArgs e)
        {
            i++;
            //Opacity = 0.5;
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.None;

            this.Cursor = Cursors.Cross;

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            bit = new Bitmap(w, h);//获取桌面图
            Graphics g = Graphics.FromImage(bit);//把图画出来
            g.CopyFromScreen(0, 0, 0, 0, new Size(w, h));

            pictureBox1.BackgroundImage = bit;

            bit.Save("C:/Users/dao/Desktop/" + i + ".jpg");
            WindowState = FormWindowState.Maximized;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = Math.Abs(e.X);
            y = Math.Abs(e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xx = Math.Abs(e.X);
                yy = Math.Abs(e.Y);
                Graphics g = pictureBox1.CreateGraphics();
                rect = new Rectangle(x, y, xx - x, yy - y);
                Refresh();
                g.DrawRectangle(pen, rect);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
             try
            {
                copy = (Bitmap)bit.Clone();
                bit2 = new Bitmap(rect.Width, rect.Height);
                g2 = Graphics.FromImage(bit2);
                g2.DrawImage(copy, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
                //g2.DrawImage(copy, 0, 0, rect.Width, rect.Height);
                pictureBox1.Image = bit2;
                bit2.Save("C:/Users/dao/Desktop/区域截图" + i + ".jpg");
                Clipboard.SetImage(bit2);
            }
            catch(Exception )
            {

            }
        }


    }
}
