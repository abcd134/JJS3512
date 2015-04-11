using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MovieFavorites
/// </summary>
public class MovieFavorites
{
    private int _movieID;
    private string _title;
    private string _posterPath;
    private string _year;
	public MovieFavorites(int movieId, string title, string posterPath, string year)
	{
        MovieID = movieId;
        Title = title;
        PosterPath = posterPath;
        Year = year;
	}
    /// <summary>
    /// Getter and Setter section for th instance variables
    /// </summary>
    public int MovieID 
    {
        get {return _movieID;}
        set { _movieID = value; } 
    }
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public string PosterPath
    {
        get { return _posterPath; }
        set { _posterPath = value; }
    }
    public string Year
    {
        get { return _year; }
        set { _year = value; }
    }
}