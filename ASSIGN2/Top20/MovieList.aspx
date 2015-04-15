<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeFile="MovieList.aspx.cs" Inherits="MovieList"
    CodePage="65001" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 


<div class="row rowCol">
    <div class="col-md-12 col-xs-12 top20Panel spaceabove">
     
        <div class="panel panel-default">
            <div class="panel-heading"><asp:Label ID="lblTitle" runat="server"></asp:Label></div>
            <div class="panel-body">
                <asp:Label ID="notFound" runat="server" Visible="false" ></asp:Label> 
                <asp:Repeater ID="layout" runat="server">
                    <ItemTemplate>
                    <div class="row">
                        <div class="col-md-6 col-xs-6">
                            <figure>
                                <a href="https://www.themoviedb.org/movie/<%# Eval("MovieId") %>">
                                <img src="<%# Eval("PosterPath") %>"
                                        title="<%# Eval("Title")%> poster"
                                        alt="<%# Eval("Title") %> poster"
                                        class="thumbnail img-responsive" /></a>
                            </figure>
                        </div>
                        <div class="col-md-6 col-xs-12">
                            <div class="row">
                                <div class="col-md-10">
                                    <h3 id="titleMobileh3"><a href="https://www.themoviedb.org/movie/<%# Eval("MovieId") %>"><%# Eval("Title") %></a>
                                        (<%# Eval("ReleaseDate").ToString().Substring(0,4) %>)</h3>
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

</div>
<asp:Label ID="labMsg" runat="server" />    
</asp:Content>