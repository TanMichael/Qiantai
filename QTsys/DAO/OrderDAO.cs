using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using QTsys.DataObjects;
using System.Data;

namespace QTsys.DAO
{
    class OrderDAO : DAOBase
    {
        public DataTable GetAllOrders()
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.订单 ORDER BY 创建时间 DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }


        public DataTable GetOrderBySerial(string num)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.订单 WHERE 订单编号='" + num + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public string GetAutoNum()
        {
            try
            {
                //string sql = "SELECT LAST_INSERT_ID();";
                string sql = "select max(订单编号) from 订单";
                //string sql = "select @订单编号";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                // MySqlDataAdapter ap = new MySqlDataAdapter(cmd);

                // DataTable dt = new DataTable();
                this.Connection.Open();
                // ap.Fill(dt); 
                string a = cmd.ExecuteScalar().ToString();
                this.Connection.Close();
                return a;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }



        public DataTable GetAllSells(DateTime startDate, DateTime endDate)//为销售显示
        {
            try
            {
                string sql = "SELECT d.客户名称,d.订单编号,d.发货时间,d.创建时间,dd.产品编号,p.产品名称,p.规格,p.材质,dd.数量,dd.单价,dd.成交价,dd.数量*dd.成交价 AS 金额 " +
                    "FROM qiaotai.订单 d INNER JOIN qiaotai.订单明细 dd ON d.订单编号=dd.订单编号 INNER JOIN qiaotai.产品信息 p ON dd.产品编号=p.产品编号 " +
                    "WHERE d.创建时间>'" + startDate.ToString("yyyy/MM/dd HH:mm:ss") + "' and d.创建时间<'" + endDate.AddDays(1).ToString("yyyy/MM/dd HH:mm:ss") + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }


        public DataTable GetAllOrderDetailsBySerial(string key)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM qiaotai.订单明细 WHERE 订单编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetAllOrderDetailsBySerialEx(string key)
        {

            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT 产品信息.产品编号,产品信息.产品名称,产品信息.规格,产品信息.变位,产品信息.材质,产品信息.规格,订单明细.数量,订单明细.单价,订单明细.折扣,订单明细.成交价 FROM 订单明细  LEFT JOIN 产品信息 ON 订单明细.产品编号=产品信息.产品编号 WHERE 订单明细.订单编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }



        public DataTable GetAllOrderByState(string key)
        {

            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM qiaotai.订单 WHERE 订单状态 LIKE '%" + key + "%' ORDER BY 创建时间 DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public DataTable GetAllOrderByStateAndSerial(string state, string key)
        {

            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM 订单 WHERE 订单.订单状态 ='" + state + "'AND 订单.订单编号='" + key + "' ORDER BY 创建时间 DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetFinishedSampleOrders()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT d.订单编号,c.客户名称,d.创建人,d.创建时间 FROM qiaotai.订单 d inner join qiaotai.客户信息 c " +
                    "on d.客户编号=c.客户编号 WHERE d.订单状态='交易成功' and d.是否样品订单='是' ORDER BY d.创建时间 DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetOrderByCreator(string userName)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM qiaotai.订单 WHERE 创建人='" + userName + "' ORDER BY 创建时间 DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetAllOrderDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM qiaotai.订单明细;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetAllOrdersByTime(DateTime date1, DateTime date2)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.订单 WHERE 创建时间>'" + date1.ToString("yyyy/MM/dd HH:mm:ss") + "' AND 创建时间<'" + date2.ToString("yyyy/MM/dd HH:mm:ss") + "' ORDER BY 创建时间 DESC;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public int AddNewOrder(Order order)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.订单(创建时间,发货时间,最后更新时间,客户编号,客户订单号,是否样品订单,订单状态,快递单号,订金方式,收货地址,收货联系人,收货电话,创建人,客户名称) VALUES ('" +
                    order.CreateTime.ToString("yyyy/MM/dd HH:mm:ss") + "','" + order.DeliverTime.ToString("yyyy/MM/dd HH:mm:ss") + "','" + order.LastUpdateTime.ToString("yyyy/MM/dd HH:mm:ss") + "','" + order.CustomerId + "','" + order.CustomerOrderId + "','" + order.IsSample + "','" + order.OrderStatus + "','" +
                    order.ExpressNO + "','" + order.DepositMode + "','" + order.RecieverAddress + "','" + order.RecieverName + "','" + order.RecieverPhone + "','" + order.Creator + "','" + order.CustomerName + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                this.Connection.Close();
                return (int)id;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public bool DelOrder(String key)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.订单 WHERE 订单编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public bool AltOrder(Order order)
        {
            try
            {
                string sql = "UPDATE qiaotai.订单 SET 发货时间='" + order.DeliverTime.ToString("yyyy/MM/dd HH:mm:ss") + "',最后更新时间='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "',订单状态='" + order.OrderStatus + "',客户订单号='" + order.CustomerOrderId +
                    "',快递单号='" + order.ExpressNO + "',送货单号='" + order.DeliverNO + "',订金方式='" + order.DepositMode + "',收货地址='" + order.RecieverAddress + "',收货联系人='" + order.RecieverName + "',收货电话='" + order.RecieverPhone + "',创建人='" + order.Creator + "' WHERE 订单编号='" + order.OrderId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool UpdateOrderStatus(string status, string oId)
        {
            try
            {
                string sql = "UPDATE qiaotai.订单 SET 订单状态='" + status + "',最后更新时间='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' WHERE 订单编号='" + oId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool AddNewOrderDetail(OrderDetail order)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.订单明细(订单编号,产品编号,数量,单价,折扣,成交价) VALUES ('" + order.OrderId + "','" + order.ProductId + "','" + order.Count + "','" + order.Price + "','" + order.Discount + "','" + order.RealPrice + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                //var id = cmd.LastInsertedId;
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public bool DelOrderDetail(OrderDetail order)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.订单明细 WHERE 订单编号='" + order.OrderId + "' AND 产品编号='" + order.ProductId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public bool AltOrderDetail(OrderDetail order)
        {
            try
            {
                string sql = "UPDATE qiaotai.订单明细 SET 订单编号='" + order.OrderId + "',产品编号='" + order.ProductId + "',数量='" + order.Count + "',单价='" + order.Price + "',折扣='" + order.Discount + "',成交价='" + order.RealPrice + "' WHERE 订单编号='" + order.OrderId + "' AND 产品编号='" + order.ProductId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }





        public DataTable GetReconciliation(string customerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                // 根据彭芸要求显示客户订单号，而不是系统订单号 so d.客户订单号 as 订单编号 instead of d.订单编号
                //string sql = "select d.发货时间,d.送货单号,p.产品名称,d.客户订单号 as 订单编号,p.规格,p.材质,dd.数量,dd.成交价,dd.数量*dd.成交价 as 金额 from qiaotai.订单 d " +
                //            "inner join qiaotai.订单明细 dd on d.订单编号 = dd.订单编号 " +
                //            "inner join qiaotai.产品信息 p on dd.产品编号 = p.产品编号 " +
                //            "where d.客户编号=" + customerId + " and d.发货时间>'" + startDate.ToString("yyyy/MM/dd HH:mm:ss") + "' and d.发货时间<'" + endDate.AddDays(1).ToString("yyyy/MM/dd HH:mm:ss") + "';";
                string sql = "select r.发货时间,r.送货单号,rd.产品名称,r.客户订单号 as 订单编号,rd.规格,rd.材质,rd.数量,rd.成交价,rd.金额 from qiaotai.送货记录 r inner join qiaotai.送货记录细节 rd on r.送货单号=rd.送货单号 " +
                             "where r.客户编号=" + customerId + " and r.发货时间>'" + startDate.ToString("yyyy/MM/dd HH:mm:ss") + "' and r.发货时间<'" + endDate.AddDays(1).ToString("yyyy/MM/dd HH:mm:ss") + "';";

                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                this.Connection.Close();
                throw ex;
            }
        }

        public int GetMaxDeliverID()
        {  int outnum = 0;
            try
            {
                string sql = "select Max(送货单号) from 送货记录;";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                //MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                outnum = Int32.Parse(cmd.ExecuteScalar().ToString());
                this.Connection.Close();
                return outnum;
            }
            catch (Exception ex)
            {
                this.Connection.Close();
                throw ex;
            }
        }

        public DataTable GetOrderInProduction()
        {
            try
            {
                string sql = "SELECT 订单编号,客户名称,是否样品订单,订单状态,快递单号,订金方式,收货地址,收货联系人,收货电话,创建人,客户编号 FROM qiaotai.订单 WHERE 订单状态='处理中' or 订单状态='打包中';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                this.Connection.Close();
                throw ex;
            }
        }

        public int InsertDeliverRecord(string selectedCustomerId, string customerName, string orderId, DateTime now, string expressNO, string username)
        {
            try  
            {
                string sql = "INSERT INTO qiaotai.送货记录(客户编号,客户名称,客户订单号,是否样品订单,发货时间,快递单号,创建人) VALUES ('" +
                    selectedCustomerId + "','" + customerName + "','" + orderId + "','','" + now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + expressNO + "','" + username + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                this.Connection.Close();
                return (int)id;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool InsertDeliverRecordDetail(DeliveryRecords record)
        {

            try  
            {
                string sql = "INSERT INTO qiaotai.送货记录细节(送货单号,产品名称,规格,材质,数量,成交价,金额) VALUES ('" +
                    record.DeliveryRecordId + "','" + record.ProductName + "','" + record.Standard + "','" + record.Texture + "'," + record.Count + "," + record.Price + "," + record.Sum + ")";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                //var id = cmd.LastInsertedId;
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
    }
}
