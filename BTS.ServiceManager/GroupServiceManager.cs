using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class GroupServiceManager
    {
        public static List<Group> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Group/GetAll");
            return serializer.Deserialize<List<Group>>(str);
        }
        public static List<Group> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Group/GetActiveList");
            return serializer.Deserialize<List<Group>>(str);
        }
        public static Group GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Group Obj = serializer.Deserialize<Group>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Group/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Group Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Group/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Group Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Group/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Group/Delete", PostData);
        }
    }
}
