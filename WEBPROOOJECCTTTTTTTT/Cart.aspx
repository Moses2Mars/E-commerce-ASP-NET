<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

 <asp:Content ID="content1" ContentPlaceHolderID="contentTest" runat="server">
        <!-- Breadcrumb Start -->
        <div class="breadcrumb-wrap">
            <div class="container-fluid">
                <ul class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item"><a href="#">Products</a></li>
                    <li class="breadcrumb-item active">Cart</li>
                </ul>
            </div>
        </div>
        <!-- Breadcrumb End -->
        
        <!-- Cart Start -->
        <div class="cart-page">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="cart-page-inner">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th>Product</th>
                                            <th>Price</th>
                                            <th>Platform</th>
                                            <th>Remove</th>
                                        </tr>
                                    </thead>
                                    <tbody class="align-middle">
                                        <%-- Needs to be Repeater for every product in cart table --%>
                                        <asp:Repeater ID="gamesInCartRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <div class="img">
                                                            <a href="#"><img src="GameImages/<%# Eval("Image") %>" alt="Image"></a>
                                                            <p><%# Eval("GameName") %></p>
                                                        </div>
                                                    </td>
                                                    <td>$<%# Eval("Price") %></td>
                                                    <td>
                                                        <%# Eval("PlatformName") %>
                                                    </td>
                                                    <td><asp:LinkButton ID="trashBtn" runat="server" CommandArgument='<%#Eval("GameId") + ";" + Eval("PlatformId")%>' OnClick="trashBtn_Click" ><i class="fa fa-trash"></i></asp:LinkButton></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="cart-page-inner">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="coupon">
                                        <asp:TextBox ID="couponCode" placeholder="Coupon Code" runat="server" style="width: 60%;"></asp:TextBox>
                                        <asp:Button ID="couponBTN" runat="server" class="btn" Text="Apply Code" style="width: 25%;" OnClick="couponBTN_Click" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="cart-summary">
                                        <div class="cart-content">
                                            <h1>Cart Summary</h1>
                                            <p>Sub Total<span>$<asp:Label ID="subTotal" runat="server" Text=""></asp:Label></span></p>
                                            <p>Tax <span>%5</span></p>
                                            <p id="austDiscount" runat="server">Discount <span> %50</span></p>
                                            <h2>Grand Total<span>$<asp:Label ID="grandTotal" runat="server" Text=""></asp:Label></span></h2>
                                            <asp:Label ID="handler" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div class="cart-btn">
                                            <asp:Button ID="refreshCart" runat="server" Text="Refresh Cart" class="btn" OnClick="refreshCart_Click" />
                                            <asp:Button ID="checkOut" runat="server" Text="Checkout" class="btn" OnClick="checkOut_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Cart End -->
        
       </asp:Content>

