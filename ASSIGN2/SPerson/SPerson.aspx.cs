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
    PersonCollection _personC;
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
            PersonC = personC;
        }

        Session["PersonCollection"] = personC;

        CastCollection castC = new CastCollection();
        castC.FetchForMovies(id);
        if (castC.Count <= 0)
        {
            // if no other roles, what do we do?
        }
        else
        {
            movieRepeater.DataSource = castC;
            movieRepeater.DataBind();
        }
        CrewCollection crewC = new CrewCollection();
        crewC.FetchForId(id);
        if (crewC.Count <= 0)
        {
            // if no other jobs, what do we do?
        }
        else
        {
            crewRepeater.DataSource = crewC;
            crewRepeater.DataBind();
        }
    }

    public void addToFav_Click(object sender, CommandEventArgs e)
    {
        PeopleFavoritesCollection favPeopleC;
        if (Session["favPeopleC"] != null)
        {
            favPeopleC = (PeopleFavoritesCollection)Session["favPeopleC"];
        }
        else { favPeopleC = new PeopleFavoritesCollection(); }
        PersonCollection personC;
        if (Session["PersonCollection"] != null)
        {
            personC = (PersonCollection)Session["PersonCollection"];
        }
        else
        {
            personC = PersonC;  // refresh data on timeout without requerying database.
        }
        if (personC.Count > 0)
        {
            int i = 0;
            while (i < personC.Count)
            {
                if (personC[i].ID.ToString() == (string)e.CommandArgument)
                {
                    // found the person to add to favorites

                    PeopleFavorites personToAdd;
                    personToAdd = personC[i].MakePersonInstance();
                    favPeopleC.Add(personToAdd);
                    Session["favPeopleC"] = favPeopleC;
                    // Need to add to the collection then  put in session 
                    Response.Redirect("../Favorites/Favorites.aspx");
                }
                i++;
            }
        }
    }
    public PersonCollection PersonC
    {
        get { return _personC; }
        set { _personC = value; }
    }

}