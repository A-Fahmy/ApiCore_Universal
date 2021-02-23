using BTS.Entities;
using BTS.Entities.Views;
using BTS.ServiceManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;

namespace BTS.PL.Forms.Settings
{
    public partial class index : System.Web.UI.Page
    {
        List<FielsUpload> files = new List<FielsUpload>();
        List<Log_FielsUpload> Log_files = new List<Log_FielsUpload>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ContactCode"] = null;
                Session["Log_files"] = null;
                Session["files"] = null;
                #region Add_EmptyRow
                if (Session["files"] != null)
                    files = Session["files"] as List<FielsUpload>;
                if (files.Count == 0)
                {
                    FielsUpload _NewTemp = new FielsUpload();
                    _NewTemp.Code = -1;
                    files.Add(_NewTemp);
                }
                #endregion
                // ddlFileType.Items.Insert(0, new ListItem("Select", "0"));
               List<View_KeyValueLookup> lookup_FileTypes = Lookup_FileTypesServiceManager.GetKeyValueList(CommonSettings.Languages.Arabic);
                ddlFileTypeSelect.DataSource = lookup_FileTypes;
                ddlFileTypeSelect.DataBind();
                ddlFileTypeSelect.Items.Insert(0, "Select");
                GridView1.DataSource = files;
                GridView1.DataBind();
                #region Add_EmptyLog
                Log_FielsUpload _NewLog = new Log_FielsUpload();
                _NewLog.Code = -1;
                Log_files.Add(_NewLog);
                GridLog.DataSource = Log_files;
                GridLog.DataBind();
                #endregion
                #region Data_From_URL
                string _UserID = Request.QueryString["UserID"];
                string _Password = Request.QueryString["Password"];
                if(_Password !=null && _UserID != null)
                { 
                Session["UserID"] = _UserID;
                Session["Password"] = _Password;
                }
                if (_UserID != null && _Password != null)
                {
                    lbl_Title.Visible = false;
                    lblUserName.Visible = false; txtUserName.Visible = false;
                    lblPassword.Visible = false; txtPasword.Visible = false;
                    lblMassage.Visible = false; btnVerify.Visible = false;
                    txtUserName.Text = _UserID;
                    txtPasword.Text = _Password;
                    btnVerify_Click(null, null);

                }
                #endregion
            }
        }
        //protected void UploadFile(object sender, EventArgs e)
        //{


        //    FileInfo fi = new FileInfo(FileUpload1.PostedFile.FileName);
        //    string FileName = fi.FullName;

        //    string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
        //    Response.Redirect(Request.Url.AbsoluteUri);
        //}
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try { 
            lblMassageDiscription.Text = "";
            bool _IsExiste = false;
            if (FileUpload1.PostedFile.FileName == "") return;
            if (Session["files"] != null)
                files = Session["files"] as List<FielsUpload>;
            FileInfo fi = new FileInfo(FileUpload1.PostedFile.FileName);
            string[] _Arr = FormatSize(FileUpload1.PostedFile.ContentLength);

            //get File size in MB
            double fileSize = (FileUpload1.PostedFile.ContentLength / 1024) / 1024.0;
            if (fileSize > 4.0)
            {
                lblMassageDiscription.Text = "File size must be less than or equal to 4MB";
                return;
            }
            if (ViewState["Sum_FileSizeBybyte"] != null && ViewState["Sum_FileSizeBybyte"].ToString() != "")
            {
                double AllfileSize = double.Parse(ViewState["Sum_FileSizeBybyte"].ToString()) + fileSize;
                fileSize = (AllfileSize / 1024) / 1024.0;
                if (fileSize > 20.0)
                {
                    lblMassageDiscription.Text = " the All Files size must be less than or equal to 20MB";
                    return;
                }
            }
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fi.Name);
            string _FileID = txtUserName.Text + "_" + fi.Name;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + _FileID);
            string MapPath = Server.MapPath(FileUpload1.PostedFile.FileName);
            int index = files.FindIndex(x => x.Code == -1);
            if (files != null && index != -1)
            {
                files.RemoveAt(index);
                Session["files"] = files;
            }

            index = files.FindIndex(x => x.FileID == txtUserName.Text + fi.Name);
            if (files != null && index != -1)
            {
                _IsExiste = true;
                files.RemoveAt(index);
                Session["files"] = files;
            }


            FielsUpload _obj = new FielsUpload();
            _obj.Code = 1;
            _obj.FileName = fi.Name;
            _obj.FileID = _FileID;
            _obj.FileSize = _Arr[1];
            _obj.FileSizeBybyte = FileUpload1.PostedFile.ContentLength;
            _obj.PathFileLocal = MapPath;
            _obj.PathFileServer = MapPath;
            _obj.UserID = txtUserName.Text;
            _obj.ContactCode = int.Parse(ViewState["ContactCode"].ToString());
            _obj.FileTypeCode = int.Parse(ddlFileTypeSelect.SelectedValue);
            _obj.IsActive = true;
            _obj.PrimaryCheckYN = false;
            _obj.SecondCheckYN = false;
            _obj.ApproveYN = false;
            _obj.BuyCheckYN = false;
            _obj.FreezeYN = false;
            _obj.UploadFileDate = DateTime.Now;
            files.Add(_obj);
            #region Test
            if (_IsExiste == false)
                FielsUploadServiceManager.Insert(_obj);
            #endregion
            #region Add_FielsUpload
            if (Session["Log_files"] != null)
                Log_files = Session["Log_files"] as List<Log_FielsUpload>;
            else
                Log_files = new List<Log_FielsUpload>();
            Log_FielsUpload _objLog = new Log_FielsUpload();
            _objLog.Code = 1;
            _objLog.UserID = txtUserName.Text;
            _objLog.CheckerName = txtUserName.Text;
            _objLog.FileTypeCode = 1;
            _objLog.LogDate = DateTime.Now;
            _objLog.Comment = "Add File  " + fi.Name;
            Log_files.Add(_objLog);
            Log_FielsUploadServiceManager.Insert(_objLog);
            Session["Log_files"] = Log_files;
            GridLog.DataSource = Log_files;
            GridLog.DataBind();
            #endregion


            SendNotification_Contact(ViewState["FCM_Token"].ToString());
            if (files[0].OnlineFormYN == false || files[0].OnlineFormYN == null)
                lblMassageDiscription.Text = "Fill Your Online Form Then First Check"; 
            Session["files"] = files;
            GridView1.DataSource = files;
            GridView1.DataBind();
            }
            catch(Exception ex)
            {

            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            try
            {
                lblMassageDiscription.Text = "";
                string filePath = (sender as LinkButton).CommandArgument;
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "filename=" + filePath);
                Response.TransmitFile(Server.MapPath("~/Uploads/") + filePath);
                Response.End();
            }
            catch (Exception ex)
            {
                lblMassageDiscription.Text = "File Not Found";
                return;
            }
        }
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;

            files = Session["files"] as List<FielsUpload>;
            int index = -1;
            Label lblFileID = (Label)GridView1.Rows[int.Parse(((LinkButton)sender).CommandName)].FindControl("lblFileID");
            index = files.FindIndex(x => x.FileID == lblFileID.Text);
            if (files == null || index == -1) return;
            File.Delete(Server.MapPath("~/Uploads/") + files[index].FileID);
            List<FielsUpload> LtsFielsUpload = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);

            FielsUpload _DeleteFileFormFtp = LtsFielsUpload.Where(x => x.FileID == lblFileID.Text && x.IsActive == true).FirstOrDefault();
            if (_DeleteFileFormFtp != null)
                _DeleteFileFormFtp.IsActive = false;
            FielsUploadServiceManager.Update(_DeleteFileFormFtp);
            files.RemoveAt(index);

            #region Add_FielsUpload

            if (Session["Log_files"] != null)
                Log_files = Session["Log_files"] as List<Log_FielsUpload>;
            else
                Log_files = new List<Log_FielsUpload>();
            Log_FielsUpload _objLog = new Log_FielsUpload();
            _objLog.Code = 1;
            _objLog.UserID = txtUserName.Text;
            _objLog.CheckerName = txtUserName.Text;
            _objLog.FileTypeCode = _DeleteFileFormFtp.FileTypeCode;
            _objLog.LogDate = DateTime.Now;
            _objLog.Comment = "Delete File  " + _DeleteFileFormFtp.FileName;
            Log_files.Add(_objLog);
            Log_FielsUploadServiceManager.Insert(_objLog);
            Session["Log_files"] = Log_files;
            GridLog.DataSource = Log_files;
            GridLog.DataBind();
            #endregion



            #region Add_EmptyRow
            if (files.Count == 0)
            {
                FielsUpload _NewTemp = new FielsUpload();
                _NewTemp.Code = -1;
                files.Add(_NewTemp);
            }
            #endregion
            Session["files"] = files;
            GridView1.DataSource = files;
            GridView1.DataBind();
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
           
            List<Contact> _obj = ContactServiceManager.GetCOntactByUserName(txtUserName.Text);
           

            List<View_Contact_Expertise> _Expertises = Contact_ExpertiseServiceManager.ExcPro_GetAllExpertiseByContactCode(_obj[0].Code);
            if (_Expertises == null || _Expertises.Count == 0)
            {
                Virefied();
                lblMassageDiscription.Text = "Add Your Expertise";
                return;

            }
            if (_obj == null || _obj.Count == 0)
            {

                Virefied();
            }
            else
            {
                //Here
                if(_obj[0].Password!=txtPasword.Text )
                {
                    Virefied();
                    return;
                }

                if(_obj[0].DCHYN == null || _obj[0].DCHYN.Value==false )
                {
                    VirefieddDCH();
                    return;
                }
                if (_obj[0].CounterDCH == 0 && _obj[0].DCHYN.Value == true)
                    VirefieddDCH();
                ViewState["ContactCode"] = _obj[0].Code;
                Session["Password"] = txtPasword.Text;
                ViewState["FCM_Token"] = _obj[0].FCM_Token;
                lblMassage.Text = "Successful";
                //FileUpload1.Enabled = true;
                // btnAdd.Enabled = true;
                ddlFileTypeSelect.Enabled = true;
                btnUploadFtP.Enabled = true;
                btnDeleteFtP.Enabled = true;
                btn_ONLineForm.Enabled = true;
               
             
                Log_files = Log_FielsUploadServiceManager.GetByUserID(txtUserName.Text);
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
                    Session["Log_files"] = Log_files;
                    GridLog.DataSource = Log_files;
                    GridLog.DataBind();
                }


                files = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);
                if (_obj[0].SpecialExpertiseYN != null && files!=null)
                {
                    if (_obj[0].CounterSpecialExpertise > 0 || _obj[0].SpecialExpertiseYN.Value == true)
                        btn_SpecialExpForm.Enabled = true;
                }
                if (files == null || files.Count == 0)
                {
                    FielsUpload _NewTemp = new FielsUpload();
                    _NewTemp.Code = -1;
                    files.Add(_NewTemp);
                    lblMassageDiscription.Text = "Upload your Files First";

                }
                else
                {

                    ViewState["Sum_FileSizeBybyte"] = files.Sum(x => x.FileSizeBybyte);

                    lblMassageDiscription.Text = "";
                  
                    if (files[0].OnlineFormYN == null || files[0].OnlineFormYN.Value == false)
                    {
                        if (files.Count == 0)
                            lblMassageDiscription.Text = "Upload your Files First";
                    }
                    else
                        btnPrimaryCheckYN.Enabled = !files[0].PrimaryCheckYN.Value;
                    if (files[0].PrimaryCheckYN.Value == true && files[0].FreezeYN.Value == true
                        && files[0].ApproveYN.Value == false)
                    {
                        FileUpload1.Enabled = false; btnSecondCheckYN.Enabled = false;
                        btnAdd.Enabled = false; btnUploadFtP.Enabled = false;
                        btnDeleteFtP.Enabled = false; GridView1.Enabled = false;
                        btn_ONLineForm.Enabled = false;
                        lblMassageDiscription.Text = "Cannot be modified until review of sent files is complete";

                    }
                    else if (files[0].PrimaryCheckYN.Value == true && files[0].FreezeYN.Value == false && files[0].ApproveYN.Value == true)
                    {
                        if (files[0].SecondCheckYN.Value == true)
                            btnSecondCheckYN.Enabled = false;
                        else
                            btnSecondCheckYN.Enabled = true;
                        FileUpload1.Enabled = true;
                        btnAdd.Enabled = true; btnUploadFtP.Enabled = true;
                        btnDeleteFtP.Enabled = true; GridView1.Enabled = true;
                        lblMassageDiscription.Text = "";
                    }
                }
                List<Contact_CV> _CVs = Contact_CVServiceManager.GetActiveList();
                Contact_CV _CV = _CVs.Find(x => x.ContactCode == int.Parse(ViewState["ContactCode"].ToString()));

                if (_CV == null )
                {
                    Virefied();
                    btn_ONLineForm.Enabled = false;
                    lblMassageDiscription.Text = "Fill Your AD First";
                }
                Session["files"] = files;

                GridView1.DataSource = files;
                GridView1.DataBind();
            }
        }
        private void Virefied()
        {
            lblMassage.Text = "invalid UserName or Password";
            FileUpload1.Enabled = false;
            btnAdd.Enabled = false;
            btnUploadFtP.Enabled = false;
            btnDeleteFtP.Enabled = false;
            FielsUpload _NewTemp = new FielsUpload();
            _NewTemp.Code = -1;
            if(files!=null)
              files.Add(_NewTemp);
            else
            {
                files = new List<FielsUpload>();
                files.Add(_NewTemp);

            }


            
            GridView1.DataSource = files;
            GridView1.DataBind();

        }
        private void VirefieddDCH()
        {
            lblMassageDiscription.Text = "You Have To Buy a Package";
            FileUpload1.Enabled = false;
            btnAdd.Enabled = false;
            btnUploadFtP.Enabled = false;
            btnDeleteFtP.Enabled = false;
            btn_ONLineForm.Enabled = false;
            FielsUpload _NewTemp = new FielsUpload();
            _NewTemp.Code = -1;
            if (files != null)
                files.Add(_NewTemp);
            else
            {
                files = new List<FielsUpload>();
                files.Add(_NewTemp);

            }



            GridView1.DataSource = files;
            GridView1.DataBind();

        }
        protected void btnPrimaryCheckYN_Click(object sender, EventArgs e)
        {
            //  List<FielsUpload> Lts =FielsUploadServiceManager.Update_PrimaryCheck(txtUserName.Text).ToList();

            List<FielsUpload> UpdatePrimaryCheckYN = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);
            foreach (FielsUpload Row in UpdatePrimaryCheckYN)
            {
                Row.PrimaryCheckYN = true;
                FielsUploadServiceManager.Update(Row);
            }
            if (UpdatePrimaryCheckYN[0].CompleteYN != null)
            {
                if(UpdatePrimaryCheckYN[0].CompleteYN.Value == true)
                lblMassageDiscription.Text = "You Have To Change Your AD";
                return;
            }
            EmptyGrid();
            EmptyGrid_LogFile();
            btnPrimaryCheckYN.Enabled = false;

            string Code = ViewState["ContactCode"].ToString();

            string UserId = "RC" + Code;
            List<Contact> obj = ContactServiceManager.GetCOntactByUserName(UserId);
            if(obj[0].CounterDCH >= 0)
            obj[0].CounterDCH--;
            ContactServiceManager.Update(obj[0]);
            ContactForm.SendNotification_ListContact(obj[0]);
            string display = "Pop-up!";
            ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + display + "');", true);
        }
        protected void btnSecondCheckYN_Click(object sender, EventArgs e)
        {
            List<FielsUpload> SecondCheckYN = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);
            if (SecondCheckYN[0].CompleteYN.Value == true)
            {
                lblMassageDiscription.Text = "You Have To Change Your AD";
                return;
            }
            foreach (FielsUpload Row in SecondCheckYN)
            {
                Row.SecondCheckYN = true;
                FielsUploadServiceManager.Update(Row);
            }
          

            EmptyGrid();
            EmptyGrid_LogFile();
            btnSecondCheckYN.Enabled = false;
            string Code = ViewState["ContactCode"].ToString();

            string UserId = "RC" + Code;
            List<Contact> obj = ContactServiceManager.GetCOntactByUserName(UserId);
            if (obj[0].CounterDCH >= 0)
                obj[0].CounterDCH--;
            ContactServiceManager.Update(obj[0]);
            ContactForm.SendNotification_ListContact(obj[0]);
            string display = "Your Files have Gone To Checker To Approve them";
            ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + display + "');", true);
        }
        protected void btnBuyCheckYN_Click(object sender, EventArgs e)
        {

        }
        protected void ddlFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DropDownList ddlControl = sender as DropDownList;
            DropDownList ddlFileType = ddlControl.NamingContainer.FindControl("ddlFileType") as DropDownList;
            Label lblFileID = ddlControl.NamingContainer.FindControl("lblFileID") as Label;



            if (ddlFileType.SelectedValue != null
                && ddlFileType.SelectedValue.ToString() != "")
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                if (row != null)
                {
                    files = Session["files"] as List<FielsUpload>;
                    int index = files.FindIndex(x => x.FileID == lblFileID.Text);
                    files[index].FileTypeCode = int.Parse(ddlFileType.SelectedValue.ToString());
                    Session["files"] = files;
                    List<FielsUpload> LtsFielsUpload = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);
                    FielsUpload _UpdateFileFormFtp = LtsFielsUpload.Where(x => x.FileID == lblFileID.Text && x.IsActive == true).FirstOrDefault();
                    if (_UpdateFileFormFtp != null)
                    {
                        _UpdateFileFormFtp.FileTypeCode = int.Parse(ddlFileType.SelectedValue.ToString());
                        FielsUploadServiceManager.Update(_UpdateFileFormFtp);
                    }
                }
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                files = Session["files"] as List<FielsUpload>;
                if (files == null || files.Count == 0)
                    return;
                if (e.Row.RowState == DataControlRowState.Normal
                   || e.Row.RowState == DataControlRowState.Alternate
                   || e.Row.RowState == DataControlRowState.Selected)
                {
                    DropDownList ddlFileType = (DropDownList)e.Row.FindControl("ddlFileType");
                    ddlFileType.SelectedValue = files[e.Row.RowIndex].FileTypeCode.ToString();
                    TextBox txtFolderName = (TextBox)e.Row.FindControl("txtFolderName");
                    txtFolderName.Text = files[e.Row.RowIndex].FolderName;
                }
            }
        }
        private void EmptyGrid()
        {
            files = new List<FielsUpload>();
            if (files.Count == 0)
            {
                FielsUpload _NewTemp = new FielsUpload();
                _NewTemp.Code = -1;
                files.Add(_NewTemp);
                Session["files"] = files;
            }
            GridView1.DataSource = files;
            GridView1.DataBind();



        }
        private void EmptyGrid_LogFile()
        {
            Log_files = new List<Log_FielsUpload>();
            if (Log_files.Count == 0)
            {
                Log_FielsUpload _NewTemp = new Log_FielsUpload();
                _NewTemp.Code = -1;
                Log_files.Add(_NewTemp);
                Session["Log_files"] = Log_files;
            }
            GridLog.DataSource = Log_files;
            GridLog.DataBind();
        }

        static readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        public static string[] FormatSize(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            string[] Arr = new string[2];
            Arr[0] = number.ToString();
            Arr[1] = string.Format("{0:n1}{1}", number, suffixes[counter]);
            //  return string.Format("{0:n1}{1}", number, suffixes[counter]);
            return Arr;
        }
        #region Old
        protected void btnUploadFtP_Click(object sender, EventArgs e)
        {
           // lblMassageDiscription.Text = "";
            UploadFileToFTP();
            EmptyGrid();

            //}
        }
        private void UploadFileToFTP()
        {
            try
            {
                files = Session["files"] as List<FielsUpload>;
                foreach (FielsUpload Row in files)
                {

                    string currentDir = Row.FolderName + "/" + Row.FileID;
                    FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create("ftp://www.risetesting.com" + "/" + Row.FileID);
                    ftp.Credentials = new NetworkCredential("ph20680569591", "Risebtshosting1@");
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;
                    ftp.UsePassive = true;
                    ftp.UseBinary = true;
                    ftp.KeepAlive = false;
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;

                    FileStream fs = File.OpenRead(Server.MapPath("~/Uploads/") + Row.FileName);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();

                    Stream ftpstream = ftp.GetRequestStream();
                    ftpstream.Write(buffer, 0, buffer.Length);
                    ftpstream.Close();
                    files = Session["files"] as List<FielsUpload>;
                    int index = -1;
                    index = files.FindIndex(x => x.FileID == Row.FileID && x.IsActive == true);
                    if (index > -1)
                    {
                        FielsUploadServiceManager.Update(files[index]);
                    }
                    else
                    {
                        index = files.FindIndex(x => x.FileID == Row.FileID);
                        files[index].PathFileServer = "ftp://www.risetesting.com" + "/" + Row.FileID;
                        files[index].IsActive = true;
                        Session["files"] = files;
                        FielsUploadServiceManager.Insert(files[index]);
                    }



                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void DeleteFileToFTP(object objfiles)
        {
            List<FielsUpload> _files = objfiles as List<FielsUpload>;
            foreach (FielsUpload Row in _files)
            {

                string currentDir = Row.FolderName + "/" + Row.FileID;
                FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create("ftp://www.risetesting.com" + "/" + Row.FileID);
                ftp.Credentials = new NetworkCredential("ph20680569591", "Risebtshosting1@");
                ftp.UsePassive = true;
                ftp.UseBinary = true;
                ftp.KeepAlive = false;
                ftp.Method = WebRequestMethods.Ftp.GetFileSize;
                try
                {
                    FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                    if (response.StatusCode != FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        FtpWebRequest ftp_Delete = (FtpWebRequest)WebRequest.Create("ftp://www.risetesting.com" + "/" + Row.FileID);
                        ftp_Delete.Credentials = new NetworkCredential("ph20680569591", "Risebtshosting1@");
                        ftp_Delete.UsePassive = true;
                        ftp_Delete.UseBinary = true;
                        ftp_Delete.KeepAlive = false;
                        ftp_Delete.Method = WebRequestMethods.Ftp.DeleteFile;
                        response = (FtpWebResponse)ftp_Delete.GetResponse();
                        int index = _files.FindIndex(x => x.FileID == Row.FileID && x.IsActive == true);
                        if (_files == null || index == -1) return;
                        try
                        {
                            _files[index].IsActive = false;
                            FielsUploadServiceManager.Update(_files[index]);
                        }
                        catch (WebException ex1)
                        {




                        }



                    }
                }
                catch (WebException ex)
                {




                }
            }


        }
        //protected void DeleteFile(object sender, EventArgs e)
        //{
        //    string filePath = (sender as LinkButton).CommandArgument;

        //    files = Session["files"] as List<FielsUpload>;
        //    int index = -1;
        //    Label lblFileID = (Label)GridView1.Rows[int.Parse(((LinkButton)sender).CommandName)].FindControl("lblFileID");
        //    index = files.FindIndex(x => x.FileID == lblFileID.Text);
        //    if (files == null || index == -1) return;


        //    List<FielsUpload> _DeleteFileFormFtp= files.Where(x => x.FileID == lblFileID.Text  && x.IsActive==true).ToList();
        //    File.Delete(Server.MapPath("~/Uploads/") + files[index].FileName);
        //    files[index].IsActive = false;
        //    FielsUploadServiceManager.Update(files[index]);
        //    files.RemoveAt(index);



        //    //if (_DeleteFileFormFtp!=null && _DeleteFileFormFtp.Count>0)
        //    //    DeleteFileToFTP(_DeleteFileFormFtp);


        //    #region Add_EmptyRow
        //    if (files.Count == 0)
        //    {
        //        FielsUpload _NewTemp = new FielsUpload();
        //        _NewTemp.Code = -1;
        //        files.Add(_NewTemp);
        //    }
        //    #endregion
        //    Session["files"] = files;
        //    GridView1.DataSource = files;
        //    GridView1.DataBind();
        //}
        protected void lnkUpdate_Click(object sender, EventArgs e)
        {

            if (((LinkButton)sender).CommandArgument != null && ((LinkButton)sender).CommandArgument != "")
            {
                files = Session["files"] as List<FielsUpload>;
                int index = -1;
                TextBox txtFolderName = (TextBox)GridView1.Rows[int.Parse(((LinkButton)sender).CommandArgument)].FindControl("txtFolderName");
                Label lblFileID = (Label)GridView1.Rows[int.Parse(((LinkButton)sender).CommandArgument)].FindControl("lblFileID");
                DropDownList ddlFileType = (DropDownList)GridView1.Rows[int.Parse(((LinkButton)sender).CommandArgument)].FindControl("ddlFileType");

                index = files.FindIndex(x => x.FileID == lblFileID.Text);
                files[index].FolderName = txtFolderName.Text;
                files[index].FileTypeCode = int.Parse(ddlFileType.SelectedValue.ToString());
                Session["files"] = files;
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
        }
        protected void txtFolderName_TextChanged(object sender, EventArgs e)
        {

            TextBox ddlControl = sender as TextBox;
            TextBox txtFolderName = ddlControl.NamingContainer.FindControl("txtFolderName") as TextBox;
            Label lblFileID = ddlControl.NamingContainer.FindControl("lblFileID") as Label;
            if (txtFolderName.Text != "")
            {
                TextBox ddl = (TextBox)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                if (row != null)
                {
                    files = Session["files"] as List<FielsUpload>;
                    int index = files.FindIndex(x => x.FileID == lblFileID.Text);
                    files[index].FolderName = txtFolderName.Text;
                    Session["files"] = files;
                }
            }
        }
        protected void btnDeleteFtP_Click(object sender, EventArgs e)
        {
            btnDeleteFtP.Enabled = false;
            DeleteFileToFTP(Session["files"] as List<FielsUpload>);
            EmptyGrid();
            btnDeleteFtP.Enabled = true;
        }
        #endregion
        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            #region Add_FielsUpload
            if (Session["Log_files"] != null)
                Log_files = Session["Log_files"] as List<Log_FielsUpload>;
            else
                Log_files = new List<Log_FielsUpload>();
            Log_FielsUpload _objLog = new Log_FielsUpload();
            _objLog.Code = 1;
            _objLog.UserID = txtUserName.Text;
            _objLog.CheckerName = txtUserName.Text;
            _objLog.FileTypeCode = 1;
            _objLog.LogDate = DateTime.Now;
            _objLog.Comment = txtComment.Text;
            Log_files.Add(_objLog);
            Log_FielsUploadServiceManager.Insert(_objLog);
            Session["Log_files"] = Log_files;
            GridLog.DataSource = Log_files;
            GridLog.DataBind();

            txtComment.Text = "";
            #endregion
        }

        protected void GridLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Log_files = Session["Log_files"] as List<Log_FielsUpload>;
                if (Log_files == null || Log_files.Count == 0)
                    return;
                if (e.Row.RowState == DataControlRowState.Normal
                   || e.Row.RowState == DataControlRowState.Alternate
                   || e.Row.RowState == DataControlRowState.Selected)
                {
                    DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");
                    ddlCategory.SelectedValue = Log_files[e.Row.RowIndex].FileTypeCode.ToString();

                }
            }
        }

        protected void btn_ONLineForm_Click(object sender, EventArgs e)
        {

            string Code = ViewState["ContactCode"].ToString();
            string password = Session["Password"].ToString();
            string UserId = "RC" + Code;
            List<FielsUpload> file = FielsUploadServiceManager.GetFielsUploadByUserID(UserId);
            if (file.Count == 0)
            {
                //    string script = "alert(\"Please Upload Your Files First\");";
                //    ScriptManager.RegisterStartupScript(this, GetType(),
                //                          "ServerControlScript", script, true);
                lblMassageDiscription.Text = "Please Upload Your Files First";
            }
            else
            Response.Redirect("/Forms/Settings/OnlineFormCV.aspx?Code=" + Code + "&Password="+ password);

        }
        private void SendNotification_Contact( string FCM_Token)
        {
          
            try
            {
                    if (FCM_Token != null && FCM_Token!="")
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

        protected void btn_SpecialExpForm_Click(object sender, EventArgs e)
        {
            string Code = ViewState["ContactCode"].ToString();
            string password = Session["Password"].ToString();

            string UserId = "RC" + Code;
            List<FielsUpload> file = FielsUploadServiceManager.GetFielsUploadByUserID(UserId);
            if (file.Count == 0)
            {
              
                lblMassageDiscription.Text = "Please Upload Your Files First";
            }
            else
                Response.Redirect("/Forms/Settings/SpecialExpertisePackage.aspx?Code=" + Code + "&Password=" + password);
        }

        protected void ddlFileTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFileTypeSelect.SelectedValue != "0")
            {
                btnAdd.Enabled = true;
                FileUpload1.Enabled = true;
            }
        }
    }
}