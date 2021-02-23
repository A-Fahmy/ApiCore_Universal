using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;

namespace BTS.PL.Forms.Settings
{
    public partial class GroupPermission : System.Web.UI.Page
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
            List<View_KeyValueLookup> lstGroup = GroupServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlGroup.DataSource = lstGroup;
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, new ListItem("-- Select --", string.Empty));
            ddlGroup.SelectedValue = "1";
            //Get the types
            LoadGroupProvinces(1);
        }
        
        private void LoadGroupProvinces(int GroupID)
        {
            List<GroupPermession> lst = GroupPermessionServiceManager.GetAll();
            List<GroupPermession> lst2 = lst.FindAll(x => x.GroupID == GroupID);
            gvData.DataSource = lst2;
            gvData.DataBind();
        }
        protected void cbxSelectedItemAllIsView_CheckedChanged(object sender , EventArgs e)
        {
            if (cbxSelectedItemAllIsView.Checked == true)
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox View = (CheckBox)row.FindControl("cbxSelectedItemIsView");
                    View.Checked = true;

                }

            }
            else
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox View = (CheckBox)row.FindControl("cbxSelectedItemIsView");
                    View.Checked = false;

                }
            }
        }
        protected void cbxSelectedItemAllIsSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSelectedItemAllIsSave.Checked == true)
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox Save = (CheckBox)row.FindControl("cbxSelectedItemIsSave");
                    Save.Checked = true;

                }

            }
            else
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox Save = (CheckBox)row.FindControl("cbxSelectedItemIsSave");
                    Save.Checked = false;

                }
            }
        }
        protected void cbxSelectedItemAllIsEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSelectedItemAllIsEdit.Checked == true)
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox Edit = (CheckBox)row.FindControl("cbxSelectedItemIsEdit");
                    Edit.Checked = true;

                }

            }
            else
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox Edit = (CheckBox)row.FindControl("cbxSelectedItemIsEdit");
                    Edit.Checked = false;

                }
            }
        }
        protected void cbxSelectedItemAllIsDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSelectedItemAllIsDelete.Checked == true)
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox Delete = (CheckBox)row.FindControl("cbxSelectedItemIsDelete");
                    Delete.Checked = true;

                }

            }
            else
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox Delete = (CheckBox)row.FindControl("cbxSelectedItemIsDelete");
                    Delete.Checked = false;

                }
            }
        }
        protected void ddlGroupPermissionView(object sender, EventArgs e)
        {
            try
            {
                int GroupID = int.Parse(ddlGroup.SelectedValue.ToString());
                LoadGroupProvinces(GroupID);

                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.SelectedItemID = int.Parse(((Button)sender).Attributes["SelectedID"]);
            int index = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow selectedRow = gvData.Rows[index];

            CheckBox View = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsView");
            CheckBox Save = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsSave");
            CheckBox Edit = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsEdit");
            CheckBox Delete = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsDelete");
            if (View.Checked == true && Save.Checked == true && Edit.Checked == true && Delete.Checked == true)
            {
                View.Checked = false;
                Save.Checked = false;
                Edit.Checked = false;
                Delete.Checked = false;
            }
            else {
                View.Checked = true;
                Save.Checked = true;
                Edit.Checked = true;
                Delete.Checked = true;
            }

        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gvData.SelectedRow.RowIndex;
            GridViewRow selectedRow = gvData.Rows[index];

            CheckBox View = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsView");
            CheckBox Save = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsSave");
            CheckBox Edit = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsEdit");
            CheckBox Delete = (CheckBox)selectedRow.FindControl("cbxSelectedItemIsDelete");

            if (View.Checked == Save.Checked == Edit.Checked == Delete.Checked == true)
            {
                View.Checked = false;
                Save.Checked = false;
                Edit.Checked = false;
                Delete.Checked = false;
            }
            else
            {
                View.Checked = true;
                Save.Checked = true;
                Edit.Checked = true;
                Delete.Checked = true;
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            GroupPermession Obj = new GroupPermession();

            try
            {
                if (!this.SelectedItemID.HasValue)
                {


                    LoadItems();
                }
                else
                {
                    foreach (GridViewRow row in gvData.Rows)
                    {
                        CheckBox View = (CheckBox)row.FindControl("cbxSelectedItemIsView");
                        CheckBox Save = (CheckBox)row.FindControl("cbxSelectedItemIsSave");
                        CheckBox Edit = (CheckBox)row.FindControl("cbxSelectedItemIsEdit");
                        CheckBox Delete = (CheckBox)row.FindControl("cbxSelectedItemIsDelete");
                        Obj.PageName = row.Cells[1].Text.ToString();
                        Obj.DeleteYN = Delete.Checked;
                        Obj.EditYN = Edit.Checked;
                        Obj.SaveYN = Save.Checked;
                        Obj.Code = int.Parse(row.Cells[0].Text.ToString());
                        Obj.URLPageName = row.Cells[2].Text.ToString();
                        Obj.ViewYN = View.Checked;
                        Obj.GroupID = int.Parse(ddlGroup.SelectedValue);

                        GroupPermessionServiceManager.Update(Obj);




                    }
                    Response.Write("<script>alert('Updated') </script>");
                    //Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void cbxSelectedItemAllIsSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSelectedItemAllIsSelected.Checked == true)
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox View = (CheckBox)row.FindControl("cbxSelectedItemIsView");
                    CheckBox Save = (CheckBox)row.FindControl("cbxSelectedItemIsSave");
                    CheckBox Edit = (CheckBox)row.FindControl("cbxSelectedItemIsEdit");
                    CheckBox Delete = (CheckBox)row.FindControl("cbxSelectedItemIsDelete");
                    View.Checked = true;
                    Save.Checked = true;
                    Edit.Checked = true;
                    Delete.Checked = true;
                    cbxSelectedItemAllIsDelete.Checked = true;
                    cbxSelectedItemAllIsView.Checked = true;
                    cbxSelectedItemAllIsSave.Checked = true;
                    cbxSelectedItemAllIsEdit.Checked = true;
                }

            }
            else
            {
                foreach (GridViewRow row in gvData.Rows)
                {
                    CheckBox View = (CheckBox)row.FindControl("cbxSelectedItemIsView");
                    CheckBox Save = (CheckBox)row.FindControl("cbxSelectedItemIsSave");
                    CheckBox Edit = (CheckBox)row.FindControl("cbxSelectedItemIsEdit");
                    CheckBox Delete = (CheckBox)row.FindControl("cbxSelectedItemIsDelete");
                    View.Checked = false;
                    Save.Checked = false;
                    Edit.Checked = false;
                    Delete.Checked = false;
                    cbxSelectedItemAllIsDelete.Checked = false;
                    cbxSelectedItemAllIsView.Checked = false;
                    cbxSelectedItemAllIsSave.Checked = false;
                    cbxSelectedItemAllIsEdit.Checked = false;

                }
            }
           
            }
        }
}