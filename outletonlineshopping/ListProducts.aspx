<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ListProducts.aspx.cs" Inherits="outletonlineshopping.ListProducts" %>
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
                            <a class="btn btn-primary" href="Product.aspx">Add New</a>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Products List
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        
                                           <asp:GridView ID="dgvproduct" runat="server" CssClass="display compact"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="ProductId" OnRowEditing="dgvproduct_RowEditing" OnRowUpdating="dgvproduct_RowUpdating" OnRowDeleting="dgvproduct_RowDeleting" OnRowCommand="dgvproduct_RowCommand">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Product Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("ProductName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sales Price">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("SalesPrice") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Unitofmeasure") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" />
                                                           <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" />
                                                            <asp:ImageButton ImageUrl="~/img/Quantity.png" runat="server" CommandName="Add" CommandArgument='<%# Eval("ProductId") %>' ToolTip="Add" Toolwidth="20px" Height="20px"/>                                                     
                                                        </ItemTemplate>

                                                   </asp:TemplateField>
                                               </Columns>
                                           </asp:GridView> 
                                            
                                    </div>
                                    <!-- /.table-responsive -->
                                    
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
             </div>
            <div class="modal fade" id="ModalQty" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="qtyModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                         <div class="form-group">
                         <asp:label runat="server">Product Quantity</asp:label>
                           <asp:TextBox ID="txtqty" class="form-control" runat="server"></asp:TextBox>                       
                         
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnqtysave" type="submit" runat="server" Text="Save" CausesValidation="false" class="btn btn-primary" onclick="btnqtysave_Click"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
            
        </asp:UpdatePanel>
    </div>
</div>
            </div>
        
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
<link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    $(function () {
        $("[id*=dgvproduct]").DataTable(
        {
            bLengthChange: true,
            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
            bFilter: true,
            bSort: true,
            bPaginate: true
        });
    });
</script>
      <script>
            function alertdelproduct() {
                Swal.fire(
                    'Success!',
                    'Product Deleted Successfully!',
                     'success'
                     )
               
            }
      </script>
</asp:Content>
