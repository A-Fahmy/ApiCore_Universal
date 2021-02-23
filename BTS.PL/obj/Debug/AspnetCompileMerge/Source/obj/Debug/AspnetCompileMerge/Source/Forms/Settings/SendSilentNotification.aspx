<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="SendSilentNotification.aspx.cs" Inherits="BTS.PL.Forms.Settings.SendSilentNotification" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showEditForm() {
            $("#itemModal").modal();
        }
        function showAlertPopUp() {
            $("#itemModalPopUp").modal();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
   <ContentTemplate>

        <div>
             <asp:Button ID="btnSync" runat="server" Text="Syncronize Lookup Changes" class="btn btn-primary" OnClick="btnSync_Click" />

        </div>

 </ContentTemplate>
</asp:Content>
