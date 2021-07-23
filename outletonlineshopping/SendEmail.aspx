<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="outletonlineshopping.SendEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header"></h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                      Send Email
                                </div>
                                <div class="panel-body" style="position:relative;">
                                   
                                    <div class="row">
                                        <div class="col-lg-9">
                                            
                                                <div class="form-group">
                                                    <asp:label runat="server">To</asp:label>
                                                    <asp:TextBox ID="txtto" CssClass="form-control" placeholder="Enter Campaign Name" runat="server"></asp:TextBox>
                                                    
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Subject</asp:label>
                                                    <asp:TextBox ID="txtsub" CssClass="form-control"  runat="server"></asp:TextBox>
                                                     
                                                </div>
                                            
                                                 <div class="form-group">
                                                    <asp:label runat="server">Message</asp:label>
                                                    <asp:TextBox ID="txtmessage" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>   
                                                  </div>
                                                <div class="form-group">
                                                       <asp:Button ID="btnsendemail" runat="server" Text="Send Email" CssClass="btn btn-success" OnClick="btnsendemail_Click" />
                                                  </div>  
                                        </div>
                                        
                                        
                                        
                                       
                                    </div>
                                    <!-- /.row (nested) -->
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                </div>
          
                <!-- /.container-fluid -->
                   
                    </div>
                  
            
            <!-- /#page-wrapper -->
<link href="css/gridstyle.css" rel="stylesheet" />
       <script>
            function alertcam() {
                Swal.fire(
                    'Success!',
                    'Campaign Created Successfully',
                     'success'
                     )
                
            }
      </script>
     <script>
            function alertcamedit() {
                Swal.fire(
                    'Success!',
                    'Email Sent',
                     'success'
                     )
                
            }
      </script>
</asp:Content>
