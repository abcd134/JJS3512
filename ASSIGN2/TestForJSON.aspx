<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestForJSON.aspx.cs" Inherits="TestForJSON" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
  <!-- jQuery -->
  <script src="http://code.jquery.com/jquery-1.10.2.min.js"></script>

  <!-- Fotorama -->
  <link href="~/Content/fotorama.css" rel="stylesheet"/>
 <script src="../Scripts/fotorama.js" type="text/javascript"></script>



</head>
<body>
    <form id="form1" runat="server">




        <div>
            <asp:Repeater ID="Backdrop" runat="server">
                <HeaderTemplate>
                    <div class="fotorama" data-nav="thumbs" data-width=" 700" data-ratio="700/467" data-max-width="50%">
                </HeaderTemplate>
                <ItemTemplate>
                    <img src="<%# Eval("FilePath500") %>" />
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

        <h1>ADDITIONAL POSTER</h1>
        <asp:Repeater ID="rptPosters" runat="server">
            <HeaderTemplate>
                <div class="fotorama" data-nav="thumbs" data-width=" 700" data-ratio="700/467" data-max-width="50%">
            </HeaderTemplate>
            <ItemTemplate>
                <img src="<%# Eval("FilePath500") %>" />
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>

    </form>
</body>
</html>
