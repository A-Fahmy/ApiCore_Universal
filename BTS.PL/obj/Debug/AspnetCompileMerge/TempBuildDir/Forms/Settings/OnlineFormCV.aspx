<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineFormCV.aspx.cs" Inherits="BTS.PL.Forms.Settings.OnlineFormCV" %>

<style type="text/css">
    .hiddencol {
        display: none;
    }


    .table-condensed tr th {
        border: 1px solid #e5e5e5;
        color: white;
        background-color: #d36541;

        
    }

    .table-condensed, .table-condensed tr td {
        border: 1px solid #e5e5e5;
    }

    tr:nth-child(even) {
        background: #f8f7ff
    }


    tr:nth-child(odd) {
        background: #fff;
    }
</style>
<script type="text/javascript">
    function getUrlVars() {
        var vars = {};
        var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
            function (m, key, value) {
                vars[key] = value;
            });
        return vars;
    }
    
  



</script>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Rise - Admin</title>
    <!-- Bootstrap Core CSS -->
    <link href="/client/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- MetisMenu CSS -->
    <link href="/client/vendor/metisMenu/metisMenu.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="/client/dist/css/main.css" rel="stylesheet">
    <!-- Custom Fonts -->
    <link href="/client/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css">
    <script src="/client/vendor/jquery/jquery.min.js"></script>
  
</head>

<body>
    <form id="form1" runat="server">
       <%-- <div>
            <h1 style="position:center">Online Form </h1>
            <br />
             <div class="container">
                             <div class="row">

             <div class="col-md-3">
                                Contact 
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtContact" Enabled="true" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContact" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                                 </div>
              <br />
           
            <div class="row">
             <div class="col-md-3">
                                Field1 
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtfield1" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfield1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
              <br />
            <div class="row">
             <div class="col-md-3">
                                Field2 
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtfield2" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfield2" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
              <br />
            <div class="row">          
                <div class="col-md-3">
                                Field3 
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtfield3" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtfield3" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
                </div>
            <asp:ScriptManager ID="HEPCASCriptManager" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel runat="server" ID="UPanel">
                <ContentTemplate>
            <div class="col-md-4">
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" CausesValidation="false" class="btn btn-default"/>
                </div>            
                
                <div class="col-md-4">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"   class="btn btn-primary" />
       </div>
                        <div class="col-md-4">
            <asp:Button ID="btnOK" runat="server" Text="Ok"  OnClientClick="JavaScript:window.history.back(1); return false;"  class="btn btn-primary" />

       </div>
                    </ContentTemplate>
            </asp:UpdatePanel>--%>
        <asp:Panel ID="Panel1" runat="server" GroupingText="Personal Data" Font-Bold="true" Width="100%" Height="100%">
                  <div class="row">

             <div class="col-md-2">
                          <h4>      Contact</h4> 
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtContact" Enabled="true" CssClass="form-control" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtContact" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                                 </div>
             <div class="row">

             <div class="col-md-2">
                             <h4>   Name </h4>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtName" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
             <div class="col-md-2">
                              <h4>  Birthdate</h4> 
                            </div>
                            <div class="col-md-4">
                              <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="TxtBirthDate"></asp:TextBox>

                            </div>
                </div>
                          <div class="row">
 
            <div class="col-md-2">
                               <h4> High School </h4>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtHighSchool" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHighSchool" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
             <div class="col-md-2">
                 <h4>Name Of University</h4>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtNameOfUniversity" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNameOfUniversity" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
                       <div class="row">

            <div class="col-md-2">
 <h4> University School</h4>

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtUniversity" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUniversity" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
             <div class="col-md-2">
<h4>Post Graduate Certifications</h4>

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPostGraduated" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPostGraduated" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <asp:Panel ID="PanelHomeAdress" GroupingText="Home Adress" runat="server"  BorderStyle="Groove">
                          <div class="row">

             <div class="col-md-1">
<h4> Area/District</h4>

             </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtArea" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtArea" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
             <div class="col-md-1">
<h4> City  </h4>
             </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtCity" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCity" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
             <div class="col-md-1">
<h4>Governorate</h4>

             </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtGovernment" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtGovernment" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
                
            </asp:Panel>
            <br />
            <div class="row">
             <div class="col-md-6">
             <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100%" OnClientClick="JavaScript:window.history.back(1); return false;" CausesValidation="false" class="btn btn-default"/>
                </div> 
                <div class="col-md-6">
            <asp:Button ID="btnNexttoSecond" runat="server" Text="Next" Width="100%"  OnClick="btnNexttoSecond_Click" autoPostback="true"  class="btn btn-primary" />
       </div>
                 </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel2" GroupingText="Additional Data">
              <div class="row">
             <div class="col-md-3">
Qualifications

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtQualifications" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtQualifications" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            <div class="row">
             <div class="col-md-3">
Competencies

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtCompetencies" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCompetencies" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            <div class="row">
             <div class="col-md-3">
Skills


             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtSkills" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSkills" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
           <%-- <div class="row">
                <div class="col-md-3">
                    Languages
                </div>
                 <div class="col-md-4">
                   <asp:DropDownList ID="ddlLanguages" AutoPostBack="false"  runat="server" DataTextField="Name" DataValueField="Code"  >  </asp:DropDownList>
             </div>
            </div>--%>
            <div class="row">
             <div class="col-md-3">
Training

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtTraining" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtTraining" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            <div class="row">
             <div class="col-md-3">
Unions

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtUnions" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtUnions" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            <div class="row">
             <div class="col-md-3">
Social - Health Clubs

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtClubs" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtClubs" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            <div class="row">
             <div class="col-md-3">
Sports

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtSports" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtSports" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            <div class="row">
             <div class="col-md-3">
Scientific Societies


             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtScientific" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtScientific" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            <div class="row">
             <div class="col-md-3">
Other Info

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtInfo" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtInfo" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
        <div class="row">
                      
                <div class="col-md-4">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="100%"   class="btn btn-primary" />
       </div>
              <div class="col-md-4">
            <asp:Button ID="btnOK" runat="server" Text="Ok"  Width="100%" OnClientClick="JavaScript:window.history.go(-3); return false;"  class="btn btn-primary" />
       </div>
                      <div class="col-md-4">
            <asp:Button ID="btnPrevious1" runat="server" Text="Previous" OnClick="btnPrevious_Click" Width="100%" />
       </div>
             </div>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" GroupingText="Employment Record">

            <asp:Panel ID="CurrentJop" runat="server" Font-Bold="true" GroupingText="Current Employment" BorderStyle="Groove">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtTitle" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtCompany" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="lblStartDate"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="TxtStartDate"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="lblEndDate"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="TxtEndDate"  ></asp:TextBox>
             </div>
         </div>
                <br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtAchievement" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop" runat="server"  Font-Bold="true" GroupingText="Previous Employment" BorderStyle="Groove">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPreTitle1" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
           
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPreCompany1" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
                
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label1"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate2"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label2"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate2"  ></asp:TextBox>
             </div>
         </div>
                            <br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtPreAchievment1" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
            </asp:Panel>
                                    <asp:Panel ID="PreviousJop1" runat="server" GroupingText="Previous Employment" Font-Bold="true" BorderStyle="Groove">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle2" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
            
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany2" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
                
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label3"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate3"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label4"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate3"  ></asp:TextBox>
             </div>
         </div>
<br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement3" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop2" runat="server" GroupingText="Previous Employment" BorderStyle="Groove" Font-Bold="true">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle3" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
           
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany3" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                              
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label5"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate4"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="95%"  AutoPostBack="false" ID="Label6"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="100%" AutoPostBack="false" ID="txtEndDate4"  ></asp:TextBox>
             </div>
         </div>
                            <br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement4" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop3" runat="server" GroupingText="Previous Employment" BorderStyle="Groove" Font-Bold="true">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle4" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                           
                            </div>
           
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany4" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                            
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label7"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate5"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label8"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate5"  ></asp:TextBox>
             </div>
         </div>
                            <br />

                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAcvhievement5" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                             
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop4" runat="server" GroupingText="Previous Employment" BorderStyle="Groove" Font-Bold="true">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle5" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                              
                            </div>
           
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany5" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                              
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label9"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate6"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label10"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate6"  ></asp:TextBox>
             </div>
         </div>
                            <br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement6" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop5" runat="server" GroupingText="Previous Employment" BorderStyle="Groove" Font-Bold="true">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle7" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany7" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label11"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate7"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label12"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate7"  ></asp:TextBox>
             </div>
         </div>
                            <br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement7" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                         
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop6" runat="server" GroupingText="Previous Employment" BorderStyle="Groove" Font-Bold="true">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle8" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                
                            </div>
                
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany8" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                  
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label13"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate8"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label14"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate8"  ></asp:TextBox>
             </div>
         </div>
                            <br />

                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement8" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop7" runat="server" GroupingText="Previous Employment" BorderStyle="Groove" Font-Bold="true">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle9" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany9" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label15"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate9"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label16"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate9"  ></asp:TextBox>
             </div>
         </div>
                            <br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement9" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="PreviousJop8" runat="server" GroupingText="Previous Employment" BorderStyle="Groove" Font-Bold="true">
                  <div class="row">
             <div class="col-md-2">
Title *
             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtTitle10" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
             <div class="col-md-2">
Company / Employer *

             </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCompany10" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-2" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label17"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="95%" AutoPostBack="false" ID="txtStartDate10"></asp:TextBox>
             </div>
              <div class="col-md-2">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label18"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="95%" AutoPostBack="false" ID="txtEndDate10"></asp:TextBox>
             </div>
         </div>
                            <br />
                            <div class="row">
             <div class="col-md-2">
Achievement

             </div>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtAchievement10" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                               
                            </div>
                </div>
            <br />
            </asp:Panel>
                    <%--    <asp:Panel ID="Panel12" runat="server" GroupingText="Previous Employment">
                  <div class="row">
             <div class="col-md-3">
Title
             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox43" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtPreTitle1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                   <div class="row">
             <div class="col-md-3">
Company / Employer

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox44" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtPreCompany1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-3" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label19"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="100%" AutoPostBack="false" ID="TextBox45"></asp:TextBox>
             </div>
              <div class="col-md-1">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label20"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="100%" AutoPostBack="false" ID="TextBox46"  ></asp:TextBox>
             </div>
         </div>

                            <div class="row">
             <div class="col-md-3">
Achievement

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox47" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtPreAchievment1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="Panel13" runat="server" GroupingText="Previous Employment">
                  <div class="row">
             <div class="col-md-3">
Title
             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox48" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtPreTitle1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                   <div class="row">
             <div class="col-md-3">
Company / Employer

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox49" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="txtPreCompany1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-3" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label21"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="100%" AutoPostBack="false" ID="TextBox50"></asp:TextBox>
             </div>
              <div class="col-md-1">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label22"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="100%" AutoPostBack="false" ID="TextBox51"  ></asp:TextBox>
             </div>
         </div>

                            <div class="row">
             <div class="col-md-3">
Achievement

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox52" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtPreAchievment1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="Panel14" runat="server" GroupingText="Previous Employment">
                  <div class="row">
             <div class="col-md-3">
Title
             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox53" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="txtPreTitle1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                   <div class="row">
             <div class="col-md-3">
Company / Employer

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox54" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtPreCompany1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-3" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label23"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="100%" AutoPostBack="false" ID="TextBox55"></asp:TextBox>
             </div>
              <div class="col-md-1">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label24"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="100%" AutoPostBack="false" ID="TextBox56"  ></asp:TextBox>
             </div>
         </div>

                            <div class="row">
             <div class="col-md-3">
Achievement

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox57" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtPreAchievment1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            </asp:Panel>
                        <asp:Panel ID="Panel15" runat="server" GroupingText="Previous Employment">
                  <div class="row">
             <div class="col-md-3">
Title
             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox58" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="txtPreTitle1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                   <div class="row">
             <div class="col-md-3">
Company / Employer

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox59" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="txtPreCompany1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
                
         <div class="row"> 
              <div class="col-md-3" >
                  <asp:Label  Text="Start" runat="server" Width="100%"  AutoPostBack="false" ID="Label25"></asp:Label>
             </div>
           <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server" Width="100%" AutoPostBack="false" ID="TextBox60"></asp:TextBox>
             </div>
              <div class="col-md-1">
                  <asp:Label  Text="End" runat="server" Width="100%"  AutoPostBack="false" ID="Label26"></asp:Label>
             </div>
            <div class="col-md-4">
                   <asp:TextBox TextMode="Date" runat="server"   Width="100%" AutoPostBack="false" ID="TextBox61"  ></asp:TextBox>
             </div>
         </div>

                            <div class="row">
             <div class="col-md-3">
Achievement

             </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextBox62" Enabled="true" CssClass="form-control" runat="server"  Text=""/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="txtPreAchievment1" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                </div>
            <br />
            </asp:Panel>--%>

             <br />
            <div class="row">
                   <div class="col-md-4">
            <asp:Button ID="btnPrevious" runat="server" Width="100%" Text="Previous PAge" OnClick="btnPrevious_Click" autoPostback="true"   />
       </div>
                         <div class="col-md-4">
            <asp:Button ID="btnAddJop1" runat="server" Width="100%" Text="Add Previous Jop" OnClick="btnAddJop1_Click" autoPostback="true"  class="btn btn-primary" />
       </div>
                             <div class="col-md-4">
            <asp:Button ID="btnNextToThird" runat="server" Width="100%" Text="Next" OnClick="btnNextToThird_Click" autoPostback="true"  class="btn btn-primary" />
       </div>
                </div>
        </asp:Panel>
    </form>
</body>
</html>
