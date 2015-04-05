using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using content.Services;
using System.Data;

/// <summary>
/// Summary description for APIMovieTrailers
/// </summary>
public class APIMovieTrailers : APIAbstractDA
{
    public override DataTable fetchData(int movieID)
    {
        return DownloadFromAPI<UpcomingMoviesCollection>(MovieDBServices.FetchTrailer(movieID)).getDataTable();
    }
}