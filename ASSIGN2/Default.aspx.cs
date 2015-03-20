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
    Adapter connect = new Adapter(WebConfigurationManager.ConnectionStrings["Movies"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            initializeDatabases();
            createFeaturedPerson();
            createCarousel();
        }
    }

    protected void initializeDatabases()
    {
        int theHobbit = 122917;

        bindRepeaterData(FeaturedRepeater, connect.createDataTable(Constants.retrieveMoviesByMovieID(theHobbit)));
    }
    protected void FeaturedButton1_Click(object sender, EventArgs e)
    {
        int theHobbit = 122917;
        bindRepeaterData(FeaturedRepeater, connect.createDataTable(Constants.retrieveMoviesByMovieID(theHobbit)));
        
    }
    protected void FeaturedButton2_Click(object sender, EventArgs e)
    {
        int interstellar = 157336;
        bindRepeaterData(FeaturedRepeater, connect.createDataTable(Constants.retrieveMoviesByMovieID(interstellar)));
    }
    protected void FeaturedButton3_Click(object sender, EventArgs e)
    {
        int matrix = 603;
        bindRepeaterData(FeaturedRepeater, connect.createDataTable(Constants.retrieveMoviesByMovieID(matrix)));
    }
    protected void FeaturedButton4_Click(object sender, EventArgs e)
    {
        int lionKing = 8587;
        bindRepeaterData(FeaturedRepeater, connect.createDataTable(Constants.retrieveMoviesByMovieID(lionKing)));
    }
    protected void FeaturedButton5_Click(object sender, EventArgs e)
    {
        int hungerGames = 131631;
        bindRepeaterData(FeaturedRepeater, connect.createDataTable(Constants.retrieveMoviesByMovieID(hungerGames)));
    }

    protected void bindRepeaterData(Repeater repreaterToChange, DataTable dataToBind)
    { 
        repreaterToChange.DataSource = dataToBind;
        repreaterToChange.DataBind();
    }

    // Featured person code

    protected void createFeaturedPerson()
    {
        int[] x = {3896, 140, 72129};
        bindRepeaterData(FeaturedPersonRepeater, connect.createDataTable(Constants.retrieveThreeActors(x[0], x[1], x[2])) );
    }

    protected void createCarousel()
    {
        bindRepeaterData(CarouselRepeater, connect.createDataTable(Constants.retrieveFeaturedMovies()));
    }
    
}