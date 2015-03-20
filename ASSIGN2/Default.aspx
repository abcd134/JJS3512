<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Begin Carousel --%>
       <span class="anchor"></span>
    <span class="anchor"></span>
    <div class="container ">
        <asp:Repeater ID="CarouselRepeater" runat="server">
            <HeaderTemplate>
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>
                        <li data-target="#myCarousel" data-slide-to="2"></li>
                    </ol>
                    <!-- Wrapper for slides -->
                    <div class="carousel-inner" role="listbox">
            </HeaderTemplate>

            <ItemTemplate>
                <div class="item">
                    <%--Reference : http://www.desktopwallpapers4.me/male-celebrities/keanu-reeves-7133/ --%>
                    <img src="images/KRDefault.jpg" alt="Movie 2" width="1200" height="690">
                    <div style="position: absolute; top: 550px; left: 30px;">
                        <h1><a href="SMovie/SMovie.aspx?id=<%#Eval("movie_id")%>>"> Top Grosser: <%# Eval("title") %></a></h1>
                    </div>
                </div>
            </ItemTemplate>

            <AlternatingItemTemplate>
                <div class="item active">
                    <img src="images/HobbitDefault.jpg" alt="Movie 1" width="1200" height="690">
                    <div style="position: absolute; top: 550px; left: 30px;">
                        <h1><a href="SMovie/SMovie.aspx?id=<%#Eval("movie_id")%>"> Top Grosser: <%# Eval("title") %></a></h1>
                    </div>
                </div>
            </AlternatingItemTemplate>

            <FooterTemplate>
                </div>
            <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
                </div>
            </FooterTemplate>
        </asp:Repeater> 
    </div>

    <%--End of the carousel--%>

    <br />

    <div class="container">
        <%--Begin Body of the website--%>

        <%--Start of the left hand side of the website--%>

        <%--Begin Featured Movie--%>
        <div class="col-md-12">
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h2>Featured Movies</h2>
                        <ul class="list-inline">
                            <li><asp:Button ID="FeaturedButton1" runat="server" CssClass="circle" OnClick="FeaturedButton1_Click" Text="1" Height="75px" Width="75px"/></li>
                            <li><asp:Button ID="FeaturedButton2" runat="server" CssClass="circle" OnClick="FeaturedButton2_Click" Text="2" Height="75px" Width="75px"/></li>
                            <li><asp:Button ID="FeaturedButton3" runat="server" CssClass="circle" OnClick="FeaturedButton3_Click" Text="3" Height="75px" Width="75px"/></li>
                            <li><asp:Button ID="FeaturedButton4" runat="server" CssClass="circle" OnClick="FeaturedButton4_Click" Text="4" Height="75px" Width="75px"/></li>
                            <li><asp:Button ID="FeaturedButton5" runat="server" CssClass="circle" OnClick="FeaturedButton5_Click" Text="5" Height="75px" Width="75px"/></li>
                        </ul>
                    </div>
                    <div class="panel-body">
                        <asp:Repeater ID="FeaturedRepeater" runat="server">
                            <ItemTemplate>
                                <h3><a href="../SMovie/SMovie.aspx?id=<%#Eval("movie_id")%>"><%#Eval("title")%></a></h3>
                                <div class="col-md-4">
                                    <img src="http://image.tmdb.org/t/p/w300<%#Eval("poster_path")%>"
                                        title="<%# Eval("title") %> poster"
                                        alt="<%# Eval("title") %> poster"
                                        class="thumbnail img-responsive" />
                                </div>
                                <div class="col-md-8">
                                    <p>Movie Overview</p>
                                    <p><%#Eval("overview") %></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
            <%--End Featured Movie--%>

            <%--Begin "Born in this day" --%>
            <asp:Repeater ID="FeaturedPersonRepeater" runat="server">
                <HeaderTemplate>
                    <div class="row">
                        <div class="panel panel-default">
                            <div class="panel-heading">Featured Person</div>
                            <div class="panel-body">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-3 col-md-offset-1">
                        <div class="row">
                            <img src="http://image.tmdb.org/t/p/w300<%#Eval("profile_path")%>"
                                title="<%# Eval("name") %> poster"
                                alt="<%# Eval("name") %> poster"
                                class="thumbnail img-responsive" />
                        </div>
                        <div class="row">
                            <h1><a href="../SPerson/SPerson.aspx?id=<%#Eval("person_id") %>"><%# Eval("name") %></a></h1>
                            <p>- <%# Eval("birthday") %></p>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                            </div>
                        </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <%--End "Born in this day" --%>
        </div>
    </div>
</asp:Content>
