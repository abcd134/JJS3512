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
    private const string fields = " movie.title, movie_cast.role_name";
    protected override string SelectStatement
    {
        get
        {
            return "SELECT " + KeyFieldName + "," + fields + " FROM  ((movie INNER JOIN movie_cast ON movie.movie_id = movie_cast.movie_id) INNER JOIN person ON movie_cast.person_id = person.person_id) ";
        }
    }

    protected override string OrderFields
    {
        get
        {
            return " movie.release_date ";
        }
    }

    protected override string KeyFieldName
    {
        get
        {
            return "movie.movie_id";
        }
    }

    public DataTable GetCrewByMovieID(int personID)
    {
        string sql = SelectStatement + " WHERE personid=@id  ORDER BY " + OrderFields + dataOrder(false) ;
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", personID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }

    private string dataOrder (bool ISAscending)
    {
        if (ISAscending) return "ASC";
        else return "DESC";
    }
}