using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class PackageServiceManager
    {
        public static List<Package> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Package/GetAll");
            return serializer.Deserialize<List<Package>>(str);
        }
        public static List<Package> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Package/GetActiveList");
            return serializer.Deserialize<List<Package>>(str);
        }
        public static Package GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Package Obj = serializer.Deserialize<Package>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Package/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Package Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Package/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Package Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Package/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Package/Delete", PostData);
        }
    }
}
