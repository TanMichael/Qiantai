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
    public partial class 送货单 : Form
    {
        public 送货单()
        {
            InitializeComponent();
        }

        private void 送货单_Load(object sender, EventArgs e)
        {
            DateTime A = DateTime.Now.AddDays(1 - DateTime.Now.Day + 24).AddMonths(-1);
            date_up.Value = A;
            date_down.Value = DateTime.Now;
            webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\HTMLPRINT_EMPTY.htm");//显示网页
        }

        private void date_up_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
