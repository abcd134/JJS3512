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

    <!--rating-->
     <link href="~/Content/rating.css" rel="stylesheet" />
        <script type="text/javascript">
        $(function ()
        {
            $('.rating').rating();

            $('.ratingEvent').rating({ rateEnd: function (v) { $('#result').text(v); } });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" aria-multiline="True" spellcheck="True">
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

        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>


        <div id="NUM NUM NUM NUM NUM NUM">
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <br />
            <input type="text" id="rating" class="rating rating5" />
            <br />
            <asp:TextBox ID="txtReview" runat="server" placeholder="Enter Review here: " Height="200" Width="400" Wrap="False" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="btnReviewSubmit" runat="server" Text="Button" OnClick="btnReviewSubmit_Click" />
        </div>

        <br />
        Test DataAcces files:
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                
                <%# Eval("review_text" )%>
            </ItemTemplate>
        </asp:Repeater>
             <script src="../Scripts/rating.js" type="text/javascript"></script>

    </form>
</body>
</html>
