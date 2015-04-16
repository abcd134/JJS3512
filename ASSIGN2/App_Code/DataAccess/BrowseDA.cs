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
        " movie.title, overview, poster_path, backdrop_path, release_date, "+
        " tagline, vote_average ";
    protected override string SelectStatement
    {
        get
        {
            return "SELECT " + KeyFieldName + "," + fields;
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
            return "distinct(movie.movie_id)";
        }
    }
    /// <summary>
    /// Returns a data table of all movies sorted by release date
    /// </summary>
    /// <returns></returns>
    public DataTable GetAllMovies()
    {
        string sql = SelectStatement + " FROM movie, movie_cast, person WHERE "
                                     + " movie_cast.movie_id = movie.movie_id AND "
                                     + " movie_cast.person_id = person.person_id AND "
                                     + " movie_cast.ordering = 0 "
                                     + " ORDER BY " + OrderFields + dataOrder(false);
        return DataHelper.GetDataTable(sql, null);
    }
    /// <summary>
    /// Returns the filtered movies based on the genre ID
    /// </summary>
    /// <param name="genreID"></param>
    /// <returns></returns>
    public DataTable GetGenreFilteredMovies(int genreID)
    {
        string sql = SelectStatement + " FROM movie, movie_cast, person ,genre, movie_genre " 
                                     + " WHERE genre.genre_id=" + genreID + " AND "
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

    public DataTable GetSearchFilteredMovies(string search, string searchBy)
    {
        string sql = SelectStatement + " FROM movie, movie_cast, person ";
               sql+= getOtherTables(searchBy);
               sql+= " WHERE movie_cast.movie_id = movie.movie_id AND "
                  +  " movie_cast.person_id = person.person_id AND "
                  +  " movie_cast.ordering = 0 AND ";
        sql += getSearchBySql(search, searchBy);
        sql += " ORDER BY " + OrderFields + dataOrder(false);
        return DataHelper.GetDataTable(sql, null);
    }

    public DataTable GetGenreAndSearchFilteredMovies(int genreID, string searchFor, string searchBy)
    {
        string sql  = SelectStatement + " FROM movie, movie_cast, person, genre, movie_genre ";
               sql += getOtherTables(searchBy);
               sql +=" WHERE genre.genre_id=" + genreID + " AND "
                   + " movie_cast.movie_id = movie.movie_id AND "
                   + " movie_cast.person_id = person.person_id AND "
                  
                   + " movie_genre.genre_id = genre.genre_id AND "
                   + " movie_genre.movie_id = movie.movie_id AND "
                    + " movie_cast.ordering = 0 AND ";

        sql += getSearchBySql(searchFor, searchBy);                         
        sql += " ORDER BY " + OrderFields + dataOrder(false);
        return DataHelper.GetDataTable(sql, null);
    }

    private string dataOrder(bool ISAscending)
    {
        if (ISAscending) return "ASC";
        else return "DESC";
    }
    private string getOtherTables(string searchBy)
    {
        string sqlPiece="";
        if (searchBy == "Company")
        {
            sqlPiece += ", company, movie_company ";
        }
        else if (searchBy == "Key Word")
        {
            sqlPiece += ", movie_keyword, keyword ";
        }
        else
        {
            sqlPiece += " ";
        }
        return sqlPiece;
    }
    private string getSearchBySql(string searchFor, string searchBy)
    {
        string sqlPiece ="";
        if (searchBy == "Company")
        {
            sqlPiece += " movie_company.company_id = company.company_id AND "
                + " movie_company.movie_id = movie.movie_id AND "
                + " company.company_name LIKE '%" + searchFor + "%' ";
        }
        else if (searchBy == "Key Word")
        {
            sqlPiece += " movie_keyword.keyword_id = keyword.keyword_id AND "
                + " movie_keyword.movie_id = movie.movie_id AND "
                + " keyword.name LIKE '%" + searchFor + "%' ";
        }
        else
        {
            sqlPiece += " movie.title LIKE '%" + searchFor + "%' ";
        }
        return sqlPiece;
    }
}