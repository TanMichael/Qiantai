using QTsys.DataObjects;
using QTsys.Manager;
using System;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace QTsys
{
    public partial class 客户管理 : Form
    {
        private UserManager userMgr;
        private string selectedCustomerId;
        private string selectedCustomerName;

        public 客户管理()
        {
            InitializeComponent();
            this.userMgr = UserManager.getUserManager();
        }

        private void 客户管理_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = this.userMgr.GetAllCustomers();
                dataGridView1.Update();
                //dataGridView2.DataSource = this.userMgr.GetAllCustomerMembers();
                //dataGridView2.Update();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//单击grid1对数据单元进行读取
        {
            try
            {
                text客户编号.Text = selectedCustomerId = dataGridView1.Rows[e.RowIndex].Cells["客户编号"].Value.ToString();
                text客户名称.Text = selectedCustomerName = dataGridView1.Rows[e.RowIndex].Cells["客户名称"].Value.ToString();
                text客户地址.Text = dataGridView1.Rows[e.RowIndex].Cells["地址"].Value.ToString();
                textBox联系人.Text = dataGridView1.Rows[e.RowIndex].Cells["默认联系人"].Value.ToString();
                text联系电话.Text = dataGridView1.Rows[e.RowIndex].Cells["联系电话"].Value.ToString();
                text传真.Text = dataGridView1.Rows[e.RowIndex].Cells["传真"].Value.ToString();
                text电子邮箱.Text = dataGridView1.Rows[e.RowIndex].Cells["电子邮箱"].Value.ToString();
                text结算方式.Text = dataGridView1.Rows[e.RowIndex].Cells["结算方式"].Value.ToString();
                text流水号.Text = dataGridView1.Rows[e.RowIndex].Cells["流水号"].Value.ToString();
                text备注.Text = dataGridView1.Rows[e.RowIndex].Cells["备注"].Value.ToString();
                //联系人信息更新
                t所属客户.Text = text客户编号.Text;
                //
                dataGridView2.DataSource = this.userMgr.GetCustomerMembersByCustomer(selectedCustomerId);
                dataGridView2.Update();
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label搜索栏目.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
        }

        private void button4_Click(object sender, EventArgs e)//搜索
        {
            try
            {
                if (textBox搜索内容.Text != "")
                {
                    dataGridView1.DataSource = this.userMgr.SearchCustomerByCol(label搜索栏目.Text, textBox搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.userMgr.GetAllCustomers();
                    dataGridView1.Update();
                }
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)//新增
        {
            try
            {
                Customer cus = new Customer();
                //cus.Id = text客户编号.Text;
                cus.Name = text客户名称.Text;
                cus.DefaultContact = textBox联系人.Text;
                cus.Address = text客户地址.Text;
                cus.Phone = text联系电话.Text;
                cus.Fax = text传真.Text;
                cus.Email = text电子邮箱.Text;
                cus.PaymentMode = text结算方式.Text;
                cus.Serial = text流水号.Text;
                cus.Remarks = text备注.Text;
                if (this.userMgr.AddNewCustomer(cus))
                {
                    MessageBox.Show("客户[" + cus.Name + "]新增成功！");
                    //更新表格数据                    
                    dataGridView1.DataSource = this.userMgr.GetAllCustomers();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("新增失败！");
            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)//删除
        {
            try
            {
                // validation
                if (text客户编号.Text == "")
                {
                    MessageBox.Show("请先选择一个客户！");
                    return;
                }

                if (this.userMgr.DelCustomer(text客户编号.Text))
                {
                    MessageBox.Show("用户[" + text客户编号.Text + "]已被删除！");
                    //更新表格数据                    
                    dataGridView1.DataSource = this.userMgr.GetAllCustomers();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("删除用户[" + text客户编号.Text + "]失败！");
            }
            catch (Exception ex) { }
        }

        private void button1_Click(object sender, EventArgs e)//修改
        {
            try
            {
                // validation
                if (text客户编号.Text == "")
                {
                    MessageBox.Show("请先选择一个客户！");
                    return;
                }

                Customer cus = new Customer();
                cus.Id = text客户编号.Text;
                cus.Name = text客户名称.Text;
                cus.DefaultContact = textBox联系人.Text;
                cus.Address = text客户地址.Text;
                cus.Phone = text联系电话.Text;
                cus.Fax = text传真.Text;
                cus.Email = text电子邮箱.Text;
                cus.PaymentMode = text结算方式.Text;
                cus.Serial = text流水号.Text;
                cus.Remarks = text备注.Text;
                if (this.userMgr.UpdateCustomer(cus))
                {
                    MessageBox.Show("客户[" + cus.Name + "]数据修改成功！");
                    //更新表格数据                    
                    dataGridView1.DataSource = this.userMgr.GetAllCustomers();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox搜索联系人.Text != "")
            {
                
                //dataGridView2.DataSource = cdao.GetCustomerMembersByName(label联系人.Text, textBox搜索联系人.Text);
                dataGridView2.DataSource = this.userMgr.SearchCustomerMemberByCol(label联系人.Text, textBox搜索联系人.Text, selectedCustomerId);
                dataGridView2.Update();
            }
            else
            {
                dataGridView2.DataSource = this.userMgr.GetCustomerMembersByCustomer(selectedCustomerId);
                dataGridView2.Update();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var header = dataGridView2.Columns[e.ColumnIndex].HeaderText.ToString();
            if (header == "客户名称" || header == "所属客户编号")
            {
                MessageBox.Show("该列为当前页过滤条件，不能设为搜索列");
                return;
            }
            label联系人.Text = header;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                t编号.Text = dataGridView2.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                t姓名.Text = dataGridView2.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                t类型.Text = dataGridView2.Rows[e.RowIndex].Cells["类型"].Value.ToString();
                t电话.Text = dataGridView2.Rows[e.RowIndex].Cells["联系电话"].Value.ToString();
                t电子邮件.Text = dataGridView2.Rows[e.RowIndex].Cells["电子邮件"].Value.ToString();
                t所属客户.Text = dataGridView2.Rows[e.RowIndex].Cells["所属客户编号"].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerMember cus = new CustomerMember();
                cus.Id = t编号.Text;
                cus.Name = t姓名.Text;
                cus.Type = t类型.Text;
                cus.Phone = t电话.Text;
                cus.Email = t电子邮件.Text;
                cus.CustomerId = t所属客户.Text;
                if (this.userMgr.AddNewCustomerMember(cus))
                {
                    MessageBox.Show("客户联系人[" + t编号.Text + "]新增成功！");
                    //更新表格数据                    
                    dataGridView2.DataSource = this.userMgr.GetCustomerMembersByCustomer(selectedCustomerId);
                    dataGridView2.Update();
                }
                else
                    MessageBox.Show("新增失败！");
            }
            catch (Exception ex) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.userMgr.DelCustomerMember(t编号.Text))
                {
                    MessageBox.Show("客户联系人[" + t编号.Text + "]已被删除！");
                    //更新表格数据                    
                    dataGridView2.DataSource = this.userMgr.GetCustomerMembersByCustomer(selectedCustomerId);
                    dataGridView2.Update();
                }
                else
                    MessageBox.Show("删除客户联系人[" + t编号.Text + "]失败！");
            }
            catch (Exception ex) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerMember cus = new CustomerMember();
                cus.Id = t编号.Text;
                cus.Name = t姓名.Text;
                cus.Type = t类型.Text;
                cus.Phone = t电话.Text;
                cus.Email = t电子邮件.Text;
                cus.CustomerId = t所属客户.Text;
                if (this.userMgr.UpdateCustomerMember(cus))
                {
                    MessageBox.Show("客户联系人[" + t编号.Text + "]修改成功！");
                    //更新表格数据                    
                    dataGridView2.DataSource = this.userMgr.GetCustomerMembersByCustomer(selectedCustomerId);
                    dataGridView2.Update();
                }
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ex) { }
        }

        private void tabCustomer_Selected(object sender, TabControlEventArgs e)
        {

            // change to customer member tab page
            if (e.TabPageIndex == 1)
            {
                if (selectedCustomerId == null)
                {
                    MessageBox.Show("请从客户表中选中一个客户！");
                    tabCustomer.SelectedTab = tabPageCustomer;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
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
    }
}
