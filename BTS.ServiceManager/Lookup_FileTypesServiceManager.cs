using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_FileTypesServiceManager
    {
        public static List<Lookup_FileTypes> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_FileTypes/GetAll");
            return serializer.Deserialize<List<Lookup_FileTypes>>(str);
        }
        public static List<Lookup_FileTypes> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_FileTypes/GetActiveList");
            return serializer.Deserialize<List<Lookup_FileTypes>>(str);
        }
        public static Lookup_FileTypes GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_FileTypes Obj = serializer.Deserialize<Lookup_FileTypes>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_FileTypes/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_FileTypes Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_FileTypes/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_FileTypes Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_FileTypes/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_FileTypes/Delete", PostData);
        }
    }
}
