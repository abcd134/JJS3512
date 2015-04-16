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
    /// Summary description for Key Words
    /// </summary>
    public class KeyWords : AbstractBusiness
    {
        private int _movieId;
        private string _keyWordName;
        private MovieKeyWordsDA _movieKeyWordsDA;
        /// <summary>
        /// Key Word Constructor
        /// </summary>
        public KeyWords()
        {
            _movieKeyWordsDA = new MovieKeyWordsDA();
            base.DataAccess = _movieKeyWordsDA;
        }
        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query
            if (row["movie_id"] == DBNull.Value)
                MovieID = -1;  // Error flag set that the movie ID was not found (should be impossible)
            else
                MovieID = (int)Convert.ToInt32(row["movie_ID"]);

            if (row["name"] == DBNull.Value)
                KeyWordName = null;
            else
                KeyWordName = (string)row["name"];

        }
        #region Getters and Setters
        public string KeyWordName
        {
            get { return _keyWordName; }
            set { _keyWordName = value; }
        }

        public int MovieID
        {
            get { return _movieId; }
            set { _movieId = value; }
        }
        #endregion
    }
}