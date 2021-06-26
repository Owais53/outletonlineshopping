<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="outletonlineshopping.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Product</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                         <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                  
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <!-- Nav tabs -->
                                    <ul class="nav nav-pills">
                                        <li class="active"><a href="#security-pills" data-toggle="tab">Security</a>
                                        </li>
                                        <li><a href="#pass-pills" data-toggle="tab">Change Password</a>
                                        </li>
                                        <li><a href="#messages-pills" data-toggle="tab">Messages</a>
                                        </li>
                                        <li><a href="#settings-pills" data-toggle="tab">Settings</a>
                                        </li>
                                    </ul>
                                    
                                    <!-- Tab panes -->
                                    <div class="tab-content">
                                        <div class="tab-pane fade in active" id="security-pills">
                                            <div class="form-group">
                                               <fieldset>
                                                   <label class="col-xs-11"></label>
                                              <label  class="col-xs-11">Security Code</label> 
                                                   <div  class="col-xs-4">
                                                        <asp:Textbox Id="txtscode" CssClass="form-control" placeholder="Security Code" runat="server"></asp:Textbox>
                                                       <label class="col-xs-11"></label>
                                                        <asp:Button runat="server" id="btngeneratecode" CssClass="btn btn-primary" Text="Generate Code for User SignUp" OnClick="btngeneratecode_Click"/>
                                                   </div>                                               
                                              
                                             </fieldset>
                                           </div>
                                             
                                        </div>
                                        <div class="tab-pane fade" id="pass-pills">
                                             <div class="form-group">
                                               <fieldset>
                                                   <label class="col-xs-11"></label>
                                                   <div  class="col-xs-4">
                                                       <asp:Label ID="Label1" runat="server" Text="Current password" Width="120px"   
                                                       Font-Bold="True" ForeColor="#996633"></asp:Label>  
                                                     <asp:TextBox ID="txt_cpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>  
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
                                              ControlToValidate="txt_cpassword"   
                                          ErrorMessage="Please enter Current password" ForeColor="Red"></asp:RequiredFieldValidator>  
                                                <br />  
                                           <asp:Label ID="Label2" runat="server" Text="New password" Width="120px"   
                                             Font-Bold="True" ForeColor="#996633"></asp:Label>  
                                            <asp:TextBox ID="txt_npassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>  
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   
                                      ControlToValidate="txt_npassword" ErrorMessage="Please enter New password" ForeColor="Red"></asp:RequiredFieldValidator>  
                                              <br />  
          
                                    <asp:Label ID="Label3" runat="server" Text="Confirm password" Width="120px"   
                                    Font-Bold="True" ForeColor="#996633"></asp:Label>  
  
                                        <asp:TextBox ID="txt_ccpassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>     
  
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"   
                                    ControlToValidate="txt_ccpassword"   
                                     ErrorMessage="Please enter Confirm  password" ForeColor="Red"></asp:RequiredFieldValidator>  
  
                                       <asp:CompareValidator ID="CompareValidator1" runat="server"   
                                             ControlToCompare="txt_npassword" ControlToValidate="txt_ccpassword"   
                                   ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
                                                       <label class="col-xs-11"></label>
                                                        <asp:Button runat="server" id="btnchangepass" CssClass="btn btn-primary" Text="Change Password" OnClick="btnchangepass_Click" />
                                                   </div>                                               
                                              
                                             </fieldset>
                                           </div>
                                        </div>
                                        <div class="tab-pane fade" id="messages-pills">
                                            <h4>Messages Tab</h4>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                        </div>
                                        <div class="tab-pane fade" id="settings-pills">
                                            <h4>Settings Tab</h4>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                    </div>
                  </div>
        </div>
     <script>
            function alertoldpassincorrect() {
                Swal.fire(
                    'Error!',
                    'Old Password is inValid!',
                     'error'
                     )               
            }
      </script>
     <script>
            function alertchangepass() {
                Swal.fire(
                    'Success!',
                    'Password is Changed!',
                     'success'
                     )               
            }
      </script>
</asp:Content>
