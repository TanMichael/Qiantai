using QTsys.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTsys
{
    public partial class 报价 : Form
    {
        private ProductionManager pMgr;
        private OrderManager oMgr;

        public 报价()
        {
            InitializeComponent();
            oMgr = new OrderManager();
            pMgr = new ProductionManager();
        }

        private void 报价_Load(object sender, EventArgs e)
        {
            // dataGridView样品

        }
    }
}
