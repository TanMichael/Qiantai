using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class ProductFlow : QiaotaiObject
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public DateTime OccurredTime { get; set; }
        public string Type { get; set; }
        public string RelatedOrderId { get; set; }
        public string RelatedPlanId { get; set; }
        public int UnqualifiedCount { get; set; }
    }
}
