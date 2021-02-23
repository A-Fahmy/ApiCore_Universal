using System.Collections.Generic;
using System.Web.Script.Serialization;
using BTS.Entities;

namespace BTS.ServiceManager
{
    public partial class CardTokenServiceManager
    {
        public static List<CardToken> GetAll()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CardToken/GetAll");
            return serializer.Deserialize<List<CardToken>>(str);
        }
        public static List<CardToken> GetActiveList()
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CardToken/GetActiveList");
            return serializer.Deserialize<List<CardToken>>(str);
        }
        public static CardToken GetByCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            CardToken Obj = serializer.Deserialize<CardToken>(WebServiceManager.GetService(WebServiceManager.WebServiceURL + "CardToken/GetByCode/" + Code.ToString()));
            return Obj;
        }
        public static int Insert(CardToken Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CardToken/Insert", PostData);
            return int.Parse(res.ToString());
        }
        public static void Update(CardToken Obj)
        {
            string PostData = new JavaScriptSerializer().Serialize(Obj);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CardToken/Update", PostData);
        }
        public static void Delete(int Code)
        {
            string PostData = new JavaScriptSerializer().Serialize(Code);
            var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "CardToken/Delete", PostData);
        }
    }
}
