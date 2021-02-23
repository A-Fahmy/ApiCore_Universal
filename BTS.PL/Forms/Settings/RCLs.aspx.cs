using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;

namespace BTS.PL.Forms.Settings
{
    public partial class RCLs : System.Web.UI.Page
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
                Lookup_RCL SelectedObj = Lookup_RCLServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_RCLServiceManager.Update(SelectedObj);
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
                txtName.Text = txtNameAr.Text = txtDescription.Text = string.Empty;
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
                Lookup_RCLServiceManager.Delete(SelectedItemID);

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
                Lookup_RCL obj = Lookup_RCLServiceManager.GetByCode(SelectedItemID.Value);
                txtName.Text = obj.RCLNameEN;
                txtNameAr.Text = obj.RCLNameAR;
                txtDescription.Text = obj.Description;
                txtYearsOfExperience.Text = obj.YearsOfExperience.ToString();
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
                    Lookup_RCL Obj = new Lookup_RCL();
                    Obj.RCLNameEN = txtName.Text;
                    Obj.RCLNameAR = txtNameAr.Text;
                    Obj.Description = txtDescription.Text;
                    Obj.YearsOfExperience = int.Parse(txtYearsOfExperience.Text);
                    Obj.IsActive = true;
                    Lookup_RCLServiceManager.Insert(Obj);
                    #endregion
                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
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
            //Get the types
            List<Lookup_RCL> lst = Lookup_RCLServiceManager.GetAll();
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        private void SetObject()
        {
            Lookup_RCL SelectedObj = Lookup_RCLServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.RCLNameEN = txtName.Text;
            SelectedObj.RCLNameAR = txtNameAr.Text;
            SelectedObj.Description = txtDescription.Text;
            SelectedObj.YearsOfExperience = int.Parse(txtYearsOfExperience.Text);
            SelectedObj.IsActive = ChkIsActive.Checked;
            Lookup_RCLServiceManager.Update(SelectedObj);
        }



            #endregion
        }
}