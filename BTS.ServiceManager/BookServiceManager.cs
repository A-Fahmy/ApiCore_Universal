using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class BookServiceManager
    {
        public static List<Book> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Book/GetAll");
            return serializer.Deserialize<List<Book>>(str);
        }
        public static List<Book> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Book/GetActiveList");
            return serializer.Deserialize<List<Book>>(str);
        }
        public static Book GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            Book Obj = serializer.Deserialize<Book>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Book/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(Book Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Book/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(Book Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Book/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Book/Delete", PostData);
        }
    }
}
