using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using QTsys.Common;
using QTsys.DataObjects;

namespace QTsys
{
    public partial class 服务器设置 : Form
    {
        public 服务器设置()
        {
            InitializeComponent();
        }

        private void 服务器设置_Load(object sender, EventArgs e)
        {
            try
            {
                var config = Utils.ReadConnConfig();
                textBox1.Text = config.Server;//获取指定节点的指定属性值
                textBox2.Text = config.Database;
                textBox3.Text = config.DataSource;
                textBox4.Text = config.UserId;
                textBox5.Text = config.Password;
                textBox6.Text = config.Pooling;
                textBox7.Text = config.CharSet;
                textBox8.Text = config.Port;
            }
            catch (Exception ex) { MessageBox.Show("读取失败！！！" + ex.ToString()); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();//创建dom对象
                XmlElement root = doc.CreateElement("mysqlset");//创建根节点album

                var config = new ConnectionConfig();
                config.Server = textBox1.Text;//
                config.Database = textBox2.Text;//
                config.DataSource = textBox3.Text;//
                config.UserId = textBox4.Text;//
                config.Password = textBox5.Text;//
                config.Pooling = textBox6.Text;//
                config.CharSet = textBox7.Text;//
                config.Port = textBox8.Text;//
                Utils.UpdateConfig(config);

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("保存失败！！！"+ex.ToString()); }
         
        }
    }
}
