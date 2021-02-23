using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class EmailMetaDataServiceManager
    {
        public static List<EmailMetaData> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "EmailMetaData/GetAll");
            return serializer.Deserialize<List<EmailMetaData>>(str);
        }
        public static List<EmailMetaData> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "EmailMetaData/GetActiveList");
            return serializer.Deserialize<List<EmailMetaData>>(str);
        }
        public static EmailMetaData GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            EmailMetaData Obj = serializer.Deserialize<EmailMetaData>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "EmailMetaData/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(EmailMetaData Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "EmailMetaData/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(EmailMetaData Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "EmailMetaData/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "EmailMetaData/Delete", PostData);
        }
    }
}
