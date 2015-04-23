﻿using System;
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

        private void Main_Load(object sender, EventArgs e)
        {
            //弹出登录对话框
            Login win = new Login();
            win.ShowDialog();
            //读取是否成功登录
            StreamReader rd2 = new StreamReader(Directory.GetCurrentDirectory() + "\\login.txt", Encoding.GetEncoding("unicode"));
            string log = rd2.ReadToEnd();
            rd2.Close();
            //如果登录失败，直接退出
            if (log != "yes")
            {
                this.Close();
            }
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
            原料管理 win = new 原料管理();
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
    }
}
