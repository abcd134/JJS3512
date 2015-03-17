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
            txtTagLine.Text = (string)dt.Rows[0]["tagline"];
            imgPoster.ImageUrl = "http://image.tmdb.org/t/p/w500/"+dt.Rows[0]["poster_path"];
    }

    /// <summary>
    /// this opens up the database connection and runs various sql queries and fills a datatable  
    /// </summary>
    protected void DisplayMovie()
    {
        int movieID = 0;
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
           
            //
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int rowCount = dt.Rows.Count;
            DisplayMovieData(rowCount, dt);

            string sqlGenre = "SELECT genre.name FROM ((genre INNER JOIN movie_genre ON genre.genre_id = movie_genre.genre_id)"; 
            sqlGenre += " INNER JOIN movie ON movie_genre.movie_id = movie.movie_id) WHERE (movie.movie_id = "+movieID+")";
            OleDbDataAdapter adapterGenre = new OleDbDataAdapter(sqlGenre, conn);
            DataTable dtG = new DataTable();
            adapterGenre.Fill(dtG);
            txtGenre.Text = tempLoop(dtG, "name");

            string sqlKeyword = "SELECT keyword.name FROM ((movie_keyword INNER JOIN movie ON movie_keyword.movie_id = movie.movie_id)";
            sqlKeyword += " INNER JOIN keyword ON movie_keyword.keyword_id = keyword.keyword_id) WHERE (movie.movie_id ="+movieID+")";
            OleDbDataAdapter adapterKeyword = new OleDbDataAdapter(sqlKeyword, conn);
            DataTable dtK = new DataTable();
            adapterKeyword.Fill(dtK);
            txtKeyword.Text = tempLoop(dtK, "name");

            string sqlCompany = "SELECT company.company_name FROM ((movie_company INNER JOIN movie ON movie_company.movie_id = movie.movie_id)";
            sqlCompany += " INNER JOIN company ON movie_company.company_id = company.company_id) WHERE (movie.movie_id =" + movieID + ")";
            OleDbDataAdapter adapterCompany = new OleDbDataAdapter(sqlCompany, conn);
            DataTable dtC = new DataTable();
            adapterCompany.Fill(dtC);
            txtCompany.Text = tempLoop(dtC, "company_name");

            string sqlCast = "select person.name, person.person_id, movie_cast.ordering, movie_cast.role_name, person.profile_path";
            sqlCast += " from person, movie_cast, movie";
            sqlCast += " where movie.movie_id = movie_cast.movie_id and movie_cast.person_id = person.person_id";
            sqlCast += " and movie.movie_id = "+movieID+" order by movie_cast.ordering";
            OleDbDataAdapter adapterCast = new OleDbDataAdapter(sqlCast, conn);
            DataTable dtCast = new DataTable();
            adapterCast.Fill(dtCast);
            rptCast.DataSource = dtCast;
            rptCast.DataBind();

            string sqlCrew = "SELECT movie.movie_id, movie_crew.movie_crew_id, person.person_id,person.profile_path, movie_crew.department, person.name";
            sqlCrew += " FROM person INNER JOIN (movie INNER JOIN movie_crew ON movie.movie_id = movie_crew.movie_id) ON person.person_id = movie_crew.person_id";
            sqlCrew += " WHERE (((movie.movie_id)=" + movieID + ")) order by movie_crew.department";
            OleDbDataAdapter adapterCrew = new OleDbDataAdapter(sqlCrew, conn);
            DataTable dtCrew = new DataTable();
            adapterCrew.Fill(dtCrew);
            rptCrew.DataSource = dtCrew;
            rptCrew.DataBind();
            //select movie_crew.department from movie, person, movie_crew where movie.movie_id = movie_crew.movie_id and person.person_id=movie_crew.person_id and movie.movie_id=122917 
            //group by movie_crew.department;

            string sqlBackDrop = "SELECT movie_image.is_poster, movie_image.file_path FROM (movie INNER JOIN movie_image";
            sqlBackDrop += " ON movie.movie_id = movie_image.movie_id) WHERE (movie.movie_id = "+movieID+") AND (movie_image.is_poster = 0)";
            OleDbDataAdapter adapterBackDrop = new OleDbDataAdapter(sqlBackDrop, conn);
            DataTable dtBD = new DataTable();
            adapterBackDrop.Fill(dtBD);
            rptBackDrop.DataSource = dtBD;
            rptBackDrop.DataBind();

            string sqlPosters = "SELECT movie_image.is_poster, movie_image.file_path FROM (movie INNER JOIN movie_image";
            sqlPosters += " ON movie.movie_id = movie_image.movie_id) WHERE (movie.movie_id = " + movieID + ") AND (movie_image.is_poster = 1)";
            OleDbDataAdapter adapterPosters = new OleDbDataAdapter(sqlPosters, conn);
            DataTable dtP = new DataTable();
            adapterPosters.Fill(dtP);
            rptPosters.DataSource = dtP;
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

    protected string tempLoop(DataTable dt, string txtName) 
    {
        string output = " | ";
        for (int num = 0; num < dt.Rows.Count; num++)
        {
            output += (string)dt.Rows[num][txtName]+" | ";
        }
        return output;
    }

}