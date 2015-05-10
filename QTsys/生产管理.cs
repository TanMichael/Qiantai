using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTsys.DataObjects;
using QTsys.Manager;
using QTsys.Common.Constants;
namespace QTsys
{
    public partial class 生产管理 : Form
    {
        private ProductPlanManager ppm;

        public 生产管理()
        {
            InitializeComponent();
            ppm = new ProductPlanManager();
        }

        private void 生产管理_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                dataGridView1.Update();
                dataGridView2.DataSource = this.ppm.GetAllProductPlanByName("生产状态", ProductionPlanStatus.PENDING);
                dataGridView2.Update();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView1.DataSource = this.ppm.GetAllProductPlanByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                text编号.Text = dataGridView1.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                com产品编号.Text = dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                com客户编号.Text = dataGridView1.Rows[e.RowIndex].Cells["客户编号"].Value.ToString();
                date下单日期.Value= Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["下单日期"].Value.ToString());
                text产品数量.Text = dataGridView1.Rows[e.RowIndex].Cells["产品数量"].Value.ToString();
                date交付时间.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["交付时间"].Value.ToString());
                date实际完成时间.Value =Convert.ToDateTime( dataGridView1.Rows[e.RowIndex].Cells["实际完成时间"].Value.ToString());
                com计划类型.Text = dataGridView1.Rows[e.RowIndex].Cells["计划类型"].Value.ToString();
                com生产状态.Text = dataGridView1.Rows[e.RowIndex].Cells["生产状态"].Value.ToString();
                text相关订单编号.Text = dataGridView1.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString();
                com负责人.Text = dataGridView1.Rows[e.RowIndex].Cells["负责人"].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label搜索栏目.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { }
        }

        public void showgrid()
        {
            try
            {
                dataGridView1.DataSource = this.ppm.GetAllProductPlanByTime(date_up.Value, date_down.Value);
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            showgrid();
        }

        private void date_down_ValueChanged(object sender, EventArgs e)
        {
            showgrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProductionPlan pp = new ProductionPlan();
                pp.Id = text编号.Text;
                pp.ProductId = com产品编号.Text;
                pp.CustomerId = com客户编号.Text;
                pp.OrderTime = date下单日期.Value;
                pp.Count =Convert.ToInt16( text产品数量.Text);
                pp.PlanningTime = date交付时间.Value;
                pp.FinishTime = date实际完成时间.Value;
                pp.PlanType = com计划类型.Text;
                pp.PlanState = com生产状态.Text;
                pp.RelatedOrderId = text相关订单编号.Text;
                pp.InChargePerson = com负责人.Text;
                if (ppm.AltPlan(pp))
                {
                    MessageBox.Show("完成更新！");
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("更新失败！");
            }
            catch (Exception ex) { MessageBox.Show("生产计划更新失败！"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ProductionPlan pp = new ProductionPlan();
                pp.Id = text编号.Text;
                pp.ProductId = com产品编号.Text;
                pp.CustomerId = com客户编号.Text;
                pp.OrderTime = date下单日期.Value;
                pp.Count = Convert.ToInt16(text产品数量.Text);
                pp.PlanningTime = date交付时间.Value;
                pp.FinishTime = date实际完成时间.Value;
                pp.PlanType = com计划类型.Text;
                pp.PlanState = com生产状态.Text;
                pp.RelatedOrderId = text相关订单编号.Text;
                pp.InChargePerson = com负责人.Text;
                if (ppm.AddNewPlan(pp))
                {
                    MessageBox.Show("新计划建立成功！");
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("失败！");
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ProductionPlan pp = new ProductionPlan();
                pp.Id = text编号.Text;
                pp.ProductId = com产品编号.Text;
                pp.CustomerId = com客户编号.Text;
                pp.OrderTime = date下单日期.Value;
                pp.Count = Convert.ToInt16(text产品数量.Text);
                pp.PlanningTime = date交付时间.Value;
                pp.FinishTime = date实际完成时间.Value;
                pp.PlanType = com计划类型.Text;
                pp.PlanState = com生产状态.Text;
                pp.RelatedOrderId = text相关订单编号.Text;
                pp.InChargePerson = com负责人.Text;
                if (ppm.DelPlan(pp.Id.ToString()))
                {
                    MessageBox.Show("删除成功！");
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("失败！");
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void text产品数量_TextChanged(object sender, EventArgs e)
        {
            label_num.Text = "计划生产数为" + text产品数量.Text + "，实际生产：";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //确认生产
            //如失败，计划-实际，生成新的订单列表（以补充形式出现订单）
            //同时合格产品入产品仓库
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
