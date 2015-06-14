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
            try
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetAllProductFlow()
        {
            try
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }


        public DataTable GetAllProductsByNameEX(string col, string value)
        {
            try
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetAllProductsByName(string col, string value)
        {
            try{
            string sql = "SELECT * FROM qiaotai.产品信息 WHERE " + col + " LIKE '%" + value + "%';";
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

        public DataTable GetProductsByOrder(string oId)
        {
            string sql = "SELECT p.产品编号,p.产品名称,p.规格,p.单位,p.单价 FROM qiaotai.产品信息 p inner join qiaotai.订单明细 o on p.产品编号 = o.产品编号 WHERE o.订单编号=" + oId;
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            this.Connection.Open();
            ap.Fill(dt);
            this.Connection.Close();
            return dt;
        }

        public bool TestPMreltionExist(string Id)
        {
            try
            {
                string sql = "SELECT count(*) FROM qiaotai.产品原料关系 WHERE 产品编号='" + Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd);
                // DataTable dt = new DataTable();
                this.Connection.Open();
                if (Convert.ToInt16(cmd.ExecuteScalar().ToString()) > 0)
                {
                    this.Connection.Close();
                    return true;
                }
                else
                {
                    this.Connection.Close();
                    return false;
                }
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetProductsWithoutPrice()
        {
            try{
            string sql = "SELECT 产品编号,产品名称,规格,单位,单价 FROM qiaotai.产品信息 WHERE 单价=0;";
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

        public DataTable GetAllProductFlowByName(string col, string value)
        {
            try{
            string sql = "SELECT * FROM qiaotai.产品进出库 WHERE " + col + " LIKE '%" + value + "%';";
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


        public DataTable GetMaterialProductRelationByProduct(String ID)
        {
            try{
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool HasProductMaterialRelation(string pId)
        {
            try{
            string sql = "select count(1) from qiaotai.产品原料关系 where 产品编号=" + pId + ";";
            MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
            this.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            int count = 0;
            while (dr.Read())
            {
                count = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            this.Connection.Close();

            return count > 0;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public DataTable GetMaterialProductRelationByProductEx(String ID, int 数量)
        {
            try
            {
                string sql = "SELECT 产品原料关系.原料编号,原材料.原料名称,原材料.单位,产品原料关系.原料数量*" + 数量 + " AS 需要原料数量,原材料.库存数量,'' AS 供应商,'0' AS 单价  FROM 产品原料关系 LEFT JOIN 原材料 ON 产品原料关系.原料编号=原材料.原料编号 WHERE 产品编号='" + ID + "';";
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }


        //产品信息增删改
        public int AddNewProduct(Product pdt)
        {
            try
            {
                string sql = "INSERT INTO qiaotai.产品信息(产品名称,规格,材质,变位,实测变位,颜色,单位,单价,库存数量," +
                    "布料编号,开料要求,开料尺寸,胶水型号,溶剂,脱模剂,硬化剂,含浸比重,搅拌时间,比重计,胶滚压力,含浸转速HZ,烤箱温度C," +
                    "成型模号,成型机台,手动自动,单个整条,成型上下模温度,成型时间,成型压力,自动切,是否拉布成型,是否中孔加补强布,补强布大小,是否压纸板,剪边喷水,压定位板,定型时间,压纸板时间," +
                    "刀模,中孔模,刀模中心定位,切刀模个数,切断模,切断模架,切断机台,单个整条切断,通用气冲模,气冲压力,多个多条切断,导线方式,导线规格,内留mm,外留mm,点锡长mm,导线长度,方向数量,线距mm,单面双面点胶," +
                    "胶水,边胶,胶水重量,摆放要求,工艺要求,打胶方式,贴合方式,贴合压力,贴合模具,贴合机台,成型首检变位,生产单重,样品变位,样品单重,测试夹具外内,是否留样,是否备品,是否产品全检,是否数量超交,是否标签盖环保章,备注,外贴标签要求,批准,审核,制作" +
                    ") VALUES ('" +
                    pdt.Name + "','" + pdt.Standard + "','" + pdt.Texture + "','" + pdt.Shift + "','" + pdt.RealShift + "','" + pdt.Color + "','" + pdt.Unit + "'," + pdt.Price + ",'" + pdt.StockCount + "','" +
                    pdt.布料编号 + "','" + pdt.开料要求 + "','" + pdt.开料尺寸 + "','" + pdt.胶水型号 + "','" + pdt.溶剂 + "','" + pdt.脱模剂 + "','" + pdt.硬化剂 + "','" + pdt.含浸比重 + "','" + pdt.搅拌时间 + "','" + pdt.比重计 + "','" + pdt.胶滚压力 + "','" + pdt.含浸转速HZ + "','" + pdt.烤箱温度C + "','" +
                    pdt.成型模号 + "','" + pdt.成型机台 + "','" + pdt.手动自动 + "','" + pdt.单个整条 + "','" + pdt.成型上下模温度 + "','" + pdt.成型时间 + "','" + pdt.成型压力 + "','" + pdt.自动切 + "','" + pdt.是否拉布成型 + "','" + pdt.是否中孔加补强布 + "','" + pdt.补强布大小 + "','" + pdt.是否压纸板 + "','" + pdt.剪边喷水 + "','" + pdt.压定位板 + "','" + pdt.定型时间 + "','" + pdt.压纸板时间 + "','" +
                    pdt.刀模 + "','" + pdt.中孔模 + "','" + pdt.刀模中心定位 + "','" + pdt.切刀模个数 + "','" + pdt.切断模 + "','" + pdt.切断模架 + "','" + pdt.切断机台 + "','" + pdt.单个整条切断 + "','" + pdt.通用气冲模 + "','" + pdt.气冲压力 + "','" + pdt.多个多条切断 + "','" + pdt.导线方式 + "','" + pdt.导线规格 + "','" + pdt.内留mm + "','" + pdt.外留mm + "','" + pdt.点锡长mm + "','" + pdt.导线长度 + "','" + pdt.方向数量 + "','" + pdt.线距mm + "','" + pdt.单面双面点胶 + "','" +
                    pdt.胶水 + "','" + pdt.边胶 + "','" + pdt.胶水重量 + "','" + pdt.摆放要求 + "','" + pdt.工艺要求 + "','" + pdt.打胶方式 + "','" + pdt.贴合方式 + "','" + pdt.贴合压力 + "','" + pdt.贴合模具 + "','" + pdt.贴合机台 + "','" + pdt.成型首检变位 + "','" + pdt.生产单重 + "','" + pdt.样品变位 + "','" + pdt.样品单重 + "','" + pdt.测试夹具外内 + "','" + pdt.是否留样 + "','" + pdt.是否备品 + "','" + pdt.是否产品全检 + "','" + pdt.是否数量超交 + "','" + pdt.是否标签盖环保章 + "','" +
                    pdt.备注 + "','" + pdt.外贴标签要求 + "','" + pdt.批准 + "','" + pdt.审核 + "','" +pdt.制作+
                    "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                var id = cmd.LastInsertedId;
                this.Connection.Close();
                return (int)id;
            }
            catch (Exception ex)
            {
                this.Connection.Close();
                throw ex;
            }
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
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }
        public bool AltProduct(Product pdt)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品信息 SET 产品名称='" + pdt.Name + "',规格='" + pdt.Standard + "',材质='" + pdt.Texture + "',变位='" + pdt.Shift + "',实测变位='" + pdt.RealShift + "',颜色='" + pdt.Color + "',单位='" + pdt.Unit + "',单价=" + pdt.Price + ",库存数量='" + pdt.StockCount +
                    "',布料编号='" + pdt.布料编号 + "',开料要求='" + pdt.开料要求 + "',开料尺寸='" + pdt.开料尺寸 + "',胶水型号='" + pdt.胶水型号 + "',溶剂='" + pdt.溶剂 + "',脱模剂='" + pdt.脱模剂 + "',硬化剂='" + pdt.硬化剂 + "',含浸比重='" + pdt.含浸比重 + "',搅拌时间='" + pdt.搅拌时间 + "',比重计='" + pdt.比重计 + "',胶滚压力='" + pdt.胶滚压力 + "',含浸转速HZ='" + pdt.含浸转速HZ + "',烤箱温度C='" + pdt.烤箱温度C +
                    "',成型模号='" + pdt.成型模号 + "',成型机台='" + pdt.成型机台 + "',手动自动='" + pdt.手动自动 + "',单个整条='" + pdt.单个整条 + "',成型上下模温度='" + pdt.成型上下模温度 + "',成型时间='" + pdt.成型时间 + "',成型压力='" + pdt.成型压力 + "',自动切='" + pdt.自动切 + "',是否拉布成型='" + pdt.是否拉布成型 + "',是否中孔加补强布='" + pdt.是否中孔加补强布 + "',补强布大小='" + pdt.补强布大小 + "',是否压纸板='" + pdt.是否压纸板 + "',剪边喷水='" + pdt.剪边喷水 + "',压定位板='" + pdt.压定位板 + "',定型时间='" + pdt.定型时间 + "',压纸板时间='" + pdt.压纸板时间 +
                    "',刀模='" + pdt.刀模 + "',中孔模='" + pdt.中孔模 + "',刀模中心定位='" + pdt.刀模中心定位 + "',切刀模个数='" + pdt.切刀模个数 + "',切断模='" + pdt.切断模 + "',切断模架='" + pdt.切断模架 + "',切断机台='" + pdt.切断机台 + "',单个整条切断='" + pdt.单个整条切断 + "',通用气冲模='" + pdt.通用气冲模 + "',气冲压力='" + pdt.气冲压力 + "',多个多条切断='" + pdt.多个多条切断 + "',导线方式='" + pdt.导线方式 + "',导线规格='" + pdt.导线规格 + "',内留mm='" + pdt.内留mm + "',外留mm='" + pdt.外留mm + "',点锡长mm='" + pdt.点锡长mm + "',导线长度='" + pdt.导线长度 + "',方向数量='" + pdt.方向数量 + "',线距mm='" + pdt.线距mm + "',单面双面点胶='" + pdt.单面双面点胶 +
                    "',胶水='" + pdt.胶水 + "',边胶='" + pdt.边胶 + "',胶水重量='" + pdt.胶水重量 + "',摆放要求='" + pdt.摆放要求 + "',工艺要求='" + pdt.工艺要求 + "',打胶方式='" + pdt.打胶方式 + "',贴合方式='" + pdt.贴合方式 + "',贴合压力='" + pdt.贴合压力 + "',贴合模具='" + pdt.贴合模具 + "',贴合机台='" + pdt.贴合机台 + "',成型首检变位='" + pdt.成型首检变位 + "',生产单重='" + pdt.生产单重 + "',样品变位='" + pdt.样品变位 + "',样品单重='" + pdt.样品单重 + "',测试夹具外内='" + pdt.测试夹具外内 + "',是否留样='" + pdt.是否留样 + "',是否产品全检='" + pdt.是否产品全检 + "',是否数量超交='" + pdt.是否数量超交 + "',是否标签盖环保章='" + pdt.是否标签盖环保章 +
                    "',备注='" + pdt.备注 + "',外贴标签要求='" + pdt.外贴标签要求 + "',批准='" + pdt.批准 + "',审核='" + pdt.审核 + "',制作='" + pdt.制作 +
                    "' WHERE 产品编号='" + pdt.Id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
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
                string sql = "INSERT INTO qiaotai.产品进出库(产品编号,发生时间,类型,相关订单编号,相关计划编号,不合格产品数,当前状态) VALUES ('" + pdt.ProductId + "','" + pdt.OccurredTime.ToString("yyyy/MM/dd HH:mm:ss") + "','" + pdt.Type + "','" + pdt.RelatedOrderId + "','" + pdt.RelatedPlanId + "','" + pdt.UnqualifiedCount + "','" + pdt.Status + "');";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool AddProductCount(string 产品编号,int 产品数量)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品信息 SET 库存数量= 库存数量 +" + 产品数量 + " WHERE 产品编号='" + 产品编号 + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        public bool ReduceProductCount(string pId, int 产品数量)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品信息 SET 库存数量= 库存数量-" + 产品数量 + " WHERE 产品编号=" + pId + ";";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }


        public bool UpdataProductByStatus(string 状态, string 编号)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品进出库 SET 当前状态= " + 状态 + " WHERE 相关订单编号='" + 编号 + "';";
                     MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

    
        public bool SetProductPrice(double price, string pId)
        {
            try
            {
                string sql = "UPDATE qiaotai.产品信息 SET 单价=" + price + " WHERE 产品编号='" + pId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                this.Connection.Open();
                cmd.ExecuteNonQuery();
                this.Connection.Close();
                return true;
            }
            catch (Exception ex) { this.Connection.Close(); throw ex; }
        }

        
    }
}
