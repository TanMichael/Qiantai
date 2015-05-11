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

        public DataTable GetAllProductFlow()
        {
            string sql = "SELECT * FROM qiaotai.产品进出库;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }


        public DataTable GetAllProductsByNameEX(string col, string value)
        {
            string sql = "SELECT * FROM qiaotai.产品信息 WHERE " + col + " = '" + value + "';";
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

        public DataTable GetAllProductFlowByName(string col, string value)
        {
            string sql = "SELECT * FROM qiaotai.产品进出库 WHERE " + col + " LIKE '%" + value + "%';";
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

        public DataTable GetMaterialProductRelationByProductEx(String ID,int 数量)
        {
            //  Material material = new Material();
            string sql = "SELECT 产品原料关系.原料编号,原材料.原料名称,原材料.单位,产品原料关系.原料数量*"+数量+" AS 需要原料数量,原材料.库存数量 FROM 产品原料关系 LEFT JOIN 原材料 ON 产品原料关系.原料编号=原材料.原料编号 WHERE 产品编号='" + ID + "';";
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


        //产品信息增删改
        public int AddNewProduct(Product pdt)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.产品信息(产品名称,规格,材质,变位,实测变位,温度,生产耗时,压力,树脂名称,树脂比重,含浸尺寸,外盘,内治具,重量,成型模,切模号,单位,单价,库存数量) VALUES ('" + pdt.Name + "','" + pdt.Standard + "','" + pdt.Texture + "','" + pdt.Shift + "','" + pdt.RealShift + "','" + pdt.Temperate + "','" + pdt.ElapsedTime + "','" + pdt.Presure + "','" + pdt.ResinName + "','" + pdt.ResinProportion + "','" + pdt.Soak + "','" + pdt.Outsize + "','" + pdt.Jig + "','" + pdt.Weight + "','" + pdt.Formingdie + "','" + pdt.ModingNum + "','" + pdt.Unit + "','" + pdt.Price + "','" + pdt.StockCount + "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                this.Connection.Close();
                return (int)id;
            }
            catch (Exception ex) { return 0; }
        }




        public bool DelProduct(String key)
        {
            try
            {
                string sql = "DELETE FROM qiaotai.产品信息 WHERE 产品编号='" + key + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool AltProduct(Product pdt)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品信息 SET 产品名称='" + pdt.Name + "',规格='" + pdt.Standard + "',材质='" + pdt.Texture + "',变位='" + pdt.Shift + "',实测变位='" + pdt.RealShift + "',温度='" + pdt.Temperate + "',生产耗时='" + pdt.ElapsedTime + "',压力='" + pdt.Presure + "',树脂名称='" + pdt.ResinName + "',树脂比重='" + pdt.ResinProportion + "',含浸尺寸='" + pdt.Soak + "',外盘='" + pdt.Outsize + "',内治具='" + pdt.Jig + "',重量='" + pdt.Weight + "',成型模='" + pdt.Formingdie + "',切模号='" + pdt.ModingNum + "',单位='" + pdt.Unit + "',单价='" + pdt.Price + "',库存数量='" + pdt.StockCount + "' WHERE 产品编号='" + pdt.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public DataTable GetProductsWithCustomer(string customerId)
        {
            string sql = "SELECT p.* FROM qiaotai.产品信息 p inner join qiaotai.产品客户关系 pc on p.产品编号=pc.产品编号 where pc.客户编号=" +
                customerId + " order by pc.成交次数 desc;";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;

        }

        //产品进出仓

        public bool AddNewProductFlow(ProductFlow pdt)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.产品进出库(产品编号,发生时间,类型,相关订单编号,相关计划编号,不合格产品数,当前状态) VALUES ('" + pdt.ProductId + "','" + pdt.OccurredTime + "','" + pdt.Type + "','" + pdt.RelatedOrderId + "','" + pdt.RelatedPlanId + "','" + pdt.UnqualifiedCount + "','" + pdt.Status + "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
            //    var id = cmd.LastInsertedId;
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool AddProductCount(string 产品编号,int 产品数量)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品信息 SET 库存数量= 库存数量 +" + 产品数量 + " WHERE 产品编号='" + 产品编号 + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                //    var id = cmd.LastInsertedId;
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { return false; }
        }

       
    }
}
