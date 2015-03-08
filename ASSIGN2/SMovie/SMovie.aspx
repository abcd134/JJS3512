<%@ Page Title="Single Movie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SMovie.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .row {margin-top:5%;}
    </style>
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-10">
            <div class="col-md-4">
                <figure>
                    <!--ADD THE RIGHT IMAGE HERE-->
                    <img src="/images/Computer-Cat.jpg" alt="..." class="thumbnail" width="300px"/>
                </figure>
            </div>

            <!--Movie Information-->
            <div class="col-md-8">
                <!--This is the important information for a movie-->
                <div class="panel panel-default">
                    <div class="panel-heading">Add Title (Release Date)</div>
                    <div class="panel-body">
                        <p>Rating: ADD RATING</p>
                        <p>Run Time: ADD Run Time</p>
                        <p>Genre: ADD GENRE</p>
                    </div>
                </div>
                <!--This is the movie overview-->
                <div class="panel panel-default">
                    <div class="panel-heading">Overview</div>
                    <div class="panel-body">
                        <p>BOOTSTRAP IS UGH!!! ADD MOVIE OVERVIEW HERE :)</p>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">Tag Lines</div>
                    <div class="panel-body">
                        <p>Add Tag lines</p>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">Key Words</div>
                    <div class="panel-body">
                        <p>Add Key words</p>
                    </div>
                </div>
            </div>
        </div>
        <!-- Side bar content -->
        <div class="col-md-2">
            <div class="panel panel-default">
                <div class="panel-heading">Movie Details</div>
                <div class="panel-body">
                <p>Average Rating: ADD RATING</p>
                <p>Vote Count: ADD VOTE COUNT</p>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">Movie Information</div>
                <div class="panel-body">
                    <p>ID: ADD IMDB ID</p>
                    <p>Companies: ADD MOVIE COMPANIES</p>
                    <p>Budget: Add Budget</p>
                    <p>Revenue: Add Revenue</p>
                </div>
            </div>
        </div>
    </div>



    <!--Put in loop and it can fit 5 imgs-->
    <div class="row">
        <div class="col-md-10">
            <div class="panel panel-default">
               <div class="panel-heading">Backdrops</div>
               <div class="panel-body">
                    <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                     </div>

                    <div class="col-xs-4 col-md-2">
                         <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                         </a>
                    </div>

                    <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                    </div>

                    <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                    </div>

                     <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                    </div>
             </div>
         </div>
        <!-- Add cast and crew members-->
        <div class="panel panel-default">
         <div class="panel-heading">Cast</div>
            <div class="panel-body">
                <p>Add Cast Members</p>
            </div>
        </div>

         <div class="panel panel-default">
         <div class="panel-heading">Crew</div>
            <div class="panel-body">
                <p>Add Crew Members</p>
            </div>
        </div>

        <!--Add related movies images-->
         <div class="panel panel-default">
               <div class="panel-heading">Related Movies</div>
               <div class="panel-body">
                    <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                     </div>

                    <div class="col-xs-4 col-md-2">
                         <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                         </a>
                    </div>

                    <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                    </div>

                    <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                    </div>

                     <div class="col-xs-4 col-md-2">
                        <a href="#" class="thumbnail">
                            <img src="/images/Computer-Cat.jpg" alt="..." />
                        </a>
                    </div>
             </div>
         </div>

      </div>
   </div>
</asp:Content>
