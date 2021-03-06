﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Services;
using System.Data;
using Content.Services;
/// <summary>
/// Used to interface with JSON elements
/// </summary>
namespace Content.Services
{
    public class MovieTrailersDA : APIAbstractDA
    {
        //this method needs to be deleted
        public override DataTable fetchData()
        {
            return null;
        }
        /// <summary>
        /// Used to fetch the trailer link of a specific movie id
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        public DataTable fetchTrailers(int movieID)
        {
            return DownloadFromAPI<MovieTrailersCollection>(MovieDBServices.FetchTrailer(movieID)).getDataTable();
        }

        public bool  checkIfTrailerExists(int movieID)
        {
            if (DownloadFromAPI<MovieTrailersCollection>(MovieDBServices.FetchTrailer(movieID)).MoviesTrailer == null || DownloadFromAPI<MovieTrailersCollection>(MovieDBServices.FetchTrailer(movieID)).MoviesTrailer.ToString() == "")
            {
                return true;
            }
            else return false;

        }
    }
}