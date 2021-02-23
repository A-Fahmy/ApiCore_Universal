using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class PaymentStatus_ResponseServiceManager
    {
        public static List<PaymentStatus_Response> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PaymentStatus_Response/GetAll");
            return serializer.Deserialize<List<PaymentStatus_Response>>(str);
        }
        public static List<PaymentStatus_Response> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PaymentStatus_Response/GetActiveList");
            return serializer.Deserialize<List<PaymentStatus_Response>>(str);
        }
        public static PaymentStatus_Response GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            PaymentStatus_Response Obj = serializer.Deserialize<PaymentStatus_Response>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PaymentStatus_Response/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(PaymentStatus_Response Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PaymentStatus_Response/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(PaymentStatus_Response Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PaymentStatus_Response/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PaymentStatus_Response/Delete", PostData);
        }
    }
}
