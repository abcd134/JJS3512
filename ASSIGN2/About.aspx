<%@ Page Title="About" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeFile="About.aspx.cs" 
    Inherits="About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .img-circle {
        float: left;
        margin-right: 1em;
    }
    p {text-indent: 2em;}
    .firstWord {font: bold;
                font-style:italic;
                font-size:larger;
                color:blueviolet;
    }
    .well {background-color:gold;}
    .innerWell {
        background-color: lightgoldenrodyellow;
    }
    .pageImg {
        padding: .5em;
    }
    .documentation {
        padding-right: 4em;
    }
    .panel-heading{font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
                    font-size:large;
    }
    .title {font-size:small;}
    figcaption {text-align:center;}
</style>
<h2><%: Title %>.</h2>

<h3 class="center">Your Complete Movie Information Source</h3>
<div class ="row">
        <div class="col-md-3">
            <figure>
                <img src="/images/naxos.jpg" width="200"
                    class="img-responsive img-rounded" 
                    title="Thinking of Greece - Naxos"
                    alt="Naxos,Greece"/>
            </figure>
        </div>
        <div class="col-md-9">
            <p>This site was designed by <A href="#joseph">Joseph</A>, <A href="#james">James</A> and <A href="#sonia" >Sonia</A>
            as part of the requirements for the Mount Royal University,
            Bachelor of Computer Information Systems degree program.  The project
            was submitted to Professor Randy Connolly in partial
            fulfilment of the requirements for Comp 3512, Web II.</p>

            <p>This page is divided into five main sections.  This introduction,
            followed by a brief bio of each of the developers.  The third section is
            a summary of the development efforts of each of the members.  The fourth 
            section involves a more detailed documentation of each of the web pages.
            The final section contains the <A href="#citations">list of citations</A> that reflect ideas/efforts
            of other people/organizations that we chose to either emulate, access or
            were just plain inspired by.</p>

            <div class="row well">
                <div class="col-md-10 col-md-offset-1 innerWell">
                    <h3 id="joseph">Joseph Balabat</h3>
                        <figure>
                            <img src="/images/joseph.jpg" 
                                 alt="Joseph Balabat"
                                 title="Joseph Balabat - The Cat"
                                 class="img-circle" 
                                 width="175" />
                        </figure>
                        <p><span class="firstWord">Joseph</span>, worked tirelessly to not only help design and implement
                            the web page, his joie de vivre inspired the team.  A key member
                            of the team who took every opportunity to lead the team and to
                            ensure that it's members understood and were on board with design
                            and implementation initiatives.  A teacher at heart.  Joseph took care
                            of the implementation details for the site master.  He pushed us to 
                            learn and use GitHub.  He took the lead in establishing the
                            database connections.  Joseph suggested and implemented a change
                            log system that helped the communications process amongst members.
                            Joseph took the lead on the home page.  We can thank Joseph for cats 
                            making their way onto this website.
                        </p>
                </div>
                <br />
                <div class="col-md-10 col-md-offset-1 innerWell">
                    <h3 id="james">James Bergeron</h3>
                        <figure>
                            <img src="/images/james.jpg" 
                                 alt="James Bergeron"
                                 title="James Bergeron - The Cat"
                                 class="img-circle" 
                                 width="175" />
                        </figure>
                        <p><span class="firstWord">James</span>, the cat in the middle, was 
                            nurtured and protected by both Joseph and Sonia.  James was a 
                            pain in the ... when it came to organizational and documentation
                            details.  Other members were heard to say, "NO MATH" and something
                            about "KISS" (probably a rock band reference) to help guide his
                            programming style.  The other members immediately recognized his
                            ability to design, use colors and throw cords.  He was instrumental
                            in the design phase, the documentation phase, and took care of the
                            implementation details for the about us page and the browse page.
                            Heard to complain about his role, he was asked to do the browse page.
                            We could go on about how great he was, but someone might suspect
                            who was actually authoring this piece.
                        </p>
                </div>
                                <br />
                <div class="col-md-10 col-md-offset-1 innerWell">
                    <h3 id="sonia">Sonia Pitrola</h3>
                        <figure>
                            <img src="/images/sonia.jpg" 
                                 alt="Sonia Pitrola"
                                 title="Sonia Pitrola- The Cat"
                                 class="img-circle" 
                                 width="175" />
                        </figure>
                        <p><span class="firstWord">Sonia</span>, tireless, design focussed,
                            led the development effort on the single movie page.  In addition
                            Sonia developed and provided to tema members clear, concise instructions
                            for cloning and using the GiHub repository for sharing information,.
                            Sonia also created and managed the Google Drive repository for
                            sharing informatio.  She was instrumental in design decisions to 
                            establish the initial layout as well as the  being the lead in
                            the establishment of the look and feel of the site.  Sonia's good
                            nature and drive for success was a key component in ensuring cohesion
                            between the team members.  She will wear a skirt to school if we get
                            an "A"......  ooops the write thinking out loud again. 
                        </p>
                </div>
          </div> 
    </div>
    <div class="row">
        <div class="col-md-3">
            <br /><br />
            <figure>
                <figcaption>Initial Design of Browse Page</figcaption>          
                <img src="/images/browse.jpg"
                     class="img-responsive" 
                     alt="Initial Design of Browse Page"
                     title="Initial Design of Browse Page"/>
            </figure>
        </div>
        <div class ="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">The Movie Web Site Documentation Pages</div>
                <div class="panel-body">
                    <ul class="list-group">
                        <li class="list-group-item"><a href="#homePage">Home Page</a></li>
                        <li class="list-group-item"><a href="#browse">Browse Movies</a></li>
                        <li class="list-group-item"><a href="#sMovie">Detailed info on one movie</a></li>
                        <li class="list-group-item"><a href="#sPerson">Detailed info on one person</a></li>
                        <li class="list-group-item"><a href="#about">This about us page, and</a></li>
                        <li class="list-group-item"><a href="#error">An error page</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <br /><br />
            <figure>
                <figcaption>Initial Design of Single Movie</figcaption>
                <img src="/images/sMovie.jpg"
                     title="Initial Design of Single Movie" 
                     alt="Initial Design of Single Movie"
                     class="img-responsive"/>
            </figure>
        </div>
        </div>
    <div class="panel panel-info">
        <div class="panel-heading" id="citations">Citations</div>
        <div class="panel-body">
            <ul class="list-group">
                <li class="list-group-item"><a href="http://www.sochealth.co.uk/2013/08/09/my-favourite-kitten-pictures-for-internationalcatday/">
                    Image of Joseph from the Socialist Health Association</a></li>
                <li class="list-group-item"><a href="http://nyc_dog_blog.downtownpet.com/2007/08/cats-and-ducks.html">
                    Image of Sonia from The NY City Downtown Pets</a></li>
                <li class="list-group-item"><a href="http://www.inlander.com/imager/b/blog/2201738/bdd7/beabetterfriend.jpg?cb=1383547907">
                    Image of James from The Inlander</a></li>
                <li class="list-group-item">Will Fowler for GitHub Guidance</li>
                <li class="list-group-item"><a href="www.tmdb.com">The Movie Database (TMDb)</a></li>
            </ul>
        </div>
    </div>
</div>
<div class="row">
    <div class="panel panel-info">
        <div class="panel-heading">Team Development Efforts</div>
        <div class="panel-body">
            <div class="panel panel-primary">
                <div class="panel-heading" id="homePage">The Home Page<br />
                    <div class="title">Lead Developer: Joseph Balabat</div>
                </div>
                <div class="row">
                    <div class="col-md-4 ">
                        <img src="/images/homePage.jpg" 
                            class="img-responsive pageImg"
                            alt="Initital Design of Home Page"
                            title="Initital Design of Home Page"/>
                    </div>
                    <div class="col-md-8 documentation">
                    <br />
                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-primary">
                <div class="panel-heading" id="browse">The Browse Page<br />
                    <div class="title">Lead Developer: James Bergeron</div>
                </div>
                <div class="row">
                    <div class="col-md-4 ">
                        <img src="/images/browse.jpg" 
                             class="img-responsive pageImg"
                             alt="Initital Design of the Browse Page"
                             title="Initital Design of the Browse Page"
                        />
                    </div>
                    <div class="col-md-8 documentation">

                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-primary">
                <div class="panel-heading" id="sMovie">The Single Movie Page<br />
                    <div class="title">Lead Developer: Sonia Pitrola</div>
                </div>
                <div class="row">
                    <div class="col-md-4 ">
                        <img src="/images/sMovie.jpg" 
                                class="img-responsive pageImg"
                                alt="Initital Design of About Page"
                                title="Initital Design of About Page"
                            />
                    </div>
                    <div class="col-md-8 documentation">

                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-primary">
                <div class="panel-heading" id="sPerson">The Single Person Page</div>
                <div class="row">
                    <div class="col-md-4 ">
                        <img src="/images/sPerson.jpg" 
                                class="img-responsive pageImg"
                                alt="Initital Design of the Single Person Page"
                                title="Initital Design of the Single Person Page"/>
                    </div>
                    <div class="col-md-8 documentation">

                    </div>
                </div>
            </div>
            <br />
            <div class="panel panel-primary">
                <div class="panel-heading" id="about">The About Page<br />
                    <div class="title">Lead Developer: James Bergeron</div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 ">
                    <img src="/images/about.jpg" 
                            class="img-responsive pageImg"
                            alt="Initital Design of About Page"
                            title="Initital Design of About Page"/>
                </div>
                <div class="col-md-8 documentation">
                    <br />
                    <p>The initial design of the about page is shown at left.
                            From the initial design, there were numerous
                            design and implementation decisons, that included:
                    </p>
                    <div class="row">
                        <div class="col-md-5 col-md-offset-4">
                            in page links, <br />
                            grid set up, <br />
                            ensuring that the page worked with the site master, <br />
                            assuring accurate and complete citations, and <br />
                            developing the content.  
                        </div>
                    </div>
                    <br />
                    <p>Chosing the right level of detail for the documentation was a
                        challenge.  Finding the "right" pictures to represent the 
                        inner cat of each of the team members
                        took a disproportionate amount of time.  There were long discussions
                        about creating 6 other web pages to include a more detailed
                        documentation for each page, but in the end the group decided
                        to focus efforts elsewhere.
                    </p>
                </div>
            </div>
        </div>
        <br />
        <div class="panel panel-primary">
            <div class="panel-heading" id="error">The Error Page<br />
                <div class="title">Lead Developer: James Bergeron</div>
            </div>
            <div class="row">
                <div class="col-md-4 ">
                    <img src="/images/error.jpg" 
                            class="img-responsive pageImg"
                            alt="Initital Design of the Single Person Page"
                            title="Initital Design of the Single Person Page"/>
                </div>
            <div class="col-md-8 documentation">

            </div>
            </div>
        </div>
    <br />
    </div>
</div>
</asp:Content>