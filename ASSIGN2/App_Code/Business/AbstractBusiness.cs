using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Repesents the base class for all business objects
    /// </summary>
    public abstract class AbstractBusiness
    {
        private int _id;
        private AbstractDA _dataAccess;

        /// <summary>
        /// Given a data table with data, populate the business objects data members.
        /// 
        /// Implemented by each business object subclass
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public abstract void PopulateDataMembersFromDataRow(DataRow table);
/*
        #region public methods
        /// <summary>
        /// Fetches a business object's data
        /// </summary>
        public bool FetchById(int id)
        {
            DataTable table = DataAccess.GetById(id);

            PopulateDataMembersFromDataRow(table.Rows[0]);
        }
        #endregion
 */
        #region protected properties
        /// <summary>
        /// The data access class used by this business object
        /// </summary>
        protected AbstractDA DataAccess
        {
            get { return _dataAccess; }
            set { _dataAccess = value; }
        }
        #endregion

        #region public properties

        /// <summary>
        /// The id of the business object
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion
    }
}