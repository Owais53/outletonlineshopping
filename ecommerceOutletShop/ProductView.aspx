<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="ecommerceOutletShop.ProductView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="margin-top:120px; margin-right:70px;">
        <div class="col-md-5">
            <div style="max-width:350px; margin-left:70px;" class="thumbnail">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner" role="listbox">
        <asp:Repeater ID="rptrImage" runat="server">
            <ItemTemplate>
      <div class="item active">
        <img src="Img/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" alt="Los Angeles"/>
          <div class="carousel-caption">
              01
          </div>
      </div>
                </ItemTemplate>
        </asp:Repeater>
     
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
            </div>
        </div>
        <div class="col-md-5">
            <div class="divDet1">
            <h1 class="proNameView"></h1>
            <span class="proOgPriceView"></span>
            <p class="proPriceView"></p>
            </div>
            <div>
                <h5 class="h5size">SIZE</h5>
                <div>
                    <asp:radiobuttonlist  CssClass="Radio" RepeatDirection="Horizontal" ID="rblSize" runat="server">
                        <asp:ListItem Value="S" Text="S"></asp:ListItem>
                         <asp:ListItem Value="M" Text="M"></asp:ListItem>
                         <asp:ListItem Value="L" Text="L"></asp:ListItem>

                    </asp:radiobuttonlist>
                </div>
            </div>
            <div class="divDet1">
                <asp:button ID="btnAddtoCart" CssClass="mainButton" runat="server" text="ADD TO CART" />
            </div>
            <div class="divDet1">
                <h5 class="h5size">Description</h5>
                <p>abc</p>

                <h5 class="h5size">Product Details</h5>
                <p>abcde</p>

                <h5 class="h5size">Material & Care</h5>
                <p>abcde</p>
            </div>
        </div>
    </div>
</asp:Content>
