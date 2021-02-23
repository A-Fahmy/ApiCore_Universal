using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class Book_HistoryServiceManager
    {
        public static List<Book_History> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Book_History/GetAll");
            return serializer.Deserialize<List<Book_History>>(str);
        }
        public static List<Book_History> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Book_History/GetActiveList");
            return serializer.Deserialize<List<Book_History>>(str);
        }
        public static Book_History GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Book_History Obj = serializer.Deserialize<Book_History>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Book_History/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Book_History Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Book_History/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Book_History Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Book_History/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Book_History/Delete", PostData);
        }
    }
}
