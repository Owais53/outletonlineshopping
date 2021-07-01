<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="ProductsAll.aspx.cs" Inherits="ecommerceOutletShop.ProductsAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row" style="padding-top:50px;">
        <asp:Repeater ID="rptrProducts" runat="server">
            <ItemTemplate>
        <div class="col-sm-3 col-md-3" style="min-height:50px;">
            <a href="ProductView.aspx?PID=<%# Eval("PID") %>" style="text-decoration:none;">
            <div class="thumbnail">
                <img src="Img/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extension") %>" alt="<%# Eval("ImageName") %>" />
                <div class="caption">
                    <div class="probrand"><%# Eval("BrandName") %></div>
                    <div class="proName"><%# Eval("ProductName") %></div>
                    <div class="proPrice">
                        <span class="proOgPrice"><%# Eval("Cost") %></span><%# Eval("SalesPrice") %><span class="proPriceDiscount">(<%# Eval("DiscAmount") %>)</span>
                    </div>
                </div>
            </div>
        </div>
                </a>
             </ItemTemplate>
          </asp:Repeater>
    </div>
</asp:Content>
