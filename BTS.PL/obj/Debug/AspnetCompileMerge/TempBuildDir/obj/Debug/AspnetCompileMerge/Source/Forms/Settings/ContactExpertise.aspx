<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ContactExpertise.aspx.cs" Inherits="BTS.PL.Forms.Settings.ContactExpertise" EnableEventValidation="false" %>

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
  
    <div class="col-md-8" style="width:100%">

    <div class="col-md-4">
        <asp:Button ID="btnAddNewItem" Enabled="false" runat="server" Text="Add" class="btn btn-primary" OnClick="btnAddNewItem_Click" />
    </div>

    <div class="col-md-4">
                  User Name         <asp:DropDownList ID="ddlContactExpertise" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlContactExpertise_SelectedIndexChanged" AutoPostBack="true">
    </asp:DropDownList>
    </div>

    </div>
            <asp:Button ID="btnExportToExcelSheet" runat="server" Text="Export To Excel Sheet" class="btn btn-primary" OnClick="btnExportToExcelSheet_Click" />
            <br />
            <br />
            <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" OnPageIndexChanging="gvData_PageIndexChanging"
                 AllowPaging="True" PagerSettings-Mode="Numeric" PageSize="20" EnableCaching="false">
                <PagerStyle CssClass="cssPager" />
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="User Name" />
                    <asp:BoundField DataField="ExpertiseLevelName2_EN_SQLLite" HeaderText="Expertise" />
                    <asp:BoundField DataField="ExpertiseLevelName3_EN_SQLLite" HeaderText="ERCL" />
                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsActive" Enabled="true" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' 
                                    Checked='<%# Eval("IsActive") %>' AutoPostBack="true" 
                                    OnCheckedChanged="cbxSelectedItemIsActive_CheckedChanged" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false"
                                 SelectedID='<%# Eval("Code") %>'
                                ImageUrl="~/client/images/edititem.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" SelectedID='<%# Eval("Code") %>' CausesValidation="false" 
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
                            <h4 class="modal-title" id="myModalLabel"> Add Expertise RCL
                            </h4>
                        </div>
                        <div class="modal-body">
                            <div class="col-md-4">
                                Expertise Name
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlExpertise" class="dropmenu" AutoPostBack="true" runat="server" DataTextField="ExpertiseNameEN" DataValueField="ExpertiseCode" OnSelectedIndexChanged="ddlExpertise_SelectedIndexChange" ></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlExpertise" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <br />
                            <div class="col-md-4">
                                RCL Name
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList ID="ddlRCL" class="dropmenu" AutoPostBack="true" runat="server" DataTextField="Name" DataValueField="Code" OnSelectedIndexChanged="ddlRCL_SelectedIndexChange" ></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="ddlRCL" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <br />
                            <br />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" class="btn btn-default" data-dismiss="modal" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="EditForm" CausesValidation="true" class="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
     

    <div class="modal fade" id="itemModalPopUp" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <asp:Label runat="server">The active property of this field will be changed, are you sure you want to continue?</asp:Label>
                    <asp:Button ID="Yes" runat="server" Text="Yes" OnClick="Yes_Click" class="btn btn-primary" />
                    <asp:Button ID="No" runat="server" Text="No" OnClick="No_Click" class="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

