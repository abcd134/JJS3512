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
        /// Fetch all the information about all people
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _da.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch information about a person with a given id. This should 
        /// normally create a collection with either 0 or 1 SinglePersons.
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _da.GetByPersonID(id);
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch all the movies for a given person name
        /// </summary>
        public void FetchForPerson(string name)
        {
            DataTable dt = _da.GetByName(name);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }
        /// <summary>
        /// Fetch information on 3 people
        /// Specialized method for the Home Page
        /// </summary>
        public void FetchFor3PeopleIds(int id1, int id2, int id3)
        {
            DataTable dt = _da.GetBy3PersonID(id1, id2, id3);
            PopulateFromDataTable(dt);
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