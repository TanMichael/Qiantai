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
    public partial class 原料管理 : Form
    {
        private MaterialManager material;

        public 原料管理()
        {
            InitializeComponent();
            this.material = MaterialManager.getMaterialManager();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            原料入仓 win = new 原料入仓();
            win.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            原料出仓 win = new 原料出仓();
            win.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           /* 原料数据修改 win = new 原料数据修改();
            win.ShowDialog();*/
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

        private void 原料管理_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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
    }
}
