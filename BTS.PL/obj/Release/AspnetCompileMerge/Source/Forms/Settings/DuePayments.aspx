<%@ Page Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="DuePayments.aspx.cs" Inherits="BTS.PL.Forms.Settings.DuePayments"EnableEventValidation="false" %>

<%@ Register Assembly="Syncfusion.EJ.Web, Version=15.4460.0.17, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

              <div class="col-md-8">
                  Date    <ej:DatePicker ID="dtBookingDate"  runat="server" OnSelect="dtBookingDate_Changed" ></ej:DatePicker>
               </div>

              <div class="col-md-8" >
                <asp:Button style="margin-top:20px;"  ID="btnExportToExcelSheet" runat="server" Text="Export To Excel Sheet" class="btn btn-primary" OnClick="btnExportToExcelSheet_Click" />
              </div>

              <div class="col-md-8">
                <asp:CheckBox Visible="false" Text="Mark All" ID="cbxMarkAll" Enabled="true" Font-Bold="true" runat="server" style="margin-top:20px;"
                                    OnCheckedChanged="cbxMarkAll_CheckedChanged" AutoPostBack="true" />
               </div>

             
      <div class="col-md-8" style="width:100%">

     <%--<div class="col-md-4" >--%>
         <%-- <asp:Button ID="btnSearch" runat="server" Text="Apply" style="margin-bottom:20PX;" class="btn btn-primary" OnClick = "btnSearch_Click" />
         </div>--%>

          
          </div>
                     
                <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" once
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2" OnPageIndexChanging="gvData_PageIndexChanging" AllowPaging="True" PagerSettings-Mode="Numeric" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                    <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                    <asp:BoundField DataField="BankAccountNumber" HeaderText="Bank Account Number" />
                    <asp:BoundField DataField="BankCode" HeaderText="Bank Code" />
                    <asp:BoundField DataField="BankBranchCode" HeaderText="Bank Branch Code" />
                   
                       <asp:TemplateField HeaderText="Is Sent">
                        <ItemTemplate>
                            <div>
                                <asp:HiddenField runat="server" Value='<%#Eval("Code") %>' />
                                <asp:CheckBox ID="cbxSelectedItemIsActive" Enabled="true" Font-Bold="true" runat="server"
                                    SelectedID='<%# Eval("Code") %>' Checked='<%# Eval("IsSent") %>' AutoPostBack="true" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                     </Columns>
               </asp:GridView>

</asp:Content>