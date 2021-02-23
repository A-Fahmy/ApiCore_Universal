using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Contact_WorkPlacesProposedServiceManager
    {
        public static List<Contact_WorkPlacesProposed> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_WorkPlacesProposed/GetAll");
            return serializer.Deserialize<List<Contact_WorkPlacesProposed>>(str);
        }
        public static List<Contact_WorkPlacesProposed> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_WorkPlacesProposed/GetActiveList");
            return serializer.Deserialize<List<Contact_WorkPlacesProposed>>(str);
        }
        public static Contact_WorkPlacesProposed GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact_WorkPlacesProposed Obj = serializer.Deserialize<Contact_WorkPlacesProposed>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_WorkPlacesProposed/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact_WorkPlacesProposed Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_WorkPlacesProposed/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact_WorkPlacesProposed Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_WorkPlacesProposed/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_WorkPlacesProposed/Delete", PostData);
        }
    }
}
