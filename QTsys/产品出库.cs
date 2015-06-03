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
    public partial class 产品出库 : Form
    {
        private string orderId;//订单ID
        private ProductionManager pdm;
        private OrderManager odm;
        private ProductPlanManager ppm;

        public 产品出库(string oId)
        {
            InitializeComponent();
            orderId = oId;
            pdm = new ProductionManager();
            odm = new OrderManager();
            ppm = new ProductPlanManager();
        }

        private void 产品出库_Load(object sender, EventArgs e)
        {
            initGrid();
        }

        private void initGrid()
        {
            text相关订单编号.Text = orderId;
            dataGridView1.DataSource = odm.GetAllOrderByStateAndSerial(OrderStatus.PROCESSING, orderId);
            dataGridView1.Update();
            dataGridView2.DataSource = odm.GetAllOrderDetailsBySerialEx(orderId);
            dataGridView2.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var canDeliver = true;
            List<ProductionPlan> plans = new List<ProductionPlan>();
            List<int> invalidProductIds = new List<int>();
            string invalidPIdStr = "";
            DataTable planTable = ppm.GetProductPlanByOrder(orderId);
            foreach (DataRow row in planTable.Rows)
            {
                ProductionPlan plan = new ProductionPlan();
                plan.Id = row["编号"].ToString();
                plan.PlanState = row["生产状态"].ToString();
                plan.ProductId = row["产品编号"].ToString();
                plan.Count = int.Parse(row["产品数量"].ToString());
                plans.Add(plan);
                if (plan.PlanState != ProductionPlanStatus.STORED)
                {
                    canDeliver = false;
                    invalidProductIds.Add(int.Parse(plan.ProductId));
                    invalidPIdStr += "," + plan.ProductId;
                }
            }

            if (canDeliver == false)
            {
                MessageBox.Show("请先完成产品" + invalidPIdStr + "的生产再出库。");
                return;
            }
            else
            {
                bool canFinishOrder = true;
                foreach (ProductionPlan pl in plans)
                {
                    if (!DeliverProduct(pl.ProductId, pl.Count, pl.Id))
                    {
                        canFinishOrder = false;
                        MessageBox.Show("产品" + pl.ProductId + "出库失败！");
                    }
                }
                MessageBox.Show("相关产品出库成功");

                if (canFinishOrder == true)
                {
                    odm.UpdateOrderStatus(OrderStatus.SHIPPED, orderId);
                }
            }

            this.Close();
        }


        public bool DeliverProduct(string 产品编号, int 产品数量, string relatedPlanId)
        {
            try
            {
                ProductFlow proflow = new ProductFlow();
                proflow.ProductId = 产品编号;
                proflow.OccurredTime = DateTime.Now;
                proflow.Type = "订单出库";
                proflow.RelatedOrderId = orderId;
                proflow.RelatedPlanId = relatedPlanId;
                //proflow.UnqualifiedCount = 不合格产品数;
                proflow.Status = ProductionStatus.OUT;
                if (pdm.DeliverProduct(proflow, 产品数量))
                {
                    //ppm.UpdatePlanStatus(ProductionPlanStatus.STORED, text编号.Text);
                    MessageBox.Show("产品" + 产品编号 + "出库成功！！！");
                    return true;
                }
                else
                    MessageBox.Show("产品" + 产品编号 + "出库失败！！！");
                return false;
            }
            catch (Exception ex) { return false; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            打印送货单 win = new 打印送货单(text相关订单编号.Text);
            win.ShowDialog();
        }
    }
}
