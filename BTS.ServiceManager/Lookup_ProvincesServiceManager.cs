using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_ProvincesServiceManager
    {
        public static List<Lookup_Provinces> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Provinces/GetAll");
            return serializer.Deserialize<List<Lookup_Provinces>>(str);
        }
        public static List<Lookup_Provinces> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Provinces/GetActiveList");
            return serializer.Deserialize<List<Lookup_Provinces>>(str);
        }
        public static Lookup_Provinces GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Provinces Obj = serializer.Deserialize<Lookup_Provinces>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Provinces/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Provinces Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Provinces/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Provinces Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Provinces/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Provinces/Delete", PostData);
        }
    }
}
