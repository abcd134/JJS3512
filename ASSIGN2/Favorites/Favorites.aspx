<%@ Page Title="Favorites" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeFile="Favorites.aspx.cs" Inherits="Favorites"
    CODEPAGE = 65001 
    %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 

<div class="row">
    <div class="col-md-8 col-xs-12 col-md-offset-2">
        <div class="panel panel-default panelMobileFav">
            <div class="panel-heading">Favorite Movies</div>
            <div class="panel-body">
                <asp:Label ID="notFound" runat="server" Visible="false"></asp:Label>
                <asp:Repeater ID="favMovies" runat="server">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-3 col-xs-5">
                                <figure>
                                    <!-- insert MovieId to query string to SMovie -->
                                    <a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieId") %>">
                                        <img src="http://image.tmdb.org/t/p/w300<%# Eval("PosterPath") %>"
                                                title="<%# Eval("Title")%> poster"
                                                alt="<%# Eval("Title") %> poster"
                                                class="thumbnail img-responsive" /></a>
                                </figure>
                                <asp:LinkButton ID="remFromMovieFav" runat="server" 
                                    OnCommand="remFromMovieFav_Click" 
                                    Text ="Remove" CssClass="btn btn-default btnResize"
                                    CommandArgument='<%# Eval("MovieId") %>' ><span class="glyphicon glyphicon-remove"></span>  Remove
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-8 col-xs-6">
                                <h3><a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieId") %>"><%# Eval("Title") %></a></h3>
                            </div>
                            <div class="col-md-2 col-xs-3">
                                <h3><%# Eval("Year") %></h3>
                            </div>
                        </div>
                        <hr />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>

<%--Starting of favorite people row--%>
<div class="row">
    <div class="col-md-8 col-xs-12 col-md-offset-2">
        <div class="panel panel-default panelMobileFav">
            <div class="panel-heading">Favorite People</div>
            <div class="panel-body">
                <asp:Label ID="noPeople" runat="server" Visible="false" ></asp:Label>
                <asp:Repeater ID="people" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-xs-5 col-md-3">
                            <figure>
                                <!-- insert PersonId to query string to SMovie -->
                                <a href="../SPerson/SPerson.aspx?id=<%# Eval("PersonID") %>">
                                    <img src="<%# Eval("ProfilePic") %>"
                                                title="<%# Eval("Name")%> picture"
                                                alt="<%# Eval("Name") %> picture"
                                                class="thumbnail img-responsive" /></a>
                            </figure>
                            <asp:LinkButton ID="remFromPeopleFav" runat="server" 
                                OnCommand="remFromPeopleFav_Click" 
                                Text ="Remove" CssClass="btn btn-default btnResize"
                                CommandArgument='<%# Eval("PersonID") %>' ><span class="glyphicon glyphicon-remove"></span>  Remove
                            </asp:LinkButton>
                        </div>
                        <div class="col-xs-7 col-md-7">
                            <h3><a href="../SPerson/SPerson.aspx?id=<%# Eval("PersonID") %>"><%# Eval("Name") %></a></h3>
                        </div>
                    </div>
                <hr />
                </ItemTemplate>
            </asp:Repeater>  
            </div>
        </div>
    </div>
</div>

<asp:Label ID="labMsg" runat="server" />    
</asp:Content>