<%@ Page Title="Actors | Actresses | Crews" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SPerson.aspx.cs" Inherits="SPerson" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12 spaceabove">
            <div class="col-md-5">
                <div class="row personImage">
                    <a href="#" data-toggle="modal" data-target="#myModal">
                    <asp:Image class="thumbnail" ID="imgProfilePic" runat="server" ImageUrl="~/images/Not_available.jpg" />
                    </a>
               <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="posterModal" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content personModal">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            </div>
                            <asp:Image ID="imgProfilePic2" runat="server" ImageUrl="~/images/Not_available.jpg" /> 
                        </div>
                    </div>
                </div>

                </div>
            </div>

            <div class="col-md-7 personPanel">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="lblPersonName" runat="server" Text="Label"></asp:Label>

                    </div>
                    <div class="panel-body">
                        <asp:Label ID="lblBirthPlace" runat="server" ></asp:Label><br />
                        <asp:Label ID="lblBirthdate" runat="server" ></asp:Label><br />
                        <asp:Label ID="lblDeathdate" runat="server" ></asp:Label><br />
                    </div>
                </div>


                <%--Bio Section--%>
                <asp:Repeater ID="BioRepeater" runat="server">
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">Biography</div>
                            <div class="panel-body">
                                <%#Eval("biography") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                

                <%--Social Media Section--%>

                <div class="panel panel-default">
                    <div class="panel-heading">Social Media</div>
                    <div class="panel-body">
                        <a href="#"><img src="../images/fb.png" /></a>
                        <a href="#"><img src="../images/twit.png" /></a>
                        <asp:HyperLink ID="HyperLink1" NavigateUrl="#" ImageUrl="~/images/home.png" runat="server"></asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
        <%--End Right hand side--%>
    </div>
    <div class="row">
       
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
            </div>
        <div class="row">

            <asp:Repeater ID="CrewRepeater" runat="server">
                <HeaderTemplate>
                    <div class="row">
                        <div class="panel panel-default panelResizing">
                            <div class="panel-heading">Department</div>
                            <div class="panel-body">
                </HeaderTemplate>
                <ItemTemplate>
                    <p><a href="../SMovie/SMovie.aspx?id=<%# Eval("movie_id") %>">Crew as <%# Eval("job") %> in <%# Eval("title") %></a></p>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                    </div>
                </div>
                </FooterTemplate>

            </asp:Repeater>
        </div>

</asp:Content>
