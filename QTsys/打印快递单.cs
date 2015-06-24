using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTsys.Manager;
using System.IO;

namespace QTsys
{
    public partial class 打印快递单 : Form
    {
        private string 客户编号;
        private OrderManager odm;

        public 打印快递单(string id)
        {
            InitializeComponent();
            客户编号 = id;
            odm = new OrderManager();
        }

        private void 打印快递单_Load(object sender, EventArgs e)
        {
            label1客户编号.Text = 客户编号;
            try
            {
                dataGridView1.DataSource = odm.GetOrderBySerial(客户编号);
                dataGridView1.Update();
                textBox客户名称.Text = dataGridView1.Rows[0].Cells["客户名称"].Value.ToString();
                text收货地址.Text = dataGridView1.Rows[0].Cells["收货地址"].Value.ToString();
                com客户联系人.Text = dataGridView1.Rows[0].Cells["收货联系人"].Value.ToString();
                textBox结算方式.Text = dataGridView1.Rows[0].Cells["订金方式"].Value.ToString();
                text联系电话.Text = dataGridView1.Rows[0].Cells["收货电话"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void ExportExcel()
        {
            try
            {
                bool fileSaved = false;
                //Directory.GetCurrentDirectory() + "\\各种单据\\送货单.htm"
                /* 
                 SaveFileDialog sfdSaveFile = new SaveFileDialog();
                 //设置保存文件的格式
                 sfdSaveFile.DefaultExt = "xlsx";
                 //sfdSaveFile.DefaultExt = "xls";
                 sfdSaveFile.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
                 sfdSaveFile.FileName = string.Empty;
                 if (sfdSaveFile.ShowDialog() != DialogResult.OK) return;*/
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
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得《速腾》

               
                //写入字段列标题 
                /*for (int i = 0; i < mycsvdt.Columns.Count; i++)
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
                }*/
               // worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。
                //对指定列进行格式输出
                //Microsoft.Office.Interop.Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[this.table.Rows.Count + 1, 1]);
                //rg.NumberFormat = "00000000";    
                worksheet.Cells[1, 1] = "广州乔泰电子有限公司";
                worksheet.Cells[1, 2] = "020-39960882";
                worksheet.Cells[2, 1] = "广州市番禺区石基镇凌边村北约大道8号之二";

                worksheet.Cells[3, 1] = textBox客户名称.Text;
                worksheet.Cells[4, 1] = text收货地址.Text;
                worksheet.Cells[5, 1] = com客户联系人.Text;
                worksheet.Cells[5, 2] = text联系电话.Text;

                worksheet.Columns.EntireColumn.AutoFit();

              //  ((Microsoft.Office.Interop.Excel.Range)worksheet.Columns["A:A ", System.Type.Missing]).ColumnWidth = 10; //列宽
               //worksheet.Columns.Range.
                    //range.RowHeight = rowHeight; 
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(Directory.GetCurrentDirectory() + "\\各种单据\\1.xlsx");//保存复制到指定位置
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
                if (fileSaved && System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\各种单据\\1.xlsx"))
                {
                    //System.IO.File.Open(sfdSaveFile.FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                    System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\\各种单据\\1.xlsx"); //打开EXCEL
                }
            }
            catch (Exception ext) { MessageBox.Show(ext.Message); }
        }
    }
}
