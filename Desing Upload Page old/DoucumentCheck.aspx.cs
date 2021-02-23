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

namespace BTS.PL.Forms.Settings
{
    public partial class UploadFiels : System.Web.UI.Page
    {

        List<FielsUpload> files = new List<FielsUpload>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                GridView1.DataSource = files;
                GridView1.DataBind();
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

            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fi.Name);
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
            _obj.FileID = txtUserName.Text + fi.Name;
            _obj.FileSize = _Arr[1];
            _obj.FileSizeBybyte = FileUpload1.PostedFile.ContentLength;
            _obj.PathFileLocal = MapPath;
            _obj.PathFileServer = MapPath;
            _obj.UserID = txtUserName.Text;
            _obj.FileTypeCode = 1;
            _obj.IsActive = true;
            _obj.PrimaryCheckYN = false;
            _obj.SecondCheckYN = false;
            _obj.ApproveYN = false;
            _obj.BuyCheckYN = false;
            _obj.FreezeYN = false;
            files.Add(_obj);
            #region Test
            if(_IsExiste==false)
               FielsUploadServiceManager.Insert(_obj);
            #endregion
            Session["files"] = files;
            GridView1.DataSource = files;
            GridView1.DataBind();
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            //string filePath = (sender as LinkButton).CommandArgument;
            //////////Response.ContentType = ContentType;
            //////////Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            //////////Response.WriteFile(filePath);
            //////////Response.End();

            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AppendHeader("Content-Disposition", "filename=" + filePath);

            //Response.TransmitFile(Server.MapPath("~/Uploads/") + filePath);

            //Response.End();


        }
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;

            files = Session["files"] as List<FielsUpload>;
            int index = -1;
            Label lblFileID = (Label)GridView1.Rows[int.Parse(((LinkButton)sender).CommandName)].FindControl("lblFileID");
            index = files.FindIndex(x => x.FileID == lblFileID.Text);
            if (files == null || index == -1) return;
            File.Delete(Server.MapPath("~/Uploads/") + files[index].FileName);
            List<FielsUpload> LtsFielsUpload = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);

            FielsUpload _DeleteFileFormFtp= LtsFielsUpload.Where(x => x.FileID == lblFileID.Text && x.IsActive==true).FirstOrDefault();
            if(_DeleteFileFormFtp!=null)
            _DeleteFileFormFtp.IsActive = false;
            FielsUploadServiceManager.Update(_DeleteFileFormFtp);
            files.RemoveAt(index);

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
            if (_obj == null || _obj.Count == 0)
            {
                lblMassage.Text = "invalid UserName or Password";
                FileUpload1.Enabled = false;
                btnAdd.Enabled = false;
                btnUploadFtP.Enabled = false;
                btnDeleteFtP.Enabled = false;
                FielsUpload _NewTemp = new FielsUpload();
                _NewTemp.Code = -1;
                files.Add(_NewTemp);
                GridView1.DataBind();
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
            else
            {
                lblMassage.Text = "successful";
                FileUpload1.Enabled = true;
                btnAdd.Enabled = true;
                btnUploadFtP.Enabled = true;
                btnDeleteFtP.Enabled = true;
                files = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);
                if (files == null || files.Count == 0)
                {
                    FielsUpload _NewTemp = new FielsUpload();
                    _NewTemp.Code = -1;
                    files.Add(_NewTemp);
                }
                else
                {
                    lblMassageDiscription.Text = "";
                    btnPrimaryCheckYN.Enabled = !files[0].PrimaryCheckYN.Value;
                    if (files[0].PrimaryCheckYN.Value == true && files[0].FreezeYN.Value == true
                        && files[0].ApproveYN.Value == false)
                    {
                        FileUpload1.Enabled = false; btnSecondCheckYN.Enabled = false;
                        btnAdd.Enabled = false; btnUploadFtP.Enabled = false;
                        btnDeleteFtP.Enabled = false; GridView1.Enabled = false;
                        lblMassageDiscription.Text = "Cannot be modified until review of sent files is complete";
                        
                    }
                    else if (files[0].PrimaryCheckYN.Value == true && files[0].FreezeYN.Value == false
                       && files[0].ApproveYN.Value == true)
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

                Session["files"] = files;
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
        }
        protected void btnPrimaryCheckYN_Click(object sender, EventArgs e)
        {
            //  List<FielsUpload> Lts =FielsUploadServiceManager.Update_PrimaryCheck(txtUserName.Text).ToList();

           List< FielsUpload> UpdatePrimaryCheckYN = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);
            foreach (FielsUpload Row in UpdatePrimaryCheckYN)
            {
                Row.PrimaryCheckYN = true;
                FielsUploadServiceManager.Update(Row);
            }
            EmptyGrid();
            btnPrimaryCheckYN.Enabled = false;
        }
        protected void btnSecondCheckYN_Click(object sender, EventArgs e)
        {
            List<FielsUpload> SecondCheckYN = FielsUploadServiceManager.GetFielsUploadByUserID(txtUserName.Text);
            foreach (FielsUpload Row in SecondCheckYN)
            {
                Row.SecondCheckYN = true;
                FielsUploadServiceManager.Update(Row);
            }
            EmptyGrid();
            btnSecondCheckYN.Enabled = false;
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
                        FielsUploadServiceManager.Update(_UpdateFileFormFtp);
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
            Arr[1]= string.Format("{0:n1}{1}", number, suffixes[counter]);
            //  return string.Format("{0:n1}{1}", number, suffixes[counter]);
            return Arr;
        }

        #region Old
        protected void btnUploadFtP_Click(object sender, EventArgs e)
        {
          
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

    }
}