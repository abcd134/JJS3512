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
        rptTagline.DataSource = movieC;
        rptTagline.DataBind();

        GenreCollection genreC = new GenreCollection();
        genreC.FetchForId(movieID);
        if (genreC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Genres Found");
        else
        {
            rptGenre.DataSource = genreC;
            rptGenre.DataBind();
        }

        KeyWordsCollection kwc = new KeyWordsCollection();
        kwc.FetchForId(movieID);
        if (kwc.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Key Words Found");
        else
        {
            rptKeyWords.DataSource = kwc;
            rptKeyWords.DataBind();
        }

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
        if (castC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Cast Found");
        else
        {
            rptCast.DataSource = castC;
            rptCast.DataBind();
        }

        CrewCollection crewC = new CrewCollection();
        crewC.FetchForMovieId(movieID);
        if (crewC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Crew Found");
        else
        {
            rptCrew.DataSource = crewC;
            rptCrew.DataBind();
        }

        MovieImageCollection backDropC = new MovieImageCollection();
        backDropC.FetchForMovieId(movieID, false);
        if (backDropC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Back Drop images Found");
        else
        {
            rptBackDrop.DataSource = backDropC;
            rptBackDrop.DataBind();
        }

        MovieImageCollection posterC = new MovieImageCollection();
        posterC.FetchForMovieId(movieID, true);
        if (posterC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Poster images Found");
        else
        {
            rptPosters.DataSource = posterC;
            rptPosters.DataBind();
        }
    }
}