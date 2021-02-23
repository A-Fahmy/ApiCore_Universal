<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTS.PL.Forms.Registeration.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rise</title>
    <link href="/client/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="/client/dist/css/main.css" rel="stylesheet">
    <link href="/client/dist/css/Login.css" rel="stylesheet" />
    <script src="jquery-3.3.1.min.js"></script>
</head>
<body>

    <div id="header"  class="header"> 
    </div>

    <div id="body" class="body">
        <div id="LoginCard" class="LoginCard">
    <form class="LoginFormClass" id="LoginForm" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div >
            <asp:TextBox runat="server" ID="txtUsername" IsRequired="true" placeholder="Username" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validator_username" runat="server" ControlToValidate="txtUsername" ErrorMessage="*" ForeColor="Red" ></asp:RequiredFieldValidator>                         
            <br />

            
            <asp:TextBox runat="server" ID="txtPassword" IsRequired="true" TextMode="Password" placeholder="Password" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="Validator_password" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"  ></asp:RequiredFieldValidator> 
            <br />
           
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" class="btn-login" />
            <br />
            <asp:Label ID="lblInvalidUser" runat="server" class="lblInvalidUser" Text="Invalid Username or Password" Visible="False"  />

        </div>

        <div class="ajax-loading" id="loading" >


                     <span class="class1"></span>
                     <span class="class2"></span>
                     <span class="class3"></span>
                     <span class="class4"></span>
                     <span class="class5"></span>

                  </div>
    </form>
             
  </div>
   </div>


    <div id="footer"  class="footer">
        <asp:Label runat="server" ID="lblCopyRight" Text="&copy;2018 Rise" CssClass="lblCopyRight" ></asp:Label>
    </div>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function (args, sender) {
            $('.ajax-loading').show();
            //document.getElementById("loading").style.display = "block"
        });
        prm.add_endRequest(function (args, sender) {
            $('.ajax-loading').hide();
        });
     </script>
</body>
</html>
