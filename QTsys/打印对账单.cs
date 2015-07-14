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
        public static string templatePath = Directory.GetCurrentDirectory() + "\\各种单据\\对账单_template.htm";
        public static string targetPath = Directory.GetCurrentDirectory() + "\\各种单据\\对账单_target.htm";

        public 打印对账单()
        {
                InitializeComponent();           
        }

        public 打印对账单(对账 parent, DataTable dt, int pages)
            : this()
        {
            int page = pages;//设置10行分页

            string customerName = parent.comboBox客户.Text;
            DateTime startDate = parent.dateTimePicker对账起始日.Value;
            DateTime endDate = parent.dateTimePicker对账截止日.Value;
            DateTime today = DateTime.Today;
            string contact = parent.com客户联系人.Text;
            string phone = parent.text联系电话.Text;
            string addr = parent.text收货地址.Text;
            string fax = parent.textBox传真.Text;
            string payMod = parent.textBox结算方式.Text;
            string year = endDate.Year.ToString();
            string month = endDate.Month.ToString();


            string result = Utils.GetTemplateContent(templatePath);
            //string result = "";

           
            string value = "";
            bool nextpage = false;
            int pagenum = 0;
            double totalSum = 0;

            string 发货时间 = "";
            string 送货单号 = "";
            string 产品名称 = "";
            string 订单编号 = "";
            string 规格 = "";
            string 材质 = "";
            string 数量 = "";
            string 成交价 = "";
            string 金额 = "";

            for (int p = 0; p < dt.Rows.Count / page + 1; p++)
            {
                for (int i = 0; i < page; i++)
                {
                    if (dt.Rows.Count == i + p * page)
                    {
                        nextpage = false;
                        break;
                    }
                    nextpage = true;
                    value += "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes;height:14.2pt'>";
                    发货时间 = dt.Rows[i + p * page]["发货时间"].ToString();
                    送货单号 = dt.Rows[i + p * page]["送货单号"].ToString();
                    产品名称 = dt.Rows[i + p * page]["产品名称"].ToString();
                    订单编号 = dt.Rows[i + p * page]["订单编号"].ToString();
                    规格 = dt.Rows[i + p * page]["规格"].ToString();
                    材质 = dt.Rows[i + p * page]["材质"].ToString();
                    数量 = dt.Rows[i + p * page]["数量"].ToString();
                    成交价 = dt.Rows[i + p * page]["成交价"].ToString();
                    金额=Convert.ToString( Convert.ToDouble(成交价)* Convert.ToInt32(数量));
                  totalSum += Convert.ToDouble(成交价)* Convert.ToUInt32(数量);
                    value += Utils.GetTableTD(发货时间) + Utils.GetTableTD(送货单号) + Utils.GetTableTD(产品名称) + Utils.GetTableTD(订单编号) + Utils.GetTableTD(规格) + Utils.GetTableTD(材质) + Utils.GetTableTD(数量) + Utils.GetTableTD(成交价) + Utils.GetTableTD(金额) + "</tr>";
                }

                if ((p + 1) * page == dt.Rows.Count)
                    nextpage = false;

                if (+dt.Rows.Count % page > 0)
                    pagenum = dt.Rows.Count / page + 1;
                else
                    pagenum = dt.Rows.Count / page;
                result = result.Replace("{页码}", Convert.ToString(p + 1) + "/" + Convert.ToString(pagenum));
                result = result.Replace("{table_content}", value);

                if (nextpage)
                {
                    result += "<p style=\"page-break-after:always;\"> </p>";//分页
                    result += Utils.GetTemplateContent(templatePath);
                    value = "";
                }

            }

             result = result.Replace("{年份}", year);
            result = result.Replace("{月份}", month);
            result = result.Replace("{客户名称}", customerName);
            result = result.Replace("{结算方式}", payMod);
            result = result.Replace("{列印日期}", today.ToShortDateString());
            result = result.Replace("{联系人}", contact);
            result = result.Replace("{性质}", " ");
            result = result.Replace("{联系电话}", phone);
            result = result.Replace("{起始日期}", startDate.ToShortDateString());
            result = result.Replace("{币种}", "RMB");
            result = result.Replace("{传真}", fax);
            result = result.Replace("{截止日期}", endDate.ToShortDateString());
            result = result.Replace("{单位}", " ");
            result = result.Replace("{地址}", addr);
            result = result.Replace("{总金额}", totalSum.ToString());    
            result = result.Replace("{财务}", Utils.GetLogonToken().Name);

            Utils.WriteToTemplate(targetPath, result);
            webBrowser预览.Url = new Uri(targetPath);//显示网页
        }

        private void button打印_Click(object sender, EventArgs e)
        {
            //webBrowser预览.Print();
            webBrowser预览.ShowPageSetupDialog();
            webBrowser预览.ShowPrintPreviewDialog();
        }

        private void 打印对账单_Load(object sender, EventArgs e)
        {

        }
    }
}
