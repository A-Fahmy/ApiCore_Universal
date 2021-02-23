using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Settings
{
    public partial class OpenCv : System.Web.UI.Page
    {
        private int? SelectedItemID
        {
            set { ViewState["SelectedItemID"] = value; }
            get
            {
                if (ViewState["SelectedItemID"] == null)
                    return null;
                else
                    return int.Parse(ViewState["SelectedItemID"].ToString());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    if (Session["LoggedUsers"] == null)
                    {
                        Response.Redirect("/Forms/Registeration/Login.aspx");
                        return;
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                //ViewContactCV cv = Contact_CVServiceManager.GetByContactCode(1029);
                //cv  = Contact_CVServiceManager.GetByContactCode(1045);
                //field1.Text = cv.Field_1;
                //field1.Text = cv.Field_1;
                //field2.Text = cv.Field_2;
                //field10.Text = cv.Field_10;
                //field3.Text = cv.Field_3;
                //field4.Text = cv.Field_4;
                //field5.Text = cv.Field_5;
                //field6.Text = cv.Field_6;
                //field7.Text = cv.Field_7;
                //field8.Text = cv.Field_8;
                //field9.Text = cv.Field_9;
                field1.Text = "Text";
                field2.Text = "Texxxxxx";
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedItemID = null;
            }
            catch (Exception exc)
            {

            }
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Label11.Text = "Another";
            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm1();", true);

        }
    }
}