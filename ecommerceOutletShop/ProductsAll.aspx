<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="ProductsAll.aspx.cs" Inherits="ecommerceOutletShop.ProductsAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row" style="padding-top:50px; margin-top:30px; min-height:10px;">
        <asp:Repeater ID="rptrProducts" runat="server">
            <ItemTemplate>
        <div class="col-sm-3 col-md-3" style="min-height:200px;">
            <a href="ProductView.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none;">
            <div class="thumbnail">
                <img src="Img/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" alt="<%# Eval("ImageName") %>" onerror="this.src='Img/imgnoavail.png'"/>
                <div class="caption">
                    <div class="probrand"><%# Eval("BrandName") %></div>
                    <div class="proName"><%# Eval("ProductName") %></div>
                    <div class="proPrice">
                        <span class="proOgPrice"></span><%# Eval("SalesPrice") %><span class="proPriceDiscount"></span>
                    </div>
                </div>
            </div>
        </div>
                </a>
             </ItemTemplate>
          </asp:Repeater>
    </div>
</asp:Content>
