<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
   <style>        
       figure {
            padding: 1em;
        }
        .thumbnail {
            margin-bottom: 0;
        }
        .panel-primary {background-color: gold;}
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
                            <a href="./SMovie/SMovie.aspx?id=<%# Eval("movie_id") %>">
                            <img src="http://image.tmdb.org/t/p/w300<%# Eval("poster_path") %>"
                                 title="<%# Eval("title")%> poster"
                                 alt="<%# Eval("title") %> poster"

                                 class="thumbnail img-responsive" /></a>
                        </figure>
                    </div>
                    <div class="col-md-6">
                        <h2><a href="./SMovie/SMovie.aspx?id=<%# Eval("movie_id") %>"><%# Eval("title") %></a>
                            (<%# Eval("release_date", "{0:yyyy}")%>)
                        </h2>
                        <div class="panel panel-primary col-md-6">
                            <div class="panel-heading">
                                <div class="panel-title">Directors</div>
                                <div class="panel-body">

                                </div>      
                            </div>
                        </div>
                        <div class="panel panel-primary col-md-6">
                            <div class="panel-heading">
                                <div class="panel-title">Lead Actors</div>
                                <div class="panel-body">

                                </div>      
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="well well-sm">
                            <h4>This movie has been classified as:</h4>
                               
                            <br />
                        </div>
                    </div>
                    <div class="col-md-3">

                    </div>
                </div>
            <hr />
            </ItemTemplate>

                </asp:Repeater> 
            </div>                     
        </div>
        <asp:Label ID="labMsg" runat="server" />    

        <asp:SqlDataSource ID="sqlMovieData" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT [movie_id], [poster_path], [title],[release_date]
             FROM [movie] order by release_date" >
    </asp:SqlDataSource>
</asp:Content>