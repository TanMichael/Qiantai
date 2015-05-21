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
    public partial class 报价 : Form
    {
        private ProductionManager pMgr;
        private OrderManager oMgr;
        private string selectedOrderId;
        private string selectedProductId;

        public 报价()
        {
            InitializeComponent();
            oMgr = new OrderManager();
            pMgr = new ProductionManager();
        }

        private void 报价_Load(object sender, EventArgs e)
        {
            button报价.Enabled = false;
            // dataGridView样品
            dataGridView样品.DataSource = oMgr.GetFinishedSampleOrders();
            dataGridView样品.Update();
        }

        private void dataGridView样品_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedOrderId = dataGridView样品.Rows[e.RowIndex].Cells["订单编号"].Value.ToString();

            if (checkBox所有没有报价.Checked)
            {
                checkBox所有没有报价.Checked = false;
            }
            else
            {
                dataGridView产品.DataSource = pMgr.GetProductsByOrder(selectedOrderId);
                dataGridView产品.Update();
            }
        }

        private void checkBox所有没有报价_CheckedChanged(object sender, EventArgs e)
        {
            updateDataGridView产品();
        }

        private void dataGridView产品_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button报价.Enabled = true;
            label产品Value.Text = dataGridView产品.Rows[e.RowIndex].Cells["产品名称"].Value.ToString();
            selectedProductId = dataGridView产品.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
        }

        private void button报价_Click(object sender, EventArgs e)
        {
            double price;
            if (Double.TryParse(textBox报价.Text, out price))
            {
                if (pMgr.SetProductPrice(price, selectedProductId))
                {
                    MessageBox.Show("报价成功");
                    updateDataGridView产品();
                    button报价.Enabled = false;
                    textBox报价.Text = "";
                    label产品Value.Text = "";
                }
            }
            else
            {
                MessageBox.Show("请输入正确的数字格式");
            }
            
        }

        private void updateDataGridView产品()
        {
            bool isChecked = checkBox所有没有报价.Checked;

            if (isChecked)
            {
                dataGridView产品.DataSource = pMgr.GetProductsWithoutPrice();
            }
            else if (selectedOrderId != null)
            {
                dataGridView产品.DataSource = pMgr.GetProductsByOrder(selectedOrderId);
            }
            else
            {
                dataGridView产品.DataSource = null;
            }
            dataGridView产品.Update();
        }
    }
}
