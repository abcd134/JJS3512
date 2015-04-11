<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse"
    CODEPAGE = 65001 
    %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 


<div class="row rowCol">
    <div class="col-md-9 browsePanel">
        <div class="well well-lg">
            <h1>Browse the Movies</h1>
            <asp:Label ID="lblGenre" runat="server" 
                Visible="false" CssClass="font"/>
            <asp:Button ID="removeFilter" runat="server"
                CssClass ="button" 
                Text ="Clear Filter"
                Visible ="false"
                CausesValidation ="false"
                OnCommand="on_Click" />    
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <asp:Label ID="notFound" runat="server" Visible="false" ></asp:Label> 
                <asp:Repeater ID="layout" runat="server">
                    <ItemTemplate>
                    <div class="row">
                        <div class="col-md-2">
                            <figure>
                                <a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieId") %>">
                                <img src="http://image.tmdb.org/t/p/w300<%# Eval("PosterPath") %>"
                                        title="<%# Eval("Title")%> poster"
                                        alt="<%# Eval("Title") %> poster"
                                        class="thumbnail img-responsive" /></a>
                            </figure>
<%--                            <figure>
                                <img src="http://image.tmdb.org/t/p/w300<%# Eval("BackDropPath") %>"
                                        title="<%# Eval("Title")%> backdrop"
                                        alt="<%# Eval("Title") %> backdrop"
                                        class="thumbnail img-responsive" /></a>
                            </figure>--%>
                            <button type="button" class="btn btn-default" runat="server" ID="addToFav">
                                <span class="glyphicon glyphicon-heart" aria-hidden="true"></span>  Favorite
                            </button>

                        </div>
                        <div class="col-md-10">
                            <div class="row">
                                <div class="col-md-10">
                                    <h3><a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieId") %>"><%# Eval("Title") %></a>
                                        (<%# Eval("ReleaseDate").ToString().Substring(0,4) %>)</h3>
                                    <asp:Label ID="tagLine" runat="server"
                                        Visible = '<%# Eval("Tagline").ToString() != "" %>' >
                                        <h5>"<%# Eval("Tagline") %>"</h5>
                                    </asp:Label>
                                    </div>
                                <div class="col-md-2">
                                    <h1><%# Eval("Average") %>/10  </h1>
                                </div>
                            </div>
                            <div class="panel panel-info row">
                                <div class="panel-heading">
                                    <div class="panel-title"><b><a href="../SPerson/SPerson.aspx?id=<%# Eval("PersonID") %>">
                                            <%# Eval("Name") %></a></b> stars as <%# Eval("RoleName")%></div>
                                </div>
                            </div>
                            <div class="panel panel-info row">
                                <div class="panel-heading">
                                    <div class="panel-title">Overview</div>
                                    <div class="panel-body">
                                        <p><%# Eval("Overview")%></p>
                                    </div>      
                                </div>
                            </div>
                        </div>
                    </div>
                <hr />
                </ItemTemplate>
                </asp:Repeater> 
            </div>                     
        </div>
    </div>
    <div class="col-md-2">        
        <!-- Alternate list box -->
        <asp:Repeater ID="drpGenres" runat="server" >
            <HeaderTemplate>
                <div class="panel panel-default fixed" >
                    <div class="panel-heading">Select Genre<br /></div>
                    <div class ="panel-body  fixedPanel">
            </HeaderTemplate>
            <%--ItemTemplate controls the content--%>
            <ItemTemplate>
                <p>
                <a href="../Browse/Browse.aspx?genre=<%# Eval("GenreID") %>&genreType=<%# Eval("GenreName") %>&search=<%# Master.SearchBx %>&SearchType=<%# Master.SearchKind %>"><%# Eval("GenreName") %></a>
                </p>
            </ItemTemplate>
            <FooterTemplate>
                    </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</div>
<asp:Label ID="labMsg" runat="server" />    
</asp:Content>