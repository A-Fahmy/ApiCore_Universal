using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Contact_WorkPlacesServiceManager
    {
        public static List<Contact_WorkPlaces> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_WorkPlaces/GetAll");
            return serializer.Deserialize<List<Contact_WorkPlaces>>(str);
        }
        public static List<Contact_WorkPlaces> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_WorkPlaces/GetActiveList");
            return serializer.Deserialize<List<Contact_WorkPlaces>>(str);
        }
        public static Contact_WorkPlaces GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact_WorkPlaces Obj = serializer.Deserialize<Contact_WorkPlaces>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_WorkPlaces/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact_WorkPlaces Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_WorkPlaces/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact_WorkPlaces Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_WorkPlaces/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_WorkPlaces/Delete", PostData);
        }
    }
}
