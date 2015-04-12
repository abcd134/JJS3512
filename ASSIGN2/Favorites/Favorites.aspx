<%@ Page Title="Favorites" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeFile="Favorites.aspx.cs" Inherits="Favorites"
    CODEPAGE = 65001 
    %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 


<div class="row">
    <div class="col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <asp:Label ID="notFound" runat="server" Visible="false"></asp:Label> 
            <asp:Repeater ID="favMovies" runat="server">
                <HeaderTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">Favourite Movies</div>
                </HeaderTemplate>
                <ItemTemplate>
                        <div class="row">
                            <div class="col-md-2">
                                <figure>
                                    <!-- insert MovieId to query string to SMovie -->
                                    <a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieId") %>">
                                        <img src="http://image.tmdb.org/t/p/w300<%# Eval("PosterPath") %>"
                                                title="<%# Eval("Title")%> poster"
                                                alt="<%# Eval("Title") %> poster"
                                                class="thumbnail img-responsive" /></a>
                                </figure>
                                <asp:Button ID="remFromMovieFav" runat="server" 
                                    OnCommand="remFromMovieFav_Click" 
                                    Text ="Remove"
                                    CommandArgument='<%# Eval("MovieId") %>' >
                                </asp:Button>
                            </div>
                            <div class="col-md-8">
                                <h3><a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieId") %>"><%# Eval("Title") %></a></h3>
                            </div>
                            <div class="col-md-2">
                                <h3><%# Eval("Year") %></h3>
                            </div>
                        </div>
                    </div>
                    <hr />
                </ItemTemplate>
            </asp:Repeater>
        </div> 
    </div>                     
</div>

<!-- Favorite People Repeater Section -->
<div class="row">
    <div class="col-md-8 col-md-offset-2">
        <div class="panel panel-default">
            <asp:Label ID="noPeople" runat="server" Visible="false" ></asp:Label> 
            <asp:Repeater ID="people" runat="server">
                <HeaderTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading">Favourite People</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-2">
                            <figure>
                                <!-- insert PersonId to query string to SMovie -->
                                <a href="../SPerson/SPerson.aspx?id=<%# Eval("PersonID") %>">
                                    <img src="<%# Eval("ProfilePic") %>"
                                                title="<%# Eval("Name")%> picture"
                                                alt="<%# Eval("Name") %> picture"
                                                class="thumbnail img-responsive" /></a>
                            </figure>
                            <asp:Button ID="remFromPeopleFav" runat="server" 
                                OnCommand="remFromPeopleFav_Click" 
                                Text ="Remove"
                                CommandArgument='<%# Eval("PersonID") %>' >
                            </asp:Button>
                        </div>
                        <div class="col-md-10">
                            <h3><a href="../SPerson/SPerson.aspx?id=<%# Eval("PersonID") %>"><%# Eval("Name") %></a></h3>
                        </div>
                    </div>
                </div>
                <hr />
                </ItemTemplate>
            </asp:Repeater>  
        </div> 
   </div>                       
</div>
<asp:Label ID="labMsg" runat="server" />    
</asp:Content>