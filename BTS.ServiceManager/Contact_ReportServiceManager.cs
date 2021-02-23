using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Contact_ReportServiceManager
    {
        public static List<Contact_Report> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Report/GetAll");
            return serializer.Deserialize<List<Contact_Report>>(str);
        }
        public static List<Contact_Report> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Report/GetActiveList");
            return serializer.Deserialize<List<Contact_Report>>(str);
        }
        public static Contact_Report GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Contact_Report Obj = serializer.Deserialize<Contact_Report>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact_Report/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Contact_Report Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Report/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Contact_Report Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Report/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact_Report/Delete", PostData);
        }
    }
}
