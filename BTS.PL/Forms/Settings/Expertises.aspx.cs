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
    public partial class Expertises : System.Web.UI.Page
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
                Lookup_Expertises SelectedObj = Lookup_ExpertisesServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_ExpertisesServiceManager.Update(SelectedObj);
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
                txtName.Text = txtNameAr.Text = string.Empty;
                ddlParentExpertises.SelectedValue = string.Empty;
                ChkIsActive.Checked = true;
                ChkIsActive.Enabled = false;
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
                Lookup_ExpertisesServiceManager.Delete(SelectedItemID);

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
                ChkIsActive.Enabled = true;
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Lookup_Expertises obj = Lookup_ExpertisesServiceManager.GetByCode(SelectedItemID.Value);
                txtName.Text = obj.ExpertiseNameEN;
                txtNameAr.Text = obj.ExpertiseNameAR;
                ChkIsActive.Checked = obj.IsActive;
                if (obj.ParentExpertiseCode.HasValue)
                    ddlParentExpertises.SelectedValue = obj.ParentExpertiseCode.Value.ToString();
                else
                    ddlParentExpertises.SelectedValue = string.Empty;

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
                    Lookup_Expertises Obj = new Lookup_Expertises();
                    Obj.ExpertiseNameEN = txtName.Text;
                    Obj.ExpertiseNameAR = txtNameAr.Text;
                    if (ddlParentExpertises.SelectedValue != string.Empty)
                        Obj.ParentExpertiseCode = int.Parse(ddlParentExpertises.SelectedValue);
                    else
                        Obj.ParentExpertiseCode = null;
                    Obj.ExpertiseDescription = string.Empty;
                    Obj.Photo = null;
                    Obj.IsActive = true;
                    Lookup_ExpertisesServiceManager.Insert(Obj);
                    #endregion
                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnImage_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

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
        #endregion

        #region Methods
        private void LoadItems()
        {
            ddlParentExpertises.DataSource = Lookup_ExpertisesServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlParentExpertises.DataTextField = "Name";
            ddlParentExpertises.DataValueField = "Code";
            ddlParentExpertises.DataBind();
            ddlParentExpertises.Items.Insert(0, new ListItem("-- Select --", ""));

            //Get the types
            List<View_LookupExperties> lst = Lookup_ExpertisesServiceManager.GetAllView(CommonSettings.Languages.Arabic);
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        private void SetObject()
        {
            Lookup_Expertises SelectedObj = Lookup_ExpertisesServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.ExpertiseNameEN = txtName.Text;
            SelectedObj.ExpertiseNameAR = txtNameAr.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            if (ddlParentExpertises.SelectedValue != string.Empty)
                SelectedObj.ParentExpertiseCode = int.Parse(ddlParentExpertises.SelectedValue);
            else
                SelectedObj.ParentExpertiseCode = null;
            Lookup_ExpertisesServiceManager.Update(SelectedObj);
        }
            #endregion
        }
}