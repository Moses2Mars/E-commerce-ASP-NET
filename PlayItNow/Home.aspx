<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

 <asp:Content ID="content1" ContentPlaceHolderID="contentTest" runat="server">
        <!-- Main Slider Start -->
        <div class="header mb-4 pt-5">
            <div class="container">
                <div class="row row-styling">
                    <div style="width: 100%;">
                        <div class="header-slider normal-slider">

                            <div class="header-slider-item">
                                <img src="img/slickImages/leagueoflegends.jpg" alt="Slider Image" class="slick-game-image"/>
                                <div class="header-slider-caption">
                                    <p>Download a Competitive Game to Test Your Skills Against Others</p>
                                    <a class="btn" href="ProductList.aspx"><i class="fa fa-shopping-cart"></i>Shop Now</a>
                                </div>
                            </div>

                            <div class="header-slider-item">
                                <img src="img/slickImages/blackops2.jpg" alt="Slider Image" class="slick-game-image" />
                                <div class="header-slider-caption">
                                    <p>Are Shooters More Your Style?</p>
                                    <a class="btn" href="ProductList.aspx"><i class="fa fa-shopping-cart"></i>Shop Now</a>
                                </div>
                            </div>

                            <div class="header-slider-item">
                                <img src="img/slickImages/minecraft2.jpg" alt="Slider Image" class="slick-game-image" />
                                <div class="header-slider-caption">
                                    <p>Why Not Try Some Survival Games</p>
                                    <a class="btn" href="ProductList.aspx"><i class="fa fa-shopping-cart"></i>Shop Now</a>
                                </div>
                            </div>

                            <div class="header-slider-item">
                                <img src="img/slickImages/GhostRecon.jpg" alt="Slider Image" class="slick-game-image" />
                                <div class="header-slider-caption">
                                    <p>Fan of Some Open World Games?</p>
                                    <a class="btn" href="ProductList.aspx"><i class="fa fa-shopping-cart"></i>Shop Now</a>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Main Slider End -->      
        
        <!-- Brand Start -->
        <div class="brand">
            <div class="container-fluid">
                <div class="brand-slider">
                    <div class="brand-item"><img src="img/PlatformImages/Blizzard Logo.png" alt=""></div>
                    <div class="brand-item smaller-logo"><img src="img/PlatformImages/Epic Games Logo.svg" alt=""></div>
                    <div class="brand-item"><img src="img/PlatformImages/Riot Logo.png" alt=""></div>
                    <div class="brand-item"><img src="img/PlatformImages/Steam Logo.png" alt=""></div>
                    <div class="brand-item"><img src="img/PlatformImages/Origin.svg.png" alt=""></div>
                    <div class="brand-item smaller-logo"><img src="img/PlatformImages/gog.png" alt=""></div>
                </div>
            </div>
        </div>
        <!-- Brand End -->      
        
        <!-- Feature Start-->
        <div class="feature">
            <div class="container-fluid">
                <div class="row align-items-center">
                    <div class="col-lg-3 col-md-6 feature-col">
                        <div class="feature-content">
                            <i class="fab fa-cc-mastercard"></i>
                            <h2>Secure Payment</h2>
                            <p>
                                We insure that you have an easy and secure checkout
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 feature-col">
                        <div class="feature-content">
                            <i class="fa fa-bolt"></i>
                            <h2>Fast Service</h2>
                            <p>
                                Buying and managing games has never been easier
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 feature-col">
                        <div class="feature-content">
                            <i class="fa fa-sync-alt"></i>
                            <h2>20 Days Return</h2>
                            <p>
                                Didn't like your game? Our return policy is one of the best!
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-6 feature-col">
                        <div class="feature-content">
                            <i class="fa fa-comments"></i>
                            <h2>24/7 Support</h2>
                            <p>
                                Need help with something? Contant our customer support
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Feature End-->      
        
        <!-- Category Start-->
        <div class="category">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-3">
                        <div class="category-item ch-400">
                            <img src="img/categoryImages/discountedGames.png" />
                            <a class="category-name" href="ProductList.aspx?query=OnSale">
                                <p>View All Discounted Games</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="category-item ch-250">
                            <img src="img/categoryImages/topselling.jpg" />
                            <a class="category-name" href="ProductList.aspx?query=TopSelling">
                                <p>View All Top Selling Games</p>
                            </a>
                        </div>
                        <div class="category-item ch-150">
                            <img src="img/categoryImages/recentlyreleased.jpg" />
                            <a class="category-name" href="ProductList.aspx?query=New">
                                <p>View Recently Released Games</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="category-item ch-150">
                            <img src="img/categoryImages/bygenre.jpg" />
                            <a class="category-name" href="ProductList.aspx">
                                <p>View Games By Price</p>
                            </a>
                        </div>
                        <div class="category-item ch-250">
                            <img src="img/categoryImages/topsellingbyplatf.png" />
                            <a class="category-name" href="ProductList.aspx">
                                <p>View Games By Platform</p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="category-item ch-400">
                            <img src="img/categoryImages/upcoming.jpg" />
                            <a class="category-name" href="ProductList.aspx?query=Hot">
                                <p>View Current Hot Games</p>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Category End-->       
        
        
        <!-- Featured Product Start -->
        <div class="featured-product product">
            <div class="container-fluid">
                <div class="section-header">
                    <h1>Featured Games</h1>
                </div>
                <div class="row align-items-center product-slider product-slider-4">
                    <%-- repeater --%>
                    <asp:Repeater ID="FeaturedGames" runat="server">
                        <ItemTemplate>

                            <div class="col-lg-3" onclick="window.location.href='ProductDetail.aspx?id=<%# Eval("Id") %>'">
                                <div class="product-item">
                                    <div class="product-title">
                                        <a href="#"><%# Eval("name") %></a>
                                        <div class="ratting">
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                            <i class="fa fa-star"></i>
                                        </div>
                                    </div>
                                    <div class="product-image">
                                        <a href="product-detail.html">
                                            <img src="./GameImages/<%# Eval("image") %>" alt="Product Image">
                                        </a>
                                        <div class="product-action">
                                            <a href="#"><i class="fa fa-cart-plus"></i></a>
                                            <a href="#"><i class="fa fa-heart"></i></a>
                                            <a href="#"><i class="fa fa-search"></i></a>
                                        </div>
                                    </div>
                                    <div class="product-price">
                                        <h3><span>$</span><%# Eval("price") %></h3>
                                        <a class="btn" href="ProductDetail.aspx?id=<%# Eval("id") %>"><i class="fa fa-shopping-cart"></i>Buy Now</a>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <!-- Featured Product End -->       
        
        
        <!-- Discounted Products Start -->
        <div class="recent-product product">
            <div class="container-fluid">
                <div class="section-header">
                    <h1>Discounted Games</h1>
                </div>
                <div class="row align-items-center product-slider product-slider-4">
                    <%-- Repeater --%>
                    <asp:Repeater ID="DiscountRepeater" runat="server">
                        <ItemTemplate>

                            <div class="col-lg-3">
                                <div class="product-item">
                                    <div class="product-title">
                                        <a href="#"><%# Eval("name") %></a>
                                    </div>
                                    <div class="product-image">
                                        <a href="product-detail.html">
                                            <img src="./GameImages/<%# Eval("image") %>" alt="Product Image">
                                        </a>
                                        <div class="product-action">
                                            <a href="#"><i class="fa fa-cart-plus"></i></a>
                                            <a href="#"><i class="fa fa-heart"></i></a>
                                            <a href="#"><i class="fa fa-search"></i></a>
                                        </div>
                                    </div>
                                    <div class="product-price">
                                        <h3><span>$</span><%# Eval("price") %></h3>
                                        <a class="btn" href="ProductDetail?id=<%# Eval("id") %>"><i class="fa fa-shopping-cart"></i>Buy Now</a>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <!-- Recent Product End -->
        
        <!-- Review Start -->
        <div class="review">
            <div class="section-header">
                <h1>Website Reviews</h1>
            </div>
            <div class="container-fluid">
                <div class="row align-items-center review-slider normal-slider">
                    <div class="col-md-6">
                        <div class="review-slider-item">
                            <div class="review-img">
                                <img src="img/userImages/candidate1.jpeg" alt="Image">
                            </div>
                            <div class="review-text">
                                <h2>Joe</h2>
                                <h3>Computer Scientist</h3>
                                <div class="ratting">
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                </div>
                                <p>
                                    Very Helpful Website! Thanks!
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="review-slider-item">
                            <div class="review-img">
                                <img src="img/userImages/candidate2.jpg" class="user-image" alt="Image">
                            </div>
                            <div class="review-text">
                                <h2>Humam</h2>
                                <h3>Software Engineer</h3>
                                <div class="ratting">
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                </div>
                                <p>
                                    Nice Website And Very Easy To Use!
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="review-slider-item">
                            <div class="review-img">
                                <img src="img/userImages/candidate6.jpeg" class="user-image" alt="Image">
                            </div>
                            <div class="review-text">
                                <h2>Mazen</h2>
                                <h3>Data Analyst</h3>
                                <div class="ratting">
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                </div>
                                <p>
                                    Simple Website With a Lot Of Potential!
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="review-slider-item">
                            <div class="review-img">
                                <img src="img/userImages/candidate7.jpg" class="user-image" alt="Image">
                            </div>
                            <div class="review-text">
                                <h2>Moussa</h2>
                                <h3>Web Developer</h3>
                                <div class="ratting">
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                    <i class="fa fa-star"></i>
                                </div>
                                <p>
                                    This Site Is Amazing! It Has Saved Me So Much Time!
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Review End -->        
  </asp:Content>
        
