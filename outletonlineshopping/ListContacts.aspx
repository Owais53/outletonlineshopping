<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="ListContacts.aspx.cs" Inherits="outletonlineshopping.ListContacts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="page-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1 class="page-header">Contacts</h1>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    Contacts List
                                </div>
                                <!-- /.panel-heading -->
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        
                                               <asp:GridView ID="dgvContacts" runat="server" CssClass="display compact" Width="100%"  AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ShowFooter="true" DataKeyNames="ContactId" OnRowEditing="dgvContacts_RowEditing">
                                               <Columns>
                                                   
                                                    <asp:TemplateField HeaderText="Name">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Address") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Email">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                  
                                                    <asp:TemplateField HeaderText="Contact No">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%# Eval("ContactNo") %>' runat="server" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:Button  runat="server" CommandName="Edit" CssClass="btn btn-danger" Text="Remove from Contacts" />                                                     
                                                       
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
        $("[id*=dgvContacts]").DataTable(
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
            function alertdeletecont(){
                Swal.fire(
                    'Success!',
                    'Contact Deleted',
                     'success'
                     )
                
            }
      </script>
    
 
</asp:Content>
