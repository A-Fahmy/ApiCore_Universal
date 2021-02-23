using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_BanksServiceManager
    {
        public static List<Lookup_Banks> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Banks/GetAll");
            return serializer.Deserialize<List<Lookup_Banks>>(str);
        }
        public static List<Lookup_Banks> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Banks/GetActiveList");
            return serializer.Deserialize<List<Lookup_Banks>>(str);
        }
        public static Lookup_Banks GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Banks Obj = serializer.Deserialize<Lookup_Banks>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Banks/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Banks Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Banks/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Banks Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Banks/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Banks/Delete", PostData);
        }
    }
}
