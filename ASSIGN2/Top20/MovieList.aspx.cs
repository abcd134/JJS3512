using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Services;

public partial class MovieList : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if not postback then display the single movie
        if (!IsPostBack)
        {
            //does an if check to see if the Querystring id is equal to null if it is redirect to error.aspx 
            if (Request.QueryString["type"] == null) { Response.Redirect("../Error.aspx?error=movie list query string null error"); }
            string type = Request.QueryString["type"];

            if (type == "nowplaying")
                buildNowPlayingRepeater();
            else if (type == "upcoming")
                buildUpcomingRepeater();
            else Response.Redirect("../Error.aspx?error=Request Type unknown");
        }

       
    }

    private void buildUpcomingRepeater()
    {
        lblTitle.Text = "Upcoming Movies";
        UpcomingMovieDA upcoming = new UpcomingMovieDA();
        layout.DataSource = upcoming.fetchData();
        layout.DataBind();
    }

    private void buildNowPlayingRepeater()
    {
        lblTitle.Text = "Now Playing Movies";
        NowPlayingMovieDA now = new NowPlayingMovieDA();
        layout.DataSource = now.fetchData();
        layout.DataBind();
    }
}