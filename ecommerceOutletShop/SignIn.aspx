<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="ecommerceOutletShop.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Custom.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <div class="navbar navbar-default navbar-fixed-top" role="navigation">
           <div class="container">
               <div class="navbar-header">
                   <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                       <span class="sr-only">Toggle Navigation</span>
                       <span class="icon-bar"></span>
                       <span class="icon-bar"></span>
                       <span class="icon-bar"></span>
                   </button>
                   <a class="navbar-brand" href="Default.aspx"><span><img src="Img/shop.png" alt="MyEShopping" height="30" /></span>Outlet Shopping</a>
               </div>
               
               <div class="navbar-collapse collapse">
                   <ul class="nav navbar-nav navbar-right">
                       <li><a href="Default.aspx">Home</a></li>
                       <li><a href="#">About</a></li>
                       <li><a href="#">Contact Us</a></li>
                       <li class="dropdown">
                           <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                           <ul class="dropdown-menu">
                                <li class="dropdown-header"><a href="#">Men</a></li>
                                 <li role="separator" class="divider"></li>
                                 <li><a href="#">Shirts</a></li>
                                 <li><a href="#">Pants</a></li>

                                <li class="dropdown-header"><a href="#">Women</a></li>
                                 <li role="separator" class="divider"></li>
                                  <li><a href="#">Shirts</a></li>
                           </ul>
                       </li>
                       <li><a href="SignIn.aspx">SignIn</a></li>
                   </ul>
               </div>
           </div>
       </div>
        <div class="center-page">
            <label class="col-xs-11">UserName:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtUname" runat="server" Class="form-control" placeholder="Enter your Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" CssClass="text-danger" ErrorMessage="Enter User Name" ForeColor="Red" ControlToValidate="txtUname"></asp:RequiredFieldValidator>
            </div>
            <label class="col-xs-11">Password:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtpass" runat="server" Class="form-control" TextMode="Password" placeholder="Enter your Password"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" CssClass="text-danger" ErrorMessage="Enter Password" ForeColor="Red" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
            </div>
             <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <div style="margin-right:10px;">
                <asp:CheckBox ID="chkrem" runat="server" /> 
                    <asp:Label ID="lblrem" cssClass="control-label" runat="server" Text="Remember me"></asp:Label> 
             </div>              
                                  
            </div>
            <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <asp:Button ID="btnsignin" class="btn btn-success" runat="server" text="Sign In&raquo;" OnClick="btnsignin_Click" />
                <asp:LinkButton ID="Linkforgetpass" runat="server" OnClick="Linkforgetpass_Click" CausesValidation="false">Forgot Password??  
                                      </asp:LinkButton>
                 <label class="col-xs-11"></label>
                 <a href="SignUp.aspx" class="btn btn-primary">Dont have account?Sign Up</a>
            </div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger"/>
                </div>
            </div>
         </div>   
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy;2021 Outlet Shopping.pk &middot; <a href="Default.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
            </div>
        </footer>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <div class="modal fade" id="Modalforgetpass" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="forgetModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                         <div class="form-group">
                         <asp:label runat="server">Email</asp:label>
                           <asp:TextBox ID="txtemailforget" class="form-control" runat="server"></asp:TextBox>                       
                           <asp:Label ID="lblerroremail" ForeColor="Red" runat="server" BorderStyle="None"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnemailsend" type="submit" runat="server" Text="Reset Password" CausesValidation="false" class="btn btn-primary" OnClick="btnemailsend_Click" />
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
                  </ContentTemplate>       
        </asp:UpdatePanel>
               </div>
          </div>
    </div>
    </form>
</body>
</html>
