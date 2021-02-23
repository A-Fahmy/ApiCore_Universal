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
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace BTS.PL.Forms.Settings
{
    public partial class CreateUser : System.Web.UI.Page
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
            List<View_KeyValueLookup> lstGroup = GroupServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
            ddlGroup.DataSource = lstGroup;
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, new ListItem("-- Select --", string.Empty));

            //Get the types
            List<User> lst = UserServiceManager.GetAll();
            gvGetAllData.DataSource = lst;
            gvGetAllData.DataBind();
        }
        protected void cbxSelectedItemIsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cbxSelectedItem = (CheckBox)sender;
                int SelectedID = int.Parse(cbxSelectedItem.Attributes["SelectedID"]);

                //Get the selected item
                User SelectedObj = UserServiceManager.GetByCode(SelectedID);
                SelectedObj.IsActive = cbxSelectedItem.Checked;
                UserServiceManager.Update(SelectedObj);
            }
            catch (Exception exc)
            {

            }
        }
        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedItemID = null;
                txtName.Text = txtmail.Text = txtPwd.Text = ddlGroup.SelectedValue = string.Empty;
                ChkIsActive.Checked = true;
                ChkIsActive.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);
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
                UserServiceManager.Delete(SelectedItemID);

                LoadItems();
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
                User obj = UserServiceManager.GetByCode(SelectedItemID.Value);
                //txt.Text = obj.Code.ToString();
                ddlGroup.SelectedValue = obj.GroupID.ToString();
                ChkIsActive.Enabled = true;
                txtName.Text = obj.UserName;
                txtmail.Text = obj.Email;
                txtPwd.Text = Base64Decode(obj.Password);
                txtMobile.Text = obj.Moblie;
                txtNational.Text = obj.NationalID;
                ChkIsActive.Checked = (bool)obj.IsActive;
                //ContactServiceManager.Sending_Email("RiseAppTest@gmail.com", obj.Email, "hello", "Hello");

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
        public static string Base64Encode(string Pwd)
        {
            var PwdBytes = System.Text.Encoding.UTF8.GetBytes(Pwd);
            return System.Convert.ToBase64String(PwdBytes);
        }
        public static string Base64Decode(string EncryptedPwd)
        {
            var EncryptedPwdBytes = System.Convert.FromBase64String(EncryptedPwd);
            return System.Text.Encoding.UTF8.GetString(EncryptedPwdBytes);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedItemID.HasValue)
                {
                    if (!ChkIsActive.Checked)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showAlertPopUp();", true);
                        return;
                    }

                    SetObject();
                }
                else
                {



                    List<User> users = UserServiceManager.GetAll();
                    foreach (User o in users)
                    {
                        if (o.UserName.ToUpper() == txtName.Text.ToUpper())
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), "showEditForm();", true);

                            lblRe.Text = "This Name has already Used";

                            txtName.Focus();
                            return;
                        }

                    }
                    User Obj = new User();
                    Obj.UserName = txtName.Text;
                    Obj.Email = txtmail.Text;
                    Obj.Password = Base64Encode(txtPwd.Text);
                    Obj.Moblie = txtMobile.Text;
                    Obj.Email = txtmail.Text;
                    Obj.NationalID = txtNational.Text;
                    Obj.GroupID = int.Parse(ddlGroup.SelectedValue);
                    Obj.IsActive = true;
                    string message = "http://localhost:1114/Forms/Settings/ConfirmPasswordURL.aspx?Mail=" + Obj.Email ;
                    string decodedUrl = Server.UrlDecode(message);

                    ContactServiceManager.Sending_Email("RiseAppTest@gmail.com", Obj.Email , decodedUrl, "Enter Your Password");


                    EmailMetaData emailMetaData = new EmailMetaData();
                    emailMetaData.From_Email = "RiseAppTest@gmail.com";
                    emailMetaData.To_Email = txtmail.Text;
                    emailMetaData.Message = "Hello";
                    emailMetaData.Subject = "Hello";
         //           Sending_Email(emailMetaData);

                    UserServiceManager.Insert(Obj);
                }
                
                this.SelectedItemID = null;
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception exc)
            {

            }
        }
        private void SetObject()
        {
            User SelectedObj = UserServiceManager.GetByCode(this.SelectedItemID.Value);
            SelectedObj.UserName = txtName.Text;
            SelectedObj.Email = txtmail.Text;
            SelectedObj.Password = txtPwd.Text;
            SelectedObj.IsActive = ChkIsActive.Checked;
            SelectedObj.Moblie = txtMobile.Text;
            SelectedObj.NationalID = txtNational.Text;
            EmailMetaData emailMetaData = new EmailMetaData();
            emailMetaData.From_Email = "RiseAppTest@gmail.com";
            emailMetaData.To_Email = txtmail.Text;
            emailMetaData.Message = "Hello";
            emailMetaData.Subject = "Hello";
            //  Sending_Email(emailMetaData);
            string message = "http://localhost:1114/Forms/Settings/ConfirmPasswordURL.aspx?Mail=" + SelectedObj.Email;
             string decodedUrl = Server.UrlDecode(message);


            ContactServiceManager.Sending_Email("RiseAppTest@gmail.com", txtmail.Text, decodedUrl, "Enter Your Password");


            UserServiceManager.Update(SelectedObj);
        }
        //public static bool Sending_Email(EmailMetaData emailMetaData)
        //{
        //    try
        //    {
        //        MailMessage mail = new MailMessage(emailMetaData.From_Email, emailMetaData.To_Email);

        //        /*foreach (var item in CC_Emails)
        //        {
        //            MailAddress CC = new MailAddress(item);
        //            mail.CC.Add(CC);
        //        }*/

        //        mail.Subject = emailMetaData.Subject;
        //        mail.Body = emailMetaData.Message;
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
        //        SmtpServer.Port = 587;
        //        SmtpServer.EnableSsl = true;
        //        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        SmtpServer.UseDefaultCredentials = false;
        //        SmtpServer.Credentials = new System.Net.NetworkCredential()
        //        {
        //            UserName = "RiseAppTest@gmail.com",
        //            Password = "BTS12345678"

        //        };

        //        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) =>
        //        {
        //            return true;
        //        });

        //        SmtpServer.Send(mail);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

        protected void Yes_Click(object sender, EventArgs e)
        {
            SetObject();
            Response.Redirect(Request.RawUrl);
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
                    {
            List<User> users = UserServiceManager.GetAll();
            foreach (User o in users)
            {
                if (o.UserName.ToUpper() == txtName.Text.ToUpper())
                {
                    lblRe.Text = "This Name has already Used";
                    txtName.Focus();
                    return;
                }

            }
        }
    }
}