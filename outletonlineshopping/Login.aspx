<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="outletonlineshopping.Login" %>

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
            function alertuserinvalid() {
                Swal.fire(
                    'Error!',
                    'Email or Password is inValid!',
                     'error'
                     )               
            }
      </script>
    <script>
            function alertemailinvalid() {
                Swal.fire(
                    'Error!',
                    'Email is inValid!',
                     'error'
                     )               
            }
      </script>
     <script>
            function alertemailsent() {
                Swal.fire(
                    'Success!',
                    'Password reset link is sent to your Email!',
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
                            <h3 class="panel-title">Please Sign In</h3>
                        </div>
                        <div class="panel-body">
                           
                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox Id="txtemail" CssClass="form-control" placeholder="E-mail" runat="server" />
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" CssClass="text-danger" ErrorMessage="Enter Email" ForeColor="Red" ControlToValidate="txtemail"></asp:RequiredFieldValidator>
                                      </div>
                                    <div class="form-group">
                                        <asp:TextBox Id="txtpass" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server" />
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" CssClass="text-danger" ErrorMessage="Enter Password" ForeColor="Red" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox runat="server" ID="chkrem" />Remember Me                                          
                                        </label>
                                    </div>
                                    <!-- Change this to a button or input when using this as a form -->
                                    <asp:Button runat="server" ID="btnlogin" CssClass="btn btn-lg btn-success btn-block" Text="Login" OnClick="btnlogin_Click"></asp:Button>
                                     <asp:LinkButton ID="Linkforgetpass" runat="server" OnClick="Linkforgetpass_Click" CausesValidation="false">Forgot Password??  
                                      </asp:LinkButton>
                                </fieldset>
                            
                        </div>
                    </div>
                </div>
            </div>
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
