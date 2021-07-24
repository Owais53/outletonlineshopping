<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ecommerceOutletShop.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Custom.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script src="js/sweetalert2.all.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <script>
            function alertsignup() {
                Swal.fire(
                    'Success!',
                    'Successfull!',
                     'success'
                     )
               
            }
           
      </script>
    <script>
            function alertcheckuser() {
                Swal.fire(
                    'Error!',
                    'Please Enter other UserName!',
                     'error'
                     )
               
            }
           
      </script>
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
                       <li><a href="SignUp.aspx">SignIn</a></li>
                   </ul>
               </div>
           </div>
       </div>
        <div class="center-page">
            <label class="col-xs-11">UserName:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtUname" runat="server" Class="form-control" placeholder="Enter your Name"></asp:TextBox>
            </div>
            <label class="col-xs-11">Password:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtpass" runat="server" Class="form-control" TextMode="Password" placeholder="Enter your Password"></asp:TextBox>
            </div>
            <label class="col-xs-11">Confirm Password:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtcpass" runat="server" Class="form-control" TextMode="Password" placeholder="Enter Confirm Password"></asp:TextBox>
            </div>
            <label class="col-xs-11">Your Full Name:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtfname" runat="server" Class="form-control" placeholder="Enter your Full Name"></asp:TextBox>
            </div>
            <label class="col-xs-11">Email:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtemail" runat="server" Class="form-control" placeholder="Enter your Email"></asp:TextBox>
            </div>
            <label class="col-xs-11">Contact No:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtcontact" runat="server" Class="form-control" placeholder="Enter your Contact No"></asp:TextBox>
            </div>
             <label class="col-xs-11">Address:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtaddress" runat="server" TextMode="MultiLine" Class="form-control" placeholder="Enter your Address"></asp:TextBox>
            </div>
             <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <div style="margin-right:10px;">
                <asp:CheckBox ID="chkadm" runat="server" OnCheckedChanged="chkadm_CheckedChanged" AutoPostBack="true" /> 
                    <asp:Label ID="lbladm" cssClass="control-label" runat="server" Text="Make as Admin"></asp:Label> 
                    </div> 
                  <asp:label class="col-xs-11" runat="server" ID="lblcode" Visible="False">Security Code:</asp:label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtcode" runat="server" Class="form-control" placeholder="Enter your Code" Visible="False"></asp:TextBox>
            </div>
            <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <asp:Button ID="btnsignup" class="btn btn-success" runat="server" OnClick="btnsignup_Click" text="Sign Up" />
                 <label class="col-xs-11"></label>
                 <a href="SignIn.aspx" class="btn btn-primary">Already have account?Sign In</a>
            </div>
            
         </div>  
       
        
    </div>
    </form>
    
</body>
</html>
