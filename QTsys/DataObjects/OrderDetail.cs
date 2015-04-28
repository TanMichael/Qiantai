using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class OrderDetail : QiaotaiObject
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double RealPrice { get; set; }
        public string IsStorage { get; set; }
    }
}
