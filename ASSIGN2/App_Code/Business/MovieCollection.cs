using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using System.Data.Common;

using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Represents a collection of Movie objects.
    /// 
    /// This collection is a bit unique in that we need to use it within an
    /// Person (since each person has their own list of miovies) and use
    /// it byself, say for searches (in that case it contains all movies)
    /// </summary>
    public class MovieCollection : AbstractBusinessCollection<SingleMovie>
    {
        private MovieDA _da = new MovieDA();

        public MovieCollection()
        {

        }

        #region properties

        #endregion

        #region methods
        /// <summary>
        /// Fetch all the movie data
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _da.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the movies with a given id. This should normally create a collection
        /// with either 0 or 1 movies. This way the single movie can be data bound to a data control.
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _da.GetById(id);
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the movies for a given person
        /// </summary>
        public void FetchForPerson(int personId)
        {
            DataTable dt = _da.GetByPerson(personId);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the movies for a given genre
        /// </summary>
        public void FetchForGenre(int genre)
        {
            // to do
        }
        /// <summary>
        /// Fetch all the movies for a given search string
        /// </summary>
        public void FetchForSearchString(string searchFor)
        {
            // to do
        }
        /// <summary>
        /// Fetch all the most frequently viewed movies
        /// </summary>
        public void FetchMostViewed()
        {
            // to do
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                SingleMovie a = new SingleMovie();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static MovieCollection GetAll()
        {
            MovieCollection list = new MovieCollection();
            list.FetchAll();

            return list;
        }
         #endregion
    }
}