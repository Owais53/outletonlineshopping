<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="GI.aspx.cs" Inherits="outletonlineshopping.GI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .buttonPOinGI{
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
                                      View  Goods Issue
                                </div>
                                <div class="panel-body" style="position:relative;">
                                     <div class="buttonPOinGI">
                                                <button id="btnsaletrack" type="button" class="btn btn-light" runat="server" onserverclick="btnsaletrack_ServerClick">
                                                    <i class="fa fa-money fa-fw" aria-hidden="true">
                                                        <span>1</span>
                                                        <br />
                                                        <span></span>
                                                    </i>
                                                    <br />
                                                    View Sale Order
                                                </button>
                                            </div>
                                    
                                    <div class="row">
                                        <div class="col-lg-9" >
                                                <asp:HiddenField ID="hdsoid" runat="server" />
                                                <div class="form-group">
                                                    <asp:label runat="server">GI No</asp:label>
                                                    <asp:TextBox ID="txtGINo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                    
                                                </div>
                                              <div class="form-group">
                                                    <asp:label runat="server" Visible="false">Status</asp:label>
                                                    <asp:TextBox ID="txtStatus" CssClass="form-control" runat="server" Enabled="false" Visible="false"></asp:TextBox>
                                                    
                                                </div>

                                                 
                                                                                            
                              <div class="form-group">
                                  <asp:GridView ID="dgvGidet" runat="server"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="Id,GiCount"   Width="100%" CssClass="table table-striped table-bordered table-hover" OnRowCommand="dgvGidet_RowCommand">
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
                                                    <asp:TemplateField HeaderText="Status">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Status") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField >
                                                       <ItemTemplate>
                                                           <asp:LinkButton  ID="btnEdit" runat="server" CssClass="btn btn-primary" Text="Change Status" CommandName="Add" CommandArgument='<%# Eval("Id") %>' />
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
                            <div class="modal fade" id="ModalUpdateStatus" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="StatusUpdateModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text="">Change Delivery Status</asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                         <div class="form-group">
                         <span class="add-on">Status</span>
                           <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Stock Picking" Value="Stock Picking"></asp:ListItem>
                               <asp:ListItem Text="Shipped" Value="Shipped"></asp:ListItem>
                               <asp:ListItem Text="Delivered" Value="Delivered"></asp:ListItem>
                           </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnsavestatus" type="submit" runat="server" Text="Save" CausesValidation="false" class="btn btn-primary" OnClick="btnsavestatus_Click" />
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
</asp:Content>
