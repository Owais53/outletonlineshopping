<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Vendor.aspx.cs" Inherits="outletonlineshopping.Vendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Vendor</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                      Add Vendors
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <asp:UpdatePanel ID="upv" runat="server"  >
                                                     
                                                 <ContentTemplate> 
                                                <div class="form-group">
                                                    <asp:label runat="server">Vendor Name</asp:label>
                                                  <asp:TextBox ID="txtVendorname" CssClass="form-control" placeholder="Enter Brand Name" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="valvname" runat="server" ControlToValidate="txtVendorname" ForeColor="Red" />
                                                    
                                                </div>
                                                     <div class="form-group">
                                                    <asp:label runat="server">Email</asp:label>
                                                  <asp:TextBox ID="txtemail" CssClass="form-control" placeholder="Enter Email" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="valemail" runat="server" ControlToValidate="txtemail" ForeColor="Red" />
                                                    
                                                </div>
                                                        <div class="form-group">
                                                    <asp:label runat="server">Contact No</asp:label>
                                                  <asp:TextBox ID="txtContact" CssClass="form-control" placeholder="Enter Contact" runat="server" TextMode="Number"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="valcontact" runat="server" ControlToValidate="txtContact" ForeColor="Red" />
                                                    
                                                </div>
                                                        <div class="form-group">
                                                    <asp:label runat="server">Address</asp:label>
                                                  <asp:TextBox ID="txtaddress" CssClass="form-control" placeholder="Enter Contact" runat="server" TextMode="Multiline"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="valAddress" runat="server" ControlToValidate="txtaddress" ForeColor="Red" />
                                                    
                                                </div>
                                                <div class="form-group">
                                                  
                                                     <asp:GridView ID="dgvVendor" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="VendorID" Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowEditing="dgvVendor_RowEditing" >
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Vendor Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("VendorName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("ContactNo") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Email">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Address") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ID="btneditvendor" ImageUrl="~/img/edit.png" runat="server"  CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" CausesValidation="false"/>
                                                           <asp:ImageButton ID="btndelvendor"  ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" CausesValidation="false"/>
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
                                                <asp:Button id="btnVendorSave" type="submit" runat="server" Text="Save" class="btn btn-primary" OnClick="btnVendorSave_Click" />
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
            function alertVendor() {
                Swal.fire(
                    'Error!',
                    'Vendor already Exists!',
                     'error'
                     )
                
            }
      </script>
     <script>
            function alertvendorsave() {
                Swal.fire(
                    'Success!',
                    'Vendor Saved Successfully!',
                     'success'
                     )
                
            }
      </script>
</asp:Content>
