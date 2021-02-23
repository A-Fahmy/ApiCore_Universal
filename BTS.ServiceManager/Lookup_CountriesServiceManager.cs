using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_CountriesServiceManager
    {
        public static List<Lookup_Countries> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Countries/GetAll");
            return serializer.Deserialize<List<Lookup_Countries>>(str);
        }
        public static List<Lookup_Countries> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Countries/GetActiveList");
            return serializer.Deserialize<List<Lookup_Countries>>(str);
        }
        public static Lookup_Countries GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Countries Obj = serializer.Deserialize<Lookup_Countries>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Countries/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Countries Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Countries/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Countries Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Countries/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Countries/Delete", PostData);
        }
    }
}
