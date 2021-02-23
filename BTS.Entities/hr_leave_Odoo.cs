using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities
{
    public class hr_leave_Odoo
    {
        public object holiday_status_id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public object employee_id { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }
}
