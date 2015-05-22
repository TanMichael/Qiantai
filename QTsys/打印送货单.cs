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

namespace QTsys
{
    public partial class 打印送货单 : Form
    {
        private string 单号;

        public 打印送货单(string id)
        {
            InitializeComponent();
            单号 = id;
        }

        private void 送货单_Load(object sender, EventArgs e)
        {
            DateTime A = DateTime.Now.AddDays(1 - DateTime.Now.Day + 24).AddMonths(-1);
            date_up.Value = A;
            date_down.Value = DateTime.Now;
            webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\送货单.htm");//显示网页
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
            //用string类替换
            webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_OVER.htm");//显示网页
        }

    }
}
