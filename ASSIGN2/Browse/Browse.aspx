<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
   <style>        
       figure {
            padding: 1em;
        }
        .thumbnail {
            margin-bottom: 0;
        }
        .panel-info {background-color: gold;}
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
                    <div class="col-md-2">
                        <figure>
                            <a href="../SMovie/SMovie.aspx?id=<%# Eval("id") %>">
                            <img src="http://image.tmdb.org/t/p/w300<%# Eval("poster_path") %>"
                                 title="<%# Eval("title")%> poster"
                                 alt="<%# Eval("title") %> poster"
                                 class="thumbnail img-responsive" /></a>
                        </figure>
                        <figure>
                            <img src="http://image.tmdb.org/t/p/w300<%# Eval("backdrop_path") %>"
                                 title="<%# Eval("title")%> backdrop"
                                 alt="<%# Eval("title") %> backdrop"
                                 class="thumbnail img-responsive" /></a>
                        </figure>
                    </div>
                    <div class="col-md-10">
                        <div class="row">
                            <div class="col-md-10">
                                <h3><a href="../SMovie/SMovie.aspx?id=<%# Eval("id") %>"><%# Eval("title") %></a>
                                    (<%# Eval("release_date", "{0:yyyy}")%>)</h3>
                                <h5>"<%# Eval("tagline")%>"</h5>
                             </div>
                            <div class="col-md-1">
                                <h1><%# Eval("vote_average") %>/10  </h1>
                            </div>
                        </div>
                        <div class="panel panel-info col-md-3">
                            <div class="panel-heading">
                                <div class="panel-title"><a href="../SPerson/SPerson.aspx?pid=<%# Eval("pid") %>">
                                        <%# Eval("name") %></a></div>
                                <div class="panel-body">
                                    <h5>Stars as <%# Eval("role_name")%></h5>
                                </div>      
                            </div>
                        </div>
                        <div class="panel panel-info col-md-9">
                            <div class="panel-heading">
                                <div class="panel-title">Overview</div>
                                <div class="panel-body">
                                    <p><%# Eval("overview")%></p>
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
        <asp:Label ID="labMsg" runat="server" />    

        <asp:SqlDataSource ID="sqlMovieData" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
        SelectCommand="SELECT [movie.movie_id] as id, [person.person_id] as pid, [poster_path], [title],
                              [release_date],[name],[role_name],[overview],[tagline],
                              [vote_average],[backdrop_path]
             FROM movie, movie_cast, person
            WHERE  movie_cast.movie_id = movie.movie_id AND
                   movie_cast.person_id = person.person_id AND
                   movie_cast.ordering = 0
            ORDER BY release_date DESC" >
    </asp:SqlDataSource>
</asp:Content>