<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateGame.aspx.cs" Inherits="CreateGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server" style="font-size: 1.2em; display: flex; flex-direction: column; align-items:center; justify-content: center; width: 100%;">
        <h1> Create a Game</h1>
        <div style="display:grid; grid-template-columns: 1fr 2fr; gap: 2em; align-items: center; justify-content: center; width: 50%;">

            <asp:Label ID="Game_Name_Label" runat="server" Text="Enter Game Name" style="grid-column:1/2"></asp:Label>
            <asp:TextBox ID="GameNameTXT" runat="server" style="grid-column:2/3"></asp:TextBox>

            <asp:Label ID="Label1" runat="server" Text="Enter Game Description"></asp:Label>
            <textarea id="GameDescriptionTXT" cols="20" rows="2" runat="server"></textarea>

            <asp:Label ID="Label2" runat="server" Text="Enter Game Genres (Comma Seperated)"></asp:Label>
            <asp:TextBox ID="GameGenresTXT" runat="server"></asp:TextBox>

            <asp:Label ID="GameImageLabel" runat="server" Text="Upload Game Image"></asp:Label>
            <asp:FileUpload ID="GameImage" runat="server" />

            <asp:Label ID="Label5" runat="server" Text="Choose Platforms"></asp:Label>
            <asp:CheckBoxList ID="PlatformCheckbox" runat="server">
            </asp:CheckBoxList>
            
            <asp:Label ID="Label4" runat="server" Text="Enter Game Price"></asp:Label>
            <asp:TextBox runat="server" ID="PlatformPrice" type="number"/>

            <asp:Label ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>


            <asp:Button ID="SubmitGameBTN" runat="server" Text="Create Game" OnClick="CreateGameFunction" style="font-size: 1em;" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Back To Dashboard" OnClick="Button1_Click" style="font-size: 1em;" />
        </div>
      

    </form>
</body>
</html>
