using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class ProductionPlan : QiaotaiObject
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderTime { get; set; }
        public int Count { get; set; }
        public DateTime PlanningTime { get; set; }
        public DateTime FinishTime { get; set; }
        public string PlanType { get; set; }
        public string PlanState { get; set; }
        public string RelatedOrderId { get; set; }
        public string InChargePerson { get; set; }
        public int AlreadyProduce { get; set; }
        public DateTime LastTime { get; set; }

        public int finishedCount { get; set; }
        public int deliveredCount { get; set; }
        public string hasFromStore { get; set; }
    }
}
