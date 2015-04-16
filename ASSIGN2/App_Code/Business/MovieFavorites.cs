﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Business;
using System.Data;
using System.Data.Common;


/// <summary>
/// Summary description for MovieFavorites
/// </summary>
public class MovieFavorites : AbstractBusiness
{
    private int _movieID;
    private string _title;
    private string _posterPath;
    private string _year;
    /// <summary>
    /// Movie Favorites Object Constructor
    /// </summary>
    /// <param name="movieId"></param>
    /// <param name="title"></param>
    /// <param name="posterPath"></param>
    /// <param name="year"></param>
	public MovieFavorites(int movieId, string title, string posterPath, string year)
	{
        MovieID = movieId;
        Title = title;
        PosterPath = posterPath;
        Year = year;
	}
    public override void PopulateDataMembersFromDataRow(DataRow row)
    {
        MovieID = (int) row["movieId"];
        Title = (string) row["title"];
        PosterPath = (string) row["posterPath"];
        Year = (string) row["year"];
    }
    #region Getters and Setters
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
    #endregion
}