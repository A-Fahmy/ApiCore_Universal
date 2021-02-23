using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class LOVServiceManager
    {
        public static List<LOV> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "LOV/GetAll");
            return serializer.Deserialize<List<LOV>>(str);
        }
        public static List<LOV> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "LOV/GetActiveList");
            return serializer.Deserialize<List<LOV>>(str);
        }
        public static LOV GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            LOV Obj = serializer.Deserialize<LOV>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "LOV/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(LOV Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "LOV/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(LOV Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "LOV/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "LOV/Delete", PostData);
        }
    }
}
