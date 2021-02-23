using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class FeaturedExpertiseLogServiceManager
    {
        public static List<FeaturedExpertiseLog> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FeaturedExpertiseLog/GetAll");
            return serializer.Deserialize<List<FeaturedExpertiseLog>>(str);
        }
        public static List<FeaturedExpertiseLog> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FeaturedExpertiseLog/GetActiveList");
            return serializer.Deserialize<List<FeaturedExpertiseLog>>(str);
        }
        public static FeaturedExpertiseLog GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            FeaturedExpertiseLog Obj = serializer.Deserialize<FeaturedExpertiseLog>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FeaturedExpertiseLog/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(FeaturedExpertiseLog Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FeaturedExpertiseLog/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(FeaturedExpertiseLog Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FeaturedExpertiseLog/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FeaturedExpertiseLog/Delete", PostData);
        }
    }
}
