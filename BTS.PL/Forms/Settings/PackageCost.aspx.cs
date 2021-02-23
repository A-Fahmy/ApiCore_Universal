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
    public partial class PackageCost : System.Web.UI.Page
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
            List<Package> lst = PackageServiceManager.GetAll();
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                PackageServiceManager.Delete(SelectedItemID);

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
               Package obj = PackageServiceManager.GetByCode(SelectedItemID.Value);
                //txt.Text = obj.Code.ToString();
                txtType.Text = obj.PackageType;
                txtName.Text = obj.PackageName;
                txtCost.Text = obj.Cost.ToString();
                txtCounter.Text = obj.Count.ToString();

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
                    //if (!ChkIsActive.Checked)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlertPopUp();", true);
                    //    return;
                    //}

                    SetObject();
                }
                else
                {
                    Package Obj = new Package();
                    Obj.PackageType = txtType.Text;
                    Obj.PackageName = txtName.Text;
                    Obj.Cost =Int32.Parse( txtCost.Text);
                    Obj.Count = int.Parse(txtCounter.Text);
                    PackageServiceManager.Insert(Obj);

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
            Package SelectedObj = PackageServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.PackageType = txtType.Text;
            SelectedObj.PackageName = txtName.Text;
            SelectedObj.Cost = decimal.Parse(txtCost.Text);
            SelectedObj.Count = int.Parse(txtCounter.Text);
            PackageServiceManager.Update(SelectedObj);
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }
    }
}