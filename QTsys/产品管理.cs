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
using System.IO;
using QTsys.Common.Constants;

namespace QTsys
{
    public partial class 产品管理 : Form
    {
        private ProductionManager proman;
        private bool canPricing;

        public 产品管理()
        {
            InitializeComponent();
            this.proman = ProductionManager.getProductionManager();
            var role = Utils.GetLogonToken().Role;
            if (role == UserRoles.FINANCE || role == UserRoles.ADMIN)    // 财务才能报价
            {
                text单价.Enabled = canPricing = true;
                labelNoPrice.Visible = false;
            }
            else
            {
                text单价.Enabled = canPricing = false;
                labelNoPrice.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Product pdt = new Product();
                pdt.Name = text产品名称.Text;
                pdt.Standard = text规格.Text;
                pdt.Texture = text材质.Text;
                pdt.Shift = text变位.Text;
                pdt.RealShift = text实测变位.Text;
                pdt.Temperate = text温度.Text;
                pdt.ElapsedTime = text生产耗时.Text;
                pdt.Presure = text压力.Text;
                pdt.ResinName = text树脂名称.Text;
                pdt.ResinProportion = text树脂比重.Text;
                pdt.Soak = text含浸尺寸.Text;
                pdt.Outsize = text外盘.Text;
                pdt.Jig = text内治具.Text;
                pdt.Weight = text重量.Text;
                pdt.Formingdie = text成型模.Text;
                pdt.ModingNum = text切模号.Text;
                pdt.Unit = text单位.Text;
                pdt.Price = canPricing ? Convert.ToDouble(text单价.Text) : 0d;
                pdt.StockCount = Convert.ToInt16(text库存数量.Text);
                if (proman.AddNewProduct(pdt) > 0)
                {
                    MessageBox.Show("增加新产品成功！");
                    dataGridView1.DataSource = this.proman.GetAllProducts();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("增加失败！");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // validation
                if (text产品编号.Text == "")
                {
                    MessageBox.Show("请先选择一个产品！");
                    return;
                }

                if (proman.DelProduct(text产品编号.Text))
                {
                    MessageBox.Show("删除产品成功！");
                    dataGridView1.DataSource = this.proman.GetAllProducts();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("删除失败！");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // validation
                if (text产品编号.Text == "")
                {
                    MessageBox.Show("请先选择一个产品！");
                    return;
                }

                Product pdt = new Product();
                pdt.Id = Convert.ToInt32(text产品编号.Text);
                pdt.Name = text产品名称.Text;
                pdt.Standard = text规格.Text;
                pdt.Texture = text材质.Text;
                pdt.Shift = text变位.Text;
                pdt.RealShift = text实测变位.Text;
                pdt.Temperate = text温度.Text;
                pdt.ElapsedTime = text生产耗时.Text;
                pdt.Presure = text压力.Text;
                pdt.ResinName = text树脂名称.Text;
                pdt.ResinProportion = text树脂比重.Text;
                pdt.Soak = text含浸尺寸.Text;
                pdt.Outsize = text外盘.Text;
                pdt.Jig = text内治具.Text;
                pdt.Weight = text重量.Text;
                pdt.Formingdie = text成型模.Text;
                pdt.ModingNum = text切模号.Text;
                pdt.Unit = text单位.Text;
                pdt.Price = Convert.ToDouble(text单价.Text);
                pdt.StockCount = Convert.ToInt16(text库存数量.Text);
                if (proman.AltProduct(pdt))
                {
                    MessageBox.Show("修改产品成功！");
                    dataGridView1.DataSource = this.proman.GetAllProducts();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
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
            try
            {
                text产品编号.Text = dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                text产品名称.Text = dataGridView1.Rows[e.RowIndex].Cells["产品名称"].Value.ToString();
                text规格.Text = dataGridView1.Rows[e.RowIndex].Cells["规格"].Value.ToString();
                text材质.Text = dataGridView1.Rows[e.RowIndex].Cells["材质"].Value.ToString();
                text变位.Text = dataGridView1.Rows[e.RowIndex].Cells["变位"].Value.ToString();
                text实测变位.Text = dataGridView1.Rows[e.RowIndex].Cells["实测变位"].Value.ToString();
                text温度.Text = dataGridView1.Rows[e.RowIndex].Cells["温度"].Value.ToString();
                text生产耗时.Text = dataGridView1.Rows[e.RowIndex].Cells["生产耗时"].Value.ToString();
                text压力.Text = dataGridView1.Rows[e.RowIndex].Cells["压力"].Value.ToString();
                text树脂名称.Text = dataGridView1.Rows[e.RowIndex].Cells["树脂名称"].Value.ToString();
                text树脂比重.Text = dataGridView1.Rows[e.RowIndex].Cells["树脂比重"].Value.ToString();
                text含浸尺寸.Text = dataGridView1.Rows[e.RowIndex].Cells["含浸尺寸"].Value.ToString();
                text外盘.Text = dataGridView1.Rows[e.RowIndex].Cells["外盘"].Value.ToString();
                text内治具.Text = dataGridView1.Rows[e.RowIndex].Cells["内治具"].Value.ToString();
                text重量.Text = dataGridView1.Rows[e.RowIndex].Cells["重量"].Value.ToString();
                text成型模.Text = dataGridView1.Rows[e.RowIndex].Cells["成型模"].Value.ToString();
                text切模号.Text = dataGridView1.Rows[e.RowIndex].Cells["切模号"].Value.ToString();
                text单位.Text = dataGridView1.Rows[e.RowIndex].Cells["单位"].Value.ToString();
                text单价.Text = dataGridView1.Rows[e.RowIndex].Cells["单价"].Value.ToString();
                text库存数量.Text = dataGridView1.Rows[e.RowIndex].Cells["库存数量"].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label搜索栏目.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView1.DataSource = this.proman.GetAllProductsByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.proman.GetAllProducts();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            产品原料关系 win = new 产品原料关系(text产品编号.Text);
            win.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //WebBrowser web = new WebBrowser();
            webBrowser1.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\工程制作指示单.htm");
            webBrowser1.ShowPageSetupDialog();
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}
