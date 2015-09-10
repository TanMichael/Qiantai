using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using QTsys.Common;
using QTsys.DataObjects;
using QTsys.DAO;
using QTsys.Manager;
using System.Diagnostics;

namespace QTsys
{
    public partial class 批量导入 : Form
    {

        private OrderManager odMgr;
        private UserManager userMgr;
       // private SalesManager sMgr;
        private ProductionManager pdtMgr;
        private MaterialManager mtMgr;

        public 批量导入()
        {
            InitializeComponent();
            odMgr = new OrderManager();
            userMgr = new UserManager();
            //sMgr = new SalesManager();
            pdtMgr = new ProductionManager();
            mtMgr = new MaterialManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resultFile = "";//EXCEL文件地址
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls|(*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    resultFile = openFileDialog1.FileName;
                    string oleconn = "";
                    //MessageBox.Show(resultFile);
                    if (resultFile.Substring(resultFile.Length - 3, 3) == "xls")
                    {
                        oleconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + resultFile + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
                    }
                    else
                    {
                        oleconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + resultFile + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    }
                    //单表操作
                    if (radio员工.Checked == true)
                        员工导入(oleconn);
                    if (radio客户.Checked == true)
                        客户导入(oleconn);
                    if (radio产品.Checked == true)
                        产品导入(oleconn);
                    if (radio原料.Checked == true)
                        原料导入(oleconn);
                  //  if (radio原料.Checked == true)
                   //     原料导入();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            } 
        }
    

        private void 批量导入_Load(object sender, EventArgs e)
        {
            radio产品.Checked = true;
        }
        //********************************************************************************************
        public void 员工导入(string oleconn)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(oleconn);
                conn.Open();
                string str_sql = "select * from [员工信息$]";
                OleDbDataAdapter oda = new OleDbDataAdapter(str_sql, conn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                conn.Close();
                //ds为数据 
                User newuser = new User();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //newuser.Id = ds.Tables[""].
                    try
                    {
                        newuser.UserName = ds.Tables[0].Rows[i][0].ToString();
                        newuser.Password = "c4ca4238a0b923820dcc509a6f75849b";
                        newuser.Name = ds.Tables[0].Rows[i][1].ToString();
                        newuser.Role = ds.Tables[0].Rows[i][2].ToString();
                        newuser.JobTitle = ds.Tables[0].Rows[i][3].ToString();
                        newuser.Mobile = ds.Tables[0].Rows[i][4].ToString();
                        newuser.Phone = ds.Tables[0].Rows[i][5].ToString();
                        newuser.Email = ds.Tables[0].Rows[i][6].ToString();
                        newuser.Department = ds.Tables[0].Rows[i][7].ToString();
                        if (this.userMgr.AddNewUser(newuser))
                        {
                            richTextBox1.Text += "新用户[" + newuser.UserName + "]生成成功,默认密码为“1”！\r\n";
                        }
                        else
                            richTextBox1.Text += "新用户[" + newuser.UserName + "]生成失败，请核实信息！\r\n";
                    }catch (Exception ex) {  richTextBox1.Text += "新用户[" + newuser.UserName + "]生成失败，请核实信息！\r\n"; }
                }  
            }
            catch (Exception ex) { richTextBox1.Text += "新用户生成失败，请核实信息！\r\n"; };
        }
        //********************************************************************************************
        public void 客户导入(string oleconn)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(oleconn);
                conn.Open();
                string str_sql = "select * from [客户信息$]";
                OleDbDataAdapter oda = new OleDbDataAdapter(str_sql, conn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                conn.Close();
                //ds为数据 
               Customer cus = new Customer();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    
                   // cus.Id = text客户编号.Text;
                    try
                    {
                        cus.Name = ds.Tables[0].Rows[i][0].ToString();
                        cus.OriginalId = ds.Tables[0].Rows[i][1].ToString(); 
                        cus.DefaultContact = ds.Tables[0].Rows[i][2].ToString();
                        cus.Address = ds.Tables[0].Rows[i][3].ToString();
                        cus.Phone = ds.Tables[0].Rows[i][4].ToString();//电话号码
                      //  MessageBox.Show(ds.Tables[0].Rows[i][4].ToString());
                        cus.Fax = ds.Tables[0].Rows[i][5].ToString();
                        cus.Email = ds.Tables[0].Rows[i][6].ToString();
                        cus.PaymentMode = ds.Tables[0].Rows[i][7].ToString();
                        cus.Serial = ds.Tables[0].Rows[i][8].ToString();
                        cus.Remarks = ds.Tables[0].Rows[i][9].ToString();
                        if (this.userMgr.AddNewCustomer(cus))
                        {
                            richTextBox1.Text += "新客户[" + cus.Name + "]生成成功！\r\n";
                        }
                        else
                            richTextBox1.Text += "新客户[" + cus.Name + "]生成失败，请核实信息！\r\n";
                    }
                    catch (Exception ex) { richTextBox1.Text += "新客户[" + cus.Name + "]生成失败，请核实信息！\r\n"; }
                }
            }
            catch (Exception ex) { richTextBox1.Text += "新客户生成失败，请核实信息！\r\n"; }
        }  
        //********************************************************************************************
        public void 产品导入(string oleconn)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(oleconn);
                conn.Open();
                string str_sql = "select * from [产品信息$]";
                OleDbDataAdapter oda = new OleDbDataAdapter(str_sql, conn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                conn.Close();
                //ds为数据 
                Product pdt = new Product();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    // Convert.ToDouble(
                    //     Convert.ToInt16(
                    try
                    {
                        pdt.Name = ds.Tables[0].Rows[i][0].ToString();
                        pdt.Standard = ds.Tables[0].Rows[i][1].ToString();
                        pdt.Texture = ds.Tables[0].Rows[i][2].ToString();
                        pdt.Shift = ds.Tables[0].Rows[i][3].ToString();
                        pdt.RealShift = ds.Tables[0].Rows[i][4].ToString();
                        pdt.Color = ds.Tables[0].Rows[i][5].ToString();
                        pdt.Unit = ds.Tables[0].Rows[i][6].ToString();
                        pdt.Price = Convert.ToDouble(ds.Tables[0].Rows[i][7].ToString());
                        pdt.StockCount = Convert.ToInt16(ds.Tables[0].Rows[i][8].ToString());
                        pdt.布料编号 = ds.Tables[0].Rows[i][9].ToString();
                        pdt.开料要求 = ds.Tables[0].Rows[i][10].ToString();
                        pdt.开料尺寸 = ds.Tables[0].Rows[i][11].ToString();
                        pdt.胶水型号 = ds.Tables[0].Rows[i][12].ToString();
                        pdt.溶剂 = ds.Tables[0].Rows[i][13].ToString();
                        pdt.脱模剂 = ds.Tables[0].Rows[i][14].ToString();
                        pdt.硬化剂 = ds.Tables[0].Rows[i][15].ToString();
                        pdt.含浸比重 = ds.Tables[0].Rows[i][16].ToString();
                        pdt.搅拌时间 = ds.Tables[0].Rows[i][17].ToString();
                        pdt.比重计 = ds.Tables[0].Rows[i][18].ToString();
                        pdt.胶滚压力 = ds.Tables[0].Rows[i][19].ToString();
                        pdt.含浸转速HZ = ds.Tables[0].Rows[i][20].ToString();
                        pdt.烤箱温度C = ds.Tables[0].Rows[i][21].ToString();
                        pdt.成型模号 = ds.Tables[0].Rows[i][22].ToString();
                        pdt.成型机台 = ds.Tables[0].Rows[i][23].ToString();
                        pdt.手动自动 = ds.Tables[0].Rows[i][24].ToString();
                        pdt.单个整条 = ds.Tables[0].Rows[i][25].ToString();
                        pdt.成型上下模温度 = ds.Tables[0].Rows[i][26].ToString();
                        pdt.成型时间 = ds.Tables[0].Rows[i][27].ToString();
                        pdt.成型压力 = ds.Tables[0].Rows[i][28].ToString();
                        pdt.自动切 = ds.Tables[0].Rows[i][39].ToString();
                        pdt.是否拉布成型 = ds.Tables[0].Rows[i][30].ToString();
                        pdt.是否中孔加补强布 = ds.Tables[0].Rows[i][31].ToString();
                        pdt.补强布大小 = ds.Tables[0].Rows[i][32].ToString();
                        pdt.是否压纸板 = ds.Tables[0].Rows[i][33].ToString();
                        pdt.剪边喷水 = ds.Tables[0].Rows[i][34].ToString();
                        pdt.压定位板 = ds.Tables[0].Rows[i][35].ToString();
                        pdt.定型时间 = ds.Tables[0].Rows[i][36].ToString();
                        pdt.压纸板时间 = ds.Tables[0].Rows[i][37].ToString();
                        pdt.刀模 = ds.Tables[0].Rows[i][38].ToString();
                        pdt.中孔模 = ds.Tables[0].Rows[i][39].ToString();
                        pdt.刀模中心定位 = ds.Tables[0].Rows[i][40].ToString();
                        pdt.切刀模个数 = ds.Tables[0].Rows[i][41].ToString();
                        pdt.切断模 = ds.Tables[0].Rows[i][42].ToString();
                        pdt.切断模架 = ds.Tables[0].Rows[i][43].ToString();
                        pdt.切断机台 = ds.Tables[0].Rows[i][44].ToString();
                        pdt.单个整条切断 = ds.Tables[0].Rows[i][45].ToString();
                        pdt.通用气冲模 = ds.Tables[0].Rows[i][46].ToString();
                        pdt.气冲压力 = ds.Tables[0].Rows[i][47].ToString();
                        pdt.多个多条切断 = ds.Tables[0].Rows[i][48].ToString();
                        pdt.导线方式 = ds.Tables[0].Rows[i][49].ToString();
                        pdt.导线规格 = ds.Tables[0].Rows[i][50].ToString();
                        pdt.内留mm = ds.Tables[0].Rows[i][51].ToString();
                        pdt.外留mm = ds.Tables[0].Rows[i][52].ToString();
                        pdt.点锡长mm = ds.Tables[0].Rows[i][53].ToString();
                        pdt.导线长度 = ds.Tables[0].Rows[i][54].ToString();
                        pdt.方向数量 = ds.Tables[0].Rows[i][55].ToString();
                        pdt.线距mm = ds.Tables[0].Rows[i][56].ToString();
                        pdt.单面双面点胶 = ds.Tables[0].Rows[i][57].ToString();
                        pdt.胶水 = ds.Tables[0].Rows[i][58].ToString();
                        pdt.边胶 = ds.Tables[0].Rows[i][59].ToString();
                        pdt.胶水重量 = ds.Tables[0].Rows[i][60].ToString();
                        pdt.摆放要求 = ds.Tables[0].Rows[i][61].ToString();
                        pdt.工艺要求 = ds.Tables[0].Rows[i][62].ToString();
                        pdt.打胶方式 = ds.Tables[0].Rows[i][63].ToString();
                        pdt.贴合方式 = ds.Tables[0].Rows[i][64].ToString();
                        pdt.贴合压力 = ds.Tables[0].Rows[i][65].ToString();
                        pdt.贴合模具 = ds.Tables[0].Rows[i][66].ToString();
                        pdt.贴合机台 = ds.Tables[0].Rows[i][67].ToString();
                        pdt.成型首检变位 = ds.Tables[0].Rows[i][68].ToString();
                        pdt.生产单重 = ds.Tables[0].Rows[i][69].ToString();
                        pdt.样品变位 = ds.Tables[0].Rows[i][70].ToString();
                        pdt.样品单重 = ds.Tables[0].Rows[i][71].ToString();
                        pdt.测试夹具外内 = ds.Tables[0].Rows[i][72].ToString();
                        pdt.是否留样 = ds.Tables[0].Rows[i][73].ToString();
                        pdt.是否备品 = ds.Tables[0].Rows[i][74].ToString();
                        pdt.是否产品全检 = ds.Tables[0].Rows[i][75].ToString();
                        pdt.是否数量超交 = ds.Tables[0].Rows[i][76].ToString();
                        pdt.是否标签盖环保章 = ds.Tables[0].Rows[i][77].ToString();
                        pdt.外贴标签要求 = ds.Tables[0].Rows[i][78].ToString();
                        pdt.备注 = ds.Tables[0].Rows[i][79].ToString();
                        pdt.批准 = ds.Tables[0].Rows[i][80].ToString();
                        pdt.审核 = ds.Tables[0].Rows[i][81].ToString();
                        pdt.制作 = ds.Tables[0].Rows[i][82].ToString();
                        if (pdtMgr.AddNewProduct(pdt) != 0)
                        {
                            richTextBox1.Text += "新产品[" + pdt.Name + "]生成成功！\r\n";
                        }
                        else
                            richTextBox1.Text += "新产品[" + pdt.Name + "]生成失败，请仔细核准数据！\r\n";
                    }
                    catch (Exception ex) { richTextBox1.Text += "新产品[" + pdt.Name + "]生成失败，请仔细核准数据！\r\n"; };
                } 
            }
            catch (Exception ex) { richTextBox1.Text += "新产品生成失败，请仔细核准数据！\r\n"; };
        }
        //********************************************************************************************
        public void 原料导入(string oleconn)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(oleconn);
                conn.Open();
                string str_sql = "select * from [原材料$]";
                OleDbDataAdapter oda = new OleDbDataAdapter(str_sql, conn);
                DataSet ds = new DataSet();
                oda.Fill(ds);
                conn.Close();
                //ds为数据 
                Material mt = new Material();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        mt.Name = ds.Tables[0].Rows[i][0].ToString();
                        mt.Supplier = ds.Tables[0].Rows[i][1].ToString();
                        mt.Unit = ds.Tables[0].Rows[i][2].ToString();
                        mt.StockCount = int.Parse(ds.Tables[0].Rows[i][3].ToString());
                        if (mtMgr.AddNewMaterial(mt) != 0)
                        {
                            richTextBox1.Text += "原料信息[" + mt.Name + "]生成成功！\r\n";
                        }
                        else
                            richTextBox1.Text += "原料信息[" + mt.Name + "]生成失败，请仔细核准数据！\r\n";
                    }
                    catch (Exception ex) { richTextBox1.Text += "原料信息[" + mt.Name + "]生成失败，请仔细核准数据！\r\n"; };
                }
            }
            catch (Exception ex) { };
        }
    }
}
