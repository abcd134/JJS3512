<%@ Page Title="Single Movie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SMovie.aspx.cs" Inherits="SMovie" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .rowCol {margin-top:1.5%;}
        tr,td {text-align:center; }
    </style>
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-10">
            <div class="col-md-4">
                <figure>
                    <!--ADD THE RIGHT IMAGE HERE-->
                    <!--<img src="" alt="..." class="thumbnail" />-->
                    <asp:Image runat="server" ID="imgPoster" class="thumbnail" />
                </figure>
            </div>

            <!--Movie Information-->
            <div class="col-md-8 rowCol">
                <!--This is the important information for a movie-->
                <div class="panel panel-default">
                    <div class="panel-heading"><asp:Label ID="txtTitle" runat="server" /> (<asp:Label ID="txtReleaseDate" runat="server" />)</div>
                    <div class="panel-body">
                        <p>Run Time: <asp:Label ID="txtRunTime" runat="server" /></p>
                        <p>Genre: <asp:Label ID="txtGenre" runat="server" /></p>
                        <p>Companies: <asp:Label ID="txtCompany" runat="server" /></p>
                    </div>
                </div>
                <!--This is the movie overview-->
                <div class="panel panel-default">
                    <div class="panel-heading">Overview</div>
                    <div class="panel-body">
                        <p><asp:Label ID="txtOverview" runat="server" /></p>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">Tag Line</div>
                    <div class="panel-body">
                        <p><asp:Label ID="txtTagLine" runat="server" /></p>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">Key Words</div>
                    <div class="panel-body">
                        <p><asp:Label ID="txtKeyword" runat="server" /></p>
                    </div>
                </div>
            </div>
        </div>
        <!-- Side bar content -->
        <div class="col-md-2 rowCol">
            <div class="panel panel-default">
                <div class="panel-heading">Details</div>
                <div class="panel-body">
                <p>Vote Average: <asp:Label ID="txtAverage" runat="server" /></p>
                <p>Vote Count: <asp:Label ID="txtVoteCount" runat="server" /></p>
                </div>
            </div>

            <div class="panel panel-default">
                <div class="panel-heading">Facts</div>
                <div class="panel-body">
                    <p>ID: <asp:Label ID="txtIMDB" runat="server" /></p>
                    <p>Budget: <asp:Label ID="txtBudget" runat="server" /></p>
                    <p>Revenue: <asp:Label ID="txtRevenue" runat="server" /></p>
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
        <div class="panel-group" id="accordian" role="tablist">
        <div class="panel panel-default">
         <div class="panel-heading" role="tab" id="collapseListGroupHeading1">
             <a data-toggle="collapse" href="#collapseListGroup1" aria-expanded="true" aria-controls="collapseListGroup1">Cast</a>
          </div>
            <div class="panel-body"> 
                <div id="collapseListGroup1" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading1" aria-expanded="true">
                    <asp:Repeater ID="rptCast" runat="server">
                        <ItemTemplate>                          
                             <ul class="list-group">
                                 <li class="list-group-item"><img src="http://image.tmdb.org/t/p/w45/<%# Eval("profile_path") %>>" alt="" /> 
                                     <a href="../SPerson/SPerson.aspx?id=<%# Eval("person_id") %>>"><%# Eval("name") %></a> <%# Eval("role_name") %></li>
                                 
                             </ul>
                        </ItemTemplate>
                    </asp:Repeater>
            </div>
                 </div>
        </div>
        </div><br />

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
    <asp:Label ID="message" runat="server" />
</asp:Content>
