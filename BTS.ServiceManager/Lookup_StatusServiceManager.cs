using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_StatusServiceManager
    {
        public static List<Lookup_Status> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Status/GetAll");
            return serializer.Deserialize<List<Lookup_Status>>(str);
        }
        public static List<Lookup_Status> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Status/GetActiveList");
            return serializer.Deserialize<List<Lookup_Status>>(str);
        }
        public static Lookup_Status GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Status Obj = serializer.Deserialize<Lookup_Status>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Status/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Status Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Status/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Status Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Status/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Status/Delete", PostData);
        }
    }
}
