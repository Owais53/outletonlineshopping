<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ecommerceOutletShop.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="center-page">
            <label class="col-xs-11">Current Password:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtc_pass" runat="server" Class="form-control" TextMode="Password" placeholder="Enter your Current Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
                                              ControlToValidate="txtc_pass"   
                                          ErrorMessage="Please enter Current password" ForeColor="Red"></asp:RequiredFieldValidator>  
            </div>
            <label class="col-xs-11">New Password:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtnpass" runat="server" Class="form-control" TextMode="Password" placeholder="Enter your New Password"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   
                                      ControlToValidate="txtnpass" ErrorMessage="Please enter New password" ForeColor="Red"></asp:RequiredFieldValidator>  
              </div>
            <label class="col-xs-11">Confirm Password:</label>
            <div class="col-xs-11">
                 <asp:TextBox Id="txtconfirmpass" runat="server" Class="form-control" TextMode="Password" placeholder="Enter Confirm Password"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"   
                                    ControlToValidate="txtconfirmpass"   
                                     ErrorMessage="Please enter Confirm  password" ForeColor="Red"></asp:RequiredFieldValidator>  
  
                                       <asp:CompareValidator ID="CompareValidator1" runat="server"   
                                             ControlToCompare="txtnpass" ControlToValidate="txtconfirmpass"   
                                   ErrorMessage="Password Mismatch" ForeColor="Red"></asp:CompareValidator>
            </div>
          
            <label class="col-xs-11"></label>
            <div class="col-xs-11">
                <asp:Button ID="btnchangepass" class="btn btn-success" runat="server" text="Change Password" OnClick="btnchangepass_Click" />
                 <label class="col-xs-11"></label>
            </div>
            
         </div>  
        <footer class="footer-pos">
            <div class="container">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy;2021 Outlet Shopping.pk &middot; <a href="Default.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
            </div>
        </footer>
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
