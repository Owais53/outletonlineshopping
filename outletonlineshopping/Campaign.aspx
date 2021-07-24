<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Campaign.aspx.cs" Inherits="outletonlineshopping.Campaign" %>
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
                                      Campaign
                                </div>
                                <div class="panel-body" style="position:relative;">
                                   
                                    <div class="row">
                                        <div class="col-lg-9">
                                            
                                                <div class="form-group">
                                                    <asp:label runat="server">Campaign Name</asp:label>
                                                    <asp:TextBox ID="txtcampname" CssClass="form-control" placeholder="Enter Campaign Name" runat="server"></asp:TextBox>
                                                    
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Start Date</asp:label>
                                                    <asp:TextBox ID="txtstartdate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                                     
                                                </div>
                                            
                                                 <div class="form-group">
                                                    <asp:label runat="server">End Date</asp:label>
                                                    <asp:TextBox ID="txtEnddate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>   
                                                  </div>
                                                 <div class="form-group">
                                                    <asp:label runat="server">Expected Revenue</asp:label>
                                                      <asp:TextBox ID="txtexpRev" CssClass="form-control" placeholder="Enter Expected Revenue" runat="server" TextMode="Number"> </asp:TextBox>
                                                  </div>
                                                   <div class="form-group">
                                                       <asp:Button ID="btnAddCamp" runat="server" Text="Save Campaign" CssClass="btn btn-danger" OnClick="btnAddCamp_Click" />
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
                    'Campaign Updated Successfully',
                     'success'
                     )
                
            }
      </script>
    <script>
            function alertcamexists() {
                Swal.fire(
                    'Error!',
                    'One Campaign is already Running.You can Create new Campaign when its Ended',
                     'Error'
                     )
                
            }
      </script>
</asp:Content>
