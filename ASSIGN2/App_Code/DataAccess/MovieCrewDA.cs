using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Used to retrieve the Crew for SMovie
/// </summary>
/// 

namespace Content.DataAccess
{
    public class MovieCrewDA : AbstractDA
    {
        private const string fields = ", movie_crew.movie_crew_id, movie_crew.person_id, person.profile_path, movie_crew.department, person.name";
        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + KeyFieldName + fields + " FROM (movie_crew INNER JOIN person ON movie_crew.person_id = person.person_id)";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "movie_crew.department";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "movie_crew.movie_id";
            }
        }

        /// <summary>
        /// Retrive movie using movie id adn returns it by order
        /// </summary>
        public DataTable GetByMovieID(int movieId)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE movie_id=@movie_id ";
            sql = "ORDER BY " + OrderFields;
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@movie_id", movieId, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
    }
}
