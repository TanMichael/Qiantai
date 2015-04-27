using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class OperationAudit : QiaotaiObject
    {
        public string Id { get; set; }
        public string Operator { get; set; }
        public DateTime OperateTime { get; set; }
        public string Action { get; set; }
        public string OperateObject { get; set; }
        public string Result { get; set; }
    }
}
