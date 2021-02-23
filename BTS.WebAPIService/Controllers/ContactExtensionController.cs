using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTS.Business;
using BTS.Entities;
using System.Web.Http;


namespace BTS.WebAPIService.Controllers
{
    public class ContactExtensionController : ApiController
    {
        [Route("api/Contact/GetByUserID_Password/{Username}/{PassWord}")]
        public IEnumerable<Contact> GetByUserID_Password(string Username, string PassWord)
        {
            return ContactBusiness.GetByUserID_Password(Username, PassWord);
        }

    }
}