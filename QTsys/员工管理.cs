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
    public partial class 员工管理 : Form
    {
        private UserManager userMgr;

        public 员工管理()
        {
            InitializeComponent();
            this.userMgr = UserManager.getUserManager();
        }

        private void 员工管理_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.userMgr.GetAllUser();
                dataGridView1.Update();

                com角色.Items.AddRange(new string[]
                    {
                        UserRoles.WORKER,
                        UserRoles.ADMIN,
                        UserRoles.ENGINEER,
                        UserRoles.SALES,
                        UserRoles.FINANCE,
                        UserRoles.STORAGE,
                        UserRoles.SYS_ADMIN
                    });

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox搜索内容.Text != "")
                {
                    dataGridView1.DataSource = this.userMgr.SearchUserByCol(label搜索栏目.Text, textBox搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.userMgr.GetAllUser();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                text员工编号.Text = dataGridView1.Rows[e.RowIndex].Cells["员工编号"].Value.ToString();
                text账户名.Text = dataGridView1.Rows[e.RowIndex].Cells["账户名"].Value.ToString();
                text密码.Text = dataGridView1.Rows[e.RowIndex].Cells["密码"].Value.ToString();
                text姓名.Text = dataGridView1.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                com角色.Text = dataGridView1.Rows[e.RowIndex].Cells["系统角色"].Value.ToString();
                text职位.Text = dataGridView1.Rows[e.RowIndex].Cells["职位"].Value.ToString();
                text手机.Text = dataGridView1.Rows[e.RowIndex].Cells["手机"].Value.ToString();
                text办公电话.Text = dataGridView1.Rows[e.RowIndex].Cells["办公电话"].Value.ToString();
                text电子邮箱.Text = dataGridView1.Rows[e.RowIndex].Cells["电子邮箱"].Value.ToString();
                text部门.Text = dataGridView1.Rows[e.RowIndex].Cells["部门"].Value.ToString();
            }
            catch (Exception ex) {   }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label搜索栏目.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
            }
        catch (Exception ex) {   }
       
        }

        private void button3_Click(object sender, EventArgs e)//新增
        {
            try
            {
                User newuser=new User();
                newuser.Id=text员工编号.Text;
                newuser.UserName= text账户名.Text;
                newuser.Password="c4ca4238a0b923820dcc509a6f75849b";
                newuser.Name=text姓名.Text;
                newuser.Role=com角色.Text;
                newuser.JobTitle = text职位.Text;
                newuser.Mobile=text手机.Text;
                newuser.Phone=text办公电话.Text;
                newuser.Email=text电子邮箱.Text;
                newuser.Department = text部门.Text;
                if (this.userMgr.AddNewUser(newuser))
                {
                    MessageBox.Show("新用户[" + text员工编号.Text + "]生成成功,默认密码为“1”！");
                    //更新表格数据                    
                    dataGridView1.DataSource = this.userMgr.GetAllUser();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("插入失败！");
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            try
            {
                if (this.userMgr.DelUser(text员工编号.Text))
                {
                    MessageBox.Show("用户[" + text员工编号.Text + "]已被删除！");
                    //更新表格数据                    
                    dataGridView1.DataSource = this.userMgr.GetAllUser();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("删除用户[" + text员工编号.Text + "]失败！");
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)// 修改并保存
        {
            try
            {
                User newuser = new User();
                newuser.Id = text员工编号.Text;
                newuser.UserName = text账户名.Text;
                newuser.Password = text密码.Text;
                newuser.Name = text姓名.Text;
                newuser.Role = com角色.Text;
                newuser.JobTitle = text职位.Text;
                newuser.Mobile = text手机.Text;
                newuser.Phone = text办公电话.Text;
                newuser.Email = text电子邮箱.Text;
                newuser.Department = text部门.Text;
                if (this.userMgr.UpdateUser(newuser))
                {
                    MessageBox.Show("用户[" + text员工编号.Text + "]数据修改成功！");
                    //更新表格数据                    
                    dataGridView1.DataSource = this.userMgr.GetAllUser();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ex) { }
        }

        private void text账户名_Leave(object sender, EventArgs e)
        {
            string name = text账户名.Text;
            if (!this.userMgr.ValidateUserName(name))
            {
                MessageBox.Show("账户名已被使用，请修改！");
            }
        }
    }
}
