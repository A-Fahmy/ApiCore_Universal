using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTS.Business;
using BTS.Entities;
using System.Web.Http;
using BTS.Entities.flutter;
using BTS.Business.flutter;

namespace BTS.WebAPIService.Controllers.flutter
{
    public class posts_flutterExtensionController: ApiController
    {
        [Route("api/flutter_posts/GetAll_WhatsNews/{id}")]
        public IEnumerable<post> GetAll_WhatsNews(int id)
        {
            return posts_flutterBusiness.GetAll_WhatsNews(id);
        }
    }
}