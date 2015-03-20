<%@ Page Title="Single Movie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SMovie.aspx.cs" Inherits="SMovie" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>.</h2>
    <%--This is start of the first main row--%>
    <div class="row">
        <div class="col-md-12">
            <%--Give the poster image a col-md of 5--%>
            <div class="col-md-5">
                <figure>
                    <%--This Image is pulled from the code-behind--%>
                    <asp:Image runat="server" ID="imgPoster" class="thumbnail" />
                </figure>
                <%--This is the start of box office content--%>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">Box Office</div>
                        <div class="panel-body">
                            <p><b>Budget:</b>
                                <%--This label data is being pulled from the code-behind--%>
                                <asp:Label ID="txtBudget" runat="server" /></p>
                            <p><b>Revenue:</b>
                                <%--This label data is being pulled from the code-behind--%>
                                <asp:Label ID="txtRevenue" runat="server" /></p>
                        </div>
                    </div>
                </div>
                <%--This is the start of the vote content--%>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">Votes</div>
                        <div class="panel-body">
                            <p><b>Vote Average:</b>
                                <%--This label data is being pulled from the code-behind--%>
                                <asp:Label ID="txtAverage" runat="server" /></p>
                            <p><b>Vote Count:</b>
                                <%--This label data is being pulled from the code-behind--%>
                                <asp:Label ID="txtVoteCount" runat="server" /></p>
                        </div>
                    </div>
                </div>
            </div>

            <%--Start Movie Information--%>
            <div class="col-md-7 rowCol">
                <%--This is the important information for a movie--%>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <%--The title and release date lable is being pulled in from the code-behind--%>
                        <asp:Label ID="txtTitle" runat="server" />
                        (<asp:Label ID="txtReleaseDate" runat="server" />)</div>
                    <div class="panel-body">
                        <p><b>Run Time:</b>
                            <%--This lable data is being pulled in from the code-behind--%>
                            <asp:Label ID="txtRunTime" runat="server" /></p>
                        <p>
                            <b>Genre:</b> |
                            <%--This is the start of the genre repeater--%>
                        <asp:Repeater ID="rptGenre" runat="server">
                            <ItemTemplate><%# Eval("name") %> | </ItemTemplate>
                        </asp:Repeater>
                        </p>
                        <p>
                            <b>Companies:</b> |
                            <%--This is the start of the companies repeater--%>
                        <asp:Repeater ID="rptCompany" runat="server">
                            <ItemTemplate><%# Eval("company_name") %> | </ItemTemplate>
                        </asp:Repeater>
                        </p>
                        <%--This IMDB label is being pulled from the code-behind--%>
                        <p><b>IMDB:</b> <a id="linkIMDB" runat="server">
                            <asp:Label ID="txtIMDB" runat="server" /></a></p>
                    </div>
                </div>
                <%--This is the movie overview--%>
                <div class="panel panel-default">
                    <div class="panel-heading">Overview</div>
                    <div class="panel-body">
                        <%--This label data is being pulled from the code-behind--%>
                        <p><asp:Label ID="txtOverview" runat="server" /></p>
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
                <asp:Repeater ID="rptKeyword" runat="server">
                    <%--HeaderTemplate controls the panel heading--%>
                    <HeaderTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">Key Words</div>
                            <div class="panel-body"> |
                    </HeaderTemplate>
                    <%--The ItemTemplate controls the content--%>
                    <ItemTemplate> <%# Eval("name") %> |</ItemTemplate>
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
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">Backdrops</div>
                <div class="panel-body">
                    <div class="display">
                        <asp:Repeater ID="rptBackDrop" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3">
                                    <a href="<%# Eval("movie_image_id") %>" class="thumbnail" data-toggle="modal" data-target=".bs-example-modal-lg">
                                        <img src="http://image.tmdb.org/t/p/w300/<%# Eval("file_path") %>" alt="" />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%--<div class="modal bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                             <div class="modal-content">
                                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button> <br />  
                                  <img src="http://image.tmdb.org/t/p/w780/<%# Eval("file_path") %>" alt="" />
                             </div>
                        </div>
                 </div>--%>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="panel-group" id="accordian" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="collapseListGroupHeading1">
                        <a data-toggle="collapse" href="#collapseListGroup1" aria-expanded="true" aria-controls="collapseListGroup1">Cast</a>
                    </div>
                    <div class="panel-body">
                        <div id="collapseListGroup1" class="panel-collapse collapse.in" role="tabpanel" aria-labelledby="collapseListGroupHeading1" aria-expanded="true">
                            <asp:Repeater ID="rptCast" runat="server">
                                <ItemTemplate>
                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <img src="<%# checkIMG(Eval("pathcast")) %>" width="45px" alt="<%# Eval("name") %>" title="<%# Eval("name") %>" />
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
                        <div id="collapseListGroup2" class="panel-collapse collapse.in" role="tabpanel" aria-labelledby="collapseListGroupHeading2" aria-expanded="true">
                            <asp:Repeater ID="rptCrew" runat="server">
                                <ItemTemplate>
                                    <ul class="list-group">
                                        <li class="list-group-item">
                                            <img src="<%# checkIMG(Eval("path")) %>" width="45px" alt="<%# Eval("name") %>" title="<%# Eval("name") %>" />
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
            <div class="panel-group" id="accordian3" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="collapseListGroupHeading3">
                        <a data-toggle="collapse" href="#collapseListGroup3" aria-expanded="true" aria-controls="collapseListGroup3">Additional Poster Images</a>
                    </div>
                    <div class="panel-body">
                        <div id="collapseListGroup3" class="panel-collapse collapse" role="tabpanel" aria-labelledby="collapseListGroupHeading2" aria-expanded="true">
                            <div class="display">
                                <asp:Repeater ID="rptPosters" runat="server">
                                    <ItemTemplate>
                                        <div class="col-md-3">
                                            <a href="#" class="thumbnail">
                                                <img src="http://image.tmdb.org/t/p/w154/<%# Eval("file_path") %>" alt="" />
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Label ID="message" runat="server" />
</asp:Content>
