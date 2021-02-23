<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="CustomNotification.aspx.cs" Inherits="BTS.PL.Forms.Settings.CustomNotification" %>
<%@ Register Assembly="Syncfusion.EJ.Web, Version=15.4460.0.17, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">


     <div class="col-md-8">                 
            Notification Description<asp:TextBox ID="txtNotificationDescription" CssClass="form-control"  runat="server" /> 
     </div>

       <div class="col-md-8" style="width:100%">
           <asp:RadioButtonList ID="rbl_SendingOptions" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbl_SendingOptions_SelectedItemChanged">
               <asp:ListItem runat="server" text="All" Selected="True" ></asp:ListItem>
               <asp:ListItem runat="server" text="All RCC"></asp:ListItem>
               <asp:ListItem runat="server" text="All RUC"></asp:ListItem>
               <asp:ListItem runat="server" text="Exact Contact"></asp:ListItem>
               <asp:ListItem runat="server" text="Due Payments"></asp:ListItem>
           </asp:RadioButtonList>
       </div>
      
      <div class="col-md-8">
           <div class="col-md-8" runat="server" id="divExp" Visible="false">
                       Expertise  <asp:DropDownList ID="ddlExpertise" runat="server"  CssClass="form-control"  DataTextField="Name" DataValueField="Code" OnSelectedIndexChanged="ddlExpertise_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
           </div>
          <div class="col-md-8"  runat="server" id="divCity">
                       City  <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control"  DataTextField="CityNameEn" DataValueField="Code" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"  AutoPostBack="true">
                                </asp:DropDownList>
           </div>

           </div>

      
       <div  runat="server" id="DuePayments" visible="false">
           <div class="col-md-8">
               Booking Date    <ej:DatePicker ID="dtBookingDate"  runat="server" OnSelect="dtSelectedChanged"></ej:DatePicker>
           </div>
                     
                <asp:GridView ID="gvBookingData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" once
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="Booking Code" />
                    <asp:BoundField DataField="RUCContactCode" HeaderText="RUC" />
                    <asp:BoundField DataField="BookDate" HeaderText="BookDate" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                   
                      <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" SelectedID='<%# Eval("Code") %>' CausesValidation="false" OnClick="btnDeleteBooking_Click"
                                ImageUrl="~/client/images/delitem.gif" OnClientClick="return confirm('Item will be deleted, Continue?');" />
                        </ItemTemplate>
                    </asp:TemplateField>

                     </Columns>
            </asp:GridView>



           </div>


       <div  runat="server" id="divAddContacts" visible="false">
           <div class="col-md-8">
               User Name  <asp:DropDownList ID="ddlContact" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlContact_SelectedIndexChanged" AutoPostBack="true">
                 </asp:DropDownList>
           </div>
                     
                <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" once
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2">
                <Columns>
                    <asp:BoundField DataField="ContactKeyEmail" HeaderText="Contact Email" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="MoblieNo" HeaderText="Moblie Number" />
                   
                      <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" SelectedID='<%# Eval("Code") %>' CausesValidation="false" OnClick="btnDelete_Click"
                                ImageUrl="~/client/images/delitem.gif" OnClientClick="return confirm('Item will be deleted, Continue?');" />
                        </ItemTemplate>
                    </asp:TemplateField>

                     </Columns>
            </asp:GridView>



           </div>





         <div class="col-md-8" style="width:100%">
             <div class="col-md-4" >
          <asp:Button ID="btnSearch" runat="server" Text="Send" class="btn btn-primary" OnClick = "btnSendNotification_Click" />
             </div>
         </div>



</asp:Content>