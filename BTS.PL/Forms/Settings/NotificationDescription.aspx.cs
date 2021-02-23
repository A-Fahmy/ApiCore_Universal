using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Settings
{
    public partial class NotificationDescription : System.Web.UI.Page
    {
        #region Properties
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
        #endregion
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
                    LoadItems();
                }
            }
            catch (Exception exc)
            {

            }
        }


        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Entities.NotificationDescription obj = NotificationDescriptionServiceManager.GetByCode(SelectedItemID.Value);
                txtName.Text = obj.NotificationDescriptionEN;
                txtNameAr.Text = obj.NotificationDescriptionAR;
                //ddlCountries.SelectedValue = obj.CountryCode.ToString();

                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetObject();
                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedItemID = null;
            }
            catch (Exception exc)
            {

            }
        }


        #region Methods
        private void LoadItems()
        {
            List<Entities.NotificationDescription> notificationDescription = NotificationDescriptionServiceManager.GetAll();
            //Get the types
            gvData.DataSource = notificationDescription;
            gvData.DataBind();
        }

        private void SetObject()
        {
            Entities.NotificationDescription SelectedObj = NotificationDescriptionServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.NotificationDescriptionEN = txtName.Text;
            SelectedObj.NotificationDescriptionAR = txtNameAr.Text;
            NotificationDescriptionServiceManager.Update(SelectedObj);
        }

        #endregion

    }
}