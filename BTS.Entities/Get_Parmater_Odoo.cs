using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BTS.Entities
{
    public class Get_Parmater_Odoo
    {
       

        public List<_Partners> partners { get; set; }
        public List<_Route> route { get; set; }
        public List<_State_collect> state_collect { get; set; }
        public List<_Currency> currency { get; set; }
        public List<_Banks> banks { get; set; }
        public List<_Journals> journals { get; set; }

    }

    public class _obj_partners
    {
        public string partner_id_name { get; set; }
        public int partner_id { get; set; }

    }

}
