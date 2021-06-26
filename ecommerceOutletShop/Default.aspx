<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ecommerceOutletShop.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Outlet Online Shopping</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale="1" />
    <meta http-equiv="X-UA-Compatible" content="IE-edge" />
    <link href="css/Custom.css" rel="stylesheet" />
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
       <div class="navbar navbar-default navbar-fixed-top" role="navigation">
           <div class="container">
               <div class="navbar-header">
                   <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                       <span class="sr-only">Toggle Navigation</span>
                       <span class="icon-bar"></span>
                       <span class="icon-bar"></span>
                       <span class="icon-bar"></span>
                   </button>
                   <a class="navbar-brand" href="Default.aspx"><span><img src="Img/shop.png" alt="MyEShopping" height="30" /></span>Outlet Shopping</a>
               </div>
               
               <div class="navbar-collapse collapse">
                   <ul class="nav navbar-nav navbar-right">
                       <li class="active"><a href="Default.aspx">Home</a></li>
                       <li><a href="#">About</a></li>
                       <li><a href="#">Contact Us</a></li>
                       <li class="dropdown">
                           <a href="#" class="dropdown-toggle" data-toggle="dropdown">Products<b class="caret"></b></a>
                           <ul class="dropdown-menu">
                                <li class="dropdown-header"><a href="#">Men</a></li>
                                 <li role="separator" class="divider"></li>
                                 <li><a href="#">Shirts</a></li>
                                 <li><a href="#">Pants</a></li>

                                <li class="dropdown-header"><a href="#">Women</a></li>
                                 <li role="separator" class="divider"></li>
                                  <li><a href="#">Shirts</a></li>
                           </ul>
                       </li>
                       <li><a href="SignIn.aspx">SignIn</a></li>
                   </ul>
               </div>
           </div>
       </div>
        <div class="container">
  <h2></h2>  
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">
      <div class="item active">
        <img src="ImgSlider/shopimg.gif" alt="Los Angeles" style="width:100%;"/>
      </div>

      <div class="item">
        <img src="ImgSlider/Printed%20T-Shirts%20Banner.png" alt="Chicago" style="width:100%;" /> 
      </div>
    
      <div class="item">
        <img src="ImgSlider/Main-Banner.jpg" alt="New york" style="width:100%; height:125%px;"/> 
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>
        <div class="container center">
            <div class="row">
                <div class="col-lg-4">
                    <img class="img-circle" src="Img/T-shirtmain.jpg" alt="thumb" width="140" height="140" />
                    <h2>T-Shirts</h2>
                    <p>Great collection of T-Shirts Available</p>
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Img/Shirtmain.jpg" alt="thumb" width="140" height="140" />
                    <h2>Shirts</h2>
                    <p>Branded Shirts from all over Pakistan</p>
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>
                <div class="col-lg-4">
                    <img class="img-circle" src="Img/womenshirt.jpg" alt="thumb" width="140" height="140" />
                    <h2>Women Wears</h2>
                    <p>Collection of Women Wears</p>
                    <p><a class="btn btn-default" href="#" role="button">View More &raquo;</a></p>
                </div>
            </div>
        </div>
        <footer>
            <div class="container">
                <p class="pull-right"><a href="#">Back to top</a></p>
                <p>&copy;2021 Outlet Shopping.pk &middot; <a href="Default.aspx">Home</a>&middot;<a href="#">About</a>&middot;<a href="#">Contact</a>&middot;<a href="#">Products</a></p>
            </div>
        </footer>
    </div>
    </form>
    
</body>
</html>
