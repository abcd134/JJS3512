using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Services;

public partial class TestForJSON : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UpcomingMovieDA upcoming = new UpcomingMovieDA();
        NowPlayingMovieDA now = new NowPlayingMovieDA();
        MovieTrailersDA trailer = new MovieTrailersDA();

        rptUpComing.DataSource = upcoming.fetchData();
        rptUpComing.DataBind();

        rptNowPlaying.DataSource = now.fetchData();
        rptNowPlaying.DataBind();

        rptTrailer.DataSource = trailer.fetchTrailers(102382);
        rptTrailer.DataBind();

    }
}