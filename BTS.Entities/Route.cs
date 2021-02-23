using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities
{
    public class Route
    {
        public string key { get; set; }
        public List<_Route> value { get; set; }
    }
    public class _Route
    {
        public string route_name { get; set; }
        public int route_id { get; set; }
    }
}
