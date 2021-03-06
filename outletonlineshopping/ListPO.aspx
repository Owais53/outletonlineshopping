<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ListPO.aspx.cs" Inherits="outletonlineshopping.ListPO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Purchase Order</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <a class="btn btn-primary" href="PONew.aspx">Add New</a>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Purchase Order List
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        
                                           <asp:GridView ID="dgvPOHeader" runat="server" CssClass="table table-striped table-bordered table-hover"  AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" DataKeyNames="POID" OnRowEditing="dgvPO_RowEditing">
                                               <Columns>
                                                    <asp:TemplateField HeaderText="PONo">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("PONo") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="SO Reference">
                                                       <ItemTemplate>
                                                           <asp:Label  Text='<%# Eval("SONo") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Order Date">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Createdon") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Vendor">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("VendorName") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Status") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:ImageButton ImageUrl="~/img/eye.png" runat="server" CommandName="Edit" ToolTip="Edit" width="20px" Height="20px" />
                                                                                    
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
           
</div>
            
        
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
<link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    $(function () {
        $("[id*=dgvPOHeader]").DataTable(
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
