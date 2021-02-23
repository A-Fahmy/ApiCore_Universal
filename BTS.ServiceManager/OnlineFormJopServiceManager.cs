using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class OnlineFormJopServiceManager
    {
        public static List<OnlineFormJop> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "OnlineFormJop/GetAll");
            return serializer.Deserialize<List<OnlineFormJop>>(str);
        }
        public static List<OnlineFormJop> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "OnlineFormJop/GetActiveList");
            return serializer.Deserialize<List<OnlineFormJop>>(str);
        }
        public static OnlineFormJop GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            OnlineFormJop Obj = serializer.Deserialize<OnlineFormJop>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "OnlineFormJop/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(OnlineFormJop Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "OnlineFormJop/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(OnlineFormJop Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "OnlineFormJop/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "OnlineFormJop/Delete", PostData);
        }
    }
}
