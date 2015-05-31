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
    public partial class 打印对账单 : Form
    {
        public static string templatePath = Directory.GetCurrentDirectory() + "\\对账单_template.htm";
        public static string targetPath = Directory.GetCurrentDirectory() + "\\对账单_target.htm";

        public 打印对账单()
        {
                InitializeComponent();           
        }

        public 打印对账单(对账 parent, DataTable dt)
            : this()
        {
            string customerName = parent.comboBox客户.Text;
            DateTime startDate = parent.dateTimePicker对账起始日.Value;
            DateTime endDate = parent.dateTimePicker对账截止日.Value;
            DateTime today = DateTime.Today;
            string contact = parent.com客户联系人.Text;
            string phone = parent.text联系电话.Text;
            string addr = parent.text收货地址.Text;
            string year = endDate.Year.ToString();
            string month = endDate.Month.ToString();


            string result = Utils.GetTemplateContent(templatePath);
            //string result = "";

            result = result.Replace("{年份}", year);
            result = result.Replace("{月份}", month);
            result = result.Replace("{客户名称}", customerName);
            //result = result.Replace("{结算方式}", year);
            result = result.Replace("{列印日期}", today.ToShortDateString());
            result = result.Replace("{联系人}", contact);
            //result = result.Replace("{性质}", year);
            //result = result.Replace("{页码}", year);
            result = result.Replace("{联系电话}", phone);
            result = result.Replace("{起始日期}", startDate.ToShortDateString());
            //result = result.Replace("{币种}", year);
            //result = result.Replace("{传真}", year);
            result = result.Replace("{截止日期}", endDate.ToShortDateString());
            //result = result.Replace("{单位}", year);
            result = result.Replace("{地址}", addr);

            string value = "";

            foreach (DataRow row in dt.Rows)
            {
                string productName = row["产品名称"].ToString();
                string standard = row["规格"].ToString();
                string deliverTime = row["发货时间"].ToString();    // TODO: time format
                string deliverNO = row["送货单号"].ToString();
                string orderId = row["订单编号"].ToString();
                string texture = row["材质"].ToString();
                string count = row["数量"].ToString();
                string price = row["成交价"].ToString();
                string sum = row["金额"].ToString();

                value += Utils.GetTableTR(new string[]
                {
                    Utils.GetTableTD(deliverTime),
                    Utils.GetTableTD(deliverNO),
                    Utils.GetTableTD(productName),
                    Utils.GetTableTD(orderId),
                    Utils.GetTableTD(standard),
                    Utils.GetTableTD(texture),
                    Utils.GetTableTD(count),
                    Utils.GetTableTD(price),
                    Utils.GetTableTD(sum)
                });
            }
            result = result.Replace("{table_content}", value);

            //if (File.Exists(targetPath))
            //{
            //    File.Delete(targetPath);
            //}
            //File.Create(targetPath);

            Utils.WriteToTemplate(targetPath, result);

            webBrowser预览.Url = new Uri(targetPath);//显示网页
        }

        private void button打印_Click(object sender, EventArgs e)
        {
            webBrowser预览.Print();
        }
    }
}
