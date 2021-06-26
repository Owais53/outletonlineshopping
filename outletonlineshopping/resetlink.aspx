<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetlink.aspx.cs" Inherits="outletonlineshopping.resetlink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Outlet Login</title>
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <meta name="description" content=""/>
        <meta name="author" content=""/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->   
    <link href="css/metisMenu.min.css" rel="stylesheet"/>
    
    <!-- Custom CSS -->
    <link href="css/startmin.css" rel="stylesheet"/>
    <!-- Morris Charts CSS -->
    <link href="css/morris.css" rel="stylesheet"/>
    <!-- Custom Fonts -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
     <script src="js/sweetalert2.all.js"></script>
      <script>
            function alertreset() {
                Swal.fire(
                    'Successfull!',
                    'Password Changed!',
                     'success'
                     )
               
            }
           
      </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Reset Pass</h3>
                        </div>
                        <div class="panel-body">
                           
                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox Id="txtpass" CssClass="form-control" TextMode="Password" placeholder="New Password" runat="server" />
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" CssClass="text-danger" ErrorMessage="Enter New Password" ForeColor="Red" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                                      </div>
                                    <div class="form-group">
                                        <asp:TextBox Id="txtcpass" CssClass="form-control" placeholder="Confirm Password" TextMode="Password" runat="server" />
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" CssClass="text-danger" ErrorMessage="Enter Confirm Password" ForeColor="Red" ControlToValidate="txtcpass"></asp:RequiredFieldValidator>
                                         <asp:CompareValidator ID="CompareValidator1" runat="server"   
                                             ControlToCompare="txtpass" ControlToValidate="txtcpass"   
                                           ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
                                    </div>
                                    
                                    <!-- Change this to a button or input when using this as a form -->
                                    <asp:Button runat="server" ID="btnreset" CssClass="btn btn-lg btn-success btn-block" Text="Reset" OnClick="btnreset_Click"></asp:Button>
                                </fieldset>
                            
                        </div>
                    </div>
                </div>
            </div>
    </div>
   </div>
         <script src="js/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<!-- Bootstrap Core JavaScript -->
  
<!-- Metis Menu Plugin JavaScript -->
<script src="js/metisMenu.min.js"></script>
  <script src="js/jquery-ui.min.js"></script>
<!-- Custom Theme JavaScript -->
<script src="js/startmin.js"></script>
    </form>
</body>
</html>
