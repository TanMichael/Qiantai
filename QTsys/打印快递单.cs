using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTsys.Manager;

namespace QTsys
{
    public partial class 打印快递单 : Form
    {
        private string 客户编号;
        private OrderManager odm;

        public 打印快递单(string id)
        {
            InitializeComponent();
            客户编号 = id;
            odm = new OrderManager();
        }

        private void 打印快递单_Load(object sender, EventArgs e)
        {
            label1客户编号.Text = 客户编号;
            try
            {
                dataGridView1.DataSource = odm.GetOrderBySerial(客户编号);
                dataGridView1.Update();
                textBox客户名称.Text = dataGridView1.Rows[0].Cells["客户名称"].Value.ToString();
                text收货地址.Text = dataGridView1.Rows[0].Cells["收货地址"].Value.ToString();
                com客户联系人.Text = dataGridView1.Rows[0].Cells["收货联系人"].Value.ToString();
                textBox结算方式.Text = dataGridView1.Rows[0].Cells["订金方式"].Value.ToString();
                text联系电话.Text = dataGridView1.Rows[0].Cells["收货电话"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
