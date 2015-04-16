using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Summary description for ReviewCollection
    /// </summary>

    public class ReviewCollection : AbstractBusinessCollection<Review>
    {
        private ReviewDA _da = new ReviewDA();

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
        /// Fetch all the people who acted in a praticular movie.
        /// </summary>

        public void FetchReviewByID (int movie_id)
        {
            DataTable dt = _da.fetchReviewByMovieID(movie_id);
            PopulateFromDataTable(dt);
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Review a = new Review();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static CastCollection GetAll()
        {
            CastCollection list = new CastCollection();
            list.FetchAll();

            return list;
        }
        #endregion
    }
}