using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Registeration
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Response.Cache.SetNoStore();
                if (Session["LoggedUsers"] == null)
                {
                    Response.Redirect("/Forms/Registeration/Login.aspx");
                    return;
                }
              
            }
        }
    }
}