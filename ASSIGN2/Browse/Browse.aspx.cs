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


public partial class Browse : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int genreID;
        string genreType;
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
                        lblGenre.Text = "Filtering on: " + Request.QueryString["genreType"];
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
                    if (lblGenre.Text.Length > 0)
                    {
                        lblGenre.Text += " and " + Master.SearchBx;
                    }
                    else { 
                        lblGenre.Text = "Filtering on: " + search;
                        lblGenre.Visible = true;
                        removeFilter.Visible = true;
                    }
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
            if (genreID >= 0) { sql += ", [genre.name] "; }
            sql += "FROM movie, movie_cast, person ";
            if (genreID >= 0) { sql += ", movie_genre, genre "; }  // add tables to retrieve genre data
            sql += "WHERE  movie_cast.movie_id = movie.movie_id AND ";
            sql += "movie_cast.person_id = person.person_id AND ";
            sql += "movie_cast.ordering = 0 ";

            // Include information to filter on Genre
            if ( genreID >= 0)
            {
                sql += " AND movie_genre.genre_id = genre.genre_id ";
                sql += " AND movie_genre.movie_id = movie.movie_id ";
                sql += " AND genre.genre_ID =" + genreID;
                notFound.Visible = false;
                removeFilter.Visible = true;
                lblGenre.Visible = true;
            }

            // Include search string
            if (search != null ) { sql += " AND movie.title LIKE '%" + search + "%' ";}
            sql += " ORDER BY release_date DESC";

            // Establish command to execute the Select statement
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            // create the data reader (the results from the SQL query)
            OleDbDataReader reader = cmd.ExecuteReader();
            // now data bind to the reader
            layout.DataSource = reader;
            layout.DataBind();
            if (!reader.HasRows)
            {
                // set a label to visible and make text
                // saying no records found
                notFound.Text = "<h2>Sorry, no records matching your criteria were found</h2>";
                notFound.Visible = true;
            }

            // Obtain data for Genre Filter Process (used to list genres)
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
            // On error, send error message to the error page"
            Response.Redirect("../Error.aspx?error=" + Convert.ToString(ex.Message) );
        }
        finally
        {
            // close connection
            conn.Close();
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
        
        // Hide elements related to a filter
        removeFilter.Visible = false;
        notFound.Visible = false;
        lblGenre.Visible = false;

        // Reset genre label to null
        lblGenre.Text = "";

        // Now head back to Browse page, resetting the POSTS to null
        Response.Redirect("../Browse/Browse.aspx");
    }
}