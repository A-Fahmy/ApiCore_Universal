<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="RCLs.aspx.cs" Inherits="BTS.PL.Forms.Settings.RCLs" %>

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
            <asp:Button ID="btnAddNewItem" runat="server" Text="Add New RCL" class="btn btn-primary" OnClick="btnAddNewItem_Click" />
            <br />
            <br />
            <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                <Columns>
                    <asp:BoundField DataField="RCLNameEn" HeaderText="English Name" />
                    <asp:BoundField DataField="RCLNameAr" HeaderText="Arabic Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="YearsOfExperience" HeaderText="Years Of Experience" />
                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsActive" Enabled="false"  Font-Bold="true" runat="server"
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
                                ×
                            </button>
                            <h4 class="modal-title" id="myModalLabel">Add RCL
                            </h4>
                        </div>
                        <div class="modal-body">
                            <div class="col-md-4">
                                English Name
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4">
                                Arabic Name
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtNameAr" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvNameAr" runat="server" ControlToValidate="txtNameAr" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4">
                                Description
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3" Columns="10" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                              <div class="col-md-4">
                                Years Of Experience 
                            </div>
                             <div class="col-md-8">
                                <asp:TextBox ID="txtYearsOfExperience" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtYearsOfExperience" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                             <div class="col-md-4">
                                  Is Active
                                  <asp:CheckBox ID="ChkIsActive" Enabled="false" Checked="true"  runat="server" />
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
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                        </div>
                    </div>

                </div>
            </div>
     

       <div class="modal fade" id="itemModalPopUp" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label runat="server" >This field will not be active, are you sure you want to continue?</asp:Label>
                    <asp:Button ID="Yes" runat="server"  Text="Yes" OnClick="Yes_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                    <asp:Button ID="No" runat="server"  Text="No" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
