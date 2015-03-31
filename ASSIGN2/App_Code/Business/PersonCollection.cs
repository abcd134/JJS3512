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
    /// Represents a collection of Person objects.
    /// </summary>
    public class PersonCollection : AbstractBusinessCollection<SinglePerson>
    {
        private PersonDA _da = new PersonDA();

        public PersonCollection()
        {

        }

        #region properties

        #endregion

        #region methods
        /// <summary>
        /// Fetch all the Art work data
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _da.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the art works with a given id. This should normally create a collection
        /// with either 0 or 1 art works. This way the single art work can be data binded to a data control.
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _da.GetById(id);
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the movies for a given person
        /// </summary>
        public void FetchForPerson(string name)
        {
            DataTable dt = _da.GetByName(name);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the Art work for a given keyword
        /// </summary>
        public void FetchForKeyword(int keywordId)
        {
            // to do
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                SinglePerson a = new SinglePerson();
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