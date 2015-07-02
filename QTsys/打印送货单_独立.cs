using QTsys.Common.Constants;
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
                label1订单编号.Text = dataGridView订单.Rows[selectOrderIdx].Cells["订单编号"].Value.ToString();
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
            try
            {
                selectedPlanIdx = e.RowIndex;
                selectedPlanId = dataGridView生产计划.Rows[selectedPlanIdx].Cells["编号"].Value.ToString();
                textBox已发货数.Text = dataGridView生产计划.CurrentRow.Cells["已发货数"].Value.ToString();
                textBox已完成生产数.Text = dataGridView生产计划.CurrentRow.Cells["已完成生产数"].Value.ToString();
                textBox订单数量.Text = dataGridView生产计划.CurrentRow.Cells["产品数量"].Value.ToString();
                textBox当前生产数.Text = dataGridView生产计划.CurrentRow.Cells["本次发货数"].Value.ToString();

                string planState = dataGridView生产计划.CurrentRow.Cells["生产状态"].Value.ToString();
                if (planState == ProductionPlanStatus.TO_BE_SHIP || planState == ProductionPlanStatus.PROCESSING)
                {
                    button打印送货单.Enabled = true;
                    button生成送货单.Enabled = true;
                    button1.Enabled = true;
                }
                else
                {
                    button打印送货单.Enabled = false;
                    button生成送货单.Enabled = false;
                    button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void insetnewlist()//生成新的销售单表
        {
            try
            {
            double count = 0;//存储金额总数
            StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_DATA.htm", Encoding.GetEncoding("unicode"));
            string usedata = rd.ReadToEnd();
            rd.Close();
            //把数据读入usedata
            //**替换操作*************************************************************
            usedata = usedata.Replace("text0", label1订单编号.Text);
            usedata = usedata.Replace("text1", textBox客户名称.Text);
            usedata = usedata.Replace("text2", text收货地址.Text);
            usedata = usedata.Replace("text3", com客户联系人.Text);
            usedata = usedata.Replace("text4", text联系电话.Text);
            usedata = usedata.Replace("year", DateTime.Now.Year.ToString());
            usedata = usedata.Replace("month", DateTime.Now.Month.ToString());
            usedata = usedata.Replace("day", DateTime.Now.Day.ToString());
            //------------------------------------------------------------------------
            string staticstr = "<tr style='mso-yfti-irow:6;height:17.25pt'> <td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt: solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm; height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data11<o:p></o:p></span></p> </td> <td style='border:none;border-bottom:solid windowtext 1.0pt;mso-border-top-alt: solid windowtext .5pt;mso-border-top-alt:solid windowtext .5pt;mso-border-bottom-alt: solid windowtext .5pt;padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data12<o:p></o:p></span></p> </td> <td nowrap style='border:solid windowtext 1.0pt;border-top:none;mso-border-top-alt: solid windowtext .5pt;mso-border-alt:solid windowtext .5pt;padding:0cm 0cm 0cm 0cm; height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data13<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data14<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data15<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data16<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data17<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data18<o:p></o:p></span></p> </td> <td nowrap style='border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt; border-right:solid windowtext 1.0pt;mso-border-top-alt:solid windowtext .5pt; mso-border-left-alt:solid windowtext .5pt;mso-border-alt:solid windowtext .5pt; padding:0cm 0cm 0cm 0cm;height:17.25pt'> <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US style='font-size:10.0pt; '>data19<o:p></o:p></span></p> </td> </tr>";
            string temp = "";
            string tempstr = "";
                //"<!--*end-->";
            //被替换string
            for (int j = 0; j < dataGridView生产计划.RowCount; j++)
            {
                if (j == 0)
                {
                    usedata = usedata.Replace("data11", label1订单编号.Text);
                    usedata = usedata.Replace("data12", dataGridView生产计划.Rows[j].Cells["规格"].Value.ToString());
                    usedata = usedata.Replace("data13", dataGridView生产计划.Rows[j].Cells["变位"].Value.ToString());
                    usedata = usedata.Replace("data14", dataGridView生产计划.Rows[j].Cells["材质"].Value.ToString());
                    usedata = usedata.Replace("data15", "pcs");
                    usedata = usedata.Replace("data16", dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString());
                    if (checkBox是否单价.Checked)
                    {

                        usedata = usedata.Replace("data17", dataGridView生产计划.Rows[j].Cells["单价"].Value.ToString());
                        usedata = usedata.Replace("data18", Convert.ToString(Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString()) * Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["单价"].Value.ToString())));

                    }
                    else
                    {
                        usedata = usedata.Replace("data16", "");
                        usedata = usedata.Replace("data17", "");
                        usedata = usedata.Replace("data18", "");
                    }
                    usedata = usedata.Replace("data19", "");
                    count += Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString()) * Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["单价"].Value.ToString());
                }
                if (j > 0)
                {
                    temp = staticstr;
                    temp = temp.Replace("data11", label1订单编号.Text);
                    temp = temp.Replace("data12", dataGridView生产计划.Rows[j].Cells["规格"].Value.ToString());
                    temp = temp.Replace("data13", dataGridView生产计划.Rows[j].Cells["变位"].Value.ToString());
                    temp = temp.Replace("data14", dataGridView生产计划.Rows[j].Cells["材质"].Value.ToString());
                    temp = temp.Replace("data15", "pcs");
                    temp = temp.Replace("data16", dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString());
                    if (checkBox是否单价.Checked)
                    {

                        temp = temp.Replace("data17", dataGridView生产计划.Rows[j].Cells["单价"].Value.ToString());
                        temp = temp.Replace("data18", Convert.ToString(Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString()) * Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["单价"].Value.ToString())));
                    }
                    else
                    {
                        temp = temp.Replace("data16", "");
                        temp = temp.Replace("data17", "");
                        temp = temp.Replace("data18", "");
                    }
                    temp = temp.Replace("data19", "");
                    count += Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString()) * Convert.ToDouble(dataGridView生产计划.Rows[j].Cells["单价"].Value.ToString());
                    tempstr += temp;
                }
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
            if (dataGridView生产计划.RowCount<1)
            {
                    MessageBox.Show("请选择有产品的订单！");
                    return;
            }
            for (int j = 0; j < dataGridView生产计划.RowCount; j++)
            {
                if (dataGridView生产计划.Rows[selectedPlanIdx].Cells["已发货数"].ToString() == "" || dataGridView生产计划.Rows[selectedPlanIdx].Cells["已发货数"].ToString() == "0")
                {
                    MessageBox.Show("请输入须送货的数量！");
                    return;
                }
            }
            insetnewlist();
        }

        private bool doCalThenUpdateDB(int iFinished, int iCurrent, int iDelivered, string ppId)
        {
            int currentStore = iFinished - iDelivered;
            int currentRemian = currentStore - iCurrent;
            int finishTobeUpdate = currentRemian > 0 ? iFinished : (iFinished - currentRemian);
            int deliveredTobeUpdate = iDelivered + iCurrent;

            return ppm.UpdatePlanCurrentDeliveryCount(deliveredTobeUpdate, finishTobeUpdate, ppId);
        }

        private void button打印送货单_Click(object sender, EventArgs e)
        {
            try
            {
                for (int j = 0; j < dataGridView生产计划.RowCount; j++)
                {
                    int cCount = int.Parse(dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString());
                    string ppId = dataGridView生产计划.Rows[j].Cells["编号"].Value.ToString();
                    string planState = dataGridView生产计划.Rows[j].Cells["生产状态"].Value.ToString();
                    int finishedCount = int.Parse(dataGridView生产计划.Rows[j].Cells["已完成生产数"].Value.ToString());
                    int iCount = int.Parse(dataGridView生产计划.Rows[j].Cells["已发货数"].Value.ToString());
                    if (iCount + cCount > int.Parse(dataGridView生产计划.Rows[j].Cells["产品数量"].Value.ToString()))
                    {
                        if (planState == ProductionPlanStatus.TO_BE_SHIP)
                        {
                            MessageBox.Show("待发货的订单产品已从库存扣除，本次发货数+已发货数不能大于计划数。请重新填写发货数量！");
                            return;
                        }
                        MessageBox.Show("本次发货数+已发货数大于计划数，是否超交？产品【" + dataGridView生产计划.Rows[j].Cells["产品编号"].Value.ToString()+"】");
                    }
                    // update 当前生产数, 已发货数
                    if (!doCalThenUpdateDB(finishedCount, cCount, iCount, ppId))
                    {
                        MessageBox.Show("产品【"+dataGridView生产计划.Rows[j].Cells["产品名称"].Value.ToString()+"】更新失败！");
                        return;
                    }
                }
                //****************
               // selectOrderIdx = e.RowIndex;

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
                //*****************
                webBrowser2.ShowPageSetupDialog();
                webBrowser2.ShowPrintPreviewDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox当前生产数_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView生产计划.Rows[selectedPlanIdx].Cells["本次发货数"].Value = Convert.ToInt32(textBox当前生产数.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            打印快递单 kdd = new 打印快递单(label1订单编号.Text);
            kdd.ShowDialog();
        }
    }
}
