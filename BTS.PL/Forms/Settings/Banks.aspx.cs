using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Settings
{
    public partial class Banks : System.Web.UI.Page
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
                Lookup_Banks SelectedObj = Lookup_BanksServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_BanksServiceManager.Update(SelectedObj);
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
                txtName.Text = txtNameAr.Text = ddlCountries.SelectedValue = string.Empty;
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
                Lookup_BanksServiceManager.Delete(SelectedItemID);

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
                Lookup_Banks obj = Lookup_BanksServiceManager.GetByCode(SelectedItemID.Value);
                txtBanKCode.Text = obj.BankCode;
                ChkIsActive.Enabled = true;
                txtName.Text = obj.BankNameEN;
                txtNameAr.Text = obj.BankNameAR;
                ddlCountries.SelectedValue = obj.CountryCode.ToString();
                ChkIsActive.Checked = obj.IsActive;

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
                    Lookup_Banks Obj = new Lookup_Banks();
                    Obj.BankNameEN = txtName.Text;
                    Obj.BankNameAR = txtNameAr.Text;
                    Obj.CountryCode = int.Parse(ddlCountries.SelectedValue);
                    Obj.IsActive = true;
                    Lookup_BanksServiceManager.Insert(Obj);
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
            List<View_KeyValueLookup> lstCountries = Lookup_CountriesServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlCountries.DataSource = lstCountries;
            ddlCountries.DataBind();
            ddlCountries.Items.Insert(0, new ListItem("-- Select --", string.Empty));

            //Get the types
            List<View_LookupBanks> lst = Lookup_BanksServiceManager.GetAllView(CommonSettings.Languages.Arabic);
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        private void SetObject()
        {
            Lookup_Banks SelectedObj = Lookup_BanksServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.BankNameEN = txtName.Text;
            SelectedObj.BankNameAR = txtNameAr.Text;
            SelectedObj.CountryCode = int.Parse(ddlCountries.SelectedValue);
            SelectedObj.IsActive = ChkIsActive.Checked;
            Lookup_BanksServiceManager.Update(SelectedObj);
        }
        #endregion
    }
}