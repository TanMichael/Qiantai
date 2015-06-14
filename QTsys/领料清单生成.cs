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
using QTsys.Common;
using QTsys.DAO;

namespace QTsys
{
    public partial class 领料清单生成 : Form
    {
        private string 订单;
        private int 产品;
        private int 数量;
        private int[] 原料;
        private ProductionManager pm;
        private MaterialManager mtm;
        private ProductPlanManager ppm;
        private MaterialManager material;
        private int select原料;

        public 领料清单生成(string 订单编号, int 产品编号, int 产品数量, int[] 原料编号)
        {
            InitializeComponent();
            pm = new ProductionManager();
            mtm = new MaterialManager();
            ppm = new ProductPlanManager();
            material = new MaterialManager();
            订单 = 订单编号;
            产品 = 产品编号;
            数量 = 产品数量;
            原料 = 原料编号;
            select原料 = -1;
        }

        private void 领料清单生成_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = 产品.ToString();
                textBox2.Text = 数量.ToString();
                textBox订单.Text = 订单.ToString();
                //   dataGridView1.DataSource = pm.GetMaterialProductRelationByProduct(textBox1.Text);
                dataGridView1.DataSource = pm.GetMaterialProductRelationByProductEx(textBox1.Text, 数量);
                dataGridView1.Update();
                //

            }
            catch (Exception ex) { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "已完成原料编号领料：";
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells["供应商"].Value.ToString() == "")
                {
                    MessageBox.Show("请选择供应商和单价！");
                    return;
                }
            }
            try
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells["库存数量"].Value) <= Convert.ToInt32(dataGridView1.Rows[i].Cells["供应商余料"].Value))
                    {
                        MessageBox.Show("领料失败:\n\r有原料库存不足！此供应商没有足够的原料在仓库！");
                        return;
                    }

                }
                bool ok = true;
                int num = 0;
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    num = Convert.ToInt32(dataGridView1.Rows[i].Cells["库存数量"].Value) - Convert.ToInt32(dataGridView1.Rows[i].Cells["需要原料数量"].Value);
                    if (mtm.MaterialDesTo(dataGridView1.Rows[i].Cells["原料编号"].Value.ToString(), num) == true)
                    {
                        str += dataGridView1.Rows[i].Cells["原料编号"].Value.ToString() + ",";
                        //ok = false;

                        //*****************************
                        MaterialDAO at = new MaterialDAO();
                        MaterialFlow mtf = new MaterialFlow();
                        //mtf.Id = com原料编号
                        mtf.Type = "领料生产";
                        mtf.FlowCount = 0 - Convert.ToInt32(dataGridView1.Rows[i].Cells["需要原料数量"].Value);
                        mtf.MaterialId = Convert.ToInt32(dataGridView1.Rows[i].Cells["原料编号"].Value);
                        //供应商选择
                        mtf.Supplier = dataGridView1.Rows[i].Cells["供应商"].Value.ToString();
                        mtf.Price = Convert.ToDouble(dataGridView1.Rows[i].Cells["单价"].Value);
                        mtf.Operator = Utils.GetCurrentUsername();
                        mtf.OccurredTime = DateTime.Now;

                        String name = text原料名称.Text;//原料名称

                        if (material.AddNewMaterialEx(mtf, name, text单位.Text))
                        {
                            com供应商.Text = "";
                            // text单价.Text = "";
                            //  text单位.Text = "";
                            text原料名称.Text = "";
                        }

                        //*****************************
                    }
                    else
                    {
                        ok = false;
                        MessageBox.Show("领料失败！此原料为," + dataGridView1.Rows[i].Cells["原料编号"].Value.ToString());
                        return;
                    }
                }
                if (ok)
                {
                    if (ppm.UpdatePlanStatus(ProductionPlanStatus.PROCESSING, textBox订单.Text))
                    {
                        MessageBox.Show("领料成功！！！");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("领料失败！");
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show("领料失败！"); };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                select原料 = e.RowIndex;
                text原料名称.Text = dataGridView1.CurrentRow.Cells["原料名称"].Value.ToString();
                text单位.Text = dataGridView1.CurrentRow.Cells["单位"].Value.ToString();
                text需要原料数量.Text = dataGridView1.CurrentRow.Cells["需要原料数量"].Value.ToString();
                dataGridView2.DataSource = this.material.GetAllMaterialFlowByNameEX("原料编号", dataGridView1.CurrentRow.Cells["原料编号"].Value.ToString());
                dataGridView2.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); };
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //text单价.Text = dataGridView2.CurrentRow.Cells["供应单价"].Value.ToString();
                text单价.Text = "";
                // text原料名称.Text = dataGridView2.CurrentRow.Cells["原料名称"].Value.ToString();
                //  text单位.Text = dataGridView2.CurrentRow.Cells["单位"].Value.ToString();
                com供应商.Text = dataGridView2.CurrentRow.Cells["供应商"].Value.ToString();
                dataGridView1.Rows[select原料].Cells["供应商"].Value = dataGridView2.CurrentRow.Cells["供应商"].Value.ToString();
                
           //     dataGridView1.Rows[select原料].Cells["单价"].Value = dataGridView2.CurrentRow.Cells["供应单价"].Value.ToString();
                //text余料
                int 余料 = 0;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (dataGridView2.Rows[i].Cells["供应商"].Value.ToString() == com供应商.Text)
                    {
                        余料 += Convert.ToInt32(dataGridView2.Rows[i].Cells["数量"].Value);
                    }
                }
                text余料.Text = 余料.ToString();
                dataGridView1.Rows[select原料].Cells["供应商余料"].Value = text余料.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); };
        }
    }
}
