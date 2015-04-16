using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using Content.Services;

/// <summary>
/// Summary description for MovieDBDA
/// </summary>
/// 
namespace Content.Services
{
    //Used to retrive upcoming movies from API
    public class UpcomingMovieDA : APIAbstractDA
    {
        /// <summary>
        /// Used to fetch Upcoming movies
        /// </summary>
        /// <returns></returns>
        public override DataTable fetchData()
        {
            DataTable UpcomingPlaying;
            try
            {
                UpcomingPlaying = DownloadFromAPI<MoviesCollection>(MovieAPIServices.FetchUpcoming()).getDataTable();
             }
            catch(Exception ex)
            {
                UpcomingPlaying = null;
                Console.WriteLine(ex.Message);
            }
            return UpcomingPlaying;
        }
        }
    }

