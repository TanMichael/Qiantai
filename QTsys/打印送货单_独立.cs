using QTsys.Manager;
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
    public partial class 打印送货单_独立 : Form
    {
        private OrderManager odm;
        private ProductPlanManager ppm;
        private int selectOrderIdx;
        private string selectedCustomerId;
        private int selectedPlanIdx;
        private string selectedPlanId;

        public 打印送货单_独立()
        {
            InitializeComponent();
            odm = new OrderManager();
            ppm = new ProductPlanManager();
        }

        private void 打印送货单_独立_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView订单.DataSource = odm.GetOrderInProduction();
                dataGridView订单.Update();
                webBrowser2.Url = new Uri(Directory.GetCurrentDirectory() + "\\各种单据\\送货单.htm");//显示网页
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView订单_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectOrderIdx = e.RowIndex;

                var orderId = dataGridView订单.Rows[selectOrderIdx].Cells["订单编号"].Value.ToString();
                selectedCustomerId = dataGridView订单.Rows[selectOrderIdx].Cells["客户编号"].Value.ToString();
                var customerName = dataGridView订单.Rows[selectOrderIdx].Cells["客户名称"].Value.ToString();
                var cAddr = dataGridView订单.Rows[selectOrderIdx].Cells["收货地址"].Value.ToString();
                var cPhone = dataGridView订单.Rows[selectOrderIdx].Cells["收货电话"].Value.ToString();
                var cContact = dataGridView订单.Rows[selectOrderIdx].Cells["收货联系人"].Value.ToString();
                //var cPayMode = dataGridView订单.Rows[selectOrderIdx].Cells["订单编号"].Value.ToString();

                textBox客户名称.Text = customerName;
                text联系电话.Text = cPhone;
                text收货地址.Text = cAddr;

                if (selectedCustomerId != "")
                {
                    com客户联系人.DataSource = new UserManager().GetCustomerMembersByCId(selectedCustomerId);
                    com客户联系人.Update();

                    com客户联系人.DisplayMember = "Name";
                    com客户联系人.ValueMember = "Id";
                }
                com客户联系人.Text = cContact;

                dataGridView生产计划.DataSource = ppm.GetProductPlanByOrder4Print(orderId);
                dataGridView生产计划.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView生产计划_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPlanIdx = e.RowIndex;
            selectedPlanId = dataGridView生产计划.Rows[selectedPlanIdx].Cells["编号"].Value.ToString();
        }

        public void insetnewlist()//生成新的销售单表
        {
            try{
            //关于对送货单_OVER.htm的操作，让送货单_DATA.htm产生数据，取代送货单.htm
            //用string类替换html中的关键字
            //空表格为“送货单.htm”，可替换送货单部分有“送货单_DATA.HTM”, 数据处理完存储在“送货单_OVER.htm”
            //double count = 0;//存储金额总数
            StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_DATA.htm", Encoding.GetEncoding("unicode"));
            string usedata = rd.ReadToEnd();
            rd.Close();
            //把数据读入usedata
            //**替换操作*************************************************************
            usedata = usedata.Replace("text0", label3.Text);
            usedata = usedata.Replace("text1", textBox客户名称.Text);
            usedata = usedata.Replace("text2", text收货地址.Text);
            usedata = usedata.Replace("text3", com客户联系人.Text);
            usedata = usedata.Replace("text4", text联系电话.Text);
            usedata = usedata.Replace("year", DateTime.Now.Year.ToString());
            usedata = usedata.Replace("month", DateTime.Now.Month.ToString());
            usedata = usedata.Replace("day", DateTime.Now.Day.ToString());
            //------------------------------------------------------------------------
            //抓取表格数据
           string staticstr = "<tr style='mso-yfti-irow:6;height:17.25pt'> <td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt: solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm; height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data11<o:p></o:p></span></p> </td> <td style='border:none;border-bottom:solid windowtext 1.0pt;mso-border-top-alt: solid windowtext .5pt;mso-border-top-alt:solid windowtext .5pt;mso-border-bottom-alt: solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data12<o:p></o:p></span></p> </td> <td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt: solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm; height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data13<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data14<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data15<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data16<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data17<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data18<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data19<o:p></o:p></span></p> </td> </tr>";
            string temp = "";
            string tempstr = "";
            double count = Convert.ToDouble(dataGridView生产计划.Rows[selectedPlanIdx].Cells["数量"].ToString());
            string sPrice = dataGridView生产计划.Rows[selectedPlanIdx].Cells["单价"].ToString();

            if (selectedPlanIdx > -1)
                {
                    usedata = usedata.Replace("data11", label3.Text);
                    usedata = usedata.Replace("data12", dataGridView生产计划.Rows[selectedPlanIdx].Cells["规格"].ToString());
                    usedata = usedata.Replace("data13", dataGridView生产计划.Rows[selectedPlanIdx].Cells["变位"].ToString());
                    usedata = usedata.Replace("data14", dataGridView生产计划.Rows[selectedPlanIdx].Cells["材质"].ToString());
                    usedata = usedata.Replace("data15", "pcs");
                    usedata = usedata.Replace("data16", dataGridView生产计划.Rows[selectedPlanIdx].Cells["数量"].ToString());
                    if (checkBox是否单价.Checked)
                    {
                        // 从计划拿数据，只能拿到规定单价。如需成交价要改sql，先这样！
                        usedata = usedata.Replace("data17", sPrice);
                        usedata = usedata.Replace("data18", Convert.ToString(count * Convert.ToDouble(sPrice)));
                    }
                    else
                    {
                        usedata = usedata.Replace("data16", "");
                        usedata = usedata.Replace("data17", "");
                        usedata = usedata.Replace("data18", "");
                    }
                    usedata = usedata.Replace("data19", "");
                    count += Convert.ToDouble(count * Convert.ToDouble(sPrice));
                }
                
            usedata = usedata.Replace("<!--*end-->", tempstr);
            //------------------------------------------------------------------------
            if (checkBox是否单价.Checked)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button生成送货单_Click(object sender, EventArgs e)
        {
            insetnewlist();
        }

        private void button打印送货单_Click(object sender, EventArgs e)
        {
            string cCount = textBox当前生产数.Text;
            string ppId = selectedPlanId;
            int iCount = int.Parse(cCount);
            if (iCount > int.Parse(dataGridView生产计划.Rows[selectedPlanIdx].Cells["产品数量"].Value.ToString()))
            {
                MessageBox.Show("超交？");
            }
            // update 当前生产数
            if (ppm.UpdatePlanCurrentDeliveryCount(int.Parse(cCount), ppId))
            {
                webBrowser2.ShowPageSetupDialog();
                webBrowser2.ShowPrintPreviewDialog();
            }
        }
    }
}
