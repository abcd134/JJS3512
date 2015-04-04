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
    /// Summary description for CrewCollection
    /// </summary>
    public class CrewCollection : AbstractBusinessCollection<Crew>
    {
        private CrewDA _da = new CrewDA();
        public CrewCollection()
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
            DataTable dt = _da.GetMoviesByPersonID(id);
            PopulateFromDataTable(dt);
        }
        public void FetchForMovieId(int id)
        {
            DataTable dt = _da.GetByMovieID(id);
            PopulateFromDataTable(dt);
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Crew a = new Crew();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static CrewCollection GetAll()
        {
            CrewCollection list = new CrewCollection();
            list.FetchAll();

            return list;
        }
        #endregion
    }
}