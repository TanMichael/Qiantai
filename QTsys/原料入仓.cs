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
    public partial class 原料入仓 : Form
    {
        private MaterialManager material;
        private UserManager userMgr;
      //  private string selectedCustomerId;
        private List<Customer> customers;
        private List<string> listNew = new List<string>();

        public 原料入仓()
        {
            InitializeComponent();
            this.material = MaterialManager.getMaterialManager();
            userMgr = new UserManager();
           // selectedCustomerId = "";
        }

        private void 原料入仓_Load(object sender, EventArgs e)
        {
            try
            {
                com原料编号.ValueMember = "Id";
                com原料编号.DisplayMember = "Name";
                var mts = this.material.GetAllMaterials(true);
                mts.Insert(0, new Material() { Id = -1, Name = "新增原料" });
                com原料编号.DataSource = mts;

                dataGridView1.DataSource = this.material.GetAllMaterials();
                dataGridView1.Update();
                dataGridView2.DataSource = this.material.GetAllMaterialFlow();
                dataGridView2.Update();
                //text操作员.Text = Utils.GetCurrentUsername();
                dateTimePicker入仓起始日.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 25);
                dateTimePicker入仓截止日.Value = DateTime.Now;


                //****供应商初始化
                com供应商.Items.Clear();
                customers = userMgr.GetAllCustomerList();
                customers.Insert(0, new Customer() { Id = "-9999", Name = "" });
                //use dataSource make selectedValue works;
                com供应商.DisplayMember = "Name";
                com供应商.ValueMember = "Id";
                //com供应商.DataSource = customers;
                com供应商.Items.AddRange(customers.ToArray());
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//关联
        {
            try
            {

                com原料编号.SelectedValue = (int)(dataGridView1.Rows[e.RowIndex].Cells["原料编号"].Value);
                //text原料名称.Text = this.material.GetMaterialNameBySerial(com原料编号.Text);
                text单位.Text = dataGridView1.Rows[e.RowIndex].Cells["单位"].Value.ToString();
               // text编号.Text = dataGridView2.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                //text类型.Text = "";
                text库存数量.Text = dataGridView1.Rows[e.RowIndex].Cells["库存数量"].Value.ToString();
                //com原料编号.Text = dataGridView2.Rows[e.RowIndex].Cells["原料编号"].Value.ToString();
                com供应商.Text = dataGridView2.Rows[e.RowIndex].Cells["供应商"].Value.ToString();
               // text供应单价.Text = dataGridView2.Rows[e.RowIndex].Cells["供应单价"].Value.ToString();
                // text操作员.Text = dataGridView2.Rows[e.RowIndex].Cells["操作员"].Value.ToString();
             //   text原料名称.Text = this.material.GetMaterialNameBySerial(com原料编号.Text);

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

        private void button1_Click(object sender, EventArgs e)
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //text编号.Text = dataGridView2.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                //text类型.Text = dataGridView2.Rows[e.RowIndex].Cells["类型"].Value.ToString();
                textBox进出数量.Text = dataGridView2.Rows[e.RowIndex].Cells["数量"].Value.ToString();
                com原料编号.SelectedValue = (int)(dataGridView2.Rows[e.RowIndex].Cells["原料编号"].Value);
                com供应商.Text = dataGridView2.Rows[e.RowIndex].Cells["供应商"].Value.ToString();
                text供应单价.Text = dataGridView2.Rows[e.RowIndex].Cells["供应单价"].Value.ToString();
               // text操作员.Text = dataGridView2.Rows[e.RowIndex].Cells["操作员"].Value.ToString();
                //text原料名称.Text = this.material.GetMaterialNameBySerial(com原料编号.Text);
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox出入仓列搜索.Text != "")
                {
                    DateTime start = dateTimePicker入仓起始日.Value;
                    DateTime end = dateTimePicker入仓截止日.Value;
                    //dataGridView2.DataSource = this.material.GetAllMaterialFlowByName(label出入仓列名.Text, textBox出入仓列搜索.Text);
                    dataGridView2.DataSource = this.material.GetSearchIncomeMaterialFlow(label出入仓列名.Text, textBox出入仓列搜索.Text, start, end);
                    dataGridView2.Update();
                }
                else
                {
                    dataGridView2.DataSource = this.material.GetAllMaterialFlow();
                    dataGridView2.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label出入仓列名.Text = dataGridView2.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (text单位.Text == "")
            {
                MessageBox.Show("未填写单位");
                return;
            }
            if (text供应单价.Text == "")
            {
                MessageBox.Show("未填写供应单价");
                return;
            }
            if (com供应商.Text == "")
            {
                MessageBox.Show("未填写供应商");
                return;
            }
            try
            {
                MaterialDAO at = new MaterialDAO();
                MaterialFlow mtf = new MaterialFlow();
                //mtf.Id = com原料编号
                mtf.Type = "入仓";
                mtf.FlowCount = Convert.ToInt32(textBox进出数量.Text);
                mtf.MaterialId = Convert.ToInt32(com原料编号.SelectedValue);
                mtf.Supplier = com供应商.Text;
                mtf.Price = Convert.ToDouble(text供应单价.Text);
                mtf.Operator = Utils.GetCurrentUsername();
                mtf.OccurredTime = DateTime.Now;
                

                String name = textBoxNewName.Text;//原料名称

                DialogResult dr = MessageBox.Show("将要对原料[" + name + "]进行入仓，供应商：" +
                    mtf.Supplier + ", 单价： " + mtf.Price + ", 数量：" + mtf.FlowCount, "请确认", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    //原料名称this.material.GetMaterialNameBySerial(com原料编号.Text);
                    
                    if (material.AddNewMaterialEx(mtf, name, text单位.Text))
                    {
                        MessageBox.Show("[" + name + "]更新库存成功！");
                        dataGridView1.DataSource = this.material.GetAllMaterials();
                        dataGridView1.Update();
                        dataGridView2.DataSource = this.material.GetAllMaterialFlow();
                        dataGridView2.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新库存失败！" + ex.ToString());
            }
        }

        private void com原料编号_SelectedIndexChanged(object sender, EventArgs e)
        {
            Material mt = (Material)(com原料编号.SelectedItem);
            if (mt.Id == -1)
            {
                text单位.Text = "";
                text库存数量.Text = "";
                textBoxNewName.Text = "";
                com供应商.Text = "";
                textBoxNewName.Visible = true;
                label原料名称.Visible = true;

            }
            else
            {
                text单位.Text = mt.Unit;
                text库存数量.Text = mt.StockCount.ToString();
                textBoxNewName.Text = com原料编号.Text;
                com供应商.Text = mt.Supplier.ToString();
                textBoxNewName.Visible = false;
                label原料名称.Visible = false;
            }
        }

        private void com供应商_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
               
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void com供应商_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                this.com供应商.Items.Clear();
                listNew.Clear();
                foreach (var item in customers)
                {
                    if (item.Name.Contains(this.com供应商.Text))
                    {
                        listNew.Add(item.Name);
                    }
                }
                this.com供应商.Items.AddRange(listNew.ToArray());
                this.com供应商.SelectionStart = this.com供应商.Text.Length;
                Cursor = Cursors.Default;
                this.com供应商.DroppedDown = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView2.DataSource;
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
