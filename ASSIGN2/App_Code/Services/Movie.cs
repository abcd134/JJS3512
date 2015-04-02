using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


/// <summary>
/// The movie.cs class is class used to store the data after parsing the Json Object
/// </summary>
public class Movie
{
    #region
    [JsonProperty("backdrop_path")]
    public string Backdrop_path
    {
        get;
        set;
    }
    [JsonProperty("id")]
    public int Id
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
    public string Release_date
    {
        get;
        set;
    }
     [JsonProperty("poster_path")]
    public string Poster_path
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
    public double Vote_average
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