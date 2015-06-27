using QTsys.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTsys
{
    public partial class 打印报价单 : Form
    {
        public static string templatePath = Directory.GetCurrentDirectory() + "\\各种单据\\报价单_template.htm";
        public static string targetPath = Directory.GetCurrentDirectory() + "\\各种单据\\报价单_target.htm";

        public 打印报价单()
        {
            InitializeComponent();
        }

        private void button打印_Click(object sender, EventArgs e)
        {
            webBrowser预览.Print();
        }

        public 打印报价单(新增报价单 parent, DataTable dt)
            : this()
        {
            string customerID = parent.l编号.Text;
            string customerName = parent.com客户名.Text;
            string contact = parent.com客户联系人.Text;
            string phone = parent.text联系电话.Text;
            string addr = parent.text收货地址.Text;
            string fax = "";
            string payMod = parent.com结算方式.Text;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string result = Utils.GetTemplateContent(templatePath);
            //string result = "";

            result = result.Replace("{年份}", year);
            result = result.Replace("{月份}", month);
            result = result.Replace("{客户名称}", customerName);
            result = result.Replace("{结算方式}", payMod);
            result = result.Replace("{列印日期}", year + "年" + month + "月" + DateTime.Now.Day.ToString()+"日");
            result = result.Replace("{联系人}", contact);
            //result = result.Replace("{性质}", year);
            //result = result.Replace("{页码}", year);
            result = result.Replace("{联系电话}", phone);
            //result = result.Replace("{币种}", year);
            result = result.Replace("{传真}", fax);
            //result = result.Replace("{单位}", year);
            result = result.Replace("{地址}", addr);

            string value = "";

           

            foreach (DataRow row in dt.Rows)
            {
                string 产品编号 = row["产品编号"].ToString();
                string 产品名称 = row["产品名称"].ToString();
                string 规格 = row["规格"].ToString();    // TODO: time format
                string 材质 = row["材质"].ToString();
                string 变位 = row["变位"].ToString();
                string 单价 = row["单价"].ToString();
                string 备注 = row["备注"].ToString();

                value += Utils.GetTableTR(new string[]
                {
                    Utils.GetTableTD(产品编号),
                    Utils.GetTableTD(产品名称),
                    Utils.GetTableTD(规格),
                    Utils.GetTableTD(材质),
                    Utils.GetTableTD(变位),
                    Utils.GetTableTD(单价),
                    Utils.GetTableTD(备注)
                });
            }
            result = result.Replace("{财务}", Utils.GetLogonToken().Name);
            result = result.Replace("{table_content}", value);
            //if (File.Exists(targetPath))
            //{
            //    File.Delete(targetPath);
            //}
            //File.Create(targetPath);

            Utils.WriteToTemplate(targetPath, result);

            webBrowser预览.Url = new Uri(targetPath);//显示网页

        }


        private void 打印报价单_Load(object sender, EventArgs e)
        {

        }
    }
}
