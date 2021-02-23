using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Sync_FlagServiceManager
    {
        public static List<Sync_Flag> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Sync_Flag/GetAll");
            return serializer.Deserialize<List<Sync_Flag>>(str);
        }
        public static List<Sync_Flag> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Sync_Flag/GetActiveList");
            return serializer.Deserialize<List<Sync_Flag>>(str);
        }
        public static Sync_Flag GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Sync_Flag Obj = serializer.Deserialize<Sync_Flag>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Sync_Flag/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Sync_Flag Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Sync_Flag/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Sync_Flag Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Sync_Flag/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Sync_Flag/Delete", PostData);
        }
    }
}
