<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="GR.aspx.cs" Inherits="outletonlineshopping.GR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .buttonPOinGR{
            position: absolute;
           top: 0px;
          right: 0px;
        }
    </style>
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
                                      View Purchase Order
                                </div>
                                <div class="panel-body" style="position:relative;">
                                     <div class="buttonPOinGR">
                                                <button id="btnsaletrack" type="button" class="btn btn-outline-primary" runat="server" >
                                                    <i class="fa fa-money fa-fw" aria-hidden="true">
                                                        <span>1</span>
                                                        <br />
                                                        <span>View Purchase Order</span>
                                                    </i>
                                                </button>
                                            </div>
                                    
                                    <div class="row">
                                        <div class="col-lg-9" >
                                                <asp:HiddenField ID="hdsoid" runat="server" />
                                                <div class="form-group">
                                                    <asp:label runat="server">GR No</asp:label>
                                                    <asp:TextBox ID="txtGRNo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                    
                                                </div>
                                              <div class="form-group">
                                                    <asp:label runat="server">Status</asp:label>
                                                    <asp:TextBox ID="txtStatus" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                    
                                                </div>

                                                 
                                                                                            
                              <div class="form-group">
                              <asp:GridView ID="dgvGRDet" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="PODetID" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Product Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("ProductName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Size">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("SizeName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Quantity") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Price">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Price") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                                                                       
                                               </Columns>
                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                     </asp:GridView> 
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
</asp:Content>
