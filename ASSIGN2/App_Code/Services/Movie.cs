using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Content.Services;

/// <summary>
///  Data Transfer Object for Movies
/// The movie.cs class is class used to store the data after parsing the Json Object
/// </summary>
namespace Content.Services
{
    public class Movie
    {
        #region Getters and Setters
        [JsonProperty("backdrop_path")]
        public string Backdrop_path
        {
            get;
            set;
        }
        [JsonProperty("id")]
        public int MovieId
        {
            get;
            set;
        }
        [JsonProperty("original_title")]
        public string Original_title
        {
            get;
            set;
        }
        [JsonProperty("release_date")]
        public string ReleaseDate
        {
            get;
            set;
        }
        [JsonProperty("poster_path")]
        public string PosterPath
        {
            get;
            set;
        }
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }
        [JsonProperty("popularity")]
        public double Popularity
        {
            get;
            set;
        }
        [JsonProperty("vote_average")]
        public double Average
        {
            get;
            set;
        }
        [JsonProperty("vote_count")]
        public double Vote_count
        {
            get;
            set;
        }
        #endregion
    }

}