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
        private int index订单;
        private int index生产计划;

        public 审核()
        {
            InitializeComponent();
            showdata = new OperationAuditDAO();
            ppm = new ProductPlanManager();
            odm = new OrderManager();
            index订单=-1;
            index生产计划 = -1;
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
            try{
                index订单 =e.RowIndex;
                dataGridView订单明细.DataSource = this.odm.GetAllOrderDetailsBySerialEx(dataGridView订单.Rows[e.RowIndex].Cells["订单编号"].Value.ToString());
                dataGridView订单明细.Update();
            }
            catch (Exception ex) { };
        }

        private void button通过计划_Click(object sender, EventArgs e)
        {
            if (index生产计划 == -1) { MessageBox.Show("请逐个审核订生产计划！"); return; } 
            try
            {
                //ProductionPlan pp = new ProductionPlan();
                string pId = dataGridView生产计划.Rows[index生产计划].Cells["编号"].Value.ToString();
                //pp.ProductId = dataGridView生产计划.Rows[index生产计划].Cells["产品编号"].Value.ToString();
                //pp.CustomerId = dataGridView生产计划.Rows[index生产计划].Cells["客户编号"].Value.ToString();
                //pp.OrderTime = Convert.ToDateTime(dataGridView生产计划.Rows[index生产计划].Cells["下单日期"].Value.ToString());
                //pp.Count = Convert.ToInt32(dataGridView生产计划.Rows[index生产计划].Cells["产品数量"].Value);
                //pp.PlanningTime = Convert.ToDateTime(dataGridView生产计划.Rows[index生产计划].Cells["交付时间"].Value.ToString());
                //pp.FinishTime = Convert.ToDateTime(dataGridView生产计划.Rows[index生产计划].Cells["实际完成时间"].Value.ToString());
                //pp.PlanType = dataGridView生产计划.Rows[index生产计划].Cells["计划类型"].Value.ToString();
                //pp.PlanState = ProductionPlanStatus.PREPARING;
                //pp.RelatedOrderId = dataGridView生产计划.Rows[index生产计划].Cells["相关订单编号"].Value.ToString();
                //pp.InChargePerson = dataGridView生产计划.Rows[index生产计划].Cells["负责人"].Value.ToString();
                if (ppm.UpdatePlanStatus(ProductionPlanStatus.PREPARING, pId))
                {
                    MessageBox.Show("生产状态更新成功！");
                    dataGridView生产计划.DataSource = this.ppm.GetAllProductPlanByName("生产状态", ProductionPlanStatus.PENDING);
                    dataGridView生产计划.Update();
                }
                else
                    MessageBox.Show("生产状态更新失败！");
            }
            catch (Exception ex) { MessageBox.Show("生产状态更新失败！"); }
        }

        private void button拒绝计划_Click(object sender, EventArgs e)
        {
            if (index生产计划 == -1) { MessageBox.Show("请逐个审核订生产计划！"); return; } 
            try
            {
                //ProductionPlan pp = new ProductionPlan();
                string pId = dataGridView生产计划.Rows[index生产计划].Cells["编号"].Value.ToString();
                //pp.ProductId = dataGridView生产计划.Rows[index生产计划].Cells["产品编号"].Value.ToString();
                //pp.CustomerId = dataGridView生产计划.Rows[index生产计划].Cells["客户编号"].Value.ToString();
                //pp.OrderTime = Convert.ToDateTime(dataGridView生产计划.Rows[index生产计划].Cells["下单日期"].Value.ToString());
                //pp.Count = Convert.ToInt32(dataGridView生产计划.Rows[index生产计划].Cells["产品数量"].Value);
                //pp.PlanningTime = Convert.ToDateTime(dataGridView生产计划.Rows[index生产计划].Cells["交付时间"].Value.ToString());
                //pp.FinishTime = Convert.ToDateTime(dataGridView生产计划.Rows[index生产计划].Cells["实际完成时间"].Value.ToString());
                //pp.PlanType = dataGridView生产计划.Rows[index生产计划].Cells["计划类型"].Value.ToString();
                //pp.PlanState = ProductionPlanStatus.CANCEL;
                //pp.RelatedOrderId = dataGridView生产计划.Rows[index生产计划].Cells["相关订单编号"].Value.ToString();
                //pp.InChargePerson = dataGridView生产计划.Rows[index生产计划].Cells["负责人"].Value.ToString();
                if (ppm.UpdatePlanStatus(ProductionPlanStatus.CANCEL, pId))
                {
                    MessageBox.Show("生产状态更新成功！");
                    dataGridView生产计划.DataSource = this.ppm.GetAllProductPlanByName("生产状态", ProductionPlanStatus.PENDING);
                    dataGridView生产计划.Update();
                }
                else
                    MessageBox.Show("生产状态更新失败！");
            }
            catch (Exception ex) { MessageBox.Show("生产状态更新失败！"); }
        }

        private void button通过订单_Click(object sender, EventArgs e)
        {
            if (index订单 == -1) { MessageBox.Show("请逐个审核订单！"); return; }
            try
            {
                //Order od = new Order();
                string oId = dataGridView订单.Rows[index订单].Cells["订单编号"].Value.ToString();
                //od.CreateTime = Convert.ToDateTime(dataGridView订单.Rows[index订单].Cells["创建时间"].Value);
                //od.DeliverTime = Convert.ToDateTime(dataGridView订单.Rows[index订单].Cells["发货时间"].Value);
                //od.LastUpdateTime = Convert.ToDateTime(dataGridView订单.Rows[index订单].Cells["最后更新时间"].Value);
                //od.OrderStatus = OrderStatus.PASS;
                //od.ExpressNO = dataGridView订单.Rows[index订单].Cells["快递单号"].Value.ToString();
                //od.DepositMode = dataGridView订单.Rows[index订单].Cells["订金方式"].Value.ToString();
                //od.RecieverAddress = dataGridView订单.Rows[index订单].Cells["收货地址"].Value.ToString();
                //od.RecieverName = dataGridView订单.Rows[index订单].Cells["收货联系人"].Value.ToString();
                //od.RecieverPhone = dataGridView订单.Rows[index订单].Cells["收货电话"].Value.ToString();
                //od.Creator = dataGridView订单.Rows[index订单].Cells["创建人"].Value.ToString();
                if (this.odm.UpdateOrderStatus(OrderStatus.PASS, oId))
                {
                    MessageBox.Show("订单状态修改成功！");
                    dataGridView订单.DataSource = this.odm.GetAllOrderByState(OrderStatus.PENDING);
                    dataGridView订单.Update();
                }
                else
                    MessageBox.Show("订单状态修改失败！");
            }
            catch (Exception ex) { MessageBox.Show("订单状态修改失败！"); }
        }

        private void button拒绝订单_Click(object sender, EventArgs e)
        {
            if (index订单 == -1) { MessageBox.Show("请逐个审核订单！"); return; }
            try
            {
                //Order od = new Order();
                string oId = dataGridView订单.Rows[index订单].Cells["订单编号"].Value.ToString();
                //od.CreateTime = Convert.ToDateTime(dataGridView订单.Rows[index订单].Cells["创建时间"].Value);
                //od.DeliverTime = Convert.ToDateTime(dataGridView订单.Rows[index订单].Cells["发货时间"].Value);
                //od.LastUpdateTime = Convert.ToDateTime(dataGridView订单.Rows[index订单].Cells["最后更新时间"].Value);
                //od.OrderStatus = OrderStatus.CANCEL;
                //od.ExpressNO = dataGridView订单.Rows[index订单].Cells["快递单号"].Value.ToString();
                //od.DepositMode = dataGridView订单.Rows[index订单].Cells["订金方式"].Value.ToString();
                //od.RecieverAddress = dataGridView订单.Rows[index订单].Cells["收货地址"].Value.ToString();
                //od.RecieverName = dataGridView订单.Rows[index订单].Cells["收货联系人"].Value.ToString();
                //od.RecieverPhone = dataGridView订单.Rows[index订单].Cells["收货电话"].Value.ToString();
                //od.Creator = dataGridView订单.Rows[index订单].Cells["创建人"].Value.ToString();
                if (this.odm.UpdateOrderStatus(OrderStatus.CANCEL, oId))
                {
                    MessageBox.Show("订单状态修改成功！");
                    dataGridView订单.DataSource = this.odm.GetAllOrderByState(OrderStatus.PENDING);
                    dataGridView订单.Update();
                }
                else
                    MessageBox.Show("订单状态修改失败！");
            }
            catch (Exception ex) { MessageBox.Show("订单状态修改失败！"); }
        }

        private void dataGridView生产计划_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index生产计划 = e.RowIndex;
        }
    }
}
