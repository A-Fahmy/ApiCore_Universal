using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities
{
    public class ReadPayment_Odoo
    {
        public string state { get; set; }
        public string date { get; set; }
        public object partner_id { get; set; }
        public int id { get; set; }
        public object second_company_id { get; set; }
        public object parent_id { get; set; }
        public object journal_id { get; set; }
        public string state_collect { get; set; }
        public string currency { get; set; }
        public string reference { get; set; }
        public double amount { get; set; }
        public bool is_check { get; set; }
        public object route_id { get; set; }
        public int check_num { get; set; }
        public string check_date { get; set; }
        public int num_of_envelope { get; set; }
        public object check_id { get; set; }
        public string notes { get; set; }

    }
}
