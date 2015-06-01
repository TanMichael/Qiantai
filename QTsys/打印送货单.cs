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
            text客户名称.Text = 订单.Rows[0]["客户名称"].ToString();
            text联系人.Text = 订单.Rows[0]["收货联系人"].ToString();
            text送货地址.Text = 订单.Rows[0]["收货地址"].ToString();
            text联系电话.Text = 订单.Rows[0]["收货电话"].ToString();
            dataGridView1.DataSource = 订单明细;
            dataGridView1.Update();
        }

        private void date_up_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                insetnewlist();
            }
            catch (Exception ex) { };
           // webBrowser2.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //insetnewlist();
            webBrowser2.ShowPageSetupDialog();
            webBrowser2.ShowPrintPreviewDialog();
        }

        public void insetnewlist()//生成新的销售单表
        {
            //关于对送货单_OVER.htm的操作，让送货单_DATA.htm产生数据，取代送货单.htm
            //用string类替换html中的关键字
            //空表格为“送货单.htm”，可替换送货单部分有“送货单_DATA.HTM”, 数据处理完存储在“送货单_OVER.htm”
            double count = 0;//存储金额总数
            StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_DATA.htm", Encoding.GetEncoding("unicode"));
            string usedata = rd.ReadToEnd();
            rd.Close();
            //把数据读入usedata
            //**替换操作*************************************************************
            usedata = usedata.Replace("text0",label3.Text);
            usedata = usedata.Replace("text1", text客户名称.Text);
            usedata = usedata.Replace("text2", text送货地址.Text);
            usedata = usedata.Replace("text3", text联系人.Text);
            usedata = usedata.Replace("text4", text联系电话.Text);
            usedata = usedata.Replace("year", DateTime.Now.Year.ToString());
            usedata = usedata.Replace("month", DateTime.Now.Month.ToString());
            usedata = usedata.Replace("day", DateTime.Now.Day.ToString());
            //------------------------------------------------------------------------
            //抓取表格数据
            /*
            switch (dataGridView1.RowCount)//加入表格字段
            {
                case 0: usedata = usedata.Replace("data12", "以下表格为空"); break;
                case 1: usedata = usedata.Replace("data22", "以下表格为空"); break;
                case 2: usedata = usedata.Replace("data32", "以下表格为空"); break;
                case 3: usedata = usedata.Replace("data42", "以下表格为空"); break;
                case 4: usedata = usedata.Replace("data52", "以下表格为空"); break;
                case 5: usedata = usedata.Replace("data62", "以下表格为空"); break;
                default:
                    break;
            }*/
            //------------------------------------------------------------------------计算data0
            /*for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                data0 += Convert.ToDouble(dataGridView1.Rows[j].Cells[8].Value) * Convert.ToDouble(dataGridView1.Rows[j].Cells[9].Value);
            }
            usedata = usedata.Replace("data0", data0.ToString());
            textBox6.Text = data0.ToString();
            */
            //------------------------------------------------------------------------
            string staticstr = "<tr><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:  solid windowtext .5pt;mso-border-alt:             solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;height:17.25pt'>data11</td><td>data12</td><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:    solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;    height:17.25pt'>data13</td><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:    solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;    height:17.25pt'>data14</td><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:    solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;    height:17.25pt'>data15</td><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:    solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;    height:17.25pt'>data16</td><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:    solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;    height:17.25pt'>data17</td><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:    solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;    height:17.25pt'>data18</td><td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt:    solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;    height:17.25pt'>data19</td></tr> ";
            string temp = "";
            string tempstr = "";
                //"<!--*end-->";
            //被替换string
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                if (j == 0)
                {
                    usedata = usedata.Replace("data11", label3.Text);
                    usedata = usedata.Replace("data12", 订单明细.Rows[j]["规格"].ToString());
                    usedata = usedata.Replace("data13", 订单明细.Rows[j]["变位"].ToString());
                    usedata = usedata.Replace("data14", 订单明细.Rows[j]["材质"].ToString());
                    usedata = usedata.Replace("data15", "pcs");
                    if (checkBox1.Checked)
                    {
                        usedata = usedata.Replace("data16", 订单明细.Rows[j]["数量"].ToString());
                        usedata = usedata.Replace("data17", 订单明细.Rows[j]["成交价"].ToString());
                        usedata = usedata.Replace("data18", Convert.ToString(Convert.ToDouble(订单明细.Rows[j]["数量"].ToString()) * Convert.ToDouble(订单明细.Rows[j]["成交价"].ToString())));
                    }
                    else {
                        usedata = usedata.Replace("data16","");
                        usedata = usedata.Replace("data17", "");
                        usedata = usedata.Replace("data18", "");
                    }
                    usedata = usedata.Replace("data19", "");
                    count += Convert.ToDouble(订单明细.Rows[j]["数量"].ToString()) * Convert.ToDouble(订单明细.Rows[j]["成交价"].ToString());
                }
                if (j > 0) {
                    temp = staticstr;
                  temp = temp.Replace("data11", label3.Text);
                    temp = temp.Replace("data12", 订单明细.Rows[j]["规格"].ToString());
                    temp = temp.Replace("data13", 订单明细.Rows[j]["变位"].ToString());
                    temp = temp.Replace("data14", 订单明细.Rows[j]["材质"].ToString());
                    temp = temp.Replace("data15", "pcs");
                    if (checkBox1.Checked)
                    {
                        temp = temp.Replace("data16", 订单明细.Rows[j]["数量"].ToString());
                        temp = temp.Replace("data17", 订单明细.Rows[j]["成交价"].ToString());
                        temp = temp.Replace("data18", Convert.ToString(Convert.ToDouble(订单明细.Rows[j]["数量"].ToString()) * Convert.ToDouble(订单明细.Rows[j]["成交价"].ToString())));
                    }
                    else
                    {
                        temp = temp.Replace("data16", "");
                        temp = temp.Replace("data17", "");
                        temp = temp.Replace("data18", "");
                    }
                    temp = temp.Replace("data19", "");
                    count += Convert.ToDouble(订单明细.Rows[j]["数量"].ToString()) * Convert.ToDouble(订单明细.Rows[j]["成交价"].ToString());
                    tempstr += temp;
                }
            }
            usedata = usedata.Replace("<!--*end-->", tempstr);
            //------------------------------------------------------------------------
            if (checkBox1.Checked)
            { usedata = usedata.Replace("data0", count.ToString()); }
            else
            { usedata = usedata.Replace("data0", ""); }
            //***************************************************************
            //把usedata写入送货单_OVER并更新
            File.Delete(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_OVER.htm");
            StreamWriter wr = new StreamWriter(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_OVER.htm", true, Encoding.GetEncoding("unicode"));
            wr.Write(usedata);
            wr.Close(); 
            webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_OVER.htm");//显示网页
        }

    }
}
