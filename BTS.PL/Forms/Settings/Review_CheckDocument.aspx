<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Review_CheckDocument.aspx.cs" Inherits="BTS.PL.Forms.Settings.Review_CheckDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../client/dist/js/main.js"></script>
    <script src="../../client/vendor/jquery/jquery.js"></script>
    <script type="text/javascript">
        function showEditForm() {
            $("#itemModal").modal();
        }
        function showCVForm() {
            $("#itemModalCV").modal();
        }

        function showAlertPopUp() {
            $("#itemModalPopUp").modal();
        }

        $(function () {
            $('.checkbox').click(function () {
                $('#btnReview').prop('disabled', !$('.checkbox:checked').length);
            });
        });

    </script>
    <style type="text/css">
        .hiddencol {
            display: none;
        }

        .modal-body {
            max-height: calc(100vh - 210px);
            overflow-y: auto;
        }

        .modal-dialog {
            width: 70%;
        }
         .hiddencol
            {
            display: none;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <contenttemplate>

         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text=" From Date" runat="server" Width="100%"  AutoPostBack="false" ID="lblFormDate"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="100%" AutoPostBack="false" ID="TxtFromDate"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text=" From Date" runat="server" Width="100%"  AutoPostBack="false" ID="lblToDate"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="100%" AutoPostBack="false" ID="TxtToDate"></asp:TextBox>
             </div>
         </div>
        <div class="row"></div>
        <div class="row"></div>
         <div class="row"> 
            <div class="col-md-2">
                  <asp:Label  Text="User Code" runat="server" Width="100%"  AutoPostBack="false" ID="Label1"></asp:Label>
             </div>
            <div class="col-md-4">
                  <asp:TextBox  runat="server" AutoPostBack="false" Width="100%" ID="TxtSerUserCode"></asp:TextBox>
             </div>
           <%--    <div class="col-md-2">
                  <asp:Label  Text="Expertise" runat="server" Width="100%"  AutoPostBack="false" ID="Label3"></asp:Label>
             </div>
             <div class="col-md-4">
                   <asp:DropDownList ID="ddlExpertise" AutoPostBack="false" Width="100%" Height="100%"  runat="server" DataTextField="ExpertiseNameEN" DataValueField="Code" OnSelectedIndexChanged="ddlExpertise_SelectedIndexChanged" >  </asp:DropDownList>
             </div>--%>

             
              <div class="col-md-2">
                  <asp:Label  Text="State" runat="server" Width="100%"  AutoPostBack="false" ID="Label2"></asp:Label>
             </div>

             <div class="col-md-4">
                   <asp:DropDownList ID="ddlDocumentState" AutoPostBack="false" Width="100%"  runat="server" >
                    <asp:ListItem Text="Document Checked" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Document Not Checked" Value="2"></asp:ListItem>
                       <asp:ListItem Text="Featured Expertise" Value="3"></asp:ListItem>
                       </asp:DropDownList>
                
             </div>
                   
        </div>
          <div class="row">

          </div>
          <div class="row"> 
          
               <div class="col-md-2">     
                  <asp:Button ID="btnSearch"  runat="server" class="btn btn-primary" Width="100%" Text="Search" OnClick="btnSearch_Click1" />
              </div>
            
          </div>
         
          <asp:GridView ID="gvGetAllData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="User ID" />
                    <asp:BoundField DataField="ContactCode" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="Contact Code" />
                    <asp:BoundField DataField="CheckerName" HeaderText="Checker Name" />
                    <asp:BoundField DataField="CheckerDate" HeaderText="Checker Date" />
                    <asp:BoundField DataField="UploadFileDate" DataFormatString = "{0:dd/MM/yyyy hh:mm}" HeaderText="Last Upload File Date" />
                    <asp:TemplateField HeaderText="Open Folder">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false"
                                OnClick="btnEdit_Click" SelectedID='<%# Eval("UserID") %>'  CommandName='<%# Eval("ContactCode") %>'
                                ImageUrl="~/client/images/edititem.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
                
          <div class="modal fade" id="itemModal" role="dialog"  data-backdrop="static" data-keyboard="false" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">

                        <div class="modal-header">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel_Freeze">
                                  <ContentTemplate>
                             <div class="col-md-3">
<%--                                  <h4 class="modal-title" id="myModalLabel"> Open Folder </h4>--%>
                                    <asp:Button ID="btnOnlineForm" Width="100%" runat="server" OnClick="btnOnlineForm_Click"  AutoPostBack="true"  class="btn btn-primary" Text="Open Online Form"  />

                              </div>
                                      <div class="col-md-3">
                                    <asp:Button ID="btnSpecial" Width="100%" runat="server" OnClick="btnSpecial_Click"  AutoPostBack="true"  class="btn btn-primary" Text="Open Featured Expertise"  />

                              </div>
                             <div class="col-md-3">
                                 
                                  <asp:Button ID="btnOpenCV" Width="100%" runat="server" OnClick="btnOpenCV_Click"  AutoPostBack="true"  class="btn btn-primary" Text="Open AD"  />
                                   
                             </div>
                             <div class="col-md-3">
                                   <h4>  Freeze Folder  <asp:CheckBox ID="Chk_Freeze" AutoPostBack="true" OnCheckedChanged="Chk_Freeze_CheckedChanged"  runat="server" /></h4> 
                              </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    <div class="modal-body">
                     
                        <div class="row">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel_Grid_Exp">
                                  <ContentTemplate>
                            <div class="col-md-12">
                                <asp:GridView ID="Grid_Exp" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="false"
                                BorderColor="#CC9966" BorderStyle="None" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="yellow"><tr><td style="text-align: center; vertical-align: middle;font-weight: bold;font-size: 18px;"> Expertises </td></tr></table>'
                                BorderWidth="1px" CellPadding="4" HeaderStyle-BackColor="LightGray"
                                EmptyDataText="No Data">
                                <Columns>
                                    <asp:BoundField DataField="ExpertiseRCLCode" ItemStyle-Width="70%" HeaderText="Expertise RCL Code" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="ExpertiseLevelCode2_SQLLite" ItemStyle-Width="70%" HeaderText="Expertise Code" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="RCLCode" ItemStyle-Width="70%" HeaderText="RCLCode" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="ExpertiseLevelName1_SQLLite" ItemStyle-Width="70%" HeaderText="Expertise Name" />
                                    <asp:BoundField DataField="ExpertiseLevelName2_EN_SQLLite" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-Width="40%" HeaderText="Expertise Name" />
                                    <asp:BoundField DataField="ExpertiseLevelName3_EN_SQLLite" ItemStyle-Width="30%" HeaderText="ERCL" />
                                     <asp:TemplateField ItemStyle-Width="5%" HeaderText="Featured">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSpacial"  Checked='<%# Eval("SpacialYN") %> '  CommandArgument='<%# Eval("RCLCode") %> '  runat="server" AutoPostBack="true" OnCheckedChanged="ChkSpacial_CheckedChanged" Enabled="false" ></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField ItemStyle-Width="2%" HeaderText="Cost">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSpacialCost"  Text='<%# Eval("SpacialCost") %> ' CommandArgument='<%# Eval("SpacialYN") %>' runat="server" OnCheckedChanged="ChkSpacial_CheckedChanged" Enabled="false" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                 </ContentTemplate>
                               </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-md-12">
                              <asp:GridView ID="GridView1" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="false"
                                BorderColor="#CC9966" BorderStyle="None" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="yellow"><tr><td style="text-align: center; vertical-align: middle;font-weight: bold;font-size: 18px;"> Check Document </td></tr></table>'
                                BorderWidth="1px" CellPadding="4" HeaderStyle-BackColor="LightGray"
                                EmptyDataText="No files uploaded">
                                <Columns>
                                    <asp:BoundField DataField="Code" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-Width="15%" HeaderText="Code" />
                                    <asp:BoundField DataField="FileName" ItemStyle-Width="60%" HeaderText="File Name" />
                                     <asp:TemplateField ItemStyle-Width="15%" HeaderText="Category">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlFileType" runat="server" Width="100%" SelectedValue='<%# Eval("FileTypeCode") %>' SelectMethod="GetAll_FileTypes" Enabled="false"  DataValueField="Code" DataTextField="Name"  AutoPostBack="true"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                                    <asp:BoundField DataField="FileID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-Width="15%" HeaderText="File ID" />
                                    <asp:BoundField DataField="FileSize" ItemStyle-Width="10%" HeaderText="Size" />
                                    <asp:BoundField DataField="UserID"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="User ID" />
                                    <asp:BoundField DataField="UploadFileDate" ItemStyle-Width="20%" DataFormatString = "{0:dd/MM/yyyy}" HeaderText=" Date" />
                                    <asp:TemplateField ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDownload" Text="Download" CommandArgument='<%# Eval("FileID") %>' runat="server" OnClick="lnkDownload_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                     </div>
                          
                         </div>
                        <div class="row">
                         <div class="col-md-12">
                            <asp:UpdatePanel runat="server" ID="UpdatePanelGrid">
                            <ContentTemplate>
                            <asp:TextBox ID="txtComment" Width="78%" BackColor="LightYellow" runat="server"></asp:TextBox>
                            <asp:Button ID="btnAddComment" Width="20%" runat="server" class="btn btn-primary" Text="Add Comment" OnClick="btnAddComment_Click" />
                            
                                <asp:GridView ID="GridLog" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="false"
                                    BorderColor="#CC9966" BorderStyle="None" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="yellow"><tr><td style="text-align: center; vertical-align: middle;font-weight: bold;font-size: 18px;"> Log </td></tr></table>'
                                    BorderWidth="1px" CellPadding="4" HeaderStyle-BackColor="LightGray"
                                    EmptyDataText="No Log">
                                    <Columns>
                                        <asp:BoundField DataField="UserID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-Width="10%" HeaderText="Note writer" />
                                        <asp:BoundField DataField="CheckerName" ItemStyle-Width="25%" HeaderText="Note writer" />
                                        <asp:BoundField DataField="LogDate" DataFormatString = "{0:dd/MM/yyyy hh:mm}" ItemStyle-Width="25%" HeaderText="Date" />
                                         <asp:TemplateField ItemStyle-Width="20%" HeaderText="Category"  ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlCategory" runat="server" Enabled="false" Width="100%" SelectMethod="GetAll_FileTypes"  DataValueField="Code" DataTextField="Name" ></asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Comment" ItemStyle-Width="50%" HeaderText="Comment" />
                                    </Columns>
                                </asp:GridView>
                           
                            </ContentTemplate>
                            </asp:UpdatePanel>
                          </div>
                         </div>
                          
                            

                       <div class="row" >
                          <div class="col-md-4">  
                             <h4>  Regional    <asp:CheckBox ID="Chk_Regional"    runat="server" /></h4> 
                        </div>
                         <div class="col-md-4">  
                            <h4>  International  <asp:CheckBox ID="Chk_International"   runat="server" /></h4>
                        </div>
                         <div class="col-md-4">  
                             <h4>
                                 <%--Global --%>
                                 <asp:CheckBox ID="Chk_Gloabal"  Visible="false" runat="server" /></h4>
                        </div>
                       </div>
                        <hr />
                       <div class="row" >
                           <asp:UpdatePanel runat="server" ID="IDUpdatePanelCheck">
                               <ContentTemplate>
                                <div class="col-md-4">  
                                    <h4>  Complete  <asp:CheckBox ID="Chk_Complete"  AutoPostBack="true"   OnCheckedChanged="Chk_Complete_CheckedChanged" runat="server" /></h4>
                                </div>
                                 <div class="col-md-4">  
                                     <h4>  Incomplete  <asp:CheckBox ID="Chk_InComplete"  AutoPostBack="true"  OnCheckedChanged="Chk_InComplete_CheckedChanged" runat="server" /></h4>
                                </div>
                                <%-- <div class="col-md-4">  
                                       <h4>  Reject  <asp:CheckBox ID="Chk_Close" AutoPostBack="true" Visible="false"  OnCheckedChanged="Chk_Close_CheckedChanged" runat="server" /></h4>
                                </div>--%>
                                   </ContentTemplate>
                               </asp:UpdatePanel>
                       </div>
                        </div>
                        <div class="modal-footer">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                               <ContentTemplate>
                         <%--   <asp:Button ID="btnIsSpecial" enabled="true" runat="server" Text="Featured Expertise Done" OnClick="btnIsSpecial_Click"
                                AutoPostBack="true"  ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />--%>

                            <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                            <asp:Button ID="btnReview" enabled="false" runat="server" Text="Review Done" OnClick="btnReview_Click"  AutoPostBack="true"  ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                          </ContentTemplate>
                               </asp:UpdatePanel>
                                   </div>
                    </div>

                </div>
            </div>

          <asp:UpdatePanel runat="server" ID="UpdatePanel_ModalCV">
                                  <ContentTemplate>
        <div  class="modal fade" id="itemModalCV" role="dialog"  data-backdrop="static" data-keyboard="false" aria-labelledby="myModalLabel" aria-hidden="true">
              <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                
                            </button>
                            <h4 class="modal-title" id="myModalLabel1"> AD
                            </h4>
                        </div>
                        <div class="modal-body">

                    <div  class="col-md-12" style="border:groove">
                           <asp:Label ID="field1"   runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                           <asp:Label ID="field2"  runat="server"></asp:Label>
                     </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                            <asp:Label ID="field3" Text="" runat="server"> </asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                         <asp:Label ID="field4" Text="" runat="server"></asp:Label>
                     </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove"  >
                            <asp:Label ID="field5" Text="" runat="server">  </asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                    <asp:Label ID="field6" Text="ddd" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                            <asp:Label ID="field7" Text="" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                        <asp:Label ID="field8" Text="" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                        <asp:Label ID="field9" Text="" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12" style="border:groove">
                         <asp:Label ID="field10" Text="" runat="server"></asp:Label>
                    </div>
                    <br />
                    <br />
                    <div class="modal-footer">
                        <asp:Button ID="btnBack" runat="server" Text="Back"  OnClick="btnBack_Click"  AutoPostBack="true" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
<%--                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />--%>
                    </div>
                    </div>

                </div>
            </div>

        </div>
                                         </ContentTemplate>
                            </asp:UpdatePanel>




        </contenttemplate>
    <div class="modal fade" id="itemModalPopUp" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label runat="server">This field will not be active, are you sure you want to continue?</asp:Label>
                    <asp:Button ID="Yes" runat="server" Text="Yes" OnClick="Yes_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                    <asp:Button ID="No" runat="server" Text="No" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
