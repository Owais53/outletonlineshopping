<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="outletonlineshopping.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Manage</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                         <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                  
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                 <div class="menu">
                                     <asp:Menu ID="mnu" Orientation="Horizontal" StaticMenuItemStyle-HorizontalPadding="50px"  runat="server" OnMenuItemClick="mnu_MenuItemClick">
                                         <Items>
                                             <asp:MenuItem Text="Brands" Value="0" Selected="true">

                                             </asp:MenuItem>
                                             <asp:MenuItem Text="Category" Value="1">

                                             </asp:MenuItem>
                                             <asp:MenuItem Text="Sub Category" Value="2">

                                             </asp:MenuItem>
                                             <asp:MenuItem Text="Size" Value="3">

                                             </asp:MenuItem>
                                         </Items>
                                     </asp:Menu>
                                     
                                    <div class="tabContents">
                                        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                                            <asp:View ID="viewb" runat="server">
                                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                 <div class="form-group">
                                                <div class="row">
                                        <div class="col-md-9">
                                            
                                                <div class="form-group">
                                                    <asp:label runat="server">Brand Name</asp:label>
                                                  <asp:TextBox ID="txtBrandname" CssClass="form-control" placeholder="Enter Brand Name" runat="server"></asp:TextBox>
                                                   
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
                                           </div>
                                                </ContentTemplate>
                                                     </asp:UpdatePanel>
                                            </asp:View>
                                            <asp:View ID="viewc" runat="server">
                                                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                <div class="row">
                                        <div class="col-md-9">
                                            
                                                <div class="form-group">
                                                    <asp:label runat="server">Category Name</asp:label>
                                                  <asp:TextBox ID="txtcatname" CssClass="form-control" placeholder="Enter Category Name" runat="server"></asp:TextBox>
                                                    
                                                </div>
                                                <div class="form-group">
                                                  
                                                     <asp:GridView ID="dgvcat" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="CatID" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowEditing="dgvcat_RowEditing">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Category Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("CatName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btneditcat" ImageUrl="~/img/edit.png" runat="server"  CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" CausesValidation="false"/>
                                                           <asp:ImageButton ID="btndelcat"  ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" CausesValidation="false"/>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>
                                               </Columns>
                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                     </asp:GridView> 
                                                   
                                 </div>                                                                   
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                        <div class="col-lg-6">                                                                                        
                                             <div class="form-group">
                                                <asp:Button id="btnaddcat" type="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnaddcat_Click"  />
                                             </div>
                                            
                                        </div>
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                    </div>
                                    <!-- /.row (nested) -->
                                </div>
                                           </div>
                                                </ContentTemplate>
                                                      </asp:UpdatePanel>
                                            </asp:View>
                                            <asp:View ID="viewsc" runat="server">
                                                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                <div class="row">
                                        <div class="col-md-9">
                                            
                                                <div class="form-group">
                                                    <asp:label runat="server">Category Name</asp:label>
                                                 <asp:DropDownList ID="ddlcatname" runat="server" CssClass="form-control"></asp:DropDownList>
                                                   
                                                </div>
                                             <div class="form-group">
                                                    <asp:label runat="server">Sub Category Name</asp:label>
                                                  <asp:TextBox ID="txtsubcatname" CssClass="form-control" placeholder="Enter Sub Category Name" runat="server"></asp:TextBox>
                                                   
                                                    </div>
                                                <div class="form-group">
                                                  
                                                     <asp:GridView ID="dgvsubcat" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="SubCatID" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowEditing="dgvsubcat_RowEditing">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Category Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("CatName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Sub Category Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("SubCatName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btneditsubcat" ImageUrl="~/img/edit.png" runat="server"  CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" CausesValidation="false"/>
                                                           <asp:ImageButton ID="btndelsubcat"  ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" CausesValidation="false"/>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>
                                               </Columns>
                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                     </asp:GridView> 
                                                   
                                 </div>                                                                   
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                        <div class="col-lg-6">                                                                                        
                                             <div class="form-group">
                                                <asp:Button id="btnsubcat" type="submit" runat="server" Text="Save" class="btn btn-primary" onclick="btnsubcat_Click" />
                                             </div>
                                            
                                        </div>
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                    </div>
                                    <!-- /.row (nested) -->
                                </div>
                                           </div>
                                                </ContentTemplate>
                                                      </asp:UpdatePanel>
                                            </asp:View>
                                            <asp:View ID="views" runat="server">
                                                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group">
                                                <div class="row">
                                        <div class="col-md-9">
                                                <div class="form-group">
                                                    <asp:label runat="server">Size Name</asp:label>
                                                  <asp:TextBox ID="txtsizename" CssClass="form-control" placeholder="Enter Sub Category Name" runat="server"></asp:TextBox>
                                                 
                                                    </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Brand Name</asp:label>
                                                 <asp:DropDownList ID="ddlbrandnames" runat="server" CssClass="form-control"></asp:DropDownList>
                                                   
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Category Name</asp:label>
                                                 <asp:DropDownList ID="ddlcatnames" runat="server" CssClass="form-control"></asp:DropDownList>
                                                   
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Sub Category Name</asp:label>
                                                 <asp:DropDownList ID="ddlsubcatnames" runat="server" CssClass="form-control"></asp:DropDownList>
                                                    
                                                </div>
                                                <div class="form-group">
                                                    <asp:label runat="server">Gender</asp:label>
                                                 <asp:DropDownList ID="ddlgender" runat="server" CssClass="form-control"></asp:DropDownList>
                                                   
                                                </div>
                                                <div class="form-group">
                                                  
                                                     <asp:GridView ID="dgvsize" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="SizeID" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowEditing="dgvsize_RowEditing">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Size Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("SizeName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Brand Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("CatName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Sub Category Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("SubCatName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Gender">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("GenderName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btneditsize" ImageUrl="~/img/edit.png" runat="server"  CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" CausesValidation="false"/>
                                                           <asp:ImageButton ID="btndelsize"  ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" CausesValidation="false"/>
                                                       </ItemTemplate>

                                                   </asp:TemplateField>
                                               </Columns>
                                                  <EmptyDataTemplate>No Record Available</EmptyDataTemplate> 
                                     </asp:GridView> 
                                                   
                                 </div>                                                                   
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                        <div class="col-lg-6">                                                                                        
                                             <div class="form-group">
                                                <asp:Button id="btnsize" type="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnsize_Click"/>
                                             </div>
                                            
                                        </div>
                                        
                                        <!-- /.col-lg-6 (nested) -->
                                    </div>
                                    <!-- /.row (nested) -->
                                </div>
                                           </div>
                                                </ContentTemplate>
                                                     </asp:UpdatePanel>
                                            </asp:View>
                                        </asp:MultiView>

                                    </div>
                                        
                                        </div>                                   
                                   
                                               
                                        
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                    </div>               
            </div>
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
            function alertcatsave() {
                Swal.fire(
                    'Success!',
                    'Category Saved Successfully!',
                     'success'
                     )
                
            }
      </script>
          <script>
            function alertsubcatsave() {
                Swal.fire(
                    'Success!',
                    'Sub Category Saved Successfully!',
                     'success'
                     )
                
            }
      </script>
     <script>
            function alertsizesave() {
                Swal.fire(
                    'Success!',
                    'Size Saved Successfully!',
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
            function alertcatdup() {
                Swal.fire(
                    'Error!',
                    'Category already Exists!',
                     'error'
                     )
                
            }
      </script>
     <script>
            function alertsizedup() {
                Swal.fire(
                    'Error!',
                    'Size already Exists!',
                     'error'
                     )
                
            }
      </script>
            <script>
            function alertsubcatdup() {
                Swal.fire(
                    'Error!',
                    'Sub Category already Exists!',
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
           <script>
            function alertcatedit() {
                Swal.fire(
                    'Success!',
                    'Category Successfully Edited!',
                     'success'
                     )
                
            }
      </script>
          <script>
            function alertsubcatedit() {
                Swal.fire(
                    'Success!',
                    'Sub Category Successfully Edited!',
                     'success'
                     )
                
            }
      </script>
    <script>
            function alertsizeedit() {
                Swal.fire(
                    'Success!',
                    'Size Successfully Edited!',
                     'success'
                     )
                
            }
      </script>
</asp:Content>
