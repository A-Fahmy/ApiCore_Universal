using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.Entities;
using BTS.Data.Repositories;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.ServiceModel;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net.Security;
using XmlRpc;
using Newtonsoft.Json;
using System.Collections;

namespace BTS.Business
{
    public partial class ContactBusiness 
    {
       
        //public static List<Contact> GetByUserID_Password(string UserName, string PassWord)
        //{
        //    try
        //    {
        //        OdooConnectionCredentials creds = new OdooConnectionCredentials("http://74.207.244.149:1143", "Beet_El-Gomla2", "admin", "admin");
        //        OdooAPI api = new OdooAPI(creds);
        //        List<Contact> _C = new List<Contact>();
        //        Contact _Add;

        //        OdooModel _employee = api.GetModel("hr.employee");
        //        _employee.AddField("id");
        //        _employee.AddField("name"); //name=Administrator

        //        object[] filter = new object[] { new object[] { "name", "=", "Administrator", } };
        //        List<OdooRecord> records = _employee.Search(filter);
        //        foreach (OdooRecord record in records)
        //        {
        //            _Add = new Contact();
        //            _Add.UserID = int.Parse(record.GetValue("id").ToString());
        //            _Add.UserName = record.GetValue("name").ToString();
        //            _Add.FirstName = record.GetValue("name").ToString();
        //            _Add.MiddleName = record.GetValue("name").ToString();
        //            _Add.LastName = record.GetValue("name").ToString();
        //            _Add.MoblieNo = "01028933447";
        //            _Add.Address = "Test";
        //            _Add.PhotoInBytes = null;
        //            _Add.Photo = null;
        //            _Add.Password = PassWord;
        //            _Add.IsActive = true;
        //            _Add.State = true;
        //            _C.Add(_Add);
        //        }
        //        return _C;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

        public static List<Contact> GetByUserID_Password(string UserName, string PassWord)
        {
            try
            {
                Confgration_Odoo._Password = PassWord;
                Confgration_Odoo._UserName = UserName;
                string Url = Confgration_Odoo._Domain_URL, db = Confgration_Odoo._DataBaseName, pass = Confgration_Odoo._Password, user = Confgration_Odoo._UserName;
               XmlRpcClient client = new XmlRpcClient();
                client.Url = Url;
                client.Path = "common";
                // LOGIN

                XmlRpcRequest requestLogin = new XmlRpcRequest("authenticate");
                requestLogin.AddParams(db, user, pass,
                     XmlRpcParameter.AsStruct(
                       XmlRpcParameter.AsMember("emp_email", UserName)
                     , XmlRpcParameter.AsMember("emp_password", PassWord)
                    ));
                XmlRpcResponse responseLogin = client.Execute(requestLogin);
                object obj=  responseLogin.GetObject();
                if (obj!=null && obj.ToString()!= "False")
                {
                  

                    List<Contact> _C = new List<Contact>();
                    Contact _Add  = new Contact();
                    _Add.UserID =int.Parse(obj.ToString());
                    _Add.UserName = UserName;
                    _Add.FirstName = UserName;
                    _Add.MiddleName = UserName;
                    _Add.LastName = UserName;
                    _Add.CurrentbranchLatitude= "0";
                    _Add.CurrentbranchLongitude= "0";
                    _Add.MoblieNo = "01028933447";
                    _Add.Address = "Test";
                    _Add.PhotoInBytes = null;
                    _Add.Photo = null;
                    _Add.Password = PassWord;
                    _Add.IsActive = true;
                    _Add.State = true;
                     _C.Add(_Add);
                    return _C;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<Contact> GetByMobile(string MoblieNo)
        {
            ContactRepository Obj = new ContactRepository();
            List<Contact> lstResult = Obj.GetWhere(x => x.MoblieNo == MoblieNo).ToList();
            return lstResult;
        }
        public static void UpdateContactPhoto(Contact contact , string path )
        {
            ContactRepository Obj = new ContactRepository();
            string ImageBytesString = Convert.ToBase64String(contact.Photo);
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://www.risetesting.com" + "/" + path);
            req.Credentials = new NetworkCredential("ph20680569591", "Risebtshosting1@");
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.UsePassive = true;
            req.UseBinary = true;
            req.KeepAlive = false;
            //FileStream stream = File.OpenRead(path);
            byte[] buffer = Convert.FromBase64String(ImageBytesString);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
            //contact.Code = int.Parse(path);
            contact.Photo = null;
            //contact.PhotoURL = "ftp://www.risetesting.com" + "/" + path;
            ContactBusiness.Update(contact);
        }
        public static Contact ReadProfilePhoto(int Contact)
        {
            Contact contact = new Contact();
            try
            {
                WebClient request = new WebClient();
                string url = "ftp://www.risetesting.com" + "/" + Contact.ToString();
                request.Credentials = new NetworkCredential("ph20680569591", "Risebtshosting1@");
                contact.Photo = request.DownloadData(url);
                return contact;
            }
            // string ImageBytesString = Convert.ToBase64String(newFileData);
            catch (Exception e)
            {
                return contact;
            }
           
        }
        public static void UploadPicture(HttpPostedFile postedImage)
        {
            //List<Contact> contact = GetByUserName(contactCode.ToString());

            var filePath = HttpContext.Current.Server.MapPath("~/Pictures/" + postedImage.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault());

            postedImage.SaveAs(filePath);

            //contact[0].PhotoURL = filePath;
            //Update(contact[0]);
        }
        public static List<Contact> ExcGetContact_by_ParentExpCode(int ParentExpCode)
        {
            ContactRepository Obj = new ContactRepository();
            var clientIdParameter = new SqlParameter("@ParentExpCode", ParentExpCode);
            return   Obj.ExcQuery("GetContact_by_ParentExpCode @ParentExpCode", clientIdParameter);
        }
    }
}
