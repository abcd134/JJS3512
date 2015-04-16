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
    private const string fields = " person.profile_path, person.name, person.person_id, movie_crew.department, movie_crew.job, movie.title";
    protected override string SelectStatement
    {
        get
        {
            return "SELECT " + KeyFieldName + "," + fields 
                + " FROM movie_crew, person, movie " +
                " WHERE person.person_id=movie_crew.person_id AND " +
                " movie_crew.movie_id = movie.movie_id ";
        }
    }

    protected override string OrderFields
    {
        get
        {
            return " movie_crew.department ";
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
    /// used to fetch the movies based on the person
    /// </summary>
    /// <param name="personID"></param>
    /// <returns></returns>
    public DataTable GetMoviesByPersonID(int personID)
    {
        string sql = SelectStatement + " AND person.person_id=" + personID + " ORDER BY " + OrderFields + dataOrder(true);
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", personID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }
    /// <summary>
    /// returns the crew for the specific movie
    /// </summary>
    /// <param name="movieID"></param>
    /// <returns></returns>
    public DataTable GetByMovieID(int movieID)
    {
        string sql = SelectStatement + " AND movie.movie_id=@id  ORDER BY " + OrderFields + dataOrder(true);
        DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", movieID, DbType.String)
        };
        return DataHelper.GetDataTable(sql, parameters);
    }
    // toogls the data order for "orderby"
    private string dataOrder(bool ISAscending)
    {
        if (ISAscending) return "ASC";
        else return "DESC";
    }
}