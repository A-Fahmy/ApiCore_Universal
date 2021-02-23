using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class UserServiceManager
    {
        public static List<User> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "User/GetAll");
            return serializer.Deserialize<List<User>>(str);
        }
        public static List<User> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "User/GetActiveList");
            return serializer.Deserialize<List<User>>(str);
        }
        public static User GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            User Obj = serializer.Deserialize<User>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "User/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(User Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "User/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(User Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "User/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "User/Delete", PostData);
        }
    }
}
