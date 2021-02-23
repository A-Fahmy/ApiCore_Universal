using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class RVServiceManager
    {
        public static List<RV> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RV/GetAll");
            return serializer.Deserialize<List<RV>>(str);
        }
        public static List<RV> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RV/GetActiveList");
            return serializer.Deserialize<List<RV>>(str);
        }
        public static RV GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            RV Obj = serializer.Deserialize<RV>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RV/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(RV Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RV/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(RV Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RV/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RV/Delete", PostData);
        }
    }
}
