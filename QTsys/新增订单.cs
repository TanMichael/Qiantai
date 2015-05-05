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
                checkBoxHistory.Checked = false;

                dataGridView1.DataSource = this.pm.GetAllProducts();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] rowadd = new string[] { dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString(), dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString(), "0", dataGridView1.Rows[selectpro].Cells["单价"].Value.ToString(), "1", "0" };
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
                com客户联系人.Text = dt.Rows[0]["默认联系人"].ToString();
                text联系电话.Text = dt.Rows[0]["联系电话"].ToString();
                text收货地址.Text = dt.Rows[0]["地址"].ToString();
                com结算方式.Text = dt.Rows[0]["结算方式"].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void com客户联系人_DragDrop(object sender, EventArgs e)
        {
            com客户联系人.Items.Clear();
            cm = userMgr.GetAllCustomerMemberList();
            com客户联系人.Items.AddRange(customers.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool right = false;//生成订单成功与否
            try
            {
                Order od = new Order();
                OrderDetail odd = new OrderDetail();
                string id = Convert.ToString((Convert.ToInt16(odm.GetAutoNum().ToString()) + 1));
                od.OrderId = id;
                od.CreateTime = System.DateTime.Now;
                od.DeliverTime = DateTime.Now;
                od.LastUpdateTime = DateTime.Now;
                od.OrderStatus = "已订";
                od.ExpressNO = "";
                od.DepositMode = com结算方式.Text;
                od.RecieverAddress = text收货地址.Text;
                od.RecieverName = com客户联系人.Text;
                od.RecieverPhone = text联系电话.Text;
                od.Creator = "";
                //插入order
                if (this.odm.AddNewOrder(od))
                {
                    right = true;
                    
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        odd.Count = Convert.ToInt16(dataGridView2.Rows[i].Cells["数量"].Value.ToString());
                        odd.Price = Convert.ToDouble(dataGridView2.Rows[i].Cells["单价"].Value.ToString());
                        odd.Discount = Convert.ToDouble(dataGridView2.Rows[i].Cells["折扣"].Value.ToString());
                        odd.RealPrice = Convert.ToDouble(dataGridView2.Rows[i].Cells["成交价"].Value.ToString());
                        odd.OrderId = id;
                        odd.ProductId = dataGridView2.Rows[i].Cells["产品编号"].Value.ToString();
                        //if (check库存.Checked == true)
                        //    odd.IsStorage = "是";
                        //else
                        //    odd.IsStorage = "否";
                        //插入订单编号
                        if (this.odm.AddNewOrderDetail(odd))
                        {
                            right = true;
                        }
                        else
                        {
                            MessageBox.Show("订单建立异常！订单建立失败！");
                            right = false;
                            break;
                        }
                    }
                    //订单生产成功后，对订单后续操作
                    if (right == true)
                    {
                        MessageBox.Show("订单建立成功！");
                        /* if (check样品.Checked == true)//生产样品
                         {
                             if (MessageBox.Show("是否自动生成样品制造清单?", "样品制造", MessageBoxButtons.OKCancel) == DialogResult.OK)
                             {
                                 MessageBox.Show("样品制造ing");
                             }
                         }
                         if (check库存.Checked == true)//优先使用库存
                         {
                             if (MessageBox.Show("是否减少库存?", "库存清理", MessageBoxButtons.OKCancel) == DialogResult.OK)
                             {
                                 MessageBox.Show("减少库存ing");
                             }
                             else
                             {
                                 if (MessageBox.Show("是否自动生产计划?", "生产计划", MessageBoxButtons.OKCancel) == DialogResult.OK)
                                 {
                                     MessageBox.Show("生产计划");
                                 }
                             }
                         }*/
                        WinSendMsg.IsSampleProduct = check样品.Checked;
                        //WinSendMsg.IsMeterialReduce = check库存.Checked;
                        WinSendMsg.row = dataGridView2.Rows.Count;
                        WinSendMsg.Oid = id;
                        样品库存自动生成 win = new 样品库存自动生成(Convert.ToInt16(id));
                        win.ShowDialog();
                    }
                    else
                        MessageBox.Show("订单建立失败！");
                }
            }
            catch (Exception ex) { MessageBox.Show("订单 建立 失败！"); }
        }

        private void checkBoxHistory_CheckedChanged(object sender, EventArgs e)
        {
            var oCustomer = com客户名.SelectedItem;

            if (oCustomer != null && checkBoxHistory.Checked == true)
            {
                string customerId = ((Customer)oCustomer).Id;
                dataGridView1.DataSource = this.pm.GetProductsWithCustomer(customerId);
                dataGridView1.Update();
            }
            else
            {
                dataGridView1.DataSource = this.pm.GetAllProducts();
                dataGridView1.Update();
            }
        }

        private void button新产品_Click(object sender, EventArgs e)
        {
            添加产品 form = new 添加产品();
            form.ShowDialog();
        }

    }
}
