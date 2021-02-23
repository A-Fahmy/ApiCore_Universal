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
    public partial class Cities : System.Web.UI.Page
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

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCountryProvinces();

               ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
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
                Lookup_Cities SelectedObj = Lookup_CitiesServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_CitiesServiceManager.Update(SelectedObj);
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
                txtName.Text = txtNameAr.Text = ddlCountries.SelectedValue = ddlProvinces.SelectedValue = string.Empty;
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
            //try
            //{
                int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Lookup_CitiesServiceManager.Delete(5);

                LoadItems();
            //}
            //catch (Exception exc)
            //{

            //}
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ChkIsActive.Enabled = true;
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Lookup_Cities obj = Lookup_CitiesServiceManager.GetByCode(SelectedItemID.Value);
                txtName.Text = obj.CityNameEn;
                txtNameAr.Text = obj.CityNameAr;

                Lookup_Provinces ObjProvince = Lookup_ProvincesServiceManager.GetByCode(obj.ProvinceCode);
                ddlCountries.SelectedValue = ObjProvince.CountryCode.ToString();
                LoadCountryProvinces();
                ddlProvinces.SelectedValue = ObjProvince.Code.ToString();
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
                    Lookup_Cities Obj = new Lookup_Cities();
                    Obj.CityNameEn = txtName.Text;
                    Obj.CityNameAr = txtNameAr.Text;
                    Obj.ProvinceCode = int.Parse(ddlProvinces.SelectedValue);
                    Obj.IsActive = true;
                    Lookup_CitiesServiceManager.Insert(Obj);
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

            LoadCountryProvinces();

            //Get the types
            List<View_LookupCities> lst = Lookup_CitiesServiceManager.GetAllView(CommonSettings.Languages.Arabic);
            gvData.DataSource = lst;
            gvData.DataBind();
        }

        private void LoadCountryProvinces()
        {
            if (ddlCountries.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lstProvinces = Lookup_ProvincesServiceManager.GetKeyValueListByCountryCode(int.Parse(ddlCountries.SelectedValue), CommonSettings.Languages.Arabic);
                ddlProvinces.DataSource = lstProvinces;
            }
            else
            {
                ddlProvinces.DataSource = null;
            }

            ddlProvinces.DataBind();
            ddlProvinces.Items.Insert(0, new ListItem("-- Select --", string.Empty));
        }
        private void SetObject()
        {
            Lookup_Cities SelectedObj = Lookup_CitiesServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.CityNameEn = txtName.Text;
            SelectedObj.CityNameAr = txtNameAr.Text;
            SelectedObj.ProvinceCode = int.Parse(ddlProvinces.SelectedValue);
            SelectedObj.IsActive = ChkIsActive.Checked;
            Lookup_CitiesServiceManager.Update(SelectedObj);

        }
            #endregion
        }
}