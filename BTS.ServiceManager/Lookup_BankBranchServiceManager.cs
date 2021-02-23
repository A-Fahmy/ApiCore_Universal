using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_BankBranchServiceManager
    {
        public static List<Lookup_BankBranch> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_BankBranch/GetAll");
            return serializer.Deserialize<List<Lookup_BankBranch>>(str);
        }
        public static List<Lookup_BankBranch> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_BankBranch/GetActiveList");
            return serializer.Deserialize<List<Lookup_BankBranch>>(str);
        }
        public static Lookup_BankBranch GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_BankBranch Obj = serializer.Deserialize<Lookup_BankBranch>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_BankBranch/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_BankBranch Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_BankBranch/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_BankBranch Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_BankBranch/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_BankBranch/Delete", PostData);
        }
    }
}
