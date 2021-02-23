using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class CashCallbackResponseServiceManager
    {
        public static List<CashCallbackResponse> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashCallbackResponse/GetAll");
            return serializer.Deserialize<List<CashCallbackResponse>>(str);
        }
        public static List<CashCallbackResponse> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashCallbackResponse/GetActiveList");
            return serializer.Deserialize<List<CashCallbackResponse>>(str);
        }
        public static CashCallbackResponse GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            CashCallbackResponse Obj = serializer.Deserialize<CashCallbackResponse>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashCallbackResponse/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(CashCallbackResponse Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashCallbackResponse/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(CashCallbackResponse Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashCallbackResponse/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashCallbackResponse/Delete", PostData);
        }
    }
}
