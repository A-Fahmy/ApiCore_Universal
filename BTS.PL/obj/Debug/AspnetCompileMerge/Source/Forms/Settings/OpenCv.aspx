<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="OpenCv.aspx.cs" Inherits="BTS.PL.Forms.Settings.OpenCv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <script type="text/javascript">
        function showEditForm() {
            $("#itemModal").modal();
        }
        function showAlertPopUp() {
            $("#itemModalPopUp").modal();
               }
        function showEditForm1() {
            $("#itemModal1").modal();
        }
    </script>
    <style>
    .modal-body {
    max-height: calc(100vh - 210px);
    overflow-y: auto;
}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
          <ContentTemplate>
              <asp:UpdatePanel>
                  <ContentTemplate>
                <asp:Button ID="btnAddNewItem" runat="server" Text="Add New User" class="btn btn-primary" OnClick="btnAddNewItem_Click" />
     </ContentTemplate>
                      </asp:UpdatePanel>
                  <div class="modal fade" id="itemModal" role="dialog" aria-labelledby="myModalLabel"  aria-hidden="true" data-backdrop="static" data-keyboard="false" >
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                
                            </button>
                            <h4 class="modal-title" id="myModalLabel">CV
                            </h4>
                        </div>
                        <div class="modal-body">

                    <div  class="col-md-10" style="border:initial">
                           <asp:Label ID="field1" Text="Field1" runat="server">

                           </asp:Label>
                            </div>
                            <br />
                            <br />
                            <div class="col-md-10" style="border:groove">
                           <asp:Label ID="field2" Text="Field2" runat="server">

                           </asp:Label>

                            </div>
                            <br />
                            <br />
                            <div class="col-md-10" style="border:inset">
                                 <asp:Label ID="field3" Text="Field3" runat="server">

                           </asp:Label>
                            </div>
                           <br /><br />
                        <div class="col-md-10" style="border:inherit">
                                 <asp:Label ID="field4" Text="Field4" runat="server">

                           </asp:Label>
                            </div>
                           <br /><br />
                             <div class="col-md-10" style="border: outset"  >
                                  <asp:Label ID="field5" Text="Field5" runat="server">

                           </asp:Label>
                            </div>
                           <br /><br />
                             <div class="col-md-10" style="border:ridge">
                              <asp:Label ID="field6" Text="Field6" runat="server">

                           </asp:Label>
                            </div>
                           
                            <br /><br />
                              <div class="col-md-10" style="border:unset">
                                     <asp:Label ID="field7" Text="Field7" runat="server">

                           </asp:Label>
                           </div>
                            <br /><br />
                                 <div class="col-md-10" style="border:double">
                                      <asp:Label ID="field8" Text="Field8" runat="server">

                           </asp:Label>
                           </div>
                            <br /><br />
                                 <div class="col-md-10" style="border:double">
                                     <asp:Label ID="field9" Text="Field9" runat="server">

                           </asp:Label>
                           </div>
                            <br />
                            <br />
                                 <div class="col-md-10" style="border:double">
                                      <asp:Label ID="field10" Text="Field10" runat="server">

                           </asp:Label>
                         
                        </div>
                            
                            <br />
                            <br />
                            <br />
                            <br />
                        <div class="modal-footer">
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
   <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" AutoPostBack="true" />
                        </div>
                    </div>

                </div>
            </div>
                      </div>
                 <div class="modal fade" id="itemModal1" role="dialog" aria-labelledby="myModalLabel"  aria-hidden="true" data-backdrop="static" data-keyboard="false" >
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                
                            </button>
                            <h4 class="modal-title" id="myModalLabel1">CV
                            </h4>
                        </div>
                        <div class="modal-body">

                    <div  class="col-md-10" style="border:initial">
                           <asp:Label ID="Label11" Text="Field1" runat="server">

                           </asp:Label>
                            </div>
                            <br />
                            <br />
                            <div class="col-md-101" style="border:groove">
                           <asp:Label ID="Label2" Text="Field2" runat="server">

                           </asp:Label>

                            </div>
                            <br />
                            <br />
                            <div class="col-md-10" style="border:inset">
                                 <asp:Label ID="Label31" Text="Field3" runat="server">

                           </asp:Label>
                            </div>
                           <br /><br />
                        <div class="col-md-10" style="border:inherit">
                                 <asp:Label ID="Label41" Text="Field4" runat="server">

                           </asp:Label>
                            </div>
                           <br /><br />
                             <div class="col-md-10" style="border: outset"  >
                                  <asp:Label ID="Label51" Text="Field5" runat="server">

                           </asp:Label>
                            </div>
                           <br /><br />
                             <div class="col-md-10" style="border:ridge">
                              <asp:Label ID="Label61" Text="Field6" runat="server">

                           </asp:Label>
                            </div>
                           
                            <br /><br />
                              <div class="col-md-10" style="border:unset">
                                     <asp:Label ID="Label71" Text="Field7" runat="server">

                           </asp:Label>
                           </div>
                            <br /><br />
                                 <div class="col-md-10" style="border:double">
                                      <asp:Label ID="Label81" Text="Field8" runat="server">

                           </asp:Label>
                           </div>
                            <br /><br />
                                 <div class="col-md-10" style="border:double">
                                     <asp:Label ID="Label91" Text="Field9" runat="server">

                           </asp:Label>
                           </div>
                            <br />
                            <br />
                                 <div class="col-md-10" style="border:double">
                                      <asp:Label ID="Label10" Text="Field10" runat="server">

                           </asp:Label>
                         
                        </div>
                            
                            <br />
                            <br />
                            <br />
                            <br />
                        <div class="modal-footer">
                            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
   <asp:Button ID="Button2" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
     <div  class="modal fade" id="itemModalPopUp" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
         <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
        <asp:Label  runat="server">This field will not be active, are you sure you want to continue?</asp:Label>
        <asp:Button ID="Yes" runat="server" Text="Yes" OnClick="Yes_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
        <asp:Button ID="No" runat="server" Text="No" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
    </div>
               </div>
            </div>
        </div>
</asp:Content>
