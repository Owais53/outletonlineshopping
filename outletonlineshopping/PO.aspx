<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PO.aspx.cs" Inherits="outletonlineshopping.PO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .buttonSo{
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
                                     <div class="buttonSo">
                                                <button id="btnsaletrack" type="button" class="btn btn-light" runat="server" onserverclick="btnsaletrack_ServerClick">
                                                    <i class="fa fa-shopping-cart fa-fw" aria-hidden="true" style="padding-right:30px;">
                                                        <span>1</span>
                                                        <br />                                                       
                                                    </i>
                                                    <br />
                                                    Sales Order
                                                </button>
                                                <button id="btnGr"  type="button" width="10%" class="btn btn-light" runat="server" onserverclick="btnGr_ServerClick">
                                                    <i class="fa fa-shopping-cart fa-fw" aria-hidden="true" style="padding-right:30px;">
                                                        <span></span>
                                                        <br />
                                                       
                                                    </i>
                                                    <br />
                                                     Create Good Receipt
                                                </button>
                                          <button id="btnvb"  type="button" width="10%" class="btn btn-light" runat="server" onserverclick="btnvb_ServerClick">
                                                    <i class="fa fa-shopping-cart fa-fw" aria-hidden="true" style="padding-right:30px;">
                                                        <span></span>
                                                        <br />
                                                       
                                                    </i>
                                                    <br />
                                                     Create Vendor Bill
                                                </button>
                                            </div>
                                      <div>
                                               
                                            </div>
                                    <div class="row" style="margin-top:50px;">
                                        <div class="col-lg-9" >
                                                <asp:HiddenField ID="hdsoid" runat="server" />
                                                <div class="form-group">
                                                    <asp:label runat="server">PONo</asp:label>
                                                    <asp:TextBox ID="txtPONo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    
                                                </div>
                                              <div class="form-group">
                                                    <asp:label runat="server">SO Reference</asp:label>
                                                    <asp:TextBox ID="txtSoref" CssClass="form-control" runat="server"></asp:TextBox>
                                                    
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Order Date</asp:label>
                                                    <asp:TextBox ID="txtorderdate" CssClass="form-control"  runat="server"></asp:TextBox>
                                                     
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Vendor</asp:label>
                                                    <asp:TextBox ID="txtVendor" CssClass="form-control" runat="server"></asp:TextBox>
                                                     
                                                </div>
                                            
                                                 <div class="form-group">
                                                    <asp:label runat="server">Status</asp:label>
                                                    <asp:TextBox ID="txtStatus" CssClass="form-control" placeholder="Enter Product Quantity" runat="server"></asp:TextBox>   
                                                  </div>
                                                  <div class="form-group">
                                                    <asp:Button ID="btnSavePo" CssClass="btn btn-primary" runat="server" Text="Save"></asp:Button>   
                                                  </div>
                                                                                            
                              <div class="form-group">
                              <asp:GridView ID="dgvPODet" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="PODetID" Width="100%" CssClass="table table-striped table-bordered table-hover">
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
