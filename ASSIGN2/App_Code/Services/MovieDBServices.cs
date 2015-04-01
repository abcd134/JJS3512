using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


/// <summary>
/// Summary description for MovieDBServices
/// </summary>
public class MovieDBServices
{
    public MovieDBServices() { }

    private static string MakeAuthenticationIdQueryString()
    {
        return "?api_key=" + ConfigurationInformation.MovieDBAPI;
    }

    public static string FetchMovie(int movieID)
    {
        string movieLink = "movie/" + movieID;
        return ConfigurationInformation.MovieDBURL + movieLink + MakeAuthenticationIdQueryString();
    }
}