using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class SuspensionServiceManager
    {
        public static List<Suspension> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Suspension/GetAll");
            return serializer.Deserialize<List<Suspension>>(str);
        }
        public static List<Suspension> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Suspension/GetActiveList");
            return serializer.Deserialize<List<Suspension>>(str);
        }
        public static Suspension GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Suspension Obj = serializer.Deserialize<Suspension>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Suspension/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Suspension Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Suspension/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Suspension Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Suspension/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Suspension/Delete", PostData);
        }
    }
}
