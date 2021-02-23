using BTS.Entities;
using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Registeration
{
    public partial class Login : System.Web.UI.Page
    {
        #region properities
        List<User> user;
        private bool PageRefreshed;

        #endregion

        #region Evets
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetNoStore();
                if (!IsPostBack)
                {
                    Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());
                    if (Session["LoggedUsers"]!=null)
                    {
                        Session["LoggedUsers"] = null;
                    }
                }
            }

            catch (Exception exc)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session["update"].ToString() == ViewState["update"].ToString())
            {
                string PWD = Base64Encode(txtPassword.Text);
                if (VaildUser(txtUsername.Text, PWD))
                {
                    user = UserServiceManager.GetAll();
                    User Users = user.Find(x => x.UserName.ToUpper() == txtUsername.Text.ToUpper());
                    int group = int.Parse(Users.GroupID.ToString());
                    Session["group"] = group;
                    Session["LoggedUsers"] = txtUsername.Text;
                    Response.Redirect("/Forms/Registeration/Default.aspx");
                }
                else
                {
                    lblInvalidUser.Visible = true;
                }
                Session["update"] = Server.UrlEncode(System.DateTime.Now.ToString());

            }

            else
                Response.Redirect(Request.RawUrl);
        }

        protected override void OnPreRender(EventArgs e)
        {
            ViewState["update"] = Session["update"];
        }

        #endregion

        #region methods
        public  bool VaildUser(string username,string password)
        {
            user = UserServiceManagerExtension.GetByUserName(username);
           
            if (user.Count > 0 && password.ToUpper()==user[0].Password.ToUpper())
                return true;
            else
                return false;
        }
        #endregion
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}