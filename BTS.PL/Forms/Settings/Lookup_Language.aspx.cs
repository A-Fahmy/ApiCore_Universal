using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Settings
{
    public partial class Lookup_Language : System.Web.UI.Page
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
            List<BTS.Entities.Lookup_Language> lst = Lookup_LanguageServiceManager.GetAll();
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
                BTS.Entities.Lookup_Language SelectedObj = Lookup_LanguageServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_LanguageServiceManager.Update(SelectedObj);
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
                Lookup_LanguageServiceManager.Delete(SelectedItemID);

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
                BTS.Entities.Lookup_Language obj = Lookup_LanguageServiceManager.GetByCode(SelectedItemID.Value);
                //txt.Text = obj.Code.ToString();
                ChkIsActive.Enabled = true;
                txtName.Text = obj.LanguageEnName;
                txtNameAr.Text = obj.LanguageAraName;
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
                    BTS.Entities.Lookup_Language Obj = new BTS.Entities.Lookup_Language();
                    Obj.LanguageEnName = txtName.Text;
                    Obj.LanguageAraName = txtNameAr.Text;
                    Obj.IsActive = true;
                    Lookup_LanguageServiceManager.Insert(Obj);

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
            BTS.Entities.Lookup_Language SelectedObj = Lookup_LanguageServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.LanguageEnName = txtName.Text;
            SelectedObj.LanguageAraName = txtNameAr.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            Lookup_LanguageServiceManager.Update(SelectedObj);
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }
    }
}