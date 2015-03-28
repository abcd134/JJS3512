﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for PersonDA
    /// </summary>
    public class MovieDA : AbstractDA
    {
        private const string fields = ""; // Need to complete this line
        protected override string SelectStatement  // need to complete this select statement
        {
            get
            {
                string sql = "SELECT " + fields + " FROM ArtWorks";
                sql += " INNER JOIN  Artists ON ArtWorks.ArtistId = Artists.ArtistId";
                return sql;
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "release_date DESC";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "movieID";
            }
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for this exact title.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetLikeTitle(string title)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE Title=@title";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@title", "%" + title + "%", DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }


        /// <summary>
        /// Returns a data table containing Movies the person did something
        /// Note that this data set will contain either 0,1, or N rows of data.
        /// </summary>
        public DataTable GetByPerson(int personId)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE ArtWorks.ArtistID=@artistid"; // need to clean this up
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
                DataHelper.MakeParameter("@artistid", personId, DbType.Int32)
            };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

    }
}