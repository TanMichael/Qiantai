using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.Common.Constants
{
    static class OrderStatus
    {
        public const string PENDING = "待审核";
        public const string PASS = "通过审核";
        public const string PROCESSING = "处理中";
        public const string PACKING = "打包中";
        public const string SHIPPED = "已发货";
        public const string SUCCEED = "交易成功";
        public const string CANCEL = "取消";
    }
}
