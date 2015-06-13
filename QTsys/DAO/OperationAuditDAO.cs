using MySql.Data.MySqlClient;
using QTsys.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DAO
{
    class OperationAuditDAO : DAOBase
    {

        public DataTable GetAllMsg(DateTime up, DateTime down)//更新
        {
            try
            {
                Customer cus = new Customer();
                string sql = "SELECT * FROM qiaotai.操作记录 WHERE 操作时间>'" + up.ToString() + "' AND 操作时间<'" + down.ToString() + "';";
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

        public DataTable GetGetAllMsgByAction(string type, string action, DateTime up, DateTime down)//更新
        {
            try
            {
                Customer cus = new Customer();
                string sql = "SELECT * FROM qiaotai.操作记录 WHERE " + type + " LIKE '%" + action + "%' AND 操作时间>'" + up.ToString() + "' AND 操作时间<'" + down.ToString() + "';";
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


    }
}