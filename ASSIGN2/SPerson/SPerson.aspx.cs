using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Web.Configuration;
using Content.Business;

public partial class SPerson : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int id;
            if (Request.QueryString["id"] == null) { Response.Redirect("../Error.aspx?error=Null Query String"); }
            else if (!Int32.TryParse(Request.QueryString["id"], out id)) { Response.Redirect("../Error.aspx?error=Invalid Query String"); }
            else
            {
                DisplayPerson(id);
            }
        }
    }

    /// <summary>
    /// Displays all the relevant data for SPerson
    /// </summary>
    /// <param name="id"></param> - ID pulled from query string. ID is use to indentify the person to display in the page
    protected void DisplayPerson(int id)
    {
        PersonCollection personC = new PersonCollection();
        personC.FetchForId(id);
        if (personC.Count <= 0)
            Response.Redirect("../Error.aspx?error=Person Not Found");
        else
        {
            rptPerson.DataSource = personC;
            rptPerson.DataBind();
        }

        Session["PersonCollection"] = personC;

        // Getting information about acting jobs this person
        // has had.  If none, no data is bound so header doesn't
        // show up.
        CastCollection castC = new CastCollection();
        castC.FetchForMovies(id);
        if (castC.Count > 0)
        {
            movieRepeater.DataSource = castC;
            movieRepeater.DataBind();
        }

        // Getting information about non acting jobs this person
        // has had.  If none, no data is bound so header doesn't
        // show up.
        CrewCollection crewC = new CrewCollection();
        crewC.FetchForId(id);
        if (crewC.Count > 0)
        {
            crewRepeater.DataSource = crewC;
            crewRepeater.DataBind();
        }
    }

    public void addToFav_Click(object sender, CommandEventArgs e)
    {
        // Getting the favorite people collection from session stat if it exists
        PeopleFavoritesCollection favPeopleC;
        if (Session["favPeopleC"] != null)
        {
            favPeopleC = (PeopleFavoritesCollection)Session["favPeopleC"];
        }
        else { favPeopleC = new PeopleFavoritesCollection(); }

        // Getting information about current person from session state if it 
        // exists, other wise sending user to error page with timed out message.
        PersonCollection personC;
        if (Session["PersonCollection"] == null)
        {
            Response.Redirect("../Error.aspx?error=Sorry, you timed out.  Please browse again.");
        }
        personC = (PersonCollection)Session["PersonCollection"];
        int i = 0;

        // Getting information required for the person from the person collection
        while (i < personC.Count)
        {
            if (personC[i].ID.ToString() == (string)e.CommandArgument)
            {
                // found the person to add to favorites
                PeopleFavorites personToAdd;
                personToAdd = personC[i].MakePersonInstance();

                // Need to add to the collection then  put in session 
                favPeopleC.Add(personToAdd);
                Session["favPeopleC"] = favPeopleC;
                Response.Redirect("../Favorites/Favorites.aspx");
            }
            i++;
        }
    }
}