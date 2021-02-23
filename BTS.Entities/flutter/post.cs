using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities.flutter
{
    public class post
    {
        public string id { get; set; }
        public string title { get; set; }
        public string featuredImage { get; set; }
        public string content { get; set; }
        public string dateWritten { get; set; }
        public string userName { get; set; }
        public int categoryId { get; set; }
        public int votesUp { get; set; }
        public int votesDown { get; set; }

    }
}
