using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class ChargeServiceManager
    {
        public static List<Charge> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Charge/GetAll");
            return serializer.Deserialize<List<Charge>>(str);
        }
        public static List<Charge> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Charge/GetActiveList");
            return serializer.Deserialize<List<Charge>>(str);
        }
        public static Charge GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Charge Obj = serializer.Deserialize<Charge>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Charge/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Charge Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Charge/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Charge Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Charge/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Charge/Delete", PostData);
        }
    }
}
