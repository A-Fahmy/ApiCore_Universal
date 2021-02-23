using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class NBE_CreditPaymentStatusServiceManager
    {
        public static List<NBE_CreditPaymentStatus> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "NBE_CreditPaymentStatus/GetAll");
            return serializer.Deserialize<List<NBE_CreditPaymentStatus>>(str);
        }
        public static List<NBE_CreditPaymentStatus> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "NBE_CreditPaymentStatus/GetActiveList");
            return serializer.Deserialize<List<NBE_CreditPaymentStatus>>(str);
        }
        public static NBE_CreditPaymentStatus GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            NBE_CreditPaymentStatus Obj = serializer.Deserialize<NBE_CreditPaymentStatus>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "NBE_CreditPaymentStatus/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(NBE_CreditPaymentStatus Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "NBE_CreditPaymentStatus/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(NBE_CreditPaymentStatus Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "NBE_CreditPaymentStatus/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "NBE_CreditPaymentStatus/Delete", PostData);
        }
    }
}
