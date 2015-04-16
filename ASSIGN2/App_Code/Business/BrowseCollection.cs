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
        /// <summary>
        /// Browse collection  constructor
        /// </summary>
        public BrowseCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region methods
        /// <summary>
        /// Method to return a BrowseCollection object based on search, field and filter criteria.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="genreID"></param>
        /// <param name="searchOn"></param>
        /// <returns></returns>
        public BrowseCollection getData(string search, int genreID, string searchOn)
        {
            BrowseCollection browseC = new BrowseCollection();
            if (search != null && genreID >= 0) // Filter on genre and search criteria
            {
                browseC.FetchForGenreAndSearch(genreID, search, searchOn);
            }
            else if (search != null)
                { //Filter on only search box criteria
                    browseC.FetchForSearch(search, searchOn);
                }
                    else if (genreID >= 0)
                        {
                            browseC.FetchForGenre(genreID); // Filter only on genre
                        }
                        else
                            {
                                browseC.FetchAll();
                            }
            return browseC;
        }
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
        /// <summary>
        /// Fetching data based on search and searchBy fields
        /// </summary>
        /// <param name="search"></param>
        /// <param name="searchBy"></param>
        public void FetchForSearch(string search, string searchBy)
        {
            DataTable dt = _da.GetSearchFilteredMovies(search, searchBy);
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// method used to fetch data that requires genreID, searchFor and searchBy
        /// </summary>
        /// <param name="genreID"></param>
        /// <param name="searchFor"></param>
        /// <param name="searchBy"></param>
        public void FetchForGenreAndSearch(int genreID, string searchFor, string searchBy)
        {
            DataTable dt = _da.GetGenreAndSearchFilteredMovies(genreID, searchFor, searchBy);
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// method to instantiate a browse object and then add it to a collection
        /// </summary>
        /// <param name="dt"></param>

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