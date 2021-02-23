using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_LanguageServiceManager
    {
        public static List<Lookup_Language> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Language/GetAll");
            return serializer.Deserialize<List<Lookup_Language>>(str);
        }
        public static List<Lookup_Language> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Language/GetActiveList");
            return serializer.Deserialize<List<Lookup_Language>>(str);
        }
        public static Lookup_Language GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Language Obj = serializer.Deserialize<Lookup_Language>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Language/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Language Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Language/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Language Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Language/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Language/Delete", PostData);
        }
    }
}
