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
using QTsys.Manager;
using QTsys.Common.Constants;

namespace QTsys
{
    public partial class 打印送货单 : Form
    {
        private string 单号;
        private DataTable 订单;
        private DataTable 订单明细;
        private OrderManager odm;

        public 打印送货单(string id)
        {
            InitializeComponent();
            odm = new OrderManager();
            单号 = id;
        }

        private void 送货单_Load(object sender, EventArgs e)
        {
            DateTime A = DateTime.Now.AddDays(1 - DateTime.Now.Day + 24).AddMonths(-1);
            date_up.Value = A;
            date_down.Value = DateTime.Now;
            webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\送货单.htm");//显示网页
            label3.Text = 单号;
            label5.Text = DateTime.Now.ToString();
            订单 = odm.GetAllOrderByStateAndSerial(OrderStatus.PROCESSING, 单号);
            订单明细 = odm.GetAllOrderDetailsBySerialEx(单号);
            comboBox1.Text = 订单.Rows[0]["客户编号"].ToString();
        }

        private void date_up_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insetnewlist();
            webBrowser2.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insetnewlist();
            webBrowser2.ShowPrintPreviewDialog();
        }

        public void insetnewlist()//生成新的销售单表
        {
            //关于对送货单_OVER.htm的操作，让送货单_DATA.htm产生数据，取代送货单.htm
            //用string类替换html中的关键字
            //空表格为“送货单.htm”，可替换送货单部分有“送货单_DATA.HTM”, 数据处理完存储在“送货单_OVER.htm”
            webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_OVER.htm");//显示网页
        }

    }
}
