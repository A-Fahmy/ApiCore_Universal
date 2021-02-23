using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class PostRV_QuestionsServiceManager
    {
        public static List<PostRV_Questions> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PostRV_Questions/GetAll");
            return serializer.Deserialize<List<PostRV_Questions>>(str);
        }
        public static List<PostRV_Questions> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PostRV_Questions/GetActiveList");
            return serializer.Deserialize<List<PostRV_Questions>>(str);
        }
        public static PostRV_Questions GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            PostRV_Questions Obj = serializer.Deserialize<PostRV_Questions>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "PostRV_Questions/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(PostRV_Questions Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PostRV_Questions/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(PostRV_Questions Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PostRV_Questions/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "PostRV_Questions/Delete", PostData);
        }
    }
}
