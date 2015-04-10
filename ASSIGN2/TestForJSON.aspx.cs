using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Services;
using Content.Business;
using Content.DataAccess;
public partial class TestForJSON : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //UpcomingMovieDA upcoming = new UpcomingMovieDA();
        //NowPlayingMovieDA now = new NowPlayingMovieDA();
        //MovieTrailersDA trailer = new MovieTrailersDA();

        //rptUpComing.DataSource = upcoming.fetchData();
        //rptUpComing.DataBind();

        //rptNowPlaying.DataSource = now.fetchData();
        //rptNowPlaying.DataBind();

        //rptTrailer.DataSource = trailer.fetchTrailers(102382);
        //rptTrailer.DataBind();

        MovieImageCollection backDropC = new MovieImageCollection();
        backDropC.FetchForMovieId(122917, false);
        if (backDropC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Back Drop images Found");
        else
        {
            Backdrop.DataSource = backDropC;
            Backdrop.DataBind();
        }


        MovieImageCollection posterC = new MovieImageCollection();
        posterC.FetchForMovieId(122917, true);
        if (posterC.Count <= 0)
            Response.Redirect("../Error.aspx?error=No Poster images Found");
        else
        {
            rptPosters.DataSource = posterC;
            rptPosters.DataBind();
        }

        ReviewDA asd = new ReviewDA();
        Repeater1.DataSource = asd.fetchReviewByMovieID(605);
        Repeater1.DataBind();

    }
    protected void btnReviewSubmit_Click(object sender, EventArgs e)
    {

    }
}