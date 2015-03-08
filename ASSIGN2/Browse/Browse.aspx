<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <style>
        figure {
            padding: .5em;
        }
    </style> 
        <h2><%: Title %>.</h2>
        
        <div class="well well-lg">
            <h1>Browse the Movies</h1>
        </div>
        <div class="panel panel-default">
            <div class="panel-body">
                <asp:Repeater ID="layout" runat="server" DataSourceID="sqlMovieData">
                    <ItemTemplate> 
                        <div class="row">
                            <div class="col-md-2 col-md-offset-2">          
                                <figure>
                                    <img src="http://image.tmdb.org/t/p/w300<%# Eval("poster_path") %>"
                                            class="img-responsive img-rounded"
                                            alt="Poster for <%# Eval("title") %>"
                                            title="Poster for <%# Eval("title") %>" />
                                </figure>
                            </div>     
                            <div class="col-md-4">
                                <a href="../SMovie/SMovie.aspx?id=<%# Eval("movie_id")%>"><%# Eval("title") %></a>
                            </div>
                            <div class="col-md-2">
                                <h5>Released: <%# Eval("release_date") %></h5>
                            </div>
                            <div class="col-md-2">

                            </div>
                        </div>
                    </ItemTemplate>

                </asp:Repeater> 
            </div>                     
        </div>
        <asp:Label ID="labMsg" runat="server" />    

        <asp:SqlDataSource ID="sqlMovieData" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT [movie_id], [poster_path], [title],[release_date]
             FROM [movie]" >
    </asp:SqlDataSource>
</asp:Content>