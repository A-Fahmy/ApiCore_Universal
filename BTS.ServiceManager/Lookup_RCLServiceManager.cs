using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_RCLServiceManager
    {
        public static List<Lookup_RCL> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_RCL/GetAll");
            return serializer.Deserialize<List<Lookup_RCL>>(str);
        }
        public static List<Lookup_RCL> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_RCL/GetActiveList");
            return serializer.Deserialize<List<Lookup_RCL>>(str);
        }
        public static Lookup_RCL GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_RCL Obj = serializer.Deserialize<Lookup_RCL>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_RCL/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_RCL Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_RCL/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_RCL Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_RCL/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_RCL/Delete", PostData);
        }
    }
}
