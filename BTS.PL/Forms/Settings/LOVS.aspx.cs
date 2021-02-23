using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BTS.Entities;
using BTS.ServiceManager;
using System.Web.UI.WebControls.WebParts;
using BTS.Business;
using System.Text.RegularExpressions;
using FreeTextBoxControls;

namespace BTS.PL.Forms.Settings
{
    public partial class LOVS : System.Web.UI.Page
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
                    LoadLOV_Type();
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
                LOV SelectedObj = LOVServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                LOVServiceManager.Update(SelectedObj);
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                HelpDiv1.Visible = false;
                HelpDiv2.Visible = false;
                HelpDiv3.Visible = false;
                HelpDiv4.Visible = false;

                if (ddlLOV_Type.SelectedItem.Text == "PlaceInterView")
                {
                    txtNameHTML.Visible = false;
                    txtNameArHTML.Visible = false;
                    txtName.Visible = true;
                    txtNameAr.Visible = true;
                }

                else
                {
                    txtNameHTML.Text = "";
                    txtNameArHTML.Text = "";
                    txtNameHTML.Visible = true;
                    txtNameArHTML.Visible = true;
                    txtName.Visible = false;
                    txtNameAr.Visible = false;

                    if (ddlLOV_Type.SelectedItem.Text == "Help")
                    {
                        HelpDiv1.Visible = true;
                        HelpDiv2.Visible = true;
                        HelpDiv3.Visible = true;
                        HelpDiv4.Visible = true;
                    }

                }

                this.SelectedItemID = null;
                //txtName.Text = txtNameAr.Text
                //    = txtLOVType.Text = string.Empty;
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
                HelpDiv1.Visible = false;
                HelpDiv2.Visible = false;
                HelpDiv3.Visible = false;
                HelpDiv4.Visible = false;
                ChkIsActive.Enabled = true;
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                LOV obj = LOVServiceManager.GetByCode(SelectedItemID.Value);
                if (obj.LOVType == "RSPA5"
                    || obj.LOVType == "RSPA6" || obj.LOVType == "RSPA7"
                    || obj.LOVType == "Disclaimer" || obj.LOVType == "Help")
                {
                    txtNameHTML.Text = obj.DescriptionsEN;
                    txtNameArHTML.Text = obj.DescriptionsAR;
                    txtName.Visible = false;
                    txtNameAr.Visible = false;
                    txtNameArHTML.Visible = true;
                    txtNameHTML.Visible = true;


                    if (obj.LOVType == "Help")
                    {
                        txtTitleEN.Text = obj.TitleEN ;
                        txtTitleAR.Text = obj.TitleAR ;
                        HelpDiv1.Visible = true;
                        HelpDiv2.Visible = true;
                        HelpDiv3.Visible = true;
                        HelpDiv4.Visible = true;

                    }
                }
                else
                {
                    txtName.Text = obj.DescriptionsEN;
                    txtNameAr.Text = obj.DescriptionsAR;
                    txtNameHTML.Visible = false;
                    txtNameArHTML.Visible = false;

                    txtName.Visible = true;
                    txtNameAr.Visible = true;
                }
                //txtLOVType.Text = obj.LOVType;
                ChkIsActive.Checked = obj.IsActive.Value;
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
                LOV SelectedObj = LOVServiceManager.GetByCode(SelectedItemID);
                SelectedObj.IsActive = false;
                LOVServiceManager.Update(SelectedObj);

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
                    LOV Obj = new LOV();
                    if(txtNameHTML.Visible==false || txtNameArHTML.Visible==false)
                    {
                        Obj.DescriptionsEN = txtName.Text;
                        Obj.DescriptionsAR = txtNameAr.Text;
                    }
                    else
                    {
                        Obj.DescriptionsEN = txtNameHTML.Xhtml.Trim();
                        Obj.DescriptionsAR = txtNameArHTML.Xhtml.Trim();

                        if (ddlLOV_Type.SelectedItem.Text == "Help")
                        {
                            Obj.TitleEN = txtTitleEN.Text;
                            Obj.TitleAR = txtTitleAR.Text;

                        }

                    }
                    Obj.LOVType = ddlLOV_Type.SelectedItem.Text;
                    Obj.IsActive = true;
                    LOVServiceManager.Insert(Obj);
                    #endregion
                }

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }

        protected void ddlLov_SelectedIdexChanged(object sender, EventArgs e)
        {
            //List<LOV> lst = LOVServiceManager.GetAll();
            //List<LOV> lstNew = new List<LOV>();
            //if (lst.Count > 0)
            //    lstNew = lst.Where(x => x.LOVType == ddlLOV_Type.SelectedItem.Text).ToList();
            //foreach (var item in lstNew)
            //{
            //    item.DescriptionsEN = HtmlToPlainText(item.DescriptionsEN);
            //    item.DescriptionsAR = HtmlToPlainText(item.DescriptionsAR);
            //}
            //gvData.DataSource = lstNew;
            //gvData.DataBind();

              LoadItems();

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
            List<LOV> lst = LOVServiceManager.GetAll();
            List<LOV> lstNew = new List<LOV>();
            if (lst.Count>0)
             lstNew = lst.Where(x => x.LOVType == ddlLOV_Type.SelectedItem.Text).ToList();
            
            foreach (var item in lstNew)
            {
                item.DescriptionsEN = HtmlToPlainText(item.DescriptionsEN);
                item.DescriptionsAR = HtmlToPlainText(item.DescriptionsAR);
            }
            gvData.DataSource = lstNew;
            gvData.DataBind();

            if (gvData.Rows.Count > 0 && (ddlLOV_Type.SelectedItem.Text == "RSPA5" ||
               ddlLOV_Type.SelectedItem.Text == "RSPA6" || ddlLOV_Type.SelectedItem.Text == "RSPA7" || ddlLOV_Type.SelectedItem.Text == "Disclaimer"))
            {
                btnAddNewItem.Enabled = false;
            }
            else
                btnAddNewItem.Enabled = true;
        }

        private void SetObject()
        {
            LOV SelectedObj; SelectedObj = LOVServiceManager.GetByCode(this.SelectedItemID.Value);
            if (SelectedObj.LOVType == "RSPA5"
                   || SelectedObj.LOVType == "RSPA6" || SelectedObj.LOVType == "RSPA7"|| SelectedObj.LOVType == "Disclaimer"|| SelectedObj.LOVType == "Help")
            {
                SelectedObj.DescriptionsEN = txtNameHTML.Xhtml.Trim();
                SelectedObj.DescriptionsAR = txtNameArHTML.Xhtml.Trim();
                if (ddlLOV_Type.SelectedItem.Text == "Help")
                {
                    SelectedObj.TitleEN = txtTitleEN.Text;
                    SelectedObj.TitleAR = txtTitleAR.Text;

                }

            }
            else
            {
                SelectedObj.DescriptionsEN = txtName.Text;
                SelectedObj.DescriptionsAR = txtName.Text;
            }
            SelectedObj.LOVType = ddlLOV_Type.SelectedItem.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            LOVServiceManager.Update(SelectedObj);
        }
        private static string HtmlToPlainText(string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }

        private void LoadLOV_Type()
        {
            LOV lov = new LOV();
            IEnumerable<string> LOV_Type = LOVServiceManager.GetAll().Select(x => x.LOVType).ToList().Distinct();
            ddlLOV_Type.DataSource=LOV_Type;
            ddlLOV_Type.DataBind();
        }


        #endregion
    }
}