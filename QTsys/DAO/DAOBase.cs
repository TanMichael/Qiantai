using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using QTsys.Common;

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

        public MySqlConnection Connection
        {
            get { return this._conn; }
            private set {this._conn = value;}
        }
    }
}
