using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_CitiesServiceManager
    {
        public static List<Lookup_Cities> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Cities/GetAll");
            return serializer.Deserialize<List<Lookup_Cities>>(str);
        }
        public static List<Lookup_Cities> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Cities/GetActiveList");
            return serializer.Deserialize<List<Lookup_Cities>>(str);
        }
        public static Lookup_Cities GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Cities Obj = serializer.Deserialize<Lookup_Cities>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Cities/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Cities Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Cities/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Cities Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Cities/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Cities/Delete", PostData);
        }
    }
}
