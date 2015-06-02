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
    public partial class 产品管理 : Form
    {
        private ProductionManager proman;
        private bool canPricing;
        private Product selectedProduct = null;

        public 产品管理()
        {
            InitializeComponent();
            this.proman = ProductionManager.getProductionManager();
            //var role = Utils.GetLogonToken().Role;
            //if (role == UserRoles.FINANCE || role == UserRoles.ADMIN)    // 财务才能报价
            //{
            //    text单价.Enabled = canPricing = true;
            //    labelNoPrice.Visible = false;
            //}
            //else
            //{
            //    text单价.Enabled = canPricing = false;
            //    labelNoPrice.Visible = true;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            添加产品 form = new 添加产品(null, this);
            form.ShowDialog();
            form.SetDesktopLocation(10, 10);
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
                    updateDataView();
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
                if (this.selectedProduct == null)
                {
                    MessageBox.Show("请先选择一个产品！");
                    return;
                }

                添加产品 form = new 添加产品(this.selectedProduct, this);
                form.ShowDialog();
                form.SetDesktopLocation(10, 10);
                
                //if (proman.AltProduct(selectedProduct))
                //{
                //    MessageBox.Show("修改产品成功！");
                //    dataGridView1.DataSource = this.proman.GetAllProducts();
                //    dataGridView1.Update();
                //}
                //else
                //    MessageBox.Show("修改失败！");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void 产品管理_Load(object sender, EventArgs e)
        {
            updateDataView();
            webBrowser1.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\工程制作指示单.htm");
        
        }

        public void updateDataView()
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
            if (e.RowIndex < 0)
            {
                return;
            }
            selectedProduct = new Product();
            var selectedRow = dataGridView1.Rows[e.RowIndex].Cells;

            text产品编号.Text = selectedRow["产品编号"].Value.ToString();
            selectedProduct.Id = int.Parse(text产品编号.Text);
            text产品名称.Text = selectedProduct.Name = selectedRow["产品名称"].Value.ToString();
            text规格.Text = selectedProduct.Standard = selectedRow["规格"].Value.ToString();
            text材质.Text = selectedProduct.Texture = selectedRow["材质"].Value.ToString();
            selectedProduct.Shift = selectedRow["变位"].Value.ToString();
            selectedProduct.RealShift = selectedRow["实测变位"].Value.ToString();
            selectedProduct.Color = selectedRow["颜色"].Value.ToString();
            selectedProduct.Price = double.Parse(selectedRow["单价"].Value.ToString());

            selectedProduct.摆放要求 = selectedRow["摆放要求"].Value.ToString();
            selectedProduct.备注 = selectedRow["备注"].Value.ToString();
            selectedProduct.比重计 = selectedRow["比重计"].Value.ToString();
            selectedProduct.边胶 = selectedRow["边胶"].Value.ToString();
            selectedProduct.补强布大小 = selectedRow["补强布大小"].Value.ToString();
            selectedProduct.布料编号 = selectedRow["布料编号"].Value.ToString();
            selectedProduct.测试夹具外内 = selectedRow["测试夹具外内"].Value.ToString();
            selectedProduct.成型机台 = selectedRow["成型机台"].Value.ToString();
            selectedProduct.成型模号 = selectedRow["成型模号"].Value.ToString();
            selectedProduct.成型上下模温度 = selectedRow["成型上下模温度"].Value.ToString();
            selectedProduct.成型时间 = selectedRow["成型时间"].Value.ToString();
            selectedProduct.成型首检变位 = selectedRow["成型首检变位"].Value.ToString();
            selectedProduct.成型压力 = selectedRow["成型压力"].Value.ToString();
            selectedProduct.打胶方式 = selectedRow["打胶方式"].Value.ToString();
            selectedProduct.单个整条切断 = selectedRow["单个整条切断"].Value.ToString();
            selectedProduct.单个整条 = selectedRow["单个整条"].Value.ToString();
            selectedProduct.单面双面点胶 = selectedRow["单面双面点胶"].Value.ToString();
            selectedProduct.刀模 = selectedRow["刀模"].Value.ToString();
            selectedProduct.刀模中心定位 = selectedRow["刀模中心定位"].Value.ToString();
            selectedProduct.导线方式 = selectedRow["导线方式"].Value.ToString();
            selectedProduct.导线规格 = selectedRow["导线规格"].Value.ToString();
            selectedProduct.导线长度 = selectedRow["导线长度"].Value.ToString();
            selectedProduct.点锡长mm = selectedRow["点锡长mm"].Value.ToString();
            selectedProduct.定型时间 = selectedRow["定型时间"].Value.ToString();
            selectedProduct.多个多条切断 = selectedRow["多个多条切断"].Value.ToString();
            selectedProduct.方向数量 = selectedRow["方向数量"].Value.ToString();
            selectedProduct.工艺要求 = selectedRow["工艺要求"].Value.ToString();
            selectedProduct.含浸比重 = selectedRow["含浸比重"].Value.ToString();
            selectedProduct.含浸转速HZ = selectedRow["含浸转速HZ"].Value.ToString();
            selectedProduct.剪边喷水 = selectedRow["剪边喷水"].Value.ToString();
            selectedProduct.胶滚压力 = selectedRow["胶滚压力"].Value.ToString();
            selectedProduct.胶水 = selectedRow["胶水"].Value.ToString();
            selectedProduct.胶水型号 = selectedRow["胶水型号"].Value.ToString();
            selectedProduct.胶水重量 = selectedRow["胶水重量"].Value.ToString();
            selectedProduct.搅拌时间 = selectedRow["搅拌时间"].Value.ToString();
            selectedProduct.开料尺寸 = selectedRow["开料尺寸"].Value.ToString();
            selectedProduct.开料要求 = selectedRow["开料要求"].Value.ToString();
            selectedProduct.内留mm = selectedRow["内留mm"].Value.ToString();
            selectedProduct.气冲压力 = selectedRow["气冲压力"].Value.ToString();
            selectedProduct.切刀模个数 = selectedRow["切刀模个数"].Value.ToString();
            selectedProduct.切断机台 = selectedRow["切断机台"].Value.ToString();
            selectedProduct.切断模 = selectedRow["切断模"].Value.ToString();
            selectedProduct.切断模架 = selectedRow["切断模架"].Value.ToString();
            selectedProduct.溶剂 = selectedRow["溶剂"].Value.ToString();
            selectedProduct.生产单重 = selectedRow["生产单重"].Value.ToString();
            selectedProduct.是否备品 = selectedRow["是否备品"].Value.ToString();
            selectedProduct.是否标签盖环保章 = selectedRow["是否标签盖环保章"].Value.ToString();
            selectedProduct.是否产品全检 = selectedRow["是否产品全检"].Value.ToString();
            selectedProduct.是否拉布成型 = selectedRow["是否拉布成型"].Value.ToString();
            selectedProduct.是否数量超交 = selectedRow["是否数量超交"].Value.ToString();
            selectedProduct.是否压纸板 = selectedRow["是否压纸板"].Value.ToString();
            selectedProduct.是否中孔加补强布 = selectedRow["是否中孔加补强布"].Value.ToString();
            selectedProduct.手动自动 = selectedRow["手动自动"].Value.ToString();
            selectedProduct.贴合方式 = selectedRow["贴合方式"].Value.ToString();
            selectedProduct.贴合机台 = selectedRow["贴合机台"].Value.ToString();
            selectedProduct.贴合模具 = selectedRow["贴合模具"].Value.ToString();
            selectedProduct.贴合压力 = selectedRow["贴合压力"].Value.ToString();
            selectedProduct.通用气冲模 = selectedRow["通用气冲模"].Value.ToString();
            selectedProduct.脱模剂 = selectedRow["脱模剂"].Value.ToString();
            selectedProduct.外留mm = selectedRow["外留mm"].Value.ToString();
            selectedProduct.线距mm = selectedRow["线距mm"].Value.ToString();
            selectedProduct.压定位板 = selectedRow["压定位板"].Value.ToString();
            selectedProduct.压纸板时间 = selectedRow["压纸板时间"].Value.ToString();
            selectedProduct.样品变位 = selectedRow["样品变位"].Value.ToString();
            selectedProduct.样品单重 = selectedRow["样品单重"].Value.ToString();
            selectedProduct.硬化剂 = selectedRow["硬化剂"].Value.ToString();
            selectedProduct.中孔模 = selectedRow["中孔模"].Value.ToString();
            selectedProduct.自动切 = selectedRow["自动切"].Value.ToString();
            selectedProduct.烤箱温度C = selectedRow["烤箱温度C"].Value.ToString();

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
            webBrowser1.ShowPageSetupDialog();
            webBrowser1.ShowPrintPreviewDialog();
        }
    }
}
