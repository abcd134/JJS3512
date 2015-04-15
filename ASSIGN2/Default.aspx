<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Begin Carousel --%>


    <div class="col-md-12 col-xs-12">

        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">

                <div class="item active">
                    <asp:Image ID="CarouselBackdrop1" runat ="server" />
                    <div style="position: absolute; top: 530px; left: 40px;">
                        <h1><asp:HyperLink CssClass="carouselText" ID="CarouselInfo1" NavigateUrl="#" runat="server">Find your favorite movies here at BBP Movies</asp:HyperLink></h1>
                    </div>
                </div>

                <div class="item">
                    <asp:Image ID="CarouselBackdrop2" runat ="server" />
                    <div style="position: absolute; top: 530px; left: 40px;">
                        <h1><asp:HyperLink CssClass="carouselText" ID="CarouselInfo2" NavigateUrl="#" runat="server">Cool facts about your cast & crew for your favourite movies</asp:HyperLink></h1>
                    </div>
                </div>
                <div class="item">
                    <asp:Image ID="CarouselBackdrop3" runat ="server" />
                    <div style="position: absolute; top: 530px; left: 40px;">
                        <h1><asp:HyperLink CssClass="carouselText" ID="CarouselInfo3" NavigateUrl="#" runat="server">Sift through thousands of movies using our Browse page</asp:HyperLink></h1>
                    </div>
                </div>

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

    </div>



    <%--End of the carousel--%>

    <br />

    <div class="container">
        <%--Begin Body of the website--%>

        <%--Start of the left hand side of the website--%>

        <%--Begin Featured Movie--%>
       <div class="col-md-12 col-xs-12">
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Discover our top five featured movies</div>                       
                    </div>
                    <div class="panel-body">
                        <asp:Repeater ID="FeaturedRepeater" runat="server">
                            <ItemTemplate>
                            <div class="row">
                                <h3><a href="../SMovie/SMovie.aspx?id=<%#Eval("MovieId")%>"><%#Eval("Title")%></a></h3>
                                <div class="col-md-4">
                                    <img src="http://image.tmdb.org/t/p/w300<%#Eval("PosterPath")%>"
                                        title="<%# Eval("Title") %> poster"
                                        alt="<%# Eval("Title") %> poster"
                                        class="thumbnail img-responsive" />
                                </div>
                                <div class="col-md-8">
                                    <p>Movie Overview</p>
                                    <p><%#Eval("Overview") %></p>
                                </div>
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
                            <div class="panel-heading">Featured Cast & Crew</div>
                            <div class="panel-body">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-md-offset-1 col-md-3 col-xs-12">
                        <div class="row">
                            
                            <img src="http://image.tmdb.org/t/p/w300<%#Eval("ProfilePath")%>"
                                title="<%# Eval("Name") %> poster"
                                alt="<%# Eval("Name") %> poster"
                                class="thumbnail img-responsive" />
                        </div>
                        <div class="row">
                            <h1><a href="../SPerson/SPerson.aspx?id=<%#Eval("ID") %>"><%# Eval("Name") %></a></h1>
                            <p><%# Eval("Birthday") %></p>
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
