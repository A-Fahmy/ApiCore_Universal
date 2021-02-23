using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class OnlineFormServiceManager
    {
        public static List<OnlineForm> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "OnlineForm/GetAll");
            return serializer.Deserialize<List<OnlineForm>>(str);
        }
        public static List<OnlineForm> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "OnlineForm/GetActiveList");
            return serializer.Deserialize<List<OnlineForm>>(str);
        }
        public static OnlineForm GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            OnlineForm Obj = serializer.Deserialize<OnlineForm>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "OnlineForm/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(OnlineForm Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "OnlineForm/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(OnlineForm Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "OnlineForm/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "OnlineForm/Delete", PostData);
        }
    }
}
