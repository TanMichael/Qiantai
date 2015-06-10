using QTsys.Common;
using QTsys.Common.Constants;
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
        private int beUpdateId;
        private bool isUpdate;
        private 产品管理 parent;
        private ProductionManager prdMgr;
        private bool canPricing;

        public 添加产品()
        {
            InitializeComponent();
            prdMgr = new ProductionManager();
            var role = Utils.GetLogonToken().Role;
            if (role == UserRoles.FINANCE || role == UserRoles.ADMIN)    // 财务才能报价
            {
                textBox单价.Enabled = canPricing = true;
                labelNoPrice.Visible = false;
            }
            else
            {
                textBox单价.Enabled = canPricing = false;
                labelNoPrice.Visible = true;
            }
        }

        public 添加产品(Product pdt, 产品管理 p)
            : this()
        {
            if (pdt != null)
            {
                isUpdate = true;
                beUpdateId = pdt.Id;

                textBox产品名称.Text = pdt.Name;
                textBox规格.Text = pdt.Standard;
                textBox变位.Text = pdt.Shift;
                textBox实测变位.Text = pdt.RealShift;
                textBox材质.Text = pdt.Texture;
                textBox颜色.Text = pdt.Color;
                textBox单价.Text = pdt.Price.ToString();
                label库存数.Text = pdt.StockCount.ToString();

                textBox摆放要求.Text = pdt.摆放要求;
                textBox备注.Text = pdt.备注;
                textBox比重计.Text = pdt.比重计;
                textBox边胶.Text = pdt.边胶;
                textBox补强布大小.Text = pdt.补强布大小;
                textBox布料编号.Text = pdt.布料编号;
                textBox测试夹具外内.Text = pdt.测试夹具外内;
                textBox成型机台.Text = pdt.成型机台;
                textBox成型模号.Text = pdt.成型模号;
                textBox成型上下模温度.Text = pdt.成型上下模温度;
                textBox成型时间.Text = pdt.成型时间;
                textBox成型首检变位.Text = pdt.成型首检变位;
                textBox成型压力.Text = pdt.成型压力;
                textBox打胶方式.Text = pdt.打胶方式;
                textBox单个整条.Text = pdt.单个整条;
                textBox单个整条切断.Text = pdt.单个整条切断;
                textBox单面双面点胶.Text = pdt.单面双面点胶;
                textBox刀模.Text = pdt.刀模;
                textBox刀模中心定位.Text = pdt.刀模中心定位;
                textBox导线方式.Text = pdt.导线方式;
                textBox导线规格.Text = pdt.导线规格;
                textBox导线长度.Text = pdt.导线长度;
                textBox点锡长.Text = pdt.点锡长mm;
                textBox定型时间.Text = pdt.定型时间;
                textBox多个多条.Text = pdt.多个多条切断;
                textBox方向数量.Text = pdt.方向数量;
                textBox工艺要求.Text = pdt.工艺要求;
                textBox含浸比重.Text = pdt.含浸比重;
                textBox含浸转速.Text = pdt.含浸转速HZ;
                textBox剪边喷水.Text = pdt.剪边喷水;
                textBox胶滚压力.Text = pdt.胶滚压力;
                textBox胶水.Text = pdt.胶水;
                textBox胶水型号.Text = pdt.胶水型号;
                textBox胶水重量.Text = pdt.胶水重量;
                textBox搅拌时间.Text = pdt.搅拌时间;
                textBox开料尺寸.Text = pdt.开料尺寸;
                textbox开料要求.Text = pdt.开料要求;
                textBox内留.Text = pdt.内留mm;
                textBox气冲压力.Text = pdt.气冲压力;
                textBox切刀模个数.Text = pdt.切刀模个数;
                textBox切断机台.Text = pdt.切断机台;
                textBox切断模.Text = pdt.切断模;
                textBox切断模架.Text = pdt.切断模架;
                textBox溶剂.Text = pdt.溶剂;
                textBox生产单重.Text = pdt.生产单重;
                textBox是否留样.Text = pdt.是否留样;
                textBox是否备品.Text = pdt.是否备品;
                textBox是否标签盖环保章.Text = pdt.是否标签盖环保章;
                textBox是否产品全检.Text = pdt.是否产品全检;
                textBox是否拉布成型.Text = pdt.是否拉布成型;
                textBox是否数量超交.Text = pdt.是否数量超交;
                textBox是否压纸板.Text = pdt.是否压纸板;
                textBox是否中孔加补强布.Text = pdt.是否中孔加补强布;
                textBox手动自动.Text = pdt.手动自动;
                textBox贴合方式.Text = pdt.贴合方式;
                textBox贴合机台.Text = pdt.贴合机台;
                textBox贴合模具.Text = pdt.贴合模具;
                textBox贴合压力.Text = pdt.贴合压力;
                textBox通用气冲模.Text = pdt.通用气冲模;
                textBox脱模剂.Text = pdt.脱模剂;
                textBox外留.Text = pdt.外留mm;
                textBox线距.Text = pdt.线距mm;
                textBox压定位板.Text = pdt.压定位板;
                textBox压纸板时间.Text = pdt.压纸板时间;
                textBox样品变位.Text = pdt.样品变位;
                textBox样品单重.Text = pdt.样品单重;
                textBox硬化剂.Text = pdt.硬化剂;
                textBox中孔模.Text = pdt.中孔模;
                textBox自动切.Text = pdt.自动切;
                textBox烤箱温度.Text = pdt.烤箱温度C;
                textBox外贴标签要求.Text = pdt.外贴标签要求;
                textBox批准.Text = pdt.批准;
                textBox审核.Text = pdt.审核;
                textBox制作.Text = pdt.制作;
            }

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
            //if (pdt.Name == _oldName)
            //{
            //    MessageBox.Show("名字重复");
            //    return;
            //}
            pdt.Standard = textBox规格.Text;
            pdt.Shift = textBox变位.Text;
            pdt.RealShift = textBox实测变位.Text;
            pdt.Texture = textBox材质.Text;
            pdt.Color = textBox颜色.Text;
            pdt.StockCount = int.Parse(label库存数.Text);
            double price;
            if (textBox单价.Text != "" && double.TryParse(textBox单价.Text, out price))
            {
                pdt.Price = price;
            }

            pdt.摆放要求 = textBox摆放要求.Text;
            pdt.备注 = textBox备注.Text;
            pdt.比重计 = textBox比重计.Text;
            pdt.边胶 = textBox边胶.Text;
            pdt.补强布大小 = textBox补强布大小.Text;
            pdt.布料编号 = textBox布料编号.Text;
            pdt.测试夹具外内 = textBox测试夹具外内.Text;
            pdt.成型机台 = textBox成型机台.Text;
            pdt.成型模号 = textBox成型模号.Text;
            pdt.成型上下模温度 = textBox成型上下模温度.Text;
            pdt.成型时间 = textBox成型时间.Text;
            pdt.成型首检变位 = textBox成型首检变位.Text;
            pdt.成型压力 = textBox成型压力.Text;
            pdt.打胶方式 = textBox打胶方式.Text;
            pdt.单个整条 = textBox单个整条.Text;
            pdt.单个整条切断 = textBox单个整条切断.Text;
            pdt.单面双面点胶 = textBox单面双面点胶.Text;
            pdt.刀模 = textBox刀模.Text;
            pdt.刀模中心定位 = textBox刀模中心定位.Text;
            pdt.导线方式 = textBox导线方式.Text;
            pdt.导线规格 = textBox导线规格.Text;
            pdt.导线长度 = textBox导线长度.Text;
            pdt.点锡长mm = textBox点锡长.Text;
            pdt.定型时间 = textBox定型时间.Text;
            pdt.多个多条切断 = textBox多个多条.Text;
            pdt.方向数量 = textBox方向数量.Text;
            pdt.工艺要求 = textBox工艺要求.Text;
            pdt.含浸比重 = textBox含浸比重.Text;
            pdt.含浸转速HZ = textBox含浸转速.Text;
            pdt.剪边喷水 = textBox剪边喷水.Text;
            pdt.胶滚压力 = textBox胶滚压力.Text;
            pdt.胶水 = textBox胶水.Text;
            pdt.胶水型号 = textBox胶水型号.Text;
            pdt.胶水重量 = textBox胶水重量.Text;
            pdt.搅拌时间 = textBox搅拌时间.Text;
            pdt.开料尺寸 = textBox开料尺寸.Text;
            pdt.开料要求 = textbox开料要求.Text;
            pdt.内留mm = textBox内留.Text;
            pdt.气冲压力 = textBox气冲压力.Text;
            pdt.切刀模个数 = textBox切刀模个数.Text;
            pdt.切断机台 = textBox切断机台.Text;
            pdt.切断模 = textBox切断模.Text;
            pdt.切断模架 = textBox切断模架.Text;
            pdt.溶剂 = textBox溶剂.Text;
            pdt.生产单重 = textBox生产单重.Text;
            pdt.是否留样 = textBox是否留样.Text;
            pdt.是否备品 = textBox是否备品.Text;
            pdt.是否标签盖环保章 = textBox是否标签盖环保章.Text;
            pdt.是否产品全检 = textBox是否产品全检.Text;
            pdt.是否拉布成型 = textBox是否拉布成型.Text;
            pdt.是否数量超交 = textBox是否数量超交.Text;
            pdt.是否压纸板 = textBox是否压纸板.Text;
            pdt.是否中孔加补强布 = textBox是否中孔加补强布.Text;
            pdt.手动自动 = textBox手动自动.Text;
            pdt.贴合方式 = textBox贴合方式.Text;
            pdt.贴合机台 = textBox贴合机台.Text;
            pdt.贴合模具 = textBox贴合模具.Text;
            pdt.贴合压力 = textBox贴合压力.Text;
            pdt.通用气冲模 = textBox通用气冲模.Text;
            pdt.脱模剂 = textBox脱模剂.Text;
            pdt.外留mm = textBox外留.Text;
            pdt.线距mm = textBox线距.Text;
            pdt.压定位板 = textBox压定位板.Text;
            pdt.压纸板时间 = textBox压纸板时间.Text;
            pdt.样品变位 = textBox样品变位.Text;
            pdt.样品单重 = textBox样品单重.Text;
            pdt.硬化剂 = textBox硬化剂.Text;
            pdt.中孔模 = textBox中孔模.Text;
            pdt.自动切 = textBox自动切.Text;
            pdt.烤箱温度C = textBox烤箱温度.Text;
            pdt.外贴标签要求 = textBox外贴标签要求.Text;
            pdt.批准 = textBox批准.Text;
            pdt.审核 = textBox审核.Text;
            pdt.制作 = textBox制作.Text;
            try
            {
                if (isUpdate)
                {
                    pdt.Id = beUpdateId;
                    prdMgr.AltProduct(pdt);
                }
                else
                {
                    int id = prdMgr.AddNewProduct(pdt);
                }

                MessageBox.Show("操作成功！");
                parent.updateDataView();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product pdt = new Product();
            // TODO validate name unique
            pdt.Name = textBox产品名称.Text;
            //if (pdt.Name == _oldName)
            //{
            //    MessageBox.Show("名字重复");
            //    return;
            //}
            pdt.Standard = textBox规格.Text;
            pdt.Shift = textBox变位.Text;
            pdt.RealShift = textBox实测变位.Text;
            pdt.Texture = textBox材质.Text;
            pdt.Color = textBox颜色.Text;
            pdt.StockCount = int.Parse(label库存数.Text);
            double price;
            if (textBox单价.Text != "" && double.TryParse(textBox单价.Text, out price))
            {
                pdt.Price = price;
            }

            pdt.摆放要求 = textBox摆放要求.Text;
            pdt.备注 = textBox备注.Text;
            pdt.比重计 = textBox比重计.Text;
            pdt.边胶 = textBox边胶.Text;
            pdt.补强布大小 = textBox补强布大小.Text;
            pdt.布料编号 = textBox布料编号.Text;
            pdt.测试夹具外内 = textBox测试夹具外内.Text;
            pdt.成型机台 = textBox成型机台.Text;
            pdt.成型模号 = textBox成型模号.Text;
            pdt.成型上下模温度 = textBox成型上下模温度.Text;
            pdt.成型时间 = textBox成型时间.Text;
            pdt.成型首检变位 = textBox成型首检变位.Text;
            pdt.成型压力 = textBox成型压力.Text;
            pdt.打胶方式 = textBox打胶方式.Text;
            pdt.单个整条 = textBox单个整条.Text;
            pdt.单个整条切断 = textBox单个整条切断.Text;
            pdt.单面双面点胶 = textBox单面双面点胶.Text;
            pdt.刀模 = textBox刀模.Text;
            pdt.刀模中心定位 = textBox刀模中心定位.Text;
            pdt.导线方式 = textBox导线方式.Text;
            pdt.导线规格 = textBox导线规格.Text;
            pdt.导线长度 = textBox导线长度.Text;
            pdt.点锡长mm = textBox点锡长.Text;
            pdt.定型时间 = textBox定型时间.Text;
            pdt.多个多条切断 = textBox多个多条.Text;
            pdt.方向数量 = textBox方向数量.Text;
            pdt.工艺要求 = textBox工艺要求.Text;
            pdt.含浸比重 = textBox含浸比重.Text;
            pdt.含浸转速HZ = textBox含浸转速.Text;
            pdt.剪边喷水 = textBox剪边喷水.Text;
            pdt.胶滚压力 = textBox胶滚压力.Text;
            pdt.胶水 = textBox胶水.Text;
            pdt.胶水型号 = textBox胶水型号.Text;
            pdt.胶水重量 = textBox胶水重量.Text;
            pdt.搅拌时间 = textBox搅拌时间.Text;
            pdt.开料尺寸 = textBox开料尺寸.Text;
            pdt.开料要求 = textbox开料要求.Text;
            pdt.内留mm = textBox内留.Text;
            pdt.气冲压力 = textBox气冲压力.Text;
            pdt.切刀模个数 = textBox切刀模个数.Text;
            pdt.切断机台 = textBox切断机台.Text;
            pdt.切断模 = textBox切断模.Text;
            pdt.切断模架 = textBox切断模架.Text;
            pdt.溶剂 = textBox溶剂.Text;
            pdt.生产单重 = textBox生产单重.Text;
            pdt.是否留样= textBox是否留样.Text;
            pdt.是否备品 = textBox是否备品.Text;
            pdt.是否标签盖环保章 = textBox是否标签盖环保章.Text;
            pdt.是否产品全检 = textBox是否产品全检.Text;
            pdt.是否拉布成型 = textBox是否拉布成型.Text;
            pdt.是否数量超交 = textBox是否数量超交.Text;
            pdt.是否压纸板 = textBox是否压纸板.Text;
            pdt.是否中孔加补强布 = textBox是否中孔加补强布.Text;
            pdt.手动自动 = textBox手动自动.Text;
            pdt.贴合方式 = textBox贴合方式.Text;
            pdt.贴合机台 = textBox贴合机台.Text;
            pdt.贴合模具 = textBox贴合模具.Text;
            pdt.贴合压力 = textBox贴合压力.Text;
            pdt.通用气冲模 = textBox通用气冲模.Text;
            pdt.脱模剂 = textBox脱模剂.Text;
            pdt.外留mm = textBox外留.Text;
            pdt.线距mm = textBox线距.Text;
            pdt.压定位板 = textBox压定位板.Text;
            pdt.压纸板时间 = textBox压纸板时间.Text;
            pdt.样品变位 = textBox样品变位.Text;
            pdt.样品单重 = textBox样品单重.Text;
            pdt.硬化剂 = textBox硬化剂.Text;
            pdt.中孔模 = textBox中孔模.Text;
            pdt.自动切 = textBox自动切.Text;
            pdt.烤箱温度C = textBox烤箱温度.Text;
            pdt.外贴标签要求 = textBox外贴标签要求.Text;
            pdt.批准 = textBox批准.Text;
            pdt.审核 = textBox审核.Text;
            pdt.制作 = textBox制作.Text;
            try
            {
                if (isUpdate)
                {
                    pdt.Id = beUpdateId;
                    prdMgr.AltProduct(pdt);
                }
                else
                {
                    int id = prdMgr.AddNewProduct(pdt);
                }

                MessageBox.Show("操作成功！");
                parent.updateDataView();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void 添加产品_Load(object sender, EventArgs e)
        {

        }
    }
}
