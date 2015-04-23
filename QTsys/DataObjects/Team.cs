using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTsys.DataObjects
{
    class Team : JsonObjectBase<Team>
    {
        public string TeamName { get; set; }
        public List<User> Members { get; set; }
    }
}
