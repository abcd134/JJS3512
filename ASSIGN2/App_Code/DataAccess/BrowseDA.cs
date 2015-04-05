using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Summary description for BrowseDA
/// </summary>
public class BrowseDA : AbstractDA
{
    private const string fields = " person.name, person.person_id,role_name, "+
        " title, overview, poster_path, backdrop_path, release_date, "+
        " tagline, vote_average ";
    protected override string SelectStatement
    {
        get
        {
            return "SELECT " + KeyFieldName + "," + fields
                + " FROM movie, movie_cast, person";
        }
    }

    protected override string OrderFields
    {
        get
        {
            return " release_date ";
        }
    }

    protected override string KeyFieldName
    {
        get
        {
            return "movie.movie_id";
        }
    }
    /// <summary>
    /// Returns a data table of all movies sorted by release date
    /// </summary>
    /// <returns></returns>
    public DataTable GetAllMovies()
    {
        string sql = SelectStatement + "  WHERE "
                                     + " movie_cast.movie_id = movie.movie_id AND "
                                     + " movie_cast.person_id = person.person_id AND "
                                     + " movie_cast.ordering = 0 "
                                     + " ORDER BY " + OrderFields + dataOrder(false);
        return DataHelper.GetDataTable(sql, null);
    }

    public DataTable GetGenreFilteredMovies(int genreID)
    {
        string sql = SelectStatement + " ,genre, movie_genre " + " WHERE genre.genre_id=" + genreID + " AND "
                                     + " movie.movie_id =  movie_genre.movie_id AND "
                                     + " movie_genre.genre_id = genre.genre_id AND "
                                     + " movie_cast.movie_id = movie.movie_id AND "
                                     + " movie_cast.person_id = person.person_id AND "
                                     + " movie_cast.ordering = 0 "
                                     + " ORDER BY " + OrderFields + dataOrder(false);
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("genre.genre_id", genreID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }

    public DataTable GetSearchFilteredMovies(string search)
    {
        string sql = SelectStatement + " WHERE movie_cast.movie_id = movie.movie_id AND "
                                     + " movie_cast.person_id = person.person_id AND "
                                     + " movie_cast.ordering = 0 AND "
                                     + " movie.title LIKE '%" + search + "%' "
                                     + " ORDER BY " + OrderFields + dataOrder(false);
        return DataHelper.GetDataTable(sql, null);
    }

    public DataTable GetGenreAndSearchFilteredMovies(int genreID, string search)
    {
        string sql = SelectStatement + " , genre, movie_genre WHERE genre.genre_id=" + genreID + " AND "
                                     + " movie_cast.movie_id = movie.movie_id AND "
                                     + " movie_cast.person_id = person.person_id AND "
                                     + " movie_cast.ordering = 0 AND "
                                     + " movie_genre.genre_id = genre.genre_id AND "
                                     + " movie_genre.movie_id = movie.movie_id AND "
                                     + " movie.title LIKE '%" + search + "%' "
                                     + " ORDER BY " + OrderFields + dataOrder(false);
        return DataHelper.GetDataTable(sql, null);
    }

    private string dataOrder(bool ISAscending)
    {
        if (ISAscending) return "ASC";
        else return "DESC";
    }
}