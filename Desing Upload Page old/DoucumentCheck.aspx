<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoucumentCheck.aspx.cs" Inherits="BTS.PL.Forms.Settings.UploadFiels" %>

<style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1"  runat="server">
         <asp:Label ID="lblUserName" Text="User Name"  Width="6%"  runat="server" ></asp:Label>
         <asp:TextBox ID="txtUserName" Width="10%"  runat="server" ></asp:TextBox>
         <asp:Label ID="lblPassword" Text="Password"  Width="6%"  runat="server" ></asp:Label>
         <asp:TextBox ID="txtPasword" Width="10%"   TextMode="Password" runat="server" ></asp:TextBox>
         <asp:Button ID="btnVerify"  OnClick="btnVerify_Click"   Text="Verify" runat="server" ></asp:Button>
         <asp:Label ID="lblMassage"  Text="" Font-Bold="true"  ForeColor="Red" Width="30%"  runat="server" ></asp:Label>
         <hr/>
    <asp:FileUpload ID="FileUpload1" Enabled="false" runat="server" />
    <asp:Button ID="btnAdd"  Enabled="false" runat="server" Text="Upload File" OnClick="btnAdd_Click" />
    <asp:Button ID="btnPrimaryCheckYN"  Enabled="true"  runat="server" Text="First Check" OnClick="btnPrimaryCheckYN_Click" />
    <asp:Button ID="btnSecondCheckYN" Enabled="false"   runat="server" Text="Second Check" OnClick="btnSecondCheckYN_Click" />
    <asp:Button ID="btnBuyCheckYN"  Enabled="false"  runat="server" Text="Pay Check" OnClick="btnBuyCheckYN_Click" />
    <asp:Label ID="lblMassageDiscription" Text="" Width="40%"  BorderColor="YellowGreen"  ForeColor="Red"  runat="server" ></asp:Label>
    <asp:Button ID="btnUploadFtP"   Enabled="false" runat="server"  Visible="false" Text="Upload All Fiels" OnClick="btnUploadFtP_Click" />
    <asp:Button ID="btnDeleteFtP"  Enabled="false" runat="server"  Visible="false" Text="Delete All Fiels" OnClick="btnDeleteFtP_Click" />
   
    <hr />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BackColor="White" 
            BorderColor="#CC9966" BorderStyle="None" 
            BorderWidth="1px" CellPadding="4"
            OnRowDataBound="GridView1_RowDataBound"
            EmptyDataText = "No files uploaded">
        <Columns>
            <asp:BoundField DataField="FileName"  ItemStyle-Width="15%"  HeaderText="File Name" />
            <asp:BoundField DataField="FileSize" ItemStyle-Width="10%" HeaderText="Size" />
            <asp:BoundField DataField="UserID"  ItemStyle-Width="10%" HeaderText="User ID" />
            <asp:BoundField DataField="PathFileLocal" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="PathFileLocal" />
            <asp:BoundField DataField="PathFileServer" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="PathFileServer" />
            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="FileID">
                <ItemTemplate>
                    <asp:Label ID="lblCode" Text = '<%# Eval("Code") %>' Width="100%"  runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="10%" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="FileID">
                <ItemTemplate>
                    <asp:Label ID="lblFileID" Text = '<%# Eval("FileID") %>' Width="100%"  runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-Width="10%" HeaderText="Folder" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                <ItemTemplate>
                    <asp:TextBox ID="txtFolderName" Text = '<%# Eval("FolderName") %>' Width="100%" OnTextChanged="txtFolderName_TextChanged"  AutoPostBack="true" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="10%" HeaderText="Category">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlFileType"  runat="server"  Width="100%" SelectMethod="GetAll_FileTypes" OnSelectedIndexChanged="ddlFileType_SelectedIndexChanged"  DataValueField="Code" DataTextField="Name"  AutoPostBack="true"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="5%" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" >
                <ItemTemplate>
                    <asp:LinkButton ID="lnkUpdate" Text = "Update" CommandArgument ='<%# Container.DataItemIndex %>' runat="server"   OnClick ="lnkUpdate_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("FileName") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="5%">
                <ItemTemplate>
                    <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("PathFileLocal") %>' CommandName ='<%# Container.DataItemIndex %>' runat = "server" OnClick = "DeleteFile" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" 
        ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" 
        HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" 
        ForeColor="#663399" />
    <SortedAscendingCellStyle BackColor="#FEFCEB" />
    <SortedAscendingHeaderStyle BackColor="#AF0101" />
    <SortedDescendingCellStyle BackColor="#F6F0C0" />
    <SortedDescendingHeaderStyle BackColor="#7E0000" />

    </asp:GridView>
    </form>
</body>
</html>
