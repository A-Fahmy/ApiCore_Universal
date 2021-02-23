using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class NotificationDescriptionServiceManager
    {
        public static List<NotificationDescription> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "NotificationDescription/GetAll");
            return serializer.Deserialize<List<NotificationDescription>>(str);
        }
        public static List<NotificationDescription> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "NotificationDescription/GetActiveList");
            return serializer.Deserialize<List<NotificationDescription>>(str);
        }
        public static NotificationDescription GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            NotificationDescription Obj = serializer.Deserialize<NotificationDescription>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "NotificationDescription/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(NotificationDescription Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "NotificationDescription/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(NotificationDescription Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "NotificationDescription/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "NotificationDescription/Delete", PostData);
        }
    }
}
