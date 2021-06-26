<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Crm.aspx.cs" Inherits="outletonlineshopping.Crm" %>
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
                                  
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <!-- Nav tabs -->
                                    <ul class="nav nav-pills">
                                        <li class="active"><a href="#campaigns-pills" data-toggle="tab">Campaigns</a>
                                        </li>
                                        <li><a href="#profile-pills" data-toggle="tab">Profile</a>
                                        </li>
                                        <li><a href="#messages-pills" data-toggle="tab">Messages</a>
                                        </li>
                                        <li><a href="#settings-pills" data-toggle="tab">Settings</a>
                                        </li>
                                    </ul>

                                    <!-- Tab panes -->
                                    <div class="tab-content">
                                        <div class="tab-pane fade in active" id="campaigns-pills">
                                           <div class="form-group" style="margin-top:30px;">
                                               <div class="table-responsive">
                                                      <asp:GridView ID="dgvcampaign" runat="server" CssClass="display compact"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true" DataKeyNames="CampaignId" OnRowCommand="dgvcampaign_RowCommand">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Campaign Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("CampaignName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Campaign Type">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("CampaignType") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Start Date">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("StartDate") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="End Date">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("EndDate") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Status">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Status") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" />
                                                           <asp:ImageButton ImageUrl="~/img/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" width="20px" Height="20px" />                                                          
                                                        </ItemTemplate>
                                                       <FooterTemplate>
                                                            <asp:ImageButton ImageUrl="~/img/Quantity.png" runat="server" CommandName="Add" CommandArgument='<%# Eval("CampaignId") %>' ToolTip="Add" Toolwidth="20px" Height="20px"/>                                                     
                                                       </FooterTemplate>

                                                   </asp:TemplateField>
                                               </Columns>
                                           </asp:GridView>                    
                                              </div>
                                           </div>
                                            
                                        </div>
                                        <div class="tab-pane fade" id="profile-pills">
                                            <h4>Profile Tab</h4>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                        </div>
                                        <div class="tab-pane fade" id="messages-pills">
                                            <h4>Messages Tab</h4>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                        </div>
                                        <div class="tab-pane fade" id="settings-pills">
                                            <h4>Settings Tab</h4>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.panel-body -->
                            </div>
                            <!-- /.panel -->
                        </div>
                    </div>
                  
                         
                     
                  
            <div class="modal fade" id="Modal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                        <asp:Button id="btnqtysave" type="submit" runat="server" Text="Save" CausesValidation="false" class="btn btn-primary" />
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
            
        </asp:UpdatePanel>
    </div>
</div>
            </div>
        </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
<link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />

     <script type="text/javascript">
    $(function () {
        $("[id*=dgvcampaign]").DataTable(
        {
            bLengthChange: true,
            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
            bFilter: true,
            bSort: true,
            bPaginate: true
        });
    });
</script>
</asp:Content>
