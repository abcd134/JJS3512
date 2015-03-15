<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SPerson.aspx.cs" Inherits="SPerson" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="container">

        <%--Begin left hand side of the webpage--%>
        <div class="col-md-4">
            <div class="row">
                <img src="http://ia.media-imdb.com/images/M/MV5BMTcwNTE4MTUxMl5BMl5BanBnXkFtZTcwMDIyODM4OA@@._V1_SX214_AL_.jpg"
                    title="<%# Eval("title") %> poster"
                    alt="<%# Eval("title") %> poster"
                    class="thumbnail img-responsive" />
            </div>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-body">
                        Hello
                    </div>
                </div>
            </div>
        </div>
        <%--End left side--%>


        <%--Begin Right Hand side of the webpage--%>
        <div class="col-md-7 col-md-offset-1">
            <%--Name Section--%>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Name</div>
                    <div class="panel-body">
                        Hello
                    </div>
                </div>
            </div>
            <%--Bio Section--%>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Biography</div>
                    <div class="panel-body">
                        YAYAYA NYAAAAAAA DEEEESSSSUUUUUUUUU kitty kitty kitty kitty
                    </div>
                </div>
            </div>
            <%--Social Media Section--%>
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading">Social Media num num num</div>
                    <div class="panel-body">
                        Facebook,  Twitter,  Website,   email
                    </div>
                </div>
            </div>
            <%--Carousel Pictures of Actor Actress--%>
            <div class="row">
                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <ol class="carousel-indicators">
                        <li data-target="PersonCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="PersonCarousel" data-slide-to="1"></li>
                        <li data-target="PersonCarousel" data-slide-to="2"></li>
                        <li data-target="PersonCarousel" data-slide-to="3"></li>
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
        </div>
        <%--End Right hand side--%>
    </div>
    
    <br />

    <div class="container">
        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">Movies</div>
                <div class="panel-body">
                    MOVIES NUM NUM NUM NUM NUM
                </div>
            </div>
        </div>

        <div class="row">
            <div class="panel panel-default">
                <div class="panel-heading">Department</div>
                <div class="panel-body">
                    Department NUM NUM NUM NUM NUM
                </div>
            </div>
        </div>
    </div>

</asp:Content>
