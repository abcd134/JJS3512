using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Data.Common;
using Content.Business;
using Content.Services;
using Content.DataAccess;

public partial class SMovie : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if not postback then display the single movie
        if (!IsPostBack)
        {
            int movieID = 0;
            //does an if check to see if the Querystring id is equal to null if it is redirect to error.aspx 
            if (Request.QueryString["id"] == null) { Response.Redirect("../Error.aspx?error=SMovie query string null error"); }
            //this checks to see if the query string is an integer if it is not redirect to the error.aspx 
            else if (!Int32.TryParse(Request.QueryString["id"], out movieID)) { Response.Redirect("../Error.aspx?error=SMovie query string non integer"); }
            DisplayMovie(movieID);
            
        }
    }

    /// <summary>
    /// this opens up the database connection and runs various sql queries and fills a datatable  
    /// </summary>
    protected void DisplayMovie(int movieID)
    {
        MovieCollection movieC = new MovieCollection();
        movieC.FetchForId(movieID);
        if (movieC.Count <= 0)
            Response.Redirect("../Error.aspx?error=Movie Not Found");
        else
        {
            topOfPage.DataSource = movieC;
            topOfPage.DataBind();
        }
        // the following data binds are a result of a visibility issue with nested repeaters.
        rptTitle.DataSource = movieC;
        rptTitle.DataBind();
        rptReleaseRun.DataSource = movieC;
        rptReleaseRun.DataBind();
        rptIMDB.DataSource = movieC;
        rptIMDB.DataBind();
        rptOverview.DataSource = movieC;
        rptOverview.DataBind();

        // alternate method to data bind versus the ones above (more memory efficient)
        if (movieC.FindById(0).Tagline != null) { rptTagline.DataSource = movieC; }
            else { rptTagline.DataSource = null; }
        rptTagline.DataBind();

        // add just the movieC to session for use with add to favorites later
        Session["movieC"] = movieC;

        // Trying to get genres from session state
        if (Session["GenreCollection"] != null)
        {
            rptGenre.DataSource = Session["GenreCollection"];
            rptGenre.DataBind();
        }
        else
        {
            GenreCollection genreC = new GenreCollection();
            genreC.FetchForId(movieID);
            if (genreC.Count <= 0)
            {
                Response.Redirect("../Error.aspx?error=No Genres Found");
            }
            else
            {
                rptGenre.DataSource = genreC;
                rptGenre.DataBind();
            }
        }

        KeyWordsCollection kwc = new KeyWordsCollection();
        kwc.FetchForId(movieID);
        if (kwc.Count <= 0)
            rptKeyWords.DataSource = null; 
        else
        {
            rptKeyWords.DataSource = kwc;         
        }
        rptKeyWords.DataBind();

        CompanyCollection companyC = new CompanyCollection();
        companyC.FetchForId(movieID);
        if (companyC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Company Names Found");
        else
        {
            rptCompany.DataSource = companyC;
            rptCompany.DataBind();
        }

        CastCollection castC = new CastCollection();
        castC.FetchForId(movieID);
        if (castC.Count > 0)
        {
            rptCast.DataSource = castC;
            rptCast.DataBind();
        }

        CrewCollection crewC = new CrewCollection();
        crewC.FetchForMovieId(movieID);
        if (crewC.Count > 0)
        {
            rptCrew.DataSource = crewC;
            rptCrew.DataBind();
        }

        MovieImageCollection backDropC = new MovieImageCollection();
        backDropC.FetchForMovieId(movieID, false);
        if (backDropC.Count > 0)
        {
            rptBackDrop.DataSource = backDropC;
            rptBackDrop.DataBind();
        }

        MovieImageCollection posterC = new MovieImageCollection();
        posterC.FetchForMovieId(movieID, true);
        if (posterC.Count > 0)
        {
            rptPosters.DataSource = posterC;
            rptPosters.DataBind();
        }

        MovieTrailersDA trailerC = new MovieTrailersDA();
        
            rptTrailer.DataSource = trailerC.fetchTrailers(movieID);
            rptTrailer.DataBind();
        

        ReviewCollection reviewC = new ReviewCollection();
        reviewC.FetchReviewByID(movieID);
        if (reviewC.Count > 0)
        {
            rptReview.DataSource = reviewC;
            rptReview.DataBind();
        }
    }
    /// <summary>
    /// Method to add a single movie to the movie favorites list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void addToFav_Click(object sender, EventArgs e)
    {
        MovieFavoritesCollection favMoviesC;
        MovieCollection movieC;
        if (Session["favMoviesC"] != null)
        {
            favMoviesC = (MovieFavoritesCollection)Session["favMoviesC"];
        }
        else 
        { 
            favMoviesC = new MovieFavoritesCollection(); 
        }

        // Check to see if the movie collection is still in session state
        // go to error page with timeout message if not.  User timed out.
        if (Session["movieC"] == null)
        {
            Response.Redirect("../Error.aspx?error=Sorry, you timed out.  Please try again.");
        }
        movieC = (MovieCollection)Session["movieC"];

        MovieFavorites movieToAdd;
        movieToAdd = movieC[0].MakeMovieInstance();
        // Need to add to the collection then  put in session 
        favMoviesC.AddToCollection(movieToAdd);
        Session["favMoviesC"] = favMoviesC;
        Response.Redirect("../Favorites/Favorites.aspx");
    }
    /// <summary>
    /// Pushes Reviews to the ReviewDA
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReviewSubmit_Click(object sender, EventArgs e)
    {
        int movieID = 0;
        string d = Request["ctl00$MainContent$rating1"];
        int rating = Convert.ToInt16(d);
        string fname = txtFirstName.Text;
        string lname = txtLastName.Text;
        string review = txtReview.Text;
        DateTime date = DateTime.Now;
        string review_title = txtReviewTitle.Text;

        if (checkForUserInput() == false)
        {
            ReviewDA dataToInsert = new ReviewDA();
            movieID = Convert.ToInt32(Request.QueryString["id"]);
            dataToInsert.InsertReview(movieID, fname, lname, review, date, rating, review_title);

            Response.Redirect(Request.RawUrl);
        }
        
    }

    private bool checkIfDataInputExists(string ToCheck)
    {
        if (ToCheck == null || ToCheck == "")
            return true;
        return false;
    }

    private bool checkForUserInput()
    {
        string errorMessege = "Required Field: ";
        bool userError = false;

        if (checkIfDataInputExists(txtFirstName.Text))
        {
            errorMessege += "First Name ";
            userError = true;
        }
        if (checkIfDataInputExists(txtLastName.Text))
        {
            errorMessege += "Last Name ";
            userError = true;
        }
        if (checkIfDataInputExists(txtReview.Text))
        {
            errorMessege += "Review ";
            userError = true;
        }
        if (checkIfDataInputExists(txtReviewTitle.Text))
        {
            errorMessege += "Review Title ";
            userError = true;
        }

        errorMessege += ". Please provide input";

        if (userError)
        {
            string script = "alert(\'" + errorMessege +" \');";
            ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", script, true);
        }
        return userError;
    }
}