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
/// Summary description for CastCollection
/// </summary>
    public class CastCollection : AbstractBusinessCollection<Cast>
    {
        private CastDA _da = new CastDA();

	    public CastCollection()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
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
        /// Fetch all the roles with a given person id. This should normally create a collection
        /// with roles. 
        /// </summary>
        public void FetchForId(int id)
        {
            DataTable dt = _da.GetMoviesByPersonID(id);
            PopulateFromDataTable(dt);
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Cast a = new Cast();
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