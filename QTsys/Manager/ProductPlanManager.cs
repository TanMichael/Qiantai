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
    class ProductPlanManager
    {
        private ProductPlanDAO pdao;

        public ProductPlanManager()
        {
            this.pdao = new ProductPlanDAO();
        }

        public static ProductPlanManager getProductPlanManager()
        {
            return new ProductPlanManager();
        }

        public DataTable GetAllProductPlan(bool reallyAll = false)
        {
            return this.pdao.GetAllProductPlan(reallyAll);
        }

        public DataTable GetAllProductPlanByName(string col, string value)
        {
            return this.pdao.GetAllProductPlanByName(col, value);
        }

        public DataTable GetAllProductPlanByNameEX(string col, string value)
        {
            return this.pdao.GetAllProductPlanByNameEX(col, value);
        }

        public DataTable GetAllProductPlanByStates(string value)
        { return this.pdao.GetAllProductPlanByStates(value); }


        public DataTable GetAllProductPlanByTime(DateTime date1, DateTime date2)
        {
            return this.pdao.GetAllProductPlanByTime(date1, date2);
        }

        public bool AddNewPlan(ProductionPlan pp) { return this.pdao.AddNewPlan(pp); }
        public bool DelPlan(String key) { return this.pdao.DelPlan(key); }
        public bool AltPlan(ProductionPlan pp) { return this.pdao.AltPlan(pp); }


        public bool UpdatePlanStatus(string status, string pId)
        {
            return this.pdao.UpdatePlanStatus(status, pId);
        }


        public DataTable GetProductPlanByOrder(string orderId)
        {
            return this.pdao.GetProductPlanByOrder(orderId);
        }
    }
}
