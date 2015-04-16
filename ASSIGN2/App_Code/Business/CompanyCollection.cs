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
    /// Summary description for CompanyCollection
    /// </summary>
    public class CompanyCollection : AbstractBusinessCollection<Company>
    {
        private MovieCompanyDA _da = new MovieCompanyDA();
        /// <summary>
        /// Constructor for a CompanyCollection object
        /// </summary>
        public CompanyCollection()
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
            DataTable dt = _da.GetByMovieID(id);
            PopulateFromDataTable(dt);
        }

        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Company a = new Company();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns></returns>
        public static CompanyCollection GetAll()
        {
            CompanyCollection list = new CompanyCollection();
            list.FetchAll();

            return list;
        }
        #endregion
    }
}