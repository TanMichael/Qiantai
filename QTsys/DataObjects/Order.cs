using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class Order : QiaotaiObject
    {
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string ExpressNO { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime DeliverTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string DepositMode { get; set; }
        public string RecieverAddress { get; set; }
        public string RecieverPhone { get; set; }
        public string RecieverName { get; set; }
        public string Creator { get; set; }
    }
}
