using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Settings
{
    public partial class File_Types : System.Web.UI.Page
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
            List<Lookup_FileTypes> lst = Lookup_FileTypesServiceManager.GetAll();
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
                Lookup_FileTypes SelectedObj = Lookup_FileTypesServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_FileTypesServiceManager.Update(SelectedObj);
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
                Lookup_FileTypesServiceManager.Delete(SelectedItemID);

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
                Lookup_FileTypes obj = Lookup_FileTypesServiceManager.GetByCode(SelectedItemID.Value);
                txtFileTypeCode.Text = obj.Code.ToString();
                ChkIsActive.Enabled = true;
                txtName.Text = obj.FileTypeNameEN;
                txtNameAr.Text = obj.FileTypeNameAR;
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
                    Lookup_FileTypes Obj = new Lookup_FileTypes();
                    Obj.FileTypeNameEN = txtName.Text;
                    Obj.FileTypeNameAR = txtNameAr.Text;
                    Obj.IsActive = true;
                    Lookup_FileTypesServiceManager.Insert(Obj);
                    
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
            Lookup_FileTypes SelectedObj = Lookup_FileTypesServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.FileTypeNameEN = txtName.Text;
            SelectedObj.FileTypeNameAR = txtNameAr.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            Lookup_FileTypesServiceManager.Update(SelectedObj);
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }
    }
}