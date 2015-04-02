<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <%# Eval("id") %>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
