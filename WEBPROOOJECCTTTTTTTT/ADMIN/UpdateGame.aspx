<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateGame.aspx.cs" Inherits="UpdateGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="font-size: 1.2em; display: flex; flex-direction: column; align-items:center; justify-content: center; width: 100%;">
        <h1> Choose a Game To Edit</h1>
        <div style="display:flex; gap: 2em; align-items: center; justify-content: center; width: 50%;">
            <asp:GridView CellPadding="10" ID="GridView1" runat="server" DataKeyNames="Id" DataSourceID="ObjectDataSource1" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Game" SelectMethod="getAllGames" TypeName="GameAccess" UpdateMethod="InsertGame"></asp:ObjectDataSource>
        </div>
        <br /> 
        <asp:Button ID="bcktoDash" runat="server" Text="Back To Dashboard" OnClick="bcktoDash_Click" style="font-size: 1em;" />
    </form>
</body>
</html>
