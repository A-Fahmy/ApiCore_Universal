using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class DuePaymentServiceManager
    {
        public static List<DuePayment> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "DuePayment/GetAll");
            return serializer.Deserialize<List<DuePayment>>(str);
        }
        public static List<DuePayment> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "DuePayment/GetActiveList");
            return serializer.Deserialize<List<DuePayment>>(str);
        }
        public static DuePayment GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            DuePayment Obj = serializer.Deserialize<DuePayment>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "DuePayment/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(DuePayment Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "DuePayment/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(DuePayment Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "DuePayment/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "DuePayment/Delete", PostData);
        }
    }
}
