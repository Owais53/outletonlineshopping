<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ListGoodsIssue.aspx.cs" Inherits="outletonlineshopping.ListGoodsIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Goods Issue</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                           
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Goods Issue List
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        
                                           <asp:GridView ID="dgvGI" runat="server" CssClass="display compact"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="SOID,GiCount" OnRowEditing="dgvGI_RowEditing">
                                               <Columns>
                                                   <asp:TemplateField HeaderText="Sale Order Reference">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("SONo") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GI No">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("DocNo") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("MoveType") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" Visible="false">
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
        $("[id*=dgvGI]").DataTable(
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
