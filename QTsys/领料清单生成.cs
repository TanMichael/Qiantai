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
    public partial class 领料清单生成 : Form
    {
        private int 产品;
        private int 数量;
        private int[] 原料;
        private ProductionManager pm;
        private MaterialManager mtm;

        public 领料清单生成(int 产品编号, int 产品数量, int[] 原料编号)
        {
            InitializeComponent();
            pm = new ProductionManager();
            mtm = new MaterialManager();
            产品 = 产品编号;
            数量 = 产品数量;
            原料 = 原料编号;
        }

        private void 领料清单生成_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = 产品.ToString();
                textBox2.Text = 数量.ToString();
             //   dataGridView1.DataSource = pm.GetMaterialProductRelationByProduct(textBox1.Text);
                dataGridView1.DataSource = pm.GetMaterialProductRelationByProductEx(textBox1.Text, 数量);
                dataGridView1.Update();
            }
            catch (Exception ex) { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "已完成原料编号领料：";
            try
            {
                bool ok=true;
                int num = 0;
                for (int i=0; i < dataGridView1.RowCount-1; i++)
                {
                    num = Convert.ToInt16(dataGridView1.Rows[i].Cells["库存数量"].Value) - Convert.ToInt16(dataGridView1.Rows[i].Cells["需要原料数量"].Value);
                    if (mtm.MaterialDesTo(dataGridView1.Rows[i].Cells["原料编号"].Value.ToString(), num) == true)
                    {
                        str += dataGridView1.Rows[i].Cells["原料编号"].Value.ToString() + ",";
                        //ok = false;
                    }
                    else
                    {
                        ok = false;
                        MessageBox.Show("领料失败！," + dataGridView1.Rows[i].Cells["原料编号"].Value.ToString());
                        return;
                    }
                }
                if (ok)
                {
                    MessageBox.Show("领料成功！！！");
                }
            }
            catch (Exception ex) { MessageBox.Show("领料失败！"); };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
