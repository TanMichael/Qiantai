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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
