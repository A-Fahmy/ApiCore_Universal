using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class PackageInfoServiceManager
    {
        public static List<PackageInfo> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PackageInfo/GetAll");
            return serializer.Deserialize<List<PackageInfo>>(str);
        }
        public static List<PackageInfo> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PackageInfo/GetActiveList");
            return serializer.Deserialize<List<PackageInfo>>(str);
        }
        public static PackageInfo GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            PackageInfo Obj = serializer.Deserialize<PackageInfo>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PackageInfo/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(PackageInfo Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PackageInfo/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(PackageInfo Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PackageInfo/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PackageInfo/Delete", PostData);
        }
    }
}
