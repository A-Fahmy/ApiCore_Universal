using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BTS.Entities
{
    public class Journals
    {
        public string key { get; set; }
        public List<_Journals> value { get; set; }

    }
    public class _Journals
    {
        public string journal_name { get; set; }
        public int journal_id { get; set; }
    }
}
