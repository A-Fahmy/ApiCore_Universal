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
    public partial class Booking : System.Web.UI.Page
    {
        #region Properties

        static List<View_Book_All> BookingList;
        static List<View_ExpertiseRCL> lstExpertise;
        static List<View_Book_All> Filter_BookingList;
        static List<Lookup_Cities> lstCity;
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
            if (Filter_BookingList == null)
            {
                gvData.DataSource = BookingList;
                gvData.DataBind();
            }
            else
            {
                gvData.DataSource = Filter_BookingList;
                gvData.DataBind();
            }
        }
        protected void btnExportToExcelSheet_Click(object sender, EventArgs e)
        {
            if (gvData.Rows.Count != 0)
            {
                Response.AddHeader("content-disposition", "attachment;filename=BookingData.xls");
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
            Filter_BookingList = new List<View_Book_All>();
            Filter_BookingList = BookingList;
            if (txtRCC.Text !="")
                Filter_BookingList = Filter_BookingList.Where(x => x.RCCContactCode == int.Parse(txtRCC.Text.Trim())).ToList();
            if (txtRUC.Text !="")
                Filter_BookingList = Filter_BookingList.Where(x => x.RUCContactCode == int.Parse(txtRUC.Text.Trim())).ToList();
            if (ddlExpertise.SelectedValue != string.Empty)
                Filter_BookingList = Filter_BookingList.Where(x => x.ExpertiseCode == int.Parse(ddlExpertise.SelectedValue)).ToList();
            if (ddlRCL.SelectedValue != string.Empty)
                Filter_BookingList = Filter_BookingList.Where(x => x.RCLCode >= int.Parse(ddlRCL.SelectedValue)).ToList();
            if (dtPickerFrom.Value != null)
                Filter_BookingList = Filter_BookingList.Where(x => x.BookDate >= dtPickerFrom.Value).ToList();
            if (dtPickerTo.Value != null)
                Filter_BookingList = Filter_BookingList.Where(x => x.BookDate <= dtPickerTo.Value).ToList();
            if (ddlBookingStatus.SelectedValue != string.Empty)
                Filter_BookingList = Filter_BookingList.Where(x => x.BookStatus.Trim() == ddlBookingStatus.SelectedValue).ToList();
            if (ddlCity.SelectedValue != string.Empty)
                Filter_BookingList = Filter_BookingList.Where(x => x.Address.Contains(lstCity.Where(y=>y.Code==int.Parse(ddlCity.SelectedValue)).Select(y=>y.CityNameEn).FirstOrDefault()) || x.Address.Contains(lstCity.Where(y => y.Code == int.Parse(ddlCity.SelectedValue)).Select(y => y.CityNameAr).FirstOrDefault())).ToList();

            gvData.DataSource = Filter_BookingList;
            gvData.DataBind();


            if (txtRCC.Text == "" && txtRUC.Text == "" && ddlExpertise.SelectedValue == string.Empty && ddlRCL.SelectedValue != string.Empty && ddlCity.SelectedValue!= string.Empty)
            {
                gvData.DataSource = BookingList;
                gvData.DataBind();
            }
        }

        protected void ddlExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRCL_Expertise();

            }
            catch (Exception exc)
            {

            }
        }

        #endregion

        public void aa()
        {   
            //var geocoder = new Geocoder("AIzaSyCDRDaDCIOXZnQvCpOKyUAg5LjMt0hN2_Q");
            //var address = geocoder.ReverseGeocode(new LatLng(30.0518868, 31.3368591));

            //ReverseGeocoder geocode = new ReverseGeocoder();
            //Console.WriteLine(geocode.GetNearestPlaceName(30.0518868,31.3368591));
        }


        #region Methods

        private void LoadItems()
        {
           //aa();
           // this.ClientScript.RegisterStartupScript(this.GetType(), "GetAddress", "GetAddress();", true);
            var List = Lookup_ExpertiseRCLServiceManager.GetAllExpertiseRCL();
            var List2 = List.GroupBy(x => x.ExpertiseNameEN, (key, group) => new { ExpertiseNameEN = key, List = group.ToList() } ).ToList();
            lstExpertise = new List<View_ExpertiseRCL>();
            foreach (var Item in List2)
            { 
                lstExpertise.Add(Item.List[0]);
                
            }

            List<string> lstExpertiseName = lstExpertise.Select(x => x.ExpertiseNameEN).Distinct().ToList();
            ddlExpertise.DataSource = lstExpertise;
            ddlExpertise.DataBind();
            ddlExpertise.Items.Insert(0, new ListItem("-- Select --", string.Empty));

            LoadRCL_Expertise();
            LoadBookingStatus();
            LoadCities();
            BookingList = Booking_ServiceManager.GetAllBookingPortal();
            if (Application["Booking_Details"] != null)
            {
                BookingList = BookingList.Where(x => x.BookCode == int.Parse(Application["Booking_Details"].ToString())).ToList();
                Application["Booking_Details"] = null;
            }
            BookingList.Reverse();
            gvData.DataSource = BookingList;
            gvData.DataBind();
        }


        private void LoadRCL_Expertise()
        {

            if (ddlExpertise.SelectedValue != string.Empty)
            {
               // int ExpertiseCode = lstExpertise.Where(x => x.ExpertiseNameEN == ddlExpertise.SelectedValue).Select(x => x.ExpertiseCode).FirstOrDefault();
                List<View_KeyValueLookup> lstRCL = Lookup_ExpertiseRCLServiceManager.GetRCLKeyValueListByExpertise(int.Parse(ddlExpertise.SelectedValue));
                ddlRCL.DataSource = lstRCL;
            }
            else
            {
                ddlRCL.DataSource = null;
            }

            ddlRCL.DataBind();
            ddlRCL.Items.Insert(0, new ListItem("-- Select --", string.Empty));
        }


        private void LoadCities()
        {
                
            if (ddlCity.SelectedValue == string.Empty)
            {
                lstCity = Lookup_CitiesServiceManager.GetAll();
                ddlCity.DataSource = lstCity;
            }
            else
            {
                ddlCity.DataSource = null;
            }

            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("-- Select --", string.Empty));
        }


        private void LoadBookingStatus()
        {
            List<string> BookingStatus = new List<string>();
            BookingStatus.Add("InProgress");
            BookingStatus.Add("ConfirmedNotPayed");
            BookingStatus.Add("ConfirmedPayed");
            BookingStatus.Add("RV_Done");
            BookingStatus.Add("Cancel");

            ddlBookingStatus.DataSource = BookingStatus;
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