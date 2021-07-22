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
                                                    <i class="fa fa-money fa-fw" aria-hidden="true">
                                                        <span id="spanCountpo" runat="server"></span>
                                                        <br />                                                       
                                                    </i>
                                                    <br />
                                                     Purchase Order
                                                </button>
                                                 <button id="btngi" type="button" class="btn btn-outline-primary" runat="server" onserverclick="btngi_ServerClick">
                                                    <i class="fa fa-road fa-fw" aria-hidden="true">
                                                        <span id="span1" runat="server"></span>
                                                        <br />                                                       
                                                    </i>
                                                    <br />
                                                     Create Goods Issue
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
                              <asp:GridView ID="dgvSODet" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="SOdetailID" Width="100%" CssClass="table table-striped table-bordered table-hover"  OnRowCommand="dgvSODet_RowCommand">
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
                                                           <asp:Label Text='<%# Eval("Datee","{0:dd, MMM yyyy}") %>' runat="server"  />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Delivery Status">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("DeliveryStatus") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField >
                                                       <ItemTemplate>
                                                           <asp:LinkButton  ID="btnEdit" runat="server" CssClass="btn btn-primary" Text="Change Delivery Date" CommandName="Add" CommandArgument='<%# Eval("SOdetailID") %>' />
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
                      <div class="modal fade" id="ModalUpdateDate" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="DateUpdateModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text="">Change Expected Delivery Date</asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                         <div class="form-group">
                         <span class="add-on">Scheduled Delivery Date</span>
                         <asp:TextBox ID="txtdateDelivery" Text='' TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnqtysave" type="submit" runat="server" Text="Save" CausesValidation="false" class="btn btn-primary" OnClick="btnqtysave_Click" />
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
            
        </asp:UpdatePanel>
    </div>
</div>
                    </div>
                  
            
            <!-- /#page-wrapper -->
<link href="css/gridstyle.css" rel="stylesheet" />
       <script>
            function alertdeldate() {
                Swal.fire(
                    'Error!',
                    'You can not change Delivery Date of this Product!',
                     'error'
                     )
                
            }
      </script>
    
</asp:Content>
