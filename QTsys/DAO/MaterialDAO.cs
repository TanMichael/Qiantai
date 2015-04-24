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
    class MaterialDAO : DAOBase
    {
        public DataTable GetAllMaterials()
        {
            Material material=new Material();
            string sql = "SELECT * FROM qiaotai.原材料;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public bool AddNewMaterial(Material material)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.原材料(原料编号,原料名称,单位,库存数量) VALUES ('" + material.Id + "','" + material.Name + "','" + material.Unit + "','" + material.StockCount + "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool DelMaterial(String key)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.原材料 WHERE 原料编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool AltMaterial(Material material)
        {
            try
            {
                string sql = "UPDATE qiaotai.原材料 SET 原料编号='" + material.Id + "',原料名称='" + material.Name + "',单位='" + material.Unit + "',库存数量='" + material.StockCount + "' WHERE 原料编号='" + material.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public DataTable GetAllMaterialsByName(string col, string value)
        {
            Material material = new Material();
            string sql = "SELECT * FROM qiaotai.原材料 WHERE "+col+" LIKE '%"+value+"%';";
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
