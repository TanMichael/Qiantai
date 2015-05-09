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
using QTsys.Manager;
using QTsys.DataObjects;
using QTsys.Common.Constants;
using QTsys.DAO;

namespace QTsys
{
    public partial class 审核 : Form
    {
        OperationAuditDAO showdata;
        private ProductPlanManager ppm;
        private OrderManager odm;

        public 审核()
        {
            InitializeComponent();
            showdata = new OperationAuditDAO();
            ppm = new ProductPlanManager();
            odm = new OrderManager();
        }

        private void 审核_Load(object sender, EventArgs e)
        {
            try
            {
                this.tabControl1.SelectedIndex = 1;
                date_down.Value = DateTime.Now;
                date_up.Value = DateTime.Now.AddMonths(-1);
                dataGridView1.DataSource = this.showdata.GetAllMsg(date_up.Value, date_down.Value);
                dataGridView1.Update();
                dataGridView生产计划.DataSource = this.ppm.GetAllProductPlanByName("生产状态", "待审核");
                dataGridView生产计划.Update();
                dataGridView订单.DataSource = this.odm.GetAllOrderByState("待审核");
                dataGridView订单.Update();
            }
            catch (Exception ex) { };
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                label_搜索栏目.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { };
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox动作.Text != "")
                {
                    dataGridView1.DataSource = this.showdata.GetGetAllMsgByAction(label_搜索栏目.Text, textBox动作.Text, date_up.Value, date_down.Value);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.showdata.GetAllMsg(date_up.Value, date_down.Value);
                    dataGridView1.Update();
                }
            }
            catch (Exception ex) { };
        }

        public void showgrid() {
            try
            {
                dataGridView1.DataSource = this.showdata.GetAllMsg(date_up.Value, date_down.Value);
                dataGridView1.Update();
            }
            catch (Exception ex) { };
        }

        private void date_up_ValueChanged(object sender, EventArgs e)
        {
            showgrid();
        }

        private void date_down_ValueChanged(object sender, EventArgs e)
        {
            showgrid();
        }

        private void dataGridView订单_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView订单明细.DataSource = this.odm.GetAllOrderDetailsBySerial(dataGridView订单.Rows[e.RowIndex].Cells["订单编号"].Value.ToString());
                dataGridView订单明细.Update();
            }
            catch (Exception ex) { };
        }
    }
}
