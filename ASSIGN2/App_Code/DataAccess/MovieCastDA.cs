
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Used to retrieve the cast for SMovie
/// </summary>
/// 

namespace Content.DataAccess
{
    public class MovieCastDA : AbstractDA
    {
        private const string fields = ", person.name, person.person_id, movie_cast.ordering, movie_cast.role_name, person.profile_path";
        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + KeyFieldName + fields + " FROM (person INNER JOIN movie_cast ON movie_cast.person_id = person.person_id)";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "movie_cast.ordering";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "movie_cast.movie_id";
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
