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


        public DataTable GetMaterialProductRelationByProduct(String ID)
        {
            //  Material material = new Material();
            string sql = "SELECT * FROM qiaotai.产品原料关系 WHERE 产品编号='" + ID + "';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public bool AltMaterialProductRelation(ProductMaterial pmr)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品原料关系 SET 原料编号='" + pmr.MaterialId + "',产品编号='" + pmr.ProductId + "',原料数量='" + pmr.MaterialCount + "' WHERE 原料编号='" + pmr.MaterialId + "' AND 产品编号='" + pmr.ProductId + "';";
              
              
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool DelMaterialProductRelation(ProductMaterial pmr)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.产品原料关系 WHERE 原料编号='" + pmr.MaterialId + "' AND 产品编号='" + pmr.ProductId + "';";   
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool AddMaterialProductRelation(ProductMaterial pmr)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.产品原料关系(原料编号,产品编号,原料数量) VALUES ('" + pmr.MaterialId + "','" + pmr.ProductId + "','" + pmr.MaterialCount  + "');";
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
