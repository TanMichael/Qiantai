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
        
        public DataTable GetAllMsg()//更新
        {
            Customer cus = new Customer();
            string sql = "SELECT * FROM qiaotai.操作记录;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public DataTable GetGetAllMsgByAction(string action)//更新
        {
            Customer cus = new Customer();
            string sql = "SELECT * FROM qiaotai.操作记录 WHERE 操作动作='"+action+"';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }
        

    }
}