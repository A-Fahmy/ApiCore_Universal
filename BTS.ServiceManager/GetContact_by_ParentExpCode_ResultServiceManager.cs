using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class GetContact_by_ParentExpCode_ResultServiceManager
    {
        public static List<GetContact_by_ParentExpCode_Result> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GetContact_by_ParentExpCode_Result/GetAll");
            return serializer.Deserialize<List<GetContact_by_ParentExpCode_Result>>(str);
        }
        public static List<GetContact_by_ParentExpCode_Result> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GetContact_by_ParentExpCode_Result/GetActiveList");
            return serializer.Deserialize<List<GetContact_by_ParentExpCode_Result>>(str);
        }
        public static GetContact_by_ParentExpCode_Result GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            GetContact_by_ParentExpCode_Result Obj = serializer.Deserialize<GetContact_by_ParentExpCode_Result>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GetContact_by_ParentExpCode_Result/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(GetContact_by_ParentExpCode_Result Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GetContact_by_ParentExpCode_Result/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(GetContact_by_ParentExpCode_Result Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GetContact_by_ParentExpCode_Result/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GetContact_by_ParentExpCode_Result/Delete", PostData);
        }
    }
}
