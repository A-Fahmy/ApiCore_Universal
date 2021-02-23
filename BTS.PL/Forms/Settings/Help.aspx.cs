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
   
        public partial class Help : System.Web.UI.Page
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

            protected void btnAddNewItem_Click(object sender, EventArgs e)
            {

                try
                {
                    this.SelectedItemID = null;
                    txtName.Text = txtNameAr.Text = string.Empty;
                    ddlParentHelp.SelectedValue = string.Empty;
                    //ChkIsActive.Checked = true;
                    //ChkIsActive.Enabled = false;
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
                   // ChkIsActive.Enabled = true;
                    this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                    Lookup_Help obj = Lookup_HelpServiceManager.GetByCode(SelectedItemID.Value);
                txtName.Text = obj.HelpTitleNameEN;
                    txtNameAr.Text = obj.HelpTitleNameAR;
                   // ChkIsActive.Checked = obj.IsActive;
                    if (obj.ParentHelpCode.HasValue)
                    ddlParentHelp.SelectedValue = obj.ParentHelpCode.Value.ToString();
                    else
                    ddlParentHelp.SelectedValue = string.Empty;

                ChkIsDescription.Checked = obj.AddDescriptionYN;
                txtNameArHTML.Text = obj.DescriptionsAR;
                txtNameHTML.Text = obj.DescriptionsEN;
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
                        Lookup_Help Obj = new Lookup_Help();
                        Obj.HelpTitleNameEN = txtName.Text;
                        Obj.HelpTitleNameAR = txtNameAr.Text;
                        if (ddlParentHelp.SelectedValue != string.Empty)
                            Obj.ParentHelpCode = int.Parse(ddlParentHelp.SelectedValue);
                        else
                            Obj.ParentHelpCode = null;
                       
                    Obj.AddDescriptionYN = ChkIsDescription.Checked;
                    if (ChkIsDescription.Checked == true)
                    {
                        Obj.DescriptionsAR = txtNameArHTML.Xhtml.Trim() ;
                        Obj.DescriptionsEN = txtNameHTML.Xhtml.Trim(); 
                    }
                    else
                    {
                        Obj.DescriptionsAR = string.Empty;
                        Obj.DescriptionsEN = string.Empty;
                    }
                        Obj.IsActive = true;
                        Lookup_HelpServiceManager.Insert(Obj);
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
            private void LoadItems()
            {
            ddlParentHelp.DataSource = Lookup_HelpServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlParentHelp.DataTextField = "Name";
            ddlParentHelp.DataValueField = "Code";
            ddlParentHelp.DataBind();
            ddlParentHelp.Items.Insert(0, new ListItem("-- Select --", ""));

                //Get the types
                List<Lookup_Help> lst = Lookup_HelpServiceManager.GetAll();
                gvData.DataSource = lst;
                gvData.DataBind();
            }
            private void SetObject()
            {
            Lookup_Help SelectedObj = Lookup_HelpServiceManager.GetByCode(this.SelectedItemID.Value);
                SelectedObj.HelpTitleNameAR = txtName.Text;
                SelectedObj.HelpTitleNameEN = txtNameAr.Text;
                SelectedObj.IsActive = ChkIsActive.Checked;
                if (ddlParentHelp.SelectedValue != string.Empty)
                    SelectedObj.ParentHelpCode = int.Parse(ddlParentHelp.SelectedValue);
                else
                    SelectedObj.ParentHelpCode = null;
            SelectedObj.AddDescriptionYN = ChkIsDescription.Checked;
            if (ChkIsDescription.Checked == true)
            {
                SelectedObj.DescriptionsAR = txtNameArHTML.Xhtml.Trim();
                SelectedObj.DescriptionsEN = txtNameHTML.Xhtml.Trim();
            }
            else
            {
                SelectedObj.DescriptionsAR = string.Empty;
                SelectedObj.DescriptionsEN = string.Empty;
            }
            Lookup_HelpServiceManager.Update(SelectedObj);
            }

        }
    }
