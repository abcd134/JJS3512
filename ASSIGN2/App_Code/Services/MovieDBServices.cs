using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


/// <summary>
/// Created build the URL link used to pull the API
/// </summary>
public class MovieDBServices
{
    public MovieDBServices() { }
    /// <summary>
    /// Used to add the api key with the ap query string
    /// </summary>
    /// <returns>returs API key and API querystring</returns>
    private static string MakeAuthenticationIdQueryString()
    {
        return "?api_key=" + ConfigurationInformation.MovieDBAPI;
    }
    /// <summary>
    /// used to add the paramenter to fetch movies
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns>retruns a URL buld to fetch the JSON objects</returns>
    public static string FetchMovie(int movieID)
    {
        string link = "movie/" + movieID;
        return ConfigurationInformation.MovieDBURL + link + MakeAuthenticationIdQueryString();
    }
    /// <summary>
    /// used to add the paramenter to fetch upcoming movies
    /// </summary>
    /// <returns>retruns a URL buld to fetch the JSON objects</returns>
    public static string FetchUpcoming()
    {
        string link = "movie/upcoming";
        return ConfigurationInformation.MovieDBURL + link + MakeAuthenticationIdQueryString();
        
    }
}