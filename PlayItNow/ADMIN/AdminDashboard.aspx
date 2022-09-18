<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="ADMIN_AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: flex; flex-direction: column; width: 100%; height: 100vh; align-items: center; justify-content: center">
            <h1 style="font-size: 4em;">Welcome Admin.</h1>

            <h3 style="font-size: 3em;">Choose what you want to do:</h3>
            <br />

            <div style="display: flex; flex-direction: row; gap: 2em;">
                <asp:Button ID="createGame" runat="server" Text="Create Game" OnClick="createGame_Click" style="font-size: 2em; cursor: pointer;" /> 
                <asp:Button ID="updateGame" runat="server" Text="Update Game" OnClick="updateGame_Click" style="font-size: 2em; cursor: pointer;"/>
                <asp:Button ID="createPlatform" runat="server" Text="Create Platform" OnClick="createPlatform_Click" style="font-size: 2em; cursor: pointer;" />
                <asp:Button ID="browse" runat="server" Text="Browse The Site" OnClick="browse_Click" style="font-size: 2em; cursor: pointer;" />
            </div>
        </div>
    </form>
</body>
</html>
