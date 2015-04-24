using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;
using QTsys.Common;
using QTsys.DataObjects;
using QTsys.DAO;

namespace QTsys
{
    public partial class 客户管理 : Form
    {
        public 客户管理()
        {
            InitializeComponent();
        }

        private void 客户管理_Load(object sender, EventArgs e)
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                dataGridView1.DataSource = cdao.GetAllCustomers();
                dataGridView1.Update();
                dataGridView2.DataSource = cdao.GetAllCustomerMembers();
                dataGridView2.Update();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//单击grid1对数据单元进行读取
        {
            try
            {
                text客户编号.Text = dataGridView1.Rows[e.RowIndex].Cells["客户编号"].Value.ToString();
                text客户名称.Text = dataGridView1.Rows[e.RowIndex].Cells["客户名称"].Value.ToString();
                text客户地址.Text = dataGridView1.Rows[e.RowIndex].Cells["地址"].Value.ToString();
                text联系电话.Text = dataGridView1.Rows[e.RowIndex].Cells["联系电话"].Value.ToString();
                text传真.Text = dataGridView1.Rows[e.RowIndex].Cells["传真"].Value.ToString();
                text电子邮箱.Text = dataGridView1.Rows[e.RowIndex].Cells["电子邮箱"].Value.ToString();
                text结算方式.Text = dataGridView1.Rows[e.RowIndex].Cells["结算方式"].Value.ToString();
                text流水号.Text = dataGridView1.Rows[e.RowIndex].Cells["流水号"].Value.ToString();
                text备注.Text = dataGridView1.Rows[e.RowIndex].Cells["备注"].Value.ToString();
                //联系人信息更新
                CustomerDAO cus = new CustomerDAO();
                dataGridView2.DataSource = cus.GetCustomerMembersByName("所属客户编号", text客户编号.Text);
                dataGridView2.Update();
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label搜索栏目.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
        }

        private void button4_Click(object sender, EventArgs e)//搜索
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                if (textBox搜索内容.Text != "")
                {
                    dataGridView1.DataSource = cdao.GetCustomerByName(label搜索栏目.Text, textBox搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = cdao.GetAllCustomers();
                    dataGridView1.Update();
                }
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)//新增
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                Customer cus = new Customer();
                cus.Id = text客户编号.Text;
                cus.Name = text客户名称.Text;
                cus.Address = text客户地址.Text;
                cus.Phone = text联系电话.Text;
                cus.Fax = text传真.Text;
                cus.Email = text电子邮箱.Text;
                cus.Accounts = text结算方式.Text;
                cus.Serial = text流水号.Text;
                cus.Remarks = text备注.Text;
                if (cdao.AddNewCustomer(cus))
                {
                    MessageBox.Show("客户[" + text客户编号.Text + "]新增成功！");
                    //更新表格数据                    
                    dataGridView1.DataSource = cdao.GetAllCustomers();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("新增失败！");
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                if (cdao.DelCustomer(text客户编号.Text))
                {
                    MessageBox.Show("用户[" + text客户编号.Text + "]已被删除！");
                    //更新表格数据                    
                    dataGridView1.DataSource = cdao.GetAllCustomers();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("删除用户[" + text客户编号.Text + "]失败！");
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)//修改
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                Customer cus = new Customer();
                cus.Id = text客户编号.Text;
                cus.Name = text客户名称.Text;
                cus.Address = text客户地址.Text;
                cus.Phone = text联系电话.Text;
                cus.Fax = text传真.Text;
                cus.Email = text电子邮箱.Text;
                cus.Accounts = text结算方式.Text;
                cus.Serial = text流水号.Text;
                cus.Remarks = text备注.Text;
                if (cdao.AltCustomer(cus))
                {
                    MessageBox.Show("客户[" + text客户编号.Text + "]数据修改成功！");
                    //更新表格数据                    
                    dataGridView1.DataSource = cdao.GetAllCustomers();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerDAO cdao = new CustomerDAO();
            if (textBox搜索联系人.Text != "")
            {
                
                dataGridView2.DataSource = cdao.GetCustomerMembersByName(label联系人.Text, textBox搜索联系人.Text);
                dataGridView2.Update();
            }
            else
            {
                dataGridView2.DataSource = cdao.GetAllCustomerMembers();
                dataGridView2.Update();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label联系人.Text = dataGridView2.Columns[e.ColumnIndex].HeaderText.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                t编号.Text = dataGridView2.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                t姓名.Text = dataGridView2.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                t类型.Text = dataGridView2.Rows[e.RowIndex].Cells["类型"].Value.ToString();
                t电话.Text = dataGridView2.Rows[e.RowIndex].Cells["联系电话"].Value.ToString();
                t电子邮件.Text = dataGridView2.Rows[e.RowIndex].Cells["电子邮件"].Value.ToString();
                t所属客户.Text = dataGridView2.Rows[e.RowIndex].Cells["所属客户编号"].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                CustomerMember cus = new CustomerMember();
                cus.Id = t编号.Text;
                cus.Name = t姓名.Text;
                cus.Type = t类型.Text;
                cus.Phone = t电话.Text;
                cus.Email = t电子邮件.Text;
                cus.CustomerId = t所属客户.Text;
                if (cdao.AddNewCustomerMember(cus))
                {
                    MessageBox.Show("客户联系人[" + t编号.Text + "]新增成功！");
                    //更新表格数据                    
                    dataGridView2.DataSource = cdao.GetAllCustomerMembers();
                    dataGridView2.Update();
                }
                else
                    MessageBox.Show("新增失败！");
            }
            catch (Exception ex) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                if (cdao.DelCustomerMember(t编号.Text))
                {
                    MessageBox.Show("客户联系人[" + t编号.Text + "]已被删除！");
                    //更新表格数据                    
                    dataGridView2.DataSource = cdao.GetAllCustomerMembers();
                    dataGridView2.Update();
                }
                else
                    MessageBox.Show("删除客户联系人[" + t编号.Text + "]失败！");
            }
            catch (Exception ex) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerDAO cdao = new CustomerDAO();
                CustomerMember cus = new CustomerMember();
                cus.Id = t编号.Text;
                cus.Name = t姓名.Text;
                cus.Type = t类型.Text;
                cus.Phone = t电话.Text;
                cus.Email = t电子邮件.Text;
                cus.CustomerId = t所属客户.Text;
                if (cdao.AltCustomerMember(cus))
                {
                    MessageBox.Show("客户联系人[" + t编号.Text + "]修改成功！");
                    //更新表格数据                    
                    dataGridView2.DataSource = cdao.GetAllCustomerMembers();
                    dataGridView2.Update();
                }
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ex) { }
        }
    }
}
