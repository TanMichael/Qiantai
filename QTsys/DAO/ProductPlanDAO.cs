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
        public DataTable GetAllProductPlan()
        {
            string sql = "SELECT * FROM qiaotai.生产计划;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public DataTable GetAllProductPlanByName(string col, string value)
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

        public DataTable GetAllProductPlanByTime(DateTime date1, DateTime date2)
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
        //------------------------------------------------
        public bool AddNewPlan(ProductionPlan pp )
        {
            try
            {
                string sql = "INSERT INTO qiaotai.生产计划(产品编号,客户编号,下单日期,产品数量,交付时间,实际完成时间,计划类型,相关订单编号,负责人) VALUES ('" + pp.ProductId+ "','" + pp.CustomerId + "','" +pp.OrderTime + "','" + pp.Count + "','" + pp.PlanningTime + "','" + pp.FinishTime+ "','" +pp.PlanType + "','" +pp.RelatedOrderId + "','" + pp.InChargePerson + "')";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
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
            catch (Exception ex) { return false; }
        }
        public bool AltPlan(ProductionPlan pp)
        {
            try
            {
                string sql = "UPDATE qiaotai.生产计划 SET 产品编号='" + pp.ProductId + "',客户编号='" + pp.CustomerId + "',下单日期='" +pp.OrderTime + "',产品数量='" + pp.Count + "',交付时间='" +pp.PlanningTime + "',实际完成时间='" + pp.FinishTime + "',计划类型='" + pp.PlanType + "',相关订单编号='" + pp.RelatedOrderId + "',负责人='" + pp.InChargePerson + "' WHERE 编号='" + pp.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }
     //---------------------------------------------- 
    }
}
