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

public partial class SMovie : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if not postback then display the single movie
        if(!IsPostBack)
        {
            DisplayMovie();
        }
    }

    /// <summary>
    /// this method displays the individual rows of data and assigns them to a label
    /// </summary>
    /// <param name="rowCount"></param>
    /// <param name="dt"></param>
    protected void DisplayMovieData(int rowCount, DataTable dt)
    {
            DataRow row = dt.Rows[0];
            int content = (int)row["movie_id"];
            txtTitle.Text = (string)dt.Rows[0]["title"];
            txtReleaseDate.Text = (string)dt.Rows[0]["release_date"];
            txtRunTime.Text = Convert.ToInt32(dt.Rows[0]["runtime"]).ToString() + " Minutes";
            txtOverview.Text = (string)dt.Rows[0]["overview"];
            txtIMDB.Text = "http://www.imdb.com/title/" + dt.Rows[0]["imdb_id"];
            linkIMDB.HRef = "http://www.imdb.com/title/" + dt.Rows[0]["imdb_id"];
            txtBudget.Text = checkValues(dt, "budget");
            txtRevenue.Text = checkValues(dt, "revenue");
            txtAverage.Text = Convert.ToDecimal(dt.Rows[0]["vote_average"]).ToString();
            txtVoteCount.Text = Convert.ToDecimal(dt.Rows[0]["vote_count"]).ToString();
            imgPoster.ImageUrl = "http://image.tmdb.org/t/p/w500"+dt.Rows[0]["poster_path"];
            imgPosterLarge.ImageUrl = "http://image.tmdb.org/t/p/w780" + dt.Rows[0]["poster_path"];
    }

    /// <summary>
    /// this opens up the database connection and runs various sql queries and fills a datatable  
    /// </summary>
    protected void DisplayMovie()
    {
        int movieID = 0;
        Adapter data = new Adapter(WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString);
        String connString = WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(connString);
        try
        {
            //does an if check to see if the Querystring id is equal to null if it is redirect to error.aspx 
            if (Request.QueryString["id"] == null) { Response.Redirect("../Error.aspx"); }
            //this checks to see if the query string is an integer if it is not redirect to the error.aspx 
            else if (!Int32.TryParse(Request.QueryString["id"], out movieID)) { Response.Redirect("../Error.aspx"); }
            
          
           //this is sql statement gets all the movie details where it equals the querystring movie id 
           string sql = "SELECT movie_id, imdb_id, title, overview, poster_path, backdrop_path, release_date, revenue, budget, runtime, tagline, vote_average, vote_count FROM movie as a";
           sql += " WHERE a.movie_id=" + movieID;

            //connect to the adapter and pass in the sql and connection string
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int rowCount = dt.Rows.Count;
            //if the rowcount is zero go to error page
            if (rowCount == 0) { Response.Redirect("../Error.aspx"); }
            DisplayMovieData(rowCount, dt);

            //binding values to tagline repeater
            rptTagline.DataSource = data.createDataTable(Constants.retrieveMovieTagline(movieID));
            rptTagline.DataBind();

            //binding values to genre repeater
            rptGenre.DataSource = data.createDataTable(Constants.retrieveMovieGenre(movieID));
            rptGenre.DataBind();

            //binding values to keyword repeater
            rptKeyword.DataSource = data.createDataTable(Constants.retrieveMovieKeyword(movieID));
            rptKeyword.DataBind();

            //binding values to company repeater
            rptCompany.DataSource = data.createDataTable(Constants.retrieveMovieCompany(movieID));
            rptCompany.DataBind();

            //binding values to cast repeater
            rptCast.DataSource = data.createDataTable(Constants.retrieveMovieCast(movieID));
            rptCast.DataBind();

            //binding values to crew repeater
            rptCrew.DataSource = data.createDataTable(Constants.retrieveMovieCrew(movieID));
            rptCrew.DataBind();

            //binding values to backdrop repeater
            rptBackDrop.DataSource = data.createDataTable(Constants.retrieveBackDropImages(movieID));
            rptBackDrop.DataBind();

            //binding values to posters repeater
            rptPosters.DataSource = data.createDataTable(Constants.retrievePosterImages(movieID));
            rptPosters.DataBind();

        }
        catch (Exception ex)
        {
            message.Text = "<h2>An Error Occurred</h2>";
            message.Text += ex.Message;
        }
        finally
        {
            conn.Close();
        }
    }

/// <summary>
/// This function checks to see if the image is NULL if it is then 
/// return a a not available image else return the image url and path 
/// </summary>
/// <param name="path"></param>
/// <returns></returns>
    protected string checkIMG (object path)
    {
        string output = "";
        if(path == DBNull.Value)
        {
            output = "../images/Not_available.jpg";
        }
        else
        {
            output = "http://image.tmdb.org/t/p/w154/"+path;
        }
        return output;
    }

    /// <summary>
    /// This functions checks to see if the currency is 0 and if it is it will return N/A
    /// else return the currency in string format 
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    protected string checkValues(DataTable dt, string name)
    {
        string output = "";
        decimal value = (decimal)dt.Rows[0][name];
        if (value.Equals(0))
        {
            output = "N/A";
        }
        else
        {
            output = String.Format("{0:c}", dt.Rows[0][name]).ToString();
        }
        return output;
    }
}