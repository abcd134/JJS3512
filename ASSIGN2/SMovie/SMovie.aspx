<%@ Page Title="Single Movie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SMovie.aspx.cs" Inherits="SMovie" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .rowCol {margin-top:1.5%;}
        tr,td {text-align:center; }
    </style>

    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-5">
                <figure>
                    <!--ADD THE RIGHT IMAGE HERE-->
                    <!--<img src="" alt="..." class="thumbnail" />-->
                    <asp:Image runat="server" ID="imgPoster" class="thumbnail" />
                </figure>
            <div class="col-md-6">
                <div class="panel panel-default">
                <div class="panel-heading">Box Office</div>
                <div class="panel-body">
                    <p><b>Budget:</b> <asp:Label ID="txtBudget" runat="server" /></p>
                    <p><b>Revenue:</b> <asp:Label ID="txtRevenue" runat="server" /></p>
                </div>
            </div>
                </div>
                <div class="col-md-6">
             <div class="panel panel-default">
                <div class="panel-heading">Votes</div>
                <div class="panel-body">
                <p><b>Vote Average:</b> <asp:Label ID="txtAverage" runat="server" /></p>
                <p><b>Vote Count:</b> <asp:Label ID="txtVoteCount" runat="server" /></p>
                </div>
            </div>
            </div>
                </div>

            <!--Movie Information-->
            <div class="col-md-7 rowCol">
                <!--This is the important information for a movie-->
                <div class="panel panel-default">
                    <div class="panel-heading"><asp:Label ID="txtTitle" runat="server" /> (<asp:Label ID="txtReleaseDate" runat="server" />)</div>
                    <div class="panel-body">
                        <p><b>Run Time:</b> <asp:Label ID="txtRunTime" runat="server" /></p>
                        <p><b>Genre:</b> <asp:Label ID="txtGenre" runat="server" /></p>
                        <p><b>Companies:</b> <asp:Label ID="txtCompany" runat="server" /></p>
                        <p><b>IMDB:</b> <a ID="linkIMDB" runat="server"><asp:Label ID="txtIMDB" runat="server" /></a></p>
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
<%--        <div class="col-md-2 rowCol">



        </div>--%>
    </div>



    <!--Put in loop and it can fit 5 imgs-->
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
               <div class="panel-heading">Backdrops</div>
               <div class="panel-body">
                   <asp:Repeater ID="rptBackDrop" runat="server">
                       <ItemTemplate>
                         <div class="col-md-3 col-md-2">
                            <a href="#" class="thumbnail" data-toggle="modal" data-target=".bs-example-modal-lg">
                                 <img src="http://image.tmdb.org/t/p/w300/<%# Eval("file_path") %>>" alt="" id="imageModal" />
                            </a>
                        </div>
                       </ItemTemplate>
                   </asp:Repeater>
                                     <div class="modal bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-lg">
                             <div class="modal-content">
                                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br />  
                                  <img src="http://image.tmdb.org/t/p/w780/<%# Eval("file_path") %>>" alt="" />
                             </div>
                        </div>
                 </div>
                        


             </div>
         </div>
            </div>
         </div>

         <div class="row">
        <div class="col-md-6">
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
                                     <a href="../SPerson/SPerson.aspx?id=<%# Eval("person_id") %>"><%# Eval("name") %></a>
                                     ...<%# Eval("role_name") %>
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
      
     <div class="col-md-6">
    <div class="panel-group" id="accordian2" role="tablist">
        <div class="panel panel-default">
         <div class="panel-heading" role="tab" id="collapseListGroupHeading2">
             <a data-toggle="collapse" href="#collapseListGroup2" aria-expanded="true" aria-controls="collapseListGroup2">Crew</a>
          </div>
            <div class="panel-body"> 
                <div id="collapseListGroup2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading2" aria-expanded="true">
                    <asp:Repeater ID="rptCrew" runat="server">
                        <ItemTemplate>                          
                             <ul class="list-group">
                                 <li class="list-group-item"><img src="http://image.tmdb.org/t/p/w45/<%# Eval("profile_path") %>>" alt="" /> 
                                     <a href="../SPerson/SPerson.aspx?id=<%# Eval("person_id") %>"><%# Eval("name") %></a>
                                     ...<%# Eval("department") %>
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

        <div class="row">
        <div class="col-md-12">
        <!--Add related movies images-->
         <div class="panel-group" id="accordian3" role="tablist">
        <div class="panel panel-default">
         <div class="panel-heading" role="tab" id="collapseListGroupHeading3">
             <a data-toggle="collapse" href="#collapseListGroup3" aria-expanded="true" aria-controls="collapseListGroup3">Additional Poster Images</a>
          </div>
            <div class="panel-body"> 
                <div id="collapseListGroup3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading2" aria-expanded="true">
                   <asp:Repeater ID="rptPosters" runat="server">
                       <ItemTemplate>
                         <div class="col-md-3 col-md-2">
                        <a href="#" class="thumbnail">
                             <img src="http://image.tmdb.org/t/p/w154/<%# Eval("file_path") %>>" alt="" />
                        </a>
                     </div>
                       </ItemTemplate>
                   </asp:Repeater>
                    
             </div>
         </div>

      </div>
   </div>

    <asp:Label ID="message" runat="server" />
</asp:Content>
