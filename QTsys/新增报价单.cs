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
    public partial class 新增报价单 : Form
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
        private List<string> listNew = new List<string>();
        private List<string> listtemp = new List<string>();

        public 新增报价单()
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
                dataGridView报价单.Rows[selectorder].Cells["折扣"].Value = text折扣.Text;
                dataGridView报价单.Rows[selectorder].Cells["成交价"].Value = Convert.ToDecimal(dataGridView报价单.Rows[selectorder].Cells["折扣"].Value.ToString()) * Convert.ToDecimal(dataGridView报价单.Rows[selectorder].Cells["单价"].Value.ToString());
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

        private void 新增报价单_Load(object sender, EventArgs e)
        {
            try
            {
                checkBoxHistory.Checked = false;
                label1备注.Text = "";
                dataGridView1.DataSource = this.pm.GetAllProducts();
                dataGridView1.Update();


                com客户名.Items.Clear();
                customers = userMgr.GetAllCustomerList();
              //  customers.Insert(0, new Customer() { Id = "-9999", Name = "" });
                //use dataSource make selectedValue works;
                com客户名.DisplayMember = "Name";
                com客户名.ValueMember = "Id";
               //com客户名.DataSource = customers;
                com客户名.Items.AddRange(customers.ToArray());
                //初始化temp数据
                listNew.Clear();
                listtemp.Clear();
                foreach (var item in customers)
                {
                    if (item.Name.Contains(this.com客户名.Text))
                    {
                        listNew.Add(item.Name);
                        listtemp.Add(item.Id);
                    }
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        public void addNewList()
        {
            /*if (!pm.TestPMreltionExist(dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString()))
            {
                MessageBox.Show("该产品未建立产品原料关系，不能加入订单！");
                return;
            }*/
          //  double selectedPrice = Convert.ToDouble(dataGridView1.Rows[selectpro].Cells["单价"].Value);
            /*if (selectedPrice == 0d)
            {
                check样品.Checked = true;
                check样品.Enabled = false;
                MessageBox.Show("有没有单价的产品被添加，该订单只能是样品订单。");
            }*/
            string[] rowadd = new string[]
            { 
                dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["规格"].Value.ToString(),
                //selectedPrice.ToString(),
                dataGridView1.Rows[selectpro].Cells["材质"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["变位"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["单价"].Value.ToString(),
                dataGridView1.Rows[selectpro].Cells["备注"].Value.ToString()
            };
            bool ins = true;
            for (int i = 0; i < dataGridView报价单.Rows.Count; i++)
            {
                if (dataGridView报价单.Rows[i].Cells["产品编号"].Value.ToString() == dataGridView1.Rows[selectpro].Cells["产品编号"].Value.ToString())
                {
                    MessageBox.Show("[" + dataGridView1.Rows[selectpro].Cells["产品名称"].Value.ToString() + "]已经被添加，请选择新产品！");
                    ins = false;
                    break;
                }
            }
            if (ins == true)
            {
                dataGridView报价单.Rows.Add(rowadd);
            }
          // numericUpDown1.Value = 1;
            //text折扣.Text = "1";
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
                dataGridView报价单.Rows[selectorder].Cells["数量"].Value = numericUpDown1.Value;
                dataGridView报价单.Rows[selectorder].Cells["成交价"].Value = Convert.ToDecimal(dataGridView报价单.Rows[selectorder].Cells["单价"].Value) * Convert.ToDecimal(dataGridView报价单.Rows[selectorder].Cells["折扣"].Value);
                CalMoney();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }



        public void CalMoney()
        {
            //实时计算整个订单总金额
           /* decimal money = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                money += Convert.ToDecimal(dataGridView2.Rows[i].Cells["数量"].Value) * Convert.ToDecimal(dataGridView2.Rows[i].Cells["成交价"].Value);
            }
            textBox总金额.Text = money.ToString();*/
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectorder = e.RowIndex;
                textBox备注.Text = dataGridView报价单.Rows[e.RowIndex].Cells["备注"].Value.ToString();
                textBox单价.Text = dataGridView报价单.Rows[e.RowIndex].Cells["单价"].Value.ToString();
            }
            catch (Exception ex) { };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView报价单.Rows.Remove(dataGridView报价单.CurrentRow);

                bool containsSample = false;
                for (int i = 0; i < dataGridView报价单.Rows.Count; i++)
                {
                    var price = Convert.ToDouble(dataGridView报价单.Rows[i].Cells["单价"].Value);
                    if (price == 0d)
                    {
                        containsSample = true;
                    }
                }

                if (!containsSample)
                {
                    check样品.Checked = false;
                    check样品.Enabled = true;
                }
            }
            catch (Exception ex) { };
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
                if(com客户名.SelectedIndex<=0)
                {
                    return;
                }
              //  MessageBox.Show(com客户名.SelectedIndex.ToString());
                selectedCustomerId=listtemp[com客户名.SelectedIndex];
                DataTable dt = new DataTable();;
                dt = userMgr.SearchCustomerByCol("客户编号", selectedCustomerId);
                l编号.Text = dt.Rows[0]["客户编号"].ToString();
                com客户联系人.Text = dt.Rows[0]["默认联系人"].ToString();
                text联系电话.Text = dt.Rows[0]["联系电话"].ToString();
                text收货地址.Text = dt.Rows[0]["地址"].ToString();
                com结算方式.Text = dt.Rows[0]["结算方式"].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void com客户联系人_DropDown(object sender, EventArgs e)
        {
            CustomerMember[] result = new CustomerMember[] { };
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addNewList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label搜索列.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
        }

        private void textBox单价_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView报价单.Rows[selectorder].Cells["单价"].Value = textBox单价.Text;
               // dataGridView2.Rows[selectorder].Cells["备注"].Value = textBox备注.Text;
            }
            catch (Exception ex) { };
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //打印
            try
            {   
                打印报价单 win = new 打印报价单(this,GetDgvToTable(dataGridView报价单),Convert.ToInt16(textBox分页数量.Text));
                win.ShowDialog();
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void textBox备注_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // dataGridView2.Rows[selectorder].Cells["单价"].Value = textBox单价.Text;
                dataGridView报价单.Rows[selectorder].Cells["备注"].Value = textBox备注.Text;
            }
            catch (Exception ex) { };
        }

        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void com客户名_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                this.com客户名.Items.Clear();
                listNew.Clear();
                listtemp.Clear();
                foreach (var item in customers)
                {
                    if (item.Name.Contains(this.com客户名.Text))
                    {
                        listNew.Add(item.Name);
                        listtemp.Add(item.Id);
                    }
                }
                this.com客户名.Items.AddRange(listNew.ToArray());
                this.com客户名.SelectionStart = this.com客户名.Text.Length;
                Cursor = Cursors.Default;
                this.com客户名.DroppedDown = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

    }
}
