using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Settings
{
    public partial class LookUpGroups : System.Web.UI.Page
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
                    LoadItems();
                }
            }
            catch (Exception exc)
            {

            }
        }
        private void LoadItems()
        {


            //Get the types
            List<Group> lst = GroupServiceManager.GetAll();
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        protected void cbxSelectedItemIsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cbxSelectedItem = (CheckBox)sender;
                int SelectedID = int.Parse(cbxSelectedItem.Attributes["SelectedID"]);

                //Get the selected item
                Group SelectedObj = GroupServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                GroupServiceManager.Update(SelectedObj);
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
                GroupServiceManager.Delete(SelectedItemID);

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
                Group obj = GroupServiceManager.GetByCode(SelectedItemID.Value);
                //txt.Text = obj.Code.ToString();
                ChkIsActive.Enabled = true;
                txtName.Text = obj.GroupsNameEN;
                txtNameAr.Text = obj.GroupsNameAR;
                ChkIsActive.Checked = (bool)obj.IsActive;

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
                    if (!ChkIsActive.Checked)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlertPopUp();", true);
                        return;
                    }

                    SetObject();
                }
                else
                {
                    Group Obj = new Group();
                    Obj.GroupsNameEN = txtName.Text;
                    Obj.GroupsNameAR = txtNameAr.Text;
                    Obj.IsActive = true;
                    GroupServiceManager.Insert(Obj);

                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }
        private void SetObject()
        {
            Group SelectedObj = GroupServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.GroupsNameEN = txtName.Text;
            SelectedObj.GroupsNameAR = txtNameAr.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            GroupServiceManager.Update(SelectedObj);
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }
    }
}