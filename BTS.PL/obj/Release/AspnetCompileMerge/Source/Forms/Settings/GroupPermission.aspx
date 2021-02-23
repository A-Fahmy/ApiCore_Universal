<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="GroupPermission.aspx.cs" Inherits="BTS.PL.Forms.Settings.GroupPermission" %>


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
<%--        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>

                    <div class="col-md-2">
                                Group
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlGroup" runat="server" class="dropmenu" DataTextField="Name" DataValueField="Code" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupPermissionView">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvGroup" runat="server" ControlToValidate="ddlGroup" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
    <div class="col-md-4"> 
                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" OnClick="btnSave_Click" />

    </div>
    <br />
    <br />
<%--    <div class="col-md-5"></div>--%>

    View All
    <div class="col-md-1">
         
         <asp:CheckBox ID="cbxSelectedItemAllIsView" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');"   AutoPostBack="true" OnCheckedChanged="cbxSelectedItemAllIsView_CheckedChanged" />
                           
    </div>
    <br />
        Save All  
    <div class="col-md-1">
     
         <asp:CheckBox ID="cbxSelectedItemAllIsSave" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');"   AutoPostBack="true" OnCheckedChanged="cbxSelectedItemAllIsSave_CheckedChanged" />
                           
    </div>
    <br />
     Edit All

    <div class="col-md-1">
            
         <asp:CheckBox ID="cbxSelectedItemAllIsEdit" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');"   AutoPostBack="true" OnCheckedChanged="cbxSelectedItemAllIsEdit_CheckedChanged" />
                           
    </div>
    <br />
     Delete All
    <div class="col-md-1">
                   

         <asp:CheckBox ID="cbxSelectedItemAllIsDelete" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');"   AutoPostBack="true" OnCheckedChanged="cbxSelectedItemAllIsDelete_CheckedChanged" />
                         </div> 
    <br />
    Select All
             <div class="col-md-1">
                   

         <asp:CheckBox ID="cbxSelectedItemAllIsSelected" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');"   AutoPostBack="true" OnCheckedChanged="cbxSelectedItemAllIsSelected_CheckedChanged" />
                         </div>  
    
    <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
       
    OnSelectedIndexChanged="OnSelectedIndexChanged"        BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                <Columns>
                    <asp:BoundField DataField="Code"  HeaderText="User Code" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                   
<%--                    <asp:BoundField DataField="GroupID" HeaderText="Group" />--%>
                  <asp:BoundField DataField="PageName" HeaderText="Page Name" />
                  <asp:BoundField DataField="URLPageName" HeaderText="Page Name"  ItemStyle-CssClass ="hiddencol" HeaderStyle-CssClass="hiddencol" />


                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsView" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("ViewYN") %>' AutoPostBack="false" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Save">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsSave" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("SaveYN") %>' AutoPostBack="false"  />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsEdit" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("EditYN") %>' AutoPostBack="false"  />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsDelete" Enabled="true" class="child" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("DeleteYN") %>' AutoPostBack="false"  />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Select All">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="parent" Enabled="true" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>'  AutoPostBack="true"  />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Select All">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false"
                                OnClick="btnEdit_Click" SelectedID='<%# Eval("Code") %>'  AutoPostBack="false"
                                ImageUrl="~/client/images/refresh.png"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Delete" Visible="false">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" SelectedID='<%# Eval("Code") %>' CausesValidation="false" OnClick="btnDelete_Click"
                                ImageUrl="~/client/images/delitem.gif" OnClientClick="return confirm('Item will be deleted, Continue?');" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
             
</asp:Content>
