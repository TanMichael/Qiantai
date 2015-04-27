using MySql.Data.MySqlClient;
using QTsys.Common;
using QTsys.DataObjects;
using System;

namespace QTsys.DAO
{
    class DAOBase
    {
        private MySqlConnection _conn;

        public DAOBase()
        {
            if (this._conn == null)
            {
                //this._conn = new MySqlConnection(mysqlStr);
                var config = Utils.ReadConnConfig();
                
                //连接数据库，读取数据
                String mysqlStr = "Server=" + config.Server + ";Database=" + config.Database + ";Data Source=" + config.DataSource +
                    ";User Id=" + config.UserId + ";Password=" + config.Password + ";pooling=" + config.Pooling + ";CharSet=" +
                    config.CharSet + ";port=" + config.Port + "";
                this._conn = new MySqlConnection(mysqlStr);
            }
        }

        protected void LogAction(OperationAudit audit)
        {
            string sql = "INSERT INTO qiaotai.操作记录 (操作员,操作动作,操作对象,操作结果,操作时间) VALUES ('" +
                audit.Operator + "','" + audit.Action + "','" + audit.OperateObject + "','" + audit.Result + "','" + audit.OperateTime + "');";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            this.Connection.Open();
            cmd.ExecuteNonQuery();
            this.Connection.Close();
        }

        public MySqlConnection Connection
        {
            get { return this._conn; }
            private set {this._conn = value;}
        }
    }
}
