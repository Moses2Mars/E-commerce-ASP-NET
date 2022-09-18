<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>

<asp:Content ID="content1" ContentPlaceHolderID="contentTest" runat="server">   
    <!-- Breadcrumb Start -->
    <div class="breadcrumb-wrap">
        <div class="container-fluid">
            <ul class="breadcrumb">
                <li class="breadcrumb-item"><a href="#">Home</a></li>
                <li class="breadcrumb-item"><a href="#">Products</a></li>
                <li class="breadcrumb-item active">My Account</li>
            </ul>
        </div>
    </div>
    <!-- Breadcrumb End -->

    <!-- My Account Start -->
    <div class="my-account">
        <div class="container-fluid">
            <div class="row">
                <%-- Left Tabs --%>
                <div class="col-md-3">
                    <div class="nav flex-column nav-pills" role="tablist" aria-orientation="vertical">

                        <a class="nav-link active" id="account-nav" data-toggle="pill" href="#account-tab" role="tab">
                            <i class="fas fa-user-circle"></i>
                            Account Details
                        </a>

                        <a class="nav-link" id="dashboard-nav" data-toggle="pill" href="#dashboard-tab" role="tab">
                            <i class="fa fa-book"></i>
                            Library
                        </a>

                        <a class="nav-link" id="payment-nav" data-toggle="pill" href="#payment-tab" role="tab">
                            <i class="fa fa-coins"></i>
                            Payment Method
                        </a>

                        <a class="nav-link" href="Cart.aspx">
                            <i class="fas fa-shopping-cart"></i>
                            Pending Orders
                        </a>

                        
                        <asp:Button ID="Button1" class="nav-link" OnClick="Button1_Click" style="border: none;" runat="server" Text="LOGOUT" />
                        <asp:Button ID="adminBTN" class="nav-link" OnClick="adminBTN_Click" style="border: none;" runat="server" Text="Admin Dashboard" />
                    </div>
                </div>

                <div class="col-md-9">
                    <div class="tab-content">

                        <div class="tab-pane fade show active" id="account-tab" role="tabpanel" aria-labelledby="account-nav">
                            <h4>Account Details</h4>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                                    <asp:TextBox ID="username" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                                    <asp:TextBox ID="email" type="email" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label3" runat="server" Text="Date Registered"></asp:Label>
                                    <asp:Label ID="dateRegistered" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label4" runat="server" Text="Enter Password To Confirm"></asp:Label>
                                    <asp:TextBox ID="oldpassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Button runat="server" class="btn" ID="Button" OnClick="Button_Click" Text="Update Account" />
                                    <br><br>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="handler1" runat="server" Text=""></asp:Label>                                    
                                    <br>
                                </div>
                            </div>
                            <h4>Password change</h4>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="label133" runat="server" Text="Current Password"></asp:Label>
                                    <asp:TextBox ID="currentpassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="label222" runat="server" Text="New Password"></asp:Label>
                                    <asp:TextBox ID="newpassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="label3211" runat="server" Text="Confirm Password"></asp:Label>
                                    <asp:TextBox ID="confirmpassword" type="password" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="saveNewPassword" runat="server" OnClick="saveNewPassword_Click" Text="Save Changes" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="handler2" runat="server" Text=""></asp:Label>                                    
                                </div>
                            </div>
                        </div>


                        <div class="tab-pane fade" id="dashboard-tab" role="tabpanel"
                            aria-labelledby="dashboard-nav">
                            <h4>Library</h4>
                            <div class="table-responsive">
                                <table class="table table-bordered">
                                    <thead class="thead-dark">
                                        <tr>
                                            <th>Product</th>
                                            <th>Platform</th>
                                            <th>Button</th>
                                        </tr>
                                    </thead>
                                    <tbody class="align-middle">
                                        <%-- Needs to be Repeater for every product in cart table --%>
                                        <asp:Repeater ID="gamesInLibraryRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <div class="img">
                                                            <a href="#"><img src="GameImages/<%# Eval("Image") %>" alt="Image" style="width: 6em; height: auto;"></a>
                                                            <p><%# Eval("GameName") %></p>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <%# Eval("PlatformName") %>
                                                    </td>
                                                    <td><asp:Button ID="trashBtn" runat="server" Text="Play It Now!" CssClass="btn" CommandArgument='<%# Eval("PlatformName") %>' OnClick="trashBtn_Click"> </asp:Button></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <div class="tab-pane fade" id="payment-tab" role="tabpanel" aria-labelledby="payment-nav">
                            
                            <h4>Your Payment Method</h4>
                            <img src="./img/PaymentImages/visa.png" style="width: 7em; height: auto" alt="">
                            <p style="font-size: 2em;"> Your Wallet: $<asp:Label ID="walletAmount" runat="server"></asp:Label></p>
                            <asp:Button ID="Button2" runat="server" Text="Add Funds (+$50)" OnClick="Button2_Click" />
                            
                            
                            <h4 style="margin-top: 1em;">Supported Payment Method</h4>
                            <p>
                                For Payment methods We accept most methods that are out there Like Paypal, Visa,
                                MasterCard, American Express, Electron (Visa), etc.
                            </p>
                            <!-- Brand Start -->
                            <div class="brand">
                                <div class="container-fluid">
                                    <div class="brand-slider">
                                        <div class="brand-item"><img  src="./img/PaymentImages/paypal.png" alt=""></div>
                                        <div class="brand-item"><img src="./img/PaymentImages/amex.png" alt=""></div>
                                        <div class="brand-item"><img src="./img/PaymentImages/mastercard.png" alt=""></div>
                                        <div class="brand-item"><img src="./img/PaymentImages/visa-electron.png" alt=""></div>
                                        <div class="brand-item"><img src="./img/PaymentImages/visa.png" alt=""></div>
                                    </div>
                                </div>
                            </div>
                            <!-- Brand End -->
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- My Account End -->
</asp:Content>