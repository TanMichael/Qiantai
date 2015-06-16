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
    public partial class 产品库管理 : Form
    {
        private ProductionManager pdm;
        private OrderManager odm;
        private ProductPlanManager ppm;

        private string selectedOrderId = "-9999";
        private string selectedOrderStatus = "";

        public 产品库管理()
        {
            InitializeComponent();
            pdm = new ProductionManager();
            odm = new OrderManager();
            ppm = new ProductPlanManager();
        }

        private void 产品库管理_Load(object sender, EventArgs e)
        {
            initGrid();
        }

        private void initGrid()
        {
            dataGridView产品进出库.DataSource = pdm.GetAllProductFlow();
            dataGridView产品进出库.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView产品进出库.DataSource = pdm.GetAllProductFlowByName(label搜索栏目.Text, text搜索内容.Text);
                        //this.material.GetAllMaterialByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView产品进出库.Update();
                }
                else
                {
                    dataGridView产品进出库.DataSource = pdm.GetAllProductFlow();
                    dataGridView产品进出库.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                text编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                text产品编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                date发生时间.Value = Convert.ToDateTime(dataGridView产品进出库.Rows[e.RowIndex].Cells["发生时间"].Value);
                text类型.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["类型"].Value.ToString();
                text相关订单编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString();
                text相关计划编号.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["相关计划编号"].Value.ToString();
                text不合格产品数.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["不合格产品数"].Value.ToString();
                text当期状态.Text = dataGridView产品进出库.Rows[e.RowIndex].Cells["当前状态"].Value.ToString();

                //dataGridView订单
                dataGridView产品信息.DataSource = pdm.GetAllProductsByNameEX("产品编号", dataGridView产品进出库.Rows[e.RowIndex].Cells["产品编号"].Value.ToString());
                dataGridView产品信息.Update();
                dataGridView订单.DataSource = odm.GetOrderBySerial(dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString());
                dataGridView订单.Update();
                //_____________________________________________________
                dataGridView完成情况.DataSource = odm.GetOrderFinish(dataGridView产品进出库.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString());
                dataGridView完成情况.Update();
                //_____________________________________________________
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label搜索栏目.Text = dataGridView产品进出库.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            产品入库 win = new 产品入库();
            win.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedOrderId == "-9999")
            {
                MessageBox.Show("请选择一个订单进行出库");
                return;
            }

            if (selectedOrderStatus == OrderStatus.SHIPPED || selectedOrderStatus == OrderStatus.SUCCEED)
            {
                MessageBox.Show("该订单已出库");
                return;
            }

            产品出库 win = new 产品出库(selectedOrderId);
            win.ShowDialog();

            initGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            产品数据修改 win = new 产品数据修改();
            win.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //产品出库操作
            打印送货单 win = new 打印送货单(selectedOrderId);
            win.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (odm.UpdateOrderStatus(OrderStatus.SHIPPED, text相关订单编号.Text))
            {
                pdm.UpdataProductByStatus(ProductionStatus.OUT, text相关订单编号.Text);
                MessageBox.Show("订单产品确定打包发货！");
            //    dataGridView产品进出库.DataSource = pdm.ge
               // dataGridView产品进出库.Update();
            }else
                MessageBox.Show("操作失败！");

        }

        private void dataGridView订单_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedOrderId = dataGridView订单.Rows[e.RowIndex].Cells["订单编号"].Value.ToString();
            selectedOrderStatus = dataGridView订单.Rows[e.RowIndex].Cells["订单状态"].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView产品进出库.DataSource;
            ExportExcel(dt);
        }
        private void ExportExcel(DataTable mycsvdt)
        {
            if (mycsvdt == null || mycsvdt.Rows.Count < 0)
            {
                return;
            }
            bool fileSaved = false;
            SaveFileDialog sfdSaveFile = new SaveFileDialog();
            //设置保存文件的格式
            sfdSaveFile.DefaultExt = "xlsx";
            //sfdSaveFile.DefaultExt = "xls";
            sfdSaveFile.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
            sfdSaveFile.FileName = string.Empty;
            if (sfdSaveFile.ShowDialog() != DialogResult.OK) return;
            //电脑Excel程序
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel程序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Workbook集合
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            //Workbook
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //WorkSheet
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
            //写入字段列标题 
            for (int i = 0; i < mycsvdt.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = mycsvdt.Columns[i].ColumnName;
            }
            //写入数值 
            for (int r = 0; r < mycsvdt.Rows.Count; r++)
            {
                for (int i = 0; i < mycsvdt.Columns.Count; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = mycsvdt.Rows[r][i];
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。
            //对指定列进行格式输出
            //Microsoft.Office.Interop.Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[this.table.Rows.Count + 1, 1]);
            //rg.NumberFormat = "00000000";    
            try
            {
                workbook.Saved = true;
                workbook.SaveCopyAs(sfdSaveFile.FileName);//保存复制到指定位置
                fileSaved = true;
            }
            catch (Exception ex)
            {
                fileSaved = false;
                MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
            }
            finally
            {
                workbooks.Close();
                xlApp.Quit();
                GC.Collect();//强行销毁 
            }
            if (fileSaved && System.IO.File.Exists(sfdSaveFile.FileName))
            {
                //System.IO.File.Open(sfdSaveFile.FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                System.Diagnostics.Process.Start(sfdSaveFile.FileName); //打开EXCEL
            }
        }

    }
}
