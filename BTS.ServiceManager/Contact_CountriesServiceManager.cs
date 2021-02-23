using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Contact_CountriesServiceManager
    {
        public static List<Contact_Countries> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Countries/GetAll");
            return serializer.Deserialize<List<Contact_Countries>>(str);
        }
        public static List<Contact_Countries> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Countries/GetActiveList");
            return serializer.Deserialize<List<Contact_Countries>>(str);
        }
        public static Contact_Countries GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact_Countries Obj = serializer.Deserialize<Contact_Countries>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Countries/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact_Countries Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Countries/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact_Countries Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Countries/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Countries/Delete", PostData);
        }
    }
}
