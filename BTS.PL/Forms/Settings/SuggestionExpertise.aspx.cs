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
    public partial class SuggestionExpertise : System.Web.UI.Page
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
            List<ExpertiseSuggestion> lst = ExpertiseSuggestionServiceManager.GetAll();
            gvData.DataSource = lst;
            gvData.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Todate = TxtToDate.Text;
            DateTime To_Date;
            if (Todate == null || Todate == "")
            {
                To_Date = DateTime.Now;
            }
            else
            {
                To_Date = Convert.ToDateTime(Todate);
            }
            string Fromdate = TxtFromDate.Text;
            DateTime From_Date;
            if (Fromdate == null || Fromdate == "")
            {
                Fromdate = "1/1/2020";
                From_Date = Convert.ToDateTime(Fromdate);

            }
            else
            {
                From_Date = Convert.ToDateTime(Fromdate);

            }
            string State = ddlState.SelectedValue;
            List<ExpertiseSuggestion> expertiseSuggestions = ExpertiseSuggestionServiceManager.GetAll();
            List<ExpertiseSuggestion> expertiseSuggestion = new List<ExpertiseSuggestion>();
            if (State == "1")
            {
                foreach (ExpertiseSuggestion file in expertiseSuggestions)
                {
                    DateTime uploadtime = (DateTime)file.Date;
                    DateTime x = uploadtime.Date;
                    if ( x >= From_Date && x <= To_Date && file.InsertYN==true)
                    {

                        expertiseSuggestion.Add(file);

                    }
                }
            }
            else
            {
                foreach (ExpertiseSuggestion file in expertiseSuggestions)
                {
                    DateTime uploadtime = (DateTime)file.Date;
                    DateTime x = uploadtime.Date;
                    if (x >= From_Date && x <= To_Date && file.InsertYN !=true)
                    {

                        expertiseSuggestion.Add(file);

                    }
                }
            }
            gvData.DataSource = expertiseSuggestion;
            gvData.DataBind();
        }

        protected void cbxSelectedItemIsActive_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            int Code = int.Parse(((ImageButton)sender).CommandName);

            ExpertiseSuggestion expertise = ExpertiseSuggestionServiceManager.GetByCode(Code);
            expertise.InsertYN = true;
            ExpertiseSuggestionServiceManager.Update(expertise);

            LoadItems();
        }
    }
}