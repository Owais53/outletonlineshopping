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
                   <h4 class="media-heading proNameViewCart"><%# Eval("ProductName") %></h4>
                     <p class="proPriceDiscountView">Size: <%# Eval("SizeNamee") %></p>
                     <span class="proPriceView">Rs.<%# Eval("SalesPrice") %></span>
                      <p class="proPriceView">Quantity: <%# Eval("Qty") %></p>
                     <p>
                         <asp:button ID="btnRemoveCart" CssClass="RemoveButton" runat="server" text="REMOVE" OnClick="btnRemoveCart_Click" />
                     </p>
                </div>
            </div>
                  </ItemTemplate>
                </asp:repeater>
        </div>
        <div id="divpriceDetail" class="col-md-3" runat="server" style="margin-top:50px;">
            <div>
                <h5 class="proNameViewCart">PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span id="spancartTotal" class="pull-right priceGray" runat="server">Rs.</span>
                </div>
                <div>
                    <asp:button ID="btnBuy" cssClass="buyNowbtn" runat="server" text="BUY NOW" OnClick="btnBuy_Click" />
                </div>
            </div>
        </div>
          <div class="modal fade" id="PayModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModalPay" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
              <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                         <div class="form-group">
                         <asp:label runat="server" CssClass="proNameViewCart">Delivery Address</asp:label>
                           <asp:TextBox ID="txtdeladdress" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                  
                         </div>
                        <div>
                         <asp:label runat="server" CssClass="proNameViewCart">Total Amount</asp:label>                          
                       <span id="spanTotalAmt" class="pull-right priceGray" runat="server" style="margin-right:300px; color:red;"></span>                               
                         </div>
                        <br />                      
                        <div class="form-group">
                         <asp:label runat="server">Choose a Payment Method</asp:label>
                            <br />
                            <asp:radiobuttonlist  CssClass="Radio" RepeatDirection="Horizontal" ID="rblPayType" runat="server" OnSelectedIndexChanged="rblPayType_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="Credit Card" Value="0" />
                                            <asp:ListItem Text="Debit Card" Value="1" />
                                            <asp:ListItem Text="Cash on Delivery" Value="2" />
                          </asp:radiobuttonlist>                                      
                         </div>
                        
                        <div class="form-group">
                         <asp:label id="lblCreditcd" runat="server" Visible="false">Credit Card </asp:label>
                           <asp:TextBox ID="txtCreditCard" class="form-control" runat="server" TextMode="Number" Visible="false" Placeholder="Credit Card Number"></asp:TextBox>
                                                                  
                         </div>
                        <div class="form-group">
                         <asp:label id="lblDebitcd" runat="server" Visible="false">Debit Card </asp:label>
                           <asp:TextBox ID="txtDebitCard" class="form-control" runat="server" TextMode="Number" Visible="false" Placeholder="Debit Card Number"></asp:TextBox>
                                                                  
                         </div>
                         <asp:Label ID="lblerror" runat="server" ForeColor="Red" CssClass="text-danger" Text=""/>
                    </div>
                    <div class="modal-footer">
                        <asp:Button id="btnpay" type="submit" runat="server" Text="Pay" CausesValidation="false" class="btn btn-danger" OnClick="btnpay_Click"/>
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
            
        </asp:UpdatePanel>
    </div>
</div>
    </div>
    <script>
            function alertpaysave(obj,obj1) {
                Swal.fire(
                    'Success!',
                    'Your Order has been Confirmed.Your Order Number is "'+obj+'" You will recieve your Order on "'+obj1+'"!',
                     'success'
                     )
                
            }
           
      </script>

</asp:Content>
