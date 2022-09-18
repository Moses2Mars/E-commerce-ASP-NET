<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Wishlist.aspx.cs" Inherits="Wishlist" %>

<asp:Content ID="content1" ContentPlaceHolderID="contentTest" runat="server">        
        <!-- Breadcrumb Start -->
        <div class="breadcrumb-wrap">
            <div class="container-fluid">
                <ul class="breadcrumb">
                    <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item"><a href="ProductList.aspx">Products</a></li>
                    <li class="breadcrumb-item active">Wishlist</li>
                </ul>
            </div>
        </div>
        <!-- Breadcrumb End -->
        
        <!-- Wishlist Start -->
        <div class="wishlist-page">
            <div class="container-fluid">
                <div class="wishlist-page-inner">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th>Product</th>
                                            <th>Price</th>
                                            <th>Platform</th>
                                            <th>Add to Cart</th>
                                            <th>Remove</th>
                                        </tr>
                                    </thead>
                                    <tbody class="align-middle">
                                        <%-- Needs to be Repeater --%>
                                         <asp:Repeater ID="gamesInWishlistRepeater" runat="server">
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
                                                    <td><asp:LinkButton ID="addToCart" runat="server" CommandArgument='<%#Eval("GameId") + ";" + Eval("PlatformId")%>' OnClick="addToCart_Click" class="btn-cart"> Add To Cart</asp:LinkButton></td>
                                                    <td><asp:LinkButton ID="trashBtn" runat="server" CommandArgument='<%#Eval("GameId") + ";" + Eval("PlatformId")%>' OnClick="trashBtn_Click" ><i class="fa fa-trash"></i></asp:LinkButton></td>
                                                </tr>
                                                
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Wishlist End -->
</asp:Content>