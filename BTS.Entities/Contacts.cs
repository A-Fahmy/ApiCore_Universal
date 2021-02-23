using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities
{
    public class Contact
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MoblieNo { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public byte[] PhotoInBytes { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> State { get; set; }
        public string CurrentbranchLatitude { get; set; }
        public string CurrentbranchLongitude { get; set; }
    }
}
