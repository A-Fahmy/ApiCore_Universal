using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Lookup_HelpServiceManager
    {
        public static List<Lookup_Help> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Help/GetAll");
            return serializer.Deserialize<List<Lookup_Help>>(str);
        }
        public static List<Lookup_Help> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Help/GetActiveList");
            return serializer.Deserialize<List<Lookup_Help>>(str);
        }
        public static Lookup_Help GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Lookup_Help Obj = serializer.Deserialize<Lookup_Help>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Lookup_Help/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Lookup_Help Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Help/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Lookup_Help Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Help/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Lookup_Help/Delete", PostData);
        }
    }
}
