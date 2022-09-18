<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="content1" ContentPlaceHolderID="contentTest" runat="server">
        <!-- Breadcrumb Start -->
        <div class="breadcrumb-wrap">
            <div class="container-fluid">
                <ul class="breadcrumb">
                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                    <li class="breadcrumb-item"><a href="#">Products</a></li>
                    <li class="breadcrumb-item active">Product List</li>
                </ul>
            </div>
        </div>
        <!-- Breadcrumb End -->
        
        <!-- Product List Start -->
        <div class="product-view">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="product-view-top">
                                    <div class="row">            

                                        <div class="col-md-4">
                                            <div class="product-price-range">
                                                <div class="dropdown">
                                                    <div class="dropdown-toggle" data-toggle="dropdown">Sort By Platform</div>
                                                    <div class="dropdown-menu dropdown-menu-right">
                                                        <asp:Repeater ID="platformRepeater" runat="server">
                                                            <ItemTemplate>
                                                                <asp:LinkButton class="dropdown-item" ID="routeToGenre" OnClick="routeToGenre_Click" commandArgument='<%# Eval("name") %>' runat="server"><%# Eval("name") %> (<%# Eval("count") %>)</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            

                            <asp:Repeater ID="GameRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-4" onclick="window.location.href='ProductDetail.aspx?id=<%# Eval("Id") %>'">
                                        <div class="product-item">
                                            <div class="product-title">
                                                <a class="ratting" href="#" style="font-family: Copperplate; font-style: italic;"><i class="fas fa-thumbtack"></i> EXCLUSIVE</a><br>
                                                <a href="ProductDetail.aspx?id=<%# Eval("Id") %>"> <%# Eval("name")%> </a>
                                    
                                            </div>
                                            <div class="product-image">
                                                <a href="product-detail.html">
                                                    <img src="./GameImages/<%# Eval("image") %>" alt="Product Image">
                                                </a>
                                                &nbsp;&nbsp;<div class="product-action">
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
        <!-- Product List End -->  
        
</asp:Content>
