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

public partial class Favorites : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                PerformDataBinding();
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
    private void PerformDataBinding()
    {
        // Get the current favorite movies from session state or set to null
        MovieFavoritesCollection favMoviesC;
        if (Session["favMoviesC"] != null)
        {
            favMoviesC = (MovieFavoritesCollection)Session["favMoviesC"];
            MovieFavorites lastOneAdded = favMoviesC[favMoviesC.Count - 1];
            // If last entry is a duplicate, remove it
            if (favMoviesC.Count > 1)
            {
                int i = 0;
                while (i < favMoviesC.Count - 2)
                {
                    if(favMoviesC[i].MovieID == lastOneAdded.MovieID)
                    {
                        favMoviesC.RemoveFromCollection(lastOneAdded);
                        break; // can only have 1 duplicate, no need to check further
                    }
                    i++;
                }
            }
        }
        else
        {
            favMoviesC = null;
            notFound.Text = "You don't have any movie favorites";
            notFound.Visible = true;
        }
        favMovies.DataSource = favMoviesC;
        favMovies.DataBind();

        // Get the current favorite people from session state or set to null
        // Will implement once favorite movies is working

         /*       PeopleFavoritesCollection favPeopleC;
                if (Session["favPeopleC"] != null)
                {
                    favPeopleC = (PeopleFavoritesCollection)Session["favPeopleC"];
                }
                else
                {
                    favPeopleC = null;
                }
                favPeople.DataSource = favPeopleC;
                favPeople.DataBind();
          * */
        noPeople.Visible = true;
        noPeople.Text = "You don't have any favorite people yet.";
    }

    /// <summary>
    /// Method to clear search and filter fields and to make
    /// their visisibilty = false.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void remFromFav_Click(object sender, CommandEventArgs e)
    {
        MovieFavoritesCollection favMoviesC;
        if (Session["favMoviesC"] != null)
        {
            favMoviesC = (MovieFavoritesCollection)Session["favMoviesC"];
        }
        else { 
            favMoviesC = new MovieFavoritesCollection();
            notFound.Text = "You don't have any movie favorites";
            notFound.Visible = true;
        }
        if (favMoviesC.Count > 1)
        {
            int i = 0;
            while (i < favMoviesC.Count)
            {
                if (favMoviesC[i].MovieID.ToString() == (string)e.CommandArgument)
                {
                    // found the movie to remove to favorites

                    MovieFavorites movieToRemove;
                    movieToRemove = favMoviesC[i];
                    favMoviesC.RemoveFromCollection(movieToRemove);
                    Session["favMoviesC"] = favMoviesC;
                    // Need to add to the collection then  put in session 
                    Response.Redirect("../Favorites/Favorites.aspx");
                }
                i++;
            }
        }
        else
        {
            favMoviesC = null;
            Session["favMoviesC"] = favMoviesC;
            notFound.Text = "You don't have any movie favorites";
            notFound.Visible =true;
        }
        Response.Redirect("../Favorites/Favorites.aspx");
    }
}