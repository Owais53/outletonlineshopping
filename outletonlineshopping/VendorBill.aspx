<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="VendorBill.aspx.cs" Inherits="outletonlineshopping.VendorBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .buttonPoinVB{
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
                                      View Vendor Bill
                                </div>
                                <div class="panel-body" style="position:relative;">
                                     <div class="buttonPoinVB">
                                                <button id="btnpovbtrack" type="button" class="btn btn-light" runat="server" onserverclick="btnpovbtrack_ServerClick">
                                                    <i class="fa fa-money fa-fw" aria-hidden="true">
                                                        <span>1</span>
                                                        <br />                     
                                                    </i>
                                                    <br/>
                                                    View Purchase Order
                                                </button>
                                            </div>
                                    
                                    <div class="row">
                                        <div class="col-lg-9" >
                                                <asp:HiddenField ID="hdsoid" runat="server" />
                                                <div class="form-group">
                                                    <asp:label runat="server">Po Reference</asp:label>
                                                    <asp:TextBox ID="txtPono" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                    
                                                </div>
                                             
                                                <div class="form-group">
                                                    <asp:label runat="server">Total Amount</asp:label>
                                                    <asp:TextBox ID="txttotalAmt" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                    
                                                </div>
                                            
                                                                                            
                              <div class="form-group">
                              <asp:GridView ID="dgvVBDet" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"  Width="100%" CssClass="table table-striped table-bordered table-hover">
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
