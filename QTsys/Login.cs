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
            //写禁止进入系统
            File.Delete(Directory.GetCurrentDirectory() + "\\login.txt");
            StreamWriter wr = new StreamWriter(Directory.GetCurrentDirectory() + "\\login.txt", true, Encoding.GetEncoding("unicode"));
            wr.Write("no");
            wr.Close();
            //测试密码是否正确
            try
            {
                User user = new User();
                user.UserName = comboBox1.Text;
                user.Password = textBox1.Text;
                if (this.userMgr.Login(user))
                {
                    //登录成功
                    File.Delete(Directory.GetCurrentDirectory() + "\\login.txt");
                    StreamWriter wr2 = new StreamWriter(Directory.GetCurrentDirectory() + "\\login.txt", true, Encoding.GetEncoding("unicode"));
                    wr2.Write("yes");
                    wr2.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误1！");
                }
                               
            }
            catch (Exception ex)
            { 
                //MessageBox.Show(ex.ToString()); 
                MessageBox.Show("账号不存在或者密码错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //设置登录失败
            File.Delete(Directory.GetCurrentDirectory() + "\\login.txt");
            StreamWriter wr2 = new StreamWriter(Directory.GetCurrentDirectory() + "\\login.txt", true, Encoding.GetEncoding("unicode"));
            wr2.Write("no");
            wr2.Close(); 
            //关闭窗口
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
                //对账户进行绑定读取mysql远程读取
                //先读mysql_set.xml
                XmlDocument doc = new XmlDocument();
                doc.Load(@"mysql_set.xml");
                XmlNode root = doc.SelectSingleNode("mysqlset");//指定一个节点
                string str1 = root.Attributes["Server"].Value;//获取指定节点的指定属性值
                string str2 = root.Attributes["Database"].Value;
                string str3 = root.Attributes["DataSource"].Value;
                string str4 = root.Attributes["UserId"].Value;
                string str5 = root.Attributes["Password"].Value;
                string str6 = root.Attributes["pooling"].Value;
                string str7 = root.Attributes["CharSet"].Value;
                string str8 = root.Attributes["port"].Value;
                //连接数据库，读取数据
               String mysqlStr = "Server=" + str1 + ";Database=" + str2 + ";Data Source=" + str3 + ";User Id=" + str4 + ";Password=" + str5 + ";pooling=" + str6 + ";CharSet=" + str7 + ";port=" + str8 + "";
                // String mysqlStr = "server=PC201503281640;user id=root;Password=0633;persistsecurityinfo=True;database=qiaotai";
                MySqlConnection mysql = new MySqlConnection(mysqlStr);
                String sql = "SELECT * FROM qiaotai.员工信息;";
                MySqlCommand cmd=new MySqlCommand(sql,mysql);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                mysql.Open();
                ap.Fill(DT);
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    comboBox1.Items.Add(DT.Rows[i][1].ToString());
                }
                mysql.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
