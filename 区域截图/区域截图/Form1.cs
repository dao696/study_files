using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 区域截图
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;
        int w = Screen.PrimaryScreen.Bounds.Width;
        int h = Screen.PrimaryScreen.Bounds.Height;

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Thread.Sleep(100);
            i += 1;

            Bitmap b = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(b);
            g.CopyFromScreen(0, 0, 0, 0, new Size(w, h));
            b.Save("C:/Users/dao/Desktop/" + i + ".jpg");

            WindowState = FormWindowState.Normal;

            Clipboard.SetImage(b);//复制图片到剪切板
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
