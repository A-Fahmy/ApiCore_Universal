using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class ExpertiseSuggestionServiceManager
    {
        public static List<ExpertiseSuggestion> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ExpertiseSuggestion/GetAll");
            return serializer.Deserialize<List<ExpertiseSuggestion>>(str);
        }
        public static List<ExpertiseSuggestion> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ExpertiseSuggestion/GetActiveList");
            return serializer.Deserialize<List<ExpertiseSuggestion>>(str);
        }
        public static ExpertiseSuggestion GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            ExpertiseSuggestion Obj = serializer.Deserialize<ExpertiseSuggestion>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ExpertiseSuggestion/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(ExpertiseSuggestion Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ExpertiseSuggestion/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(ExpertiseSuggestion Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ExpertiseSuggestion/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ExpertiseSuggestion/Delete", PostData);
        }
    }
}
