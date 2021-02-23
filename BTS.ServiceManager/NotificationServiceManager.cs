using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class NotificationServiceManager
    {
        public static List<Notification> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Notification/GetAll");
            return serializer.Deserialize<List<Notification>>(str);
        }
        public static List<Notification> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Notification/GetActiveList");
            return serializer.Deserialize<List<Notification>>(str);
        }
        public static Notification GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Notification Obj = serializer.Deserialize<Notification>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Notification/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Notification Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Notification/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Notification Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Notification/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Notification/Delete", PostData);
        }
    }
}
