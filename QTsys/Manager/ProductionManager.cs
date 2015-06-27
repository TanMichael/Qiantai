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
        public DataTable GetAllProductsByNameEX(string col, string value)
        {
            return this.pdao.GetAllProductsByNameEX(col, value);
        }

        public DataTable GetProductsByOrder(string oId)
        {
            return this.pdao.GetProductsByOrder(oId);
        }

        public DataTable GetProductsWithoutPrice()
        {
            return this.pdao.GetProductsWithoutPrice();
        }

        public bool TestPMreltionExist(string Id)
        {
            return this.pdao.TestPMreltionExist(Id);
        }
        public DataTable GetMaterialProductRelationByProduct(String ID)
        {
            return this.pdao.GetMaterialProductRelationByProduct(ID);
        }

        public DataTable GetMaterialProductRelationByProductEx(String ID,int num)
        {
            return this.pdao.GetMaterialProductRelationByProductEx(ID,num);
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

        public bool HasProductMaterialRelation(string pId)
        {
            return this.pdao.HasProductMaterialRelation(pId);
        }

        public DataTable GetProductsWithCustomer(string customerId)
        {
            return this.pdao.GetProductsWithCustomer(customerId);
        }

      

         public DataTable GetAllProductFlow()
         { return this.pdao.GetAllProductFlow(); }
        
        public DataTable GetAllProductFlowByName(string col, string value)
         {
             return this.pdao.GetAllProductFlowByName(col, value);
         }

        public int AddNewProduct(Product pdt) { return pdao.AddNewProduct(pdt); }
        public bool DelProduct(String key) { return pdao.DelProduct(key); }
        public bool AltProduct(Product pdt) { return pdao.AltProduct(pdt); }

        public bool AddProduct(ProductFlow pdt,int num) 
        {
            if (pdao.AddNewProductFlow(pdt))
            {
                if (pdao.AddProductCount(pdt.ProductId,num))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool UpdataProductByStatus(string 状态, string 编号){ return pdao.UpdataProductByStatus(状态, 编号); }



        public bool SetProductPrice(double price, string pId)
        {
            return this.pdao.SetProductPrice(price, pId);
        }


        public bool DeliverProduct(ProductFlow proflow, int 产品数量)
        {
            if (pdao.AddNewProductFlow(proflow))
            {
                if (pdao.ReduceProductCount(proflow.ProductId, 产品数量))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool UpdateProductStoreCount(int changeCount, string pId)
        {
            return pdao.UpdateProductStoreCount(changeCount, pId);
        }
    }
}
