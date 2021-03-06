﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="BTS.PL.Forms.Settings.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
         <script type="text/javascript">
        function showEditForm() {
            $("#itemModal").modal();
        }
        function showAlertPopUp() {
            $("#itemModalPopUp").modal();
        }
    </script>
    <style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
      <ContentTemplate>
            <asp:Button ID="btnAddNewItem" runat="server" Text="Add New User" class="btn btn-primary" OnClick="btnAddNewItem_Click" />
            <br />
            <br />
          <asp:GridView ID="gvGetAllData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="User Code"  ItemStyle-CssClass ="hiddencol" HeaderStyle-CssClass="hiddencol" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Moblie" HeaderText="Mobile" />
                    <asp:BoundField DataField="NationalID" HeaderText="National ID" />

                    <asp:BoundField DataField="GroupID" HeaderText="Group" />

                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsActive" Enabled="false" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("IsActive") %>' AutoPostBack="true" OnCheckedChanged="cbxSelectedItemIsActive_CheckedChanged" />
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
                                
                            </button>
                            <h4 class="modal-title" id="myModalLabel">Add  User
                            </h4>
                        </div>
                        <div class="modal-body">

<%--                            <div class="col-md-4">
                                User Code
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtUserCode" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFileTypeCode" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>--%>

                            <div class="col-md-4">
                                User Name
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server"  OnTextChanged="txtName_TextChanged"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-12">
                            <asp:Label runat="server" ID="lblRe"></asp:Label>
                                </div>
                            <div class="col-md-4">
                                Password
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtPwd" CssClass="form-control"  runat="server" />
                                <asp:RequiredFieldValidator ID="rfvpwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="txtPwd"
 ErrorMessage="*Write 8 Numbers / uppercase and lowercase letters / Special character, e.g., ! @ # ? ] " 
 ValidationExpression="^((?=.*[A-Z])(?=.*\d)(?=.*[a-z])|(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%&\/=?_.-])|(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%&\/=?_.-])|(?=.*\d)(?=.*[a-z])(?=.*[!@#$%&\/=?_.-])).{8,15}$">

                                  </asp:RegularExpressionValidator>

                            </div>
                        <div class="col-md-4">
                                E-mail
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtmail" CssClass="form-control" runat="server" TextMode="Email" />
                                <asp:RequiredFieldValidator ID="rfvmail" runat="server" ControlToValidate="txtmail" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                              <div class="col-md-4">
                                National ID
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtNational" CssClass="form-control" runat="server"  />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNational" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNational" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^[0-9]{14}$"></asp:RegularExpressionValidator>

                            </div>
                             <div class="col-md-4">
                                Phone
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtMobile" CssClass="form-control"  runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobile" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                             <div class="col-md-4">
                                Group
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlGroup" runat="server" class="dropmenu" DataTextField="Name" DataValueField="Code">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvGroup" runat="server" ControlToValidate="ddlGroup" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                              <div class="col-md-4">
                                    Is Active
                               <asp:CheckBox ID="ChkIsActive" Enabled="false" Checked="true"  runat="server" />
                           </div>
                        </div>
                        
                            <br />
                            <br />
                            <br />  
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />  
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        <div class="modal-footer">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
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
