using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class GroupPermessionServiceManager
    {
        public static List<GroupPermession> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GroupPermession/GetAll");
            return serializer.Deserialize<List<GroupPermession>>(str);
        }
        public static List<GroupPermession> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GroupPermession/GetActiveList");
            return serializer.Deserialize<List<GroupPermession>>(str);
        }
        public static GroupPermession GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            GroupPermession Obj = serializer.Deserialize<GroupPermession>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "GroupPermession/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(GroupPermession Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GroupPermession/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(GroupPermession Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GroupPermession/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "GroupPermession/Delete", PostData);
        }
    }
}
