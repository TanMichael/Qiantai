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
using QTsys.Common.Constants;

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
        private string selectedCustomerId;
        private List<CustomerMember> cMembers;
        private ProductPlanManager ppm;

        public 新增订单()
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
            pm = new ProductionManager();
            ppm = new ProductPlanManager();
            selectorder = 0;
            selectpro = 0;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows[selectorder].Cells["折扣"].Value = text折扣.Text;
                dataGridView2.Rows[selectorder].Cells["成交价"].Value =  Convert.ToDecimal(dataGridView2.Rows[selectorder].Cells["折扣"].Value.ToString() )* Convert.ToDecimal(dataGridView2.Rows[selectorder].Cells["单价"].Value.ToString());
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


                com客户名.Items.Clear();
                // 初始化客户信息
                customers = userMgr.GetAllCustomerList();
                customers.Insert(0, new Customer() { Id = "-9999", Name = "" });
                //use dataSource make selectedValue works;
                com客户名.DisplayMember = "Name";
                com客户名.ValueMember = "Id";
                com客户名.DataSource = customers;
                //com客户名.Items.AddRange(customers.ToArray());
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        public void addNewList()
        {
            if (!pm.TestPMreltionExist(dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString()))
            {
                MessageBox.Show("该产品未建立产品原料关系，不能加入订单！");
                return;
            }
            double selectedPrice = Convert.ToDouble(dataGridView1.Rows[selectpro].Cells["单价"].Value);
            if (selectedPrice == 0d)
            {
                check样品.Checked = true;
                check样品.Enabled = false;
                MessageBox.Show("有没有单价的产品被添加，该订单只能是样品订单。");
            }
            string[] rowadd = new string[]
            { 
                dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["规格"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["库存数量"].Value.ToString(),
                "1",
                selectedPrice.ToString(),
                "1",
                dataGridView1.Rows[selectpro].Cells["单价"].Value.ToString()
            };
            bool ins = true;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["产品编号"].Value.ToString() == dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString())
                {
                    MessageBox.Show("[" + dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString() + "]已经被添加，请选择新产品！");
                    ins = false;
                    break;
                }
            }
            if (ins == true)
            {
                dataGridView2.Rows.Add(rowadd);
            }
            numericUpDown1.Value = 1;
            text折扣.Text = "1";
            CalMoney();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addNewList();
           
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

            bool containsSample = false;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                var price = Convert.ToDouble(dataGridView2.Rows[i].Cells["单价"].Value);
                if (price == 0d)
                {
                    containsSample = true;
                }


                //if (dataGridView2.Rows[i].Cells["产品编号"].Value.ToString() == dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString())
                //{
                //    MessageBox.Show("[" + dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString() + "]已经被添加，请选择新产品！");
                //    ins = false;
                //    break;
                //}
            }

            if (!containsSample)
            {
                check样品.Checked = false;
                check样品.Enabled = true;
            }
        }

        private void button搜索_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox产品名称搜索.Text != "")
                {
                    string searchField = label搜索列.Text;
                    dataGridView1.DataSource = this.pm.GetAllProductsByName(searchField, textBox产品名称搜索.Text);
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

        private void com客户名_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedCustomerId = com客户名.SelectedValue.ToString();//customers[com客户名.SelectedIndex].Id;
                if (selectedCustomerId == "-9999")
                {
                    return;
                }
                //com客户联系人
                DataTable dt = new DataTable();
                // MessageBox.Show(customers[com客户名.SelectedIndex].Id);
                dt = userMgr.SearchCustomerByCol("客户编号", selectedCustomerId);
               l编号.Text= dt.Rows[0]["客户编号"].ToString();
                com客户联系人.Text = dt.Rows[0]["默认联系人"].ToString();
                text联系电话.Text = dt.Rows[0]["联系电话"].ToString();
                text收货地址.Text = dt.Rows[0]["地址"].ToString();
                com结算方式.Text = dt.Rows[0]["结算方式"].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void com客户联系人_DropDown(object sender, EventArgs e)
        {
            CustomerMember[] result = new CustomerMember[]{};
            com客户联系人.Items.Clear();
            if (selectedCustomerId != "")
            {
                cMembers = userMgr.GetCustomerMembersByCId(selectedCustomerId);
                result = cMembers.ToArray();
            }

            com客户联系人.Items.AddRange(result);
            com客户联系人.DisplayMember = "Name";
            com客户联系人.ValueMember = "Id";
        }


        private void com客户联系人_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update address, phone etc.
            var cMember = (CustomerMember)(com客户联系人.SelectedItem);

            text联系电话.Text = cMember.Phone;
            //text收货地址.Text = cMember.add;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool right = false;//生成订单成功与否
            if (selectedCustomerId == "-9999")
            {
                MessageBox.Show("请选择客户！");
                return;
            }
            if (dataGridView2.Rows.Count<1)
            {
                MessageBox.Show("请选择订单的产品！");
                return;
            }
            try
            {
                Order od = new Order();
                OrderDetail odd = new OrderDetail();
                int id = 0;
                od.CustomerId = selectedCustomerId;
                od.CustomerName=  com客户名.Text;
                od.IsSample = check样品.Checked ? "是" : "否";
                od.CreateTime = DateTime.Now;
                od.DeliverTime = DateTime.Now;  // default null??
                od.LastUpdateTime = DateTime.Now;
                od.OrderStatus = OrderStatus.PENDING;
                od.ExpressNO = "";
                od.DepositMode = com结算方式.Text;
                od.RecieverAddress = text收货地址.Text;
                od.RecieverName = com客户联系人.Text;
                od.RecieverPhone = text联系电话.Text;
                od.Creator = Utils.GetCurrentUsername();
                od.CustomerOrderId = textBox客户订单号.Text;
                //插入order
                id = this.odm.AddNewOrder(od);
                if (id > 0)
                {
                    //   MessageBox.Show("订单建立成功！等订单明细生成...............");//test
                    right = true;
                    // id = odm.GetAutoNum().ToString();
                    int j = dataGridView2.Rows.Count;
                    // MessageBox.Show(j.ToString());
                    for (int i = 0; i < j; i++)
                    {
                        odd.OrderId = id.ToString();
                        odd.ProductId = dataGridView2.Rows[i].Cells["产品编号"].Value.ToString();
                        odd.Count = Convert.ToInt16(dataGridView2.Rows[i].Cells["数量"].Value.ToString());
                        odd.Price = Convert.ToDouble(dataGridView2.Rows[i].Cells["单价"].Value.ToString());
                        odd.Discount = Convert.ToDouble(dataGridView2.Rows[i].Cells["折扣"].Value.ToString());
                        odd.RealPrice = Convert.ToDouble(dataGridView2.Rows[i].Cells["成交价"].Value.ToString());
                        if (!this.odm.AddNewOrderDetail(odd))
                        {
                            MessageBox.Show("订单建立失败!!!");
                            right = false;
                            break;
                        }
                    }
                    //订单生产成功后，对订单后续操作
                    if (right == true)
                    {
                        MessageBox.Show("订单建立成功！待审核中。。。");//test
                        this.Close();
                        //WinSendMsg.IsSampleProduct = check样品.Checked;
                        ////WinSendMsg.IsMeterialReduce = check库存.Checked;
                        //WinSendMsg.row = dataGridView2.Rows.Count;
                        //WinSendMsg.Oid = id.ToString();
                        //ProductionPlan plan = new ProductionPlan();
                        //plan.RelatedOrderId = id.ToString();
                        //plan.ProductId = "";
                        //plan.CustomerId = l编号.Text;
                        //plan.OrderTime = DateTime.Now;
                        //plan.Count = 0;
                        //plan.PlanningTime = DateTime.Now;
                        //plan.FinishTime = DateTime.Now;
                        //if (check样品.Checked == true)
                        //    plan.PlanType = "样品";
                        //else
                        //    plan.PlanType = "正品";
                        //plan.InChargePerson = Utils.GetCurrentUsername();
                        //样品库存自动生成 win = new 样品库存自动生成(plan.PlanType, plan.RelatedOrderId, plan.CustomerId);
                        //win.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("订单建立失败！");
                }

            }
            catch (Exception ex) { MessageBox.Show("订单建立失败！原因是：" + ex.ToString()); }
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

        //private void button新产品_Click(object sender, EventArgs e)
        //{
        //    Product pdt = new Product
        //    {
        //        Name = dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString(),
        //        Standard = dataGridView1.Rows[selectpro].Cells["规格"].Value.ToString(),
        //        Texture = dataGridView1.Rows[selectpro].Cells["材质"].Value.ToString(),
        //        Shift = dataGridView1.Rows[selectpro].Cells["变位"].Value.ToString(),
        //        RealShift = dataGridView1.Rows[selectpro].Cells["实测变位"].Value.ToString(),
        //        Temperate = dataGridView1.Rows[selectpro].Cells["温度"].Value.ToString(),
        //        ElapsedTime = dataGridView1.Rows[selectpro].Cells["生产耗时"].Value.ToString(),
        //        Presure = dataGridView1.Rows[selectpro].Cells["压力"].Value.ToString(),
        //        ResinName = dataGridView1.Rows[selectpro].Cells["树脂名称"].Value.ToString(),
        //        ResinProportion = dataGridView1.Rows[selectpro].Cells["树脂比重"].Value.ToString(),
        //        Soak = dataGridView1.Rows[selectpro].Cells["含浸尺寸"].Value.ToString(),
        //        Outsize = dataGridView1.Rows[selectpro].Cells["外盘"].Value.ToString(),
        //        Jig = dataGridView1.Rows[selectpro].Cells["内治具"].Value.ToString(),
        //        Weight = dataGridView1.Rows[selectpro].Cells["重量"].Value.ToString(),
        //        Formingdie = dataGridView1.Rows[selectpro].Cells["成型模"].Value.ToString(),
        //        ModingNum = dataGridView1.Rows[selectpro].Cells["切模号"].Value.ToString(),
        //        Unit = dataGridView1.Rows[selectpro].Cells["单位"].Value.ToString(),
        //        Price = double.Parse(dataGridView1.Rows[selectpro].Cells["单价"].Value.ToString()),
        //    };
        //    添加产品 form = new 添加产品(pdt, this);
        //    form.ShowDialog();
        //}

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addNewList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label搜索列.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
        }


    }
}
