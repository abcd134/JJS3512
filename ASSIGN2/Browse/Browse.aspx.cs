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

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int genreID;
            string search;
            if (Request.QueryString["search"] != null)
            {
                search = null;
            }
            else { search = null; }
            if (Request.QueryString["genre"] != null)
            {
                genreID = Convert.ToInt32(Request.QueryString["genre"]);
                lblGenre.Text = Convert.ToString(genreID);
            }
            else { genreID = -1;}
            PerformDataBinding(search, genreID);
        }
    }
    private void PerformDataBinding(string search, int genreID)
    {
        // retrieve the connection string from our config file
        string connString =
        WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        // create the connection
        OleDbConnection conn = new OleDbConnection(connString);
        try
        {
            // open the connection to the database
            conn.Open();
            // create the SQL command
            string sql =
            "SELECT [movie.movie_id] as id, [person.person_id] as pid, [poster_path],";
            sql += "[title],[release_date],[person.name] as name,[role_name],[overview],";
            sql += "[tagline],[vote_average],[backdrop_path] ";
            sql += "FROM movie, movie_cast, person ";
            if (genreID >= 0) { sql += ", movie_genre, genre "; }
            sql += "WHERE  movie_cast.movie_id = movie.movie_id AND ";
            sql += "movie_cast.person_id = person.person_id AND ";
            sql += "movie_cast.ordering = 0 ";
            if ( genreID >= 0)
            {
                sql += " AND movie_genre.genre_id = genre.genre_id ";
                sql += " AND movie_genre.movie_id = movie.movie_id ";
                sql += " AND genre.genre_ID =" + genreID;
            }
            if (search != null) { sql += " AND movie.title = '%" + search + "%' ";}
            sql += " ORDER BY release_date DESC";

            OleDbCommand cmd = new OleDbCommand(sql, conn);
            // create the data reader (the results from the SQL query)
            OleDbDataReader reader = cmd.ExecuteReader();
            // now data bind to the reader
            layout.DataSource = reader;
            layout.DataBind();


            sql = "Select name as genreName, genre_id from genre";
            cmd = new OleDbCommand(sql, conn);
            reader = cmd.ExecuteReader();
            drpGenres.DataSource = reader;
            drpGenres.DataBind();
            // close the reader after binding
            reader.Close();
        }
        catch (Exception ex)
        {
            labMsg.Text = "<h2>An Error Occurred</h2>";
            labMsg.Text += ex.Message;
        }
        finally
        {
            // always close connection in the finally block, as this
            // guarantees closure whether or not an error occurs
            conn.Close();
        }
    }
    public void genres_SelectedIndexChanged(object sender, EventArgs e)
    {
        String search;
        if (Request.QueryString["search"] != null)
        {
            search = null;
        }
        else { search = null;  }
        lblGenre.Visible = true;
        String filter = drpGenres.SelectedItem.Text;

        // retrieve index of the row that generated the event
        int genre_ID = Convert.ToInt32(drpGenres.SelectedValue);
        PerformDataBinding(search, genre_ID);
        lblGenre.Text = filter;
        Response.Redirect("Browse.aspx?search=" + search + "&genre=" + genre_ID);
    }
    

}