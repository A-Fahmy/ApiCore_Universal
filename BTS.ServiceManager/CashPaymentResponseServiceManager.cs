using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class CashPaymentResponseServiceManager
    {
        public static List<CashPaymentResponse> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashPaymentResponse/GetAll");
            return serializer.Deserialize<List<CashPaymentResponse>>(str);
        }
        public static List<CashPaymentResponse> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashPaymentResponse/GetActiveList");
            return serializer.Deserialize<List<CashPaymentResponse>>(str);
        }
        public static CashPaymentResponse GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            CashPaymentResponse Obj = serializer.Deserialize<CashPaymentResponse>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashPaymentResponse/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(CashPaymentResponse Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashPaymentResponse/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(CashPaymentResponse Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashPaymentResponse/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashPaymentResponse/Delete", PostData);
        }
    }
}
