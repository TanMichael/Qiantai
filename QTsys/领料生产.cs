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
            index3=0;
        }

        private void 领料生产_Load(object sender, EventArgs e)
        {
            try
            {
                string a = "";
                dataGridView1.DataSource = this.ppm.GetAllProductPlanByTime(a);
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView2.DataSource = pm.GetAllProductsByNameEX("产品编号", dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGridView3.DataSource = pm.GetMaterialProductRelationByProduct(dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGridView2.Update();
                dataGridView3.Update();
                textBox产品.Text = dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
               
            }
            catch (Exception ex) { };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            原料选择 win = new 原料选择(textBox产品.Text);
            win.ShowDialog();
            dataGridView3.DataSource = pm.GetMaterialProductRelationByProduct(textBox产品.Text);
            dataGridView3.Update();
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
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
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
                    dataGridView2.DataSource = pm.GetMaterialProductRelationByProduct(textBox产品.Text);
                    dataGridView2.Update();
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
            textBox产品.Text = dataGridView3.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
            textBox原料.Text = dataGridView3.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
            textBox原料数量.Text = dataGridView3.Rows[e.RowIndex].Cells["原料数量"].Value.ToString();
            dataGridView7.DataSource = mt.GetAllMaterialByName("原料编号", dataGridView3.Rows[e.RowIndex].Cells["原料编号"].Value.ToString());
            dataGridView7.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //确定领料生产
            //在仓库原料里减少相关数量料






        }
    }
}
