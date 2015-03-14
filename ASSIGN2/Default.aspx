<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Begin Carousel --%>
 <br>
    <div class="container">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
                <li data-target="#myCarousel" data-slide-to="3"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img src="images/joseph.jpg" alt="Movie 1" width="460" height="345">
                    <div style="position: absolute; top: 120px; left: 15px; width: 200px; height: 25px">
                        <p>Looking Into The Future</p>
                    </div>
                </div>

                <div class="item">
                    <img src="images/joseph.jpg" alt="Movie 2" width="460" height="345">
                </div>

                <div class="item">
                    <img src="images/joseph.jpg" alt="Movie 3" width="460" height="345">
                </div>

                <div class="item">
                    <img src="images/joseph.jpg" alt="Movie 4" width="460" height="345">
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
        <div class="col-md-8">
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Featured Movies</div>
                    <div class="panel-body">
                        <div class="col-md-4">
                            <img src="http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_AL_.jpg"
                                title="<%# Eval("title") %> poster"
                                alt="<%# Eval("title") %> poster"
                                class="thumbnail img-responsive" />
                            <p>Top Featured movie</p>
                        </div>
                        <div class="col-md-8">
                            <ol>
                                <li>2nd featured</li>
                                <li>3rd featured</li>
                                <li>4th featured</li>
                                <li>5th featured</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <%--End Featured Movie--%>

            <%--Begin "Born in this day" --%>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Born on this day</div>
                    <div class="panel-body">
                        <div class="col-md-4">
                            <img src="http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_AL_.jpg"
                                title="<%# Eval("title") %> poster"
                                alt="<%# Eval("title") %> poster"
                                class="thumbnail img-responsive" />
                            <p>Born on this day</p>
                        </div>
                        <div class="col-md-8">
                            <div class="row">
                                <h1>Bio</h1>
                                <p>This is where the bio goes in. NUM NUM NUM NUM NUM!!!!</p>
                            </div>
                            <div class="row">
                                <h1>Latest Movies</h1>
                                <p>This is where the latest movie goes in. NUM NUM NUM NUM NUM!!!!</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--End "Born in this day" --%>

            <%--Begin Featured Movie--%>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Featured Movies</div>
                    <div class="panel-body">
                        <div class="col-md-4">
                            <img src="http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_AL_.jpg"
                                title="<%# Eval("title") %> poster"
                                alt="<%# Eval("title") %> poster"
                                class="thumbnail img-responsive" />
                            <p>Top Featured Movies</p>
                        </div>
                        <div class="col-md-8">
                            <ol>
                                <li>2nd featured</li>
                                <li>3rd featured</li>
                                <li>4th featured</li>
                                <li>5th featured</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <%--End "Born in this day" --%>
        </div>
        <!-- col md 9 -->

        <%--This is the right hand side of the website--%>

        <div class="col-md-3 col-md-offset-1">
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Now Playing</div>
                    <div class="panel-body">
                        <ul class="list-unstyled">
                            <li>Movie1</li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Coming Soon</div>
                    <div class="panel-body">
                        <ul class="list-unstyled">
                            <li>Movie1</li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Genre</div>
                    <div class="panel-body">
                        <ul class="list-unstyled">
                            <li>Movie1</li>
                        </ul>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
