using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class FielsUploadServiceManager
    {
        public static List<FielsUpload> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FielsUpload/GetAll");
            return serializer.Deserialize<List<FielsUpload>>(str);
        }
        public static List<FielsUpload> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FielsUpload/GetActiveList");
            return serializer.Deserialize<List<FielsUpload>>(str);
        }
        public static FielsUpload GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            FielsUpload Obj = serializer.Deserialize<FielsUpload>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FielsUpload/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(FielsUpload Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FielsUpload/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(FielsUpload Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FielsUpload/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FielsUpload/Delete", PostData);
        }
    }
}
