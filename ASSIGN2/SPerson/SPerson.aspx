<%@ Page Title="Actors | Actresses | Crews" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SPerson.aspx.cs" Inherits="SPerson" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .profilePic{ height: 450px;
                 width:  300px;
    }
</style>
    <div class="row">
        <asp:Repeater ID="rptPerson" runat="server">
            <ItemTemplate>
                <div class="col-xs-12 col-sm-12 col-md-12 spaceabove">
                    <div class="col-xs-5 col-sm-4 col-md-5">
                        <div class="row personImage">
                            <a href="#" data-toggle="modal" data-target="#myModal">
                            <figure class="img-responsive">
                            <img src="<%# Eval("ProfilePic") %>"  class="thumbnail"/>
                            </figure>
                            </a>
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="posterModal" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content personModal">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        </div>
                                        <img src="<%# Eval("ProfilePic") %>"  class="profilePic"/> 
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            
                    <div class="col-xs-12 col-sm-8 col-md-7 personPanel">
                        <div class="panel panel-default personInfoMobile">
                            <div class="panel-heading">
                                <%# Eval("Name") %> <br />
                                <asp:LinkButton runat="server" ID="addToFav" CssClass="btn btn-default"><span class="glyphicon glyphicon-heart"></span> Favorite</asp:LinkButton>
                            </div>
                            <div class="panel-body">
                                <%# Eval("Birthday") %><br />
                                <%# Eval("Deathday") %><br />
                                <%# Eval("Birthplace") %><br />
                            </div>
                        </div>
                    

                <%--Bio Section--%>
                  
                    <div class="panel panel-default bioClear">
                        <div class="panel-heading">Biography</div>
                        <div class="panel-body">
                            <%#Eval("Biography") %>
                        </div>
                    </div>
                    
                <%--Social Media Section--%>
                
                <div class="panel panel-default">
                    <div class="panel-heading">Social Media</div>
                    <div class="panel-body">
                        <a href="#"><img src="../images/fb.png" /></a>
                        <a href="#"><img src="../images/twit.png" /></a>
                        <a href="<%# Eval("HomePage") %>" ><img src="../images/home.png" /></a>
                    </div>
                </div>
                </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
     </div>           
     <%--End Right hand side--%>

    <%--Begin Crew and movie info--%>
    <div class="row">
       <div class="col-xs-12 col-md-12">
            <asp:Repeater ID="movieRepeater" runat="server">
                <HeaderTemplate>
                    <div class="panel panel-default panelResizing">
                        <div class="panel-heading">Movies</div>
                        <div class="panel-body">
                </HeaderTemplate>
                <ItemTemplate>
                    <p><a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieID") %>">Played as <%# Eval("RoleName") %> in <%# Eval("Title") %></a></p>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-12">
            <asp:Repeater ID="crewRepeater" runat="server">
                <HeaderTemplate>
                        <div class="panel panel-default panelResizing">
                            <div class="panel-heading">Department</div>
                            <div class="panel-body">
                </HeaderTemplate>
                <ItemTemplate>
                    <p><a href="../SMovie/SMovie.aspx?id=<%# Eval("MovieID") %>"> was  <%# Eval("Job") %> in the <%# Eval("Department ") %> department in <%# Eval("Title") %></a></p>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                    </div>
                </FooterTemplate>

            </asp:Repeater>
            </div>
        </div>
     <%--End Crew and movie info--%>
</asp:Content>
