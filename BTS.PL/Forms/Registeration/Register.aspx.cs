using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Registeration
{
    public partial class Register : System.Web.UI.Page
    {
        #region Properties
        private bool IsConsultant
        {
            get
            {
                return bool.Parse(ViewState["IsConsultant"].ToString());
            }
            set
            {
                ViewState["IsConsultant"] = value;
            }
        }
        private bool IsUser
        {
            get
            {
                return bool.Parse(ViewState["IsUser"].ToString());
            }
            set
            {
                ViewState["IsUser"] = value;
            }
        }
        private bool IsBoth
        {
            get
            {
                return bool.Parse(ViewState["IsBoth"].ToString());
            }
            set
            {
                ViewState["IsBoth"] = value;
            }
        }
        private int Step
        {
            get
            {
                return int.Parse(ViewState["Step"].ToString());
            }
            set
            {
                ViewState["Step"] = value;
            }
        }
        private DataTable DtCountries
        {
            get
            {
                if (ViewState["DtCountries"] == null)
                {
                    DataTable Dt = new DataTable();
                    Dt.Columns.Add("CountryCode", typeof(int));
                    Dt.Columns.Add("CountryName", typeof(string));
                    Dt.Columns.Add("IsPrimary", typeof(bool));
                    ViewState["DtCountries"] = Dt;
                    return Dt;
                }
                else
                {
                    return (DataTable)ViewState["DtCountries"];
                }
            }
            set
            {
                ViewState["DtCountries"] = value;
            }
        }
        private DataTable DtExpertiseRCL
        {
            get
            {
                if (ViewState["DtExpertiseRCL"] == null)
                {
                    DataTable Dt = new DataTable();
                    Dt.Columns.Add("Code", typeof(int));
                    Dt.Columns.Add("MainExpertiseName", typeof(string));
                    Dt.Columns.Add("ChildExpertiseName", typeof(string));
                    Dt.Columns.Add("RCLName", typeof(string));
                    Dt.Columns.Add("Cost", typeof(decimal));
                    ViewState["DtExpertiseRCL"] = Dt;
                    return Dt;
                }
                else
                {
                    return (DataTable)ViewState["DtExpertiseRCL"];
                }
            }
            set
            {
                ViewState["DtExpertiseRCL"] = value;
            }
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadItems();

                this.Step = 0;
            }
        }

        #region Registeration type
        protected void cbxlstRegisterationTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxlstRegisterationTypes.Items[0].Selected == true
                    || cbxlstRegisterationTypes.Items[1].Selected == true)
                    btnRegisterationTypes_Next.Enabled = true;
                else
                    btnRegisterationTypes_Next.Enabled = false;
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnRegisterationTypes_Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxlstRegisterationTypes.Items[0].Selected == true
                    && cbxlstRegisterationTypes.Items[1].Selected == true)
                {
                    this.IsBoth = true;
                    this.IsConsultant = this.IsUser = true;
                }
                else if (cbxlstRegisterationTypes.Items[0].Selected == true)
                {
                    this.IsConsultant = true;
                    this.IsUser = this.IsBoth = false;
                }
                else
                {
                    this.IsUser = true;
                    this.IsConsultant = this.IsBoth = false;
                }

                this.Step = 1;

                UpdateFormView();
            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region Personal info

        protected void ddlPersonal_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPersonalProvinces();
            }
            catch (Exception exc)
            {

            }
        }
        protected void ddlPersonal_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPersonalCities();
            }
            catch (Exception exc)
            {

            }
        }

        protected void ddlPersonal_CompanyCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPersonalCompanyProvinces();
            }
            catch (Exception exc)
            {

            }
        }
        protected void ddlPersonal_CompanyProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPersonalCompanyCities();
            }
            catch (Exception exc)
            {

            }
        }
        protected void ddlPersonal_BankCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPersonalBanks();
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnPersonal_Next_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.IsConsultant || this.IsBoth)
                {
                    PnlMainRegisterationInfo.Visible = false;
                    PnlPersonalInfo.Visible = false;
                    PnlCountries.Visible = true;
                    PnlExpertiseRCLInfo.Visible = false;
                }
                else
                {
                    SavePersonalInfo();
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnPersonal_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtPersonal_Email.Text = txtPersonal_FirstName.Text = txtPersonal_SecondName.Text = txtPersonal_ThirdName.Text = string.Empty;
            }
            catch (Exception exc)
            {

            }
        }

        #endregion

        #region Countries
        protected void btnAddAvailableCountry_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow dr in this.DtCountries.Rows)
                {
                    if (dr["CountryCode"].ToString() == ddlAvailableCountries.SelectedValue)
                        return;
                }

                if (this.DtCountries.Rows.Count == 0)
                    this.DtCountries.Rows.Add(ddlAvailableCountries.SelectedValue, ddlAvailableCountries.SelectedItem.Text, true);
                else
                    this.DtCountries.Rows.Add(ddlAvailableCountries.SelectedValue, ddlAvailableCountries.SelectedItem.Text, false);

                btnCountry_Next.Enabled = true;

                gvAvailableCountries.DataSource = this.DtCountries;
                gvAvailableCountries.DataBind();
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

                if (cbxSelectedItem.Checked)
                {
                    #region Reset mandatory country
                    foreach (DataRow dr in this.DtCountries.Rows)
                    {
                        dr["IsPrimary"] = false;
                    }
                    #endregion

                    #region Update the new mandatory country
                    foreach (DataRow dr in this.DtCountries.Rows)
                    {
                        if (dr["CountryCode"].ToString() == SelectedID.ToString())
                        {
                            dr["IsPrimary"] = true;
                            break;
                        }
                    }
                    #endregion

                    gvAvailableCountries.DataSource = this.DtCountries;
                    gvAvailableCountries.DataBind();
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnDelete_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                int SelectedID = int.Parse(imgbtn.Attributes["SelectedID"]);

                foreach (DataRow dr in this.DtCountries.Rows)
                {
                    if (dr["CountryCode"].ToString() == SelectedID.ToString())
                    {
                        dr.Delete();
                        break;
                    }
                }

                if (this.DtCountries.Rows.Count == 0)
                    btnCountry_Next.Enabled = false;

                gvAvailableCountries.DataSource = this.DtCountries;
                gvAvailableCountries.DataBind();
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnCountry_Back_Click(object sender, EventArgs e)
        {
            try
            {
                PnlMainRegisterationInfo.Visible = false;
                PnlPersonalInfo.Visible = true;
                PnlCountries.Visible = false;
                PnlExpertiseRCLInfo.Visible = false;
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnCountry_Next_Click(object sender, EventArgs e)
        {
            try
            {
                PnlMainRegisterationInfo.Visible = false;
                PnlPersonalInfo.Visible = false;
                PnlCountries.Visible = false;
                PnlExpertiseRCLInfo.Visible = true;
            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #region Expertise RCL

        protected void ddlExpertises_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadChildExpertise();
            }
            catch (Exception exc)
            {

            }
        }

        protected void ddlExpertises_Child_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadChildExpertiseRCL();
            }
            catch (Exception exc)
            {

            }
        }

        protected void ddlRCL_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ExpertiseRCLCode = int.Parse(ddlRCL.SelectedValue);
                Lookup_ExpertiseRCL Obj = Lookup_ExpertiseRCLServiceManager.GetByCode(ExpertiseRCLCode);
                lblExpertiseRCLCost.Text = Obj.Cost.ToString();
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnAddExpertise_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    foreach (DataRow dr in this.DtExpertiseRCL.Rows)
                    {
                        if (dr["Code"].ToString() == ddlRCL.SelectedValue)
                            return;
                    }

                    this.DtExpertiseRCL.Rows.Add(int.Parse(ddlRCL.SelectedValue), ddlExpertises_Main.SelectedItem.Text, ddlExpertises_Child.SelectedItem.Text, ddlRCL.SelectedItem.Text, decimal.Parse(lblExpertiseRCLCost.Text));

                    btnExpertise_Save.Enabled = true;

                    gvExpertiseRCL.DataSource = this.DtExpertiseRCL;
                    gvExpertiseRCL.DataBind();
                }
                catch (Exception exc)
                {

                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnDeleteExpertiseRCL_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                int SelectedID = int.Parse(imgbtn.Attributes["SelectedID"]);

                foreach (DataRow dr in this.DtExpertiseRCL.Rows)
                {
                    if (dr["Code"].ToString() == SelectedID.ToString())
                    {
                        dr.Delete();
                        break;
                    }
                }

                if (this.DtExpertiseRCL.Rows.Count == 0)
                    btnExpertise_Save.Enabled = false;

                gvExpertiseRCL.DataSource = this.DtExpertiseRCL;
                gvExpertiseRCL.DataBind();
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnExpertise_Back_Click(object sender, EventArgs e)
        {
            try
            {
                PnlMainRegisterationInfo.Visible = false;
                PnlPersonalInfo.Visible = false;
                PnlCountries.Visible = true;
                PnlExpertiseRCLInfo.Visible = false;
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnExpertise_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //Save the personal info
                int ContactCode = SavePersonalInfo();

                #region Save the available countries
                foreach (DataRow dr in this.DtCountries.Rows)
                {
                    Contact_CountriesServiceManager.Insert(
                        new Contact_Countries()
                        {
                            ContactCode = ContactCode,
                            CountryCode = int.Parse(dr["CountryCode"].ToString()),
                            IsPrimaryCountry = bool.Parse(dr["IsPrimary"].ToString())
                        });
                }
                #endregion

                #region Save the expertise RCL
                foreach (DataRow dr in this.DtExpertiseRCL.Rows)
                {
                    Contact_ExpertiseServiceManager.Insert(
                        new Contact_Expertise()
                        {
                            ContactCode = ContactCode,
                            ExpertiseRCLCode = int.Parse(dr["Code"].ToString()),
                            IsActive = true
                        });
                }
                #endregion
            }
            catch (Exception exc)
            {

            }
        }
        #endregion

        #endregion

        #region Methods
        private void UpdateFormView()
        {
            if (this.Step == 1)
            {
                if (this.IsConsultant || this.IsBoth)
                {
                    btnPersonal_Next.Text = "Next";
                    divBankCode.Visible = divBankCodeValue.Visible
                        = divBankCountry.Visible = divBankCountryValue.Visible
                        = divBankAccountNO.Visible = divBankAccountNOValue.Visible = true;
                }
                else
                {
                    btnPersonal_Next.Text = "Save";
                    divBankCode.Visible = divBankCodeValue.Visible
                        = divBankCountry.Visible = divBankCountryValue.Visible
                        = divBankAccountNO.Visible = divBankAccountNOValue.Visible = false;
                }

                PnlMainRegisterationInfo.Visible = false;
                PnlPersonalInfo.Visible = true;
                PnlCountries.Visible = false;
                PnlExpertiseRCLInfo.Visible = false;
            }
            else if (this.Step == 2)
            {
                PnlMainRegisterationInfo.Visible = false;
                PnlPersonalInfo.Visible = false;
                PnlCountries.Visible = true;
                PnlExpertiseRCLInfo.Visible = false;
            }
            else if (this.Step == 3)
            {
                PnlMainRegisterationInfo.Visible = false;
                PnlPersonalInfo.Visible = false;
                PnlCountries.Visible = false;
                PnlExpertiseRCLInfo.Visible = true;
            }
        }

        private int SavePersonalInfo()
        {
            Contact ContactObj = new Contact();
            ContactObj.ContactKeyEmail = txtPersonal_Email.Text;
            ContactObj.FirstName = txtPersonal_FirstName.Text;
            ContactObj.MiddleName = txtPersonal_SecondName.Text;
            ContactObj.LastName = txtPersonal_ThirdName.Text;
            ContactObj.Address = txtPersonal_Address.Text;
            ContactObj.Area = txtPersonal_Area.Text;
            ContactObj.CompanyAddress = txtPersonal_CompanyAddress.Text;
            ContactObj.CompanyArea = txtPersonal_CompanyArea.Text;
            ContactObj.CompanyName = txtPersonal_CompanyName.Text;
            ContactObj.MoblieNo = txtPersonal_MobileNO.Text;
            ContactObj.NationalID = txtPersonal_NationalID.Text;
            ContactObj.PhoneNo = txtPersonal_PhoneNO.Text;
            ContactObj.Password = txtPersonal_Password.Text;

            if (txtPersonal_Birthdate.Text != string.Empty)
                ContactObj.BirthDate = DateTime.Parse(txtPersonal_Birthdate.Text);
            if (ddlPersonal_City.SelectedValue != string.Empty)
                ContactObj.CityCode = int.Parse(ddlPersonal_City.SelectedValue);
            if (ddlPersonal_CompanyCity.SelectedValue != string.Empty)
                ContactObj.CompanyCityCode = int.Parse(ddlPersonal_CompanyCity.SelectedValue);

            ContactObj.IsSuspended = false;
            ContactObj.OTPCode = "4892";
            if (this.IsConsultant || this.IsBoth)
            {
                ContactObj.BankAccountNo = txtPersonal_BankAccountNO.Text;
                if (ddlPersonal_Bank.SelectedValue != string.Empty)
                    ContactObj.BankCode = int.Parse(ddlPersonal_Bank.SelectedValue);
                ContactObj.RCC = true;

            }
            else if (this.IsUser)
            {
                ContactObj.RUC = true;
            }
            else
            {

            }

            return ContactServiceManager.Insert(ContactObj);
        }

        private void LoadItems()
        {
            List<View_KeyValueLookup> lst = Lookup_CountriesServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlPersonal_Country.DataSource = lst;
            ddlPersonal_Country.DataTextField = "Name";
            ddlPersonal_Country.DataValueField = "Code";
            ddlPersonal_Country.DataBind();
            ddlPersonal_Country.Items.Insert(0, new ListItem("-- Select --", ""));

            LoadPersonalProvinces();

            ddlAvailableCountries.DataSource = lst;
            ddlAvailableCountries.DataTextField = "Name";
            ddlAvailableCountries.DataValueField = "Code";
            ddlAvailableCountries.DataBind();
            ddlAvailableCountries.Items.Insert(0, new ListItem("-- Select --", ""));

            ddlPersonal_BankCountry.DataSource = lst;
            ddlPersonal_BankCountry.DataTextField = "Name";
            ddlPersonal_BankCountry.DataValueField = "Code";
            ddlPersonal_BankCountry.DataBind();
            ddlPersonal_BankCountry.Items.Insert(0, new ListItem("-- Select --", ""));

            LoadPersonalBanks();

            ddlPersonal_CompanyCountry.DataSource = lst;
            ddlPersonal_CompanyCountry.DataTextField = "Name";
            ddlPersonal_CompanyCountry.DataValueField = "Code";
            ddlPersonal_CompanyCountry.DataBind();
            ddlPersonal_CompanyCountry.Items.Insert(0, new ListItem("-- Select --", ""));

            LoadPersonalCompanyProvinces();

            lst = Lookup_ExpertisesServiceManager.GetRootKeyValueList(CommonSettings.Languages.Arabic);
            ddlExpertises_Main.DataSource = lst;
            ddlExpertises_Main.DataTextField = "Name";
            ddlExpertises_Main.DataValueField = "Code";
            ddlExpertises_Main.DataBind();
            ddlExpertises_Main.Items.Insert(0, new ListItem("-- Select --", ""));

            LoadChildExpertise();
        }

        private void LoadPersonalBanks()
        {
            if (ddlPersonal_BankCountry.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lst = Lookup_BanksServiceManager.GetKeyValueListByCountryCode(int.Parse(ddlPersonal_BankCountry.SelectedValue), CommonSettings.Languages.Arabic);
                ddlPersonal_Bank.DataSource = lst;
            }
            else
            {
                ddlPersonal_Bank.DataSource = null;
            }

            ddlPersonal_Bank.DataTextField = "Name";
            ddlPersonal_Bank.DataValueField = "Code";
            ddlPersonal_Bank.DataBind();
            ddlPersonal_Bank.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void LoadPersonalProvinces()
        {
            if (ddlPersonal_Country.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lst = Lookup_ProvincesServiceManager.GetKeyValueListByCountryCode(int.Parse(ddlPersonal_Country.SelectedValue), CommonSettings.Languages.Arabic);
                ddlPersonal_Province.DataSource = lst;
            }
            else
            {
                ddlPersonal_Province.DataSource = null;
            }

            ddlPersonal_Province.DataTextField = "Name";
            ddlPersonal_Province.DataValueField = "Code";
            ddlPersonal_Province.DataBind();
            ddlPersonal_Province.Items.Insert(0, new ListItem("-- Select --", ""));

            LoadPersonalCities();
        }
        private void LoadPersonalCities()
        {
            if (ddlPersonal_Province.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lst = Lookup_CitiesServiceManager.GetKeyValueListByProvinceCode(int.Parse(ddlPersonal_Province.SelectedValue), CommonSettings.Languages.Arabic);
                ddlPersonal_City.DataSource = lst;
            }
            else
            {
                ddlPersonal_City.DataSource = null;
            }

            ddlPersonal_City.DataTextField = "Name";
            ddlPersonal_City.DataValueField = "Code";
            ddlPersonal_City.DataBind();
            ddlPersonal_City.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void LoadPersonalCompanyProvinces()
        {
            if (ddlPersonal_CompanyCountry.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lst = Lookup_ProvincesServiceManager.GetKeyValueListByCountryCode(int.Parse(ddlPersonal_CompanyCountry.SelectedValue), CommonSettings.Languages.Arabic);
                ddlPersonal_CompanyProvince.DataSource = lst;
            }
            else
            {
                ddlPersonal_CompanyProvince.DataSource = null;
            }

            ddlPersonal_CompanyProvince.DataTextField = "Name";
            ddlPersonal_CompanyProvince.DataValueField = "Code";
            ddlPersonal_CompanyProvince.DataBind();
            ddlPersonal_CompanyProvince.Items.Insert(0, new ListItem("-- Select --", ""));

            LoadPersonalCompanyCities();
        }
        private void LoadPersonalCompanyCities()
        {
            if (ddlPersonal_CompanyProvince.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lst = Lookup_CitiesServiceManager.GetKeyValueListByProvinceCode(int.Parse(ddlPersonal_CompanyProvince.SelectedValue), CommonSettings.Languages.Arabic);
                ddlPersonal_CompanyCity.DataSource = lst;
            }
            else
            {
                ddlPersonal_CompanyCity.DataSource = null;
            }

            ddlPersonal_CompanyCity.DataTextField = "Name";
            ddlPersonal_CompanyCity.DataValueField = "Code";
            ddlPersonal_CompanyCity.DataBind();
            ddlPersonal_CompanyCity.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void LoadChildExpertise()
        {
            ddlExpertises_Child.Items.Clear();

            if (ddlExpertises_Main.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lst = Lookup_ExpertisesServiceManager.GetKeyValueListByParentCode(int.Parse(ddlExpertises_Main.SelectedValue), CommonSettings.Languages.Arabic);
                ddlExpertises_Child.DataSource = lst;
            }
            else
            {
                ddlExpertises_Child.DataSource = null;
            }

            ddlExpertises_Child.DataTextField = "Name";
            ddlExpertises_Child.DataValueField = "Code";
            ddlExpertises_Child.DataBind();
            ddlExpertises_Child.Items.Insert(0, new ListItem("-- Select --", ""));

            LoadChildExpertiseRCL();
        }

        private void LoadChildExpertiseRCL()
        {
            ddlRCL.Items.Clear();

            if (ddlExpertises_Child.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lst = Lookup_ExpertiseRCLServiceManager.GetRCLKeyValueListByExpertise(int.Parse(ddlExpertises_Child.SelectedValue));
                ddlRCL.DataSource = lst;
            }
            else
            {
                ddlRCL.DataSource = null;
            }

            ddlRCL.DataTextField = "Name";
            ddlRCL.DataValueField = "Code";
            ddlRCL.DataBind();
            ddlRCL.Items.Insert(0, new ListItem("-- Select --", ""));
        }
        #endregion


    }
}