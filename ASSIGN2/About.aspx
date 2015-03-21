<%@ Page Title="About" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeFile="About.aspx.cs" 
    Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
                    <span class="anchor" id="joseph"></span>
                    <h3 >Joseph Balabat</h3>
                        <figure>
                            <img src="/images/joseph.jpg" 
                                 alt="Joseph Balabat"
                                 title="Joseph Balabat - The Cat"
                                 class="img-circle" 
                                 width="175" />
                        </figure>
                        <p><span class="firstWord">Joseph</span>, worked tirelessly to  help design and implement
                            the web page.  His joie de vivre inspired the team.  A key member
                            of the team who took every opportunity to lead and to
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
                    <span class="anchor" id="james"></span>
                    <h3 >James Bergeron</h3>
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
                            implementation details for the about us page and the error page.  
                            Heard to complain about his role, he was asked 
                            to do the browse page. We could go on about how great he was, but 
                            someone might suspect who was actually authoring this piece.
                        </p>
                </div>
                <br />
                
                <div class="col-md-10 col-md-offset-1 innerWell">
                    <span class="anchor" id="sonia"></span>
                    <h3 >Sonia Pitrola</h3>
                        <figure>
                            <img src="/images/sonia.jpg" 
                                 alt="Sonia Pitrola"
                                 title="Sonia Pitrola- The Cat"
                                 class="img-circle" 
                                 width="175" />
                        </figure>
                        <p><span class="firstWord">Sonia</span>, tireless, design focussed,
                            led the development effort on the single movie page.  In addition
                            Sonia developed and provided to team members clear, concise instructions
                            for cloning and using the GitHub repository for sharing information.
                            Sonia also created and managed the Google Drive repository for
                            sharing information.  She was instrumental in design decisions to 
                            establish the initial layout as well as the lead in
                            the establishment of the look and feel of the site.  Sonia's good
                            nature and drive for success was a key component in ensuring cohesion
                            between the team members.  She will wear a skirt to school if we get
                            an "A"......  ooops the writer was thinking out loud again. 
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
        <span class="anchor" id="citations"></span>
        <div class="panel-heading" >Citations</div>
        <div class="panel-body">
            <ul class="list-group">
                <li class="list-group-item"><a href="http://www.sochealth.co.uk/2013/08/09/my-favourite-kitten-pictures-for-internationalcatday/">
                    Image of Joseph from the Socialist Health Association</a></li>
                <li class="list-group-item"><a href="http://nyc_dog_blog.downtownpet.com/2007/08/cats-and-ducks.html">
                    Image of Sonia from The NY City Downtown Pets</a></li>
                <li class="list-group-item"><a href="http://www.inlander.com/imager/b/blog/2201738/bdd7/beabetterfriend.jpg?cb=1383547907">
                    Image of James from The Inlander</a></li>
                <li class="list-group-item">Will Fowler for GitHub Guidance</li>
                <li class="list-group-item">Connolly R., Hoar R., 2015,Fundamentals of Web Development</li>
                <li class="list-group-item">Connolly R., 2007,Core Internet Application with ASP.NET 2.0</li>
                <li class="list-group-item"><a href="https://www.themoviedb.org/">The Movie Database (TMDb)</a></li>
                <li class="list-group-item"><a href="http://pixelflips.com/blog/anchor-links-with-a-fixed-header">In Page Referencing Spacing Solution</a></li>
                <li class="list-group-item"><a href="http://www.codeproject.com/Articles/333650/Beginner-s-Tutorial-on-Master-Pages-in-ASP-NET">Getting/Setting Master Page Content from a content page</a></li>
            </ul>
        </div>
    </div>
</div>
<div class="row">
    <div class="panel panel-info">
        <div class="panel-heading">Team Development Efforts</div>
        <div class="panel-body">
            <span class="anchor" id="homePage"></span>
            <div class="panel panel-primary">
                <div class="panel-heading" >The Home Page<br />
                    <div class="title">Lead Developer: Joseph Balabat</div>
                </div>
                <div class="row">
                    <div class="col-md-3 col-md-offset-1 ">
                        <img src="/images/homePage.jpg" 
                            class="img-responsive pageImg"
                            alt="Initital Design of Home Page"
                            title="Initital Design of Home Page"/>
                    </div>
                    <div class="col-md-7 documentation">
                    <br />
                        <p>The home page provided a number of challenges, the largest
                            of which was balancing design and functionality.  </p>
                        <p>The page provided the opportunity to learn how to implement the 
                            carousel feature. </p>
                        <p>The page was used to help set up the
                            database access and the master page features related to
                            the header and the footer. 
                        </p>
                        <p> A number of design choices were tested on the home page
                            before we settled on the look submitted.
                        </p>
                        <p>
                            Not truly part of the home page, but Joseph lead the set up
                            of the file structure we used, initiated github for development,
                             and got a number of master page features to work.
                        </p>
                    </div>
                </div>
            </div>
            <br />
            <span class="anchor" id="browse"></span>
            <div class="panel panel-primary">
                <div class="panel-heading" >The Browse Page<br />
                    <div class="title">Lead Developer: James Bergeron</div>
                </div>
                <div class="row">
                    <div class="col-md-3 col-md-offset-1 ">
                        <img src="/images/browse.jpg" 
                             class="img-responsive pageImg"
                             alt="Initital Design of the Browse Page"
                             title="Initital Design of the Browse Page"
                        />
                    </div>
                    <div class="col-md-7 documentation">
                        <br />
                        <p>The browse page provided an initial challenge, because
                            any given movie could have multiple cast members, directors
                            and genres.

                        </p>
                        <p>
                            A number of the design choices were made for expediency, leaving 
                            future improvement opportunities.  Specifically, the rating system could
                            be improved with the use of images, the height of each row could
                            standardized, and the inclusion of nested materials, would
                            enhance the information value of the pages.
                        </p>
                        <p> 
                            Beyond the initial challenges of learning how to use ASP.NET,
                            there were a number of smaller challenges.  The desire to use 
                            Bootstrap trumped the
                            use of the controls which would easily allow pagination.
                            The same comment applied to sorting on columns.
                            We believe that a pleasing look, coupled with continual small
                            tweaks to functionality would keep visitors coming
                            back and keep us employed upgrading the site.
                        </p>
                    </div>
                </div>
            </div>
            <br />
            <span class="anchor" id="sMovie"></span>
            <div class="panel panel-primary">
                <div class="panel-heading" >The Single Movie Page<br />
                    <div class="title">Lead Developer: Sonia Pitrola</div>
                </div>
                <div class="row">
                    <div class="col-md-3 col-md-offset-1 ">
                        <img src="/images/sMovie.jpg" 
                                class="img-responsive pageImg"
                                alt="Initital Design of About Page"
                                title="Initital Design of About Page"
                            />
                    </div>
                    <div class="col-md-7 documentation">
                        <br />
                        <p>The Single movie page's main challenge was initially
                            in the design that would allow a sensible display of large
                            amounts of data.
                        </p>
                        <p>We struggled with whether to put the data binding in the
                            front page or the code behind.  We opted for the code
                            behind, binding the data with an adaptor in a data
                            table.  We found the explicit associating of each label
                            with it's corresponding value to be a simple approach,
                            but were left feeling like our coding could have been better.
                        </p>
                        <p>We discussed how to bind data for those items that had multiple
                            possible values.  Examples of this type of data are genre, cast
                            members, actors,.... We opted for multiple query strings that
                            would be bound to labels contained in repeaters.
                        </p>
                    </div>
                </div>
            </div>
            <br />
            <span class="anchor" id="sPerson"></span>
            <div class="panel panel-primary">
                <div class="panel-heading" >The Single Person Page</div>
                <div class="row">
                    <div class="col-md-3 col-md-offset-1 ">
                        <img src="/images/sPerson.jpg" 
                                class="img-responsive pageImg"
                                alt="Initital Design of the Single Person Page"
                                title="Initital Design of the Single Person Page"/>
                    </div>
                    <div class="col-md-7 documentation">
                        <br />
                        <p>This page had similar challenges to those encountered
                            in the Single Movie page.  The largest challenge by far
                            was determining the right design.  
                        </p>
                        <p>
                            By the time we got around to designing this page, Sonia
                            had mastered a number of the technical challenges and 
                            had laid the visual framework for the work to progress.
                        </p>
                        <p>
                            Styling similar to that shown on the single movie page
                            needed to be coordinated and synchronized.
                        </p>
                    </div>
                </div>
            </div>
            <br />
            <span class="anchor" id="about"></span>
            <div class="panel panel-primary">
                <div class="panel-heading" >The About Page<br />
                    <div class="title">Lead Developer: James Bergeron</div>
                </div>
            
            <div class="row">
                <div class="col-md-3 col-md-offset-1 ">
                    <img src="/images/about.jpg" 
                            class="thumbnail img-responsive"
                            alt="Initital Design of About Page"
                            title="Initital Design of About Page"/>
                </div>
                <div class="col-md-7 documentation">
                    <br />
                    <p>The initial design of the about page is shown at left.
                            From the initial design, there were numerous
                            design and implementation decisons, that included:
                    </p>
                    <div class="row">
                        <div class="col-md-6 col-md-offset-2">
                            in page links, <br />
                            grid set up, <br />
                            ensuring that the page worked with the site master, <br />
                            assuring accurate and complete citations, and <br />
                            developing the content.  
                        </div>
                    </div>
                    <p>Chosing the right level of detail for the documentation was a
                        challenge.  Finding the "right" pictures to represent the 
                        inner cat of each of the team members
                        took a disproportionate amount of time.
                    </p>
                </div>
                </div>
            </div>
        </div>
        <br />
        <span class="anchor" id="error"></span>
        <div class="panel panel-primary">
            <div class="panel-heading" >The Error Page<br />
                <div class="title">Lead Developer: James Bergeron</div>
            </div>
            <div class="row">
                <div class="col-md-3 col-md-offset-1 ">
                    <img src="/images/error.jpg" 
                            class="img-responsive pageImg"
                            alt="Initital Design of the Single Person Page"
                            title="Initital Design of the Single Person Page"/>
                </div>
                <div class="col-md-7 documentation">
                    <br />
                    <p>Nothing fancy on this page. </p><br />
                    <p> We opted not to include a query string retrieval process to 
                        provide more descriptive error messages, but it bugged us so
                        much that we decided to include the functionality (OK, bugged me).
                    </p>
                    <p>
                        We considered putting an explicit Button Link 
                        back to the home page, but felt there were enough navigation 
                        options already included on the page for this function.
                    </p><br />
                    <p>Yes, we agree, picture of the cat getting
                        zapped is tacky and the image editing is on par with an
                        early 80's effort, so you already know who did it.
                    </p>    
                </div>
            </div>
        </div>
    <br />
    </div>
</div>
</asp:Content>