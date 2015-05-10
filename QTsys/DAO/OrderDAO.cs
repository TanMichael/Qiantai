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
            string sql = "SELECT * FROM qiaotai.订单;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public string GetAutoNum()
        {
            //string sql = "SELECT LAST_INSERT_ID();";
            string sql = "select max(订单编号) from 订单";
            //string sql = "select @订单编号";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
           // MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
           
           // DataTable dt = new DataTable();
            this.Connection.Open();
           // ap.Fill(dt); 
            string a  = cmd.ExecuteScalar().ToString();
            this.Connection.Close();          
            return a;
        }



        public DataTable GetAllSells()//为销售显示
        {
            string sql = "SELECT 订单.发货时间,订单.最后更新时间,订单.收货联系人,订单.订单编号,订单明细.产品编号,订单明细.数量,订单明细.单价,订单明细.数量*订单明细.单价 AS 金额 FROM 订单 LEFT JOIN 订单明细 ON 订单.订单编号=订单明细.订单编号;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }


        public DataTable GetAllOrderDetailsBySerial(string key)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM qiaotai.订单明细 WHERE 订单编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd); 
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); return dt; }
        }

        public DataTable GetAllOrderDetailsBySerialEx(string key)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT 产品信息.产品名称,产品信息.规格,订单明细.数量,订单明细.单价,订单明细.折扣,订单明细.成交价 FROM 订单明细  LEFT JOIN 产品信息 ON 订单明细.产品编号=产品信息.产品编号 WHERE 订单明细.订单编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); return dt; }
        }



        public DataTable GetAllOrderByState(string key)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM qiaotai.订单 WHERE 订单状态 LIKE '%" + key + "%';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); return dt; }
        }

        public DataTable GetOrderByCreator(string userName)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM qiaotai.订单 WHERE 创建人='" + userName + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                this.Connection.Open();
                ap.Fill(dt);
                this.Connection.Close();
                return dt;
            }
            catch (Exception ex) { this.Connection.Close(); return dt; }
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
            catch (Exception ex) { this.Connection.Close(); return dt; }
        }

        public DataTable GetAllOrdersByTime(DateTime date1, DateTime date2)
        {
            string sql = "SELECT * FROM qiaotai.订单 WHERE 创建时间>'" + date1.ToString() + "' AND 创建时间<'" + date2.ToString() + "';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public int AddNewOrder(Order order)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.订单(创建时间,发货时间,最后更新时间,客户编号,订单状态,快递单号,订金方式,收货地址,收货联系人,收货电话,创建人) VALUES ('" +
                    order.CreateTime + "','" + order.DeliverTime + "','" + order.LastUpdateTime + "','" + order.CustomerId + "','" + order.OrderStatus + "','" + order.ExpressNO + "','" + order.DepositMode + "','" + order.RecieverAddress + "','" + order.RecieverName + "','" + order.RecieverPhone + "','" + order.Creator + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                this.Connection.Close();
                return (int)id;
            }
            catch (Exception ex) { return 0; }
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
            catch (Exception ex) { return false; }
        }
        public bool AltOrder(Order order)
        {
            try
            {
                string sql = "UPDATE qiaotai.订单 SET 发货时间='" + order.DeliverTime + "',最后更新时间='" + order.LastUpdateTime + "',订单状态='" + order.OrderStatus + "',快递单号='" + order.ExpressNO + "',订金方式='" + order.DepositMode + "',收货地址='" + order.RecieverAddress + "',收货联系人='" + order.RecieverName + "',收货电话='" + order.RecieverPhone + "',创建人='" + order.Creator + "' WHERE 订单编号='" + order.OrderId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery(); 
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool UpdateOrderStatus(string status, string oId)
        {
            try
            {
                string sql = "UPDATE qiaotai.订单 SET 订单状态='" + status + "' WHERE 订单编号='" + oId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool AddNewOrderDetail(OrderDetail order)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.订单明细(订单编号,产品编号,数量,单价,折扣,成交价) VALUES ('" + order.OrderId+ "','" + order.ProductId + "','" + order.Count + "','" + order.Price + "','" + order.Discount + "','" + order.RealPrice + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                //var id = cmd.LastInsertedId;
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool DelOrderDetail(OrderDetail order)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.订单明细 WHERE 订单编号='" + order.OrderId + "' AND 产品编号='"+order.ProductId+"';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool AltOrderDetail(OrderDetail order)
        {
            try
            {
                string sql = "UPDATE qiaotai.订单明细 SET 订单编号='" + order.OrderId + "',产品编号='" + order.ProductId + "',数量='" + order.Count + "',单价='" + order.Price + "',折扣='" + order.Discount + "',成交价='" + order.RealPrice + "' WHERE 订单编号='" + order.OrderId + "' AND 产品编号='"+order.ProductId+"';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }




    }
}
