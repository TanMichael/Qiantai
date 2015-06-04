using QTsys.DataObjects;
using QTsys.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTsys
{
    public partial class 对账 : Form
    {
        private OrderManager odm;
        private UserManager userMgr;
        private string selectedCustomerId;

        public 对账()
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
        }

        private void 对账_Load(object sender, EventArgs e)
        {
            comboBox客户.Items.Clear();
            // 初始化客户信息
            var customers = userMgr.GetAllCustomerList();
            customers.Insert(0, new Customer() { Id = "-9999", Name = "" });
            //use dataSource make selectedValue works;
            comboBox客户.DisplayMember = "Name";
            comboBox客户.ValueMember = "Id";
            comboBox客户.DataSource = customers;

            dateTimePicker对账起始日.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 25);
            dateTimePicker对账截止日.Value = DateTime.Today;
        }

        private void comboBox客户_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomerId = comboBox客户.SelectedValue.ToString();//customers[com客户名.SelectedIndex].Id;
            if (selectedCustomerId == "-9999")
            {
                return;
            }
            //com客户联系人
            DataTable dt = new DataTable();
            // MessageBox.Show(customers[com客户名.SelectedIndex].Id);
            dt = userMgr.SearchCustomerByCol("客户编号", selectedCustomerId);
            //l编号.Text = dt.Rows[0]["客户编号"].ToString();
            com客户联系人.Text = dt.Rows[0]["默认联系人"].ToString();
            text联系电话.Text = dt.Rows[0]["联系电话"].ToString();
            text收货地址.Text = dt.Rows[0]["地址"].ToString();
            textBox传真.Text = dt.Rows[0]["传真"].ToString();
            textBox结算方式.Text = dt.Rows[0]["结算方式"].ToString();
        }

        private void button生成_Click(object sender, EventArgs e)
        {
            string customerId = comboBox客户.SelectedValue.ToString();
            if (customerId == "-9999")
            {
                MessageBox.Show("请选择要对账的客户");
                return;
            }
            DateTime startDate = dateTimePicker对账起始日.Value;
            DateTime endDate = dateTimePicker对账截止日.Value;


            dataGridView对账单.DataSource = this.odm.GetReconciliation(customerId, startDate, endDate);
            dataGridView对账单.Update();
        }

        private void button打印_Click(object sender, EventArgs e)
        {
            try
            {
                打印对账单 win = new 打印对账单(this, (DataTable)(dataGridView对账单.DataSource));
                win.ShowDialog();
            }
            catch (Exception ex) { };
        }
    }
}
