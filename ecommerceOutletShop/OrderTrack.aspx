<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderTrack.aspx.cs" Inherits="ecommerceOutletShop.OrderTrack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tracking</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="css/Custom1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div class="container">
    <div class="card">
        <header class="card-header"> My Orders / Tracking </header>
        <asp:Repeater ID="rptrTrack" runat="server">
             <ItemTemplate>
                  <div class="card-body">
            <h6>Order No: <%# Eval("SONo") %></h6>
            <article class="card">
                <div class="card-body row">
                    <div class="col"> <strong>Estimated Delivery time:</strong> <br><asp:Label runat="server" ID="lblDate" Text='<%# Eval("Datee") %>'></asp:Label> </div>
                    <div class="col"> <strong></strong> <br> </div>
                    <div class="col"> <strong>Status:</strong> <br> <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("Status") %>'></asp:Label></div>
                    <div class="col"> <strong>Tracking #:</strong> <br> <%# Eval("DocNo") %></div>
                </div>
            </article>
            <div class="track">
                <div id="divconf" class="step active" runat="server"> <span class="icon"> <i class="fa fa-check"></i> </span> <span class="text">Order confirmed</span> </div>
                <div id="divStockpick" class="step" runat="server"> <span class="icon"> <i class="fa fa-user"></i> </span> <span class="text"> Stock Picking</span> </div>
                <div id="divShipped" class="step" runat="server"> <span class="icon"> <i class="fa fa-truck"></i> </span> <span class="text"> Shipped </span> </div>
                <div id="divDev" class="step"  runat="server"> <span class="icon"> <i class="fa fa-box"></i> </span> <span class="text">Delivered</span> </div>
            </div>
            <hr>
            <ul class="row">             
                <li class="col-md-4">
                    <figure class="itemside mb-3">
                        <div class="aside"><img src="Img/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>" width="100px" alt="<%# Eval("Name") %>" onerror="this.src='Img/imgnoavail.png'" class="img-sm border"></div>
                        <figcaption class="info align-self-center">
                            <p class="title"><%# Eval("ProductName") %> <br></p> <span class="text-muted">Rs <%# Eval("Price") %> </span>
                        </figcaption>
                    </figure>
                </li>
            </ul>
            <hr> <a href="UserHome.aspx" class="btn btn-warning" data-abc="true"> <i class="fa fa-chevron-left"></i> Back to orders</a>
        </div>
                 </ItemTemplate>
        </asp:Repeater>
       
    </div>
</div>
    </div>
    </form>
</body>
</html>
