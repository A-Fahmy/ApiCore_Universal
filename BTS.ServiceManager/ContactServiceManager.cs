using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class ContactServiceManager
    {
        public static List<Contact> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact/GetAll");
            return serializer.Deserialize<List<Contact>>(str);
        }
        public static List<Contact> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact/GetActiveList");
            return serializer.Deserialize<List<Contact>>(str);
        }
        public static Contact GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact Obj = serializer.Deserialize<Contact>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact/Delete", PostData);
        }
    }
}
