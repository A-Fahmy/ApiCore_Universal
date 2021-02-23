using BTS.Business;
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
    public partial class CustomNotification : System.Web.UI.Page
    {

        #region Properties

         static List<Contact> lstContact;
        static List<Contact> lstFilteredContact;
        static List<Contact> lstExactContact;
        static List<Book> lstBook;
        static List<Book> lsFilteredtBook;
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

        protected void rbl_SendingOptions_SelectedItemChanged(object sender, EventArgs e)
        {
            if (rbl_SendingOptions.SelectedItem.Text == "All")
            {
                lstFilteredContact = lstContact;
                divExp.Visible = false;
                divCity.Visible = true;
                divAddContacts.Visible = false;
                DuePayments.Visible = false;
            }

            else if (rbl_SendingOptions.SelectedItem.Text == "All RCC")
            {
                lstFilteredContact = lstContact.Where(x => x.RCC != null && x.RCC.Value).ToList();
                divExp.Visible = true;
                divCity.Visible = true;
                divAddContacts.Visible = false;
                DuePayments.Visible = false;
            }

            else if (rbl_SendingOptions.SelectedItem.Text == "All RUC")
            {
                lstFilteredContact = lstContact.Where(x => x.RUC != null && x.RUC.Value).ToList();
                divExp.Visible = false;
                divCity.Visible = true;
                divAddContacts.Visible = false;
                DuePayments.Visible = false;
            }
            else if (rbl_SendingOptions.SelectedItem.Text == "Exact Contact")
            {
                divExp.Visible = false;
                divCity.Visible = false;
                divAddContacts.Visible = true;
                DuePayments.Visible = false;
                LoadContactList();
                lstExactContact = new List<Contact>();
            }

            else
            {
                divCity.Visible = true;
                divAddContacts.Visible = false;
                DuePayments.Visible = true;
                LoadBookingData();
            }
        }

        protected void btnSendNotification_Click(object sender, EventArgs e)
        {
            Entities.CustomNotification customNotification = new Entities.CustomNotification();
            customNotification.Message = txtNotificationDescription.Text;
            customNotification.Date = System.DateTime.Now;
            if (rbl_SendingOptions.SelectedItem.Text == "All")
            {
                if (ddlCity.SelectedValue != string.Empty)
                    lstFilteredContact = lstFilteredContact.Where(x => x.CityCode != null && x.CityCode == int.Parse(ddlCity.SelectedValue)).ToList();
                if (lstContact.Count > 0)
                {
                    customNotification.TargetUsers = "All";
                    customNotification.IsActive = true;
                    CustomNotificationServiceManager.Insert(customNotification);
                }
                for (int i = 0; i < lstContact.Count; i++)
                {
                    FCM.SendNotification("A", lstContact[i].Code, 0, 0, txtNotificationDescription.Text);
                }
            }

            else if (rbl_SendingOptions.SelectedItem.Text == "All RCC")
            {
                lstFilteredContact = lstFilteredContact.Where(x => x.RCC != null && x.RCC.Value == true).ToList();
                if (ddlCity.SelectedValue != string.Empty)
                    lstFilteredContact = lstFilteredContact.Where(x => x.CityCode != null && x.CityCode == int.Parse(ddlCity.SelectedValue)).ToList();
                if (lstFilteredContact.Count > 0)
                {
                    customNotification.TargetUsers = "All RCC";
                    customNotification.IsActive = true;
                    CustomNotificationServiceManager.Insert(customNotification);
                }
                for (int i = 0; i < lstFilteredContact.Count; i++)
                {
                    FCM.SendNotification("A", lstFilteredContact[i].Code, 0, 0, txtNotificationDescription.Text);
                }
            }

            else if (rbl_SendingOptions.SelectedItem.Text == "All RUC")
            {
                lstFilteredContact = lstFilteredContact.Where(x => x.RUC != null && x.RUC.Value == true).ToList();
                if (ddlCity.SelectedValue != string.Empty)
                    lstFilteredContact = lstFilteredContact.Where(x => x.CityCode != null && x.CityCode == int.Parse(ddlCity.SelectedValue)).ToList();
                if (lstFilteredContact.Count > 0)
                {
                    customNotification.TargetUsers = "All RUC";
                    customNotification.IsActive = true;
                    CustomNotificationServiceManager.Insert(customNotification);
                }
                for (int i = 0; i < lstFilteredContact.Count; i++)
                {
                    FCM.SendNotification("A", lstFilteredContact[i].Code, 0, 0, txtNotificationDescription.Text);
                }
            }
            else if (rbl_SendingOptions.SelectedItem.Text == "Exact Contact")
            {
                if (lstExactContact.Count > 0)
                {
                    customNotification.TargetUsers = "Due Payments";
                    customNotification.IsActive = true;
                    CustomNotificationServiceManager.Insert(customNotification);
                }
                for (int i = 0; i < lstExactContact.Count; i++)
                {
                    FCM.SendNotification("A", lstExactContact[i].Code, 0, 0, txtNotificationDescription.Text);
                }

            }

            else
            {
                if (lsFilteredtBook.Count > 0)
                {
                    customNotification.TargetUsers = "Exact Contact";
                    customNotification.IsActive = true;
                    CustomNotificationServiceManager.Insert(customNotification);
                }
                for (int i = 0; i < lsFilteredtBook.Count; i++)
                {
                    FCM.SendNotification("A", lsFilteredtBook[i].RUCContactCode.Value, 0, 0, txtNotificationDescription.Text);
                }

            }
        }

        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
            Contact DeletedContact = lstExactContact.Where(x => x.Code == SelectedItemID).FirstOrDefault();
            lstExactContact.Remove(DeletedContact);
            gvData.DataSource = lstExactContact;
            gvData.DataBind();
        }

        protected void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
            Book DeletedContact = lstBook.Where(x => x.Code == SelectedItemID).FirstOrDefault();
            lstBook.Remove(DeletedContact);
            gvBookingData.DataSource = lstBook;
            gvBookingData.DataBind();
        }



        protected void ddlExpertise_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              List<Contact> lstExpContact = ContactBusiness.ExcGetContact_by_ParentExpCode(int.Parse(ddlExpertise.SelectedValue));
                lstFilteredContact = (from L1 in lstFilteredContact
                                      join L2 in lstExpContact
                                      on L1.Code equals L2.Code
                                      select new Contact
                                      {
                                          ContactKeyEmail = L1.ContactKeyEmail,
                                          Code =L1.Code,
                                          Title = L1.Title,
                                          FirstName = L1.FirstName,
                                          MiddleName = L1.MiddleName,
                                          LastName = L1.LastName,
                                          MoblieNo = L1.MoblieNo,
                                          PhoneNo = L1.PhoneNo,
                                          CityCode = L1.CityCode,
                                          Area = L1.Area,
                                          Address = L1.Address,
                                          BankCode = L1.BankCode,
                                          BankAccountNo = L1.BankAccountNo,
                                          CompanyName = L1.CompanyName,
                                          CompanyAddress = L1.CompanyAddress,
                                          UserName = L1.UserName,
                                          Password = L1.Password,
                                          ID_Type = L1.ID_Type,
                                          NationalID = L1.NationalID,
                                          BirthDate = L1.BirthDate,
                                          RCC = L1.RCC,
                                          RUC = L1.RUC,
                                          IsSuspended = L1.IsSuspended,
                                          OTPCode = L1.OTPCode,
                                          OTPVerify = L1.OTPVerify,
                                          CreationDate = L1.CreationDate,
                                          BankBranchCode = L1.BankBranchCode,
                                          BankAccountName = L1.BankAccountName,
                                          FCM_Token = L1.FCM_Token,
                                          ShowProfilePhoto = L1.ShowProfilePhoto,
                                          Rating = L1.Rating,
                                          CountRootExpertise = L1.CountRootExpertise,
                                          GraduationDate = L1.GraduationDate,
                                          IsActive = L1.IsActive,
                                          Company = L1.Company,
                                          RV_Number = L1.RV_Number
                                      }).ToList();

                lstFilteredContact = lstFilteredContact.GroupBy(x => x.Code).Select(x => x.First()).ToList();

            }
            catch (Exception exc)
            {

            }
        }

       
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCity.SelectedItem.Text == string.Empty)
                {
                    lsFilteredtBook = lstBook;
                    return;
                }
                if (lstBook != null && lstBook.Count > 0)
                {
                    lsFilteredtBook = lstBook.Where(x =>x.Address!=null && x.Address.Contains(ddlCity.SelectedItem.Text)).ToList();
                    gvBookingData.DataSource = lsFilteredtBook;
                    gvBookingData.DataBind();
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void dtSelectedChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstBook != null && lstBook.Count > 0)
                {
                    lsFilteredtBook = lstBook.Where(x =>  x.BookDate.Value.Date == dtBookingDate.Value).ToList();
                    gvBookingData.DataSource = lsFilteredtBook;
                    gvBookingData.DataBind();
                }

            }
            catch (Exception exc)
            {

            }
        }
        

        protected void ddlContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Contact ExactContact = lstContact.Where(x => x.UserName == ddlContact.SelectedItem.Text).FirstOrDefault();
                lstExactContact.Add(ExactContact);
                gvData.DataSource = lstExactContact;
                gvData.DataBind();
            }
            catch (Exception exc)
            {

            }
        }

        #endregion


        #region Methods

        private void LoadItems()  
        {
            lstContact = ContactServiceManager.GetAll();
            lstFilteredContact = lstContact;
            ddlExpertise.DataSource = Lookup_ExpertisesServiceManager.GetKeyValueList(CommonSettings.Languages.English);
            ddlExpertise.DataBind();
            ddlExpertise.Items.Insert(0, new ListItem("-- Select --", ""));


            ddlCity.DataSource = Lookup_CitiesServiceManager.GetAll();
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("-- Select --", ""));

        }

        private void LoadContactList()
        {
            List<string> lstUsername = lstContact.Where(x=>x.UserName!=null && x.FCM_Token!=null).Select(x => x.UserName).ToList();
            ddlContact.DataSource = lstUsername;
            ddlContact.DataBind();
            ddlCity.Items.Insert(0, new ListItem("-- Select --", ""));
        }

        private void LoadBookingData()
        {
            lstBook = Booking_ServiceManager.GetByBookinStatus("ConfirmedPayed");
            gvBookingData.DataSource = lstBook;
            gvBookingData.DataBind();
        }

        #endregion
    }
}