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

public partial class Browse : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int genreID;
        string search;
        if (!IsPostBack)
        {
            // Check Query String for value then validate
            try
            {
                genreID = -1;    // No genre to filter on unless explicity set in next section
                // Check for valid genre id and name
                if (Request.QueryString["genre"] != null ){
                    if(Request.QueryString["genreType"] != null){
                        genreID = Convert.ToInt32(Request.QueryString["genre"]);

                        if (Request.QueryString["SearchType"] == null) { Master.SearchKind = "Title"; }
                        else { Master.SearchKind = Request.QueryString["SearchType"]; }

                        lblGenre.Text = "&nbsp Showing only " + Request.QueryString["genreType"] + " movies";                      
                    }
                    else{
                        Response.Redirect("../Error.aspx?error=Invalid Query String sent to Browse Page");
                    }
                }
                // Check Query String for value
                if (Request.QueryString["search"] != null && Request.QueryString["search"] != "")
                {
                    search = Request.QueryString["search"];
                    // set the search box with latest search string
                    Master.SearchBx = search;
                    Master.SearchKind = Request.QueryString["SearchType"];
                    if (lblGenre.Text.Length > 0)
                    {
                        lblGenre.Text += " containing '" ;
                    }
                    else {
                        lblGenre.Text = "&nbsp Showing only movies containing '";
                        lblGenre.Visible = true;
                        removeFilter.Visible = true;
                    }
                    lblGenre.Text += Master.SearchBx + "' in the " + Master.SearchKind + " field.";
                }
                else { search = null; }
                PerformDataBinding(search, genreID);
            }
            catch (Exception ex)
            {
                Response.Redirect("../Error.aspx?error=" + Convert.ToString(ex.Message)); 
            }
        }
    }
    /// <summary>
    /// PerformDataBinding
    /// Method used to retrieve data and bind data to control Elements
    /// </summary>
    /// <param name="search">String used in SQL WHERE clause to search on</param>
    /// <param name="genreID">Integer used in SQL WHERE clasue to filter on</param>
    private void PerformDataBinding(string search, int genreID)
    {
        notFound.Visible = false;
        removeFilter.Visible = true;
        lblGenre.Visible = true;
        string searchOn = Master.SearchKind;
        BrowseCollection browseC = new BrowseCollection();
        if (search != null && genreID >= 0) // Filter on genre and search criteria
        {
            browseC.FetchForGenreAndSearch(genreID, search, searchOn);
        }
            else if(search != null){ //Filter on only search box criteria
                browseC.FetchForSearch(search, searchOn);
            }
                else if(genreID >= 0){
                    browseC.FetchForGenre(genreID); // Filter only on genre
                }
                    else { 
                        browseC.FetchAll();
                        removeFilter.Visible = false;
                        lblGenre.Visible = false;
                    }
        if (browseC.Count <= 0)
        {
            // set a label to visible and make text
            // saying no records found
            notFound.Text = "<h2>Sorry, no records matching your criteria were found</h2>";
            notFound.Visible = true;
        }        
        else
        {
            layout.DataSource = browseC;
            layout.DataBind();
        }

        Session["BrowseCollection"] = browseC;

        // Trying to get genres from session state
        if (Session["GenreCollection"] != null)
        {
            drpGenres.DataSource = Session["GenreCollection"];
            drpGenres.DataBind();
        }
        else
        {
            GenreCollection genreC = new GenreCollection();
            genreC.FetchGenreNames();
            drpGenres.DataSource = genreC;
            drpGenres.DataBind();
            Session["GenreCollection"] = genreC;
        }
    }

    /// <summary>
    /// Method to clear search and filter fields and to make
    /// their visisibilty = false.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void on_Click(object sender, EventArgs e)
    {
        // Clear Master search box
        Master.SearchBx = "";
        Master.SearchKind = "Title";
        
        // Hide elements related to a filter
        removeFilter.Visible = false;
        notFound.Visible = false;
        lblGenre.Visible = false;

        // Reset genre label to null
        lblGenre.Text = "";

        // Now head back to Browse page, resetting the POSTS to null
        Response.Redirect("../Browse/Browse.aspx");
    }
    /// <summary>
    /// Method to add a Movie to the Favorites list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void addToFav_Click(object sender, CommandEventArgs e)
    {
        // Check for existing favorites list, create one if not found
        MovieFavoritesCollection favMoviesC;
        if (Session["favMoviesC"] != null)
        {
            favMoviesC = (MovieFavoritesCollection) Session["favMoviesC"];
        }
        else { favMoviesC = new MovieFavoritesCollection(); }

        //Get the current browse page collection.  If timed out go to error page.
        BrowseCollection browseC;
        if (Session["BrowseCollection"] == null)
        {
            Response.Redirect("../Error.aspx?error=Sorry, you timed out.  Please browse again.");
        }
        browseC = (BrowseCollection)Session["BrowseCollection"];

        if (browseC.Count > 0)  // this check likely not necessary
                                // shouldn't be able to get here without 
                                // at least one moive
        {
            // Need to get the data from the movie chosen
            int i = 0;
            while (i < browseC.Count){
                if ( browseC[i].MovieId.ToString()  == (string) e.CommandArgument)
                {
                    // found the movie to add to favorites
                    
                    MovieFavorites movieToAdd;
                    movieToAdd = browseC[i].MakeMovieInstance();
                    // Need to add to the collection then put in session 
                    favMoviesC.Add(movieToAdd);
                    Session["favMoviesC"] = favMoviesC;
                    Response.Redirect("../Favorites/Favorites.aspx");
                }
                i++;
            }   
        }
    }
}