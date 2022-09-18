<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateSingleGame.aspx.cs" Inherits="ADMIN_UpdateSingleGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 1.2em; display: flex; flex-direction: column; align-items:center; justify-content: center; width: 100%;">
        <div style="display:grid; grid-template-columns: 1fr 2fr 1fr; gap: 2em; align-items: center; justify-content: center; width: 50%;">

            <asp:Image ID="gameImage" runat="server" style="max-width: 25em; max-height: 25em; object-fit: cover; grid-column:1/4; justify-self:center;"/>

            <asp:Label ID="Label2" runat="server" Text="Game Name: " style="grid-column:1/4; justify-self:center;"></asp:Label>
            <asp:TextBox ID='gameName' runat="server" Text='' style="grid-column:1/3; font-size: 1em;"></asp:TextBox>
            <asp:Button ID="editGameName" runat="server" class="btn" Text="Edit Game Name" OnClick="editGameName_Click" style="grid-column:3/4; font-size: 1em;" />

            <br /><br />
            <asp:Label ID="gamenameHandler" runat="server" Text=""></asp:Label>
        </div>
        <asp:Label ID="Label3" runat="server" Text="Platform Prices: " style="margin-bottom: 1em;"></asp:Label>

        <asp:Repeater ID="GameRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-4" style="display: flex; flex-direction: row; gap:1em; justify-content:center; align-items: center;">
                    <asp:Label ID="Label1" style="font-size: 1em;" runat="server" Text='<%# Eval("PlatformName") %>'></asp:Label>
                    <span style="font-size: 1em;" >$</span><asp:TextBox ID="gamePrice" style="font-size: 1em;" runat="server" Text='<%# Eval("price") %>'></asp:TextBox> <br />

                    <asp:Label runat="server" Text="Discount: %" style="font-size: 1em;" ></asp:Label>
                    <asp:TextBox ID="discountAmount" runat="server" Text="0" style="font-size: 1em;" ></asp:TextBox> <br />

                    <asp:Button style="font-size: 1em;"  ID="editPlatPrice" runat="server" OnClick="editPlatPrice_Click" CommandArgument='<%# Eval("PlatformId") %>' class="btn" Text="Edit Price" />
                    <br /> <br />
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Label ID="generalErrorHandler" runat="server" Text=""></asp:Label><br />
        <asp:Button ID="returnToDashboard" runat="server" Text="Return To Dashboard" OnClick="returnToDashboard_Click" style="font-size: 1em;" />
        

    </form>
</body>
</html>
