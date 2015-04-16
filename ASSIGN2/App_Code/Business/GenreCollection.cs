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
    /// Summary description for GenreCollection
    /// </summary>
    public class GenreCollection : AbstractBusinessCollection<Genre>
    {
        private GenreDA _da = new GenreDA();
        /// <summary>
        /// Genre Collection Constructor
        /// </summary>
        public GenreCollection()
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
        /// Fetch all the crew roles with a given person id. 
        /// This should normally create a collection where
        /// the person had a non-acting role
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _da.GetGenresByMovieID(id);
            PopulateFromDataTable(dt);
        }
        public void FetchGenreNames()
        {
            DataTable dt = _da.GetGenreNames();
            PopulateFromDataTable(dt);
        }

        public void FetchTenGenreNames(Boolean top = true)
        {
            DataTable dt = _da.GetTenGenreNames(top);
            PopulateFromDataTable(dt);
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Genre a = new Genre();
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