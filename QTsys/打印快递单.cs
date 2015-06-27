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
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                //速腾
                if(radioButton1.Checked==true)
                {
                    worksheet.Cells[2, 1] = "广州乔泰电子有限公司";
                    worksheet.Cells[1, 2] = "020-39960882";
                    worksheet.Cells[3, 1] = "广州市番禺区石基镇凌边村北约大道8号之二";

                    //worksheet.Cells[4, 1] = textBox客户名称.Text;
                    worksheet.Cells[6, 1] = text收货地址.Text;
                    worksheet.Cells[4, 1] = com客户联系人.Text;
                    worksheet.Cells[4, 2] = text联系电话.Text;

                    worksheet.Cells[9, 3] ="签回单";
                    worksheet.Cells[10, 3] = DateTime.Now;

                    worksheet.Columns.EntireColumn.ShrinkToFit = true;

                    worksheet.Cells.get_Range("C9").Font.Size = 15;
                    worksheet.Cells.get_Range("C9").HorizontalAlignment = HorizontalAlignment.Center;
                    worksheet.Cells.get_Range("C9").Font.Bold = true;
                    worksheet.Cells.get_Range("A6", "B6").MergeCells = true;
                    worksheet.Cells.get_Range("A3", "B3").MergeCells = true;

                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Columns.ColumnWidth = 30;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 2]).Columns.ColumnWidth = 15;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 3]).Columns.ColumnWidth = 22; 
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Rows.RowHeight = 11;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1]).Rows.RowHeight = 21;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 1]).Rows.RowHeight = 34;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[4, 1]).Rows.RowHeight = 21;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[5, 1]).Rows.RowHeight = 21;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[6, 1]).Rows.RowHeight = 53;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[7, 1]).Rows.RowHeight = 45;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[8, 1]).Rows.RowHeight = 28;
                }
                //运通
                if (radioButton2.Checked == true)
                {
                    worksheet.Cells[2, 1] = "广州乔泰电子有限公司";
                    worksheet.Cells[4, 1] = "020-39960882";
                    worksheet.Cells[3, 1] = "广州市番禺区石基镇凌边村北约大道8号之二";

                    worksheet.Cells[2, 3] = textBox客户名称.Text;
                    worksheet.Cells[3, 3] = text收货地址.Text;
                    worksheet.Cells[4, 4] = com客户联系人.Text;
                    worksheet.Cells[4, 3] = text联系电话.Text;

                    worksheet.Cells[6, 5] = "签回单";
                    worksheet.Cells[7, 1] = DateTime.Now;

                    worksheet.Columns.EntireColumn.ShrinkToFit = true;

                    worksheet.Cells.get_Range("E6").Font.Size = 15;
                    worksheet.Cells.get_Range("E6").HorizontalAlignment = HorizontalAlignment.Center;
                    worksheet.Cells.get_Range("E6").Font.Bold = true;
                    worksheet.Cells.get_Range("B3", "B3").MergeCells = true;
                    worksheet.Cells.get_Range("C3", "D3").MergeCells = true;
                   // worksheet.Cells.get_Range( "D4","E5").MergeCells = true;

                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Columns.ColumnWidth = 30;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 2]).Columns.ColumnWidth = 3;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 3]).Columns.ColumnWidth = 20;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 4]).Columns.ColumnWidth = 10;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 5]).Columns.ColumnWidth = 15;

                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Rows.RowHeight = 11;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1]).Rows.RowHeight = 21;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 1]).Rows.RowHeight = 43;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[4, 1]).Rows.RowHeight = 34;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[5, 1]).Rows.RowHeight = 120;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[6, 1]).Rows.RowHeight = 20;
;
                }
                //联昊通
                if (radioButton3.Checked == true)
                {
                    worksheet.Cells[2, 1] = "广州乔泰电子有限公司";
                    worksheet.Cells[5, 1] = "020-39960882";
                    worksheet.Cells[4, 1] = "广州市番禺区石基镇凌边村北约大道8号之二";

                    worksheet.Cells[7, 1] = textBox客户名称.Text;
                    worksheet.Cells[8, 1] = text收货地址.Text;
                    worksheet.Cells[10, 2] = com客户联系人.Text;
                    worksheet.Cells[10, 1] = text联系电话.Text;

                    worksheet.Cells[11, 2] = "签回单";
                    worksheet.Cells[7, 4] = DateTime.Now;

                    worksheet.Columns.EntireColumn.ShrinkToFit = true;

                    worksheet.Cells.get_Range("B11").Font.Size = 15;
                    worksheet.Cells.get_Range("B11").HorizontalAlignment = HorizontalAlignment.Center;
                    worksheet.Cells.get_Range("B11").Font.Bold = true;
                    worksheet.Cells.get_Range("A2", "B2").MergeCells = true;
                    worksheet.Cells.get_Range("A4", "B4").MergeCells = true;
                    worksheet.Cells.get_Range("A5", "B5").MergeCells = true;
                    worksheet.Cells.get_Range("A7", "B7").MergeCells = true;
                    worksheet.Cells.get_Range("A8", "B8").MergeCells = true;
                    // worksheet.Cells.get_Range( "D4","E5").MergeCells = true;

                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Columns.ColumnWidth = 30;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 2]).Columns.ColumnWidth = 8;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 3]).Columns.ColumnWidth = 35;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 4]).Columns.ColumnWidth = 15;

                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1]).Rows.RowHeight = 11;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1]).Rows.RowHeight = 28;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 1]).Rows.RowHeight = 10;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[4, 1]).Rows.RowHeight = 34;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[5, 1]).Rows.RowHeight = 34;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[6, 1]).Rows.RowHeight = 24;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[7, 1]).Rows.RowHeight = 30;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[8, 1]).Rows.RowHeight = 40;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[9, 1]).Rows.RowHeight = 16;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[10, 1]).Rows.RowHeight =24;
                    ((Microsoft.Office.Interop.Excel.Range)worksheet.Cells[11, 1]).Rows.RowHeight = 30;

                }
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
