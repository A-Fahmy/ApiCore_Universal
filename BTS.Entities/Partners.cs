using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities
{
    public class Partners
    {
        public string key { get; set; }
        public List<_Partners> value { get; set; }
    }
    public class _Partners
    {
        public object parent_id { get; set; }
        public string partner_id_name { get; set; }
        public int partner_id { get; set; }
        public bool is_company { get; set; }
        public bool is_second_level { get; set; }




    }
}
