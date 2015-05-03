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
    public partial class 样品库存自动生成 : Form
    {
        private OrderManager odm;
        private UserManager userMgr;
        private ProductionManager pm;
        private int index3;

        public 样品库存自动生成()
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
            pm = new ProductionManager();
            index3 = 0;
        }

        private void 样品库存自动生成_Load(object sender, EventArgs e)
        {
           // WinSendMsg.row = dataGridView2.Rows.Count;
           // WinSendMsg.Oid = id;
            dataGridView1.DataSource = odm.GetAllOrderDetailsBySerial(WinSendMsg.Oid);
            dataGridView4.DataSource = odm.GetAllOrderDetailsBySerial(WinSendMsg.Oid);
            dataGridView5.DataSource = odm.GetAllOrderDetailsBySerial(WinSendMsg.Oid);
            if (!WinSendMsg.IsSampleProduct)//是否订制样品
            {
                this.tabPage1.Parent = null;
            }
            if (!WinSendMsg.IsMeterialReduce)//是否从库存取产品
            {
                this.tabPage2.Parent = null;
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //根据产品编号查询数据
            //dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString()
            dataGridView2.DataSource= pm.GetAllProductsByName("产品编号", dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
            dataGridView3.DataSource = pm.GetMaterialProductRelationByProduct(dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1 ;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)//产品原料关系
        {
            index3 = e.RowIndex;
            text原料数量.Text = dataGridView3.Rows[e.RowIndex].Cells["原料数量"].Value.ToString();
            l原料数量.Text ="生产产品【"+dataGridView3.Rows[e.RowIndex].Cells["产品编号"].Value.ToString()+"】1件须消耗原料【"+ dataGridView3.Rows[e.RowIndex].Cells["原料编号"].Value.ToString()+"】";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows[index3].Cells["原料数量"].Value = text原料数量.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
