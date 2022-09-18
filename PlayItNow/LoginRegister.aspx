<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginRegister.aspx.cs" Inherits="LoginRegister" %>

<asp:Content ID="content1" ContentPlaceHolderID="contentTest" runat="server">   
        <!-- Breadcrumb Start -->
        <div class="breadcrumb-wrap">
            <div class="container-fluid">
                <ul class="breadcrumb">
                    <li class="breadcrumb-item"><a href="/">Home</a></li>
                    <li class="breadcrumb-item"><a href="/">Products</a></li>
                    <li class="breadcrumb-item active">Login & Register</li>
                </ul>
            </div>
        </div>
        <!-- Breadcrumb End -->
        
        <!-- Login Start -->
        <div class="login">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6">    
                        <h2> Register </h2>
                        <%-- Register --%>
                        <div class="register-form">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Username</label>
                                    <asp:TextBox ID="usernameTXT" class="form-control" type="text" placeholder="Username" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="Group1" ID="usernameValidator" runat="server" ErrorMessage="Username is required" ControlToValidate="usernameTXT" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    <label>E-mail</label>
                                    <asp:TextBox class="form-control" id="emailTXT" type="text" placeholder="E-mail" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="Group1" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email Required!" ControlToValidate="emailTXT" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="col-md-6">
                                    <label>Password</label>
                                    <asp:TextBox class="form-control" id="passwordTXT" type="password" placeholder="Password" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="Group1" ID="passwordValidator" runat="server" ErrorMessage="Password is required" ControlToValidate="passwordTXT" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-6">
                                    <label>Confirm Password</label>
                                    <asp:TextBox class="form-control" type="password" ID="confirmPasswordTXT"  placeholder="Password" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="Group1" ID="confirmPasswordValidator" runat="server" ErrorMessage="Confirm Password is required" ControlToValidate="confirmPasswordTXT" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ValidationGroup="Group1" ID="ComparePasswordValidator" runat="server" ErrorMessage="Password do not match" ControlToCompare="confirmPasswordTXT" ControlToValidate="passwordTXT"></asp:CompareValidator>
                                    <asp:CustomValidator ValidationGroup="Group1" ID="UserExistsValidator" runat="server" ErrorMessage="This username already exists!" ControlToValidate="usernameTXT" OnServerValidate="UserExistsValidator_ServerValidate"></asp:CustomValidator>
                                </div>

                                <div class="col-md-12">
                                    <asp:Button ValidationGroup="Group1" CssClass="btn" OnClick="RegisterUser" runat="server" Text="Register"/>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- Login --%>
                    <div class="col-lg-6">
                        <h2> Login </h2>
                        <div class="login-form">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Username</label>
                                    <asp:TextBox class="form-control" ID="LoginUsernameTXT" type="text" placeholder="Username" runat="server"/>
                                </div>
                                <div class="col-md-6">
                                    <label>Password</label>
                                    <asp:TextBox class="form-control" ID="LoginPasswordTXT" type="password" placeholder="Password" runat="server"/>
                                </div>
                                <div class="col-md-6">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="newaccount">
                                        <label class="custom-control-label" for="newaccount">Keep me signed in</label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="handler" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ValidationGroup="Group2" CausesValidation="False" CssClass="btn" ID="LoginBtn" OnClick="Login" runat="server" Text="Login" /><br />
                                    <asp:RequiredFieldValidator ValidationGroup="Group2" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Username Required!" ControlToValidate="LoginUsernameTXT" ForeColor="Red"></asp:RequiredFieldValidator> <br />
                                    <asp:RequiredFieldValidator ValidationGroup="Group2" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password Required!" ControlToValidate="LoginPasswordTXT" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Login End -->
</asp:Content>