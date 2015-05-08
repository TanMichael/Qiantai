using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTsys.Common;
using QTsys.Manager;
using QTsys.DataObjects;
using System.Diagnostics;
using System.Data.OleDb;
using System.IO;

namespace QTsys
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {

        }

        private void checkLoginStatus()
        {
            //弹出登录对话框
            Login win = new Login();
            win.ShowDialog();
            //读取是否成功登录
            var token = Utils.GetLogonToken();
            toolStripStatusLabel1.Text = token.Role.ToString();
            toolStripStatusLabel3.Text = token.UserName.ToString();
            if (token.Status == false)
            {
                this.Close();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            checkLoginStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            客户管理 win = new 客户管理();
            win.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            员工管理 win = new 员工管理();
            win.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            原料库管理 win = new 原料库管理();
            win.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            产品管理 win = new 产品管理();
            win.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            样品生产 win = new 样品生产();
            win.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            订单管理 win = new 订单管理();
            win.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            生产管理 win = new 生产管理();
            win.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            销售管理 win = new 销售管理();
            win.ShowDialog();
        }

        private void 相关设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            送货单 win = new 送货单();
            win.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            新增订单 win = new 新增订单();
            win.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            产品库管理 win = new 产品库管理();
            win.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关于 win = new 关于();
            win.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            修改密码 win = new 修改密码(toolStripStatusLabel3.Text, toolStripStatusLabel1.Text);
            win.ShowDialog();
        }

        private void 员工数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            批量导入 win = new 批量导入();
            win.ShowDialog();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ClearLogonToken();
            checkLoginStatus();
        }
    }
}
