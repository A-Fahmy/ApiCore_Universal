using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Charge_ResponseServiceManager
    {
        public static List<Charge_Response> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Charge_Response/GetAll");
            return serializer.Deserialize<List<Charge_Response>>(str);
        }
        public static List<Charge_Response> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Charge_Response/GetActiveList");
            return serializer.Deserialize<List<Charge_Response>>(str);
        }
        public static Charge_Response GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Charge_Response Obj = serializer.Deserialize<Charge_Response>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Charge_Response/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Charge_Response Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Charge_Response/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Charge_Response Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Charge_Response/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Charge_Response/Delete", PostData);
        }
    }
}
