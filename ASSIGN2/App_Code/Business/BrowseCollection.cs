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
    /// Summary description for BrowseCollection
    /// </summary>
    public class BrowseCollection : AbstractBusinessCollection<Browse>
    {
        private BrowseDA _da = new BrowseDA();
        public BrowseCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region methods
        /// <summary>
        /// Fetch all the data for all movies
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _da.GetAllMovies();
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the movies for a particular genre
        /// </summary>
        public void FetchForGenre(int genreID)
        {
            DataTable dt = _da.GetGenreFilteredMovies(genreID);
            PopulateFromDataTable(dt);
        }
        public void FetchForSearch(string search)
        {
            DataTable dt = _da.GetSearchFilteredMovies(search);
            PopulateFromDataTable(dt);
        }
        public void FetchForGenreAndSearch(int genreID, string search)
        {
            DataTable dt = _da.GetGenreAndSearchFilteredMovies(genreID, search);
            PopulateFromDataTable(dt);
        }
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Browse a = new Browse();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static BrowseCollection GetAll()
        {
            BrowseCollection list = new BrowseCollection();
            list.FetchAll();

            return list;
        }
        #endregion
    }
}