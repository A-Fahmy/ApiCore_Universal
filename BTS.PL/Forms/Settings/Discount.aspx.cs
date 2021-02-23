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
    public partial class Discount : System.Web.UI.Page
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
                Entities.Discount SelectedObj = DiscountServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                DiscountServiceManager.Update(SelectedObj);
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
                ChkIsActive.Enabled = true;
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Entities.Discount obj = DiscountServiceManager.GetByCode(SelectedItemID.Value);
                txtDiscountDuration.Text = obj.DurationInHr.ToString();
                txtDiscountPercentage.Text = obj.Percentage.ToString();
                txtDescription.Text = obj.Description.ToString();
                ChkIsActive.Checked = obj.IsActive.Value;

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
                    List<Entities.Discount> lstDicount = DiscountServiceManager.GetAll();
                    Entities.Discount Obj = new Entities.Discount();
                    Obj.DurationInHr = int.Parse(txtDiscountDuration.Text);
                    Obj.Percentage = int.Parse(txtDiscountPercentage.Text);
                    Obj.Description = txtDescription.Text; ;
                    Obj.IsActive = true;

                    if (lstDicount.Any(x => x.DurationInHr == Obj.DurationInHr))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "ShowitemModalPopUpAlert();", true);
                        return;
                    }
                    else
                    DiscountServiceManager.Insert(Obj);
                    #endregion
                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }


        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
  
            int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
            DiscountServiceManager.Delete(5);

            LoadItems();
          
        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }
        #endregion



        #region methods

        private void LoadItems()
        {
            List<Entities.Discount> lstDicount = DiscountServiceManager.GetAll();
            gvData.DataSource = lstDicount;
            gvData.DataBind();
        }


        private void SetObject()
        {
            Entities.Discount SelectedObj = DiscountServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.DurationInHr = int.Parse(txtDiscountDuration.Text);
            SelectedObj.Percentage = int.Parse(txtDiscountPercentage.Text);
            SelectedObj.Description = txtDescription.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            DiscountServiceManager.Update(SelectedObj);

        }

        #endregion
    }
}