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
    public partial class 原料选择 : Form
    {
        private ProductionManager pm;
        private MaterialManager mm;
        private int index;

        public 原料选择()
        {
            InitializeComponent();
            mm = new MaterialManager();
            pm = new ProductionManager();
            index = 0;
        }

        private void 原料选择_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.mm.GetAllMaterials();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView1.DataSource = this.mm.GetAllMaterialByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.mm.GetAllMaterials();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        public void selectm()
        {
            try
            {
                产品原料关系 newform = (产品原料关系)this.ParentForm;
                if (textBox1.Text != "0")
                {
                    ProductMaterial pmr = new ProductMaterial();
                    pmr.MaterialCount = Convert.ToInt16(textBox1.Text);
                    pmr.ProductId = newform.产品编号;
                    pmr.MaterialId = dataGridView1.Rows[index].Cells["原料编号"].Value.ToString();
                    if (pm.AddMaterialProductRelation(pmr))
                    {
                        // MessageBox.Show("！");
                    }
                }
                else
                    MessageBox.Show("请输入产品-原材料比例的数量！");
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
         //   textBox2.Text = dataGridView1.Rows[index].Cells["原料编号"].Value.ToString();
            selectm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                selectm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index =0;
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
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
    }
}
