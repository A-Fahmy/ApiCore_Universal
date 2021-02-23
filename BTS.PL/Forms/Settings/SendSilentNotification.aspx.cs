using BTS.Entities;
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
    public partial class SendSilentNotification : System.Web.UI.Page
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
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            List<Contact> contacts = new List<Contact>();
            contacts = ContactServiceManager.GetAll();
            SendNotification_ListContact(contacts);
            btnSync.Enabled = true;
        }


        public void SendNotification_ListContact(List<Contact>ContactList)
        {
            List<Contact> RemainContactList = ContactList;
            Sync_Flag sync_Flag = Sync_FlagServiceManager.GetAll().FirstOrDefault();
            sync_Flag.Lookup_Version = sync_Flag.Lookup_Version + 1;
            Sync_FlagServiceManager.Update(sync_Flag);
            try
            {

                foreach (var item in ContactList)
                {
                    if (item.FCM_Token != null)
                    {
                        RemainContactList.Remove(item);
                        //string LegacyServerkey = "AIzaSyBo_VLozqIG-xQ0uptgD-LIpcv6X-AjvlE";
                        //string WebAPIKey = "AIzaSyCLsnpqG8VtEWOccuvSOaaXg3zXsDU64Zo";
                        string LegacyServerkey = "AIzaSyCghyOVe_Msy0rfrCgmMvkI12hbkOdINmI";
                        string WebAPIKey = "AIzaSyCyoCIcbvpR2S-FpYYBmRQuujMmnf2pQXE";
                        string _FCM_Token = item.FCM_Token;
                        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        tRequest.ContentType = "application/json";
                        var data = new
                        {
                            to = _FCM_Token,
                            data = new
                            {
                                body = "",
                                Notification_Type = "Sync",
                                Notification_detail = "",
                                BookingCode = "",
                                OnDay = "false",
                                NotificationStatusCode = 0,
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
            }


            catch (Exception exc)
            {
                SendNotification_ListContact(RemainContactList);
            }

        }
    }
}