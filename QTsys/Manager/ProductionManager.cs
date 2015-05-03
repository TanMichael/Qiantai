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

        public DataTable GetAllProductsByName(string col, string value)
        {
            return this.pdao.GetAllProductsByName(col, value);
        }


        public DataTable GetMaterialProductRelationByProduct(String ID)
        {
            return this.pdao.GetMaterialProductRelationByProduct(ID);
        }

        public bool AltMaterialProductRelation(ProductMaterial pmr)
        {
            return this.pdao.AltMaterialProductRelation(pmr);
        }

        public bool DelMaterialProductRelation(ProductMaterial pmr)
        {
            return this.pdao.DelMaterialProductRelation(pmr);
        }

        public bool AddMaterialProductRelation(ProductMaterial pmr)
        {
            return this.pdao.AddMaterialProductRelation(pmr);
        }

        public DataTable GetProductsWithCustomer(string customerId)
        {
            return this.pdao.GetProductsWithCustomer(customerId);
        }

    }
}
