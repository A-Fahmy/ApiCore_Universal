using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class RiseStoredPlaceServiceManager
    {
        public static List<RiseStoredPlace> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RiseStoredPlace/GetAll");
            return serializer.Deserialize<List<RiseStoredPlace>>(str);
        }
        public static List<RiseStoredPlace> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RiseStoredPlace/GetActiveList");
            return serializer.Deserialize<List<RiseStoredPlace>>(str);
        }
        public static RiseStoredPlace GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            RiseStoredPlace Obj = serializer.Deserialize<RiseStoredPlace>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "RiseStoredPlace/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(RiseStoredPlace Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RiseStoredPlace/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(RiseStoredPlace Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RiseStoredPlace/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "RiseStoredPlace/Delete", PostData);
        }
    }
}
