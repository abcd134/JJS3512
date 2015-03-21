<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
   
<h2><%: Title %>.</h2>   
<div class="row">
    <div class="col-md-10">
        <div class="well well-lg">
            <h1>Browse the Movies</h1>
            <asp:Label ID="lblGenre" runat="server" 
                Visible="false"/>
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
                                        (<%# Eval("release_date", "{0: YYYY}")%>)</h3>
                                    <asp:Label ID="tagLine" runat="server"
                                        Visible = '<%# Eval("tagline").ToString() != "" %>' >
                                        <h5>"<%# Eval("tagline") %>"</h5>
                                    </asp:Label>
                                    </div>
                                <div class="col-md-1">
                                    <h1><%# Eval("vote_average") %>/10  </h1>
                                </div>
                            </div>
                            <div class="panel panel-info row">
                                <div class="panel-heading">
                                    <div class="panel-title"><a href="../SPerson/SPerson.aspx?id=<%# Eval("pid") %>">
                                            <%# Eval("name") %></a></div>
                                    <div class="panel-body">
                                        <h5>Stars as <%# Eval("role_name")%></h5>
                                    </div> 
                                </div>
                            </div>
                            <div class="panel panel-info row">
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
    </div>
    <div class="col-md-2">        
        <!-- Alternate list box -->
        <asp:Repeater ID="drpGenres" runat="server" >
            <HeaderTemplate>
                <div class="panel panel-default fixed" >
                    <div class="panel-heading">Select Genre<br /></div>
                    <div class ="panel-body">
            </HeaderTemplate>
            <%--ItemTemplate controls the content--%>
            <ItemTemplate>
                <p>
                <a href="../Browse/Browse.aspx?genre=<%# Eval("genre_id") %>&genreType=<%# Eval("genreName") %>&search=<%# Master.SearchBx %>"><%# Eval("genreName") %></a>
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