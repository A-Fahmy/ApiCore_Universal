using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTS.Business;
using BTS.Entities;
using Microsoft.AspNetCore.Mvc;
namespace WebAPICoreService.Controllers
{
    [ApiController]
    public class ContactExtensionController : ControllerBase
    {
        [Route("api/Contact/GetByUserID_Password/{Username}/{PassWord}")]
        public IEnumerable<Contact> GetByUserID_Password(string Username,string PassWord)
         {
            return ContactBusiness.GetByUserID_Password(Username, PassWord);
        }
    }
}