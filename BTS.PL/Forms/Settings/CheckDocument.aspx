<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckDocument.aspx.cs" Inherits="BTS.PL.Forms.Settings.index" %>

<style type="text/css">
    .hiddencol {
        display: none;
    }


    .table-condensed tr th {
        border: 1px solid #e5e5e5;
        color: white;
        background-color: #d36541;

        
    }

    .table-condensed, .table-condensed tr td {
        border: 1px solid #e5e5e5;
    }

    tr:nth-child(even) {
        background: #f8f7ff
    }


    tr:nth-child(odd) {
        background: #fff;
    }
</style>
<script type="text/javascript">
    function getUrlVars() {
        var vars = {};
        var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
            function (m, key, value) {
                vars[key] = value;
            });
        return vars;
    }
    var _UserID = getUrlVars()["UserID"];
    var _Password = getUrlVars()["Password"];
    
  



</script>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Rise - Admin</title>
    <!-- Bootstrap Core CSS -->
    <link href="/client/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- MetisMenu CSS -->
    <link href="/client/vendor/metisMenu/metisMenu.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="/client/dist/css/main.css" rel="stylesheet">
    <!-- Custom Fonts -->
    <link href="/client/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css">
    <script src="/client/vendor/jquery/jquery.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
     
        <div class="container" runat="server" id="Verify">
          <div class="row" >
               <asp:Label ID="lbl_Title" Font-Size="X-Large"   Text="Please Enter UserID and Password" runat="server"></asp:Label>
          </div>
            <div class="row" >
                <div class="col-lg-4">
                    <asp:HiddenField ID="Hidden_ContactCode" runat="server" />
                    <asp:Label ID="lblUserName" Text="User Name" runat="server"></asp:Label>
                    <asp:TextBox ID="txtUserName" class="form-control" placeholder="User Name" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblPassword" Text="Password" runat="server"></asp:Label>
                    <asp:TextBox ID="txtPasword" TextMode="Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-4">
                    <asp:Label ID="lblMassage" Text="Massage" Width="100%" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
                    <asp:Button ID="btnVerify" type="submit" Font-Bold="true" BackColor="#d36541" ForeColor="White" Width="40%" class="form-control" Text="Verify" runat="server" OnClick="btnVerify_Click"></asp:Button>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblMassageDiscription" Text="" BorderColor="YellowGreen" ForeColor="Red" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                  <div class="col-lg-1" style="font-size:x-large"> Category*</div>
                <div class="col-lg-2" style="margin-left:10px">              
                    <asp:DropDownList ID="ddlFileTypeSelect" runat="server" Width="100%" Height="6%"  Enabled="false" OnSelectedIndexChanged="ddlFileTypeSelect_SelectedIndexChanged" DataValueField="Code" DataTextField="Name" AutoPostBack="true">

                    </asp:DropDownList>

</div>

                <div class="col-lg-3">
                    <asp:FileUpload ID="FileUpload1" Enabled="false" Width="100%" BackColor="#d36541" ForeColor="White" class="btn btn-primary" runat="server" />
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="FileUpload1"
 ErrorMessage="Not  allowed" 
 ValidationExpression="(.+\.([Pp][Nn][Gg])|.+\.([Dd][Oo][Cc])|.+\.([Tt][Xx][Tt])|.+\.([Pp][Dd][Ff])|.+\.([Dd][Oo][Cc][Xx])|.+\.([Xx][Ll][Ss][Xx])|.+\.([Jj][Pp][Gg]))"></asp:RegularExpressionValidator>

                </div>
                              <div class="col-lg-1">
                    <asp:Button ID="btnAdd" Enabled="false" runat="server" Width="100%" BackColor="#d36541" ForeColor="White"  class="btn btn-primary" Text="Upload" OnClick="btnAdd_Click" />
                </div>
                </div>
            <div class="row">
            <asp:Panel ID="panDCH" BorderStyle="Groove" runat="server" BackColor="Snow" GroupingText ="DCH">
                <div class="col-lg-2">
                    <asp:Button ID="btnPrimaryCheckYN" Enabled="false" Width="100%" BackColor="#d36541" ForeColor="White" class="btn btn-primary" runat="server" Text="First Check" OnClick="btnPrimaryCheckYN_Click" />
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btnSecondCheckYN" Enabled="false" Width="100%" BackColor="#d36541" ForeColor="White"  runat="server" class="btn btn-primary" Text="Second Check" OnClick="btnSecondCheckYN_Click" />
                </div>
                   <div class="col-lg-2">
                       <asp:Button ID="btn_ONLineForm" Enabled="false" Width="100%" BackColor="#d36541" ForeColor="White" runat="server" class="btn btn-primary" Text="Online Form" OnClick="btn_ONLineForm_Click"  />
                  </div>
                </asp:Panel>
                <asp:Panel ID="panFXP" BorderStyle="Groove" runat="server" BackColor="Snow" GroupingText ="FXP" >
                <div class="col-lg-2">
                        <asp:Button ID="btn_SpecialExpForm" Enabled="false" Width="100%" BackColor="#d36541" ForeColor="White" runat="server" class="btn btn-primary" Text="Featured Expertise Form" OnClick="btn_SpecialExpForm_Click" />
                  </div>
               </asp:Panel>
            </div>
          
             
        </div>
        <div class="row">
            <asp:Button ID="btnUploadFtP" Enabled="false" runat="server" Visible="false" Text="Upload All Fiels" OnClick="btnUploadFtP_Click" />
            <asp:Button ID="btnDeleteFtP" Enabled="false" runat="server" Visible="false" Text="Delete All Fiels" OnClick="btnDeleteFtP_Click" />
        </div>
        <div class="row">
            <hr />
        </div>
        <div class="row">
            <div class="col-lg-12">
                <%--  <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="false"--%>
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="false"
                    BorderColor="#CC9966" BorderStyle="None"
                    
                  
                    BorderWidth="1px" CellPadding="4"
                    OnRowDataBound="GridView1_RowDataBound"
                    EmptyDataText="No files uploaded">
                    <Columns>
                        <asp:BoundField DataField="FileName" ItemStyle-Width="15%" HeaderText="File Name" />
                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Category">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlFileType" runat="server" Width="100%" SelectMethod="GetAll_FileTypes" Enabled="false" OnSelectedIndexChanged="ddlFileType_SelectedIndexChanged" DataValueField="Code" DataTextField="Name" AutoPostBack="true"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FileSize" ItemStyle-Width="10%" HeaderText="Size" />
                        <asp:BoundField DataField="UserID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-Width="10%" HeaderText="User ID" />
                        <asp:BoundField DataField="PathFileLocal" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="PathFileLocal" />
                        <asp:BoundField DataField="PathFileServer" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="PathFileServer" />
                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="FileID">
                            <ItemTemplate>
                                <asp:Label ID="lblCode" Text='<%# Eval("Code") %>' Width="100%" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblUploadFileDate" Text='<%#Eval("UploadFileDate","{0:dd/MM/yyyy hh:mm}") %>' Width="100%" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="FileID">
                            <ItemTemplate>
                                <asp:Label ID="lblFileID" Text='<%# Eval("FileID") %>' Width="100%" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Folder" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                            <ItemTemplate>
                                <asp:TextBox ID="txtFolderName" Text='<%# Eval("FolderName") %>' Width="100%" OnTextChanged="txtFolderName_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="5%" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkUpdate" Text="Update" CommandArgument='<%# Container.DataItemIndex %>' runat="server" OnClick="lnkUpdate_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="5%">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("FileID") %>' runat="server" OnClick="DownloadFile"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="5%">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" Text="Delete"  ForeColor="Red" CommandArgument='<%# Eval("PathFileLocal") %>' CommandName='<%# Container.DataItemIndex %>' runat="server" OnClick="DeleteFile" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <%--<FooterStyle BackColor="#337ab7" ForeColor="#330099" />
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True"
                        ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099"
                        HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True"
                        ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />--%>
                </asp:GridView>
            </div>
        </div>
        <div class="row">
            <hr style="height:2px;border-width:medium;color:black;background-color:black"/>
            <h3 style="position:center; padding-left:70px">Log</h3>
        </div>
       
           <div class="row">
            <div class="col-lg-12">
                <asp:TextBox ID="txtComment" Width="80%"  BackColor="LightYellow" runat="server"></asp:TextBox>
                <asp:Button ID="btnAddComment" Width="15%"  BackColor="#d36541" ForeColor="White"  runat="server" class="btn btn-primary" Text="Add Comment" OnClick="btnAddComment_Click" />
               
                    <asp:GridView ID="GridLog" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="false"
                        BorderColor="#CC9966" BorderStyle="None"
                       
                        BorderWidth="1px" CellPadding="4"
                         OnRowDataBound="GridLog_RowDataBound"
                        EmptyDataText="No Log">
                        <Columns>
                            <asp:BoundField DataField="UserID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-Width="10%" HeaderText="Note writer" />
                            <asp:BoundField DataField="CheckerName" ItemStyle-Width="25%" HeaderText="Note writer" />
                            <asp:BoundField DataField="LogDate" DataFormatString = "{0:dd/MM/yyyy hh:mm}" ItemStyle-Width="25%" HeaderText="Date" />
                            <asp:TemplateField ItemStyle-Width="15%" HeaderText="Category" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlCategory" runat="server" Enabled="false" Width="100%" SelectMethod="GetAll_FileTypes"  DataValueField="Code" DataTextField="Name" ></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:BoundField DataField="Comment" ItemStyle-Width="58%" HeaderText="Comment" />
                        </Columns>
                    </asp:GridView>
            </div>
           </div>
             
        

    </form>
</body>
</html>
