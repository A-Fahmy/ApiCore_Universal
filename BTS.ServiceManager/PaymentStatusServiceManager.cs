using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class PaymentStatusServiceManager
    {
        public static List<PaymentStatus> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PaymentStatus/GetAll");
            return serializer.Deserialize<List<PaymentStatus>>(str);
        }
        public static List<PaymentStatus> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PaymentStatus/GetActiveList");
            return serializer.Deserialize<List<PaymentStatus>>(str);
        }
        public static PaymentStatus GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            PaymentStatus Obj = serializer.Deserialize<PaymentStatus>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PaymentStatus/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(PaymentStatus Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PaymentStatus/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(PaymentStatus Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PaymentStatus/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PaymentStatus/Delete", PostData);
        }
    }
}
