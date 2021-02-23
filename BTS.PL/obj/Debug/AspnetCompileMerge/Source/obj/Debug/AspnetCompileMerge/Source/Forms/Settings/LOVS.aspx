<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="LOVS.aspx.cs"  ValidateRequest="false"  Inherits="BTS.PL.Forms.Settings.LOVS" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

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
    <asp:Button ID="btnAddNewItem" runat="server" Text="Add New LOV" class="btn btn-primary" OnClick="btnAddNewItem_Click" />
    <asp:DropDownList ID="ddlLOV_Type" Width="50%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLov_SelectedIdexChanged">
                                </asp:DropDownList>
    <br />
    <br />
    <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
        BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
        <Columns>
            <asp:BoundField DataField="DescriptionsEN" HeaderText="Descriptions English Name" />
            <asp:BoundField DataField="DescriptionsAR" HeaderText="Descriptions Arabic Name" />
            <asp:TemplateField HeaderText="Is Active" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <div>
                        <asp:HiddenField runat="server" Value='<%#Eval("LOVKey") %>' />
                        <asp:CheckBox ID="cbxSelectedItemIsActive" Font-Bold="true" Enabled="false" runat="server"
                            OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("LOVKey") %>' Checked='<%# Eval("IsActive") %>' AutoPostBack="true" OnCheckedChanged="cbxSelectedItemIsActive_CheckedChanged" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:ImageButton ID="btnViewImage" runat="server" CausesValidation="false"
                        OnClick="btnViewImage_Click" SelectedID='<%# Eval("LOVKey") %>' Width="20px" Height="20px"
                        ImageUrl="~/client/images/image.png" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false"
                        OnClick="btnEdit_Click" SelectedID='<%# Eval("LOVKey") %>'
                        ImageUrl="~/client/images/edititem.gif" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:ImageButton ID="btnDelete" runat="server" SelectedID='<%# Eval("LOVKey") %>' CausesValidation="false" OnClick="btnDelete_Click"
                        ImageUrl="~/client/images/delitem.gif" OnClientClick="return confirm('Item will be deleted, Continue?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="modal fade" id="itemModal"  role="dialog"   aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog_LOV" >
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×
                    </button>
                    <h4 class="modal-title" id="myModalLabel">Add LOV
                    </h4>
                </div>
                <div class="modal-body">
                     <%--<div class="col-md-4">
                        LOV Type
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtLOVType" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLOVType" ErrorMessage="*" ForeColor="Red"
                            ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                    </div>--%>
                    <div class="col-md-4">
                        English Name
                    </div>
                    <div class="col-md-8">
                       <FTB:FreeTextBox ID="txtNameHTML" runat="server" Width="600px" Height="200px"></FTB:FreeTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNameHTML" ErrorMessage="*" ForeColor="Red"
                         ValidationGroup="EditForm"></asp:RequiredFieldValidator>

                         <asp:TextBox ID="txtName" CssClass="form-control" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"
                            ValidationGroup="EditForm"></asp:RequiredFieldValidator>

                    </div>
                    <div class="col-md-4">
                        Arabic Name
                    </div>
                    <div class="col-md-8">

                          <FTB:FreeTextBox ID="txtNameArHTML" runat="server" Width="600px"  Height="200px">
                           </FTB:FreeTextBox>
                        <asp:RequiredFieldValidator ID="rfvNameAr" runat="server" ControlToValidate="txtNameArHTML" ErrorMessage="*" ForeColor="Red"
                            ValidationGroup="EditForm"></asp:RequiredFieldValidator>

                          <asp:TextBox ID="txtNameAr" CssClass="form-control" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNameAr" ErrorMessage="*" ForeColor="Red"
                            ValidationGroup="EditForm"></asp:RequiredFieldValidator>

                    </div>

                    <div class="col-md-4" id="HelpDiv1" runat="server" visible="false">
                                English Title
                            </div>
                            <div class="col-md-8" id="HelpDiv2" runat="server" visible="false" >
                                <asp:TextBox ID="txtTitleEN" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="rqvTitle" runat="server" ControlToValidate="txtTitleEN" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>

                     <div class="col-md-4" id="HelpDiv3" runat="server" visible="false">
                                Arabic Title
                            </div>
                            <div class="col-md-8" id="HelpDiv4" runat="server" visible="false" >
                                <asp:TextBox ID="txtTitleAR" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitleAR" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>

                    <div class="col-md-4">
                        Is Active
                          <asp:CheckBox ID="ChkIsActive" Enabled="false" Checked="true" runat="server" />
                    </div>
                   <%-- <div class="col-md-3">
                    </div>
                    <div class="col-md-3">
                    </div>
                    <br />
                    <br />
                    <br />--%>
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
                    <asp:Label runat="server">This field will not be active, are you sure you want to continue?</asp:Label>
                    <asp:Button ID="Yes" runat="server" Text="Yes" OnClick="Yes_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                    <asp:Button ID="No" runat="server" Text="No" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
