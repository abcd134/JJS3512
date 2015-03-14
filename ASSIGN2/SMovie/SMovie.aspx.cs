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

    protected void DisplayMovieData(int rowCount, DataTable dt)
    {
        if (rowCount > 0)
        {
            DataRow row = dt.Rows[0];
            int content = (int)row["movie_id"];
            txtTitle.Text = (string)dt.Rows[0]["title"];
            txtReleaseDate.Text = (string)dt.Rows[0]["release_date"];
            txtRunTime.Text = Convert.ToInt32(dt.Rows[0]["runtime"]).ToString() + " Minutes";
            txtOverview.Text = (string)dt.Rows[0]["overview"];
            txtIMDB.Text = (string)dt.Rows[0]["imdb_id"];
            txtBudget.Text = Convert.ToDecimal(dt.Rows[0]["budget"]).ToString();
            txtRevenue.Text = Convert.ToDecimal(dt.Rows[0]["revenue"]).ToString();
            txtAverage.Text = Convert.ToDecimal(dt.Rows[0]["vote_average"]).ToString();
            txtVoteCount.Text = Convert.ToDecimal(dt.Rows[0]["vote_count"]).ToString();
            txtTagLine.Text = (string)dt.Rows[0]["tagline"];
            //txtGenre.Text = (string)dt.Rows[0]["name"];
        }
        else
        {
            Response.Redirect("Error.aspx");
        }

    }

    protected void DisplayMovie()
    {
        string movieID = Request["id"];
        String connString = WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(connString);
        try
        {
           string sql = "SELECT * FROM movie as a";
           sql += " WHERE a.movie_id=" + movieID;
            
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int rowCount = dt.Rows.Count;
            DisplayMovieData(rowCount, dt);
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
}