using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Contact_MeetingPointsServiceManager
    {
        public static List<Contact_MeetingPoints> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_MeetingPoints/GetAll");
            return serializer.Deserialize<List<Contact_MeetingPoints>>(str);
        }
        public static List<Contact_MeetingPoints> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_MeetingPoints/GetActiveList");
            return serializer.Deserialize<List<Contact_MeetingPoints>>(str);
        }
        public static Contact_MeetingPoints GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact_MeetingPoints Obj = serializer.Deserialize<Contact_MeetingPoints>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_MeetingPoints/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact_MeetingPoints Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_MeetingPoints/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact_MeetingPoints Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_MeetingPoints/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_MeetingPoints/Delete", PostData);
        }
    }
}
