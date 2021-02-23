using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BTS.Entities
{
    public class hr_leave
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int TypeVactionID { get; set; }
        public string TypeVactionName { get; set; }
        public string state { get; set; }
        public string name { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public string Description { get; set; }
    }
}
