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

namespace QTsys
{
    public partial class 产品库管理 : Form
    {
        private ProductionManager pdm;
        private OrderManager odm;
        private ProductPlanManager ppm;
        public 产品库管理()
        {
            InitializeComponent();
            pdm = new ProductionManager();
            odm = new OrderManager();
            ppm = new ProductPlanManager();
        }

        private void 产品库管理_Load(object sender, EventArgs e)
        {
            dataGridView产品进出库.DataSource = pdm.GetAllProductFlow();
            dataGridView产品进出库.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView产品进出库.DataSource = pdm.GetAllProductFlowByName(label搜索栏目.Text, text搜索内容.Text);
                        //this.material.GetAllMaterialByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView产品进出库.Update();
                }
                else
                {
                    dataGridView产品进出库.DataSource = pdm.GetAllProductFlow();
                    dataGridView产品进出库.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                text编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["编号"].Value.ToString();
               text产品编号.Text=  dataGridView产品进出库.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                date发生时间.Value=Convert.ToDateTime(dataGridView产品进出库.Rows[e.RowIndex].Cells["发生时间"].Value);
                text类型.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["类型"].Value.ToString();
                text相关订单编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString();
                text相关计划编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["相关计划编号"].Value.ToString();
                text不合格产品数.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["不合格产品数"].Value.ToString();
                text当期状态.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["当前状态"].Value.ToString();

                //dataGridView订单
                dataGridView产品信息.DataSource = pdm.GetAllProductsByNameEX("产品编号", dataGridView产品进出库.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGridView产品信息.Update();
                dataGridView订单.DataSource = odm.GetOrderBySerial(dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString());
                dataGridView订单.Update();
               dataGridView生产计划.DataSource = ppm.GetAllProductPlanByNameEX("相关订单编号", dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString());
                dataGridView生产计划.Update();
                dataGridView订单明细.DataSource = odm.GetAllOrderDetailsBySerial(dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString());
                dataGridView订单明细.Update();
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label搜索栏目.Text = dataGridView产品进出库.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            产品入库 win = new 产品入库();
            win.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            产品出库 win = new 产品出库();
            win.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            产品数据修改 win = new 产品数据修改();
            win.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //产品出库操作
            送货单 win = new 送货单();
            win.ShowDialog();
        }
    }
}
