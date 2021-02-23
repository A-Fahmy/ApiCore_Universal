<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialExpertisePackage.aspx.cs" Inherits="BTS.PL.Forms.Settings.SpecialExpertisePackage" %>


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
  
    <script type="text/javascript">
        $(function () {
            $('#ChkRelarion').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtRelation').prop("disabled", false);
                }
                else {
                    $('#txtRelation').prop("disabled", true);

                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#ChkTypeEX').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtTypeEX').prop("disabled", false);
                }
                else {
                    $('#txtTypeEX').prop("disabled", true);

                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#ChkDurationEX').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtDurationEX').prop("disabled", false);
                }
                else {
                    $('#txtDurationEX').prop("disabled", true);

                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#ChkLevelEX').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtLevelEX').prop("disabled", false);
                }
                else {
                    $('#txtLevelEX').prop("disabled", true);

                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#ChkPublicPerson').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtPublicPerson').prop("disabled", false);
                }
                else {
                    $('#txtPublicPerson').prop("disabled", true);

                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#ChkOnline').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtOnline').prop("disabled", false);
                }
                else {
                    $('#txtOnline').prop("disabled", true);

                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#ChkTitle').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtTilte').prop("disabled", false);
                }
                else {
                    $('#txtTilte').prop("disabled", true);

                }
            });
        });
    </script>
     <script type="text/javascript">
        $(function () {
            $('#ChkRecognition').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtRecognition').prop("disabled", false);
                }
                else {
                    $('#txtRecognition').prop("disabled", true);

                }
            });
        });
    </script>
      <script type="text/javascript">
        $(function () {
            $('#ChkOthers').change(function () {
                var re = this.checked;
                if (re) {
                    $('#txtOthers').prop("disabled", false);
                }
                else {
                    $('#txtOthers').prop("disabled", true);

                }
            });
        });
    </script>
    <style type="text/css">
    .hiddencol {
        display: none;
    }
    </style>
</head>

<body>
    <form id="form1" runat="server">

                    <h1 style="position:center">Featured Expertise </h1>
<br />
        <asp:Panel ID="PanGrid" runat="server" GroupingText="Your Featuered Expertise">
            <div class="row">
                  <div class="col-md-4">
                <asp:Button ID="btnAdd" runat="server" Width="100%"  Text=" Add New Expertise" OnClick="btnAdd_Click"  ForeColor="White"  class="btn btn-primary" BackColor="#d36541" />

             </div>
                <div class="col-md-4">
             <asp:Button ID="btnCancel2" runat="server" Width="100%" Text="Cancel" Onclick="btnCancel_Click"  CausesValidation="false" class="btn btn-default"/>
                </div>  
                
                <div class="col-md-4">
                    <asp:Label ID="lblCount" runat="server" Width="100%" BorderStyle="Inset" BorderColor="#d36541"></asp:Label>
                </div>
            </div>
              <asp:GridView ID="Grid_Exp" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="false"
                                BorderColor="#CC9966" BorderStyle="None" Caption='<table border="1" width="100%" cellpadding="0" cellspacing="0" bgcolor="yellow"><tr><td style="text-align: center; vertical-align: middle;font-weight: bold;font-size: 18px;"> Expertises </td></tr></table>'
                                BorderWidth="1px" CellPadding="4" HeaderStyle-BackColor="LightGray"
                                EmptyDataText="No Data">
                                <Columns>
                                    <asp:BoundField DataField="ExpertiseRCLCode" ItemStyle-Width="70%" HeaderText="Expertise RCL Code" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="ExpertiseLevelCode2_SQLLite" ItemStyle-Width="70%" HeaderText="Expertise Code" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="RCLCode" ItemStyle-Width="70%" HeaderText="RCLCode" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="ExpertiseLevelName1_SQLLite" ItemStyle-Width="70%" HeaderText="Expertise Name" />
                                    <asp:BoundField DataField="ExpertiseLevelName2_EN_SQLLite" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ItemStyle-Width="40%" HeaderText="Expertise Name" />
                                    <asp:BoundField DataField="SpacialCost" ItemStyle-Width="30%" HeaderText="Cost" />

                                  
                                 <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" CausesValidation="false"
                                OnClick="btnEdit_Click" SelectedID='<%# Eval("ContactExpertiseCode") %>'  CommandName='<%# Eval("SpecialCode") %>'
                                ImageUrl="~/client/images/edititem.gif" />
                        </ItemTemplate>
                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                              
        </asp:Panel>
          <asp:ScriptManager ID="HEPCASCriptManager" runat="server"></asp:ScriptManager>
           <asp:UpdatePanel runat="server" ID="ddlUpdate">
                <ContentTemplate>
         <asp:Panel ID="PanRCL" runat="server"  GroupingText="Choose Your Featuered Expertise" Visible="true">
             <div class="row">
             <div class="col-md-3">
                   <asp:DropDownList ID="ddlExpertiseLevel1" Visible="true" AutoPostBack="true" Width="100%"  runat="server" DataTextField="Name" DataValueField="Code" OnSelectedIndexChanged="ddlExpertiseLevel1_SelectedIndexChanged">  </asp:DropDownList>
             </div>
                               <div class="col-md-3">
                   <asp:DropDownList ID="ddlExpertiseLevel2" Visible="true" AutoPostBack="true" Width="100%"  runat="server" DataTextField="Name" DataValueField="Code" OnSelectedIndexChanged="ddlExpertiseLevel2_SelectedIndexChanged">  </asp:DropDownList>
             </div>
                               <div class="col-md-3">
                   <asp:DropDownList ID="ddlExpertiseLevel3" Visible="true" AutoPostBack="true" Width="100%" runat="server" DataTextField="Name" DataValueField="Code" OnSelectedIndexChanged="ddlExpertiseLevel3_SelectedIndexChanged">  </asp:DropDownList>
             </div>
                               <div class="col-md-2">
                   <asp:DropDownList ID="ddlExpertiseLevel4" Visible="true" AutoPostBack="true"  Width="100%" runat="server" DataTextField="Name" DataValueField="Code" >  </asp:DropDownList>
             </div>
                 <div class="col-md-1">
                   <asp:DropDownList ID="ddlExpertiseLevel5" Visible="true" AutoPostBack="true"   runat="server" DataTextField="Name" DataValueField="Code" >  </asp:DropDownList>
             </div>
             </div>
             </asp:Panel>
                </ContentTemplate>
               </asp:UpdatePanel>
        <br />
             <div class="row" id="divCost" runat="server">
                 <%-- <div class="col-md-2">
                                <h4>Feeze</h4> 
                            </div>
                 <div class="col-md-4">
                   <asp:TextBox ID="txtCost" Enabled="true"  CssClass="form-control" runat="server" />

                 </div>--%>
             <div class="col-md-4">
                <asp:Button ID="btnNext" runat="server" Width="100%"  AutoPostBack="true" Text=" Next" OnClick="btnNext_Click"   class="btn btn-primary" />

             </div>
                 </div>
                 
        <asp:Panel ID="PanTemplate" runat="server" GroupingText="Reason For Request Featured" BorderStyle="Groove">
            <div class="row">
                  <div class="col-md-2">
                                <h4>Fees</h4> 
                            </div>
                 <div class="col-md-4">
                   <asp:TextBox ID="txtCost" Enabled="true"  CssClass="form-control" runat="server" />

                 </div>
            </div>    
            <div class="row">

             <div class="col-md-4">
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
            <div class="col-md-2">
                Key Relations
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkRelarion" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtRelation" Enabled="false" ForeColor="Black" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
         <br />
        <div class="row">
            <div class="col-md-2">
Type of Expertise
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkTypeEX" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtTypeEX" Enabled="false" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
          <br />
        <div class="row">
            <div class="col-md-2">
Duration of Expertise
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkDurationEX" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtDurationEX" Enabled="false" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
         <br />
        <div class="row">
            <div class="col-md-2">
Level of Expertise
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkLevelEX" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtLevelEX" Enabled="false" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
          <br />
        <div class="row">
            <div class="col-md-2">
Public Person
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkPublicPerson" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtPublicPerson" Enabled="false" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
          <br />
        <div class="row">
            <div class="col-md-2">
Found Online
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkOnline" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtOnline" Enabled="false" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
            <br />
        <div class="row">
            <div class="col-md-2">
Current / Previous Title
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkTitle" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtTilte" Enabled="false"  CssClass="form-control" runat="server" />
                               
            </div>
        </div>
         <br />
        <div class="row">
            <div class="col-md-2">
Special Recognition
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkRecognition" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtRecognition" Enabled="false" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
          <br />
        <div class="row">
            <div class="col-md-2">
Others
            </div>
            <div class="col-md-2">
                <asp:CheckBox ID="ChkOthers" Checked="false" runat="server"/>
            </div>
            <div class="col-md-8">
                 <asp:TextBox ID="txtOthers" Enabled="false" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
              <br />
        <div class="row">
            <div class="col-md-4">
Few lines to explain your featured expertise
            </div>
           
            <div class="col-md-8">
                 <asp:TextBox ID="txtMore" Enabled="true"  TextMode="MultiLine" Rows="5" CssClass="form-control" runat="server" />
                               
            </div>
        </div>
        <br />
            <div class="row" style="margin-left:50px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Size="X-Large" ></asp:Label>
            </div>
            <br />
        <div class="row">
              <div class="col-md-3">
             <asp:Button ID="btnCancel" runat="server" Width="100%" Text="Cancel" Onclick="btnCancel_Click"  CausesValidation="false" class="btn btn-default"/>
                </div>            
                
                <div class="col-md-3">
            <asp:Button ID="btnSave" runat="server" Width="100%"  Text=" Save" OnClick="btnSave_Click"   class="btn btn-primary" />
       </div>
                            
                <div class="col-md-3">
            <asp:Button ID="btnSubmit" runat="server"  Width="100%"  Text="Submit" OnClick="btnSubmit_Click"   class="btn btn-primary" />
       </div>
      
      
        </div>
            <div runat="server" id="divSubmited" class="row">
                    <div class="col-md-6">
            <asp:Button ID="btncheck" runat="server"  Width="100%"  Text="Check" OnClick="btncheck_Click"   class="btn btn-primary" />
       </div>
                <div class="col-md-6">
            <asp:Button ID="btndisabled" runat="server"  Width="100%"  Text="Disaple this Featured Expertise" OnClick="btndisabled_Click"   class="btn btn-primary" />
       </div>

            </div>
            <div class="row" id="divChecker" runat="server">
                  <div class="col-md-6">
            <asp:Button ID="btnAccept" runat="server" Width="100%"  Text=" Accept" OnClick="btnAccept_Click"   class="btn btn-primary" />
       </div>
                  <div class="col-md-6">
            <asp:Button ID="btnReject" runat="server" Width="100%"  Text=" Reject" OnClick="btnReject_Click"   class="btn btn-primary" />
       </div>
            </div>
            </asp:Panel>
    </form>
</body>
</html>

