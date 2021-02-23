using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BTS.ServiceManager
{
    public static class WebServiceManager
    {
        private static HttpClient client = new HttpClient();

        public static string WebServiceURL
        {
            get
            {
                //Get the web service URL from the web application web.config file
                // return ConfigurationManager.AppSettings["WebServiceURL"].ToString();

                 return "http://151.106.34.109:9494/api/";
                  // return "http://192.168.1.46:9090/api/";
                // return "http://ahmedshorim-001-site1.itempurl.com/api/";
                //  return "http://webservice.risetesting.com/api/";
                // return "http://160.153.244.15:9292/api/";


            }
        }

        public static string GetService(string URL)
        {
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(URL);
            httpWReq.Method = "GET";
            string result = null;
            using (WebResponse response = httpWReq.GetResponseAsync().Result)
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
        public static string PostService(string URL, string postData)
        {
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(URL);

            byte[] data = Encoding.UTF8.GetBytes(postData);

            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/json";

            using (Stream stream = httpWReq.GetRequestStreamAsync().Result)
            {
                stream.Write(data, 0, data.Length);
            }

            string result = null;
            using (WebResponse response = httpWReq.GetResponseAsync().Result)
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public static string DeleteService(string URL, string postData)
        {
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(URL);

            byte[] data = Encoding.UTF8.GetBytes(postData);

            httpWReq.Method = "DELETE";
            httpWReq.ContentType = "application/json";

            using (Stream stream = httpWReq.GetRequestStreamAsync().Result)
            {
                stream.Write(data, 0, data.Length);
            }

            string result = null;
            using (WebResponse response = httpWReq.GetResponseAsync().Result)
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
