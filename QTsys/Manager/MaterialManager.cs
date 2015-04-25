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
        public DataTable GetAllMaterialByName(string col, string value)
        {
            return this.dao.GetAllMaterialsByName(col, value);
        }
        public DataTable GetAllMaterialFlowByName(string col, string value)
        {
            return this.dao.GetAllMaterialFlowByName(col, value);
        }
        public bool AltMaterials(Material m)
        {
            return this.dao.AltMaterial(m);
        }

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
            if (this.dao.AddNewMaterialFlow(material, mtName, mtUnit))
            {
                Material mt = new Material();
                mt.Id = material.MaterialId;
                mt.Name = mtName;
                mt.Unit = mtUnit;
                mt.StockCount = material.StockCount;
                if (this.dao.AddNewMaterialEx(mt))
                {
                    return true;
                }
                else
                {
                    //对this.dao.AddNewMaterialFlow(material, mtName, mtUnit)进行逆操作,删除刚才加入的。
                    this.dao.DelMaterialFlow(material);
                    return false;
                }
            }
            else
                return false;
        }

        public bool AddNewMaterial(Material material)
        {
            return this.dao.AddNewMaterial(material);
        }

        public bool DelMaterial(String key) { return this.dao.DelMaterial(key); }
    }
}
