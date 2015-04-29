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
    public partial class 销售管理 : Form
    {
        private OrderManager odm;

        public 销售管理()
        {
            InitializeComponent();
            odm = new OrderManager();
        }

        private void 销售管理_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.odm.GetAllSells();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }
    }
}
