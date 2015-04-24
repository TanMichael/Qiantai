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

        public bool AltMaterials(Material m)
        {
            return this.dao.AltMaterial(m);
        }
    }
}
