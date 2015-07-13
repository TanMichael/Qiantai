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
            webBrowser预览.ShowPrintPreviewDialog();
        }

        public 打印报价单(新增报价单 parent, DataTable dt,int pages)
            : this()
        {
            int page = pages;//设置10行分页
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

            result = result.Replace("{月份}", month);
            result = result.Replace("{客户名称}", customerName);
            result = result.Replace("{结算方式}", payMod);
            result = result.Replace("{列印日期}", year + "年" + month + "月" + DateTime.Now.Day.ToString() + "日");
            result = result.Replace("{联系人}", contact);
            result = result.Replace("{联系电话}", phone);
            result = result.Replace("{传真}", fax);
            result = result.Replace("{地址}", addr);
            string value = "";
            bool nextpage = false;
            int pagenum = 0;

            string 产品编号 = "";
            string 产品名称 = "";
            string 规格 = "";
            string 材质 = "";
            string 变位 = "";
            string 单价 = "";
            string 备注 = "";

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
                    产品编号 = dt.Rows[i + p * page]["产品编号"].ToString();
                    产品名称 = dt.Rows[i + p * page]["产品名称"].ToString();
                    规格 = dt.Rows[i + p * page]["规格"].ToString();
                    材质 = dt.Rows[i + p * page]["材质"].ToString();
                    变位 = dt.Rows[i + p * page]["变位"].ToString();
                    单价 = dt.Rows[i + p * page]["单价"].ToString();
                    备注 = dt.Rows[i + p * page]["备注"].ToString();
                    value += Utils.GetTableTD(产品编号) + Utils.GetTableTD(产品名称) + Utils.GetTableTD(规格) + Utils.GetTableTD(材质) + Utils.GetTableTD(变位) + Utils.GetTableTD(单价) + Utils.GetTableTD(备注) + "</tr>";
                }

                if ((p + 1) * page == dt.Rows.Count)
                    nextpage = false;

                if (+dt.Rows.Count % page > 0)
                    pagenum = dt.Rows.Count / page + 1;
                else
                    pagenum = dt.Rows.Count / page;
                result = result.Replace("{页数}", Convert.ToString(p + 1) + "/" + Convert.ToString(pagenum));
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
            result = result.Replace("{列印日期}", year + "年" + month + "月" + DateTime.Now.Day.ToString() + "日");
            result = result.Replace("{联系人}", contact);
            result = result.Replace("{联系电话}", phone);
            result = result.Replace("{传真}", fax);
            result = result.Replace("{地址}", addr);
            result = result.Replace("{财务}", Utils.GetLogonToken().Name);

            Utils.WriteToTemplate(targetPath, result);

            webBrowser预览.Url = new Uri(targetPath);//显示网页

        }


        private void 打印报价单_Load(object sender, EventArgs e)
        {

        }
    }
}
