using BTS.Entities;
using BTS.Entities.Views;
using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Settings
{
    public partial class ConfirmPasswordURL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                ////http://localhost:1114/Forms/Settings/ConfirmPasswordURL.aspx?Mail=ahmed.Fahmy@besttopsystems.com
                string _Mail = Request.QueryString["Mail"];
            if(_Mail!=null)
            { 
            List<User> Obj = UserServiceManagerExtension.GetByEmail(_Mail);
            txtName.Text = Obj[0].UserName;
            }
            }
            catch(Exception exc)
            {
            }
        }

        protected void btnConfirmPwd_Click(object sender, EventArgs e)
        {
            string _Mail = Request.QueryString["Mail"];
            User Obj = UserServiceManagerExtension.GetByEmail(_Mail).FirstOrDefault();
            Obj.Password = txtPwd.Text;
            UserServiceManager.Update(Obj);
            ClientScript.RegisterStartupScript(this.GetType(), "Login", "Password Updated ", true);

            Response.Redirect("/Forms/Registeration/Login.aspx");

        }
    }
}