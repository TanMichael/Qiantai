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
    public partial class 样品库存自动生成 : Form
    {
        private OrderManager odm;
        private UserManager userMgr;
        private ProductionManager pm;
        private MaterialManager mt;
        private int index3;
        private int OrderId;
        private ProductPlanManager ppm;
        private ProductionPlan plan;


        public 样品库存自动生成()
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
            pm = new ProductionManager();
            mt = new MaterialManager();
            ppm = new ProductPlanManager();
            index3 = 0;
        }

        public 样品库存自动生成(string 是否样品, string 订单编号,string 客户编号)
      //  public 样品库存自动生成(ProductionPlan plant)
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
            pm = new ProductionManager();
            mt = new MaterialManager();
            ppm = new ProductPlanManager();
            plan = new ProductionPlan();
       //     plan = plant;
            index3 = 0;
          //  OrderId =Convert.ToInt16( plant.RelatedOrderId);
            OrderId = Convert.ToInt16(订单编号);
            plan.PlanType = 是否样品;
            plan.CustomerId = 客户编号;
           plan.RelatedOrderId = 订单编号;
        }

        private void 样品库存自动生成_Load(object sender, EventArgs e)
        {
           // WinSendMsg.row = dataGridView2.Rows.Count;
           // WinSendMsg.Oid = id;
            text订单编号.Text = OrderId.ToString();
            dataGridView1.DataSource = odm.GetAllOrderDetailsBySerial(text订单编号.Text);
           // dataGridView4.DataSource = odm.GetAllOrderDetailsBySerial(WinSendMsg.Oid);
          //  dataGridView5.DataSource = odm.GetAllOrderDetailsBySerial(WinSendMsg.Oid);
           /* 
            if (!WinSendMsg.IsSampleProduct)//是否订制样品
            {
                this.tabPage1.Parent = null;
            }
            if (!WinSendMsg.IsMeterialReduce)//是否从库存取产品
            {
                this.tabPage2.Parent = null;
            }*/
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //根据产品编号查询数据
            //dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString()
            try
            { dataGridView2.DataSource = pm.GetAllProductsByNameEX("产品编号", dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGridView3.DataSource = pm.GetMaterialProductRelationByProduct(dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGridView2.Update();
                dataGridView3.Update();
                //
                text产品编号.Text = dataGridView2.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                text产品名称.Text = dataGridView2.Rows[e.RowIndex].Cells["产品名称"].Value.ToString();
                text规格.Text = dataGridView2.Rows[e.RowIndex].Cells["规格"].Value.ToString();
                text材质.Text = dataGridView2.Rows[e.RowIndex].Cells["材质"].Value.ToString();
                text变位.Text = dataGridView2.Rows[e.RowIndex].Cells["变位"].Value.ToString();
                text实测变位.Text = dataGridView2.Rows[e.RowIndex].Cells["实测变位"].Value.ToString();
                text温度.Text = dataGridView2.Rows[e.RowIndex].Cells["温度"].Value.ToString();
                text生产耗时.Text = dataGridView2.Rows[e.RowIndex].Cells["生产耗时"].Value.ToString();
                text压力.Text = dataGridView2.Rows[e.RowIndex].Cells["压力"].Value.ToString();
                text树脂名称.Text = dataGridView2.Rows[e.RowIndex].Cells["树脂名称"].Value.ToString();
                text树脂比重.Text = dataGridView2.Rows[e.RowIndex].Cells["树脂比重"].Value.ToString();
                text含浸尺寸.Text = dataGridView2.Rows[e.RowIndex].Cells["含浸尺寸"].Value.ToString();
                text外盘.Text = dataGridView2.Rows[e.RowIndex].Cells["外盘"].Value.ToString();
                text内治具.Text = dataGridView2.Rows[e.RowIndex].Cells["内治具"].Value.ToString();
                text重量.Text = dataGridView2.Rows[e.RowIndex].Cells["重量"].Value.ToString();
                text成型模.Text = dataGridView2.Rows[e.RowIndex].Cells["成型模"].Value.ToString();
                text切模号.Text = dataGridView2.Rows[e.RowIndex].Cells["切模号"].Value.ToString();
                text单位.Text = dataGridView2.Rows[e.RowIndex].Cells["单位"].Value.ToString();
                text单价.Text = dataGridView2.Rows[e.RowIndex].Cells["单价"].Value.ToString();
                text库存数量.Text = dataGridView2.Rows[e.RowIndex].Cells["库存数量"].Value.ToString();
                ////////
            }
            catch (Exception ex) { };

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // tabControl1.SelectedIndex = 1 ;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)//产品原料关系
        {
            index3 = e.RowIndex;
          //  text原料数量.Text = dataGridView3.Rows[e.RowIndex].Cells["原料数量"].Value.ToString();
           // l原料数量.Text = "生产产品【" + dataGridView3.Rows[e.RowIndex].Cells["产品编号"].Value.ToString() + "】1件须消耗原料【" + dataGridView3.Rows[e.RowIndex].Cells["原料编号"].Value.ToString() + "】";
            textBox产品.Text = dataGridView3.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
            textBox原料.Text = dataGridView3.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
            textBox原料数量.Text = dataGridView3.Rows[e.RowIndex].Cells["原料数量"].Value.ToString();
            dataGridView7.DataSource = mt.GetAllMaterialByName("原料编号", dataGridView3.Rows[e.RowIndex].Cells["原料编号"].Value.ToString());
            dataGridView7.Update();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows[index3].Cells["原料数量"].Value = textBox原料数量.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)//制定生产计划
        {
            bool planok = true;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                plan.RelatedOrderId = text订单编号.Text;
                plan.ProductId = dataGridView1.Rows[i].Cells["产品编号"].Value.ToString();
               // plan.CustomerId = l编号.Text;
                plan.OrderTime = DateTime.Now;
                plan.Count =Convert.ToInt16(dataGridView1.Rows[i].Cells["数量"].Value);
                plan.PlanningTime = date交付时间.Value;
                plan.FinishTime = date完成时间.Value;
                plan.InChargePerson = Utils.GetCurrentUsername();
                if (!ppm.AddNewPlan(plan)) { MessageBox.Show("插入计划失败"); planok = false; break; };
            }
            if (planok = true) { MessageBox.Show("生产计划生成成功！"); this.Close(); }
        }
    }
}
