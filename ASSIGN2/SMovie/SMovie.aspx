<%@ Page Title="Single Movie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SMovie.aspx.cs" Inherits="SMovie" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--This is start of the first main row--%>
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12">
            <%--Give the poster image a col-md of 5--%>
            <div class="col-xs-7 col-sm-6 col-md-5 imageResize">
                <asp:Repeater ID="topOfPage" runat="server">
                    <ItemTemplate>
                        
                       <a href="#" data-toggle="modal" data-target="#myModal"> 
                        <figure class="img-responsive">
                            <img src="<%# Eval("ImgPoster500") %>" class="thumbnail" />
                            <%--This Image is pulled from the code-behind--%>
                            <%-- %> <asp:Image runat="server" ID="imgPoster" class="thumbnail" /> --%>
                        </figure>
                        </a>
                  
                   
                        <%--This handles the modal for the poster and opens up the bigger picture--%>
                        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="posterModal" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    </div>
                                    <div class="modal-body">
                                        <img src="<%# Eval("ImgPoster780") %>" class="thumbnail" />
                                        <%-- <asp:Image runat="server" ID="imgPosterLarge" class="thumbnail" /> --%>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%--This is the start of box office content--%>
                        <div class="hidden-xs col-sm-12 col-md-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">Box Office</div>
                                <div class="panel-body">
                                    <p><b>Budget:</b>
                                        <%--This label data is being pulled from the code-behind--%>
                                        <%-- <asp:Label ID="txtBudget" runat="server" /> --%>
                                        <%# Eval("Budget") %> </p>
                                    <p><b>Revenue:</b>
                                        <%--This label data is being pulled from the code-behind--%>
                                        <%-- <asp:Label ID="txtRevenue" runat="server" /> --%>
                                        <%# Eval("Revenue") %></p>
                                </div>
                            </div>
                        </div>
                        <%--This is the start of the vote content--%>
                        <div class="hidden-xs col-sm-12 col-md-6">
                            <div class="panel panel-default">
                                <div class="panel-heading">Votes</div>
                                <div class="panel-body">
                                    <p><b>Vote Average:</b>
                                        <%--This label data is being pulled from the code-behind--%>
                                        <%--<asp:Label ID="txtAverage" runat="server" /> --%>
                                            <%# Eval("Average") %></p>
                                    <p><b>Vote Count:</b>
                                        <%--This label data is being pulled from the code-behind--%>
                                        <%--<asp:Label ID="txtVoteCount" runat="server" /> --%>
                                            <%# Eval("VoteCount") %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <%-- First Repeater Ends Here--ImgPoster500, ImgPoster780, Budget, Revenue,Average,VoteCount done  --%>
            </div>
            
            <%--Start Movie Information--%>
            <div class="col-md-7 col-xs-12 col-sm-6 spaceabove">
                <%--This is the important information for a movie--%>
                <div class="panel panel-default bioClear">
                    <div class="panel-heading">
                        <%--The title and release date lable is being pulled in from the code-behind--%>
                        <%-- Still need to figure out control visibility of a nested repeater --%>
                        <%-- <asp:Label ID="txtTitle" runat="server" /> --%>
                        <asp:Repeater ID="rptTitle" runat="server">
                            <ItemTemplate>
                                <%# Eval("Title") %>
                            </ItemTemplate>
                        </asp:Repeater><br />

                            <asp:LinkButton ID="addToFav" runat="server" 
                                OnCommand="addToFav_Click" 
                                Text ="Favorite" CssClass="btn btn-default"
                                CommandArgument='<%# Eval("MovieId") %>' ><span class="glyphicon glyphicon-heart"></span>  Favorite
                            </asp:LinkButton>
                            <button type="button" class="btn btn-default" data-toggle="modal" data-target="#review"  runat="server" ID="writeReview">
                                <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>  Write Review
                            </button>

                        <!-- Modal for write review -->
                         <div class="modal fade" id="review" tabindex="-1" role="dialog" aria-labelledby="review" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    </div>
                                    <div class="modal-body">
                                        <asp:Label ID="lblFname" runat="server" Text="First Name"></asp:Label><asp:TextBox ID="txtFirstName" placeholder="Enter First Name" runat="server"></asp:TextBox>
                                        <asp:Label ID="lblLname" runat="server" Text="Last Name"></asp:Label><asp:TextBox ID="txtLastName" placeholder="Enter Last Name" runat="server"></asp:TextBox>
                                        <asp:Label ID="lblTItle" runat="server" Text="Review Title"></asp:Label><asp:TextBox ID="txtReviewTitle" placeholder="Enter Review Title Here" runat="server"></asp:TextBox>
                                        <br />
                                        <input type="text" id="rating1" class="rating rating5" runat="server" />
                                        <br />
                                        <asp:TextBox ID="txtReview" runat="server" placeholder="Enter Review here: " Height="200" Width="400" Wrap="False" TextMode="MultiLine"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnReviewSubmit" runat="server" Text="Submit" OnClick="btnReviewSubmit_Click" OnClientClick="RefreshPage()" />
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                    <div class="panel-body">
                        <asp:Repeater ID="rptReleaseRun" runat="server">
                            <ItemTemplate>
                                <p><b>Release Date:</b> 
                                    <%-- <asp:Label ID="txtReleaseDate" runat="server" /> --%>
                                    <%# Eval("ReleaseDate") %>
                                </p>
                                <p><b>Run Time:</b>
                                    <%--This lable data is being pulled in from the code-behind--%>
                                    <%-- <asp:Label ID="txtRunTime" runat="server" /> --%>
                                    <%# Eval("Runtime") %>
                                </p>                      
                            </ItemTemplate>
                        </asp:Repeater>
                        <p>
                            <b>Genre:</b> |
                            <%--This is the start of the genre repeater - relies on Genre Class--%>
                            <asp:Repeater ID="rptGenre" runat="server">
                                <ItemTemplate><b><a href="../Browse/Browse.aspx?genre=<%# Eval("GenreID") %>&genreType=<%# Eval("GenreName") %>"> <%# Eval("GenreName") %></a></b> | </ItemTemplate>
                            </asp:Repeater>
                        </p>
                        <p>
                            <b>Companies:</b> |
                            <%--This is the start of the companies repeater--%>
                        <asp:Repeater ID="rptCompany" runat="server">
                            <ItemTemplate><a href='../Browse/Browse.aspx?search=<%# Eval("CompanyName") %>&SearchType=Company'><%# Eval("CompanyName") %></a> | </ItemTemplate>
                        </asp:Repeater>
                        </p>
                        <%--This IMDB label is being pulled from the code-behind--%>
                        <b><p>IMDB: <%-- <a id="linkIMDB" runat="server"> --%>
                            <asp:Repeater ID="rptIMDB" runat="server" >
                                <ItemTemplate>
                                    <a href="<%# Eval("ImdbId") %>" >
                                    <%# Eval("ImdbId") %></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p></b>
                    </div>
                </div>
                <%--This is the movie overview--%>
                <div class="panel panel-default">
                    <div class="panel-heading">Overview</div>
                    <div class="panel-body">
                        <%--This label data is being pulled from the code-behind--%>
                        <p>
                            <%-- <asp:Label ID="txtOverview" runat="server" /> --%>
                            <asp:Repeater ID="rptOverview" runat="server" >
                                <ItemTemplate>
                                    <%# Eval("Overview") %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                    </div>
                </div>
                <%--This is the start of tag line repeater--%>
                <asp:Repeater ID="rptTagline" runat="server">
                    <%--HeaderTemplate controls the panel heading--%>
                    <HeaderTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">Tag Line</div>
                            <div class="panel-body">
                    </HeaderTemplate>
                    <%--ItemTemplate controls the content--%>
                    <ItemTemplate><%# Eval("tagline") %> </ItemTemplate>
                    <FooterTemplate>
                        </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
                <%--This is the start of keyword repeater--%>
                <asp:Repeater ID="rptKeyWords" runat="server">
                    <%--HeaderTemplate controls the panel heading--%>
                    <HeaderTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">Key Words</div>
                            <div class="panel-body"> |
                    </HeaderTemplate>
                    <%--The ItemTemplate controls the content--%>
                    <ItemTemplate> <a href="../Browse/Browse.aspx?search=<%# Eval("KeyWordName") %>&SearchType=Key Word"><%# Eval("KeyWordName") %></a> |</ItemTemplate>
                    <FooterTemplate>
                        </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <%--Closing of main row--%>

    <%--This is start of a new main row--%>
    <div class="row">
        <div class="col-md-6 hidden-xs">
            <%--Start of Backdrops--%>
            <div class="panel panel-default castResize">
                <div class="panel-heading">Backdrops</div>
                <div class="panel-body">
                        <asp:Repeater ID="rptBackDrop" runat="server">
                            <HeaderTemplate>
                                <div class="fotorama" data-nav="thumbs" data-width=" 700" data-ratio="700/467" data-max-width="100%">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <img src="<%# Eval("FilePath500") %>" />
                            </ItemTemplate>
                            <FooterTemplate>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    
               <%--Modal and Backdrop ENDS HERE--%>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-xs-12">
                            <%--This is the start of trailer repeater--%>
                <asp:Repeater ID="rptTrailer" runat="server">
                    <HeaderTemplate>
                        <div class="panel panel-default crewResize">
                            <div class="panel-heading">Trailer</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <div class="panel-body">
                                <iframe class="trailerDimensions" <%--width="560" height="315" --%>src="https://www.youtube.com/embed/<%# Eval("Key") %>"></iframe>
                            </div>
                    </ItemTemplate>
                    <FooterTemplate>
                            </div>
                    </FooterTemplate>
                </asp:Repeater>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 col-xs-12">
            <%--Start of cast panel--%>
            <div class="panel-group castResize" id="accordian" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="collapseListGroupHeading1">
                        <a data-toggle="collapse" href="#collapseListGroup1" aria-expanded="true" aria-controls="collapseListGroup1">Cast</a>
                    </div>
                    <div class="panel-body">
                        <div id="collapseListGroup1" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="collapseListGroupHeading1" aria-expanded="true">
                            <%--The data is being pulled from the repeater and binded in the behind code--%>
                            <asp:Repeater ID="rptCast" runat="server">
                                <ItemTemplate>
                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <%--The checkIMG(parma) is used to check if the image path is null or not--%>
                                            <img src="<%# Eval("ProfilePath") %>" width="45px" alt="<%# Eval("ActorName") %>" title="<%# Eval("ActorName") %>" />
                                            <a href="../SPerson/SPerson.aspx?id=<%# Eval("ActorID") %>"><b><%# Eval("ActorName") %></a>
                                            ...<%# Eval("RoleName") %></b>
                                        </li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <br />
        </div>

        <div class="col-md-6 hidden-xs">
            <%--This is the start of crew panel--%>
            <div class="panel-group crewResize" id="accordian2" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="collapseListGroupHeading2">
                        <a data-toggle="collapse" href="#collapseListGroup2" aria-expanded="true" aria-controls="collapseListGroup2">Crew</a>
                    </div>
                    <div class="panel-body">
                        <div id="collapseListGroup2" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="collapseListGroupHeading2" aria-expanded="true">
                            <asp:Repeater ID="rptCrew" runat="server">
                                <ItemTemplate>
                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <%--The checkIMG(parma) is used to check if the image path is null or not--%>
                                            <img src="<%# Eval("ProfilePath") %>" width="45px" alt="<%# Eval("PersonName") %>" title="<%# Eval("PersonName") %>" />
                                            <a href="../SPerson/SPerson.aspx?id=<%# Eval("PersonID") %>"><b><%# Eval("PersonName") %></a>
                                            ...<%# Eval("Department") %></b>
                                        </li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <br />
        </div>
    </div>

    <%--this is the start of additional poster images--%>
    <div class="row">
        <div class="col-md-12 hidden-xs">
            <div class="panel-group panelResizing" id="accordian3" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="collapseListGroupHeading3">
                        <a data-toggle="collapse" href="#collapseListGroup3" aria-expanded="true" aria-controls="collapseListGroup3">Additional Poster Images</a>
                    </div>
                    <div class="panel-body">
                        <div id="collapseListGroup3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading2" aria-expanded="true">
                            <%--<div class="display">--%>


<%--                                <asp:Repeater ID="rptPosters" runat="server">
                                    <ItemTemplate>
                                        <div class="col-md-3">
                                            <a href="#" class="thumbnail" data-toggle="modal" data-target="#myModal2<%# Eval ("MovieImageID") %>">
                                                <img src="<%# Eval("FilePath154") %>" alt="" />
                                            </a>
                                             <div class="modal fade" id="myModal2<%# Eval ("MovieImageID") %>" tabindex="-1" role="dialog" aria-labelledby="backDropModal" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            </div>
                                            <div class="modal-body">
                                               <img src="<%# Eval("FilePath500") %>" alt="" class="thumbnail" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>--%>

                                <asp:Repeater ID="rptPosters" runat="server">
                                    <HeaderTemplate>
                                        <div class="fotorama" data-nav="thumbs" data-width=" 700" data-ratio="700/467" data-max-width="100%">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <img src="<%# Eval("FilePath500") %>" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>

                            <%--</div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Should escapsulate the entire code so that review section does not display when there are no reviews-->
        <div class="col-md-12 col-xs-12">
            <div class="panel panel-default panelResizing">
                <div class="panel-heading">Reviews</div>
                <div class="panel-body">
                    <asp:Repeater ID="rptReview" runat="server">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-10 col-md-offset-1">

                                    <div class="col-md-6">
                                        <div class="panel-title">
                                            <b>
                                                <asp:Label ID="lblName" runat="server" Text="Reviewer Name: "></asp:Label></b><asp:Label ID="lblDisplayName" runat="server"><%# Eval("first_name" )%> <%# Eval("last_name" )%></asp:Label>
                                            <br />
                                            <asp:Label ID="lblDate" runat="server"><b>Date of Review:</b> <%# Eval("date" )%></asp:Label>
                                            <br />
                                             <input type="text" runat="server"  id="rating" readonly="readonly" value='<%# Eval("rating") %>' class="rating rating5" />
                                            <br />
                                        </div>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lblReviewTtile" runat="server"><%# Eval("review_title" )%></asp:Label>
                                            <br />
                                            <asp:Label ID="lblReviewTest" runat="server"><%# Eval("review_text" )%></asp:Label>
                                        </div>
                                    
                                </div>
                            </div>
                             <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

    </div>
    



    <asp:Label ID="message" runat="server" />
<%--    <script>
        $(window).resize(function () {
            if ($(window).width() <= 768) {
                // do something here
                $("#collapseListGroup1").find("ul").slice(3).remove();
            }
        });
</script>--%>

                <script type="text/javascript">
        $(function ()
        {
            $('.rating').rating();

            $('.ratingEvent').rating({ rateEnd: function (v) { $('#result').text(v); } });
        });

        function RefreshPage() {
            window.location.reload()
        }
    </script>
        <script src="../Scripts/rating.js" type="text/javascript"></script>
     <script src="../Scripts/fotorama.js" type="text/javascript"></script>

</asp:Content>
