using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class RCC_STSServiceManager
    {
        public static List<RCC_STS> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RCC_STS/GetAll");
            return serializer.Deserialize<List<RCC_STS>>(str);
        }
        public static List<RCC_STS> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RCC_STS/GetActiveList");
            return serializer.Deserialize<List<RCC_STS>>(str);
        }
        public static RCC_STS GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            RCC_STS Obj = serializer.Deserialize<RCC_STS>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RCC_STS/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(RCC_STS Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RCC_STS/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(RCC_STS Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RCC_STS/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RCC_STS/Delete", PostData);
        }
    }
}
