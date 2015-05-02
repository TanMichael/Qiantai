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
using QTsys.DataObjects;
using QTsys.DAO;
using QTsys.Manager;

namespace QTsys
{
    public partial class 新增订单 : Form
    {
        private OrderManager odm;
        private UserManager userMgr;
        private ProductionManager pm;
        private int selectorder;
        private int selectpro;
        private List<Customer> customers;
        private List<CustomerMember> cm;

        public 新增订单()
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
            pm = new ProductionManager();
            selectorder = 0;
            selectpro = 0;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows[selectorder].Cells["折扣"].Value = text折扣.Text;
                dataGridView2.Rows[selectorder].Cells["成交价"].Value = Convert.ToDecimal(dataGridView2.Rows[selectorder].Cells["单价"].Value) * Convert.ToDecimal(dataGridView2.Rows[selectorder].Cells["折扣"].Value);
                CalMoney();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void 新增订单_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.pm.GetAllProducts();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] rowadd = new string[] { dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString(), dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString(), "0", dataGridView1.Rows[selectpro].Cells["单价"].Value.ToString(), "0", "0" };
            dataGridView2.Rows.Add(rowadd);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectpro = e.RowIndex;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows[selectorder].Cells["数量"].Value = numericUpDown1.Value;
                dataGridView2.Rows[selectorder].Cells["成交价"].Value = Convert.ToDecimal(dataGridView2.Rows[selectorder].Cells["单价"].Value) * Convert.ToDecimal(dataGridView2.Rows[selectorder].Cells["折扣"].Value);
                CalMoney();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        public void CalMoney()
        {
            //实时计算整个订单总金额
            decimal money = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                money += Convert.ToDecimal(dataGridView2.Rows[i].Cells["数量"].Value) * Convert.ToDecimal(dataGridView2.Rows[i].Cells["成交价"].Value);
            }
            textBox总金额.Text = money.ToString();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectorder = e.RowIndex;
            numericUpDown1.Value = Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells["数量"].Value.ToString());
            text折扣.Text = dataGridView2.Rows[e.RowIndex].Cells["折扣"].Value.ToString();
            CalMoney();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox产品名称搜索.Text != "")
                {
                    dataGridView1.DataSource = this.pm.GetAllProductsByName("产品名称", textBox产品名称搜索.Text);
                dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.pm.GetAllProducts();
                    dataGridView1.Update();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            com客户名.Items.Clear();
            // 初始化客户信息
            customers = userMgr.GetAllCustomerList();
            com客户名.Items.AddRange(customers.ToArray());
            com客户名.DisplayMember = "Name";
            com客户名.ValueMember = "Id";
           // com客户名.
            //--------------------------------------
        }

        private void com客户名_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //com客户联系人
                DataTable dt = new DataTable();
                // MessageBox.Show(customers[com客户名.SelectedIndex].Id);
                dt = userMgr.SearchCustomerByCol("客户编号", customers[com客户名.SelectedIndex].Id);
                text联系电话.Text = dt.Rows[0][3].ToString();
                text收货地址.Text = dt.Rows[0][2].ToString();
                text订金方式.Text = dt.Rows[0][6].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void com客户联系人_DragDrop(object sender, DragEventArgs e)
        {
            com客户联系人.Items.Clear();
            cm = userMgr.GetAllCustomerMemberList();
            com客户联系人.Items.AddRange(customers.ToArray());
        }
    }
}
