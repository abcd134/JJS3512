<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

        <h3 class="center">Your Complete Movie Information Source</h3>
    <div class ="row">
        <div class="col-md-3">
            <img src="/images/naxos.jpg" width="200"/>
        </div>
        <div class="col-md-9">
            <p>This site was designed by James, Joseph and Sonia 
            as part of the requirements for the Mount Royal University 
            Bachelor of Computer Information Systems degree.  The project
            will be submitted to Professor Randy Connolly in partial
            fulfilment of the requirements for Comp 3512, Web II.</p>

            <p>This page is divided into three main sections.  The first being
            a brief bio of each of the developers.  The second section will be
            a summary of the development efforts of the members, choices and 
            finally the challenges we solved / decided to leave alone.  A more
            detailed documentation of the above will be contained in separately
            linked web pages.  The final section will contain the list of
            citations that reflect ideas/efforts of other people/organizations
            that we chose to either emulate, access or were just plain inspired
            by </p>

            <p>The site is a developmental web site that contains
            six working web pages plus six documentation pages (one for each 
            web page).  In the documentation pages, choices / issues related
            to the page will be discussed in detail.  The documentation pages
            can be reached by clicking the links below (for now all the information
            is contained on just on this one page. Each of these pages will be 
            discussed in detail, highlighting problems, choices and developmental
            efforts of each of the team members.
            </p>
          </div> 
       </div>
        <div class="row">
            <div class="col-md-3">
                <p>Home Page Initial Design Concept</p>
                <img src="/images/homePage.jpg" width="200"/>
            </div>
            <div class ="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">The Movie Web Site Documentation Pages</div>
                <div class="panel-body">
                <ul class="list-group">
                    <li class="list-group-item"><a href="#">home page</a></li>
                    <li class="list-group-item"><a href="#">browse movies</a></li>
                    <li class="list-group-item"><a href="#">Detailed info on one movie</a></li>
                    <li class="list-group-item"><a href="#">Detailed info on one person</a></li>
                    <li class="list-group-item"><a href="#">This about us page, and</a></li>
                    <li class="list-group-item"><a href="#">An error page</a></li>
                </ul>
                </div>
             </div>
                </div>
            <div class="col-md-3">
                <p>About Page Initial Design Concept</p>
                <img src="/images/about.jpg" width="200"/>
            </div>
            </div>
</asp:Content>