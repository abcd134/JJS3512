using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for KeyWordsCollection
    /// </summary>
    public class KeyWordsCollection : AbstractBusinessCollection<KeyWords>
    {
        private MovieKeyWordsDA _da = new MovieKeyWordsDA();
        public KeyWordsCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region methods
        /// <summary>
        /// Fetch all the data where the person was part of the crew
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _da.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the key words for a given movie id. 
        /// This should normally create a collection 
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _da.GetByMovieID(id);
            PopulateFromDataTable(dt);
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                KeyWords a = new KeyWords();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static GenreCollection GetAll()
        {
            GenreCollection list = new GenreCollection();
            list.FetchAll();

            return list;
        }
        #endregion
    }
}