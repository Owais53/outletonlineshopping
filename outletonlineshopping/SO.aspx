<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="SO.aspx.cs" Inherits="outletonlineshopping.SO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .buttonPO{
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
                                      View Sale Order
                                </div>
                                <div class="panel-body" style="position:relative;">
                                    <div class="buttonPO">
                                                <button id="btnpotrack" type="button" class="btn btn-outline-primary" runat="server" onserverclick="btnpotrack_ServerClick">
                                                    <i class="fa fa-money-bill-alt fa-fw" aria-hidden="true">
                                                        <span id="spanCountpo" runat="server"></span>
                                                        <br />                                                       
                                                    </i>
                                                    <br />
                                                     Purchase Order
                                                </button>
                                            </div>
                                    <div class="row">
                                        <div class="col-lg-9">
                                            
                                                <div class="form-group">
                                                    <asp:label runat="server">SONo</asp:label>
                                                    <asp:TextBox ID="txtSONo" CssClass="form-control" runat="server"></asp:TextBox>
                                                    
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Order Date</asp:label>
                                                    <asp:TextBox ID="txtorderdate" CssClass="form-control" placeholder="Enter Cost" runat="server"></asp:TextBox>
                                                     
                                                </div>
                                            
                                                 <div class="form-group">
                                                    <asp:label runat="server">Status</asp:label>
                                                    <asp:TextBox ID="txtStatus" CssClass="form-control" placeholder="Enter Product Quantity" runat="server"></asp:TextBox>   
                                                  </div>
                                                 <div class="form-group">
                                                    <asp:label runat="server">Customer Type</asp:label>
                                                      <asp:TextBox ID="txtCustType" CssClass="form-control" placeholder="Enter Product Quantity" runat="server"></asp:TextBox>
                                                  </div>
                                                                                                
                                          <div class="form-group">
                              <asp:GridView ID="dgvSODet" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="SOdetailID" Width="100%" CssClass="table table-striped table-bordered table-hover">
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
                                                    <asp:TemplateField HeaderText="Scheduled Delivery Date">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("ScheduledDeliveryDate") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Delivery Status">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("DeliveryStatus") %>' runat="server" />
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
