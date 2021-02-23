using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class CardToken_ResponseServiceManager
    {
        public static List<CardToken_Response> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CardToken_Response/GetAll");
            return serializer.Deserialize<List<CardToken_Response>>(str);
        }
        public static List<CardToken_Response> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CardToken_Response/GetActiveList");
            return serializer.Deserialize<List<CardToken_Response>>(str);
        }
        public static CardToken_Response GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            CardToken_Response Obj = serializer.Deserialize<CardToken_Response>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CardToken_Response/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(CardToken_Response Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CardToken_Response/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(CardToken_Response Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CardToken_Response/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CardToken_Response/Delete", PostData);
        }
    }
}
