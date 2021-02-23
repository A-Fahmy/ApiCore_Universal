<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.Master"  AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="BTS.PL.Forms.Settings.ContactForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showEditForm() {
            $("#itemModal").modal();
        } 
        function showAlertPopUp() {
            $("#itemModalPopUp").modal();
        }
    </script>
        <script type="text/javascript">
        function showAlternativeForm() {
            $("#alternativeModal").modal();
        } 
        function showAlertPopUp() {
            $("#alternativeModalPopUp").modal();
        }
    </script>
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
        <ContentTemplate>
           <div class="col-md-8">
                               From Contact Code
                <asp:TextBox ID="txtFromContactCode" CssClass="form-control" TextMode="Number" runat="server" min="1"  />
                            
<%--             <asp:RequiredFieldValidator ID="rv_txtFromContact" runat="server" ControlToValidate="txtFromContactCode" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>--%>
               </div>
            <div class="col-md-8">
                                To Contact Code
                 <asp:TextBox ID="txtToContactCode" CssClass="form-control" TextMode="Number" runat="server" min="1"  />
                            
          <%--  <asp:RequiredFieldValidator ID="rv_txtToContact" runat="server" ControlToValidate="txtToContactCode" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>--%>
                </div>
            <div class="col-md-4">
             <asp:Button ID="btnSearch" runat="server" Text="Apply" class="btn btn-primary" OnClick = "btnSearch_Click" />
                </div>
            
            <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" OnPageIndexChanging="gvData_PageIndexChanging"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2" AllowPaging="True" PageSize="30" PagerSettings-Mode="Numeric">
                <PagerStyle CssClass="cssPager" />
                <Columns>
                    <asp:BoundField DataField="ContactKeyEmail" HeaderText="Contact Email" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="MoblieNo" HeaderText="Moblie Number" />
                    <asp:BoundField DataField="Rating" HeaderText="Rating" />
                    <asp:BoundField DataField="CountRootExpertise" HeaderText="Root Expertise Number" />
                   <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsActive" Enabled="false" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("IsActive") %>' AutoPostBack="true" OnCheckedChanged="cbxSelectedItemIsActive_CheckedChanged" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valid Phone Number">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="ChkIsValidPhoneNumberYN" Enabled="false" Font-Bold="true" runat="server"
                                   SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("IsValidPhoneNumberYN") %>' AutoPostBack="true" OnCheckedChanged="cbxSelectedItemIsValidPhoneNumberYN_CheckedChanged" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Rise Certified" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                              <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsRegional" Enabled="false" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("RiseCertifyYN") %>' AutoPostBack="false" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false"
                                OnClick="btnEdit_Click" SelectedID='<%# Eval("Code") %>'
                                ImageUrl="~/client/images/edititem.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Alternative Contacts">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlternative" runat="server" CausesValidation="false"
                                OnClick="btnAlternative_Click" SelectedID='<%# Eval("Code") %>'
                                ImageUrl="~/client/images/edititem.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" SelectedID='<%# Eval("Code") %>' CausesValidation="false" OnClick="btnDelete_Click"
                                ImageUrl="~/client/images/delitem.gif" OnClientClick="return confirm('Item will be deleted, Continue?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="modal fade" id="itemModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×
                            </button>
                            <h4 class="modal-title" id="myModalLabel">Update Contact
                            </h4>
                        </div>
                        <div class="modal-body">

                            <div class="col-md-4">
                               Rating
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtRating" CssClass="form-control" TextMode="Number" runat="server" min="1" max="5" step="1" />
                                <asp:RequiredFieldValidator ID="rv_txtRating" runat="server" ControlToValidate="txtRating" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-4">
                               Root Expertise Number
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtRootExp_Number" CssClass="form-control" TextMode="Number" runat="server" min="0" max="10" step="1" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRootExp_Number" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                           <div class="col-md-4">
                                    Is Active
                               <asp:CheckBox ID="ChkIsActive" Enabled="false" Checked="true"  runat="server" />
                           </div>
                             <div class="col-md-4">
                                    Valid Phone Number
                               <asp:CheckBox ID="ChkIsValidPhoneNumberYN" Enabled="false" Checked="true"  runat="server" />
                           </div>
                             <div class="col-md-4">
                                    Rise Certified
                               <asp:CheckBox ID="ChkRiseCertified" Enabled="true" Checked="true"  runat="server" />
                           </div>

                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                        </div>
                    </div>

                </div>
            </div>
               <div class="modal fade" id="alternativeModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×
                            </button>
                            <h4 class="modal-title" id="alternativeModalLabel">Alternative Contacts
                            </h4>
                        </div>
                        <div class="modal-body">
                             
            <asp:GridView ID="GVAlternative" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" OnPageIndexChanging="gvData_PageIndexChanging"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2" AllowPaging="True" PageSize="30" PagerSettings-Mode="Numeric">
                <PagerStyle CssClass="cssPager" />
                <Columns>
                    <asp:BoundField DataField="ContactKeyEmail" HeaderText="Contact Email" />
                    <asp:BoundField DataField="alternativeName" HeaderText="Alternative Contacts" />
<%--                    <asp:BoundField DataField="alternativeType" HeaderText="Types" />--%>
                         <asp:TemplateField ItemStyle-Width="20%" HeaderText="Types">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlalternativeType" runat="server" Width="100%" SelectMethod="GetAll_AlternativeTypes" SelectedValue='<%# Eval("alternativeType") %>' Enabled="false"  DataValueField="Code" DataTextField="Name" AutoPostBack="true"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="Description " />
                    
                  
                  

             
                </Columns>
            </asp:GridView>
                           

                           
                        </div>
                        <div class="modal-footer">
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
      <div  class="modal fade" id="alternativeModalPopUp" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
         <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
        <asp:Label  runat="server">This field will not be active, are you sure you want to continue?</asp:Label>
        <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="Yes_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
        <asp:Button ID="btnNo" runat="server" Text="No" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
    </div>
               </div>
            </div>
        </div>
</asp:Content>
