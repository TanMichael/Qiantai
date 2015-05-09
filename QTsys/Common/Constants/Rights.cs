using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.Common.Constants
{
    enum Rights
    {
        EMPLOYEE = 1 << 0,      // 00000001     员工管理, 预警统计
        CUSTOMER = 1 << 1,      // 00000010     客户管理
        SALES = 1 << 2,         // 00000100     订单管理，新增订单, 销售管理
        PRODUCT = 1 << 3,       // 00001000     产品，产品管理
        STORAGE = 1 << 4,       // 00010000     原材料管理， TODO: 产品进出库(仓库)
        MANUFACTURE = 1 << 5,   // 00100000     生产计划
        REVIEWER = 1 << 6       // 01000000     审核
    }
}
