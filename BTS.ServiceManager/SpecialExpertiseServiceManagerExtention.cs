using BTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BTS.ServiceManager
{
   public partial class SpecialExpertiseServiceManager
    {
        public static SpecialExpertise GetByUserCode(int Code)
        {
            var serializer = new JavaScriptSerializer();
            string str = WebServiceManager.GetService(WebServiceManager.WebServiceURL + "SpecialExpertise/GetByUserCode/" + Code.ToString());
            return serializer.Deserialize<SpecialExpertise>(str);
        }
    }
}
