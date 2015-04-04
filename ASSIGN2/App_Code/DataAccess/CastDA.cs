using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Summary description for Cast
/// </summary>
public class CastDA : AbstractDA
{
    private const string fields = " person.person_id, person.profile_path, person.name, movie.title, movie_cast.role_name";
    protected override string SelectStatement
    {
        get
        {
            return "SELECT " + KeyFieldName + "," + fields + " FROM  person, movie_cast, movie " +
                " WHERE movie.movie_id = movie_cast.movie_id AND " +
                " movie_cast.person_id = person.person_id ";
        }
    }

    protected override string OrderFields
    {
        get
        {
            return " movie_cast.ordering ";
        }
    }

    protected override string KeyFieldName
    {
        get
        {
            return "movie.movie_id";
        }
    }

    public DataTable GetByMovieID(int movieID)
    {
        string sql = SelectStatement + " AND movie.movie_id=@id  ORDER BY " + OrderFields + dataOrder(true);
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", movieID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }
    public DataTable GetMovies(int personID)
    {
        string sql = SelectStatement + " AND person.person_id=" + personID + " ORDER BY " + OrderFields + dataOrder(true);
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("person.person_id", personID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }
    private string dataOrder(bool ISAscending)
    {
        if (ISAscending) return "ASC";
        else return "DESC";
    }
}