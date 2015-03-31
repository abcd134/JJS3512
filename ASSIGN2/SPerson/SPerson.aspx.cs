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
                PersonCollection ac = new PersonCollection();
                ac.FetchForId(id);
                if (ac.Count <= 0)
                    Response.Redirect("../Error.aspx?error=Person Not Found");
                else
                {
                    rptPerson.DataSource = ac;
                    rptPerson.DataBind();

                    /*
                    // display the information for this person
                    viewWorks.DataSource = ac[0].Works;
                    viewWorks.DataBind();
                    */
                }
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
        try
        {
            //Instantiate the Adaptor Class and set the query string
            Adapter data = new Adapter(WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString);

            DataTable dt = data.createDataTable(Constants.retriveAllPerson(id));

            //if the rowcount is zero go to error page
            if (dt == null) { Response.Redirect("../Error.aspx"); }

            displayPersonInfo(data, id);
            if (data.createDataTable(Constants.retrieveBio(id)).Rows[0]["biography"].ToString() != "")
            {
                BioRepeater.DataSource = data.createDataTable(Constants.retrieveBio(id));
                BioRepeater.DataBind();
            }


            //Displays the movies the person participated in as an actor

            movieRepeater.DataSource = data.createDataTable(Constants.retrieveMoviesByPersonID(id));
            movieRepeater.DataBind();


            //Displays the movies the person participated in as an crew

            CrewRepeater.DataSource = data.createDataTable(Constants.retrieveCrew(id));
            CrewRepeater.DataBind();
        }
        catch (Exception ex)
        {
            Response.Redirect("../Error.aspx?error=" + Convert.ToString(ex.Message));
        }
    }

    protected void displayPersonInfo(Adapter data, int id)
    {
        //Displays the Full Biography
        DataTable tempData = data.createDataTable(Constants.retriveAllPerson(id));
        // lblPersonName.Text = tempData.Rows[0]["name"] as String;
        string bday = tempData.Rows[0]["birthday"] as String;
        string dday = tempData.Rows[0]["deathday"] as String;
        string birthPlace = tempData.Rows[0]["birth_place"] as String;
        string homePage = tempData.Rows[0]["home_page"] as String;

        if (checkData(bday))
        {
            //lblBirthdate.Text = "Birth Date: " + bday;
        }

        if (checkData(dday))
        {
            //lblDeathdate.Text = "Death Date: " + dday;
        }

        //lblBirthPlace.Text = birthPlace;

        if (checkData(homePage))
        {
            HyperLink1.NavigateUrl = homePage;
        }
           
        if ((tempData.Rows[0]["profile_path"] as String) != null)
        {
            string profilePic = "http://image.tmdb.org/t/p/w300/" + tempData.Rows[0]["profile_path"] as String;
            imgProfilePic.ImageUrl = profilePic;
            imgProfilePic2.ImageUrl = profilePic;
        }

    }

    protected bool checkData(string x)
    {
        if (x == null || x == "")
        {
            return false;
        }
        return true;
    }
}