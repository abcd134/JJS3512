using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;
using Content.Business;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            initializeDatabases();
            createFeaturedPerson();
            createCarousel();
        }
    }

    protected void initializeDatabases()
    {
        int theHobbit = 122917;
        bindMovie(theHobbit);
    }
    protected void FeaturedButton1_Click(object sender, EventArgs e)
    {
        int theHobbit = 122917;
        bindMovie(theHobbit);
    }
    protected void FeaturedButton2_Click(object sender, EventArgs e)
    {
        int interstellar = 157336;
        bindMovie(interstellar);
    }
    protected void FeaturedButton3_Click(object sender, EventArgs e)
    {
        int matrix = 603;
        bindMovie(matrix);
    }
    protected void FeaturedButton4_Click(object sender, EventArgs e)
    {
        int lionKing = 8587;
        bindMovie(lionKing);
    }
    protected void FeaturedButton5_Click(object sender, EventArgs e)
    {
        int hungerGames = 131631;
        bindMovie(hungerGames);
    }
    // Featured person code
    protected void createFeaturedPerson()
    {
        PersonCollection personC = new PersonCollection();
        // Time permitting, this method should be changed to 
        // have a variable length array as an input
        personC.FetchFor3PeopleIds(3896, 140, 72129);
        if (personC.Count <= 2)
            Response.Redirect("Error.aspx?error=Fatal Error - Person Not Found for home page");
        else
        {
            FeaturedPersonRepeater.DataSource = personC;
            FeaturedPersonRepeater.DataBind();
        }
    }
    /// <summary>
    /// The attached method could be greatly cleaned up by fetching
    /// the three chosen movies in one request ..... ah, another thing to do :-)
    /// </summary>
    protected void createCarousel()
    {
        int posterID = 14428;
        MovieImageCollection imageC = new MovieImageCollection();
        imageC.FetchForImageID(posterID);
        if (imageC.Count != 1)
            Response.Redirect("Error.aspx?error=Fatal Error - Image Count issue on home page");
        else
        {
            // Note the find by id method used here.  I will use this on the smovie page
            CarouselBackdrop1.ImageUrl = (string)imageC.FindById(0).FilePath1920;
            CarouselInfo1.NavigateUrl = "../SMovie/SMovie.aspx?id=" + (int)imageC.FindById(0).MovieID;
        }

        posterID = 13990;
        imageC = new MovieImageCollection();
        imageC.FetchForImageID(posterID);
        if (imageC.Count != 1)
            Response.Redirect("Error.aspx?error=Fatal Error - Person Image Count issue on home page");
        else
        {
            CarouselBackdrop2.ImageUrl = (string)imageC.FindById(0).FilePath1920;
            CarouselInfo2.NavigateUrl = "../SMovie/SMovie.aspx?id=" + (int)imageC.FindById(0).MovieID;
        }
        posterID = 7265;
        imageC = new MovieImageCollection();
        imageC.FetchForImageID(posterID);
        if (imageC.Count != 1)
            Response.Redirect("Error.aspx?error=Fatal Error - Third Image Count issue on home page");
        else
        {
            CarouselBackdrop3.ImageUrl = (string)imageC.FindById(0).FilePath1920;
            CarouselInfo3.NavigateUrl = "../SMovie/SMovie.aspx?id=" + (int)imageC.FindById(0).MovieID;
        }
    }
    /// <summary>
    /// Method to create movie collections for a single movie
    /// Time permitting, this could be made more robust my accepting
    /// an array of ID's and retrieving a collection of movie objects
    /// rather than 3 separate data retrievals
    /// </summary>
    /// <param name="movieID"></param>
    protected void bindMovie(int movieID)
    {
        MovieCollection movieC = new MovieCollection();
        movieC.FetchForId(movieID);
        if (movieC.Count <= 0)
            Response.Redirect("Error.aspx?error=Movie Not Found");
        else
        {
            FeaturedRepeater.DataSource = movieC;
            FeaturedRepeater.DataBind();
        }
    }  
}