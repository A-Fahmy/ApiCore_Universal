using BTS.Entities;
using BTS.Entities.Views;
using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BTS.PL.Forms.Settings
{
    public partial class OnlineFormCV : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                //List<Entities.Lookup_Language> languages = Lookup_LanguageServiceManager.GetActiveList();
                //List<View_KeyValueLookup> lst = (from l in languages
                //                                 where l.IsActive == true
                //                                 select new View_KeyValueLookup
                //                                 {
                //                                     Code = l.Code,
                //                                     Name = l.LanguageEnName
                //                                 }).ToList();
                //ddlLanguages.DataSource = lst;
                //ddlLanguages.DataBind();
                //ddlLanguages.Items.Insert(0, new ListItem("-- Select --", string.Empty));

                Panel2.Visible = false;
                Panel3.Visible = false;
            string _UserID = Request.QueryString["UserID"];
            string _Path = Request.QueryString["Path"];
            string _Code = Request.QueryString["Code"];
                string password = Request.QueryString["Password"];
                Session["Password"] = password;
            txtContact.Text= _Code;
            txtContact.Enabled = false;
            OnlineForm obj = OnlineFormServiceManager.GetByUserCode(int.Parse(_Code));
             
            if(obj != null)
            {
                
      
                    txtName.Text = obj.Name;
                    TxtBirthDate.Text = Convert.ToDateTime( obj.BirthDate).ToString("yyyy-MM-dd");
                    txtHighSchool.Text = obj.HighSchool ;
                   txtUniversity.Text = obj.UniversitySchool;
                     txtNameOfUniversity.Text = obj.University ;
                     txtPostGraduated.Text = obj.PostGraduated ;
                     txtArea.Text = obj.District ;
                     txtCity.Text = obj.City ;
                     txtGovernment.Text = obj.Government ;
                     txtCompetencies.Text = obj.Competencies ;
                    txtSkills.Text = obj.Skills ;
                     txtTraining.Text = obj.Training ;
                    txtUnions.Text = obj.Unions ;
                     txtClubs.Text = obj.Clups;
                     txtSports.Text = obj.Sports ;
                     txtScientific.Text = obj.ScientificSocieties ;
                    txtInfo.Text = obj.OtherInfo ;
                    txtQualifications.Text = obj.Qualifications ;
                  //  ddlLanguages.SelectedValue = obj.Languages.ToString();
                                 }
                if (_Path == "1")
                {
                    btnSave.Visible = false;
                    btnAddJop1.Visible = false;
                    txtAchievement.Enabled = false;
                    txtAchievement10.Enabled = false;
                    txtAchievement3.Enabled = false;
                    txtAchievement4.Enabled = false;
                    txtAchievement6.Enabled = txtAchievement7.Enabled = txtAchievement8.Enabled = txtAchievement9.Enabled = txtAcvhievement5.Enabled = txtArea.Enabled = false;
                    TxtBirthDate.Enabled = txtCity.Enabled = txtClubs.Enabled = txtCompany.Enabled = txtCompany10.Enabled = txtCompany2.Enabled = txtCompany3.Enabled = false;
                    txtCompany4.Enabled = txtCompany5.Enabled = txtCompany7.Enabled = txtCompany8.Enabled = txtCompany9.Enabled = txtCompetencies.Enabled = false;
                    TxtEndDate.Enabled = txtEndDate10.Enabled = txtEndDate2.Enabled = txtEndDate3.Enabled = txtEndDate4.Enabled = txtEndDate5.Enabled = txtEndDate6.Enabled = false;
                    txtEndDate7.Enabled = txtEndDate8.Enabled = txtEndDate9.Enabled = txtGovernment.Enabled = txtHighSchool.Enabled = txtInfo.Enabled = txtName.Enabled = false;
                    txtNameOfUniversity.Enabled = txtPostGraduated.Enabled = txtPreAchievment1.Enabled = txtPreCompany1.Enabled = txtPreTitle1.Enabled = false;
                    txtQualifications.Enabled = txtScientific.Enabled = txtSkills.Enabled = txtSports.Enabled = TxtStartDate.Enabled = txtStartDate10.Enabled = false;
                    txtStartDate2.Enabled = txtStartDate3.Enabled = txtStartDate4.Enabled = txtStartDate5.Enabled = txtStartDate6.Enabled = false;
                    //Panel1.Enabled = false;
                    //Panel2.Enabled = false;
                    //Panel3.Enabled = false;
                    //btnNexttoSecond.Enabled = true;
                    //btnNextToThird.Enabled = true;
                    //btnPrevious.Enabled = true;
                    //btnPrevious1.Enabled = true;
                    //btnOK.Enabled = true;
                    txtStartDate7.Enabled = txtStartDate8.Enabled = txtStartDate9.Enabled = txtTitle.Enabled = txtTitle10.Enabled = false;
                    txtTitle2.Enabled = txtTitle3.Enabled = txtTitle4.Enabled = txtTitle5.Enabled = txtTitle7.Enabled = txtTitle8.Enabled = txtTitle9.Enabled = false;
                    txtTraining.Enabled = txtUnions.Enabled = txtUniversity.Enabled = false;
                    
                }
                else
                {
                    btnOK.Visible = false;
                }

            }
        }

      

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            { 
            string password = Session["Password"].ToString();
            OnlineForm OnlineCv = OnlineFormServiceManager.GetByUserCode(int.Parse(txtContact.Text));
            if(OnlineCv!=null)
            { 
            OnlineCv.Name = txtName.Text;
                OnlineCv.BirthDate = Convert.ToDateTime( TxtBirthDate.Text);
                OnlineCv.HighSchool = txtHighSchool.Text;
                OnlineCv.UniversitySchool = txtUniversity.Text;
                OnlineCv.University = txtNameOfUniversity.Text;
                OnlineCv.PostGraduated = txtPostGraduated.Text;
                OnlineCv.District = txtArea.Text;
                OnlineCv.City = txtCity.Text;
                OnlineCv.Government = txtGovernment.Text;
                OnlineCv.Competencies = txtCompetencies.Text;
                OnlineCv.Skills = txtSkills.Text;
                OnlineCv.Training = txtTraining.Text;
                OnlineCv.Unions = txtUnions.Text;
                OnlineCv.Clups = txtClubs.Text;
                OnlineCv.Sports = txtSports.Text;
                OnlineCv.ScientificSocieties = txtScientific.Text;
                OnlineCv.OtherInfo = txtInfo.Text;
                OnlineCv.Qualifications = txtQualifications.Text;
               // OnlineCv.Languages = int.Parse(ddlLanguages.SelectedValue);
            OnlineCv.ContactCode =int.Parse( txtContact.Text);
            OnlineFormServiceManager.Update(OnlineCv);
            }
            else
            {
                OnlineForm obj = new OnlineForm();
                obj.Name = txtName.Text;

                obj.BirthDate = Convert.ToDateTime(TxtBirthDate.Text);
                obj.HighSchool = txtHighSchool.Text;
                obj.UniversitySchool = txtUniversity.Text;
                obj.University = txtNameOfUniversity.Text;
                obj.PostGraduated = txtPostGraduated.Text;
                obj.District = txtArea.Text;
                obj.City = txtCity.Text;
                obj.Government = txtGovernment.Text;
                obj.Competencies = txtCompetencies.Text;
                obj.Skills = txtSkills.Text;
                obj.Training = txtTraining.Text;
                obj.Unions = txtUnions.Text;
                obj.Clups = txtClubs.Text;
                obj.Sports = txtSports.Text;
                obj.ScientificSocieties = txtScientific.Text;
                obj.OtherInfo = txtInfo.Text;
                //obj.Languages = int.Parse(ddlLanguages.SelectedValue);
                obj.Qualifications = txtQualifications.Text;
                obj.ContactCode = int.Parse(txtContact.Text);
                OnlineFormServiceManager.Insert(obj);
            }
            //List<OnlineFormJop> jop = OnlineFormJopServiceManager.GetAll();
            //List<OnlineFormJop> _jops = jop.FindAll(x => x.ContactCode ==int.Parse( txtContact.Text)).ToList();
            List<OnlineFormJop> jobs = OnlineFormJopServiceManager.GetAll();
            List<OnlineFormJop> _Jop = jobs.FindAll(x => x.ContactCode == int.Parse(txtContact.Text)).ToList();
        
            OnlineFormJop objs = new OnlineFormJop();
            if(txtTitle.Text != "" && txtCompany.Text != "")
            { 
            objs.ContactCode = int.Parse(txtContact.Text);
            objs.Title = txtTitle.Text;
            objs.Company = txtCompany.Text;
            objs.Achievment = txtAchievement.Text;
            if (TxtStartDate.Text != null && TxtStartDate.Text != "")
                objs.StartDate =Convert.ToDateTime( TxtStartDate.Text);
            if (TxtEndDate.Text != null && TxtEndDate.Text != "")
                objs.EndDate = Convert.ToDateTime(TxtEndDate.Text);
            if (_Jop.Count > 0)
            {
                objs.Code = _Jop[0].Code;
                OnlineFormJopServiceManager.Update(objs);
            }
            else
                OnlineFormJopServiceManager.Insert(objs);
            
            objs = new OnlineFormJop();
            }
            if (txtPreTitle1.Text !="" && txtPreCompany1.Text != "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtPreTitle1.Text;
                objs.Company = txtPreCompany1.Text;
                objs.Achievment = txtPreAchievment1.Text;
                if (txtStartDate2.Text!=null && txtStartDate2.Text != "")
                objs.StartDate = Convert.ToDateTime(txtStartDate2.Text);
                if (txtEndDate2.Text != null && txtEndDate2.Text != "")
                      objs.EndDate = Convert.ToDateTime(txtEndDate2.Text);
                if (_Jop.Count > 1)
                {
                    objs.Code = _Jop[1].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();

            }
            if(txtTitle2.Text !="" && txtCompany2.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle2.Text;
                objs.Company = txtCompany2.Text;
                objs.Achievment = txtAchievement3.Text;
                if (txtStartDate3.Text != null && txtStartDate3.Text != "")
                        objs.StartDate = Convert.ToDateTime(txtStartDate3.Text);
                if (txtEndDate3.Text != null && txtEndDate3.Text != "")
                objs.EndDate = Convert.ToDateTime(txtEndDate3.Text);
               
                if (_Jop.Count > 2)
                {
                    objs.Code = _Jop[2].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();
            }
            if (txtTitle3.Text != "" && txtCompany3.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle3.Text;
                objs.Company = txtCompany3.Text;
                objs.Achievment = txtAchievement4.Text;
                if (txtStartDate4.Text != null && txtStartDate4.Text != "")
                    objs.StartDate = Convert.ToDateTime(txtStartDate4.Text);
                if (txtEndDate4.Text != null && txtEndDate4.Text != "")
                    objs.EndDate = Convert.ToDateTime(txtEndDate4.Text);
                if (_Jop.Count > 3)
                {
                    objs.Code = _Jop[3].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();
            }
            if (txtTitle4.Text != "" && txtCompany4.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle4.Text;
                objs.Company = txtCompany4.Text;
                objs.Achievment = txtAcvhievement5.Text;
                if (txtStartDate5.Text != null && txtStartDate5.Text != "")
                    objs.StartDate = Convert.ToDateTime(txtStartDate5.Text);
                if (txtEndDate5.Text != null && txtEndDate5.Text != "")
                    objs.EndDate = Convert.ToDateTime(txtEndDate5.Text);
                if (_Jop.Count > 4)
                {
                    objs.Code = _Jop[4].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();
            }
            if (txtTitle5.Text != "" && txtCompany5.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle5.Text;
                objs.Company = txtCompany5.Text;
                objs.Achievment = txtAchievement6.Text;
                if (txtStartDate6.Text != null && txtStartDate6.Text != "")
                    objs.StartDate = Convert.ToDateTime(txtStartDate6.Text);
                if (txtEndDate6.Text != null && txtEndDate6.Text != "")
                    objs.EndDate = Convert.ToDateTime(txtEndDate6.Text);
                if (_Jop.Count > 5)
                {
                    objs.Code = _Jop[5].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();
            }
            if (txtTitle7.Text != "" && txtCompany7.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle7.Text;
                objs.Company = txtCompany7.Text;
                objs.Achievment = txtAchievement7.Text;
                if (txtStartDate7.Text != null && txtStartDate7.Text != "")
                    objs.StartDate = Convert.ToDateTime(txtStartDate6.Text);
                if (txtEndDate7.Text != null && txtEndDate7.Text != "")
                    objs.EndDate = Convert.ToDateTime(txtEndDate7.Text);
                if (_Jop.Count > 6)
                {
                    objs.Code = _Jop[6].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();
            }
            if (txtTitle8.Text != "" && txtCompany8.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle8.Text;
                objs.Company = txtCompany8.Text;
                objs.Achievment = txtAchievement8.Text;
                if (txtStartDate8.Text != null && txtStartDate8.Text != "")
                    objs.StartDate = Convert.ToDateTime(txtStartDate6.Text);
                if (txtEndDate8.Text != null && txtEndDate8.Text != "")
                    objs.EndDate = Convert.ToDateTime(txtEndDate8.Text);
                if (_Jop.Count > 7)
                {
                    objs.Code = _Jop[7].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();
            }
            if (txtTitle9.Text != "" && txtCompany9.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle9.Text;
                objs.Company = txtCompany9.Text;
                objs.Achievment = txtAchievement9.Text;
                if (txtStartDate9.Text != null && txtStartDate9.Text != "")
                    objs.StartDate = Convert.ToDateTime(txtStartDate9.Text);
                if (txtEndDate9.Text != null && txtEndDate9.Text != "")
                    objs.EndDate = Convert.ToDateTime(txtEndDate9.Text);
                if (_Jop.Count > 8)
                {
                    objs.Code = _Jop[8].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
                objs = new OnlineFormJop();
            }
            if (txtTitle10.Text != "" && txtCompany10.Text == "")
            {
                objs.ContactCode = int.Parse(txtContact.Text);
                objs.Title = txtTitle10.Text;
                objs.Company = txtCompany10.Text;
                objs.Achievment = txtAchievement10.Text;
                if (txtStartDate10.Text != null && txtStartDate10.Text != "")
                    objs.StartDate = Convert.ToDateTime(txtStartDate10.Text);
                if (txtEndDate10.Text != null && txtEndDate10.Text != "")
                    objs.EndDate = Convert.ToDateTime(txtEndDate10.Text);
                if (_Jop.Count > 9)
                {
                    objs.Code = _Jop[9].Code;
                    OnlineFormJopServiceManager.Update(objs);
                }
                else
                    OnlineFormJopServiceManager.Insert(objs);
            }
            string UserId = "RC" + txtContact.Text;
            List<FielsUpload> file = FielsUploadServiceManager.GetFielsUploadByUserID(UserId);
            foreach (FielsUpload f in file)
            {
                f.OnlineFormYN = true;
                FielsUploadServiceManager.Update(f);
            }
               Response.Redirect("/Forms/Settings/CheckDocument.aspx?UserID="+ UserId + "&Password="+password);
                //   ScriptManager.RegisterStartupScript(this, GetType(),  "goBack", "history.go(-1);", true);

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnNexttoSecond_Click(object sender, EventArgs e)
        {
        if(TxtBirthDate.Text != null && TxtBirthDate.Text !="" && txtName.Text != "")
            { 
                List<OnlineFormJop> objs = OnlineFormJopServiceManager.GetAll();
            List<OnlineFormJop> _Jop = objs.FindAll(x => x.ContactCode == int.Parse(txtContact.Text)).ToList();
            if(_Jop == null || _Jop.Count == 0)
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
            CurrentJop.Visible = true;
            PreviousJop.Visible = true;
            PreviousJop1.Visible = false;
            PreviousJop2.Visible = false;
            PreviousJop3.Visible = false;
            PreviousJop4.Visible = false;
            PreviousJop5.Visible = false;
            PreviousJop6.Visible = false;
            PreviousJop7.Visible = false;
            PreviousJop8.Visible = false;


            }
            else
            { 
            #region Jobs Retrive Data
            if (_Jop.Count >= 1)
            {
                txtTitle.Text = _Jop[0].Title;
                txtCompany.Text = _Jop[0].Company;
                txtAchievement.Text = _Jop[0].Achievment;
                        if(_Jop[0].StartDate!=null)
                TxtStartDate.Text =  Convert.ToDateTime(_Jop[0].StartDate).ToString("yyyy-MM-dd");
                        if(_Jop[0].EndDate!=null)
                    TxtEndDate.Text = Convert.ToDateTime(_Jop[0].EndDate).ToString("yyyy-MM-dd");
                  
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    CurrentJop.Visible = true;
                PreviousJop.Visible = false;
                PreviousJop1.Visible = false;
                PreviousJop2.Visible = false;
                PreviousJop3.Visible = false;
                PreviousJop4.Visible = false;
                PreviousJop5.Visible = false;
                PreviousJop6.Visible = false;
                PreviousJop7.Visible = false;
                PreviousJop8.Visible = false;
            }
            if (_Jop.Count >= 2)
            {
                txtPreTitle1.Text = _Jop[1].Title;
                txtPreCompany1.Text = _Jop[1].Company;
                txtPreAchievment1.Text = _Jop[1].Achievment;
                        if (_Jop[1].StartDate != null)
                            txtStartDate2.Text = Convert.ToDateTime(_Jop[1].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[1].EndDate != null)
                            txtEndDate2.Text = Convert.ToDateTime(_Jop[1].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                PreviousJop.Visible = true;
                PreviousJop1.Visible = false;
                PreviousJop2.Visible = false;
                PreviousJop3.Visible = false;
                PreviousJop4.Visible = false;
                PreviousJop5.Visible = false;
                PreviousJop6.Visible = false;
                PreviousJop7.Visible = false;
                PreviousJop8.Visible = false;
            }
             if (_Jop.Count >= 3)
            {
                txtTitle2.Text = _Jop[2].Title;
                txtCompany2.Text = _Jop[2].Company;
                txtAchievement3.Text = _Jop[2].Achievment;
                        if (_Jop[2].StartDate != null)
                            txtStartDate3.Text = Convert.ToDateTime(_Jop[2].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[2].EndDate != null)
                            txtEndDate3.Text = Convert.ToDateTime(_Jop[2].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                PreviousJop.Visible = true;
                PreviousJop1.Visible = true;
                PreviousJop2.Visible = false;
                PreviousJop3.Visible = false;
                PreviousJop4.Visible = false;
                PreviousJop5.Visible = false;
                PreviousJop6.Visible = false;
                PreviousJop7.Visible = false;
                PreviousJop8.Visible = false;
            }
           if (_Jop.Count >= 4)
            {
                txtTitle3.Text = _Jop[3].Title;
                txtCompany3.Text = _Jop[3].Company;
                txtAchievement4.Text = _Jop[3].Achievment;
                        if (_Jop[3].StartDate != null)
                            txtStartDate4.Text = Convert.ToDateTime(_Jop[3].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[3].EndDate != null)
                            txtEndDate4.Text = Convert.ToDateTime(_Jop[3].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                PreviousJop.Visible = true;
                PreviousJop1.Visible = true;
                PreviousJop2.Visible = true;
                PreviousJop3.Visible = false;
                PreviousJop4.Visible = false;
                PreviousJop5.Visible = false;
                PreviousJop6.Visible = false;
                PreviousJop7.Visible = false;
                PreviousJop8.Visible = false;
            }
           if (_Jop.Count>=5)
                {
                    txtTitle4.Text = _Jop[4].Title;
                    txtCompany4.Text = _Jop[4].Company;
                    txtAcvhievement5.Text = _Jop[4].Achievment;
                        if (_Jop[4].StartDate != null)
                            txtStartDate5.Text = Convert.ToDateTime(_Jop[4].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[4].EndDate != null)
                            txtEndDate5.Text = Convert.ToDateTime(_Jop[4].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                    PreviousJop.Visible = true;
                    PreviousJop1.Visible = true;
                    PreviousJop2.Visible = true;
                    PreviousJop3.Visible = true;
                    PreviousJop4.Visible = false;
                    PreviousJop5.Visible = false;
                    PreviousJop6.Visible = false;
                    PreviousJop7.Visible = false;
                    PreviousJop8.Visible = false;
                }
           if(_Jop.Count >=6)
                {

                    
                        txtTitle5.Text = _Jop[5].Title;
                        txtCompany5.Text = _Jop[5].Company;
                        txtAchievement6.Text = _Jop[5].Achievment;
                        if (_Jop[5].StartDate != null)
                            txtStartDate6.Text = Convert.ToDateTime(_Jop[5].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[5].EndDate != null)
                            txtEndDate6.Text = Convert.ToDateTime(_Jop[5].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                        PreviousJop.Visible = true;
                        PreviousJop1.Visible = true;
                        PreviousJop2.Visible = true;
                        PreviousJop3.Visible = true;
                        PreviousJop4.Visible = true;
                        PreviousJop5.Visible = false;
                        PreviousJop6.Visible = false;
                        PreviousJop7.Visible = false;
                        PreviousJop8.Visible = false;
                    
                }
           if(_Jop.Count>=7)
                {
                    txtTitle7.Text = _Jop[6].Title;
                    txtCompany7.Text = _Jop[6].Company;
                    txtAchievement7.Text = _Jop[6].Achievment;
                        if (_Jop[6].StartDate != null)
                            txtStartDate7.Text = Convert.ToDateTime(_Jop[6].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[6].EndDate != null)
                            txtEndDate7.Text = Convert.ToDateTime(_Jop[6].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                    PreviousJop.Visible = true;
                    PreviousJop1.Visible = true;
                    PreviousJop2.Visible = true;
                    PreviousJop3.Visible = true;
                    PreviousJop4.Visible = true;
                    PreviousJop5.Visible = true;
                    PreviousJop6.Visible = false;
                    PreviousJop7.Visible = false;
                    PreviousJop8.Visible = false;
                }
           if(_Jop.Count>=8)
                {
                    txtTitle8.Text = _Jop[7].Title;
                    txtCompany8.Text = _Jop[7].Company;
                    txtAchievement8.Text = _Jop[7].Achievment;
                        if (_Jop[7].StartDate != null)
                            txtStartDate8.Text = Convert.ToDateTime(_Jop[7].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[7].EndDate != null)
                            txtEndDate8.Text = Convert.ToDateTime(_Jop[7].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                    PreviousJop.Visible = true;
                    PreviousJop1.Visible = true;
                    PreviousJop2.Visible = true;
                    PreviousJop3.Visible = true;
                    PreviousJop4.Visible = true;
                    PreviousJop5.Visible = true;
                    PreviousJop6.Visible = true;
                    PreviousJop7.Visible = false;
                    PreviousJop8.Visible = false;
                }
                if (_Jop.Count >= 9)
                {
                    txtTitle9.Text = _Jop[8].Title;
                    txtCompany9.Text = _Jop[8].Company;
                    txtAchievement9.Text = _Jop[8].Achievment;
                        if (_Jop[8].StartDate != null)
                            txtStartDate9.Text = Convert.ToDateTime(_Jop[8].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[8].EndDate != null)
                            txtEndDate9.Text = Convert.ToDateTime(_Jop[8].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                    PreviousJop.Visible = true;
                    PreviousJop1.Visible = true;
                    PreviousJop2.Visible = true;
                    PreviousJop3.Visible = true;
                    PreviousJop4.Visible = true;
                    PreviousJop5.Visible = true;
                    PreviousJop6.Visible = true;
                    PreviousJop7.Visible = true;
                    PreviousJop8.Visible = false;
                }
                if (_Jop.Count >= 10)
                {
                    txtTitle10.Text = _Jop[9].Title;
                    txtCompany10.Text = _Jop[9].Company;
                    txtAchievement10.Text = _Jop[9].Achievment;
                        if (_Jop[9].StartDate != null)
                            txtStartDate10.Text = Convert.ToDateTime(_Jop[9].StartDate).ToString("yyyy-MM-dd");
                        if (_Jop[9].EndDate != null)
                            txtEndDate10.Text = Convert.ToDateTime(_Jop[9].EndDate).ToString("yyyy-MM-dd");
                    CurrentJop.Visible = true;
                    PreviousJop.Visible = true;
                    PreviousJop1.Visible = true;
                    PreviousJop2.Visible = true;
                    PreviousJop3.Visible = true;
                    PreviousJop4.Visible = true;
                    PreviousJop5.Visible = true;
                    PreviousJop6.Visible = true;
                    PreviousJop7.Visible = true;
                    PreviousJop8.Visible = true;
                }
                #endregion
            }
            }
        else
            {
                if (txtName.Text == "")
                    txtName.Focus();
                else
                TxtBirthDate.Focus();
                
            }
        }

        protected void btnNextToThird_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtCompany.Text == "")

            {
                txtCompany.Focus();
                return;
            }
            else if (txtTitle.Text == "" && txtCompany.Text != "")
            {
                txtTitle.Focus();
                return;
            }
            else if (txtTitle.Text == "" && txtCompany.Text == "" )
            {
                if (TxtStartDate.Text != "" || TxtEndDate.Text != "" || txtAchievement.Text != "")
                {
                    txtTitle.Focus();
                    return;
                }
            }

            if (txtPreTitle1.Text != "" && txtPreCompany1.Text == "")
            {
                txtPreCompany1.Focus();
                return;
            }
            else if (txtPreTitle1.Text == "" && txtPreCompany1.Text != "")

            {
                txtPreTitle1.Focus();
                return;
            }
            else if (txtPreTitle1.Text == "" && txtPreCompany1.Text == "" )
            {
                if (txtStartDate2.Text != "" || txtEndDate2.Text != "" || txtPreAchievment1.Text != "")
                { 
                   txtPreTitle1.Focus();
                return;
                }
            }
            if (txtTitle2.Text != "" && txtCompany2.Text == "")
            {
                txtCompany2.Focus();
                return;
            }
            else if (txtTitle2.Text == "" && txtCompany2.Text != "")

            {
                txtTitle2.Focus();
                return;
            }
            else if (txtTitle2.Text == "" && txtCompany2.Text == "" )
            {
                if (txtStartDate3.Text != "" || txtEndDate3.Text != "" || txtAchievement3.Text != "")
                { 
                    txtTitle2.Focus();
                return;
                }
            }
           
            if (txtTitle3.Text != "" && txtCompany3.Text == "")
            {
                txtCompany3.Focus();
                return;
            }
            else if (txtTitle3.Text == "" && txtCompany3.Text != "")
            { 
                txtTitle3.Focus();
                return;
            }
            else if (txtTitle3.Text == "" && txtCompany3.Text == "" )
            {
                if (txtStartDate4.Text != "" || txtEndDate4.Text != "" || txtAchievement4.Text != "")
                { 
                    txtTitle3.Focus();
                return;
                }
            }
            if (txtTitle4.Text != "" && txtCompany4.Text == "")
            {
                txtCompany4.Focus();
                return;
            }
            else if (txtTitle4.Text == "" && txtCompany4.Text != "")
            {
                txtTitle4.Focus();
                return;
            }
            else if (txtTitle4.Text == "" && txtCompany4.Text == "")
            {
                if (txtStartDate5.Text != "" || txtEndDate5.Text != "" || txtAcvhievement5.Text != "")
                {
                    txtTitle4.Focus();
                    return;
                }
            }
            if (txtTitle5.Text != "" && txtCompany5.Text == "")
            {
                txtCompany5.Focus();
                return;
            }
            else if (txtTitle5.Text == "" && txtCompany5.Text != "")
            {
                txtTitle5.Focus();
                return;
            }
            else if (txtTitle5.Text == "" && txtCompany5.Text == "" )
            {
                if (txtStartDate6.Text != "" || txtEndDate6.Text != "" || txtAchievement6.Text != "")
                { 
                    txtTitle5.Focus();
                return;
            }
            }
            if (txtTitle7.Text != "" && txtCompany7.Text == "")
            {
                txtCompany7.Focus();
                return;
            }
            else if (txtTitle7.Text == "" && txtCompany7.Text != "")
            {
                txtTitle7.Focus();
                return;
            }
            else if (txtTitle7.Text == "" && txtCompany7.Text == "" ){
                if (txtStartDate7.Text != "" || txtEndDate7.Text != "" || txtAchievement7.Text != "")
                { 
                    txtTitle7.Focus();
                return;
                }
            }
            if (txtTitle8.Text != "" && txtCompany8.Text == "")
            {
                txtCompany8.Focus();
                return;
            }
            else if (txtTitle8.Text == "" && txtCompany8.Text != "")
            {
                txtTitle8.Focus();
                return;
            }
            else if (txtTitle8.Text == "" && txtCompany8.Text == "" ){
                if (txtStartDate8.Text != "" || txtEndDate8.Text != "" || txtAchievement8.Text != "")
                { 
                    txtTitle8.Focus();
                return;
                }
            }
            if (txtTitle9.Text != "" && txtCompany9.Text == "")
            {
                txtCompany9.Focus();
                return;
            }
            else if (txtTitle9.Text == "" && txtCompany9.Text != "")
            {
                txtTitle9.Focus();
                return;
            }
            else if (txtTitle9.Text == "" && txtCompany9.Text == "" ){
                if (txtStartDate9.Text != "" || txtEndDate9.Text != "" || txtAchievement9.Text != "")
                { 
                    txtTitle9.Focus();
                return;
            }
            }
            if (txtTitle10.Text != "" && txtCompany10.Text == "")
            {
                txtCompany10.Focus();
                return;
            }
            else if (txtTitle10.Text == "" && txtCompany10.Text != "")
            {
                txtTitle10.Focus();
                return;
            }
            else if (txtTitle10.Text == "" && txtCompany10.Text == "" ){
                if (txtStartDate10.Text != "" || txtEndDate10.Text != "" || txtAchievement10.Text != "")
                { 
                    txtTitle10.Focus();
                return;
            }
            }
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
            

        }

        protected void btnAddJop1_Click(object sender, EventArgs e)
        {
            if (PreviousJop.Visible == false)
                PreviousJop.Visible = true;
           else if (PreviousJop1.Visible == false)
                PreviousJop1.Visible = true;
            else if (PreviousJop3.Visible == false)
                PreviousJop3.Visible = true;
            else if (PreviousJop2.Visible == false)
                PreviousJop2.Visible = true;
            else if (PreviousJop3.Visible == false)
                PreviousJop3.Visible = true;
            else if (PreviousJop4.Visible == false)
                PreviousJop4.Visible = true;
            else if (PreviousJop5.Visible == false)
                PreviousJop5.Visible = true;
            else if (PreviousJop6.Visible == false)
                PreviousJop6.Visible = true;
            else if (PreviousJop7.Visible == false)
                PreviousJop7.Visible = true;
            else if (PreviousJop8.Visible == false)

            {
                PreviousJop8.Visible = true;
                btnAddJop1.Visible = false;
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        //protected void btnOK_Click(object sender, EventArgs e)
        //{

        //}
    }
}