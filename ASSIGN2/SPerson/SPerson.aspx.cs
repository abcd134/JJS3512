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
}