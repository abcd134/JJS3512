using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Use to fetch all the data related to moves db
    /// </summary>
    public class MovieDA : AbstractDA
    {
        private const string fields = "person.name, person.person_id,role_name,movie.movie_id,imdb_id, title, overview, poster_path, backdrop_path, release_date, revenue, budget, runtime, tagline, vote_average, vote_count";
        protected override string SelectStatement 
        {
            get
            {
                string sql = "SELECT " + fields + " FROM Movie, movie_cast, person";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "movie_image_id";
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
        /// Retrives the movies based on the title
        /// </summary>
        public DataTable GetLikeTitle(string title)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE Title=@title";
            sql += " AND movie_cast.movie_id = movie.movie_id AND ";
            sql += "movie_cast.person_id = person.person_id AND ";
            sql += "movie_cast.ordering = 0 ";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@title", "%" + title + "%", DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }


        /// <summary>
        /// Retrive movie using movie id
        /// </summary>
        public DataTable GetByMovieID(int movieId)
        {
            // set up parameterized query statement
            string  sql = SelectStatement + " WHERE movie.movie_id=@movie_id";
                    sql += " AND movie_cast.movie_id = movie.movie_id AND ";
                    sql += "movie_cast.person_id = person.person_id AND ";
                    sql += "movie_cast.ordering = 0 ";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@movie_id", movieId, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

    }
}