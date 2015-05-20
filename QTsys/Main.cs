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
using QTsys.Common.Constants;

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

        private void CheckLoginStatus()
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
            else
            {
                Rights right = Utils.MapRightsToRole(token.Role);
                SetButtonStatus(right);
            }
        }

        private void SetButtonStatus(Rights right)
        {
            if ((right & Rights.EMPLOYEE) == Rights.EMPLOYEE)
            {
                button员工管理.Visible = true;
                button预警统计.Visible = true;
                button批处理.Visible = true;
            }
            else
            {
                button员工管理.Visible = false;
                button预警统计.Visible = false;
                button批处理.Visible = false;
            }

            if ((right & Rights.CUSTOMER) == Rights.CUSTOMER)
            {
                button客户管理.Visible = true;
            }
            else
            {
                button客户管理.Visible = false;
            }

            if ((right & Rights.SALES) == Rights.SALES)
            {
                button订单管理.Visible = true;
                button新增订单.Visible = true;
                button销售管理.Visible = true;
            }
            else
            {
                button订单管理.Visible = false;
                button新增订单.Visible = false;
                button销售管理.Visible = false;
            }

            if ((right & Rights.PRODUCT) == Rights.PRODUCT)
            {
                button产品管理.Visible = true;
                button产品.Visible = true;
            }
            else
            {
                button产品管理.Visible = false;
                button产品.Visible = false; 
            }

            if ((right & Rights.MANUFACTURE) == Rights.MANUFACTURE)
            {
                button生产管理.Visible = true;
            }
            else
            {
                button生产管理.Visible = false;
            }

            if ((right & Rights.REVIEWER) == Rights.REVIEWER)
            {
                button审核.Visible = true;
            }
            else
            {
                button审核.Visible = false;
            }

            if ((right & Rights.STORAGE) == Rights.STORAGE)
            {
                button原料.Visible = true;
                //button产品.Visible = true;
                //button生产管理.Visible = true;
            }
            else
            {
                button原料.Visible = false;
                //button产品.Visible = false;
                //button生产管理.Visible = false;
            }

            if ((right & Rights.FIN) == Rights.FIN)
            {
                button报价.Visible = true;
                // 对账单
            }
            else
            {
                button报价.Visible = false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CheckLoginStatus();
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
           
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ClearLogonToken();
            CheckLoginStatus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            审核 win = new 审核();
            win.ShowDialog();
        }

        private void button批处理_Click(object sender, EventArgs e)
        {
            批量导入 win = new 批量导入();
            win.ShowDialog();
        }

        private void button报价_Click(object sender, EventArgs e)
        {
            报价 win = new 报价();
            win.ShowDialog();
        }
    }
}
