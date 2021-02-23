using BTS.Entities;
using BTS.Entities.Views;
using BTS.ServiceManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTS.PL.Forms.Settings
{
    public partial class ContactForm : System.Web.UI.Page
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

        static List<Contact> ContactList;
        static List<Contact> FilteredContactList;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ChkIsActive.Checked)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlertPopUp();", true);
                    return;
                }

                SetObject();

                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }


        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                Contact obj = ContactServiceManager.GetByCode(SelectedItemID.Value);
                ChkIsActive.Enabled = true;
                ChkIsValidPhoneNumberYN.Enabled = true;
                txtRating.Text = obj.Rating.ToString();
                txtRootExp_Number.Text = obj.CountRootExpertise.ToString();
                if(obj.IsActive==null)
                   ChkIsActive.Checked =false;
                else
                    ChkIsActive.Checked = obj.IsActive.Value;

                if (obj.IsValidPhoneNumberYN == null)
                    ChkIsValidPhoneNumberYN.Checked = false;
                else
                    ChkIsValidPhoneNumberYN.Checked = obj.IsValidPhoneNumberYN.Value;

                if (obj.RiseCertifyYN == null)
                    ChkRiseCertified.Checked = false;
                else
                    ChkRiseCertified.Checked = obj.RiseCertifyYN.Value;
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
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

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
                ContactServiceManager.Delete(SelectedItemID);

                LoadItems();
            }
            catch (Exception exc)
            {

            }
        }

        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }

        protected void cbxSelectedItemIsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cbxSelectedItem = (CheckBox)sender;
                int SelectedID = int.Parse(cbxSelectedItem.Attributes["SelectedID"]);

                //Get the selected item
                Contact SelectedObj = ContactServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                ContactServiceManager.Update(SelectedObj);
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnSearch_Click(object obj, EventArgs e)
        {
            try
            {
                if (txtFromContactCode.Text == "" || txtToContactCode.Text == "")
                {
                    LoadItems();
                }

               else  if (int.Parse(txtFromContactCode.Text) == 0 || int.Parse(txtFromContactCode.Text) > int.Parse(txtToContactCode.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Range');", true);
                }

                else
                {
                    Contact FirstContact = FindNearsetContactAcs(int.Parse(txtFromContactCode.Text));
                    Contact LastContact = FindNearsetContactDes(int.Parse(txtToContactCode.Text));
                    if (FirstContact == null || LastContact == null || FirstContact.Code == 0 || LastContact.Code == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No data found');", true);
                        return;
                    }
                    //int Count = int.Parse(txtToContactCode.Text) - int.Parse(txtFromContactCode.Text) + 1;
                    //if (Count > ContactList.Count)
                    //{
                    //    Count = ContactList.Count;
                    //}
                    int Index1 = ContactList.IndexOf(FirstContact);
                    int Index2 = ContactList.IndexOf(LastContact);
                    FilteredContactList = ContactList.GetRange(Index2, Index1 - Index2 + 1);
                    gvData.DataSource = FilteredContactList;
                    gvData.DataBind();
                }
            }

            catch (Exception exc)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(" + exc.Message + ");", true);
            }

        }
        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvData.PageIndex = e.NewPageIndex;
            if (FilteredContactList == null)
            {
                gvData.DataSource = ContactList;
                gvData.DataBind();
            }
            else
            {
                gvData.DataSource = FilteredContactList;
                gvData.DataBind();
            }
        }

        #endregion

        #region Methods
        private void LoadItems()
        {
            ContactList = ContactServiceManager.GetAll();
            ContactList.Where(x => x.IsActive == null);
            ContactList.Where(x=>x.IsActive==null).ToList().ForEach(x => x.IsActive = false);
            ContactList.Where(x => x.IsValidPhoneNumberYN == null).ToList().ForEach(x => x.IsValidPhoneNumberYN = false);
            ContactList.Where(x => x.RiseCertifyYN == null).ToList().ForEach(x => x.RiseCertifyYN = false);

            ContactList.Reverse();
            //List<Contact> Last50Contact = ContactList.Skip(Math.Max(0, ContactList.Count() - 50)).ToList();
            //gvData.DataSource = Last50Contact;
            gvData.DataSource = ContactList;
            gvData.DataBind();
        }

        private void SetObject()
        {
            Contact SelectedObj = ContactServiceManager.GetByCode(this.SelectedItemID.Value);

            SelectedObj.CountRootExpertise = txtRootExp_Number.Text==""?0: int.Parse(txtRootExp_Number.Text);
            SelectedObj.Rating = txtRating.Text==""?0: decimal.Parse(txtRating.Text);
            SelectedObj.IsActive = ChkIsActive.Checked;
            SelectedObj.IsValidPhoneNumberYN = ChkIsValidPhoneNumberYN.Checked;
            SelectedObj.RiseCertifyYN = ChkRiseCertified.Checked;
            ContactServiceManager.Update(SelectedObj);
            SendNotification_ListContact(SelectedObj);
        }

        public Contact FindNearsetContactAcs(int ContactCode)
        {
            int MaxCode =  ContactList.Max(x => x.Code);
            if (ContactCode > MaxCode)
                return new Contact();
            Contact FirstContact = ContactList.FirstOrDefault(x => x.Code == ContactCode);
            if (FirstContact != null)
                return FirstContact;
            else
                return FindNearsetContactAcs(ContactCode + 1);
        }


        public Contact FindNearsetContactDes(int ContactCode)
        {
            if (ContactCode < 0)
                return new Contact();
            Contact FirstContact = ContactList.FirstOrDefault(x => x.Code == ContactCode);
            if (FirstContact != null)
                return FirstContact;
            else
                return FindNearsetContactDes(ContactCode - 1);
        }

        #endregion

        protected void cbxSelectedItemIsValidPhoneNumberYN_CheckedChanged(object sender, EventArgs e)
        {

        }
        public static  void SendNotification_ListContact(Contact ContactList)
        {
            try
            {
                    if (ContactList.FCM_Token != null)
                    {
                        string LegacyServerkey = "AIzaSyCghyOVe_Msy0rfrCgmMvkI12hbkOdINmI";
                        string WebAPIKey = "AIzaSyCyoCIcbvpR2S-FpYYBmRQuujMmnf2pQXE";
                        string _FCM_Token = ContactList.FCM_Token;
                        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        tRequest.ContentType = "application/json";
                        var data = new
                        {
                            to = _FCM_Token,
                            data = new
                            {
                                body = "",
                                Notification_Type = "C",
                                Notification_detail = "",
                                NotificationStatusCode = 0,
                                BookingCode = "",
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
        public List<View_KeyValueLookup> GetAll_AlternativeTypes()
        {
            try
            {
                return alternativeTypeServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        protected void btnAlternative_Click(object sender, ImageClickEventArgs e)
        {
            this.SelectedItemID = int.Parse(((ImageButton)sender).Attributes["SelectedID"]);
            Contact obj = ContactServiceManager.GetByCode(SelectedItemID.Value);
            string mail = obj.ContactKeyEmail;
            List<alternativeContact> objs = alternativeContactServiceManager.GetAll().FindAll(x=>x.ContactKeyEmail == mail);
           // List<alternativeType> types = alternativeTypeServiceManager.GetAll();
            GVAlternative.DataSource = objs;
            GVAlternative.DataBind();
            
            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlternativeForm();", true);

        }
    }
}