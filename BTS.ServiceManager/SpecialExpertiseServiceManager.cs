using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class SpecialExpertiseServiceManager
    {
        public static List<SpecialExpertise> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "SpecialExpertise/GetAll");
            return serializer.Deserialize<List<SpecialExpertise>>(str);
        }
        public static List<SpecialExpertise> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "SpecialExpertise/GetActiveList");
            return serializer.Deserialize<List<SpecialExpertise>>(str);
        }
        public static SpecialExpertise GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            SpecialExpertise Obj = serializer.Deserialize<SpecialExpertise>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "SpecialExpertise/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(SpecialExpertise Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "SpecialExpertise/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(SpecialExpertise Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "SpecialExpertise/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "SpecialExpertise/Delete", PostData);
        }
    }
}
