<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmPasswordURL.aspx.cs" Inherits="BTS.PL.Forms.Settings.ConfirmPasswordURL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../client/vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style>
        .divElement{
    position: absolute;
    top: 25%;
    left: 25%;
    margin-top: -50px;
    margin-left: -50px;
    width: 50%;
    height: 50%;
    background-color: aliceblue;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border:groove" class="divElement" >
            <h4>Please Enter your Password</h4>
                <br />
            <div class="container" style="margin-left:5px;margin-top:15px">
                
            <div class="row">
            <div class="col-md-2" style="margin-left:auto">
                                User Name
                          </div>
                            <div class="col-md-5">
                                
                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Enabled="false" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
                            </div>
                           <br />
                            <br />
             <div class="row">
            <div class="col-md-2" style="margin-left:auto">
                                Password
                          </div>
                            <div class="col-md-5">
                                 

                                <asp:TextBox ID="txtPwd" CssClass="form-control"  runat="server" />
                                <asp:RequiredFieldValidator ID="rfvpwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="EditForm"></asp:RequiredFieldValidator>
                            </div>
               </div>
                              
                           <br />
                            <br />
                              <div class="row">
            <div class="col-md-2" style="margin-left:auto">
                              Confirm  Password
                          </div>
                            <div class="col-md-5" style="position:relative">
                                   
                                <asp:TextBox ID="txtConfirmPwd" CssClass="form-control"  runat="server" />
                                
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                     ControlToValidate="txtConfirmPwd"
                                     CssClass="ValidationError"
                                     ControlToCompare="txtPwd"
                                     ErrorMessage="No Match" 
                                     ToolTip="Password must be the same" />
                            </div>
                                   </div>
                             <br />
        
                            
                        <asp:Button ID="btnConfirmPwd" runat="server" Text="Confirmed " class="btn btn-primary" OnClick="btnConfirmPwd_Click" />

        </div>
        </div>
    </form>
</body>
</html>
