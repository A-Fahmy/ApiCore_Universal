using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.Entities;
using System.Web.Script.Serialization;
using BTS.Entities.Views;

namespace BTS.ServiceManager
{
   public partial class UserServiceManagerExtension
    {
        public static List<User> GetByUserName(string username)
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "User/GetByUserName/" + username);
            return serializer.Deserialize<List<User>>(str);
        }
        public static List<User> GetByEmail(string Email)
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "User/GetByEmail/" + Email);
            return serializer.Deserialize<List<User>>(str);
        }
    }
}
