using BTS.Entities;
using BTS.Entities.Views;
using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Settings
{
    public partial class Financial : System.Web.UI.Page
    {
        #region Properties
        static List<FinsStatement> lstfinsStatements;
        static List<View_ExpertiseRCL> lstExpertise;
        static List<FinsStatement> Filter_finsStatementsList;
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
        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvData.PageIndex = e.NewPageIndex;
            if (Filter_finsStatementsList == null)
            {
                gvData.DataSource = lstfinsStatements;
                gvData.DataBind();
            }
            else
            {
                gvData.DataSource = Filter_finsStatementsList;
                gvData.DataBind();
            }
        }
        protected void btnExportToExcelSheet_Click(object sender, EventArgs e)
        {
            if (gvData.Rows.Count != 0)
            {
                Response.AddHeader("content-disposition", "attachment;filename=FinancialData.xls");
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
        protected void btnSearch_Click(object obj, EventArgs e)
        {
            decimal n;
            Filter_finsStatementsList = new List<FinsStatement>();
            Filter_finsStatementsList = lstfinsStatements;
            if (txtUserCode.Text != "")
                Filter_finsStatementsList = Filter_finsStatementsList.Where(x => x.UserCode == int.Parse(txtUserCode.Text.Trim())).ToList();
            if (txtRefrenceNumber.Text != "")
                Filter_finsStatementsList = Filter_finsStatementsList.Where(x => x.ReferenceNumber == txtRefrenceNumber.Text.Trim()).ToList();
            if (ddlBookingStatus.SelectedValue != "")
                Filter_finsStatementsList = Filter_finsStatementsList.Where(x => x.PaymentStatus == ddlBookingStatus.SelectedValue).ToList();
            if (ddlBookingStatus.SelectedValue == "PAID" && dtPickerPayment.Value !=null)
                Filter_finsStatementsList = Filter_finsStatementsList.Where(x => Convert.ToDateTime(x.PaymentDate).Date == dtPickerPayment.Value).ToList();
            if (txtAmount.Text != "" && decimal.TryParse(txtAmount.Text.Trim(),out n))
                Filter_finsStatementsList = Filter_finsStatementsList.Where(x => x.Amount == decimal.Parse(txtAmount.Text.Trim())).ToList();

            gvData.DataSource = Filter_finsStatementsList;
            gvData.DataBind();


            if (txtUserCode.Text == "" && ddlBookingStatus.SelectedValue == string.Empty && txtRefrenceNumber.Text=="" && txtAmount.Text == "")
            {
                gvData.DataSource = lstfinsStatements;
                gvData.DataBind();
            }
        }
        protected void btnBooking_details_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Application["Booking_Details"] = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Response.Redirect("/Forms/Settings/Booking.aspx");
            }
            catch (Exception exc)
            {

            }
        }
        protected void ddlBookingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlBookingStatus.SelectedValue == "PAID")
                dtPicker_div.Visible = true;

            else
                dtPicker_div.Visible = false;
        }
        #endregion

        #region Methods                                
        private void LoadItems()
        {
            LoaFinStatmentStatus();
            lstfinsStatements = FinsStatementServiceManager.GetAll();
            lstfinsStatements = lstfinsStatements.Where(x => x.PaymentStatus.Trim() != "PaidTransaction").ToList();
            lstfinsStatements.Reverse();
            gvData.DataSource = lstfinsStatements;
            gvData.DataBind();
        }
        private void LoaFinStatmentStatus()
        {
            List<string> FinStatmentStatus = new List<string>();
            FinStatmentStatus.Add("PAID");
            FinStatmentStatus.Add("UNPAID");
            FinStatmentStatus.Add("Refund");

            ddlBookingStatus.DataSource = FinStatmentStatus;
            ddlBookingStatus.DataBind();
            ddlBookingStatus.Items.Insert(0, new ListItem("-- Select --", string.Empty));
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //  base.VerifyRenderingInServerForm(control);
        }
        #endregion
    }
}