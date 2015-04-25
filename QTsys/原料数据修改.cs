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
    public partial class 原料数据修改 : Form
    {
        private MaterialManager material;

        public 原料数据修改()
        {
            InitializeComponent();
            this.material = MaterialManager.getMaterialManager();
        }

        private void 原料数据修改_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.material.GetAllMaterials();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                text原料编号.Text = dataGridView1.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
                text原料名称.Text = dataGridView1.Rows[e.RowIndex].Cells["原料名称"].Value.ToString();
                text单位.Text = dataGridView1.Rows[e.RowIndex].Cells["单位"].Value.ToString();
                text库存数量.Text = dataGridView1.Rows[e.RowIndex].Cells["库存数量"].Value.ToString();
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
                Material mtl = new Material();
                mtl.Id = Convert.ToInt16(text原料编号.Text);
                mtl.Name = text原料名称.Text;
                mtl.Unit = text单位.Text;
                mtl.StockCount = Convert.ToInt16(text库存数量.Text);
                if (this.material.AltMaterials(mtl))
                {
                    MessageBox.Show("原料[" + text原料编号.Text + "]数据修改成功！");
                    dataGridView1.DataSource = this.material.GetAllMaterials();
                    dataGridView1.Update();
                }
                else { MessageBox.Show("修改失败！"); }
            }
            catch (Exception ex) { MessageBox.Show("数据修改失败！"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Material mt = new Material();
                mt.Name = text原料名称.Text;
                mt.Unit = text单位.Text;
                mt.StockCount = Convert.ToInt16(text库存数量.Text);
                if (this.material.AddNewMaterial(mt))
                {
                    MessageBox.Show("原料[" + text原料名称.Text + "]插入成功！");
                    dataGridView1.DataSource = this.material.GetAllMaterials();
                    dataGridView1.Update();
                }
                else { MessageBox.Show("插入失败！"); }
            }
            catch (Exception ex) { MessageBox.Show("数据插入失败！"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Material mt = new Material();
                mt.Name = text原料名称.Text;
                mt.Unit = text单位.Text;
                mt.StockCount = Convert.ToInt16(text库存数量.Text);
                if (this.material.DelMaterial(text原料编号.Text))
                {
                    MessageBox.Show("原料[" + text原料名称.Text + "]删除成功！");
                    dataGridView1.DataSource = this.material.GetAllMaterials();
                    dataGridView1.Update();
                }
                else { MessageBox.Show("删除失败！"); }
            }
            catch (Exception ex) { MessageBox.Show("数据删除失败！"); }
        }
    }
}
