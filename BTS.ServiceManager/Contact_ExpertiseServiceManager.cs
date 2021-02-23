using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Contact_ExpertiseServiceManager
    {
        public static List<Contact_Expertise> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Expertise/GetAll");
            return serializer.Deserialize<List<Contact_Expertise>>(str);
        }
        public static List<Contact_Expertise> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Expertise/GetActiveList");
            return serializer.Deserialize<List<Contact_Expertise>>(str);
        }
        public static Contact_Expertise GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact_Expertise Obj = serializer.Deserialize<Contact_Expertise>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Expertise/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact_Expertise Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Expertise/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact_Expertise Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Expertise/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Expertise/Delete", PostData);
        }
    }
}
