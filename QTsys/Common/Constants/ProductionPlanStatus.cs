using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.Common.Constants
{
    class ProductionPlanStatus
    {
        public const string PENDING = "待审核";
        public const string PREPARING = "备货中";
        public const string PROCESSING = "生产中";
        public const string STORED = "入库";
        public const string CANCEL = "取消";
    }
}
