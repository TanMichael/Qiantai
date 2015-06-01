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
    public partial class 产品出库 : Form
    {
        private string id;//订单ID
        private ProductionManager pdm;
        private OrderManager odm;
        private ProductPlanManager ppm;

        public 产品出库(string listid)
        {
            InitializeComponent();
            id=listid;
            pdm = new ProductionManager();
            odm = new OrderManager();
            ppm = new ProductPlanManager();
        }

        private void 产品出库_Load(object sender, EventArgs e)
        {
            text相关订单编号.Text = id;
            dataGridView1.DataSource = odm.GetAllOrderByStateAndSerial(OrderStatus.PROCESSING,id);
            dataGridView1.Update();
            dataGridView2.DataSource = odm.GetAllOrderDetailsBySerialEx(id);
            dataGridView2.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            打印送货单 win = new 打印送货单(text相关订单编号.Text);
            win.ShowDialog();
        }
    }
}
