using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Business;
using BTS.Entities;
using BTS.ServiceManager;

namespace BTS.PL.Forms
{
	public partial class Test : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //Contact Obj = ContactBusiness.GetByEmail("islam.abdelhamid");
            //Contact Obj = ContactServiceManager.GetByEmail("islam.abdelhamid");
            Lookup_Countries Obj = new Lookup_Countries();
            Obj.CountryNameEn = "test1";
            Obj.CountryNameAr = "test1";
            Obj.CurrencyNameEn = "test1";
            Obj.CurrencyNameAr = "test1";
            Obj.CurrencyISOCode = "test1";
            Obj.ExchangeRateToEGP = 5;
            Obj.KeyInternational = "02";
            Obj.Photo = null; //fuImage.FileBytes;
            Obj.IsActive = true;

            Lookup_CountriesBusiness.Insert(Obj);
        }
    }
}