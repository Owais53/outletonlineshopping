<%@ Page Title="" Language="C#" MasterPageFile="~/UserHome.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ecommerceOutletShop.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-top:50px;">
        <div class="col-md-9">
            <h4 class="proNameViewCart" runat="server" id="h4Noitems"></h4>           
            <asp:repeater ID="rptrCartProducts" runat="server">
                <ItemTemplate>                   
            <div class="media" style="border:1px solid black;">
                <div class="media-left">
                    <a href="ProductView.aspx?PID=<%# Eval("ProductId") %>" target="_blank">
                        <img class="media-object" width="100px" src="Img/ProductImages/<%# Eval("ProductId") %>/<%# Eval("Name") %><%# Eval("Extension") %>" alt="<%# Eval("Name") %>" onerror="this.src='Img/imgnoavail.png'"/>
                    </a>
                </div>
                 <div class="media-body">
                   <h4 class="media-heading proNameViewCart"><%# Eval("Name") %></h4>
                     <p class="proPriceDiscountView">Size: <%# Eval("SizeNamee") %></p>
                     <span class="proPriceView">Rs.<%# Eval("SalesPrice") %></span>
                     <p>
                         <asp:button ID="btnRemoveCart" CssClass="RemoveButton" runat="server" text="REMOVE" OnClick="btnRemoveCart_Click" />
                     </p>
                </div>
            </div>
                  </ItemTemplate>
                </asp:repeater>
        </div>
        <div id="divpriceDetail" class="col-md-3" runat="server">
            <div>
                <h5>PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span id="spancartTotal" class="pull-right priceGray" runat="server"></span>
                </div>
                <div>
                    <asp:button ID="btnBuy" cssClass="buyNowbtn" runat="server" text="BUY NOW" OnClick="btnBuy_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
