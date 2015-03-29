using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

using Content.DataAccess;

namespace Content.DataAccess
{
    /// <summary>
    /// Summary description for PersonDA
    /// </summary>
    public class PersonDA : AbstractDA
    {

        private const string fields = "FirstName,LastName,LastName + ', ' + Firstname As FullName,Nationality,YearOfBirth,YearOfDeath,Details,Link";
        //private const string fields = "FirstName,LastName,Nationality,YearOfBirth,YearOfDeath,Details,Link";

        protected override string SelectStatement
        {
            get
            {
                return "SELECT " + KeyFieldName + "," + fields + " FROM Movies";
            }
        }

        protected override string OrderFields
        {
            get
            {
                return "LastName";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "PersonID";
            }
        }

        /// <summary>
        /// Returns a data table containing Artist table info for this exact name.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetByName(string name)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE LastName=@name";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", name, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }


        /// <summary>
        /// Returns a data table containing Artist table info that is similar to this title.
        /// </summary>
        public DataTable GetLikeName(string name)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE LastName Like @name";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", "%" + name + "%", DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        public void DeleteAllArtists()
        {
            //string sql = "DELETE FROM Artists ";
            //DataHelper.RunNonQuery(sql, null, CommandType.Text);
        }

        public int InsertArtist(string mbid, string name, string summary, string description)
        {
            //DbParameter[] parameters = new DbParameter[] {
            //    DataHelper.MakeParameter("@mbid", mbid),
            //    DataHelper.MakeParameter("@name", name),
            //    DataHelper.MakeParameter("@summary", summary),
            //    DataHelper.MakeParameter("@description", description)              
            //};

            //construct SQL
            //string sql = "INSERT INTO Artists (mbid, name, summary, description) VALUES (@mbid, @name,@summary, @description)";
            //int artistId = DataHelper.RunNonQuery(sql, parameters, CommandType.Text, true);
            return 0;
        }

    }
}