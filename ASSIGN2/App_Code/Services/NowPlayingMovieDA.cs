using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Services;
using System.Data;
/// <summary>
/// used to interface and get the now playing liist
/// </summary>
namespace Content.Services
{
    public class NowPlayingMovieDA : APIAbstractDA
    {
        /// <summary>
        /// Retrieves all the data for now playing
        /// </summary>
        /// <returns></returns>
        public override DataTable fetchData()
        {
            return DownloadFromAPI<MoviesCollection>(MovieDBServices.FetchNowPlaying()).getDataTable();
        }
    }
}