using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class FinsStatementServiceManager
    {
        public static List<FinsStatement> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FinsStatement/GetAll");
            return serializer.Deserialize<List<FinsStatement>>(str);
        }
        public static List<FinsStatement> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FinsStatement/GetActiveList");
            return serializer.Deserialize<List<FinsStatement>>(str);
        }
        public static FinsStatement GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            FinsStatement Obj = serializer.Deserialize<FinsStatement>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "FinsStatement/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(FinsStatement Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FinsStatement/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(FinsStatement Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FinsStatement/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "FinsStatement/Delete", PostData);
        }
    }
}
