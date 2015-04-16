using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Summary description for Company
    /// </summary>
    public class Company : AbstractBusiness
    {
        private int _movieId;
        private string _companyName;
        private MovieCompanyDA _movieCompanyDA;
        /// <summary>
        /// Constructor for a MovieCompany object, including a MovieCompany Data access object
        /// </summary>
        public Company()
        {
            _movieCompanyDA = new MovieCompanyDA();
            base.DataAccess = _movieCompanyDA;
        }
        /// <summary>
        /// Method to obtain a row of validated data
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            // set the data members to the data retrieved from the database table/query

            if (row["movie_id"] == DBNull.Value)
                MovieID = -1;  // Error flag set that the movie ID was not found (should be impossible)
            else
                MovieID = (int)Convert.ToInt32(row["movie_ID"]);

            if (row["company_name"] == DBNull.Value)
                CompanyName = "";
            else
                CompanyName = (string)row["company_name"];
        }
        #region Getters and Setters
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        public int MovieID
        {
            get { return _movieId; }
            set { _movieId = value; }
        }
        #endregion
    }
}