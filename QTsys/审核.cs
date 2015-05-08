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
using QTsys.Manager;
using QTsys.DataObjects;
using QTsys.Common.Constants;
using QTsys.DAO;

namespace QTsys
{
    public partial class 审核 : Form
    {
        OperationAuditDAO showdata;
        public 审核()
        {
            InitializeComponent();
            showdata = new OperationAuditDAO();
        }

        private void 审核_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = showdata.GetAllMsg();
                dataGridView1.Update();
            }
            catch (Exception ex) { };
        }
    }
}
