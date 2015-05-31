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

        public 打印制造单()
        {
            InitializeComponent();
            planid = "";
            isnewplan = true;
        }

        public 打印制造单(string planID)
        {
            InitializeComponent();
           planid = planID;
            isnewplan = false;
        }

        private void 打印制造单_Load(object sender, EventArgs e)
        {
            if (isnewplan == true)
            {
                webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\制造指令单.htm");
            }
            else
            {
             //通过生产计划ID获取产品相关数据

                webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\制造指令单_DATA.htm");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser2.Print();
            webBrowser2.ShowPrintDialog(); 
            //webBrowser2.ShowPageSetupDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser2.ShowPageSetupDialog();
           webBrowser2.ShowPrintPreviewDialog();
        }
    }
}
