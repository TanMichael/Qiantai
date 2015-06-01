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
                        oleconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + resultFile + ";Extended Properties='Excel 8.0;HDR=YES'";
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
                    cus.Name = ds.Tables[0].Rows[i][0].ToString();
                    cus.DefaultContact = ds.Tables[0].Rows[i][1].ToString();
                    cus.Address = ds.Tables[0].Rows[i][2].ToString();
                    cus.Phone = ds.Tables[0].Rows[i][3].ToString();
                    cus.Fax = ds.Tables[0].Rows[i][4].ToString();
                    cus.Email = ds.Tables[0].Rows[i][5].ToString();
                    cus.PaymentMode = ds.Tables[0].Rows[i][6].ToString();
                    cus.Serial = ds.Tables[0].Rows[i][7].ToString();
                    cus.Remarks = ds.Tables[0].Rows[i][8].ToString();
                    if (this.userMgr.AddNewCustomer(cus))
                    {
                        richTextBox1.Text += "新客户[" + cus.Name + "]生成成功！\r\n";
                    }
                    else
                        richTextBox1.Text += "新客户[" + cus.Name + "]生成失败，请核实信息！\r\n";
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
                    pdt.Name = ds.Tables[0].Rows[i][0].ToString();
                    pdt.Standard = ds.Tables[0].Rows[i][1].ToString();
                    pdt.Texture = ds.Tables[0].Rows[i][2].ToString();
                    pdt.Shift = ds.Tables[0].Rows[i][3].ToString();
                    pdt.RealShift = ds.Tables[0].Rows[i][4].ToString();
                    pdt.Color = ds.Tables[0].Rows[i][5].ToString();

                    // TODO
                    //pdt.ElapsedTime = ds.Tables[0].Rows[i][6].ToString();
                    //pdt.Presure = ds.Tables[0].Rows[i][7].ToString();
                    //pdt.ResinName = ds.Tables[0].Rows[i][8].ToString();
                    //pdt.ResinProportion = ds.Tables[0].Rows[i][9].ToString();
                    //pdt.Soak = ds.Tables[0].Rows[i][10].ToString();
                    //pdt.Outsize = ds.Tables[0].Rows[i][11].ToString();
                    //pdt.Jig = ds.Tables[0].Rows[i][12].ToString();
                    //pdt.Weight = ds.Tables[0].Rows[i][13].ToString();
                    //pdt.Formingdie = ds.Tables[0].Rows[i][14].ToString();
                    //pdt.ModingNum = ds.Tables[0].Rows[i][15].ToString();
                    pdt.Unit = ds.Tables[0].Rows[i][16].ToString();
                    pdt.Price = Convert.ToDouble(ds.Tables[0].Rows[i][17].ToString());
                    pdt.StockCount = Convert.ToInt16(ds.Tables[0].Rows[i][18].ToString());
                    if (pdtMgr.AddNewProduct(pdt)!=0)
                    {
                        richTextBox1.Text += "新产品[" + pdt.Name + "]生成成功！\r\n";
                    }
                    else
                        richTextBox1.Text += "新产品[" + pdt.Name + "]生成失败，请仔细核准数据！\r\n";
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
                        MessageBox.Show("插入失败！");
                }
            }
            catch (Exception ex) { };
        }
    }
}
