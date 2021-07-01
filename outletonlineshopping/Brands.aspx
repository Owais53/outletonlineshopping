<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="outletonlineshopping.Brands" %>
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
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                      Add Brands
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <asp:UpdatePanel ID="upgb" runat="server"  >
                                                     
                                                 <ContentTemplate> 
                                                <div class="form-group">
                                                    <asp:label runat="server">Brand Name</asp:label>
                                                  <asp:TextBox ID="txtBrandname" CssClass="form-control" placeholder="Enter Brand Name" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="valbrandname" runat="server" ControlToValidate="txtBrandname" ForeColor="Red" />
                                                    
                                                </div>
                                                <div class="form-group">
                                                  
                                                     <asp:GridView ID="dgvbrand" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="BrandID" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowEditing="dgvbrand_RowEditing">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Brand Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btneditbrand" ImageUrl="~/img/edit.png" runat="server"  CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" CausesValidation="false"/>
                                                           <asp:ImageButton ID="btndelbrand"  ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" CausesValidation="false"/>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>
                                               </Columns>
                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                     </asp:GridView> 
                                              </ContentTemplate>
                                                       
                                                      </asp:UpdatePanel>        
                                 </div>                                                                   
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                        <div class="col-lg-6">                                                                                        
                                             <div class="form-group">
                                                <asp:Button id="btnbrandsave" type="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnbrandsave_Click" />
                                             </div>
                                            
                                        </div>
                                        
                                        <!-- /.col-lg-6 (nested) -->
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
         <link href="css/gridstyle.css" rel="stylesheet" />
       <script>
            function alertbrandsave() {
                Swal.fire(
                    'Success!',
                    'Brand Saved Successfully!',
                     'success'
                     )
                
            }
      </script>
          <script>
            function alertbranddup() {
                Swal.fire(
                    'Error!',
                    'Brand already Exists!',
                     'error'
                     )
                
            }
      </script>
           <script>
            function alertbrandedit() {
                Swal.fire(
                    'Success!',
                    'Brand Successfully Edited!',
                     'success'
                     )
                
            }
      </script>
</asp:Content>
