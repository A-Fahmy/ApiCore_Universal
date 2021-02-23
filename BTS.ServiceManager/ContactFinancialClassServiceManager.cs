using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class ContactFinancialClassServiceManager
    {
        public static List<ContactFinancialClass> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ContactFinancialClass/GetAll");
            return serializer.Deserialize<List<ContactFinancialClass>>(str);
        }
        public static List<ContactFinancialClass> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ContactFinancialClass/GetActiveList");
            return serializer.Deserialize<List<ContactFinancialClass>>(str);
        }
        public static ContactFinancialClass GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            ContactFinancialClass Obj = serializer.Deserialize<ContactFinancialClass>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "ContactFinancialClass/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(ContactFinancialClass Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ContactFinancialClass/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(ContactFinancialClass Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ContactFinancialClass/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "ContactFinancialClass/Delete", PostData);
        }
    }
}
