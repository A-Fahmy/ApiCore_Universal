using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.Entities
{
    public class ReadPayment
    {
        public string state { get; set; }
        public string date { get; set; }
        public int id { get; set; }
        public int partner_id { get; set; }
        public string partner_Name { get; set; }
        
        public int second_company_id { get; set; }
        public string second_company_Name { get; set; }
        public int parent_id { get; set; }
        public string parent_Name { get; set; }
        public int journal_id { get; set; }
        public string journal_Name { get; set; }
        public string state_collect { get; set; }
        public string currency { get; set; }
        public string reference { get; set; }
        public double amount { get; set; }
        public bool is_check { get; set; }
        public int route_id { get; set; }
        public string route_Name { get; set; }
        public int check_num { get; set; }
        public string check_date { get; set; }
        public int num_of_envelope { get; set; }
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string notes { get; set; }

    }
}
