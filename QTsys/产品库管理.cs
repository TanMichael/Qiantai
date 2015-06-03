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
    public partial class 产品库管理 : Form
    {
        private ProductionManager pdm;
        private OrderManager odm;
        private ProductPlanManager ppm;

        private string selectedOrderId = "-9999";
        private string selectedOrderStatus = "";

        public 产品库管理()
        {
            InitializeComponent();
            pdm = new ProductionManager();
            odm = new OrderManager();
            ppm = new ProductPlanManager();
        }

        private void 产品库管理_Load(object sender, EventArgs e)
        {
            initGrid();
        }

        private void initGrid()
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
                text产品编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                date发生时间.Value = Convert.ToDateTime(dataGridView产品进出库.Rows[e.RowIndex].Cells["发生时间"].Value);
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
                //_____________________________________________________
                dataGridView完成情况.DataSource = odm.GetOrderFinish(dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString());
                dataGridView完成情况.Update();
                //_____________________________________________________
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
            if (selectedOrderId == "-9999")
            {
                MessageBox.Show("请选择一个订单进行出库");
                return;
            }

            if (selectedOrderStatus == OrderStatus.SHIPPED || selectedOrderStatus == OrderStatus.SUCCEED)
            {
                MessageBox.Show("该订单已出库");
                return;
            }

            产品出库 win = new 产品出库(selectedOrderId);
            win.ShowDialog();

            initGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            产品数据修改 win = new 产品数据修改();
            win.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //产品出库操作
            打印送货单 win = new 打印送货单(selectedOrderId);
            win.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (odm.UpdateOrderStatus(OrderStatus.SHIPPED, text相关订单编号.Text))
            {
                pdm.UpdataProductByStatus(ProductionStatus.OUT, text相关订单编号.Text);
                MessageBox.Show("订单产品确定打包发货！");
            //    dataGridView产品进出库.DataSource = pdm.ge
               // dataGridView产品进出库.Update();
            }else
                MessageBox.Show("操作失败！");

        }

        private void dataGridView订单_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedOrderId = dataGridView订单.Rows[e.RowIndex].Cells["订单编号"].Value.ToString();
            selectedOrderStatus = dataGridView订单.Rows[e.RowIndex].Cells["订单状态"].Value.ToString();
        }
    }
}
