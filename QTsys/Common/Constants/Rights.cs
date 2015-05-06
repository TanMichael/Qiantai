using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.Common.Constants
{
    enum Rights
    {
        ADMIN = 1 << 0,   // 00000001
        SALES = 1 << 1,   // 00000010
        PRODUCTION = 1 << 2,   // 00000100
        STORAGE = 1 << 3   // 00001000
    }
}
