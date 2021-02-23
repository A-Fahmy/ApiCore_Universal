using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Settings
{
    public partial class ExpertiseRCL : System.Web.UI.Page
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

        #region Events
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

        protected void cbxSelectedItemIsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cbxSelectedItem = (CheckBox)sender;
                int SelectedID = int.Parse(cbxSelectedItem.Attributes["SelectedID"]);

                //Get the selected item
                Lookup_ExpertiseRCL SelectedObj = Lookup_ExpertiseRCLServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_ExpertiseRCLServiceManager.Update(SelectedObj);
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedItemID = null;
                ChkIsActive.Checked = true;
                ChkIsActive.Enabled = false;
                ddlExpertises.SelectedValue = ddlRCL.SelectedValue = string.Empty;
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Lookup_ExpertiseRCLServiceManager.Delete(SelectedItemID);

                LoadItems();
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
                Lookup_ExpertiseRCL obj = Lookup_ExpertiseRCLServiceManager.GetByCode(SelectedItemID.Value);
                ddlExpertises.SelectedValue = obj.ExpertiseCode.ToString();
                ddlRCL.SelectedValue = obj.RCLCode.ToString();
                txtCost.Text = obj.Cost.ToString();
                ChkIsActive.Checked = obj.IsActive;
                ChkIsActive.Enabled = true;

                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedItemID.HasValue)
                {
                    #region Edit
                    if (!ChkIsActive.Checked)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlertPopUp();", true);
                        return;
                    }

                    SetObject();
                    #endregion
                }
                else
                {
                    #region Add
                    Lookup_ExpertiseRCL Obj = new Lookup_ExpertiseRCL();
                    Obj.ExpertiseCode = int.Parse(ddlExpertises.SelectedValue);
                    Obj.RCLCode = int.Parse(ddlRCL.SelectedValue);
                    Obj.Cost = decimal.Parse(txtCost.Text);
                    Obj.IsActive = true;
                    Lookup_ExpertiseRCLServiceManager.Insert(Obj);
                    #endregion
                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }
        
        #endregion

        #region Methods
        private void LoadItems()
        {
            ddlExpertises.DataSource = Lookup_ExpertisesServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlExpertises.DataTextField = "Name";
            ddlExpertises.DataValueField = "Code";
            ddlExpertises.DataBind();
            ddlExpertises.Items.Insert(0, new ListItem("-- Select --", ""));

            ddlRCL.DataSource = Lookup_RCLServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlRCL.DataTextField = "Name";
            ddlRCL.DataValueField = "Code";
            ddlRCL.DataBind();
            ddlRCL.Items.Insert(0, new ListItem("-- Select --", ""));

            //Get the types
            List<View_LookupExpertiseRCL> lst = Lookup_ExpertiseRCLServiceManager.GetAllView();
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        private void SetObject()
        {
            Lookup_ExpertiseRCL SelectedObj = Lookup_ExpertiseRCLServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.ExpertiseCode = int.Parse(ddlExpertises.SelectedValue);
            SelectedObj.RCLCode = int.Parse(ddlRCL.SelectedValue);
            SelectedObj.Cost = decimal.Parse(txtCost.Text);
            SelectedObj.IsActive = ChkIsActive.Checked;
            Lookup_ExpertiseRCLServiceManager.Update(SelectedObj);
        }
            #endregion
        }
}