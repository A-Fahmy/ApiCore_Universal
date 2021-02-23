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
    public partial class SpecialExpertisePackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                string _Path = Request.QueryString["Path"];
                string _Code = Request.QueryString["Code"];
                txtContact.Text = _Code;
                txtContact.Enabled = false;
                string userID = "RC" + _Code;
                // SpecialExpertise obj = SpecialExpertiseServiceManager.GetByUserCode(int.Parse(_Code));
                List<View_Contact_Expertise> Lts_AllExpertise = Contact_ExpertiseServiceManager.ExcPro_GetAllSpecialExpertiseByContactCode(int.Parse(txtContact.Text));
                List<View_Contact_Expertise> Lts_AllExpertise_ISActive = Lts_AllExpertise.FindAll(x => x.SpacialCost != 0 );
                if (Lts_AllExpertise_ISActive == null || Lts_AllExpertise_ISActive.Count == 0)
                {
                    View_Contact_Expertise _NewTemp = new View_Contact_Expertise();
                    Lts_AllExpertise_ISActive.Add(_NewTemp);
                }

                Session["Lts_Expertise"] = Lts_AllExpertise_ISActive;
                Grid_Exp.DataSource = Lts_AllExpertise_ISActive;
                Grid_Exp.DataBind();
                List<Lookup_Expertises> _Expertises = Lookup_ExpertisesServiceManager.GetAll();
                List<Lookup_Expertises> Expertises = _Expertises.FindAll(X => X.ParentExpertiseCode == 0);

                List<View_KeyValueLookup> ddlExpertise = new List<View_KeyValueLookup>();

                foreach(Lookup_Expertises ddlobj in Expertises)
                {
                
                    View_KeyValueLookup view_KeyValueLookup = new View_KeyValueLookup();
                    view_KeyValueLookup.Code = ddlobj.Code;
                    view_KeyValueLookup.Name = ddlobj.ExpertiseNameEN;
                    ddlExpertise.Add(view_KeyValueLookup);
                }

                ddlExpertiseLevel1.DataSource = ddlExpertise;
                ddlExpertiseLevel1.DataBind();
                ddlExpertiseLevel1.Items.Insert(0, new ListItem("-- Select --", ""));

                ddlExpertiseLevel2.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlExpertiseLevel3.Items.Insert(0, new ListItem("-- Select --", ""));
                ddlExpertiseLevel4.Items.Insert(0, new ListItem("-- Select --", ""));

                ddlExpertiseLevel2.Visible = false;
                ddlExpertiseLevel3.Visible = false;
                ddlExpertiseLevel4.Visible = false;
                ddlExpertiseLevel5.Visible = false;
                List<Contact> contact = ContactServiceManager.GetCOntactByUserName(userID);
                lblCount.Text = " "+" Counter : "+contact[0].CounterSpecialExpertise.ToString()+" Requests";
                if (contact[0].CounterSpecialExpertise == 0)
                    btnSubmit.Enabled = false;
                if (_Path == "1")
                {
                    btnCancel.Visible = false;
                    btnSave.Visible = false;
                    btnSubmit.Visible = false;
                    PanTemplate.Visible = false;
                    PanRCL.Visible = false;
                    divCost.Visible = false;
                    btnAdd.Visible = false;
                    btnCancel2.Visible = false;
                    lblCount.Visible = false;
                    List<FeaturedExpertise> featuredExpertise = FeaturedExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.SubmitYN == true).ToList();
                    List<View_Contact_Expertise> Lts_AllExpertiseCh = Contact_ExpertiseServiceManager.ExcPro_GetAllSpecialExpertiseByContactCode(int.Parse(txtContact.Text));
                    List<View_Contact_Expertise> Lts_AllExpertise_ISActiveCh = new List<View_Contact_Expertise>();
                    View_Contact_Expertise view_Contact_Expertise = new View_Contact_Expertise();
                    foreach (FeaturedExpertise obj in featuredExpertise)
                    {
                        view_Contact_Expertise = Lts_AllExpertise.Find(x => x.ExpertiseRCLCode == obj.RCLCode);
                        Lts_AllExpertise_ISActiveCh.Add(view_Contact_Expertise);
                    }
                    if (Lts_AllExpertise_ISActiveCh == null || Lts_AllExpertise_ISActiveCh.Count == 0)
                    {
                        View_Contact_Expertise _NewTemp = new View_Contact_Expertise();
                        Lts_AllExpertise_ISActiveCh.Add(_NewTemp);
                    }

                    Session["Lts_Expertise"] = Lts_AllExpertise_ISActiveCh;
                    Grid_Exp.DataSource = Lts_AllExpertise_ISActiveCh;
                    Grid_Exp.DataBind();
                }
                else
                {
                    PanTemplate.Visible = false;
                    PanRCL.Visible = false;
                    divCost.Visible = false;
                }
              

            }
        }

      private decimal CostValidation()
        {
            int RCLCode = RCL();
            Lookup_ExpertiseRCL obj = Lookup_ExpertiseRCLServiceManager.GetByCode(RCLCode);
            int expertiseCode = obj.ExpertiseCode;
            List<Lookup_ExpertiseRCL> lst = Lookup_ExpertiseRCLServiceManager.GetAll().FindAll(x => x.ExpertiseCode == expertiseCode && x.RCLCode != 13);
            decimal Cost = lst.Min(x => x.Cost);
            return Cost;
        }
        private int RCL()
        {
            int RCL;
            if (ddlExpertiseLevel4.SelectedValue != null && ddlExpertiseLevel4.SelectedValue != "")
                RCL = int.Parse(ddlExpertiseLevel4.SelectedValue);
            else if (ddlExpertiseLevel3.SelectedValue != null && ddlExpertiseLevel3.SelectedValue != "")
                RCL = int.Parse(ddlExpertiseLevel3.SelectedValue);
            else if (ddlExpertiseLevel2.SelectedValue != null && ddlExpertiseLevel2.SelectedValue != "")
                RCL = int.Parse(ddlExpertiseLevel2.SelectedValue);
            else if (ddlExpertiseLevel1.SelectedValue != null && ddlExpertiseLevel1.SelectedValue != "")
                RCL = int.Parse(ddlExpertiseLevel1.SelectedValue);
            else
            { 
            return 0;
            }
            List<Lookup_ExpertiseRCL> lst = Lookup_ExpertiseRCLServiceManager.GetAll();
            Lookup_ExpertiseRCL obj = lst.Find(x => x.ExpertiseCode == RCL && x.RCLCode == 13);
            if (obj == null)
            {
                Lookup_ExpertiseRCL _expertiseRCL = new Lookup_ExpertiseRCL();
                _expertiseRCL.ExpertiseCode = RCL;
                _expertiseRCL.IsActive = true;
                _expertiseRCL.RCLCode = 13;
                _expertiseRCL.Cost = 0;
                RCL = Lookup_ExpertiseRCLServiceManager.Insert(_expertiseRCL);
                //  ExpertiseRCLCode = _expertiseRCL.Code.ToString();
            }
            else
            {
                RCL = obj.Code;
            }
            return RCL;
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int RCLCode = RCL();
           
            FeaturedExpertise obj = FeaturedExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode==RCLCode).FirstOrDefault();
            //FeaturedExpertise obj = new FeaturedExpertise();
          
            if (obj == null)
            {
                btnSave.Visible = true;
                btnSubmit.Visible = true;
            
            }
            else
            {
                txtDurationEX.Text = obj.DurationOfExpertise;
                txtLevelEX.Text = obj.LevelOfExpertise;
                txtMore.Text = obj.Info;
                txtOnline.Text = obj.FoundOnline;
                txtOthers.Text = obj.Others;
                txtPublicPerson.Text = obj.PublicPerson;
                txtRecognition.Text = obj.SpecialRecogintion;
                txtRelation.Text = obj.Relations;
                txtTilte.Text = obj.Title;
                txtTypeEX.Text = obj.TypeOfExpertise;
                txtContact.Text = obj.ContactCode.ToString();
                txtCost.Text = obj.Cost.ToString();
                if(obj.SubmitYN==true)
                {
                    btnSubmit.Visible = false;
                    btnSave.Visible = false;
                    divSubmited.Visible = true;
                    lblMessage.Text = "You Will Lose the Submit";
                }
            }


            //if (txtCost.Text == null || txtCost.Text == "")
            //{
            //    lblMessage.Text = "Please Enter Your Feeze";
            //    return;

            //}
            if (ddlExpertiseLevel1.SelectedValue == null || ddlExpertiseLevel1.SelectedValue == "")
                return;
            if(ddlExpertiseLevel2.Visible == true)
            {
                if (ddlExpertiseLevel2.SelectedValue == null || ddlExpertiseLevel2.SelectedValue == "")
                    return;
            }
            if (ddlExpertiseLevel3.Visible == true)
            {
                if (ddlExpertiseLevel3.SelectedValue == null || ddlExpertiseLevel3.SelectedValue == "")
                    return;
            }
            if (ddlExpertiseLevel4.Visible == true)
            {
                if (ddlExpertiseLevel4.SelectedValue == null || ddlExpertiseLevel4.SelectedValue == "")
                    return;
            }
            PanRCL.Visible = false;
            PanTemplate.Visible = true;
            divCost.Visible = false;
            PanGrid.Visible = false;
        }

        protected void ddlExpertiseLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlExpertiseLevel2.Visible = true;
            int Selected = int.Parse(ddlExpertiseLevel1.SelectedValue);
            List<Lookup_Expertises> _Expertises = Lookup_ExpertisesServiceManager.GetAll();
            List<Lookup_Expertises> Expertises = _Expertises.FindAll(X => X.ParentExpertiseCode == Selected);

            List<View_KeyValueLookup> ddlExpertise = new List<View_KeyValueLookup>();

            foreach (Lookup_Expertises ddlobj in Expertises)
            {

                View_KeyValueLookup view_KeyValueLookup = new View_KeyValueLookup();
                view_KeyValueLookup.Code = ddlobj.Code;
                view_KeyValueLookup.Name = ddlobj.ExpertiseNameEN;
                ddlExpertise.Add(view_KeyValueLookup);
            }

            ddlExpertiseLevel2.DataSource = ddlExpertise;
            ddlExpertiseLevel2.DataBind();
            ddlExpertiseLevel2.Items.Insert(0, new ListItem("-- Select --", ""));

        

        }
        

        protected void ddlExpertiseLevel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlExpertiseLevel2.SelectedValue!=null)
            { 
            int Selected = int.Parse(ddlExpertiseLevel2.SelectedValue);
            List<Lookup_Expertises> _Expertises = Lookup_ExpertisesServiceManager.GetAll();
            List<Lookup_Expertises> Expertises = _Expertises.FindAll(X => X.ParentExpertiseCode == Selected);

            List<View_KeyValueLookup> ddlExpertise = new List<View_KeyValueLookup>();

            foreach (Lookup_Expertises ddlobj in Expertises)
            {

                View_KeyValueLookup view_KeyValueLookup = new View_KeyValueLookup();
                view_KeyValueLookup.Code = ddlobj.Code;
                view_KeyValueLookup.Name = ddlobj.ExpertiseNameEN;
                ddlExpertise.Add(view_KeyValueLookup);
            }

            ddlExpertiseLevel3.DataSource = ddlExpertise;
            ddlExpertiseLevel3.DataBind();

            ddlExpertiseLevel3.Items.Insert(0, new ListItem("-- Select --", ""));
            }
        }

        protected void ddlExpertiseLevel3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int Selected = int.Parse(ddlExpertiseLevel3.SelectedValue);
            List<Lookup_Expertises> _Expertises = Lookup_ExpertisesServiceManager.GetAll();
            List<Lookup_Expertises> Expertises = _Expertises.FindAll(X => X.ParentExpertiseCode == Selected);

            List<View_KeyValueLookup> ddlExpertise = new List<View_KeyValueLookup>();

            foreach (Lookup_Expertises ddlobj in Expertises)
            {

                View_KeyValueLookup view_KeyValueLookup = new View_KeyValueLookup();
                view_KeyValueLookup.Code = ddlobj.Code;
                view_KeyValueLookup.Name = ddlobj.ExpertiseNameEN;
                ddlExpertise.Add(view_KeyValueLookup);
            }

            ddlExpertiseLevel4.DataSource = ddlExpertise;
            ddlExpertiseLevel4.DataBind();
            

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try { 
            string User = "RC" + txtContact.Text;

            List<Contact> _Contact = ContactServiceManager.GetCOntactByUserName(User);
            //if (_Contact[0].CounterSpecialExpertise > 0)
            //    _Contact[0].CounterSpecialExpertise--;
            //else
            //    return;
            int RCLCode = RCL();
            decimal Cost = CostValidation();
            FeaturedExpertise obj = FeaturedExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == RCLCode).FirstOrDefault();
            if(obj == null)
            { 
                btnSave_Click(null, null);
                if (txtCost.Text != "")
                {
                    if (decimal.Parse(txtCost.Text) < Cost)
                    {
                        lblMessage.Text = "Your Feeze must be more Than " + Cost + "LE";
                        return;
                    }
                    else if (decimal.Parse(txtCost.Text) > 25000)
                    {
                        lblMessage.Text = "Your Feeze must be less Than 25000 LE";
                        return;
                    }
                  
                }
                    obj = FeaturedExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == RCLCode).FirstOrDefault();
                obj.SubmitYN = true;
                Contact_Expertise _obj = Contact_ExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.ExpertiseRCLCode == RCLCode).FirstOrDefault();
                _Contact[0].CounterSpecialExpertise--;
                _obj.OldExpertiseRCLCode = 0;
                if(txtCost.Text!=null || txtCost.Text!="" || txtCost.Text!="0")
                { 
                Contact_ExpertiseServiceManager.Update(_obj);
                FeaturedExpertiseServiceManager.Update(obj);
                }
                else
                {
                    lblMessage.Text = "Please Enter Your Feeze";
                }
            }
            else
            {
                
                obj.SubmitYN = true;
                //obj.ExpertiseLevel5 = 1;
                Contact_Expertise _obj = Contact_ExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.ExpertiseRCLCode == RCLCode).FirstOrDefault();
                _Contact[0].CounterSpecialExpertise--;
                _obj.OldExpertiseRCLCode = 0;
                if (txtCost.Text != null || txtCost.Text != "" || txtCost.Text != "0")
                {
                    Contact_ExpertiseServiceManager.Update(_obj);
                    FeaturedExpertiseServiceManager.Update(obj);
                }
                else
                {
                    lblMessage.Text = "Please Enter Your Feeze";
                }
            }
          
            //List<Contact_CV> _CV = Contact_CVServiceManager.GetAll();
            //Contact_CV contact_CV = _CV.Find(x => x.ContactCode == int.Parse(txtContact.Text));
            //contact_CV.SpecialExpertiseInfo = txtMore.Text;
            //Contact_CVServiceManager.Update(contact_CV);


            ContactServiceManager.Update(_Contact[0]);
            ContactForm.SendNotification_ListContact(_Contact[0]);
            PanGrid.Visible = true;
            PanRCL.Visible = false;
            divCost.Visible = false;
            PanTemplate.Visible = false;
            divSubmited.Visible = false;
        

            List<Contact> contact = ContactServiceManager.GetCOntactByUserName(User);
            lblCount.Text = " " + " Counter : " + contact[0].CounterSpecialExpertise.ToString() + " Requests";

            List<View_Contact_Expertise> Lts_AllExpertise = Contact_ExpertiseServiceManager.ExcPro_GetAllSpecialExpertiseByContactCode(int.Parse(txtContact.Text));
            List<View_Contact_Expertise> Lts_AllExpertise_ISActive = Lts_AllExpertise.FindAll(x => x.SpacialCost != 0);
            if (Lts_AllExpertise_ISActive == null || Lts_AllExpertise_ISActive.Count == 0)
            {
                View_Contact_Expertise _NewTemp = new View_Contact_Expertise();
                Lts_AllExpertise_ISActive.Add(_NewTemp);
            }

            Session["Lts_Expertise"] = Lts_AllExpertise_ISActive;
            Grid_Exp.DataSource = Lts_AllExpertise_ISActive;
            Grid_Exp.DataBind();
            }
            catch (Exception exc)
            {
                lblMessage.Text = "Sorry ";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try { 
            string User = "RC" + txtContact.Text;
            List<FielsUpload> file = FielsUploadServiceManager.GetFielsUploadByUserID(User);
                foreach (FielsUpload fiels in file)
                {
                   fiels.SpecialExpertiseFirstYN = true;
                   // fiels.SpecialExpertiseYN = true;
                    FielsUploadServiceManager.Update(fiels);

                }
            decimal Cost = CostValidation();
            int RCLCode = RCL();

            Contact_Expertise contactExpertise = Contact_ExpertiseServiceManager.GetAll().Where(x=>x.ContactCode==int.Parse(txtContact.Text) && x.ExpertiseRCLCode == RCLCode).FirstOrDefault();
            if (contactExpertise == null)
            {
                contactExpertise = new Contact_Expertise();
                contactExpertise.ContactCode = int.Parse(txtContact.Text);
                if (txtCost.Text != "")
                {
                    if (decimal.Parse(txtCost.Text) < Cost)
                    {
                        lblMessage.Text = "Your Feeze must be more Than " + Cost + "LE";
                        return;
                    }
                    else if (decimal.Parse(txtCost.Text) > 25000)
                    {
                        lblMessage.Text = "Your Feeze must be less Than 25000 LE";
                        return;
                    }
                    else
                    {
                        contactExpertise.Cost = decimal.Parse(txtCost.Text);

                    }
                }
                else
                    contactExpertise.Cost = 1;

                contactExpertise.EntriyRootExpertise = 3;
                contactExpertise.ExpertiseRCLCode = RCLCode;
                contactExpertise.IsActive = false;
                Contact_ExpertiseServiceManager.Insert(contactExpertise);
            }
            else
            {
                contactExpertise.ContactCode = int.Parse(txtContact.Text);
                if (txtCost.Text != "")
                { 
                    if (decimal.Parse(txtCost.Text) < Cost)
                    {
                        lblMessage.Text = "Your Feeze must be more Than " + Cost + "LE";
                        return;
                    }
                    else if  (decimal.Parse(txtCost.Text) > 25000)
                    {
                        lblMessage.Text = "Your Feeze must be less Than 25000 LE";
                        return;
                    }
                    else
                    {
                        contactExpertise.Cost = decimal.Parse(txtCost.Text);

                    }
                }
                else
                    contactExpertise.Cost = 1;

              
                contactExpertise.EntriyRootExpertise = 3;
                contactExpertise.ExpertiseRCLCode = RCLCode;
                contactExpertise.IsActive = contactExpertise.IsActive;
                Contact_ExpertiseServiceManager.Update(contactExpertise);
            }

          
            //  List<FeaturedExpertise> lst = FeaturedExpertiseServiceManager.GetAll();
            //FeaturedExpertise obj = FeaturedExpertiseServiceManager.GetByUserCode(int.Parse(txtContact.Text));
            FeaturedExpertise obj = FeaturedExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == RCLCode).FirstOrDefault();

            if (obj == null)
            {
                FeaturedExpertise _obj = new FeaturedExpertise();
                _obj.ContactCode = int.Parse(txtContact.Text);
                _obj.DurationOfExpertise = txtDurationEX.Text;
                _obj.FoundOnline = txtOnline.Text;
                _obj.Info = txtMore.Text;
                _obj.LevelOfExpertise = txtLevelEX.Text;
                _obj.Others = txtOthers.Text;
                _obj.PublicPerson = txtPublicPerson.Text;
                _obj.Relations = txtRelation.Text;
                _obj.SpecialRecogintion = txtRecognition.Text;
                _obj.Title = txtTilte.Text;
                _obj.TypeOfExpertise = txtTypeEX.Text;
                if (txtCost.Text != "")
                    _obj.Cost = decimal.Parse(txtCost.Text);
                else
                    _obj.Cost = 1;
                _obj.RCLCode = RCLCode;
                _obj.SubmitYN = false;
                _obj.ExpertiseLevel1 = int.Parse(ddlExpertiseLevel1.SelectedValue);
                if (ddlExpertiseLevel2.SelectedValue!=null && ddlExpertiseLevel2.SelectedValue!="")
                _obj.ExpertiseLevel2 = int.Parse(ddlExpertiseLevel2.SelectedValue);
                if (ddlExpertiseLevel3.SelectedValue != null && ddlExpertiseLevel3.SelectedValue != "")
                    _obj.ExpertiseLevel3 = int.Parse(ddlExpertiseLevel3.SelectedValue);
                if (ddlExpertiseLevel4.SelectedValue != null && ddlExpertiseLevel4.SelectedValue != "")
                    _obj.ExpertiseLevel4 = int.Parse(ddlExpertiseLevel4.SelectedValue);
                FeaturedExpertiseServiceManager.Insert(_obj);
            }
            else
            {
                obj.ContactCode = int.Parse(txtContact.Text);
                obj.DurationOfExpertise = txtDurationEX.Text;
                obj.FoundOnline = txtOnline.Text;
                obj.Info = txtMore.Text;
                obj.LevelOfExpertise = txtLevelEX.Text;
                obj.Others = txtOthers.Text;
                obj.PublicPerson = txtPublicPerson.Text;
                obj.Relations = txtRelation.Text;
                obj.SpecialRecogintion = txtRecognition.Text;
                obj.Title = txtTilte.Text;
                obj.TypeOfExpertise = txtTypeEX.Text;
                if (txtCost.Text != "")
                    obj.Cost = decimal.Parse(txtCost.Text);
                else
                    obj.Cost = 1;
                obj.RCLCode = RCLCode;
                obj.SubmitYN = false;
                obj.ExpertiseLevel1 = int.Parse(ddlExpertiseLevel1.SelectedValue);
                if (ddlExpertiseLevel2.SelectedValue != null && ddlExpertiseLevel2.SelectedValue != "")
                    obj.ExpertiseLevel2 = int.Parse(ddlExpertiseLevel2.SelectedValue);
                if (ddlExpertiseLevel3.SelectedValue != null && ddlExpertiseLevel3.SelectedValue != "")
                    obj.ExpertiseLevel3 = int.Parse(ddlExpertiseLevel3.SelectedValue);
                if (ddlExpertiseLevel4.SelectedValue != null && ddlExpertiseLevel4.SelectedValue != "")
                    obj.ExpertiseLevel4 = int.Parse(ddlExpertiseLevel4.SelectedValue);
                FeaturedExpertiseServiceManager.Update(obj);
            }
            PanGrid.Visible = true;
            PanRCL.Visible = false;
            divCost.Visible = false;
            PanTemplate.Visible = false;
           
            List<View_Contact_Expertise> Lts_AllExpertise = Contact_ExpertiseServiceManager.ExcPro_GetAllSpecialExpertiseByContactCode(int.Parse(txtContact.Text));
            List<View_Contact_Expertise> Lts_AllExpertise_ISActive = Lts_AllExpertise.FindAll(x => x.SpacialCost != 0);
            if (Lts_AllExpertise_ISActive == null || Lts_AllExpertise_ISActive.Count == 0)
            {
                View_Contact_Expertise _NewTemp = new View_Contact_Expertise();
                Lts_AllExpertise_ISActive.Add(_NewTemp);
            }

            Session["Lts_Expertise"] = Lts_AllExpertise_ISActive;
            Grid_Exp.DataSource = Lts_AllExpertise_ISActive;
            Grid_Exp.DataBind();
            }
            catch(Exception exc)
            {
                lblMessage.Text = "Sorry ";
            }
            }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Code = txtContact.Text ;
            string userID = "RC" + Code;

            ddlExpertiseLevel1.SelectedValue = "";
            txtCost.Text = "";
            ddlExpertiseLevel2.Visible = false;
            txtDurationEX.Text = "";
            txtLevelEX.Text = "";
            txtMore.Text = "";
            txtOnline.Text = "";
            txtOthers.Text = "";
            txtPublicPerson.Text = "";
            txtRecognition.Text = "";
            txtRelation.Text = "";
            txtTilte.Text = "";
            txtTypeEX.Text = "";
            
            PanRCL.Visible = true;
            divCost.Visible = true;
            btnNext.Visible = true;
            PanGrid.Visible = false;
            PanTemplate.Visible = false;
            divChecker.Visible = false;
            divSubmited.Visible = false;
            Contact contact = ContactServiceManager.GetCOntactByUserName(userID).FirstOrDefault();
            if(contact.CounterSpecialExpertise == 0)
            {
                btnSubmit.Visible = false;
            }

        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
            {
            string _Path = Request.QueryString["Path"];
                int RCLExpertiseCode = int.Parse(((ImageButton)sender).CommandName);
            FeaturedExpertise obj = FeaturedExpertiseServiceManager.GetByCode(RCLExpertiseCode);
            FeaturedExpertiseLog log = FeaturedExpertiseLogServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == RCLExpertiseCode).FirstOrDefault();
            if (_Path == "1")
            {
                
                btnCancel.Visible = false;
                btnSave.Visible = false;
                btnSubmit.Visible = false;
                PanTemplate.Visible = true;
                PanGrid.Visible = false;
                PanRCL.Visible = true;
                divCost.Visible = false;
                txtCost.Visible = false;
                divSubmited.Visible = false;
                Contact_Expertise _obj = Contact_ExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.ExpertiseRCLCode == obj.RCLCode).FirstOrDefault();

                if (_obj.OldExpertiseRCLCode == 1)
                    divChecker.Visible = false;
                else
                    divChecker.Visible = true;
            }
            else
            {
                PanGrid.Visible = false;
                PanRCL.Visible = false;
                divCost.Visible = false;
                btnNext.Visible = false;
                PanTemplate.Visible = true;
                divChecker.Visible = false;
                if (obj.SubmitYN == true)
                {
                    btnSubmit.Visible = false;
                    btnSave.Visible = false;
                    lblMessage.Text = " You will Lose Your Featured Expertise";
                }
                else
                {
                    divSubmited.Visible = false;
                }
            }

            //obj.SubmitYN = false;
            
               
                ddlExpertiseLevel1.SelectedValue = obj.ExpertiseLevel1.ToString();
                if (obj.ExpertiseLevel2.ToString() != "" || obj.ExpertiseLevel2 != null)
                {
                    ddlExpertiseLevel1_SelectedIndexChanged(null, null);
                    ddlExpertiseLevel2.SelectedValue = obj.ExpertiseLevel2.ToString();
                    ddlExpertiseLevel2.Visible = true;
                }
                if (obj.ExpertiseLevel3.ToString() != "" || obj.ExpertiseLevel3 != null)
                {
                    ddlExpertiseLevel2_SelectedIndexChanged(null, null);
                    ddlExpertiseLevel3.SelectedValue = obj.ExpertiseLevel3.ToString();
                    ddlExpertiseLevel3.Visible = true;
                }
                if (obj.ExpertiseLevel4.ToString() != "" || obj.ExpertiseLevel4 != null)
                {
                    ddlExpertiseLevel3_SelectedIndexChanged(null, null);
                    ddlExpertiseLevel4.SelectedValue = obj.ExpertiseLevel4.ToString();
                    ddlExpertiseLevel4.Visible = true;
                }
            txtCost.Text = obj.Cost.ToString();
            if (log == null)
            { 
           
                txtDurationEX.Text = obj.DurationOfExpertise;
                txtLevelEX.Text = obj.LevelOfExpertise;
                txtMore.Text = obj.Info;
                txtOnline.Text = obj.FoundOnline;
                txtOthers.Text = obj.Others;
                txtPublicPerson.Text = obj.PublicPerson;
                txtRecognition.Text = obj.SpecialRecogintion;
                txtRelation.Text = obj.Relations;
                txtTilte.Text = obj.Title;
                txtTypeEX.Text = obj.TypeOfExpertise;
            }
            else
            {
                txtDurationEX.Text = log.DurationOfExpertise;
                txtLevelEX.Text = log.LevelOfExpertise;
                txtMore.Text = log.Info;
                txtOnline.Text = log.FoundOnline;
                txtOthers.Text = log.Other;
                txtPublicPerson.Text = log.PublicPerson;
                txtRecognition.Text = log.SpecialRecogination;
                txtRelation.Text = log.Relations;
                txtTilte.Text = log.Title;
                txtTypeEX.Text = log.TypeOfExpertise;
            }
            FeaturedExpertiseServiceManager.Update(obj);
          
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            //OldExpertiseRClCode used For 
            // If approved -> approve Button visiblity will be false
            int RCLCode = RCL();
            Contact_Expertise obj = Contact_ExpertiseServiceManager.GetAll().Where(x=>x.ContactCode == int.Parse(txtContact.Text) && x.ExpertiseRCLCode== RCLCode).FirstOrDefault();
            obj.IsActive = true;
            obj.OldExpertiseRCLCode = 1;
            Contact_ExpertiseServiceManager.Update(obj);
            string userId = "RC" + txtContact.Text;
           List< FielsUpload> file = FielsUploadServiceManager.GetFielsUploadByUserID(userId);
            foreach (FielsUpload fiels in file)
            {
                fiels.SpecialExpertiseYN = true;
                FielsUploadServiceManager.Update(fiels);
            }
            List<Contact_Expertise> _obj = Contact_ExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.Cost>0 && x.IsActive==false).ToList();
            if(_obj == null || _obj.Count == 0)
            {
                foreach (FielsUpload fiels in file)
                {
                    fiels.SpecialExpertiseFirstYN = false;
                    fiels.SpecialExpertiseYN = true;
                    FielsUploadServiceManager.Update(fiels);
                }
            }
            FeaturedExpertise featured = FeaturedExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == RCLCode).FirstOrDefault();
            FeaturedExpertiseLog log = FeaturedExpertiseLogServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == featured.Code).FirstOrDefault();
            if(log != null)
            { 
            featured.DurationOfExpertise = log.DurationOfExpertise;
            featured.FoundOnline = log.FoundOnline;
            featured.Info = log.Info;
            featured.LevelOfExpertise = log.LevelOfExpertise;
            featured.Others = log.Other;
            featured.PublicPerson = log.PublicPerson;
            featured.Relations = log.Relations;
            featured.SpecialRecogintion = log.SpecialRecogination;
            featured.Title = log.Title;
            featured.TypeOfExpertise = log.TypeOfExpertise;
            FeaturedExpertiseServiceManager.Update(featured);
                log.IsActive = false;
                FeaturedExpertiseLogServiceManager.Update(log);
            }
            //  Response.Redirect("/Forms/Settings/SpecialExpertisePackage.aspx?Code="+txtContact.Text+"&Path=1");

            //   ScriptManager.RegisterStartupScript(this, GetType(), "goBack", "window.history.go(-2);", true);
            ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-2);", true);

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string _Code = Request.QueryString["Code"];
            string UserId = "RC" + _Code;
            string password = Request.QueryString["Password"];

            Response.Redirect("/Forms/Settings/CheckDocument.aspx?UserID=" + UserId + "&Password=" + password);
        }

        protected void btncheck_Click(object sender, EventArgs e)
        {
            string User = "RC" + txtContact.Text;

            
            int RCLCode = RCL();
            Contact_Expertise contactExpertise = Contact_ExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.ExpertiseRCLCode == RCLCode).FirstOrDefault();

            FeaturedExpertise obj = FeaturedExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == RCLCode).FirstOrDefault();
            if(txtCost.Text!=obj.Cost.ToString() && txtDurationEX.Text == obj.DurationOfExpertise && txtLevelEX.Text == obj.LevelOfExpertise
                && txtMore.Text == obj.Info && txtOnline.Text == obj.FoundOnline && txtOthers.Text == obj.Others && txtPublicPerson.Text == obj.PublicPerson
                && txtRecognition.Text == obj.SpecialRecogintion && txtRelation.Text == obj.Relations && txtTilte.Text == obj.Title
                && txtTypeEX.Text == obj.TypeOfExpertise)

            {
                obj.Cost = decimal.Parse(txtCost.Text);
                contactExpertise.Cost= decimal.Parse(txtCost.Text);
               // obj.SubmitYN = true;
                FeaturedExpertiseServiceManager.Update(obj);
                Contact_ExpertiseServiceManager.Update(contactExpertise);
            }
            else
            {
                FeaturedExpertiseLog _obj = FeaturedExpertiseLogServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.RCLCode == obj.Code).FirstOrDefault();
                
                if (_obj == null)
                {
                    FeaturedExpertiseLog expertiseLog = new FeaturedExpertiseLog();
                    expertiseLog.DurationOfExpertise = txtDurationEX.Text;
                    expertiseLog.FoundOnline = txtOnline.Text;
                    expertiseLog.Info = txtMore.Text;
                    expertiseLog.LevelOfExpertise = txtLevelEX.Text;
                    expertiseLog.Other = txtOthers.Text;
                    expertiseLog.PublicPerson = txtPublicPerson.Text;
                    expertiseLog.Relations = txtRelation.Text;
                    expertiseLog.SpecialRecogination = txtRecognition.Text;
                    expertiseLog.Title = txtTilte.Text;
                    expertiseLog.TypeOfExpertise = txtTypeEX.Text;
                    expertiseLog.ContactCode = int.Parse(txtContact.Text);
                    expertiseLog.RCLCode = obj.Code;
                    expertiseLog.IsActive = true;
                    FeaturedExpertiseLogServiceManager.Insert(expertiseLog);
                }
                else
                {
                    _obj.DurationOfExpertise = txtDurationEX.Text;
                    _obj.FoundOnline = txtOnline.Text;
                    _obj.Info = txtMore.Text;
                    _obj.LevelOfExpertise = txtLevelEX.Text;
                    _obj.Other = txtOthers.Text;
                    _obj.PublicPerson = txtPublicPerson.Text;
                    _obj.Relations = txtRelation.Text;
                    _obj.SpecialRecogination = txtRecognition.Text;
                    _obj.Title = txtTilte.Text;
                    _obj.TypeOfExpertise = txtTypeEX.Text;
                    _obj.ContactCode = int.Parse(txtContact.Text);
                    _obj.RCLCode = obj.Code;
                    _obj.IsActive = true;
                    FeaturedExpertiseLogServiceManager.Update(_obj);
                }
                //obj.DurationOfExpertise = txtDurationEX.Text;
                //obj.FoundOnline = txtOnline.Text;
                //obj.Info = txtMore.Text;
                //obj.LevelOfExpertise = txtLevelEX.Text;
                //obj.Others = txtOthers.Text;
                //obj.PublicPerson = txtPublicPerson.Text;
                //obj.Relations = txtRelation.Text;
                //obj.SpecialRecogintion = txtRecognition.Text;
                //obj.Title = txtTilte.Text;
                //obj.TypeOfExpertise = txtTypeEX.Text;
                obj.Cost = decimal.Parse(txtCost.Text);
               // obj.SubmitYN = false;
                contactExpertise.Cost = decimal.Parse(txtCost.Text);
                contactExpertise.IsActive = true;
                contactExpertise.OldExpertiseRCLCode = 0;
                FeaturedExpertiseServiceManager.Update(obj);
                Contact_ExpertiseServiceManager.Update(contactExpertise);
                List<FielsUpload> file = FielsUploadServiceManager.GetFielsUploadByUserID(User);
                foreach (FielsUpload fiels in file)
                {
                    fiels.SpecialExpertiseFirstYN = true;
                    // fiels.SpecialExpertiseYN = true;
                    FielsUploadServiceManager.Update(fiels);

                }
            }
            PanGrid.Visible = true;
            PanRCL.Visible = false;
            divCost.Visible = false;
            PanTemplate.Visible = false;
        }

        protected void btndisabled_Click(object sender, EventArgs e)
        {
            int RCLCode = RCL();

            Contact_Expertise contactExpertise = Contact_ExpertiseServiceManager.GetAll().Where(x => x.ContactCode == int.Parse(txtContact.Text) && x.ExpertiseRCLCode == RCLCode).FirstOrDefault();
            contactExpertise.IsActive = false;
            contactExpertise.Cost = 0;
            Contact_ExpertiseServiceManager.Update(contactExpertise);
            PanGrid.Visible = true;
            PanRCL.Visible = false;
            divCost.Visible = false;
            PanTemplate.Visible = false;
        }
    }
}