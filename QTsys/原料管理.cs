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
    public partial class 原料管理 : Form
    {
        public 原料管理()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            原料入仓 win = new 原料入仓();
            win.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            原料出仓 win = new 原料出仓();
            win.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            原料数据修改 win = new 原料数据修改();
            win.ShowDialog();
        }
    }
}
