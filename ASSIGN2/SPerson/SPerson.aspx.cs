using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

public partial class SPerson : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int id;
            if (Request.QueryString["id"] == null) { Response.Redirect("../Error.aspx"); }
            else if (!Int32.TryParse(Request.QueryString["id"], out id)) { Response.Redirect("../Error.aspx"); }
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
        try
        {
            //Instantiate the Adaptor Class and set the query string
            Adapter data = new Adapter(WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString);

            //Displays the Birthplace and image
            imageRepeater.DataSource = data.createDataTable(Constants.retrieveBio(id));
            imageRepeater.DataBind();

            displayPersonBio(data, id);

            //Displays the movies the person participated in as an actor

            movieRepeater.DataSource = data.createDataTable(Constants.retrieveMoviesByPersonID(id));
            movieRepeater.DataBind();


            //Displays the movies the person participated in as an crew

            CrewRepeater.DataSource = data.createDataTable(Constants.retrieveCrew(id));
            CrewRepeater.DataBind();
        }
        catch (Exception e)
        {
            
        }
    }

    protected void displayPersonBio(Adapter data, int id)
    {
        //Displays the Full Biography
        DataTable tempData = data.createDataTable(Constants.retrieveBio(id));
        lblPersonName.Text = tempData.Rows[0]["name"] as String;
        lblBirthdate.Text = tempData.Rows[0]["birthday"] as String;
        lblBio.Text = tempData.Rows[0]["biography"] as String;


    }
}