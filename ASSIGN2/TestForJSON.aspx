<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestForJSON.aspx.cs" Inherits="TestForJSON" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptNowPlaying" runat="server">
            <ItemTemplate>
                <b>Now Playing</b>
              Poster Path: <%# Eval("Backdrop_path") %> <br />
                 ID: <%# Eval("Id") %> <br />
                 Title: <%# Eval("Title") %> <br />


            </ItemTemplate>
        </asp:Repeater>
        
         <asp:Repeater ID="rptUpComing" runat="server">
             <ItemTemplate>
                 <b> Upcoming </b>
                 Poster Path: <%# Eval("Backdrop_path") %> <br />
                 ID: <%# Eval("Id") %> <br />
                 Title: <%# Eval("Title") %> <br />

            </ItemTemplate>
         </asp:Repeater>
         <asp:Repeater ID="rptTrailer" runat="server">
             <ItemTemplate>
                 <b> Trailers</b>
                 https://www.youtube.com/watch?v=<%# Eval("Key") %> <br />
            </ItemTemplate>
         </asp:Repeater>
    </div>
    </form>
</body>
</html>
