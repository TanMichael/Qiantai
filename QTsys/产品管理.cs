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
    public partial class 产品管理 : Form
    {
        private ProductionManager proman;

        public 产品管理()
        {
            InitializeComponent();
            this.proman = ProductionManager.getProductionManager();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            产品入库 win = new 产品入库();
            win.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            产品出库 win = new 产品出库();
            win.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            产品数据修改 win = new 产品数据修改();
            win.ShowDialog();
        }

        private void 产品管理_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.proman.GetAllProducts();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                text产品编号.Text = dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                text产品名称.Text = dataGridView1.Rows[e.RowIndex].Cells["产品名称"].Value.ToString();
                text规格.Text = dataGridView1.Rows[e.RowIndex].Cells["规格"].Value.ToString();
                text材质.Text = dataGridView1.Rows[e.RowIndex].Cells["材质"].Value.ToString();
                text变位.Text = dataGridView1.Rows[e.RowIndex].Cells["变位"].Value.ToString();
                text实测变位.Text = dataGridView1.Rows[e.RowIndex].Cells["实测变位"].Value.ToString();
                text温度.Text = dataGridView1.Rows[e.RowIndex].Cells["温度"].Value.ToString();
                text生产耗时.Text = dataGridView1.Rows[e.RowIndex].Cells["生产耗时"].Value.ToString();
                text压力.Text = dataGridView1.Rows[e.RowIndex].Cells["压力"].Value.ToString();
                text树脂名称.Text = dataGridView1.Rows[e.RowIndex].Cells["树脂名称"].Value.ToString();
                text树脂比重.Text = dataGridView1.Rows[e.RowIndex].Cells["树脂比重"].Value.ToString();
                text含浸尺寸.Text = dataGridView1.Rows[e.RowIndex].Cells["含浸尺寸"].Value.ToString();
                text外盘.Text = dataGridView1.Rows[e.RowIndex].Cells["外盘"].Value.ToString();
                text内治具.Text = dataGridView1.Rows[e.RowIndex].Cells["内治具"].Value.ToString();
                text重量.Text = dataGridView1.Rows[e.RowIndex].Cells["重量"].Value.ToString();
                text成型模.Text = dataGridView1.Rows[e.RowIndex].Cells["成型模"].Value.ToString();
                text切模号.Text = dataGridView1.Rows[e.RowIndex].Cells["切模号"].Value.ToString();
                text单位.Text = dataGridView1.Rows[e.RowIndex].Cells["单位"].Value.ToString();
                text单价.Text = dataGridView1.Rows[e.RowIndex].Cells["单价"].Value.ToString();
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
                    dataGridView1.DataSource = this.proman.GetAllProductsByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.proman.GetAllProducts();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            产品原料关系 win = new 产品原料关系();
            win.ShowDialog();
        }
    }
}
