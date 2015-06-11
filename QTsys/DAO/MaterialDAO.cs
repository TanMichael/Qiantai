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
        public DataTable GetAllMaterialFlow()
        {
            MaterialFlow material = new MaterialFlow();
            string sql = "SELECT * FROM qiaotai.原材料进出仓 ORDER BY 编号 DESC;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public int AddNewMaterial(Material material)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.原材料(原料名称,单位,库存数量,供应商) VALUES ('" + material.Name + "','" + material.Unit + "','" + material.StockCount + "','" + material.Supplier + "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                this.Connection.Close();
                return (int)id;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool UpdateMaterial(Material material)
        {
            try
            {
                string sql = "UPDATE qiaotai.原材料 SET 库存数量=库存数量+" + material.StockCount.ToString() +
                    " ,单位='" + material.Unit + "',供应商='" + material.Supplier + "' WHERE 原料编号=" + material.Id + ";";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        //public bool AddNewMaterial(Material material)//增加进仓原料
        //{
        //    //增加仓库原料，先判断是否存在此种原料，如存在看单位是否一致，名称是否一致，一致则增加库存，否则报错。如没有这种原料则新增一行
        //    try
        //    {
        //        //判断存在
        //        string sql = "SELECT * FROM qiaotai.原材料 WHERE 原料名称='" + material.Name +"' AND 单位='"+material.Unit+"';";
        //        MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
        //        MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        this.Connection.Open();
        //        ap.Fill(dt);
        //        this.Connection.Close();
        //        if (dt.Rows.Count != 0)
        //        {
        //            //存在此种原材料，增加库存
        //            sql = "UPDATE qiaotai.原材料 SET 库存数量='" +Convert.ToString(material.StockCount +Convert.ToUInt16(dt.Rows[0][3].ToString())) +"' WHERE 原料名称='" + material.Name + "' AND 单位='" + material.Unit + "';";
        //            MySqlCommand cmd1 = new MySqlCommand(sql, this.Connection);
        //            this.Connection.Open();
        //            cmd1.ExecuteNonQuery();
        //            this.Connection.Close();
        //            return true;
        //        }
        //        else
        //        {
        //            //不存在此种原材料，增加新材料
                    
        //        }
        //    }
        //    catch (Exception ex) { return false; }
        //}

        public bool AddNewMaterialFlow(MaterialFlow material,String mtName,String mtUnit)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.原材料进出仓(类型,数量,原料编号,供应商,供应单价,发生时间,操作员) VALUES ('" + material.Type + "','" + material.FlowCount + "','" + material.MaterialId + "','" + material.Supplier + "','" + material.Price + "','" + material.OccurredTime.ToString("yyyy/MM/dd HH:mm:ss") + "','" + material.Operator + "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool DelMaterialFlow(MaterialFlow material)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.原材料进出仓 WHERE 库存数量='" + material.FlowCount + "' AND 原料编号='"+material.MaterialId+"';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool AltMaterial(Material material)
        {
            try
            {
                string sql = "UPDATE qiaotai.原材料 SET 原料编号='" + material.Id + "',原料名称='" + material.Name + "',单位='" + material.Unit + "',库存数量='" + material.StockCount + "',供应商='" + material.Supplier + "' WHERE 原料编号='" + material.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool MaterialDesTo(string ID, int desnum)
        {
            try
            {
                string sql = "UPDATE qiaotai.原材料 SET 库存数量='" + desnum + "' WHERE 原料编号='" + ID + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
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

        public DataTable GetAllMaterialFlowByName(string col, string value)
        {
            Material material = new Material();
            string sql = "SELECT * FROM qiaotai.原材料进出仓 WHERE " + col + " LIKE '%" + value + "%';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }


        public DataTable GetSearchIncomeMaterialFlow(string column, string value, DateTime start, DateTime end)
        {
            Material material = new Material();
            string sql = "SELECT * FROM qiaotai.原材料进出仓 WHERE " + column + " LIKE '%" + value + "%' and 发生时间>'" + start.ToString("yyyy/MM/dd HH:mm:ss") + "' and 发生时间<'" + end.AddDays(1).ToString("yyyy/MM/dd HH:mm:ss") + "';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public String GetMaterialNameBySerial(string value)
        {
            Material material = new Material();
            string sql = "SELECT 原料名称 FROM qiaotai.原材料 WHERE " +"原料编号" + " LIKE '%" + value + "%';";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            String name="";
            this.Connection.Open();
            MySqlDataReader read=cmd.ExecuteReader();
            if (read.Read())
            {
                name = read[0].ToString();
               
            }
            this.Connection.Close();
            return name;
        }

    }
}
