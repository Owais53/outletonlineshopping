<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ListCampaign.aspx.cs" Inherits="outletonlineshopping.ListCampaign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Campaign</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <a class="btn btn-primary" href="Campaign.aspx">Add New</a>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Campaign List
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        
                                               <asp:GridView ID="dgvcampaign" runat="server" CssClass="display compact"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true" DataKeyNames="CampaignId" OnRowEditing="dgvcampaign_RowEditing" OnRowCommand="dgvcampaign_RowCommand">
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
                                                        </ItemTemplate>
                                                       <FooterTemplate>
                                                            <asp:ImageButton ImageUrl="~/img/Quantity.png" runat="server" CommandName="Add" CommandArgument='<%# Eval("CampaignId") %>' ToolTip="Add" Toolwidth="20px" Height="20px"/>                                                     
                                                       </FooterTemplate>

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
            <div class="modal fade" id="ModalLead" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="LeadModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text="">Create Lead</asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                         <div class="form-group">
                             <asp:HiddenField runat="server" ID="hdcamid" />
                         <span class="add-on">Name</span>
                             <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
                          <span class="add-on">Address</span>
                             <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                             <span class="add-on">Email</span>
                             <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                              <span class="add-on">Contact No</span>
                             <asp:TextBox ID="txtcontact" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnsavelead" type="submit" runat="server" Text="Save" CausesValidation="false" class="btn btn-primary" OnClick="btnsavelead_Click" />
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
     <script>
            function alerterrornotactive() {
                Swal.fire(
                    'Error!',
                    'Campaign is Expired',
                     'error'
                     )
                
            }
      </script>
</asp:Content>
