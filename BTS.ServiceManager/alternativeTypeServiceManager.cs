using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class alternativeTypeServiceManager
    {
        public static List<alternativeType> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "alternativeType/GetAll");
            return serializer.Deserialize<List<alternativeType>>(str);
        }
        public static List<alternativeType> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "alternativeType/GetActiveList");
            return serializer.Deserialize<List<alternativeType>>(str);
        }
        public static alternativeType GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            alternativeType Obj = serializer.Deserialize<alternativeType>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "alternativeType/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(alternativeType Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "alternativeType/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(alternativeType Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "alternativeType/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "alternativeType/Delete", PostData);
        }
    }
}
