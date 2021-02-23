using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTS.Business;
using BTS.Entities;
using System.Web.Http;



namespace BTS.WebAPIService.Controllers
{
    public class ParmaterController: ApiController
    {
        [HttpGet]
        [Route("api/Parmater/GetAll_Parmater")]
        public Get_Parmater_Odoo GetAll_Parmater()
        {
            return Get_ParmaterBusiness.GetAll_Parmater();
        }

        [HttpGet]
        [Route("api/Parmater/GetAll_Companies/{main_customer_id}")]
        public IEnumerable<Companies> GetAll_Companies(int main_customer_id)
        {
            return Get_ParmaterBusiness.GetAll_Companies(main_customer_id);
        }

        [HttpGet]
        [Route("api/Parmater/GetAll_Branches/{second_company_id}")]
        public IEnumerable<Companies> GetAll_Branches(int second_company_id)
        {
            return Get_ParmaterBusiness.GetAll_Branches(second_company_id);
        }

        [HttpGet]
        [Route("api/Parmater/Read_Payment/{UserID}")]
        public IEnumerable<ReadPayment> Read_Payment(int UserID)
        {
            return Get_ParmaterBusiness.Read_Payment(UserID);
        }



        [HttpGet]
        [Route("api/Parmater/Create_payment_api/{UserName}/{PassWord}/{partner_id}/{second_company_id}" +
            "/{parent_id}/{journal_id}/{state_collect}/{currency}/{reference}" +
            "/{amount}/{is_check}/{route_id}/{two_hundred}/{one_hundred}" +
            "/{fifty}/{twenty}/{ten}/{five}/{one}/{half_one}" +
            "/{quarter_one}/{num_of_envelope}/{check_id}/{check_num}/{check_date}/{notes}")]
        public string Create_payment_api(string UserName, string PassWord,
            int partner_id, int second_company_id, int parent_id, int journal_id,
            string state_collect, string currency, string reference,
          double amount, int is_check, int route_id, int two_hundred, int one_hundred, int fifty
            , int twenty, int ten, int five, int one, int half_one, int quarter_one, int num_of_envelope
            , int check_id, int check_num, string check_date)
        {
            return Get_ParmaterBusiness.Create_payment_api(UserName, PassWord, partner_id, second_company_id
                , parent_id, journal_id, state_collect, currency, reference, amount, is_check, route_id, two_hundred,
                 one_hundred, fifty, twenty, ten, five, one, half_one, quarter_one, num_of_envelope, check_id, check_num, check_date);
        }
    }
}