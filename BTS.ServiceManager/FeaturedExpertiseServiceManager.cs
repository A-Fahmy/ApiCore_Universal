using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class FeaturedExpertiseServiceManager
    {
        public static List<FeaturedExpertise> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FeaturedExpertise/GetAll");
            return serializer.Deserialize<List<FeaturedExpertise>>(str);
        }
        public static List<FeaturedExpertise> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FeaturedExpertise/GetActiveList");
            return serializer.Deserialize<List<FeaturedExpertise>>(str);
        }
        public static FeaturedExpertise GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            FeaturedExpertise Obj = serializer.Deserialize<FeaturedExpertise>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FeaturedExpertise/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(FeaturedExpertise Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FeaturedExpertise/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(FeaturedExpertise Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FeaturedExpertise/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FeaturedExpertise/Delete", PostData);
        }
    }
}
