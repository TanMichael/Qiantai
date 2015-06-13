using QTsys.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QTsys.DataObjects;

namespace QTsys.Manager
{
    class MaterialManager
    {
        private MaterialDAO dao;

        public MaterialManager()
        {
            this.dao = new MaterialDAO();
        }

        public static MaterialManager getMaterialManager()
        {
            return new MaterialManager();
        }

        public DataTable GetAllMaterials()
        {
            return this.dao.GetAllMaterials();
        }

        public List<Material> GetAllMaterials(bool b)
        {
            try
            {
                List<Material> results = new List<Material>();
                DataTable dt = this.dao.GetAllMaterials();

                var l = dt.Rows.Count;
                for (int i = 0; i < l; i++)
                {
                    var rs = dt.Rows[i];
                    Material mt = new Material();

                    mt.Id = (int)rs["原料编号"];
                    mt.Name = rs["原料名称"].ToString();
                    mt.Unit = rs["单位"].ToString();
                    mt.StockCount = (int)rs["库存数量"];
                    mt.Supplier = rs["供应商"].ToString();

                    results.Add(mt);
                }

                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable GetAllMaterialByName(string col, string value)
        {
            return this.dao.GetAllMaterialsByName(col, value);
        }

        public DataTable GetAllMaterialFlowByName(string col, string value)
        {
            return this.dao.GetAllMaterialFlowByName(col, value);
        }

        public DataTable GetSearchIncomeMaterialFlow(string column, string value, DateTime start, DateTime end)
        {
            return this.dao.GetSearchIncomeMaterialFlow(column, value, start, end);
        }

        public bool AltMaterials(Material m)
        {
            return this.dao.AltMaterial(m);
        }

        public bool MaterialDesTo(string ID, int desnum)
        { return this.dao.MaterialDesTo(ID, desnum); }

        public String GetMaterialNameBySerial(string value)
        {
            return this.dao.GetMaterialNameBySerial(value);
        }

        public DataTable GetAllMaterialFlow()
        {
            return this.dao.GetAllMaterialFlow();
        }

        public bool AddNewMaterialEx(MaterialFlow material, String mtName, String mtUnit)
        {
            try
            {
                Material mt = new Material();
                mt.Id = material.MaterialId;
                mt.Unit = mtUnit;
                mt.StockCount = material.FlowCount;

                if (mt.Id == -1)
                {
                    mt.Name = mtName;
                    material.MaterialId = mt.Id = this.dao.AddNewMaterial(mt);
                }
                else
                {
                    this.dao.UpdateMaterial(mt);
                }

                return this.dao.AddNewMaterialFlow(material, mtName, mtUnit);
            }
            catch (Exception ex) {   throw ex; }
        }

        public int AddNewMaterial(Material material)
        {
            return this.dao.AddNewMaterial(material);
        }

        public bool DelMaterial(String key) { return this.dao.DelMaterial(key); }

    }
}
