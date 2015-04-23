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
            //grid1
            try
            {
                UserDAO con = new UserDAO();
                dataGridView1.DataSource = con.GetAllUser();
                dataGridView1.Update();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
            //grid2
            try
            {
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
                MySqlConnection mysql = new MySqlConnection(mysqlStr);
                String sql = "SELECT * FROM qiaotai.客户联系人;";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                mysql.Open();
                ap.Fill(DT);
                dataGridView2.DataSource = DT;
                dataGridView2.Update();
                mysql.Close();
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
                MySqlConnection mysql = new MySqlConnection(mysqlStr);
                String sql = "SELECT * FROM qiaotai.客户信息 WHERE " + label搜索栏目.Text + " LIKE '%" + textBox搜索内容.Text + "%';";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                mysql.Open();
                ap.Fill(DT);
                dataGridView1.DataSource = DT;
                dataGridView1.Update();
                mysql.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button3_Click(object sender, EventArgs e)//新增
        {

        }

        private void button2_Click(object sender, EventArgs e)//删除
        {

        }

        private void button1_Click(object sender, EventArgs e)//修改
        {

        }
    }
}
