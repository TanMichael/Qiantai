using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QTsys.DataObjects;
using QTsys.Manager;
using QTsys.Common.Constants;
using QTsys.Common;
using QTsys.DAO;


namespace QTsys
{
    public partial class 打印制造单 : Form
    {
        private bool isnewplan;
        private string planid;
        private ProductPlanDAO pdao;

        public 打印制造单()
        {
            InitializeComponent();
            planid = "";
            isnewplan = true;
            pdao = new ProductPlanDAO();
        }

        public 打印制造单(string planID)
        {
            InitializeComponent();
           planid = planID;
            isnewplan = false;
            pdao = new ProductPlanDAO();
        }

        private void 打印制造单_Load(object sender, EventArgs e)
        {
            text编号.Text = planid;
            comboBox1.Text = "否";
            if (isnewplan == true)
            {
                webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\生产单.htm");
            }
            else
            {
             //通过生产计划ID获取产品相关数据

                webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\生产单.htm");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser2.Print();
           // webBrowser2.ShowPrintDialog(); 
            //webBrowser2.ShowPageSetupDialog(); 
            webBrowser2.ShowPageSetupDialog();
            webBrowser2.ShowPrintPreviewDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //webBrowser2.ShowPrintPreviewDialog();
            insetnewlist();
        }

        public void insetnewlist()//生成新的工程制作指示单
        {
            try
            {
                StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + "\\各种单据\\生产单_DATA.htm", Encoding.GetEncoding("gb2312"));
                string usedata = rd.ReadToEnd();
                rd.Close();
                //把数据读入usedata
               //**替换操作*************************************************************
               DataTable ds=new DataTable();
                ds=pdao.GetAllProductPlanByNameEX("编号",text编号.Text);
                usedata = usedata.Replace("《下单编号》", text编号.Text);
                usedata = usedata.Replace("《开单日期》", ds.Rows[0]["下单日期"].ToString());
                usedata = usedata.Replace("《客编》", ds.Rows[0]["客户编号"].ToString());
                usedata = usedata.Replace("《客户料号》", "  ");
                usedata = usedata.Replace("《工程单编号》", ds.Rows[0]["产品编号"].ToString());
                usedata = usedata.Replace("《订单号》", ds.Rows[0]["相关订单编号"].ToString());
                usedata = usedata.Replace("《订单数量》", ds.Rows[0]["产品数量"].ToString());
                usedata = usedata.Replace("《交货日期》", ds.Rows[0]["交付时间"].ToString());
                usedata = usedata.Replace("《包装要求》", textBox3.Text);
                usedata = usedata.Replace("《可否超交》", comboBox1.Text);
                usedata = usedata.Replace("《备注》", textBox1.Text);
                
                //把usedata写入生产单_OVER并更新
                File.Delete(Directory.GetCurrentDirectory() + "\\各种单据\\生产单_OVER.htm");
                StreamWriter wr = new StreamWriter(Directory.GetCurrentDirectory() + "\\各种单据\\生产单_OVER.htm", true, Encoding.GetEncoding("gb2312"));
                wr.Write(usedata);
                wr.Close();
                webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\生产单_OVER.htm");//显示网页
            }
            catch (Exception ex)
            {
                MessageBox.Show("请先选择一个产品！");
            }
        }
    }
}
