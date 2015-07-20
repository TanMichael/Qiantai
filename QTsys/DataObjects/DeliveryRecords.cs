using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class DeliveryRecords : QiaotaiObject
    {
        public string DeliveryRecordId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        //public string CustomerId { get; set; }
        //public string CustomerName { get; set; }
        //public string OrderId { get; set; }
        public string IsSample { get; set; }
        public int Count { get; set; }
        public string Standard { get; set; }
        public string Texture { get; set; }
        public double Price { get; set; }
        public double Sum { get; set; }
    }
}
