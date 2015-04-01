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
        PersonCollection pc = new PersonCollection();
        pc.FetchForId(id);
        if (pc.Count <= 0)
            Response.Redirect("../Error.aspx?error=Person Not Found");
        else
        {
            rptPerson.DataSource = pc;
            rptPerson.DataBind();
        }

        CastCollection cc = new CastCollection();
        cc.FetchForId(id);
        if (cc.Count <= 0)
        {
            // if no other roles, what do we do?
        }
        else
        {
            movieRepeater.DataSource = cc;
            movieRepeater.DataBind();
        }
        CrewCollection cc2 = new CrewCollection();
        cc2.FetchForId(id);
        if (cc2.Count <= 0)
        {
            // if no other jobs, what do we do?
        }
        else
        {
            crewRepeater.DataSource = cc2;
            crewRepeater.DataBind();
        }
    }
}