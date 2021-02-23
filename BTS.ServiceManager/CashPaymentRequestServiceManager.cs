using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class CashPaymentRequestServiceManager
    {
        public static List<CashPaymentRequest> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashPaymentRequest/GetAll");
            return serializer.Deserialize<List<CashPaymentRequest>>(str);
        }
        public static List<CashPaymentRequest> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashPaymentRequest/GetActiveList");
            return serializer.Deserialize<List<CashPaymentRequest>>(str);
        }
        public static CashPaymentRequest GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            CashPaymentRequest Obj = serializer.Deserialize<CashPaymentRequest>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CashPaymentRequest/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(CashPaymentRequest Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashPaymentRequest/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(CashPaymentRequest Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashPaymentRequest/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CashPaymentRequest/Delete", PostData);
        }
    }
}
