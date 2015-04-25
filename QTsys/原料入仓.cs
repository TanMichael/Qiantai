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
    public partial class 原料入仓 : Form
    {
        private MaterialManager material;

        public 原料入仓()
        {
            InitializeComponent();
            this.material = MaterialManager.getMaterialManager();
        }

        private void 原料入仓_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.material.GetAllMaterials();
                dataGridView1.Update();
                dataGridView2.DataSource = this.material.GetAllMaterialFlow();
                dataGridView2.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//关联
        {
            try
            {

                com原料编号.Text= dataGridView1.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
                text原料名称.Text = this.material.GetMaterialNameBySerial(com原料编号.Text);
                text单位.Text = dataGridView1.Rows[e.RowIndex].Cells["单位"].Value.ToString();
               // text编号.Text = dataGridView2.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                text类型.Text = "";
                text库存数量.Text = "";
                //com原料编号.Text = dataGridView2.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
               // com供应商.Text = dataGridView2.Rows[e.RowIndex].Cells["供应商"].Value.ToString();
               // text供应单价.Text = dataGridView2.Rows[e.RowIndex].Cells["供应单价"].Value.ToString();
                // text操作员.Text = dataGridView2.Rows[e.RowIndex].Cells["操作员"].Value.ToString();
             //   text原料名称.Text = this.material.GetMaterialNameBySerial(com原料编号.Text);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView1.DataSource = this.material.GetAllMaterialByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.material.GetAllMaterials();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                text编号.Text = dataGridView2.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                text类型.Text = dataGridView2.Rows[e.RowIndex].Cells["类型"].Value.ToString();
                text库存数量.Text = dataGridView2.Rows[e.RowIndex].Cells["库存数量"].Value.ToString();
                com原料编号.Text = dataGridView2.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
                com供应商.Text = dataGridView2.Rows[e.RowIndex].Cells["供应商"].Value.ToString();
                text供应单价.Text = dataGridView2.Rows[e.RowIndex].Cells["供应单价"].Value.ToString();
               // text操作员.Text = dataGridView2.Rows[e.RowIndex].Cells["操作员"].Value.ToString();
                text原料名称.Text = this.material.GetMaterialNameBySerial(com原料编号.Text);
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView2.DataSource = this.material.GetAllMaterialFlowByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView2.Update();
                }
                else
                {
                    dataGridView2.DataSource = this.material.GetAllMaterialFlow();
                    dataGridView2.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label搜索栏目.Text = dataGridView2.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (text单位.Text == "")
            {
                MessageBox.Show("更新库存失败！未填写单位");
                return;
            }
            try
            {
                MaterialDAO at = new MaterialDAO();
                MaterialFlow mtf = new MaterialFlow();
                mtf.Id = Convert.ToUInt16(text编号.Text);
                mtf.Type = text类型.Text;
                mtf.StockCount = Convert.ToUInt16(text库存数量.Text);
                mtf.MaterialId = Convert.ToUInt16(com原料编号.Text);
                mtf.Supplier = com供应商.Text;
                mtf.Price = Convert.ToDouble(text供应单价.Text);
                mtf.Operator = text操作员.Text;
                //原料名称this.material.GetMaterialNameBySerial(com原料编号.Text);
                String name = this.material.GetMaterialNameBySerial(com原料编号.Text);
                if (material.AddNewMaterialEx(mtf, name, text单位.Text))
                // if(at.AddNewMaterialFlow(mtf, name, text单位.Text))
                {
                    MessageBox.Show("[" + name + "]更新库存成功！");
                    dataGridView1.DataSource = this.material.GetAllMaterials();
                    dataGridView1.Update();
                    dataGridView2.DataSource = this.material.GetAllMaterialFlow();
                    dataGridView2.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新库存失败！" + ex.ToString());
            }
        }
    }
}
