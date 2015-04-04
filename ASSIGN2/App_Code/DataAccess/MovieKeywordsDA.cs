﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

/// <summary>
/// Used to retrieve the list of keywords for SMovie
/// </summary>
/// 

namespace Content.DataAccess
{
    public class MovieKeyWordsDA : AbstractDA
    {
        private const string fields = "";
        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + KeyFieldName + fields 
                + " FROM movie_keyword.keyword= keyword_keyword AND keyword.keyword_id = movie_keyword.keyword_id";
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
                return "name";
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