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
    /// Summary description for Movie Image Collection
    /// </summary>
    public class MovieImageCollection : AbstractBusinessCollection<MovieImage>
    {
        private MovieImageDA _da = new MovieImageDA();

        public MovieImageCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region methods
        /// <summary>
        /// Fetch all the actors in database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _da.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all images for a particular movie.
        /// </summary>
        public void FetchForMovieId(int id, bool isMoviePoster)
        {
            DataTable dt = _da.GetByMovieImage(id, isMoviePoster );
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch for one image.
        /// </summary>
        public void FetchForImageID(int id)
        {
            DataTable dt = _da.GetByImageID(id);
            PopulateFromDataTable(dt);
        }
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                MovieImage a = new MovieImage();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static MovieImageCollection GetAll()
        {
            MovieImageCollection list = new MovieImageCollection();
            list.FetchAll();

            return list;
        }
        #endregion
    }
}