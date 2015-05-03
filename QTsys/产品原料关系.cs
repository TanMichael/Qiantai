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
    public partial class 产品原料关系 : Form
    {
        private OrderManager odm;
        private UserManager userMgr;
        private ProductionManager pm;
        private MaterialManager mm;
        
        public string 产品编号;
        public 产品原料关系()
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
            pm = new ProductionManager();
            mm = new MaterialManager();
           // win = new 原料选择();
            产品编号 = "0";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView2.DataSource = pm.GetMaterialProductRelationByProduct(dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGridView2.Update();
            }
            catch (Exception ex){};
        }

        private void 产品原料关系_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.pm.GetAllProducts();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox产品.Text = dataGridView2.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
            textBox原料.Text = dataGridView2.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
            textBox原料数量.Text = dataGridView2.Rows[e.RowIndex].Cells["原料数量"].Value.ToString();
            dataGridView3.DataSource = mm.GetAllMaterialByName("原料编号", dataGridView2.Rows[e.RowIndex].Cells["原料编号"].Value.ToString());
            产品编号 = dataGridView2.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
        }

        private void textBox原料数量_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ProductMaterial pmt = new ProductMaterial();
            pmt.MaterialId = textBox原料.Text;
            pmt.ProductId=textBox产品.Text;
            pmt.MaterialCount=Convert.ToInt16( textBox原料数量.Text);
            if (pm.DelMaterialProductRelation(pmt))
            {
                MessageBox.Show("删除成功");
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
            }
            else { MessageBox.Show("删除失败！"); }
        }

        public void UpdateT2()
        {
            try
            {
                ProductMaterial pmt = new ProductMaterial();
                pmt.MaterialId = textBox原料.Text;
                pmt.ProductId = textBox产品.Text;
                pmt.MaterialCount = Convert.ToInt16(textBox原料数量.Text);
                if (pm.AltMaterialProductRelation(pmt))
                {
                   // MessageBox.Show("修改成功！");
                    dataGridView2.DataSource = pm.GetMaterialProductRelationByProduct(textBox产品.Text);
                    dataGridView2.Update();
                }
                else
                {
                    MessageBox.Show("修改失败！"); 
                }
            }
            catch (Exception ex) { };
        }

        private void textBox原料_TextChanged(object sender, EventArgs e)
        {
           // UpdateT2();
        }

        private void textBox原料数量_TextChanged(object sender, EventArgs e)
        {
            if (textBox原料数量.Focused == true) { 
                //
                UpdateT2(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            原料选择 win = new 原料选择(textBox产品.Text);
            win.ShowDialog();
            dataGridView2.DataSource = pm.GetMaterialProductRelationByProduct(textBox产品.Text);
            dataGridView2.Update();
        }
    }
}
