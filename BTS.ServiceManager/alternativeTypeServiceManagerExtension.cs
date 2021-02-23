using BTS.Entities;
using BTS.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BTS.ServiceManager
{
   public partial class alternativeTypeServiceManager
    {
        public static List<View_KeyValueLookup> GetKeyValueList(CommonSettings.Languages LanguageID)
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "alternativeType/GetKeyValueList/" + ((int)LanguageID).ToString());
            return serializer.Deserialize<List<View_KeyValueLookup>>(str);
        }
    }
}
