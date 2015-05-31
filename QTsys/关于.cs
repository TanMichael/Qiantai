using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTsys
{
    public partial class 关于 : Form
    {
        public 关于()
        {
            InitializeComponent();
        }
        string[] textstr = new string[] { "软件声明\n\r", "本软件起始于2015年4月3日，专为乔泰公司设计!\n\r", "设计师：\n\r", "谭伟华  18501700734\n\r", "赵鲁泉  18175825295\n\r", "", "", "", "", "" };
        private void 关于_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            this.Opacity = 0.1;
            for (int i = 0; i < 9; i++)
            {

                this.Opacity += 0.1;
                Delay(100);
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            for (int i = 0; i < 9; i++)
            {
                richTextBox1.Text += textstr[i];
                // this.Opacity += 0.1;
                Delay(300);
            }
            for (int i = 0; i < 9; i++)
            {

                this.Opacity -= 0.1;
                Delay(100);
            }
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }



        public static bool Delay(int delayTime)//延时函数
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Milliseconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }
    }
}
