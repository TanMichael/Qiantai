using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using QTsys.Common;
using QTsys.Manager;
using QTsys.DataObjects;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Xml;

namespace QTsys
{
    public partial class Login : Form
    {
        private UserManager userMgr;

        public Login()
        {
            InitializeComponent();
            this.userMgr = UserManager.getUserManager();
        }

        private void button1_Click(object sender, EventArgs e)//按登录按钮
        {
            //测试密码是否正确
            try
            {
                User user = new User();
                user.UserName = comboBox1.Text;
                user.Password = textBox1.Text;
                this.userMgr.UpdateConnection(); 
                User rUser = this.userMgr.Login(user);
                if (rUser != null)
                {
                    ////登录成功
                    Utils.SetLogonToken(rUser.UserName, rUser.Role);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误1！");
                }
                               
            }
            catch (Exception ex)
            {  
                MessageBox.Show("账号不存在或者密码错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            服务器设置 win = new 服务器设置();
            win.ShowDialog();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
            try
            {
                comboBox1.Items.Clear();
                QTsys.DAO.UserDAO dao = new DAO.UserDAO();
                var names = dao.GetAllUserNames();
                comboBox1.Items.AddRange(names.ToArray());
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
