using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTsys.DataObjects;
using QTsys.Manager;
using QTsys.Common.Constants;
using QTsys.Common;
using QTsys.DAO;


namespace QTsys
{
    public partial class 生产管理 : Form
    {
        private ProductPlanManager ppm;
        private ProductionManager product;
        private OrderManager oMgr;
        private ProductionPlan plan;
        private int index待生产订单 = -1;

        public 生产管理()
        {
            InitializeComponent();
            ppm = new ProductPlanManager();
            oMgr = new OrderManager();
            product = new ProductionManager();
            plan = new ProductionPlan();
        }

        private void 生产管理_Load(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.DataSource = this.ppm.GetAllProductPlanByStates(ProductionPlanStatus.PROCESSING);
                //get all for now
                button6.Enabled = false;//初始状态不允许生产成功！
                dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                dataGridView1.Update();
                dataGridView审核通过订单.DataSource = this.oMgr.GetAllOrderByState(OrderStatus.PASS);
                dataGridView审核通过订单.Update();

                // plan status
                com生产状态.Items.AddRange(new string[]
                {
                    //ProductionPlanStatus.PENDING,
                    ProductionPlanStatus.PREPARING,
                    ProductionPlanStatus.PROCESSING,
                    ProductionPlanStatus.STORED,
                    ProductionPlanStatus.CANCEL
                });

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (text搜索内容.Text != "")
                {
                    dataGridView1.DataSource = this.ppm.GetAllProductPlanByName(label搜索栏目.Text, text搜索内容.Text);
                    dataGridView1.Update();
                }
                else
                {
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (com生产状态.Text == ProductionPlanStatus.PROCESSING)
            {
                 button6.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
            }
                try
            {
                text编号.Text = dataGridView1.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                com产品编号.Text = dataGridView1.Rows[e.RowIndex].Cells["产品编号"].Value.ToString();
                com客户编号.Text = dataGridView1.Rows[e.RowIndex].Cells["客户编号"].Value.ToString();
                date下单日期.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["下单日期"].Value.ToString());
                text产品数量.Text = dataGridView1.Rows[e.RowIndex].Cells["产品数量"].Value.ToString();
                date交付时间.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["交付时间"].Value.ToString());
                date实际完成时间.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["实际完成时间"].Value.ToString());
                com计划类型.Text = dataGridView1.Rows[e.RowIndex].Cells["计划类型"].Value.ToString();
                com生产状态.Text = dataGridView1.Rows[e.RowIndex].Cells["生产状态"].Value.ToString();
                text相关订单编号.Text = dataGridView1.Rows[e.RowIndex].Cells["相关订单编号"].Value.ToString();
                com负责人.Text = dataGridView1.Rows[e.RowIndex].Cells["负责人"].Value.ToString();
                //-----------------------------------------------------------------------------------------------
                
                    textBox计划数.Text = text产品数量.Text;
                    textBox实际数.Text= dataGridView1.Rows[e.RowIndex].Cells["产品数量"].Value.ToString();

                textBox补充数.Text = Convert.ToString(Convert.ToInt16(textBox计划数.Text) - Convert.ToInt16(textBox实际数.Text));

                if (com生产状态.Text == ProductionPlanStatus.PROCESSING)
                {
                    button6.Enabled = true;
                }
                else
                {
                    button6.Enabled = false;
                }
            }
            catch (Exception ex) {
                if (com生产状态.Text == ProductionPlanStatus.PROCESSING)
                {
                    button6.Enabled = true;
                }
                else
                {
                    button6.Enabled = false;
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label搜索栏目.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void showgrid()
        {
            try
            {
                dataGridView1.DataSource = this.ppm.GetAllProductPlanByTime(date_up.Value, date_down.Value);
                dataGridView1.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString() + "加载失败！"); }
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            showgrid();
        }

        private void date_down_ValueChanged(object sender, EventArgs e)
        {
            showgrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // validation
                if (text编号.Text == "")
                {
                    MessageBox.Show("请先选择一个产品！");
                    return;
                }

                ProductionPlan pp = new ProductionPlan();
                pp.Id = text编号.Text;
                pp.ProductId = com产品编号.Text;
                pp.CustomerId = com客户编号.Text;
                pp.OrderTime = date下单日期.Value;
                pp.Count =Convert.ToInt32(text产品数量.Text);
                pp.PlanningTime = date交付时间.Value;
                pp.FinishTime = date实际完成时间.Value;
                pp.PlanType = com计划类型.Text;
                pp.PlanState = com生产状态.Text;
                pp.RelatedOrderId = text相关订单编号.Text;
                pp.InChargePerson = com负责人.Text;
                if (ppm.AltPlan(pp))
                {
                    MessageBox.Show("完成更新！");
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("更新失败！");
            }
            catch (Exception ex) { MessageBox.Show("生产计划更新失败！\n" + ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ProductionPlan pp = new ProductionPlan();
                pp.Id = text编号.Text;
                pp.ProductId = com产品编号.Text;
                pp.CustomerId = com客户编号.Text;
                pp.OrderTime = date下单日期.Value;
                pp.Count = Convert.ToInt32(text产品数量.Text);
                pp.PlanningTime = date交付时间.Value;
                pp.FinishTime = date实际完成时间.Value;
                pp.PlanType = com计划类型.Text;
                pp.PlanState = ProductionPlanStatus.PENDING;//com生产状态.Text;
                pp.RelatedOrderId = text相关订单编号.Text;
                pp.InChargePerson = com负责人.Text;
                if (ppm.AddNewPlan(pp))
                {
                    MessageBox.Show("新计划建立成功！审核中");
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("失败！");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ProductionPlan pp = new ProductionPlan();
                pp.Id = text编号.Text;
                pp.ProductId = com产品编号.Text;
                pp.CustomerId = com客户编号.Text;
                pp.OrderTime = date下单日期.Value;
                pp.Count = Convert.ToInt32(text产品数量.Text);
                pp.PlanningTime = date交付时间.Value;
                pp.FinishTime = date实际完成时间.Value;
                pp.PlanType = com计划类型.Text;
                pp.PlanState = com生产状态.Text;
                pp.RelatedOrderId = text相关订单编号.Text;
                pp.InChargePerson = com负责人.Text;
                if (ppm.DelPlan(pp.Id.ToString()))
                {
                    MessageBox.Show("删除成功！");
                    dataGridView1.DataSource = this.ppm.GetAllProductPlanByStates(ProductionPlanStatus.PROCESSING);
                    dataGridView1.Update();
                }
                else
                    MessageBox.Show("失败！");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void text产品数量_TextChanged(object sender, EventArgs e)
        {
            label_num.Text = "计划生产数为" + text产品数量.Text + "，实际生产：";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定是否生产成功?", "生产完成入库", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (Convert.ToInt16(textBox计划数.Text) == Convert.ToInt16(textBox实际数.Text)) //正好生产
                    {
                        产品入库(com产品编号.Text, Convert.ToInt16(textBox实际数.Text), 0);
                    }
                    if (Convert.ToInt16(textBox计划数.Text) > Convert.ToInt16(textBox实际数.Text))//生产少了
                    {
                        if (产品入库(com产品编号.Text, Convert.ToInt16(textBox实际数.Text), Convert.ToInt16(textBox计划数.Text) - Convert.ToInt16(textBox实际数.Text)))
                        {
                            补充生产(com产品编号.Text, Convert.ToInt16(textBox补充数.Text));
                        }
                    }
                    if (Convert.ToInt16(textBox计划数.Text) < Convert.ToInt16(textBox实际数.Text))//生产多了
                    {
                        产品入库(com产品编号.Text, Convert.ToInt16(textBox实际数.Text), 0);
                    }
                    dataGridView1.DataSource = this.ppm.GetAllProductPlan();
                    dataGridView1.Update();
                    dataGridView审核通过订单.DataSource = this.oMgr.GetAllOrderByState(OrderStatus.PASS);
                    dataGridView审核通过订单.Update();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public bool 产品入库(string 产品编号, int 产品数量,int 不合格产品数)
        {
            try{
            ProductFlow proflow = new ProductFlow();
            proflow.ProductId = 产品编号;
            proflow.OccurredTime = DateTime.Now;
            proflow.Type = "生产入库";
            proflow.RelatedOrderId = text相关订单编号.Text;
            proflow.RelatedPlanId = text编号.Text;
            proflow.UnqualifiedCount = 不合格产品数;
            proflow.Status = ProductionStatus.IN;  
            if (product.AddProduct(proflow, 产品数量))
            {
                ppm.UpdatePlanStatus(ProductionPlanStatus.STORED,text编号.Text);
                MessageBox.Show("产品增加成功！！！");
                return true;
            }else
                MessageBox.Show("产品增加失败！！！");
            return false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public void 补充生产(string 产品编号, int 产品数量)
        {
            try
            {
                plan.RelatedOrderId = text相关订单编号.Text;
                plan.ProductId = com产品编号.Text;
                plan.CustomerId = com客户编号.Text;
                plan.OrderTime = DateTime.Now;
                plan.Count = 产品数量;
                plan.PlanningTime = date交付时间.Value;
                plan.FinishTime = DateTime.Parse("2000-01-01");
               // plan.PlanState = ProductionPlanStatus.PREPARING;
                plan.PlanType = "补充生产";
                plan.PlanState = ProductionPlanStatus.PENDING;
                plan.InChargePerson = com负责人.Text;
                if (ppm.AddNewPlan(plan)) { MessageBox.Show("补充计划成功！！！");  }
                else
                {
                    MessageBox.Show("补充生产失败！！！");

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button生成生产计划_Click(object sender, EventArgs e)
        {
            if (index待生产订单 < 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            try
            {
                string id = dataGridView审核通过订单.Rows[index待生产订单].Cells["订单编号"].Value.ToString();
                string cId = dataGridView审核通过订单.Rows[index待生产订单].Cells["客户编号"].Value.ToString();
                bool isSample = dataGridView审核通过订单.Rows[index待生产订单].Cells["是否样品订单"].Value.ToString() == "是";
                DateTime oTime = DateTime.Parse(dataGridView审核通过订单.Rows[index待生产订单].Cells["创建时间"].Value.ToString());

                WinSendMsg.IsSampleProduct = isSample;
                //WinSendMsg.IsMeterialReduce = check库存.Checked;
                WinSendMsg.row = dataGridView审核通过订单.Rows.Count;
                WinSendMsg.Oid = id;
                ProductionPlan plan = new ProductionPlan();
                plan.RelatedOrderId = id;
                plan.ProductId = "";
                plan.CustomerId = cId;
                plan.OrderTime = oTime;
                plan.Count = 0;
                plan.PlanningTime = DateTime.Now;
                plan.FinishTime = DateTime.Now;
                plan.PlanType = isSample ? "样品" : "正品";
                plan.InChargePerson = Utils.GetCurrentUsername();
                根据订单生成计划 win = new 根据订单生成计划(plan.PlanType, plan.RelatedOrderId, plan.CustomerId);
                win.ShowDialog();
                dataGridView1.DataSource = this.ppm.GetAllProductPlanByStates(ProductionPlanStatus.PROCESSING);
                dataGridView1.Update();
                dataGridView审核通过订单.DataSource = this.oMgr.GetAllOrderByState(OrderStatus.PASS);
                dataGridView审核通过订单.Update();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView审核通过订单_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index待生产订单 = e.RowIndex;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (com生产状态.Text == ProductionPlanStatus.PROCESSING)
            {
                button6.Enabled = true;
            }
            else
            {
                button6.Enabled = false;
            }
        }

        private void textBox实际数_TextChanged(object sender, EventArgs e)
        {
            try {
                //textBox计划数-textBox实际数=textBox补充数
                textBox补充数.Text = Convert.ToString(Convert.ToInt16(textBox计划数.Text) - Convert.ToInt16(textBox实际数.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            打印制造单 win = new 打印制造单(text编号.Text);
            win.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
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
