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
            txtBudget.Text = String.Format("{0:c}",dt.Rows[0]["budget"]).ToString();
            txtRevenue.Text = String.Format("{0:c}",dt.Rows[0]["revenue"]).ToString();
            txtAverage.Text = Convert.ToDecimal(dt.Rows[0]["vote_average"]).ToString();
            txtVoteCount.Text = Convert.ToDecimal(dt.Rows[0]["vote_count"]).ToString();
            object valueTag = dt.Rows[0]["tagline"];    
            //txtTagLine.Text = (string)dt.Rows[0]["tagline"];
            txtTagLine.Text = checkEmpty(dt, valueTag, "tagline");
            imgPoster.ImageUrl = "http://image.tmdb.org/t/p/w500/"+dt.Rows[0]["poster_path"];
           
            //object value = dt.Rows[0]["poster_path"];
            //checkImage(dt, imgPoster.ImageUrl, value, "poster_path");
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
           string sql = "SELECT * FROM movie as a";
           sql += " WHERE a.movie_id=" + movieID;

            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int rowCount = dt.Rows.Count;
            if (rowCount == 0) { Response.Redirect("../Error.aspx"); }
            DisplayMovieData(rowCount, dt);

            rptGenre.DataSource = data.createDataTable(Constants.retrieveMovieGenre(movieID));
            rptGenre.DataBind();

            rptKeyword.DataSource = data.createDataTable(Constants.retrieveMovieKeyword(movieID));
            rptKeyword.DataBind();

            rptCompany.DataSource = data.createDataTable(Constants.retrieveMovieCompany(movieID));
            rptCompany.DataBind();

            rptCast.DataSource = data.createDataTable(Constants.retrieveMovieCast(movieID));
            rptCast.DataBind();

            rptCrew.DataSource = data.createDataTable(Constants.retrieveMovieCrew(movieID));
            rptCrew.DataBind();

            rptBackDrop.DataSource = data.createDataTable(Constants.retrieveBackDropImages(movieID));
            rptBackDrop.DataBind();

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

    private string checkEmpty(DataTable dt, object value, string name)
    {
        string output = "";
        if(value == DBNull.Value)
        {
            return output;
        }
        else
        {
            //return imgPoster.ImageUrl = "http://image.tmdb.org/t/p/w500/"+dt.Rows[0][name];
            output = (string)dt.Rows[0][name];
        }
        return output;
    }
}