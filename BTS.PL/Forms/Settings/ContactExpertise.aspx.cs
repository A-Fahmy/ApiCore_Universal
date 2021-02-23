using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;

using BTS.Entities.Views;
using BTS.ServiceManager;

namespace BTS.PL.Forms.Settings
{
    public partial class ContactExpertise : System.Web.UI.Page
    {
        #region Properties
        static List<View_Contact_Expertise> lstContactExpertise;
        static List<View_ExpertiseRCL> lstExpertise;
        static View_Contact_Expertise SelectedObj=new View_Contact_Expertise();
        static CheckBox cbxSelectedItem;
        static int ContactCode;
        static int ExpertiseRCLCode;
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
        protected void ddlContactExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlContactExpertise.SelectedValue != string.Empty)
                {
                    btnAddNewItem.Enabled = true;
                }
                else
                {
                    btnAddNewItem.Enabled = false;
                }
                  LoadContact_Expertise();
            }
            catch (Exception exc)
            {

            }
        }
        protected void ddlExpertise_SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                LoadRCL_Expertise();
            }
            catch (Exception exc)
            {

            }
        }
        protected void ddlRCL_SelectedIndexChange(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
        }
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
             ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnExportToExcelSheet_Click(object sender, EventArgs e)
        {
            if (gvData.Rows.Count != 0)
            {
                Response.AddHeader("content-disposition", "attachment;filename=ContactExpertiseData.xls");
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    //gvData.AllowPaging = true;
                    gvData.AllowPaging = false;
                    LoadItems();
                    gvData.RenderControl(hw);
                    Response.Output.Write(sw);
                    Response.Flush();
                    Response.Clear();
                    Response.End();
                }
            }
        }
        protected void cbxSelectedItemIsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlertPopUp();", true);

                 cbxSelectedItem = (CheckBox)sender;
                int SelectedID = int.Parse(cbxSelectedItem.Attributes["SelectedID"]);

                //Get the selected item
                SelectedObj = lstContactExpertise.Where(x => x.Code == SelectedID).ToList().FirstOrDefault();
            }
            catch (Exception exc)
            {

            }
        }
        protected void Yes_Click(object sender, EventArgs e)
        {
            Contact_Expertise contactExpertise = new Contact_Expertise();
            contactExpertise.Code = SelectedObj.Code;
            contactExpertise.ContactCode = SelectedObj.ContactCode;
            contactExpertise.EntriyRootExpertise = SelectedObj.EntriyRootExpertise;
            contactExpertise.ExpertiseRCLCode = SelectedObj.ExpertiseRCLCode;
            contactExpertise.IsActive = cbxSelectedItem.Checked;
            Contact_ExpertiseServiceManager.Update(contactExpertise);
        }
        protected void No_Click(object sender, EventArgs e)
        {
            //cbxSelectedItem.Checked = SelectedObj.IsActive;
            //foreach (GridViewRow row in gvData.Rows)
            //{
            //    CheckBox cbx = (CheckBox)row.FindControl("cbxSelectedItemIsActive");
            //    if (cbx != null)
            //    {
            //        cbx.Checked = SelectedObj.IsActive;
            //    }
            //}
            //GridViewRow row = gvData.SelectedRow;
            //CheckBox cbx = (CheckBox)row.FindControl("cbxSelectedItemIsActive");
            //cbx.Checked = SelectedObj.IsActive;
            // int ID = int.Parse(gvData.Rows[gvData.SelectedIndex].Cells[3].Text);
            // cbxSelectedItemIsActive_CheckedChanged(null, null);

            GridViewRow row = ((GridViewRow)(cbxSelectedItem).NamingContainer);
            int index = row.RowIndex;
            CheckBox cb1 = (CheckBox)gvData.Rows[index].FindControl("cbxSelectedItemIsActive");
            cb1.Checked = SelectedObj.IsActive;
        }
            protected void btnSave_Click(object sender, EventArgs e)
        {
            //Insert New Contact Expertise
            Contact_Expertise NewContactExpertise = new Contact_Expertise();
            NewContactExpertise.ContactCode = ContactCode;
            NewContactExpertise.ExpertiseRCLCode = ExpertiseRCLCode;
            NewContactExpertise.IsActive = true;
            NewContactExpertise.EntriyRootExpertise = 3;
            Contact_ExpertiseServiceManager.Insert(NewContactExpertise);
            LoadItems();
        }

        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvData.PageIndex = e.NewPageIndex;
            LoadItems();
        }
        #endregion
        #region Methods
        private void LoadItems()
        {
            lstContactExpertise = Contact_ExpertiseServiceManager.GetAllExpertiseLevelForAllContacts();
            List<string> lstContacts = lstContactExpertise.Select(x => x.Username).Distinct().ToList();
           // lstContactExpertise.Reverse();
            gvData.DataSource = lstContactExpertise;
            gvData.DataBind();
            // Fill Contacts DropDown List
            ddlContactExpertise.DataSource = lstContacts;
            ddlContactExpertise.DataBind();
            ddlContactExpertise.Items.Insert(0, new ListItem("-- Select --", string.Empty));

            //Fill Expertise DropDown List
            var List = Lookup_ExpertiseRCLServiceManager.GetAllExpertiseRCL();
            var List2 = List.GroupBy(x => x.ExpertiseNameEN, (key, group) => new { ExpertiseNameEN = key, List = group.ToList() }).ToList();
            lstExpertise = new List<View_ExpertiseRCL>();
            foreach (var Item in List2)
            {
                lstExpertise.Add(Item.List[0]);
            }
            List<string> lstExpertiseName = lstExpertise.Select(x => x.ExpertiseNameEN).Distinct().ToList();
            ddlExpertise.DataSource = lstExpertise;
            ddlExpertise.DataBind();
            ddlExpertise.Items.Insert(0, new ListItem("-- Select --", string.Empty));
          //  ddlRCL.Items.Insert(0, new ListItem("-- Select --", string.Empty));
        }
        private void LoadContact_Expertise()
        {
            if (ddlContactExpertise.SelectedValue != string.Empty)
            {
                // For Insert New Contact Expertise
                View_Contact_Expertise ObjContact = new View_Contact_Expertise();
                ObjContact = lstContactExpertise.Where(x => x.Username == ddlContactExpertise.SelectedValue).FirstOrDefault();
                ContactCode = ObjContact.ContactCode;

                List<View_Contact_Expertise> FilteredContact = lstContactExpertise.Where(x => x.Username == ddlContactExpertise.SelectedValue).ToList();
                gvData.DataSource = FilteredContact;
                gvData.DataBind();
            }
            else
            {
                gvData.DataSource = lstContactExpertise;
                gvData.DataBind();
            }
        }
        private void LoadRCL_Expertise()
        {
            if (ddlExpertise.SelectedValue != string.Empty)
            {
                List<View_KeyValueLookup> lstRCL = Lookup_ExpertiseRCLServiceManager.GetRCLKeyValueListByExpertise(int.Parse(ddlExpertise.SelectedValue));
                ddlRCL.DataSource = lstRCL;
                // For Insert New Contact Expertise
                View_KeyValueLookup ObjExpertiseRCL = new View_KeyValueLookup();
                ObjExpertiseRCL = lstRCL.FirstOrDefault();
                ExpertiseRCLCode = ObjExpertiseRCL.Code;
            }
            else
            {
                ddlRCL.DataSource = null;
            }
            ddlRCL.DataBind();
            ddlRCL.Items.Insert(0, new ListItem("-- Select --", string.Empty));
            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
          //  base.VerifyRenderingInServerForm(control);
        }
        #endregion
    }
}