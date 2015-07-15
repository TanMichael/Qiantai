using QTsys.Common;
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

        public void insetnewlist(int page)//生成新的销售单表
        {
            try
            {
                int allpage = 0;//实际有效行
                for (int j = 0; j < dataGridView生产计划.RowCount; j++)
                {
                    if (dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString() != "0")
                        allpage++;
                }
                if (allpage < 1)
                {
                    MessageBox.Show("未生产发货情况单据！请输入发货数量！");
                    return;
                }
               // MessageBox.Show(allpage.ToString());
                int pages=1;//设置分页数为10
                int pagesnum = 1;
                double count = 0;//存储金额总数
                StreamReader rd = new StreamReader(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_DATA.htm", Encoding.Default);
                string usedatatemp = rd.ReadToEnd();
                string usedata = usedatatemp;
                rd.Close();
                if (allpage % page == 0)
                {
                    pages = allpage / page;
                }
                else
                {
                    pages = allpage / page + 1;
                }
                //把数据读入usedata
                //**替换操作*************************************************************
                usedata = usedata.Replace("text0", label1订单编号.Text + "(第" + pagesnum.ToString() + "页,共" + pages.ToString() + "页)");
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
                bool firstline = true;
                //被替换string
               // result += "<p style=\"page-break-after:always;\"> </p>";//分页
                int useline = -1;//有效行号
                for (int j= 0; j < dataGridView生产计划.RowCount; j++)
                {
                    //判断此行是否有效
                    if (dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString() == "0")
                    { continue; }
                    else
                    {
                        useline++;
                    }
                    if ((useline + 1) % page == 1 && (useline + 1) > page)
                    {
                        pagesnum++;
                        firstline = true;
                        usedata = usedata.Replace("<!--*end-->", tempstr);
                        usedata += "<p style=\"page-break-after:always;\"> </p>";//分页
                        usedata += usedatatemp;
                        usedata = usedata.Replace("text0", label1订单编号.Text + "(第" + pagesnum.ToString() + "页,共" + pages.ToString() + "页)");
                        usedata = usedata.Replace("text1", textBox客户名称.Text);
                        usedata = usedata.Replace("text2", text收货地址.Text);
                        usedata = usedata.Replace("text3", com客户联系人.Text);
                        usedata = usedata.Replace("text4", text联系电话.Text);
                        usedata = usedata.Replace("year", DateTime.Now.Year.ToString());
                        usedata = usedata.Replace("month", DateTime.Now.Month.ToString());
                        usedata = usedata.Replace("day", DateTime.Now.Day.ToString());
                        tempstr = "";
                    }
                    if (firstline==true )
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
                        firstline = false;
                    }
                    if (firstline == false && j > 0 && (j + 1) % page !=1)
                    {
                        temp = staticstr;
                        temp = temp.Replace("data11", label1订单编号.Text );
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
                StreamWriter wr = new StreamWriter(Directory.GetCurrentDirectory() + "\\各种单据\\送货单_OVER.htm", true, Encoding.Default);
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
            try
            {
                if (dataGridView生产计划.RowCount < 1)
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
                insetnewlist(Convert.ToUInt16(textBox分页数量.Text));
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
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
                var orderId = "";
                var customerName = "";
                var cAddr = "";
                var cPhone = "";
                var cContact = "";

                string proName = "";
                string guige = "";
                string caizhi = "";
                double price = 0;

                string ppId = "";
                string planState = "";
                int finishedCount = 0;
                int iCount = 0;

                int cCount = 0;
                /*  int j = selectedPlanIdx;
                  if (j < 0)
                  {
                      return;
                  }*/

                for (int j = 0; j < dataGridView生产计划.RowCount; j++)
                {

                    cCount = int.Parse(dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString());
                    //   = int.Parse(dataGridView生产计划.Rows[j].Cells["本次发货数"].Value.ToString());
                    /*
                                    if (cCount <= 0)
                                    {
                                        MessageBox.Show("本次发货数要大于0！");
                                        return;
                                    }*/
                    if (cCount <= 0)
                    {
                        //  MessageBox.Show("本次发货数要大于0！");、
                        //对0发货数行不处理
                        continue;
                    }

                    proName = dataGridView生产计划.Rows[j].Cells["产品名称"].Value.ToString();
                    guige = dataGridView生产计划.Rows[j].Cells["规格"].Value.ToString();
                    caizhi = dataGridView生产计划.Rows[j].Cells["材质"].Value.ToString();
                    price = double.Parse(dataGridView生产计划.Rows[j].Cells["单价"].Value.ToString());

                    ppId = dataGridView生产计划.Rows[j].Cells["编号"].Value.ToString();
                    planState = dataGridView生产计划.Rows[j].Cells["生产状态"].Value.ToString();
                    finishedCount = int.Parse(dataGridView生产计划.Rows[j].Cells["已完成生产数"].Value.ToString());
                    iCount = int.Parse(dataGridView生产计划.Rows[j].Cells["已发货数"].Value.ToString());
                    if (iCount + cCount > int.Parse(dataGridView生产计划.Rows[j].Cells["产品数量"].Value.ToString()))
                    {
                        if (planState == ProductionPlanStatus.TO_BE_SHIP)
                        {
                            MessageBox.Show("待发货的订单产品已从库存扣除，本次发货数+已发货数不能大于计划数。请重新填写发货数量！");
                            continue;
                        }
                        MessageBox.Show("本次发货数+已发货数大于计划数，是否超交？产品【" + dataGridView生产计划.Rows[j].Cells["产品编号"].Value.ToString() + "】");
                    }
                    // update 当前生产数, 已发货数
                    if (!doCalThenUpdateDB(finishedCount, cCount, iCount, ppId))
                    {
                        MessageBox.Show("产品【" + proName + "】更新失败！");
                        return;
                    }
                    //}
                    //****************
                    // selectOrderIdx = e.RowIndex;

                    orderId = dataGridView订单.Rows[selectOrderIdx].Cells["订单编号"].Value.ToString();
                    selectedCustomerId = dataGridView订单.Rows[selectOrderIdx].Cells["客户编号"].Value.ToString();
                    customerName = dataGridView订单.Rows[selectOrderIdx].Cells["客户名称"].Value.ToString();
                    cAddr = dataGridView订单.Rows[selectOrderIdx].Cells["收货地址"].Value.ToString();
                    cPhone = dataGridView订单.Rows[selectOrderIdx].Cells["收货电话"].Value.ToString();
                    cContact = dataGridView订单.Rows[selectOrderIdx].Cells["收货联系人"].Value.ToString();
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

                    // 插入送货记录表，为跟客户结账
                    odm.InsertDeliverRecord(selectedCustomerId, customerName, orderId, "",
                                            proName, guige, caizhi,
                                            cCount, price, price * cCount,
                                            DateTime.Now, "", Utils.GetCurrentUsername());

                }
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
