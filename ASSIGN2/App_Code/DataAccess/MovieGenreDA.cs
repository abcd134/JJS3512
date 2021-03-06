﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Used to retrieve the list of genre for SMovie
/// </summary>
/// 
namespace Content.DataAccess
{
    public class MovieGenreDA : AbstractDA
    {
        private const string fields = ", name";
        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + KeyFieldName + fields + " FROM (movie_genre INNER JOIN genre ON movie_genre.genre_id = genre.genre_id)";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "name";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "genre.genre_id";
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