<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="SuggestionExpertise.aspx.cs" Inherits="BTS.PL.Forms.Settings.SuggestionExpertise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .hiddencol {
            display: none;
        }
              </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
     <ContentTemplate>
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
         <div class="row">
               <div class="col-md-2">
                  <asp:Label  Text="State" runat="server" Width="100%"  AutoPostBack="false" ID="Label2"></asp:Label>
             </div>

             <div class="col-md-4">
                   <asp:DropDownList ID="ddlState" AutoPostBack="false" Width="100%"  runat="server" >
                    <asp:ListItem Text=" Inserted" Value="1"></asp:ListItem>
                     <asp:ListItem Text=" Not Inserted" Value="2"></asp:ListItem>
                       </asp:DropDownList>
                
             </div>
                 <div class="col-md-2">     
                  <asp:Button ID="btnSearch"  runat="server" class="btn btn-primary" Width="100%" Text="Search" OnClick="btnSearch_Click" />
              </div>
         </div>
      <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                <Columns>
                    <asp:BoundField DataField="ContactCode" HeaderText="Contact Code" />
                    <asp:BoundField DataField="Parent" HeaderText="Expertise Parent" />
                  <asp:BoundField DataField="Date" HeaderText="Expertise Date" />

                    <asp:BoundField DataField="Title" HeaderText="Title"  ItemStyle-Width="50%" />
                     <asp:BoundField DataField="Discreption" HeaderText="Discreption"  ItemStyle-Width="50%" />
                    <asp:BoundField DataField="MonthlySalary" HeaderText="Net Monthly Salary"  ItemStyle-Width="50%" />

                    <asp:TemplateField HeaderText="Is Inserted">
                        <ItemTemplate>
                            <div>
<%--                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />--%>
                                <asp:CheckBox ID="cbxSelectedItemIsActive" Enabled="false" Font-Bold="true" runat="server"
                                    OnClientClick="return confirm('Item activation will be changed, Continue?');" SelectedID='<%# Eval("Code") %>' 
 Checked='<%# Eval("InsertYN") %>' AutoPostBack="true" OnCheckedChanged="cbxSelectedItemIsActive_CheckedChanged" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
       
                                 <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false" OnClick="btnEdit_Click"
                                 SelectedID='<%# Eval("Code") %>'  CommandName='<%# Eval("Code") %>'
                                ImageUrl="~/client/images/edititem.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>              
                </Columns>
            </asp:GridView>
         </ContentTemplate>
</asp:Content>
