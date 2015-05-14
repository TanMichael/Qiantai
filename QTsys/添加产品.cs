using QTsys.DataObjects;
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
    public partial class 添加产品 : Form
    {
        private string _oldName;
        private 新增订单 parent;
        private ProductionManager prdMgr;

        public 添加产品()
        {
            InitializeComponent();
            prdMgr = new ProductionManager();
        }

        public 添加产品(Product pdt, 新增订单 p) : this()
        {
            textBox产品名称.Text = _oldName = pdt.Name;
            textBox规格.Text = pdt.Standard;
            textBox变位.Text = pdt.Shift;
            textBox实测变位.Text = pdt.RealShift;
            textBox材质.Text = pdt.Texture;
            textBox成型模.Text = pdt.Formingdie;
            //textBox单价.Text = pdt.Price.ToString();
            textBox单位.Text = pdt.Unit;
            textBox含浸尺寸.Text = pdt.Soak;
            textBox内治具.Text = pdt.Jig;
            textBox切模号.Text = pdt.ModingNum;
            textBox生产耗时.Text = pdt.ElapsedTime;
            textBox树脂比重.Text = pdt.ResinProportion;
            textBox树脂名称.Text = pdt.ResinName;
            textBox外盘.Text = pdt.Outsize;
            textBox温度.Text = pdt.Temperate;
            textBox重量.Text = pdt.Weight;

            parent = p;
        }

        private void button取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button确定_Click(object sender, EventArgs e)
        {
            Product pdt = new Product();
            // TODO validate name unique
            pdt.Name = textBox产品名称.Text;
            if (pdt.Name == _oldName)
            {
                MessageBox.Show("名字重复");
                return;
            }
            pdt.Standard = textBox规格.Text;
            pdt.Shift = textBox变位.Text;
            pdt.RealShift = textBox实测变位.Text;
            pdt.Texture = textBox材质.Text;
            pdt.Formingdie = textBox成型模.Text;
            //pdt.Price = double.Parse(textBox单价.Text);
            pdt.Unit = textBox单位.Text;
            pdt.Soak = textBox含浸尺寸.Text;
            pdt.Jig = textBox内治具.Text;
            pdt.ModingNum = textBox切模号.Text;
            pdt.ElapsedTime = textBox生产耗时.Text;
            pdt.ResinProportion = textBox树脂比重.Text;
            pdt.ResinName = textBox树脂名称.Text;
            pdt.Outsize = textBox外盘.Text;
            pdt.Temperate = textBox温度.Text;
            pdt.Weight = textBox重量.Text;

            int id = prdMgr.AddNewProduct(pdt);

            if (id > 0)
            {
                var dataGridView2 = parent.dataGridView2;
                string[] rowadd = new string[] { id.ToString(), pdt.Name, "0", pdt.Price.ToString(), "1", "0" };
                dataGridView2.Rows.Add(rowadd);

                // for no price item
                parent.check样品.Checked = true;
                parent.check样品.Enabled = false;

                var dataGridView1 = parent.dataGridView1;
                dataGridView1.DataSource = this.prdMgr.GetAllProducts();
                dataGridView1.Update();
            }

            this.Close();
        }
    }
}
