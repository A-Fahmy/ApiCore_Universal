using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Contact_CVServiceManager
    {
        public static List<Contact_CV> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_CV/GetAll");
            return serializer.Deserialize<List<Contact_CV>>(str);
        }
        public static List<Contact_CV> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_CV/GetActiveList");
            return serializer.Deserialize<List<Contact_CV>>(str);
        }
        public static Contact_CV GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact_CV Obj = serializer.Deserialize<Contact_CV>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_CV/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact_CV Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_CV/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact_CV Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_CV/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_CV/Delete", PostData);
        }
    }
}
