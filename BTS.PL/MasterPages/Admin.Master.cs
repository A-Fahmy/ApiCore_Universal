using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;
using System.Web.UI.HtmlControls;

namespace BTS.PL.MasterPages
{
    public partial class Admin : System.Web.UI.MasterPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            List<GroupPermession> lst = GroupPermessionServiceManager.GetAll();
            List<GroupPermession> lst2 = lst.FindAll(x => x.GroupID == int.Parse(Session["group"].ToString()));
            foreach(GroupPermession group in lst2)
                {
                if ( group.ViewYN == true && group.DeleteYN ==true&& group.EditYN ==true &&group.SaveYN ==true )
                {
                    Control list = this.Page.Master.FindControl("side-menu");

                    HtmlGenericControl li = new HtmlGenericControl("li");
                    Nav.Controls.Add(li);
                    
                    HtmlGenericControl anchor = new HtmlGenericControl("a");
                    anchor.Attributes.Add("href", "/Forms/Settings/"+ group.PageName);
                    anchor.InnerText = group.URLPageName;

                    li.Controls.Add(anchor);
                }
            }

        }
    }
}