using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Summary description for CrewDA
/// </summary>
public class CrewDA : AbstractDA
{
// SELECT movie_crew.person_id, movie_crew.department, movie_crew.job, movie_crew.movie_id, movie.title, person.name
// FROM  ((movie_crew INNER JOIN
//       movie ON movie_crew.movie_id = movie.movie_id) INNER JOIN
//       person ON movie_crew.person_id = person.person_id)
// WHERE  (person.person_id = 1387385)


    private const string fields = " movie_crew.person_id, movie_crew.department, movie_crew.job, movie.title";
    protected override string SelectStatement
    {
        get
        {
            return "SELECT " + KeyFieldName + "," + fields 
                + " FROM movie_crew INNER JOIN movie ON movie_crew.movie_id = movie.movie_id";
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
            return "movie_crew.movie_id";
        }
    }

    public DataTable GetMoviesByPersonID(int personID)
    {
        string sql = SelectStatement + " WHERE person_id=@id  ORDER BY " + OrderFields + dataOrder(false);
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", personID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }

    private string dataOrder(bool ISAscending)
    {
        if (ISAscending) return "ASC";
        else return "DESC";
    }
}