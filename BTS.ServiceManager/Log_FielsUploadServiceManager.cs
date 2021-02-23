using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Log_FielsUploadServiceManager
    {
        public static List<Log_FielsUpload> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Log_FielsUpload/GetAll");
            return serializer.Deserialize<List<Log_FielsUpload>>(str);
        }
        public static List<Log_FielsUpload> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Log_FielsUpload/GetActiveList");
            return serializer.Deserialize<List<Log_FielsUpload>>(str);
        }
        public static Log_FielsUpload GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Log_FielsUpload Obj = serializer.Deserialize<Log_FielsUpload>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Log_FielsUpload/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Log_FielsUpload Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Log_FielsUpload/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Log_FielsUpload Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Log_FielsUpload/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Log_FielsUpload/Delete", PostData);
        }
    }
}
