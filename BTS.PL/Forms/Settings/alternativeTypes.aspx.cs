using BTS.Entities;
using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Settings
{
    public partial class alternativeTypes : System.Web.UI.Page
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
            List<alternativeType> lst = alternativeTypeServiceManager.GetAll();
            gvData.DataSource = lst;
            gvData.DataBind();
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

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                alternativeType obj = alternativeTypeServiceManager.GetByCode(SelectedItemID.Value);
                //txtalternativeTypeCode.Text = obj.Code.ToString();
                ChkIsActive.Enabled = true;
                txtName.Text = obj.alternativeNameEn;
                txtNameAr.Text = obj.alternativeNameAr;
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
                    alternativeType Obj = new alternativeType();
                    Obj.alternativeNameEn = txtName.Text;
                    Obj.alternativeNameAr = txtNameAr.Text;
                    Obj.IsActive = true;
                    alternativeTypeServiceManager.Insert(Obj);

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
            alternativeType SelectedObj = alternativeTypeServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.alternativeNameEn = txtName.Text;
            SelectedObj.alternativeNameAr = txtNameAr.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            alternativeTypeServiceManager.Update(SelectedObj);
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                alternativeTypeServiceManager.Delete(SelectedItemID);

                LoadItems();
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
                alternativeType SelectedObj = alternativeTypeServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                alternativeTypeServiceManager.Update(SelectedObj);
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
    }
}