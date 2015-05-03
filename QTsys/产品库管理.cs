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
    public partial class 产品库管理 : Form
    {
        private ProductionManager pdm;
        public 产品库管理()
        {
            InitializeComponent();
            pdm = new ProductionManager();
        }

        private void 产品库管理_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pdm.GetAllProductFlow();
            dataGridView1.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView1.DataSource = pdm.GetAllProductFlowByName(label搜索栏目.Text, text搜索内容.Text);
                        //this.material.GetAllMaterialByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = pdm.GetAllProductFlow();
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
               text产品编号.Text=  dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                date发生时间.Value=Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["发生时间"].Value);
                text类型.Text = dataGridView1.Rows[e.RowIndex].Cells["类型"].Value.ToString();
                text相关订单编号.Text = dataGridView1.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString();
                text相关计划编号.Text = dataGridView1.Rows[e.RowIndex].Cells["相关计划编号"].Value.ToString();
                text不合格产品数.Text = dataGridView1.Rows[e.RowIndex].Cells["不合格产品数"].Value.ToString();
                text当期状态.Text = dataGridView1.Rows[e.RowIndex].Cells["当期状态"].Value.ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            送货单 win = new 送货单();
            win.ShowDialog();
        }
    }
}
