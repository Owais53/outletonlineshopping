<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="PONew.aspx.cs" Inherits="outletonlineshopping.PONew" %>
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
                                      View Purchase Order
                                </div>
                                <div class="panel-body" style="position:relative;">
                                      <div class="buttonGr">
                                                <button id="btnGrinPonew" type="button" class="btn btn-outline-primary" runat="server" onserverclick="btnGrinPonew_ServerClick">
                                                    <i class="fa fa-shopping-cart fa-fw" aria-hidden="true">                                                       
                                                        <span>Create Good Receipt</span>
                                                    </i>
                                                </button>
                                            </div>
                                    <div class="row">
                                        <div class="col-lg-9" >
                                               
                                                <div class="form-group">
                                                    <asp:label runat="server">Vendor</asp:label>
                                                   <asp:DropDownList ID="ddlvendor" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlvendor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                                 <div class="form-group">
                                                    <asp:label ID="lblProd" runat="server">Product</asp:label>
                                                   <asp:DropDownList ID="ddlproduct" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                             
                                                <div class="form-group">
                                                    <asp:label ID="lblSize" runat="server">Size</asp:label>
                                                      <asp:DropDownList ID="ddlsize" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <asp:label ID="lblQty" runat="server">Quantity</asp:label>
                                                     <asp:TextBox ID="txtqty" CssClass="form-control" runat="server"></asp:TextBox> 
                                                </div>
                                                
                                                  <div class="form-group">
                                                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" Text="Add" OnClick="btnAdd_Click"></asp:Button>   
                                                  </div>
                                                
                                                                                                
                              <div class="form-group">
                              <asp:GridView ID="dgvPODet" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"  Width="100%" CssClass="table table-striped table-bordered table-hover" onRowDataBound="dgvPODet_RowDataBound" OnRowDeleting="OnRowDeleting">
                                               <Columns>
                                                  <asp:BoundField HeaderText="Product " DataField="ProductName" />
                                                   <asp:BoundField HeaderText="Size" DataField="SizeName" />
                                                   <asp:BoundField HeaderText="Quantity" DataField="Quantity" /> 
                                                   <asp:BoundField HeaderText="Price" DataField="Price" /> 
                                                   <asp:CommandField ShowDeleteButton="True"  ButtonType="Button"  />                                                                                                                                                     
                                               </Columns>
                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                     </asp:GridView> 
                         </div>
                                             <div class="form-group">
                                                    <asp:Button ID="btnsave" CssClass="btn btn-primary" runat="server" Text="Save" onclick="btnsave_Click"></asp:Button>   
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
            function alertaddpo() {
                Swal.fire(
                    'Success!',
                    'Purchase Order Successfully Created!',
                     'success'
                     )
                
            }
      </script>
</asp:Content>
