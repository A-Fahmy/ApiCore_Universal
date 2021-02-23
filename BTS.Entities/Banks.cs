using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities
{
    public class Banks
    {
        public string key { get; set; }
        public List<_Banks> value { get; set; }
    }
    public class _Banks
    {
        public string check_name { get; set; }
        public int check_id { get; set; }
    }
}
