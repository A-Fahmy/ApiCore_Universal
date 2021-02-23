using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class TransactionPaymentServiceManager
    {
        public static List<TransactionPayment> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "TransactionPayment/GetAll");
            return serializer.Deserialize<List<TransactionPayment>>(str);
        }
        public static List<TransactionPayment> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "TransactionPayment/GetActiveList");
            return serializer.Deserialize<List<TransactionPayment>>(str);
        }
        public static TransactionPayment GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            TransactionPayment Obj = serializer.Deserialize<TransactionPayment>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "TransactionPayment/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(TransactionPayment Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "TransactionPayment/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(TransactionPayment Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "TransactionPayment/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "TransactionPayment/Delete", PostData);
        }
    }
}
