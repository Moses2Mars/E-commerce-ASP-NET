<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePlatform.aspx.cs" Inherits="CreatePlatform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 1.2em; display: flex; flex-direction: column; align-items:center; justify-content: center; width: 100%;">
        <h1> Create a Platform</h1>
        <div style="display:grid; grid-template-columns: 1fr 2fr; gap: 2em; align-items: center; justify-content: center; width: 50%;">
            <asp:Label ID="Game_Name_Label" runat="server" Text="Enter Platform Name"></asp:Label>
            <asp:TextBox ID="PlatformNameTXT" runat="server"></asp:TextBox>

            <asp:Label ID="Label3" runat="server" Text="Upload Game Image"></asp:Label>
            <asp:FileUpload ID="PlatformImage" runat="server" />
            <br />
                        
            <asp:Button ID="PlatformGameBTN" runat="server" Text="Create Game" OnClick="CreatePlatformFunction" style="font-size: 1em;" />

            <br />
            <asp:Button ID="bcktoDash" runat="server" Text="Back To Dashboard" OnClick="bcktoDash_Click" style="font-size: 1em;" />
        </div>
    </form>
</body>
</html>
