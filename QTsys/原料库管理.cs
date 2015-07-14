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
    public partial class 原料库管理 : Form
    {
        private MaterialManager material;
        private string selectNum;

        public 原料库管理()
        {
            InitializeComponent();
            this.material = MaterialManager.getMaterialManager();
            selectNum="";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            原料入仓 win = new 原料入仓();
            win.ShowDialog();
            dataGridView1.DataSource = this.material.GetAllMaterials();
            dataGridView1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*原料出仓 win = new 原料出仓();
            win.ShowDialog();*/
            领料生产 win = new 领料生产();
            win.ShowDialog();
            dataGridView1.DataSource = this.material.GetAllMaterials();
            dataGridView1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           原料数据修改 win = new 原料数据修改();
            win.ShowDialog();
            /*  try
             {
                 Material mtl = new Material();
                 mtl.Id = Convert.ToInt16(text原料编号.Text);
                 mtl.Name = text原料名称.Text;
                 mtl.Unit = text单位.Text;
                 mtl.StockCount = Convert.ToInt16(text库存数量.Text);
                 if (this.material.AltMaterials(mtl))
                 {
                     MessageBox.Show("原料[" + text原料编号.Text + "]数据修改成功！");
                     dataGridView1.DataSource = this.material.GetAllMaterials();
                     dataGridView1.Update();
                 }
                 else { MessageBox.Show("修改失败！"); }
             }
             catch (Exception ex) { MessageBox.Show("数据修改失败！"); }*/
        }

        private void 原料管理_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.material.GetAllMaterials();
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //搜索用
                text原料编号.Text = dataGridView1.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
                text原料名称.Text = dataGridView1.Rows[e.RowIndex].Cells["原料名称"].Value.ToString();
                text单位.Text = dataGridView1.Rows[e.RowIndex].Cells["单位"].Value.ToString();
                text库存数量.Text = dataGridView1.Rows[e.RowIndex].Cells["库存数量"].Value.ToString();
                text供应商.Text = dataGridView1.Rows[e.RowIndex].Cells["供应商"].Value.ToString();
                //显示进出原料仓库明细情况
                dataGridView2.DataSource = this.material.GetAllMaterialFlowByNameEX("原料编号", dataGridView1.CurrentRow.Cells["原料编号"].Value.ToString());
                dataGridView2.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！");}
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
                    dataGridView1.DataSource = this.material.GetAllMaterialByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.material.GetAllMaterials();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void label搜索栏目_Click(object sender, EventArgs e)
        {

        }

        private void text搜索内容_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView1.DataSource;
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

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView2.DataSource;
            ExportExcel(dt);
        }
    }
}
