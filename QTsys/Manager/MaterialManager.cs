using QTsys.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.Manager
{
    class MaterialManager
    {
        private MaterialDAO dao;
        public MaterialManager()
        {
            this.dao = new MaterialDAO();
        }
    }
}
