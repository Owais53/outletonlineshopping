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
      <div class="item <%# GetActiveImgClass(Container.ItemIndex) %>">
        <img src="Img/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extension") %>"  alt="<%# Eval("Name") %>" onerror="this.src='Img/imgnoavail.png'"/>
          
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
            <asp:Repeater ID="rptrProdInfo" runat="server" OnItemDataBound="rptrProdInfo_ItemDataBound">
            <ItemTemplate>
            <div class="divDet1">
            <h1 class="proNameView"><%# Eval("ProductName") %></h1>
            <span class="proOgPriceView"></span>
            <p class="proPriceView">Rs. <%# Eval("SalesPrice") %></p>
            </div>
            <div>
                <h5 class="h5size">SIZE</h5>
                <div>
                    <asp:radiobuttonlist  CssClass="Radio" RepeatDirection="Horizontal" ID="rblSize" runat="server">
                        
                    </asp:radiobuttonlist>
                </div>
            </div>
            <div class="divDet1">
                <asp:button ID="btnAddtoCart" CssClass="mainButton" runat="server" text="ADD TO CART" OnClick="btnAddtoCart_Click" />
                <asp:Label ID="lblError" CssClass="text-danger" runat="server"></asp:Label>
            </div>
            <div class="divDet1">
                <h5 class="h5size">Description</h5>
                <p><%# Eval("Description") %></p>

                <h5 class="h5size">Product Details</h5>
                <p><%# Eval("ProductDetails") %></p>

                <h5 class="h5size">Material & Care</h5>
                <p><%# Eval("MaterialCare") %></p>
                <div>                   
                <p><%# ((int)Eval("FreeDelivery")==1)? "Free Delivery":"" %></p>
                </div>
                
            </div>
                <asp:HiddenField ID="hfCatID" runat="server" Value='<%# Eval("CategoryID") %>'></asp:HiddenField>
                <asp:HiddenField ID="hfSubCatID" runat="server" Value='<%# Eval("SubCatID") %>'></asp:HiddenField>
                <asp:HiddenField ID="hfGenderID" runat="server" Value='<%# Eval("GenderID") %>'></asp:HiddenField>
                 <asp:HiddenField ID="hfBrandID" runat="server" Value='<%# Eval("BrandID") %>'></asp:HiddenField>
                </ItemTemplate>
                
                </asp:Repeater>
        </div>
    </div>
</asp:Content>
