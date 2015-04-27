using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class QiaotaiObject
    {
        public string ToString()
        {
            string result = "";
            var t = this.GetType();
            var props = t.GetProperties();
            foreach (var prop in props)
            {
                result += prop.Name + "：" + prop.GetValue(this) + "; ";
            }
            return result;
        }
    }
}
