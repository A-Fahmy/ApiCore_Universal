using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class BookinglinkServiceManager
    {
        public static List<Bookinglink> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Bookinglink/GetAll");
            return serializer.Deserialize<List<Bookinglink>>(str);
        }
        public static List<Bookinglink> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Bookinglink/GetActiveList");
            return serializer.Deserialize<List<Bookinglink>>(str);
        }
        public static Bookinglink GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Bookinglink Obj = serializer.Deserialize<Bookinglink>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Bookinglink/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Bookinglink Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Bookinglink/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Bookinglink Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Bookinglink/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Bookinglink/Delete", PostData);
        }
    }
}
