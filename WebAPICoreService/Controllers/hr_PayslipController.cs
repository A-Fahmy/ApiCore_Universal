using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTS.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICoreService.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class hr_PayslipController : ControllerBase
    {
        [HttpGet]
        //[Route("api/hr_Payslip/Print_Payslip/{employee_id}/{MonthId}")]
        [Route("api/hr_Payslip/Print_Payslip/{employee_id}")]
        //public string Print_Payslip(int employee_id, string MonthId)
        public string Print_Payslip(int employee_id)
        {
            //  return hr_PayslipBusiness.Print_Payslip(employee_id,"09");
            return "";
        }

      
    }
}
