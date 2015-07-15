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
    public partial class 对账 : Form
    {
        private OrderManager odm;
        private UserManager userMgr;
        private string selectedCustomerId;
        private List<CustomerMember> cMembers;
        private List<string> listNew = new List<string>();
        private List<string> listtemp = new List<string>();
        private List<Customer> customers;

        public 对账()
        {
            InitializeComponent();
            odm = new OrderManager();
            userMgr = new UserManager();
        }

        private void 对账_Load(object sender, EventArgs e)
        {
            comboBox客户.Items.Clear();
            // 初始化客户信息
            customers = userMgr.GetAllCustomerList();
          //  customers.Insert(0, new Customer() { Id = "-9999", Name = "" });
            //use dataSource make selectedValue works;
            comboBox客户.DisplayMember = "Name";
            comboBox客户.ValueMember = "Id";
            comboBox客户.Items.AddRange(customers.ToArray());
            //初始化temp数据
            listNew.Clear();
            listtemp.Clear();
            foreach (var item in customers)
            {
                if (item.Name.Contains(this.comboBox客户.Text))
                {
                    listNew.Add(item.Name);
                    listtemp.Add(item.Id);
                }
            }

            dateTimePicker对账起始日.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 25);
            dateTimePicker对账截止日.Value = DateTime.Today;
        }

        private void comboBox客户_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox客户.SelectedIndex <0)
                {
                    return;
                }
                if (comboBox客户.Items[0].ToString() == "")
                {
                        l编号.Text = "0";
                        com客户联系人.Text = "";
                        text联系电话.Text = "";
                        text收货地址.Text = "";
                        textBox传真.Text = "";
                        textBox结算方式.Text = "";
                        return;
                }
                selectedCustomerId = listtemp[comboBox客户.SelectedIndex];
                //com客户联系人
                DataTable dt = new DataTable();
                // MessageBox.Show(customers[com客户名.SelectedIndex].Id);
                dt = userMgr.SearchCustomerByCol("客户编号", selectedCustomerId);
                l编号.Text = dt.Rows[0]["客户编号"].ToString();
                com客户联系人.Text = dt.Rows[0]["默认联系人"].ToString();
                text联系电话.Text = dt.Rows[0]["联系电话"].ToString();
                text收货地址.Text = dt.Rows[0]["地址"].ToString();
                textBox传真.Text = dt.Rows[0]["传真"].ToString();
                textBox结算方式.Text = dt.Rows[0]["结算方式"].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button生成_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = l编号.Text;
                if (customerId == "-9999")
                {
                    MessageBox.Show("请选择要对账的客户");
                    return;
                }
                DateTime startDate = dateTimePicker对账起始日.Value;
                DateTime endDate = dateTimePicker对账截止日.Value;


                dataGridView对账单.DataSource = this.odm.GetReconciliation(customerId, startDate, endDate);
                dataGridView对账单.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button打印_Click(object sender, EventArgs e)
        {
            try
            {
                打印对账单 win = new 打印对账单(this, (DataTable)(dataGridView对账单.DataSource),Convert.ToUInt16(textBox分页数量.Text));
                win.ShowDialog();
            }
            catch (Exception ex) { };
        }

        private void com客户联系人_DropDown(object sender, EventArgs e)
        {
            CustomerMember[] result = new CustomerMember[] { };
            com客户联系人.Items.Clear();
            if (selectedCustomerId != "")
            {
                cMembers = userMgr.GetCustomerMembersByCId(selectedCustomerId);
                result = cMembers.ToArray();
            }

            com客户联系人.Items.AddRange(result);
            com客户联系人.DisplayMember = "Name";
            com客户联系人.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView对账单.DataSource;
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

        private void comboBox客户_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                this.comboBox客户.Items.Clear();
                listNew.Clear();
                listtemp.Clear();
                foreach (var item in customers)
                {
                    if (item.Name.Contains(this.comboBox客户.Text))
                    {
                        listNew.Add(item.Name);
                        listtemp.Add(item.Id);
                    }
                }
                this.comboBox客户.Items.AddRange(listNew.ToArray());
                this.comboBox客户.SelectionStart = this.comboBox客户.Text.Length;
                Cursor = Cursors.Default;
                this.comboBox客户.DroppedDown = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
