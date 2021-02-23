<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Financial.aspx.cs" MasterPageFile="~/MasterPages/Admin.Master" Inherits="BTS.PL.Forms.Settings.Financial" EnableEventValidation="false" %>
<%@ Register Assembly="Syncfusion.EJ.Web, Version=15.4460.0.17, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

     <div class="col-md-8" style="width:100%">
    <div class="col-md-4">
                 Contact Code
                <asp:TextBox ID="txtUserCode" CssClass="form-control" TextMode="Number" runat="server" min="1" /> 
        </div>

         <div class="col-md-4">
                 Reference Number
                <asp:TextBox ID="txtRefrenceNumber" CssClass="form-control"  runat="server"  /> 
        </div>
          </div>

    <div class="col-md-8" style="width:100%">
    <div class="col-md-4" >

                        Status    <asp:DropDownList ID="ddlBookingStatus" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBookingStatus_SelectedIndexChanged"  AutoPostBack="true">
                                </asp:DropDownList>
          </div>

        <div class="col-md-4">
                 Amount
                <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" /> 
        </div>

        </div>
       

    <div id="dtPicker_div" runat="server" class="col-md-8" style="width:100%;margin-bottom:20PX;" visible="false">
    <div class="col-md-4" >
           Payment Date    <ej:DatePicker ID="dtPickerPayment" runat="server"  ></ej:DatePicker>
        </div>
        </div>

      <div  class="col-md-8" style="width:100%">
             <div class="col-md-4" >
          <asp:Button ID="btnSearch" runat="server" Text="Apply" style="margin-bottom:20PX;" class="btn btn-primary" OnClick = "btnSearch_Click" />
         </div>
           <div class="col-md-4" >
             <asp:Button ID="btnExportToExcelSheet" runat="server" Text="Export To Excel Sheet" style="margin-bottom:20PX;" class="btn btn-primary" OnClick="btnExportToExcelSheet_Click" />
             </div>
         </div>            

            <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" OnPageIndexChanging="gvData_PageIndexChanging"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2" AllowPaging="True" PageSize="20" PagerSettings-Mode="Numeric">
                <PagerStyle CssClass="cssPager" />
                <Columns>
                     <asp:BoundField DataField="BookingCode" HeaderText="Booking Code" />
                    <asp:BoundField DataField="UserCode" HeaderText="Contact Code" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    <asp:BoundField DataField="Cr_Dr" HeaderText="Credit/Debit" />
                    <asp:BoundField DataField="PaymentStatus" HeaderText="Payment Status" />
                    <asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" />
                    <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" />
                    <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                      <asp:TemplateField HeaderText="Booking Details">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnBooking_details" runat="server" CausesValidation="false"
                                OnClick="btnBooking_details_Click" SelectedID='<%# Eval("BookingCode") %>'
                                ImageUrl="~/client/images/search.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                  
                </Columns>
            </asp:GridView>
 
    
</asp:Content>