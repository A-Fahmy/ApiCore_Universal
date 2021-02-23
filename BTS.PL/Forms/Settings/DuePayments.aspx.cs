using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;
using BTS.Business;
using System.IO;

namespace BTS.PL.Forms.Settings
{
    public partial class DuePayments : System.Web.UI.Page
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
        static List<View_DuePayment> lst;
        static CheckBox cbxSelectedItem;
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
                  //  LoadItems();
                }
            }
            catch (Exception exc)
            {

            }
        }
        protected void dtBookingDate_Changed(object obj, EventArgs e)
        {
            LoadItems();
        }
        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvData.PageIndex = e.NewPageIndex;
            LoadItems();
        }
        protected void btnExportToExcelSheet_Click(object sender, EventArgs e)
        {
            if (gvData.Rows.Count != 0)
            {
                
                for (int i = 0; i < gvData.Rows.Count; i++)
                {
                    if ((gvData.Rows[i].Cells[5].Controls[3] as CheckBox).Checked)
                    {
                        DuePayment duePayment = new DuePayment();
                        duePayment.BookingCode = lst[i].Code;
                        duePayment.BankBranchCode = lst[i].BankBranchCodeKey;
                        duePayment.ContactCode = lst[i].ContactCode;
                        duePayment.IsSent = true;
                        DuePaymentServiceManager.Insert(duePayment);
                    }

                }

                string date = DateTime.Now.ToString();
                Response.AddHeader("content-disposition", "attachment;filename=DuePaymentsData" + date + ".xls");
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
        protected void cbxMarkAll_CheckedChanged(object obj, EventArgs e)
        {
            if(lst.Count>0)
                for(int i=0;i<lst.Count;i++)
                {
                    lst[i].IsSent = cbxMarkAll.Checked;
                }

            gvData.DataSource = lst;
            gvData.DataBind();
        }
        
        #endregion


        #region Methods
        private void LoadItems()
        {
            lst = DuePaymentBusines.GetAllView(7,7, dtBookingDate.Value.Value);
            if (lst.Count > 0)
                cbxMarkAll.Visible = true;
            else
                cbxMarkAll.Visible = false;
            gvData.DataSource = lst;
            gvData.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //  base.VerifyRenderingInServerForm(control);
        }


        #endregion
    }
}