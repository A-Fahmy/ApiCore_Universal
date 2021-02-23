using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class DeductionServiceManager
    {
        public static List<Deduction> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Deduction/GetAll");
            return serializer.Deserialize<List<Deduction>>(str);
        }
        public static List<Deduction> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Deduction/GetActiveList");
            return serializer.Deserialize<List<Deduction>>(str);
        }
        public static Deduction GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Deduction Obj = serializer.Deserialize<Deduction>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Deduction/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Deduction Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Deduction/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Deduction Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Deduction/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Deduction/Delete", PostData);
        }
    }
}
