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

        private const string fields = "name,birthday,deathday,birth_place,biography,profile_path,home_page";

        protected override string SelectStatement
        {
            get
            {
                return "SELECT " + KeyFieldName + "," + fields + " FROM Person";
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
                return "person_id";
            }
        }

        /// <summary>
        /// Returns a data table containing SinglePerson table info for this exact name.
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
        public DataTable GetByPersonID(int personID)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE person_Id=@ID";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@ID", personID, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
    }
}