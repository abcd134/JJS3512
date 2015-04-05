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
            throw new NotImplementedException();
        }
        public DataTable fetchTrailer(int movieID)
        {
            return DownloadFromAPI<MoviesCollection>(MovieDBServices.FetchTrailer(movieID)).getDataTable();
        }
    }
}