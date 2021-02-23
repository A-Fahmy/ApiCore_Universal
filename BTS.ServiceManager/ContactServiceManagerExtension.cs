using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.Entities;
using System.Web;
using System.Web.Script.Serialization;
using BTS.Entities.Views;

namespace BTS.ServiceManager
{
    public partial class ContactServiceManager
    {
        public static List<View_KeyValueLookup> GetByUserName(string Username)
        {
            var serializer = new JavaScriptSerializer();

            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact/GetByUserName/" + Username).ToString();
            return serializer.Deserialize<List<View_KeyValueLookup>>(str);
        }
        public static List<Contact> GetCOntactByUserName(string Username)
        {
            var serializer = new JavaScriptSerializer();

            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact/GetByUserName/" + Username).ToString();
            return serializer.Deserialize<List<Contact>>(str);
        }
        public static Contact GetByEmail(string Email)
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "Contact/GetByEmail/" + HttpUtility.UrlEncode(Email)).ToString();
            return serializer.Deserialize<Contact>(str);
        }
        public static bool Sending_Email(string From_Email, string To_Email, String Message, string Subject)
        {
            try
            {
                EmailMetaData emailMetaData = new EmailMetaData();
                emailMetaData.From_Email = From_Email;
                emailMetaData.To_Email = To_Email;
                emailMetaData.Message = Message;
                emailMetaData.Subject = Subject;
                string PostData = new JavaScriptSerializer().Serialize(emailMetaData);
                var res = WebServiceManager.PostService(WebServiceManager.WebServiceURL + "Contact/Sending_Email", PostData);
                return true;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
