using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class alternativeContactServiceManager
    {
        public static List<alternativeContact> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "alternativeContact/GetAll");
            return serializer.Deserialize<List<alternativeContact>>(str);
        }
        public static List<alternativeContact> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "alternativeContact/GetActiveList");
            return serializer.Deserialize<List<alternativeContact>>(str);
        }
        public static alternativeContact GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            alternativeContact Obj = serializer.Deserialize<alternativeContact>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "alternativeContact/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(alternativeContact Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "alternativeContact/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(alternativeContact Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "alternativeContact/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "alternativeContact/Delete", PostData);
        }
    }
}
