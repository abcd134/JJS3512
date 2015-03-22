<%@ Page Title="Single Person" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SPerson.aspx.cs" Inherits="SPerson" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12 rowCol">
            <div class="col-md-5">
                <asp:Repeater ID="imageRepeater" runat="server">
                <ItemTemplate>
                    <div class="row personImage">
                        <img src="http://image.tmdb.org/t/p/w300/<%#Eval("profile_path")%>"
                            title="<%# Eval("name") %> "
                            alt="<%# Eval("name") %>"
                            class="thumbnail img-responsive" />
                    </div>
                    <div class="row">
                        <div class="col-md-8 personBorn">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <p><b><%# Eval("birth_place") %></b></p>
                            </div>
                        </div>
                    </div>
                        </div>
                </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="col-md-7 personPanel">
                <asp:Repeater ID="BioRepeater" runat="server">
                    <ItemTemplate>
                     
                        <div class="panel panel-default">
                            <div class="panel-heading"><%# Eval("name") %></div>
                            <div class="panel-body">
                                <p><b>Birthdate: </b> <%#Eval("birthday") %></p>
                            </div>
                        </div>
                    

                    <%--Bio Section--%>
                   
                        <div class="panel panel-default">
                            <div class="panel-heading">Biography</div>
                            <div class="panel-body">
                                <%#Eval("biography") %>
                            </div>
                        </div>
                    
                    <%--Social Media Section--%>
                    
                       <div class="panel panel-default">
                            <div class="panel-heading">Social Media</div>
                            <div class="panel-body">
                                Facebook,  Twitter,  Website,   email
                            </div>
                        </div>
                    
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Repeater ID="movieRepeater" runat="server">
            <HeaderTemplate>
                
                    <div class="panel panel-default panelResizing">
                        <div class="panel-heading">Movies</div>
                        <div class="panel-body">
            </HeaderTemplate>
            <ItemTemplate>
                <p><a href="../SMovie/SMovie.aspx?id=<%# Eval("movie_id") %>">Played as <%# Eval("role_name") %> in <%# Eval("title") %></a></p>
            </ItemTemplate>
            <FooterTemplate>
                        </div>
                    </div>
            </FooterTemplate>
        </asp:Repeater>

         <asp:Repeater ID="CrewRepeater" runat="server">
            <HeaderTemplate>
                <div class="row">
                    <div class="panel panel-default panelResizing">
                        <div class="panel-heading">Department</div>
                        <div class="panel-body">
            </HeaderTemplate>
            <ItemTemplate>
                <p><a href="../SMovie/SMovie.aspx?id=<%# Eval("movie_id") %>">Crew as <%# Eval("job") %> in <%# Eval("title") %>></a></p>
            </ItemTemplate>
            <FooterTemplate>
                        </div>
                    </div>
                </div>
            </FooterTemplate>

        </asp:Repeater>
        </div>
    </div>
</asp:Content>
