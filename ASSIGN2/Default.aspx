<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <br>
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

    <div class="row">

        <div class="col-md-9">
            <div class="row">
                <h2>Featured Movies</h2>
                <div class="col-md-4">
                    <img src="http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_AL_.jpg"
                        title="<%# Eval("title")%> poster"
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
          
            <div class="row">
                <h2>BORN TO DAY</h2>
                <div class="col-md-4">
                    <img src="http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_AL_.jpg"
                        title="<%# Eval("title")%> poster"
                        alt="<%# Eval("title") %> poster"
                        class="thumbnail img-responsive" />
                    <p>Persons picture</p>
                </div>
                <div class="col-md-8">
                    <p>BIO</p>
                </div>
            </div>

            <div class="row">
                <h2>Featured People</h2>
                <div class="col-md-4">
                    <img src="http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_AL_.jpg"
                        title="<%# Eval("title")%> poster"
                        alt="<%# Eval("title") %> poster"
                        class="thumbnail img-responsive" />
                    <p>Persons picture</p>
                </div>
                <div class="col-md-8">
                    <p>BIO</p>
                </div>
            </div>

        </div>
        <div class="col-md-3">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
