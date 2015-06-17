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
    class ProductPlanDAO : DAOBase
    {
        public DataTable GetAllProductPlan(bool reallyAll)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.生产计划";
                if (!reallyAll)
                {
                    sql += " where 生产状态 <> '待审核' and 生产状态 <> '取消' and 生产状态 <> '入库'";
                }
                sql += ";";
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

        public DataTable GetAllProductPlanByName(string col, string value)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.生产计划 WHERE " + col + " LIKE '%" + value + "%';";
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

        public DataTable GetAllProductPlanByNameEX(string col, string value)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.生产计划 WHERE " + col + " = '" + value + "';";
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


        public DataTable GetAllProductPlanByStates(string value)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.生产计划 WHERE 生产状态 = '" + value + "';";
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


        public DataTable GetAllProductPlanByTime(DateTime date1, DateTime date2)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.生产计划 WHERE 下单日期>'" + date1.ToString() + "' AND 下单日期<'" + date2.ToString() + "';";
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
        //------------------------------------------------
        public bool AddNewPlan(ProductionPlan pp)
        {
            try
            {

                // string sql = "INSERT INTO qiaotai.生产计划(产品编号,客户编号,下单日期,产品数量,交付时间,实际完成时间,计划类型,生产状态,相关订单编号,负责人) VALUES ('" + pp.ProductId + "','" + pp.CustomerId + "','" + pp.OrderTime + "','" + pp.Count + "','" + pp.PlanningTime + "','" + pp.FinishTime + "','" + pp.PlanType + "','" + pp.PlanState + "','" + pp.RelatedOrderId + "','" + pp.InChargePerson + "')";
                string sql = "INSERT INTO qiaotai.生产计划(产品编号,客户编号,生产状态,下单日期,产品数量,交付时间,实际完成时间,计划类型,相关订单编号,负责人,当前生产数) VALUES ('" +
                    pp.ProductId + "','" + pp.CustomerId + "','" + pp.PlanState + "','" + pp.OrderTime.ToString("yyyy/MM/dd HH:mm:ss") + "','" + pp.Count + "','" + pp.PlanningTime.ToString("yyyy/MM/dd HH:mm:ss") + "','" + pp.FinishTime.ToString("yyyy/MM/dd HH:mm:ss") +
                    "','" + pp.PlanType + "','" + pp.RelatedOrderId + "','" + pp.InChargePerson + "',0)";

                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public bool DelPlan(String key)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.生产计划 WHERE 编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public bool AltPlan(ProductionPlan pp)
        {
            try
            {
                string sql = "UPDATE qiaotai.生产计划 SET 产品编号='" + pp.ProductId + "',客户编号='" + pp.CustomerId + "',下单日期='" +
                    pp.OrderTime.ToString("yyyy/MM/dd HH:mm:ss") + "',产品数量='" + pp.Count + "',交付时间='" + pp.PlanningTime.ToString("yyyy/MM/dd HH:mm:ss") + "',实际完成时间='" + pp.FinishTime.ToString("yyyy/MM/dd HH:mm:ss") +
                    "',计划类型='" + pp.PlanType + "',生产状态='" + pp.PlanState + "',相关订单编号='" + pp.RelatedOrderId + "',负责人='" + pp.InChargePerson +
                    "' WHERE 编号='" + pp.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool UpdatePlanStatus(string status, string pId)
        {
            try
            {
                string sql = "UPDATE qiaotai.生产计划 SET 生产状态='" + status + "' WHERE 编号='" + pId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        //---------------------------------------------- 

        public DataTable GetProductPlanByOrder(string orderId)
        {
            try
            {
                string sql = "SELECT * FROM qiaotai.生产计划 WHERE 相关订单编号=" + orderId + ";";
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

        public DataTable GetProductPlanByOrder4Print(string orderId)
        {
            try
            {
                string sql = "select p.产品编号, pro.产品名称,p.产品数量,p.当前生产数 AS 已发货数,0 AS 本次发货数, pro.规格, pro.变位, pro.材质, pro.单价, p.客户编号,  p.生产状态, p.下单日期, p.最后更新时间, p.编号 " +
                    "from qiaotai.生产计划 p inner join qiaotai.产品信息 pro on p.产品编号=pro.产品编号 where p.相关订单编号=" + orderId + ";";
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

        public bool UpdatePlanCurrentDeliveryCount(int count, string ppId)
        {
            try
            {
                string sql = "update qiaotai.生产计划 set 当前生产数 = 当前生产数+" + count.ToString() + ", 最后更新时间='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "' where 编号 =" + ppId + ";";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                this.Connection.Close();
                throw ex;
            }
        }
    }
}
