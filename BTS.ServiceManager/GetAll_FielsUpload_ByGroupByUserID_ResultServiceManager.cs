using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class GetAll_FielsUpload_ByGroupByUserID_ResultServiceManager
    {
        public static List<GetAll_FielsUpload_ByGroupByUserID_Result> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GetAll_FielsUpload_ByGroupByUserID_Result/GetAll");
            return serializer.Deserialize<List<GetAll_FielsUpload_ByGroupByUserID_Result>>(str);
        }
        public static List<GetAll_FielsUpload_ByGroupByUserID_Result> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GetAll_FielsUpload_ByGroupByUserID_Result/GetActiveList");
            return serializer.Deserialize<List<GetAll_FielsUpload_ByGroupByUserID_Result>>(str);
        }
        public static GetAll_FielsUpload_ByGroupByUserID_Result GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            GetAll_FielsUpload_ByGroupByUserID_Result Obj = serializer.Deserialize<GetAll_FielsUpload_ByGroupByUserID_Result>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GetAll_FielsUpload_ByGroupByUserID_Result/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(GetAll_FielsUpload_ByGroupByUserID_Result Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GetAll_FielsUpload_ByGroupByUserID_Result/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(GetAll_FielsUpload_ByGroupByUserID_Result Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GetAll_FielsUpload_ByGroupByUserID_Result/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GetAll_FielsUpload_ByGroupByUserID_Result/Delete", PostData);
        }
    }
}
