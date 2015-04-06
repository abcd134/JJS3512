using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Summary description for Genre
    /// </summary>
    public class Genre : AbstractBusiness
    {
        private int _genreID;
        private string _genreName;
        private GenreDA _genreDA;

        public Genre()
        {
            _genreDA = new GenreDA();
            base.DataAccess = _genreDA;
        }
        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            if (row["name"] == DBNull.Value)
                GenreName = "";
            else
                GenreName = (string)row["name"];

            if (row["genre_id"] == DBNull.Value)
                GenreID = -1;  // Error flag set that the movie ID was not found (should be impossible)
            else
                GenreID = (int)Convert.ToInt32(row["genre_ID"]);
        }

        public int GenreID
        {
            get { return _genreID; }
            set { _genreID = value; }
        }

        public string GenreName
        {
            get { return _genreName; }
            set { _genreName = value; }
        }
    }
}