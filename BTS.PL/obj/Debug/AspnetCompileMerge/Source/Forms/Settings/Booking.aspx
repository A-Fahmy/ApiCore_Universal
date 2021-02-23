<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPages/Admin.Master" CodeBehind="Booking.aspx.cs" Inherits="BTS.PL.Forms.Settings.Booking" EnableEventValidation="false" %>

<%@ Register Assembly="Syncfusion.EJ.Web, Version=15.4460.0.17, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?libraries=places&sensor=false&key=AIzaSyCDRDaDCIOXZnQvCpOKyUAg5LjMt0hN2_Q"></script>
<script type="text/javascript">
    function GetAddress() {
        var latlng = new google.maps.LatLng(30.0518868, 31.3368591);
        var geocoder = geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[1]) {
                    alert("Location: " + results[1].formatted_address);
                }
            }
        });
    }
</script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

     <div class="col-md-8" style="width:100%">
    <div class="col-md-4">
                 RCC
                <asp:TextBox ID="txtRCC" CssClass="form-control" TextMode="Number" runat="server" min="1" /> 
        </div>
     <div class="col-md-4">
                 RUC
                <asp:TextBox ID="txtRUC" CssClass="form-control" TextMode="Number"  runat="server" min="1"  /> 
           </div>
          </div>
    <div class="col-md-8" style="width:100%">
      <div class="col-md-4">

                       Expertise         <asp:DropDownList ID="ddlExpertise" runat="server" CssClass="form-control"  DataTextField="ExpertiseNameEN" DataValueField="ExpertiseCode" OnSelectedIndexChanged="ddlExpertise_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
           </div>
     <div class="col-md-4">

                         ERCL        <asp:DropDownList ID="ddlRCL" runat="server" CssClass="form-control"  DataTextField="Name" DataValueField="Code" AutoPostBack="true">
                                </asp:DropDownList>
         </div>
         </div>
    <div class="col-md-8" style="width:100%">
    <div class="col-md-4">
           From Date    <ej:DatePicker ID="dtPickerFrom" runat="server"  ></ej:DatePicker>
        </div>

     <div class="col-md-4">
            To Date    <ej:DatePicker ID="dtPickerTo" runat="server"></ej:DatePicker>
        </div>
        </div>
    <div class="col-md-8" style="width:100%">
    <div class="col-md-4" >

                       Booking Status         <asp:DropDownList ID="ddlBookingStatus" runat="server" CssClass="form-control"  AutoPostBack="true">
                                </asp:DropDownList>
          </div>

          <div class="col-md-4" >

                       City        <asp:DropDownList ID="ddlCity" runat="server" DataTextField="CityNameEn" DataValueField="Code" CssClass="form-control"  AutoPostBack="true">
                                </asp:DropDownList>
          </div>

        </div>
         <div class="col-md-8" style="width:100%">
             <div class="col-md-4" >
          <asp:Button style="margin-bottom:20PX;" ID="btnSearch" runat="server" Text="Apply" class="btn btn-primary" OnClick = "btnSearch_Click" />
             </div>
             <div class="col-md-4" >
             <asp:Button style="margin-bottom:20PX;" ID="btnExportToExcelSheet" runat="server" Text="Export To Excel Sheet" class="btn btn-primary" OnClick="btnExportToExcelSheet_Click" />
             </div>
         </div>
            <asp:GridView ID="gvData" runat="server" CssClass="table table-responsive" AutoGenerateColumns="false" OnPageIndexChanging="gvData_PageIndexChanging"
                BorderWidth="0" HeaderStyle-BackColor="#e2e2e2" PageSize="20" AllowPaging="True" PagerSettings-Mode="Numeric">
                <PagerStyle CssClass="cssPager" />
                <Columns>
                     <asp:BoundField DataField="BookCode" HeaderText="Booking Code" />
                    <asp:BoundField DataField="RCCContactCode" HeaderText="RCC" />
                    <asp:BoundField DataField="RUCContactCode" HeaderText="RUC" />
                    <asp:BoundField DataField="ExpertiseNameEN" HeaderText="Expertise" />
                    <asp:BoundField DataField="RCLNameEN" HeaderText="ERCL" />
                    <asp:BoundField DataField="BookDate" HeaderText="Date" />
                    <asp:BoundField DataField="BookDuration" HeaderText="Duration" />
                    <asp:BoundField DataField="BookStatus" HeaderText="Status" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                </Columns>
            </asp:GridView>
 
    
</asp:Content>

