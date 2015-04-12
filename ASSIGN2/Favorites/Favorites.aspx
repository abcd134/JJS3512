<%@ Page Title="Favorites" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeFile="Favorites.aspx.cs" Inherits="Favorites"
    CODEPAGE = 65001 
    %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 


<div class="row">
    <div class="col-md-8 col-md-offset-2">
        <div class="panel panel-info">
            <asp:Label ID="notFound" runat="server" Visible="false" ></asp:Label> 
            <asp:Repeater ID="favMovies" runat="server">
                <ItemTemplate>
                    <HeaderTemplate>
                        <div class="panel-title">Favourite Movies</div>
                    </HeaderTemplate>
                    <div class="panel-body">
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
                                <!-- Hard coded movie id for now -->
                                <asp:Button ID="remFromFav" runat="server" 
                                    OnCommand="remFromFav_Click" 
                                    Text ="Remove"
                                    CommandArgument='<%# Eval("MovieId") %>' >
                                </asp:Button>
                            </div>
                            <div class="col-md-10">
                                <div class="row">
                                    <div class="col-md-10">
                                        <h3><a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieId") %>"><%# Eval("Title") %></a></h3>
                                    </div>
                                    <div class="col-md-2">
                                        <h3><%# Eval("Year") %></h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                    </div>
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
                <ItemTemplate>
                    <HeaderTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">Favourite People</div>
                    </HeaderTemplate>
                            <div class="row">
                                <div class="col-md-2">
                                    <figure>
                                        <!-- insert PersonId to query string to SMovie -->
                                        <a href="../SPerson/SPerson.aspx?id=">Image Goes here</a>
                                    </figure>
                                    <!-- Hard coded person id for now -->
                                    <asp:Button ID="remFromFav" runat="server" 
                                        OnCommand="remFromFav_Click" 
                                        Text ="Remove"
                                        CommandArgument='917' >
                                    </asp:Button>
                                </div>
                                <div class="col-md-10">
                                    <!--insert id=PersonId Eval  and put in a real name -->
                                    <h3><a href="../SPerson/SPerson.aspx?id=">Blah blah blah</a></h3>
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