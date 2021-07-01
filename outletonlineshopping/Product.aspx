<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="outletonlineshopping.Product" EnableEventValidation="false" ValidateRequest="false"%>
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
                                      Add Products
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            
                                                <div class="form-group">
                                                    <asp:label runat="server">Product Name</asp:label>
                                                    <asp:TextBox ID="txtProductname" CssClass="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator id="name" runat="server" ControlToValidate="txtProductname"   
                                                   ErrorMessage="Please enter a Product Name" ForeColor="Red" />
                                                     
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Cost</asp:label>
                                                    <asp:TextBox ID="txtcost" class="form-control" placeholder="Enter Cost" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator id="cost" runat="server" ControlToValidate="txtcost"   
                                                      ErrorMessage="Please enter Cost" ForeColor="Red" />
                                                      
                                                </div>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                 <ContentTemplate>
                                                <div class="form-group">
                                                     <div class="col-md-11" style="margin-left:-16px;">
                                                    <asp:label runat="server">Unit of Measure</asp:label>
                                                  
                                                        <asp:DropDownList ID="ddluom" runat="server" CssClass="form-control"></asp:DropDownList>
                                                       </div>
                                                    <div style="margin-left:400px; ">
                                                        <div style="margin-bottom:-10px; z-index:-1;">
                                                             <asp:LinkButton ID="btnopen" CssClass="btn btn-primary btn-circle" CausesValidation="false" runat="server" OnClick="btnopen_Click" Text='<i class="fa fa-list"></i>' />                                                                                                        
                                                        </div>
                                                       
                                                    </div>
                                                                                                     
                                                     <asp:RequiredFieldValidator id="unit" runat="server" ControlToValidate="ddluom"   
                                                   ErrorMessage="Please enter a Product Name" ForeColor="Red" InitialValue="Select Unit" />
                                                      
                                                </div>
                                                     </ContentTemplate>
                                                <Triggers>
                                                     <asp:AsyncPostBackTrigger ControlID="btnunitsave" EventName="Click" />
                                                 </Triggers>
                                               
                                                </asp:UpdatePanel>
                                                <div style="z-index: -1;">
                                                    
                                                </div>
                                               
                                                 <div class="form-group">
                                                    <asp:label runat="server">Size</asp:label>
                                                  <asp:CheckBoxList ID="cblSize" CssClass="form-control" RepeatDirection="Horizontal" runat="server"></asp:CheckBoxList>
                                                     
                                                  </div>
                                                 <div class="form-group">
                                                    <asp:label runat="server">Quantity</asp:label>
                                                      <asp:TextBox ID="txtQty" CssClass="form-control" placeholder="Enter Product Quantity" runat="server"></asp:TextBox>
                                                  </div>
                                                 <div class="form-group">
                                                    <asp:label runat="server">Description</asp:label>
                                                    <asp:TextBox ID="txtdescription" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Product Description" runat="server"></asp:TextBox>
                                                     
                                                  </div>
                                                  <div class="form-group">
                                                    <asp:label runat="server">Product Details</asp:label>
                                                    <asp:TextBox ID="txtproductdetails" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Product Details" runat="server"></asp:TextBox>
                                                     
                                                     
                                                  </div>
                                              <div class="form-group">
                                                    <asp:label runat="server">Materials and Care</asp:label>
                                                    <asp:TextBox ID="txtMatcare" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Material and Care" runat="server"></asp:TextBox>
                                                    
                                                     
                                                  </div>
                                             <div class="form-group">
                                                    <asp:label runat="server">Upload Image</asp:label>
                                                    <asp:FileUpload ID="fuImg01" CssClass="form-control" runat="server" />
                                                     
                                                  </div>
                                              <div class="form-group">
                                                    <asp:label runat="server">Upload Image</asp:label>
                                                    <asp:FileUpload ID="fuImg02" CssClass="form-control" runat="server" />
                                                     
                                                  </div>
                                             <div class="form-group">
                                                    <asp:label runat="server">Upload Image</asp:label>
                                                    <asp:FileUpload ID="fuImg03" CssClass="form-control" runat="server" />
                                                     
                                                  </div>
                                                
                                     
                                        </div>
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                        <div class="col-lg-6">
                                            
                                            <div class="form-group">
                                                    <asp:label runat="server">Sales Price</asp:label>
                                                    <asp:TextBox ID="txtprice" CssClass="form-control" placeholder="Enter Product Price" runat="server"></asp:TextBox>
                                                    
                                                  </div>
                                              <div class="form-group">
                                                    <asp:label runat="server">Brand</asp:label>
                                                  <asp:DropDownList ID="ddlbrand" CssClass="form-control" runat="server"></asp:DropDownList>
                                                     
                                                  </div>
                                             <div class="form-group">
                                                    <asp:label runat="server">Category</asp:label>
                                                  <asp:DropDownList ID="ddlcategory" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged"></asp:DropDownList>
                                                     
                                                  </div>
                                            <div class="form-group">
                                                    <asp:label runat="server">SubCategory</asp:label>
                                                  <asp:DropDownList ID="ddlsubcategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlsubcategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                     
                                                     
                                                  </div>
                                             <div class="form-group">
                                                    <asp:label runat="server">Gender</asp:label>
                                                  <asp:DropDownList ID="ddlgender" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlgender_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    
                                                     
                                                  </div>
                                             <div class="form-group">
                                                    <asp:label runat="server">Free Delivery</asp:label>
                                                    <asp:CheckBox ID="ChkFD" runat="server" />
                                                  </div>
                                            
                                             <div class="form-group">
                                                <asp:Button id="btnProdsave" type="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnProdsave_Click" CausesValidation="false"/>
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
           
                 <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                         <div class="form-group">
                         <asp:label runat="server">Unit Name</asp:label>
                           <asp:TextBox ID="txtunit" class="form-control" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtunit"   
                            ErrorMessage="Please enter a Unit Name" ForeColor="Red" />                                             
                         </div>
                         <div class="form-group">
                              <asp:GridView ID="dgvunit" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="UomId" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowDeleting="dgvunit_RowDeleting" OnRowEditing="dgvunit_RowEditing">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Unit of Measure">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Unitofmeasure") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btnedit" ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" CausesValidation="false"/>
                                                           <asp:ImageButton ID="btndel"  ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" CausesValidation="false"/>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>
                                               </Columns>
                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                     </asp:GridView> 
                         </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnunitsave" type="submit" runat="server" Text="Save" CausesValidation="false" class="btn btn-primary" onclick="btnunitsave_Click"/>
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
            function alertproduct() {
                Swal.fire(
                    'Success!',
                    'Product Saved Successfully!',
                     'success'
                     )
                setTimeout(window.location.href = "ListProducts.aspx", 20000);
                
            }
      </script>
     <script>
            function alerteditproduct() {
                Swal.fire(
                    'Success!',
                    'Product Updated Successfully!',
                     'success'
                     )
                setTimeout(window.location.href = "ListProducts.aspx", 20000);
                
            }
           
      </script>
    <script>
        function alertemptyunit() {
            Swal.fire({
                icon: 'error',
                title: 'Error!',
                text: 'Please Enter Unit!'
            })

        }
    </script>
</asp:Content>
