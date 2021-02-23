using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;


namespace BTS.PL.Forms.Settings
{
    public partial class BankBranch : System.Web.UI.Page
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
                txtName.Text = txtNameAr.Text = ddlBanks.SelectedValue = string.Empty;
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
                Lookup_BankBranch obj = Lookup_BankBranchServiceManager.GetByCode(SelectedItemID.Value);
                txtBranchCode.Text = obj.BranchCode;
                ChkIsActive.Enabled = true;
                txtName.Text = obj.BankBranchNameEN;
                txtNameAr.Text = obj.BankBranchNameAR;
                ddlBanks.SelectedValue = obj.BankCode.ToString();
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
                    Lookup_BankBranch Obj = new Lookup_BankBranch();
                    Obj.BranchCode = txtBranchCode.Text;
                    Obj.BankBranchNameEN = txtName.Text;
                    Obj.BankBranchNameAR = txtNameAr.Text;
                    Obj.BankCode = int.Parse(ddlBanks.SelectedValue);
                    Obj.IsActive = true;
                    Lookup_BankBranchServiceManager.Insert(Obj);
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
            List<Lookup_Banks> lstBanks = Lookup_BanksServiceManager.GetAll();
            ddlBanks.DataSource = lstBanks;
            ddlBanks.DataBind();
            ddlBanks.Items.Insert(0, new ListItem("-- Select --", string.Empty));

            //Get the types
            List<View_LookupBankBranch> lst = Lookup_BankBranchServiceManager.GetAllView();
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        private void SetObject()
        {
            Lookup_BankBranch SelectedObj = Lookup_BankBranchServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.BranchCode = txtBranchCode.Text;
            SelectedObj.BankBranchNameEN = txtName.Text;
            SelectedObj.BankBranchNameAR = txtNameAr.Text;
            SelectedObj.BankCode = int.Parse(ddlBanks.SelectedValue);
            SelectedObj.IsActive = ChkIsActive.Checked;
            Lookup_BankBranchServiceManager.Update(SelectedObj);
        }
        #endregion
    }
}