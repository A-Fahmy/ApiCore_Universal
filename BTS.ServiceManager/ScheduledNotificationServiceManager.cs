using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class ScheduledNotificationServiceManager
    {
        public static List<ScheduledNotification> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ScheduledNotification/GetAll");
            return serializer.Deserialize<List<ScheduledNotification>>(str);
        }
        public static List<ScheduledNotification> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ScheduledNotification/GetActiveList");
            return serializer.Deserialize<List<ScheduledNotification>>(str);
        }
        public static ScheduledNotification GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            ScheduledNotification Obj = serializer.Deserialize<ScheduledNotification>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ScheduledNotification/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(ScheduledNotification Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ScheduledNotification/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(ScheduledNotification Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ScheduledNotification/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ScheduledNotification/Delete", PostData);
        }
    }
}
