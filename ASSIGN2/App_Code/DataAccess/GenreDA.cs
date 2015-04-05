using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Summary description for GenreDA
/// </summary>
public class GenreDA : AbstractDA
{
    private const string fields = " movie.movie_id, genre.genre_id, genre.name";
    protected override string SelectStatement
    {
        get
        {
            return "SELECT " + KeyFieldName + "," + fields
                + " FROM movie, movie_genre, genre ";       
        }
    }

    protected override string OrderFields
    {
        get
        {
            return " genre.name ";
        }
    }

    protected override string KeyFieldName
    {
        get
        {
            return "movie.movie_id";
        }
    }

    public DataTable GetGenresByMovieID(int movieID)
    {
        string sql = SelectStatement + " WHERE movie.movie_id=@id  AND "
                                     + " movie.movie_id =  movie_genre.movie_id AND "
                                     + " movie_genre.genre_id = genre.genre_id " 
                                     + " ORDER BY " + OrderFields + dataOrder(false);
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", movieID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }
    public DataTable GetGenreNames()
    {
        string sql = "Select name, genre_id from genre";
        return DataHelper.GetDataTable(sql, null);
    }
    private string dataOrder(bool ISAscending)
    {
        if (ISAscending) return "ASC";
        else return "DESC";
    }
}