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
    public partial class 报价 : Form
    {
        private ProductionManager pMgr;
        private OrderManager oMgr;
        private string selectedOrderId;
        private string selectedProductId;

        public 报价()
        {
            InitializeComponent();
            oMgr = new OrderManager();
            pMgr = new ProductionManager();
        }

        private void 报价_Load(object sender, EventArgs e)
        {
            button报价.Enabled = false;
            // dataGridView样品
            dataGridView样品.DataSource = oMgr.GetFinishedSampleOrders();
            dataGridView样品.Update();
            checkBox所有没有报价.Checked = true;
        }

        private void dataGridView样品_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedOrderId = dataGridView样品.Rows[e.RowIndex].Cells["订单编号"].Value.ToString();

                if (checkBox所有没有报价.Checked)
                {
                    checkBox所有没有报价.Checked = false; // will fire change event.
                }
                else
                {
                    dataGridView产品.DataSource = pMgr.GetProductsByOrder(selectedOrderId);
                    dataGridView产品.Update();
                }
            }
            catch (Exception ex) { };
        }

        private void checkBox所有没有报价_CheckedChanged(object sender, EventArgs e)
        {
            updateDataGridView产品();
        }

        private void dataGridView产品_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                button报价.Enabled = true;
                label产品Value.Text = dataGridView产品.Rows[e.RowIndex].Cells["产品名称"].Value.ToString();
                selectedProductId = dataGridView产品.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
            }
            catch (Exception ex) { };
        }

        private void button报价_Click(object sender, EventArgs e)
        {
            double price;
            if (Double.TryParse(textBox报价.Text, out price))
            {
                if (pMgr.SetProductPrice(price, selectedProductId))
                {
                    MessageBox.Show("报价成功");
                    updateDataGridView产品();
                    button报价.Enabled = false;
                    textBox报价.Text = "";
                    label产品Value.Text = "";
                }
            }
            else
            {
                MessageBox.Show("请输入正确的数字格式");
            }
            
        }

        private void updateDataGridView产品()
        {
            bool isChecked = checkBox所有没有报价.Checked;

            if (isChecked)
            {
                dataGridView产品.DataSource = pMgr.GetProductsWithoutPrice();
            }
            else if (selectedOrderId != null)
            {
                dataGridView产品.DataSource = pMgr.GetProductsByOrder(selectedOrderId);
            }
            else
            {
                dataGridView产品.DataSource = null;
            }
            dataGridView产品.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView产品.DataSource;
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
