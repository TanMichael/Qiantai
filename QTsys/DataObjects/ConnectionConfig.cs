using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class ConnectionConfig
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string DataSource { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string Pooling { get; set; }
        public string CharSet { get; set; }
        public string Port { get; set; }
    }
}
