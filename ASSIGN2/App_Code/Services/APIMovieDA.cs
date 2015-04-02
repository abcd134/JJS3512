using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using content.Services;

/// <summary>
/// Summary description for MovieDBDA
/// </summary>
/// 
namespace content.Services
{
    //Used to retrive upcoming movies from API
    public class APIMovieDA : APIAbstractDA
    {
        /// <summary>
        /// Used to fetch Upcoming movies
        /// </summary>
        /// <returns></returns>
        public override DataTable fetchData()
        {
            return DownloadFromAPI<UpcomingMoviesCollection>(MovieDBServices.FetchUpcoming()).getDataTable();
        }
    }
}
