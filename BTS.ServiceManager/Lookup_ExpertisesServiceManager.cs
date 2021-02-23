using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_ExpertisesServiceManager
    {
        public static List<Lookup_Expertises> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Expertises/GetAll");
            return serializer.Deserialize<List<Lookup_Expertises>>(str);
        }
        public static List<Lookup_Expertises> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Expertises/GetActiveList");
            return serializer.Deserialize<List<Lookup_Expertises>>(str);
        }
        public static Lookup_Expertises GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Expertises Obj = serializer.Deserialize<Lookup_Expertises>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Expertises/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Expertises Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Expertises/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Expertises Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Expertises/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Expertises/Delete", PostData);
        }
    }
}
