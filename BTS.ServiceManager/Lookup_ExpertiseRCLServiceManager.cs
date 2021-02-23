using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_ExpertiseRCLServiceManager
    {
        public static List<Lookup_ExpertiseRCL> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_ExpertiseRCL/GetAll");
            return serializer.Deserialize<List<Lookup_ExpertiseRCL>>(str);
        }
        public static List<Lookup_ExpertiseRCL> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_ExpertiseRCL/GetActiveList");
            return serializer.Deserialize<List<Lookup_ExpertiseRCL>>(str);
        }
        public static Lookup_ExpertiseRCL GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_ExpertiseRCL Obj = serializer.Deserialize<Lookup_ExpertiseRCL>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_ExpertiseRCL/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_ExpertiseRCL Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_ExpertiseRCL/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_ExpertiseRCL Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_ExpertiseRCL/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_ExpertiseRCL/Delete", PostData);
        }
    }
}
