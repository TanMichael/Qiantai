using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class OperationRecord
    {
        public string Id { get; set; }
        public string OperatorId { get; set; }
        public DateTime OperateTime { get; set; }
        public string Action { get; set; }
    }
}
