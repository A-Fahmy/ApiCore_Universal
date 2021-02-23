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
    public partial class PackagesInfo : System.Web.UI.Page
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
            List<PackageInfo> lst = PackageInfoServiceManager.GetAll();
            gvData.DataSource = lst;
            gvData.DataBind();
            btnAddNewItem.Visible = false;
        }
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedItemID = null;
                txtName.Text = txtNameAr.Text = string.Empty;
                txtLink1.Text = txtLink2.Text = string.Empty;
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
                PackageInfo obj = PackageInfoServiceManager.GetByCode(SelectedItemID.Value);
                //txt.Text = obj.Code.ToString();
                ChkIsActive.Enabled = true;
                txtName.Text = obj.DescriptionEN;
                txtNameAr.Text = obj.DescriptionAR;
                ChkIsActive.Checked = (bool)obj.IsActive;
                txtLink1.Text = obj.Link1;
                txtLink2.Text = obj.Link2;
                ddlPackageType.SelectedValue = obj.PackageType.ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
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
                    PackageInfo Obj = new PackageInfo();
                    Obj.DescriptionEN = txtName.Text;
                    Obj.DescriptionAR = txtNameAr.Text;
                    Obj.Link1 = txtLink1.Text;
                    Obj.Link2 = txtLink2.Text;
                    Obj.PackageType = int.Parse(ddlPackageType.SelectedValue);
                    Obj.IsActive = true;
                    PackageInfoServiceManager.Insert(Obj);

                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
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
        private void SetObject()
        {
            PackageInfo SelectedObj = PackageInfoServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.DescriptionEN = txtName.Text;
            SelectedObj.DescriptionAR = txtNameAr.Text;
            SelectedObj.Link1 = txtLink1.Text;
            SelectedObj.Link2 = txtLink2.Text;
            SelectedObj.PackageType = int.Parse(ddlPackageType.SelectedValue);
            SelectedObj.IsActive = ChkIsActive.Checked;
            PackageInfoServiceManager.Update(SelectedObj);
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }
    }
}