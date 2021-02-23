using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class DiscountServiceManager
    {
        public static List<Discount> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Discount/GetAll");
            return serializer.Deserialize<List<Discount>>(str);
        }
        public static List<Discount> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Discount/GetActiveList");
            return serializer.Deserialize<List<Discount>>(str);
        }
        public static Discount GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Discount Obj = serializer.Deserialize<Discount>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Discount/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Discount Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Discount/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Discount Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Discount/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Discount/Delete", PostData);
        }
    }
}
