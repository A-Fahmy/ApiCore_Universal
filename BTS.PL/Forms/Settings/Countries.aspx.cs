using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Business;

namespace BTS.PL.Forms.Settings
{
    public partial class Countries : System.Web.UI.Page
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
                Lookup_Countries SelectedObj = Lookup_CountriesServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                Lookup_CountriesServiceManager.Update(SelectedObj);
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
                txtName.Text = txtNameAr.Text 
                    = txtCurrencyName.Text = txtCurrencyNameAr.Text 
                    = txtCurrencyISOCode.Text = txtCurrencyExchangeRateToEGP.Text 
                    = txtInternationalKey.Text = string.Empty;
                ChkIsActive.Checked = true;
                ChkIsActive.Enabled = false;
                ChkIsRegional.Checked = false;
                ChkIsRegional.Enabled = true;
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
                ChkIsRegional.Enabled = true;
                ChkIsActive.Enabled = true;
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Lookup_Countries obj = Lookup_CountriesServiceManager.GetByCode(SelectedItemID.Value);
                txtName.Text = obj.CountryNameEn;
                txtNameAr.Text = obj.CountryNameAr;
                txtCurrencyName.Text = obj.CurrencyNameEn;
                txtCurrencyNameAr.Text = obj.CurrencyNameAr;
                txtCurrencyISOCode.Text = obj.CurrencyISOCode;
                txtCurrencyExchangeRateToEGP.Text = obj.ExchangeRateToEGP.ToString();
                txtInternationalKey.Text = obj.KeyInternational.ToString();
                ChkIsActive.Checked = obj.IsActive;
                ChkIsRegional.Checked = (bool)obj.RegionalYN;
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
                //Get the selected item
                Lookup_Countries SelectedObj = Lookup_CountriesServiceManager.GetByCode(SelectedItemID);
                SelectedObj.IsActive = false;
                Lookup_CountriesServiceManager.Update(SelectedObj);
                
                LoadItems();
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
                    //Lookup_CountriesServiceManager.Update(SelectedObj);
                    #endregion
                }
                else
                {
                    #region Add
                    Lookup_Countries Obj = new Lookup_Countries();
                    Obj.CountryNameEn = txtName.Text;
                    Obj.CountryNameAr = txtNameAr.Text;
                    Obj.CurrencyNameEn = txtCurrencyName.Text;
                    Obj.CurrencyNameAr = txtCurrencyNameAr.Text;
                    Obj.CurrencyISOCode = txtCurrencyISOCode.Text;
                    Obj.ExchangeRateToEGP = decimal.Parse(txtCurrencyExchangeRateToEGP.Text);
                    Obj.KeyInternational = "(" + txtInternationalKey.Text + ")";
                    Obj.Photo = null; //fuImage.FileBytes;
                    Obj.IsActive = true;
                    Obj.RegionalYN = ChkIsRegional.Checked;
                    Lookup_CountriesServiceManager.Insert(Obj);
                    #endregion
                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }
       

        protected void btnViewImage_Click(object sender, ImageClickEventArgs e)
        {

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
            List<Lookup_Countries> lst = Lookup_CountriesServiceManager.GetAll();
            gvData.DataSource = lst;
            gvData.DataBind();
        }

        private void SetObject()
        {
            Lookup_Countries SelectedObj; SelectedObj = Lookup_CountriesServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.CountryNameEn = txtName.Text;
            SelectedObj.CountryNameAr = txtNameAr.Text;
            SelectedObj.CurrencyNameEn = txtCurrencyName.Text;
            SelectedObj.CurrencyNameAr = txtCurrencyNameAr.Text;
            SelectedObj.CurrencyISOCode = txtCurrencyISOCode.Text;
            SelectedObj.ExchangeRateToEGP = decimal.Parse(txtCurrencyExchangeRateToEGP.Text);
            SelectedObj.KeyInternational = "(" + txtInternationalKey.Text + ")";
            SelectedObj.IsActive = ChkIsActive.Checked;
            SelectedObj.RegionalYN = ChkIsRegional.Checked;
            SelectedObj.Photo = null; //fuImage.FileBytes;
            Lookup_CountriesServiceManager.Update(SelectedObj);

        }

        #endregion

    }
}