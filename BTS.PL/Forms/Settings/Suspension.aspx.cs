using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Settings
{
    public partial class Suspension : System.Web.UI.Page
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
                Entities.Suspension obj = SuspensionServiceManager.GetByCode(SelectedItemID.Value);
                txtRejectionCount.Text = obj.RejectionCount.ToString();
                txtTotalCount.Text = obj.TotalCount.ToString();
                ChkIsActive.Checked = (bool)obj.IsActive;
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
                if (!ChkIsActive.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlertPopUp();", true);
                    return;
                }
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


        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }

        #region Methods
        private void LoadItems()
        {
            List<Entities.Suspension> notificationDescription = SuspensionServiceManager.GetAll();
            //Get the types
            gvData.DataSource = notificationDescription;
            gvData.DataBind();
        }

        private void SetObject()
        {
            Entities.Suspension SelectedObj = SuspensionServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.RejectionCount = int.Parse(txtRejectionCount.Text);
            SelectedObj.TotalCount = int.Parse(txtTotalCount.Text);
            SelectedObj.IsActive = ChkIsActive.Checked;
            SuspensionServiceManager.Update(SelectedObj);
        }

        #endregion
    }
}