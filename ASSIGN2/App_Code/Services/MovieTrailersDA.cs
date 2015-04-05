using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Services;
using System.Data;
using Content.Services;
/// <summary>
/// Summary description for APIMovieTrailers
/// </summary>
namespace Content.Services
{
    public class MovieTrailersDA : APIAbstractDA
    {
        public override DataTable fetchData()
        {
            return null;
        }
        public DataTable fetchTrailers(int movieID)
        {
            return DownloadFromAPI<MovieTrailersCollection>(MovieDBServices.FetchTrailer(movieID)).getDataTable();
        }
    }
}