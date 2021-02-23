using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BTS.Entities;
using BTS.ServiceManager;
using BTS.Entities.Views;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net.Security;
using System.Net;
using Newtonsoft.Json;
using System.Text;

using System.IO;

namespace BTS.PL.Forms.Settings
{
    public partial class Review_CheckDocument : System.Web.UI.Page
    {
        List<Log_FielsUpload> Log_files = new List<Log_FielsUpload>();
        private string SelectedItemID
        {
            set { ViewState["SelectedItemID"] = value; }
            get
            {
                if (ViewState["SelectedItemID"] == null)
                    return null;
                else
                    return ViewState["SelectedItemID"].ToString();
            }
        }
        private string ContactCode
        {
            set { ViewState["ContactCode"] = value; }
            get
            {
                if (ViewState["ContactCode"] == null)
                    return null;
                else
                    return ViewState["ContactCode"].ToString();
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
            string checker = Session["LoggedUsers"].ToString();
            List<View_FielsUpload_ByGroupByUserID> lstFileUpload = FielsUploadServiceManager.GetAll_FielsUpload_ByGroupByUserID();
            List<View_FielsUpload_ByGroupByUserID> lstFileUploads = lstFileUpload.FindAll(x => x.CheckerName == null || x.CheckerName == checker);
            if (lstFileUploads == null || lstFileUploads.Count==0)
            {
                View_FielsUpload_ByGroupByUserID _obj = new View_FielsUpload_ByGroupByUserID();
                lstFileUploads.Add(_obj);
            }
            gvGetAllData.DataSource = lstFileUploads; 
            gvGetAllData.DataBind();
            List<Lookup_Expertises> expertises = Lookup_ExpertisesServiceManager.GetActiveList();
            List<Lookup_Expertises> expertises1 = expertises.FindAll(x => x.ParentExpertiseCode == 0 );
            //ddlExpertise.DataSource = expertises1;

            //ddlExpertise.DataBind();
            //ddlExpertise.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            //ddlExpertise.SelectedIndex = 0;
        }
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedItemID = null;
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            this.SelectedItemID =((ImageButton)sender).Attributes["SelectedID"];
            this.ContactCode = ((ImageButton)sender).CommandName;
            //btnReview.Enabled = false;
            if (this.SelectedItemID == null || this.SelectedItemID == "") return;
            List<FielsUpload> files = FielsUploadServiceManager.GetFielsUploadByUserID(this.SelectedItemID);
            if (files == null || files.Count == 0)
            {
                FielsUpload _NewTemp = new FielsUpload();
                _NewTemp.Code = -1;
                files.Add(_NewTemp);
            }
            else
            {
                Chk_Regional.Checked = (files[0].RegionalYN == null  || files[0].RegionalYN.Value.ToString()=="") ? false : files[0].RegionalYN.Value;
                Chk_International.Checked = (files[0].InternationalYN == null || files[0].InternationalYN.Value.ToString() == "") ? false : files[0].InternationalYN.Value;
                Chk_Gloabal.Checked = (files[0].GloabalYN == null || files[0].GloabalYN.Value.ToString() == "") ? false : files[0].GloabalYN.Value;

                Chk_Complete.Checked = (files[0].CompleteYN == null || files[0].CompleteYN.Value.ToString() == "") ? false : files[0].CompleteYN.Value;
                Chk_InComplete.Checked = (files[0].InCompleteYN == null || files[0].InCompleteYN.Value.ToString() == "") ? false : files[0].InCompleteYN.Value;
                //Chk_Close.Checked = (files[0].CloseYN == null || files[0].CloseYN.Value.ToString() == "") ? false : files[0].CloseYN.Value;
                Chk_Freeze.Checked = (files[0].FreezeYN == null || files[0].FreezeYN.Value.ToString() == "") ? false : files[0].FreezeYN.Value;
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
          
           
            List<Log_FielsUpload> Log_files  = Log_FielsUploadServiceManager.GetByUserID(this.SelectedItemID);
            if (Log_files == null || Log_files.Count == 0)
            {
                Log_FielsUpload _NewTemp = new Log_FielsUpload();
                _NewTemp.Code = -1;
                Log_files.Add(_NewTemp);
                GridLog.DataSource = Log_files;
                GridLog.DataBind();
            }
            else
            {
              
                Session["Log_files"]= Log_files;
                GridLog.DataSource = Log_files;
                GridLog.DataBind();
            }

            List<View_Contact_Expertise> Lts_AllExpertise = Contact_ExpertiseServiceManager.ExcPro_GetAllExpertiseByContactCode(int.Parse(this.ContactCode));
            List<View_Contact_Expertise> Lts_AllExpertise_ISActive = Lts_AllExpertise.FindAll(x => x.IsActive == true);
            if(Lts_AllExpertise_ISActive==null || Lts_AllExpertise_ISActive.Count==0)
            {
                View_Contact_Expertise _NewTemp = new View_Contact_Expertise();
                Lts_AllExpertise_ISActive.Add(_NewTemp);
            }
            List<View_Contact_Expertise> lstllSpecial = Contact_ExpertiseServiceManager.ExcPro_GetAllSpecialExpertiseByContactCode(int.Parse(this.ContactCode));
            List<View_Contact_Expertise> lstSpecial = lstllSpecial.FindAll(x => x.SpacialYN == true);
            if(lstSpecial == null || lstSpecial.Count == 0)
            {
                btnSpecial.Enabled = false;
            }
            else
            {
                btnSpecial.Enabled = true;
            }
            Session["Lts_Expertise"] = Lts_AllExpertise_ISActive;
            Grid_Exp.DataSource = Lts_AllExpertise_ISActive;
            Grid_Exp.DataBind();


            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
        }

        protected void Yes_Click(object sender, EventArgs e)
        {
          
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            try
            {
               
                string filePath = (sender as LinkButton).CommandArgument;
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "filename=" + filePath);
                Response.TransmitFile(Server.MapPath("~/Uploads/") + filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            #region Add_FielsUpload
            if (Session["Log_files"] != null)
                Log_files = Session["Log_files"] as List<Log_FielsUpload>;
            else
                Log_files = new List<Log_FielsUpload>();
            Log_FielsUpload _objLog = new Log_FielsUpload();
            _objLog.Code = 1;
            _objLog.UserID = this.SelectedItemID ;
            _objLog.CheckerName = Session["LoggedUsers"].ToString();
            _objLog.LogDate = DateTime.Now;
            _objLog.FileTypeCode = 1;
            _objLog.Comment = txtComment.Text;
            Log_files.Add(_objLog);
            Log_FielsUploadServiceManager.Insert(_objLog);
            txtComment.Text = "";
            Session["Log_files"] = Log_files;
            GridLog.DataSource = Log_files;
            GridLog.DataBind();
           
            #endregion
        }

      
        protected void Chk_Complete_CheckedChanged(object sender, EventArgs e)
        {
            btnReview.Enabled = true;

            Chk_InComplete.Checked = false;
           // Chk_Close.Checked = false;
        }

        protected void Chk_InComplete_CheckedChanged(object sender, EventArgs e)
        {
            Chk_Complete.Checked = false;
           // Chk_Close.Checked = false;
            btnReview.Enabled = true;

        }
        protected void Chk_Close_CheckedChanged(object sender, EventArgs e)
        {
            Chk_Complete.Checked = false;
            Chk_InComplete.Checked = false;
            btnReview.Enabled = true;

        }
        protected void btnOpenCV_Click(object sender, EventArgs e)
        {
           


            List<ViewContactCV> _ContactCV = Contact_CVServiceManager.GetByContactCode(int.Parse(this.ContactCode));
            if (_ContactCV == null) return;
            field1.Text= _ContactCV[0].Field_1;
            field2.Text = _ContactCV[0].Field_2;
            field3.Text = _ContactCV[0].Field_3;
            field4.Text = _ContactCV[0].Field_4;
            field5.Text = _ContactCV[0].Field_5;
            field6.Text = _ContactCV[0].Field_6;
            field7.Text = _ContactCV[0].Field_7;
            field8.Text = _ContactCV[0].Field_8;
            field9.Text = _ContactCV[0].Field_9;
            field10.Text = _ContactCV[0].Field_10;
            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showCVForm();", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
        }

        protected void Chk_Freeze_CheckedChanged(object sender, EventArgs e)
        {
            List<FielsUpload> UpdatePrimaryCheckYN = FielsUploadServiceManager.GetFielsUploadByUserID(this.SelectedItemID);
            CheckBox ChkControl = sender as CheckBox;
            CheckBox Chk_Freeze = ChkControl.NamingContainer.FindControl("Chk_Freeze") as CheckBox;

            foreach (FielsUpload Row in UpdatePrimaryCheckYN)
            {
                Row.FreezeYN = Chk_Freeze.Checked;
                FielsUploadServiceManager.Update(Row);
            }
        }

        protected void btnReview_Click(object sender, EventArgs e)
        {
            try
            {



                List<Contact_CV> _CV = Contact_CVServiceManager.GetActiveList();
                Contact_CV obj = _CV.Find(X => X.ContactCode == int.Parse(this.ContactCode));
                List<ViewContactCV> _ContactCV = Contact_CVServiceManager.GetByContactCode(int.Parse(this.ContactCode));

                if (Chk_International.Checked == true)
                {
                    obj.InternationalCountriesArabicName = _ContactCV[0].InternationalCountriesArabicName;
                    obj.InternationalCountriesEnglishName = _ContactCV[0].InternationalCountriesEnglishName;
                }
                if (Chk_Regional.Checked == true)
                {
                    obj.RegionalCountriesArabicName = _ContactCV[0].RegionalCountriesArabicName;
                    obj.RegionalCountriesEnglishName = _ContactCV[0].RegionalCountriesEnglishName;
                }
                Contact_CVServiceManager.Update(obj);
                List<FielsUpload> UpdatePrimaryCheckYN = FielsUploadServiceManager.GetFielsUploadByUserID(this.SelectedItemID);
                if (UpdatePrimaryCheckYN != null && UpdatePrimaryCheckYN.Count > 0)
                {
                    foreach (FielsUpload Row in UpdatePrimaryCheckYN)
                    {
                        Row.RegionalYN = Chk_Regional.Checked;
                        Row.InternationalYN = Chk_International.Checked;
                        Row.GloabalYN = Chk_Gloabal.Checked;
                        Row.CompleteYN = Chk_Complete.Checked;
                        Row.InCompleteYN = Chk_InComplete.Checked;
                       // Row.CloseYN = Chk_Close.Checked;
                        Row.FreezeYN = false;
                        Row.ApproveYN = true;
                        Row.CheckerName = Session["LoggedUsers"].ToString();
                        Row.CheckerDate = DateTime.Now;

                        FielsUploadServiceManager.Update(Row);
                    }
                }
                List<View_Contact_Expertise> Lts_AllExpertise_ISActive = Session["Lts_Expertise"] as List<View_Contact_Expertise>;
                if (Lts_AllExpertise_ISActive != null && Lts_AllExpertise_ISActive.Count > 0)
                {
                    foreach (View_Contact_Expertise Row in Lts_AllExpertise_ISActive)
                    {
                        string _Status = "";
                        if (Chk_Complete.Checked == true)
                        
                            _Status = "Complete";
                        
                        if (Chk_InComplete.Checked == true)
                        
                            _Status = "In Complete";
                        
                        //if (Chk_Close.Checked == true)
                        
                        //    _Status = "Close";
                        


                        string _Comment = Row.ExpertiseLevelName2_EN_SQLLite + "/" + Row.ExpertiseLevelName3_EN_SQLLite + " : Result:" + _Status;
                        Log_FielsUpload _objLog = new Log_FielsUpload();
                        _objLog.Code = 1;
                        _objLog.UserID = this.SelectedItemID;
                        _objLog.CheckerName = Session["LoggedUsers"].ToString();
                        _objLog.LogDate = DateTime.Now;
                        _objLog.Comment = _Comment;
                        Log_files.Add(_objLog);
                        Log_FielsUploadServiceManager.Insert(_objLog);
                        if (Chk_Complete.Checked == true || Chk_Regional.Checked==true || Chk_International.Checked==true)
                        {
                            List<Contact> _obj = ContactServiceManager.GetCOntactByUserName(this.SelectedItemID);
                            SendNotification_Contact(_obj[0].FCM_Token);
                        }
                    }
                }

                Response.Redirect("/Forms/Settings/Review_CheckDocument.aspx");
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public List<View_KeyValueLookup> GetAll_FileTypes()
        {
            try
            {
                return Lookup_FileTypesServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        private void SendNotification_Contact(string FCM_Token)
        {

            try
            {
               

                if (FCM_Token != null && FCM_Token != "")
                {


                    //string LegacyServerkey = "AIzaSyBo_VLozqIG-xQ0uptgD-LIpcv6X-AjvlE";
                    //string WebAPIKey = "AIzaSyCLsnpqG8VtEWOccuvSOaaXg3zXsDU64Zo";
                    string LegacyServerkey = "AIzaSyCghyOVe_Msy0rfrCgmMvkI12hbkOdINmI";
                    string WebAPIKey = "AIzaSyCyoCIcbvpR2S-FpYYBmRQuujMmnf2pQXE";
                    string _FCM_Token = FCM_Token;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    var data = new
                    {
                        to = _FCM_Token,
                        data = new
                        {
                            body = "",
                            Notification_Type = "DOC",
                            Notification_detail = "",
                            BookingCode = "",
                            NotificationStatusCode = 0,
                            OnDay = "false",
                            notId = "0"
                        }
                    };

                    //var serializer = new JavaScriptSerializer();
                    //serializer.Serialize(data);
                    var json = JsonConvert.SerializeObject(data);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", LegacyServerkey));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", WebAPIKey));
                    tRequest.ContentLength = byteArray.Length;

                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    string str = sResponseFromServer;
                                }
                            }
                        }
                    }

                }

            }


            catch (Exception exc)
            {

            }

        }




        protected void ddlExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lookup_Expertises> expertises = Lookup_ExpertisesServiceManager.GetActiveList();
            expertises.FindAll(x => x.ParentExpertiseCode == 0);
            //ddlExpertise.DataSource = expertises;
            
            //ddlExpertise.DataBind();
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
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
                string UserCode = TxtSerUserCode.Text.ToLower();
                string State = ddlDocumentState.SelectedValue;
                List<View_FielsUpload_ByGroupByUserID> lstFileUpload = FielsUploadServiceManager.GetAll_FielsUpload_ByGroupByUserID();
                if (lstFileUpload == null || lstFileUpload.Count == 0)
                {
                    View_FielsUpload_ByGroupByUserID _obj = new View_FielsUpload_ByGroupByUserID();
                    lstFileUpload.Add(_obj);
                }

                List<View_FielsUpload_ByGroupByUserID> FileUpload = new List<View_FielsUpload_ByGroupByUserID>();
                if (UserCode != null && UserCode != "")
                {
                    if (State == "1")
                    {
                        foreach (View_FielsUpload_ByGroupByUserID file in lstFileUpload)
                        {
                        DateTime uploadtime = (DateTime)file.UploadFileDate;
                        DateTime x = uploadtime.Date;
                        if (file.CheckerName != null && file.UserID.ToLower() == UserCode && x >= From_Date && x <= To_Date)
                            {

                                FileUpload.Add(file);

                            }
                        }
                    }
                    else if (State =="3")
                {
                    foreach (View_FielsUpload_ByGroupByUserID file in lstFileUpload)
                    {
                        DateTime uploadtime = (DateTime)file.UploadFileDate;
                        DateTime x = uploadtime.Date;
                        List<FielsUpload> fielsUploads = FielsUploadServiceManager.GetAll();
                        List<FielsUpload> fiels = fielsUploads.FindAll(z => z.SpecialExpertiseFirstYN == true && z.ContactCode == file.ContactCode);
                        if (file.CheckerName != null && file.UserID.ToLower() == UserCode && x >= From_Date && x <= To_Date && fiels[0].SpecialExpertiseFirstYN == true)
                        {

                            FileUpload.Add(file);

                        }
                    }
                }
                    else
                    {
                        foreach (View_FielsUpload_ByGroupByUserID file in lstFileUpload)
                        {
                        DateTime uploadtime = (DateTime)file.UploadFileDate;
                        DateTime x = uploadtime.Date;
                        if (file.CheckerName == null && file.UserID.ToLower() == UserCode && x >= From_Date && x <= To_Date)
                            {

                                FileUpload.Add(file);

                            }
                        }
                    }
                }
                else
                {
                    if (State == "1")
                    {
                        foreach (View_FielsUpload_ByGroupByUserID file in lstFileUpload)
                        {
                        DateTime uploadtime = (DateTime)file.UploadFileDate;
                        DateTime x = uploadtime.Date;
                        if (file.CheckerName != null && x >= From_Date && x <= To_Date)
                            {

                                FileUpload.Add(file);

                            }
                        }
                    }
                else if (State == "3")
                {
                    foreach (View_FielsUpload_ByGroupByUserID file in lstFileUpload)
                    {
                        DateTime uploadtime = (DateTime)file.UploadFileDate;
                        DateTime x = uploadtime.Date;
                        List<FielsUpload> fielsUploads = FielsUploadServiceManager.GetAll();
                        List<FielsUpload> fiels = fielsUploads.FindAll(z => z.SpecialExpertiseFirstYN == true && z.ContactCode == file.ContactCode);
                        if(fiels != null && fiels.Count !=0)
                        {
                            if ( x >= From_Date && x <= To_Date && fiels[0].SpecialExpertiseFirstYN == true)
                        {

                            FileUpload.Add(file);

                        }
                        }
                    }
                }

                else
                {
                        foreach (View_FielsUpload_ByGroupByUserID file in lstFileUpload)
                        {
                        DateTime uploadtime = (DateTime)file.UploadFileDate;
                        DateTime x = uploadtime.Date;
                            if (file.CheckerName == null && x >= From_Date && x <= To_Date)
                            {

                                FileUpload.Add(file);

                            }
                        }
                    }
                }
                gvGetAllData.DataSource = FileUpload;
                gvGetAllData.DataBind();

            


        }

        protected void btnOnlineForm_Click(object sender, EventArgs e)
        {
            string Code = ViewState["ContactCode"].ToString();

           // string UserId = "RC" + Code;
          
           
                Response.Redirect("/Forms/Settings/OnlineFormCV.aspx?Code=" + Code + "&Path=1");
        }

        protected void ChkSpacial_CheckedChanged(object sender, EventArgs e)
        {

          
          


        }

        protected void btnSpecial_Click(object sender, EventArgs e)
        {
            string Code = ViewState["ContactCode"].ToString();

            Response.Redirect("/Forms/Settings/SpecialExpertisePackage.aspx?Code=" + Code + "&Path=1");


        }

        protected void btnIsSpecial_Click(object sender, EventArgs e)
        {

            #region Test
            foreach (GridViewRow row in Grid_Exp.Rows)
            {
                CheckBox ChkSpacial = (CheckBox)row.FindControl("ChkSpacial");
                if (ChkSpacial.Checked == true)
                {
                    TextBox txtSpacialCost = (TextBox)row.FindControl("txtSpacialCost");
                    string ExpertiseRCLCode = row.Cells[0].Text;
                    string ExpertiseCode = row.Cells[1].Text;
                    string RCLCode = row.Cells[2].Text;

                    string OldExpertiseRCLCode = ExpertiseRCLCode;
                    Contact_Expertise _ContactExpertise = new Contact_Expertise();


                    //List<View_Contact_Expertise> view_Contacts = Contact_ExpertiseServiceManager.ExcPro_GetAllExpertiseByContactCode(int.Parse(this.ContactCode));
                    //Contact_Expertise _obj = view_Contacts.Find(x => x.ExpertiseRCLCode == int.Parse(ExpertiseRCLCode));
                    // Contact_Expertise obj = Contact_ExpertiseServiceManager.GetByEXP_RCL_Code()
                    List<Contact_Expertise> _obj = Contact_ExpertiseServiceManager.GetAll();
                    Contact_Expertise _obj1 = _obj.Find(x => x.ExpertiseRCLCode == int.Parse(ExpertiseRCLCode) && x.ContactCode == int.Parse(this.ContactCode));
                    if (_obj1 != null)
                    {
                        
                            if (_obj1.Cost == null)
                            {
                            _obj1.IsActive = false;
                                Contact_ExpertiseServiceManager.Update(_obj1);
                            }
                          
                        }

                    List<Lookup_ExpertiseRCL> lst = Lookup_ExpertiseRCLServiceManager.GetAll();
                    Lookup_ExpertiseRCL obj = lst.Find(x => x.ExpertiseCode == int.Parse(ExpertiseCode) && x.RCLCode == 13);
                    if (obj == null)
                    {
                        Lookup_ExpertiseRCL _expertiseRCL = new Lookup_ExpertiseRCL();
                        _expertiseRCL.ExpertiseCode = int.Parse(ExpertiseCode);
                        _expertiseRCL.IsActive = true;
                        _expertiseRCL.RCLCode = 13;
                        _expertiseRCL.Cost = 0;
                        ExpertiseRCLCode= Lookup_ExpertiseRCLServiceManager.Insert(_expertiseRCL).ToString();
                      //  ExpertiseRCLCode = _expertiseRCL.Code.ToString();
                    }
                    else
                    {
                        ExpertiseRCLCode = obj.Code.ToString();
                    }


                    _ContactExpertise = _obj.Find(x => x.ExpertiseRCLCode == int.Parse(ExpertiseRCLCode) && x.ContactCode == int.Parse(this.ContactCode));
                    
                    if (_ContactExpertise == null)
                    {
                        _ContactExpertise = new Contact_Expertise();
                        _ContactExpertise.ContactCode = int.Parse(this.ContactCode);
                        _ContactExpertise.Cost = decimal.Parse(txtSpacialCost.Text);
                        _ContactExpertise.EntriyRootExpertise = 3;
                        _ContactExpertise.ExpertiseRCLCode = int.Parse(ExpertiseRCLCode);
                        _ContactExpertise.IsActive = true;
                        _ContactExpertise.OldExpertiseRCLCode = int.Parse(OldExpertiseRCLCode);
                        Contact_ExpertiseServiceManager.Insert(_ContactExpertise);
                    }
                    else
                    {
                        _ContactExpertise.ContactCode = int.Parse(this.ContactCode);
                        _ContactExpertise.Cost = decimal.Parse(txtSpacialCost.Text);
                        _ContactExpertise.EntriyRootExpertise = 3;
                        _ContactExpertise.ExpertiseRCLCode = int.Parse(ExpertiseRCLCode);
                        _ContactExpertise.IsActive = true;
                        _ContactExpertise.OldExpertiseRCLCode = int.Parse(OldExpertiseRCLCode);
                        Contact_ExpertiseServiceManager.Update(_ContactExpertise);
                    }



                }
                else
                {
                    TextBox txtSpacialCost = (TextBox)row.FindControl("txtSpacialCost");
                    string ExpertiseRCLCode = row.Cells[0].Text;
                    string ExpertiseCode = row.Cells[1].Text;
                    string RCLCode = row.Cells[2].Text;

                    string OldExpertiseRCLCode;
                    Contact_Expertise _ContactExpertise = new Contact_Expertise();
                    List<Contact_Expertise> _obj = Contact_ExpertiseServiceManager.GetAll();
                    Contact_Expertise _obj1 = _obj.Find(x => x.ExpertiseRCLCode == int.Parse(ExpertiseRCLCode) && x.ContactCode == int.Parse(this.ContactCode));
                    if (_obj1 != null)
                    {
                        OldExpertiseRCLCode = _obj1.OldExpertiseRCLCode.ToString();
                        Contact_Expertise _objOld = _obj.Find(x => x.ExpertiseRCLCode == int.Parse(OldExpertiseRCLCode) && x.ContactCode == int.Parse(this.ContactCode));
                        _objOld.IsActive = true;
                                Contact_ExpertiseServiceManager.Update(_objOld);
                  
                    }

                    List<Lookup_ExpertiseRCL> lst = Lookup_ExpertiseRCLServiceManager.GetAll();
                    Lookup_ExpertiseRCL obj = lst.Find(x => x.ExpertiseCode == int.Parse(ExpertiseCode) && x.RCLCode == 13);
                    if (obj == null)
                    {

                    }
                    else
                    {
                        ExpertiseRCLCode = obj.Code.ToString();
                        List<Contact_Expertise> _objnew = Contact_ExpertiseServiceManager.GetAll();
                        Contact_Expertise _obj1new = _obj.Find(x => x.ExpertiseRCLCode == int.Parse(ExpertiseRCLCode) && x.ContactCode == int.Parse(this.ContactCode));
                        if (_obj1new != null)
                        {
                            _obj1new.IsActive = false;
                            Contact_ExpertiseServiceManager.Update(_obj1new);
                        }
                        else
                        { }
                        }

                }
            }
            #endregion

            List<FielsUpload> fielsUploads = FielsUploadServiceManager.GetFielsUploadByUserID(this.SelectedItemID);

            foreach(FielsUpload fiels in fielsUploads)
            {
                fiels.SpecialExpertiseYN = false;
                FielsUploadServiceManager.Update(fiels);
            }
            //btnIsSpecial.Enabled = false;
            btnSpecial.Enabled = false;
        }
    }
}