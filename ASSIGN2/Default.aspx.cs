using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            initializeDatabases();
        }
    }

    protected void initializeDatabases()
    {
        int theHobbit = 122917;
        Adapter connect = new Adapter(WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString);

        FeaturedRepeater.DataSource = connect.createDataTable(Constants.retrieveMoviesByMovieID(theHobbit));
        FeaturedRepeater.DataBind();
    }
    protected void FeaturedButton1_Click(object sender, EventArgs e)
    {
        int theHobbit = 122917;
        changeRepeaterData(FeaturedRepeater, theHobbit);
        
    }
    protected void FeaturedButton2_Click(object sender, EventArgs e)
    {
        int interstellar = 157336;
        changeRepeaterData(FeaturedRepeater, interstellar);
    }
    protected void FeaturedButton3_Click(object sender, EventArgs e)
    {
        int matrix = 603;
        changeRepeaterData(FeaturedRepeater, matrix);
    }
    protected void FeaturedButton4_Click(object sender, EventArgs e)
    {
        int lionKing = 8587;
        changeRepeaterData(FeaturedRepeater, lionKing);
    }
    protected void FeaturedButton5_Click(object sender, EventArgs e)
    {
        int hungerGames = 131631;
        changeRepeaterData(FeaturedRepeater, hungerGames);
    }

    protected void changeRepeaterData(Repeater repreaterToChange, int movieId)
    {
        Adapter connect = new Adapter(WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString);

        repreaterToChange.DataSource = connect.createDataTable(Constants.retrieveMoviesByMovieID(movieId));
        repreaterToChange.DataBind();
    }
}