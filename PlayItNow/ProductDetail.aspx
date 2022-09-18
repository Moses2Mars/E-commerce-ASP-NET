<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail" %>


<asp:Content ID="content1" ContentPlaceHolderID="contentTest" runat="server">
        <!-- Breadcrumb Start -->
        <div class="breadcrumb-wrap">
            <div class="container-fluid">
                <ul class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item"><a href="#">Products</a></li>
                    <li class="breadcrumb-item active">Product Detail</li>
                </ul>
            </div>
        </div>
        <!-- Breadcrumb End -->
        
        <!-- Product Detail Start -->
        <div class="product-detail">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="product-detail-top">
                            <div class="row align-items-center">
                                <div class="col-md-5">
                                    <div class="product-slider-single normal-slider">
                                        <asp:Image ID="GameImage" runat="server" alt="Game Image" />
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="product-content">
                                        <div class="title">
                                            <h2><asp:Label ID="GameName" runat="server" Text=""></asp:Label></h2>
                                        </div>
                                        <div class="p-size">
                                            <h4>Platforms:</h4> <br /> <br />
                                            <asp:Repeater ID="PlatformPrice" runat="server">
                                                <ItemTemplate>
                                                    <div class="">
                                                        <h4><%# Eval("name") %> : $<%# Eval("price") %></h4>
                                                        <asp:Button ID="addToCart" class="btn" runat="server" Text="Add To Cart" OnClick="addToCart_Click"  CommandArgument='<%#Eval("Id")%>' style="margin-left: 4px; margin-right: 4px;" />
                                                        <asp:Button ID="buyNow" class="btn" runat="server" Text="Buy Now" OnClick="buyNow_Click" CommandArgument='<%#Eval("Id") + ";" + Eval("price")%>' style="margin-left: 4px; margin-right: 4px;"/>
                                                        <asp:Button ID="addWishlist" class="btn" runat="server" Text="Add To Wishlist" OnClick="addWishlist_Click" CommandArgument='<%#Eval("Id")%>' style="margin-left: 4px; margin-right: 4px;"/>
                                                    </div> 
                                                    <br /> 
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:Label ID="handler" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row product-detail-bottom">
                            <div class="col-lg-12">
                                <ul class="nav nav-pills nav-justified">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-toggle="pill" href="#description">Description</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="pill" href="#specification">Genres</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="pill" href="#reviews">Statistics</a>
                                    </li>
                                </ul>

                                <div class="tab-content">
                                    <div id="description" class="container tab-pane active">
                                        <h4>Game description</h4>
                                        <p>
                                            <asp:Label ID="GameDescription" runat="server" Text=""></asp:Label>                                   
                                        </p>
                                    </div>
                                    <div id="specification" class="container tab-pane fade">
                                        <h4>Game Genres</h4>
                                        <asp:Label ID="GameGenre" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div id="reviews" class="container tab-pane fade">
                                        <asp:Label ID="gameOwnerCount" runat="server" Text=""></asp:Label> Gamers Own This Game. <br />
                                        <asp:Label ID="wishlistCount" runat="server" Text=""></asp:Label> Gamers Have This Game In Their Wishlist.<br />
                                        <asp:Label ID="cartCount" runat="server" Text=""></asp:Label> Gamers Have This Game In Their Cart.<br />
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="product">
                            <div class="section-header">
                                <h1>Other Games</h1>
                            </div>

                            <div class="row align-items-center product-slider product-slider-3">
                                
                                    <asp:Repeater ID="OtherGamesRepeater" runat="server">
                                        <ItemTemplate>
                                            <div class="col-lg-3">
                                                <div class="product-item" onclick="window.location.href='ProductDetail.aspx?id=<%# Eval("Id") %>'">
                                                    <div class="product-title">
                                                        <a class="ratting" href="#" style="font-family: Copperplate; font-style: italic;"><i class="fas fa-thumbtack"></i> EXCLUSIVE</a><br>
                                                        <a href="ProductDetail.aspx?id=<%# Eval("Id") %>"> <%# Eval("name")%> </a>
                                    
                                                    </div>
                                                    <div class="product-image">
                                                        <a href="product-detail.html">
                                                            <img src="./GameImages/<%# Eval("image") %>" alt="Product Image">
                                                        </a>
                                                        &nbsp;<div class="product-action">
                                                            <a href="#"><i class="fa fa-cart-plus"></i></a>
                                                            <a href="#"><i class="fa fa-heart"></i></a>
                                                        </div>
                                                    </div>
                                                    <div class="product-price">
                                                
                                                        <h3><span>$</span><%# Eval("price") %></h3>
                                                        <a href="ProductDetail.aspx?id=<%# Eval("Id") %>" class="btn"><i class="fa fa-shopping-cart"></i>Buy Now</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                
                            </div>
                        </div>
                    </div>
                    
                    
                </div>
            </div>
        </div>
        <!-- Product Detail End -->
      
</asp:Content>