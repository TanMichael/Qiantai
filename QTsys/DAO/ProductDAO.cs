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
    class ProductDAO : DAOBase
    {
        public DataTable GetAllProducts()
        {
            string sql = "SELECT * FROM qiaotai.产品信息;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public DataTable GetAllProductsByName(string col, string value)
        {
            string sql = "SELECT * FROM qiaotai.产品信息 WHERE " + col + " LIKE '%" + value + "%';";
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
