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
    public partial class 领料生产 : Form
    {
        private ProductPlanManager ppm;
        private ProductionManager pm;
        private int index3;
        private MaterialManager mt;
        

        public 领料生产()
        {
            InitializeComponent();
            ppm = new ProductPlanManager();
            pm = new ProductionManager();
            mt = new MaterialManager();
          //  mat = new Material();
            index3=0;
        }

        private void 领料生产_Load(object sender, EventArgs e)
        {
            try
            {
                string a = "";
                dataGrid未生产.DataSource = this.ppm.GetAllProductPlanByStates(ProductionPlanStatus.PREPARING);
                dataGrid未生产.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGrid产品.DataSource = pm.GetAllProductsByNameEX("产品编号", dataGrid未生产.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGrid产品原料关系.DataSource = pm.GetMaterialProductRelationByProduct(dataGrid未生产.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGrid产品.Update();
                dataGrid产品原料关系.Update();
                textBox产品.Text = dataGrid未生产.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                textBox领料产品.Text = dataGrid未生产.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                textBox产品数量.Text = dataGrid未生产.Rows[e.RowIndex].Cells["产品数量"].Value.ToString();
                textBox订单编号.Text = dataGrid未生产.Rows[e.RowIndex].Cells["编号"].Value.ToString();
               
            }
            catch (Exception ex) { };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            原料选择 win = new 原料选择(textBox产品.Text);
            win.ShowDialog();
            dataGrid产品原料关系.DataSource = pm.GetMaterialProductRelationByProduct(textBox产品.Text);
            dataGrid产品原料关系.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductMaterial pmt = new ProductMaterial();
            pmt.MaterialId = textBox原料.Text;
            pmt.ProductId = textBox产品.Text;
            pmt.MaterialCount = Convert.ToInt16(textBox原料数量.Text);
            if (pm.DelMaterialProductRelation(pmt))
            {
                MessageBox.Show("删除成功");
                dataGrid产品原料关系.Rows.Remove(dataGrid产品原料关系.CurrentRow);
            }
            else { MessageBox.Show("删除失败！"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ProductMaterial pmt = new ProductMaterial();
                pmt.MaterialId = textBox原料.Text;
                pmt.ProductId = textBox产品.Text;
                pmt.MaterialCount = Convert.ToInt16(textBox原料数量.Text);
                if (pm.AltMaterialProductRelation(pmt))
                {
                    // MessageBox.Show("修改成功！");
                    dataGrid产品原料关系.DataSource = pm.GetMaterialProductRelationByProduct(textBox产品.Text);
                    dataGrid产品原料关系.Update();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch (Exception ex) { };
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index3 = e.RowIndex;
            //  text原料数量.Text = dataGridView3.Rows[e.RowIndex].Cells["原料数量"].Value.ToString();
            // l原料数量.Text = "生产产品【" + dataGridView3.Rows[e.RowIndex].Cells["产品编号"].Value.ToString() + "】1件须消耗原料【" + dataGridView3.Rows[e.RowIndex].Cells["原料编号"].Value.ToString() + "】";
            textBox产品.Text = dataGrid产品原料关系.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
            textBox原料.Text = dataGrid产品原料关系.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
            textBox原料数量.Text = dataGrid产品原料关系.Rows[e.RowIndex].Cells["原料数量"].Value.ToString();
            dataGrid原料.DataSource = mt.GetAllMaterialByName("原料编号", dataGrid产品原料关系.Rows[e.RowIndex].Cells["原料编号"].Value.ToString());
            dataGrid原料.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox领料产品.Text == "")
            {
                MessageBox.Show("领料失败！未选择产品！");
                return;
            }
            if (dataGrid未生产.RowCount<=1)
            {
                MessageBox.Show("领料失败！无未生产产品！");
                return;
            }
            try
            {
                int[] 原料编号 = new int[dataGrid产品原料关系.RowCount];
                for (int i = 0; i < dataGrid产品原料关系.RowCount; i++)
                {
                    原料编号[i] =Convert.ToInt16( dataGrid产品原料关系.Rows[i].Cells["原料编号"].Value);
                }

                领料清单生成 win = new 领料清单生成(textBox订单编号.Text,Convert.ToInt16(textBox领料产品.Text), Convert.ToInt16(textBox产品数量.Text), 原料编号);
               // 领料清单生成 win=new 领料清单生成(Convert.ToInt16(textBox领料产品.Text));
                win.ShowDialog();
                dataGrid未生产.DataSource = this.ppm.GetAllProductPlanByStates(ProductionPlanStatus.PREPARING);
                dataGrid未生产.Update();



            }
            catch (Exception ex) { };




        }
    }
}
