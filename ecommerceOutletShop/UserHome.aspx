<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="ecommerceOutletShop.UserHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="row" style="margin-top:120px; margin-right:70px;">
       <div class="container bootdey">
    <div class="panel panel-default panel-order">
        <div class="panel-heading">
            <strong>Order History</strong>
            <div class="btn-group pull-right">
                <div class="btn-group">
                    <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">Filter history <i class="fa fa-filter"></i></button>
                    <ul class="dropdown-menu dropdown-menu-right">
                        <li><a id="btnAll" runat="server" href="#" onserverclick="btnAll_ServerClick">All</a></li>
                        <li><a id="btndelivered" runat="server" href="#" onserverclick="btndelivered_ServerClick">Delivered</a></li>
                        <li><a id="btnnotdelivered" runat="server" href="#" onserverclick="btnnotdelivered_ServerClick">Not Delivered</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="panel-body">
          
            <h4 class="proNameViewCart" runat="server" id="h4Noitems"></h4>
             <asp:Repeater ID="rptrOrderHistory" runat="server">
            <ItemTemplate>
            <div class="media">
                <div class="media-left">
                    <img src="Img/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("Name") %>" onerror="this.src='Img/imgnoavail.png'" class="media-object img-thumbnail" width="100px" />
                </div>
                <div class="media-body">                  
                    <div class="row">
                        <div class="col-md-12">
                            <div id="lbl" runat="server" class="pull-right"><asp:Label ID="lblstatus" runat="server" CssClass="" Text='<%# Eval("DeliveryStatus") %>'></asp:Label></div>
                            <span><strong>Order NO</strong></span> <span class="label label-info"><%# Eval("SONo") %></span><br />
                            <span><strong>Item</strong></span>  <span><strong><%# Eval("ProductName") %></strong></span>
                            <br />
                            Quantity : <%# Eval("Quantity") %>, Price: Rs <%# Eval("Price") %><br />
                            <a data-placement="top" class="btn btn-success btn-xs glyphicon glyphicon-ok" href="#" title="View"></a>
                            <a data-placement="top" class="btn btn-danger btn-xs glyphicon glyphicon-trash" href="#" title="Danger"></a>
                            <a data-placement="top" class="btn btn-info btn-xs glyphicon glyphicon-usd" href="#" title="Danger"></a>
                        </div>
                        <div class="col-md-12">order made on: <%# Eval("Createdon") %></div>
                    </div>
                </div>
            </div>
                </ItemTemplate>
                 </asp:Repeater>
            
    </div>
</div>
   </div>
       </div>
</asp:Content>
