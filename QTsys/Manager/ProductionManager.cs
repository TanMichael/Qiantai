using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTsys.DataObjects;
using QTsys.DAO;
using System.Data;

namespace QTsys.Manager
{
    class ProductionManager
    {
        private ProductDAO pdao;
        public ProductionManager()
        {
            this.pdao = new ProductDAO();
        }

        public static ProductionManager getProductionManager()
        {
            return new ProductionManager();
        }

         public DataTable GetAllProducts()
        {
            return this.pdao.GetAllProducts();
        }
    }
}
