using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class CustomNotificationServiceManager
    {
        public static List<CustomNotification> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CustomNotification/GetAll");
            return serializer.Deserialize<List<CustomNotification>>(str);
        }
        public static List<CustomNotification> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CustomNotification/GetActiveList");
            return serializer.Deserialize<List<CustomNotification>>(str);
        }
        public static CustomNotification GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            CustomNotification Obj = serializer.Deserialize<CustomNotification>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CustomNotification/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(CustomNotification Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CustomNotification/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(CustomNotification Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CustomNotification/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CustomNotification/Delete", PostData);
        }
    }
}
